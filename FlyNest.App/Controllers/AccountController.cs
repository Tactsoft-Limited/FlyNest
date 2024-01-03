using FlyNest.Application.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static FlyNest.SharedKernel.Entities.Identities.IdentityModel;

namespace FlyNest.App.Controllers;

[Authorize]
[Route("[controller]/[action]")]
public class AccountController(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    IEmailSender emailSender,
    ILogger<AccountController> logger) : Controller
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly SignInManager<User> _signInManager = signInManager;
    private readonly IEmailSender _emailSender = emailSender;
    private readonly ILogger _logger = logger;

    [TempData]
    public string ErrorMessage { get; set; }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Login(string returnUrl = null)
    {
        await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(VmLogin model, string returnUrl = null)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(
                model.Email,
                model.Password,
                model.RememberMe,
                lockoutOnFailure: true);

            switch (result.Succeeded)
            {
                case true:
                    ViewBag.IsLoginSucceeded = true;
                    TempData["SuccessMessage"] = "Login Success";
                    _logger.LogInformation("User logged in.");
                    return string.IsNullOrEmpty(returnUrl) || returnUrl == "/" && !Url.IsLocalUrl(returnUrl)
                        ? Redirect(returnUrl)
                        : RedirectToAction(nameof(Index), "Dashboard");

                case false when result.RequiresTwoFactor:
                    return RedirectToAction(nameof(LoginWith2fa), new { returnUrl, model.RememberMe });

                case false when result.IsLockedOut:
                    _logger.LogWarning("User account locked out.");
                    return RedirectToAction(nameof(Lockout));

                default:
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    ViewBag.IsLoginSucceeded = "Invalid login attempt.";
                    return View(model);
            }
        }
        return View(model);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> LoginWith2fa(bool rememberMe, string returnUrl = null)
    {
        _ = await _signInManager.GetTwoFactorAuthenticationUserAsync() ??
            throw new ApplicationException($"Unable to load two-factor authentication user.");
        var model = new VmLoginWith2fa { RememberMe = rememberMe };
        ViewData["ReturnUrl"] = returnUrl;

        return View(model);
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LoginWith2fa(VmLoginWith2fa model, bool rememberMe, string returnUrl = null)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _signInManager.GetTwoFactorAuthenticationUserAsync() ??
            throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        var authenticatorCode = model.TwoFactorCode.Replace(" ", string.Empty).Replace("-", string.Empty);

        var result = await _signInManager.TwoFactorAuthenticatorSignInAsync(
            authenticatorCode,
            rememberMe,
            model.RememberMachine);

        switch (result.Succeeded)
        {
            case true:
                _logger.LogInformation("User with ID {UserId} logged in with 2fa.", user.Id);
                return RedirectToLocal(returnUrl);

            case false when result.IsLockedOut:
                _logger.LogWarning("User with ID {UserId} account locked out.", user.Id);
                return RedirectToAction(nameof(Lockout));

            default:
                _logger.LogWarning("Invalid authenticator code entered for user with ID {UserId}.", user.Id);
                ModelState.AddModelError(string.Empty, "Invalid authenticator code.");
                return View();
        }
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> LoginWithRecoveryCode(string returnUrl = null)
    {
        _ = await _signInManager.GetTwoFactorAuthenticationUserAsync() ??
            throw new ApplicationException($"Unable to load two-factor authentication user.");

        ViewData["ReturnUrl"] = returnUrl;

        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LoginWithRecoveryCode(VmLoginWithRecoveryCode model, string returnUrl = null)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _signInManager.GetTwoFactorAuthenticationUserAsync() ??
            throw new ApplicationException($"Unable to load two-factor authentication user.");

        var recoveryCode = model.RecoveryCode.Replace(" ", string.Empty);

        var result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(recoveryCode);

        switch (result.Succeeded)
        {
            case true:
                _logger.LogInformation("User with ID {UserId} logged in with a recovery code.", user.Id);
                return RedirectToLocal(returnUrl);

            case false when result.IsLockedOut:
                _logger.LogWarning("User with ID {UserId} account locked out.", user.Id);
                return RedirectToAction(nameof(Lockout));

            default:
                _logger.LogWarning("Invalid recovery code entered for user with ID {UserId}", user.Id);
                ModelState.AddModelError(string.Empty, "Invalid recovery code entered.");
                return View();
        }
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Lockout() { return View(); }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        HttpContext.Session.Clear(); // Clear session data
        TempData["SuccessMessage"] = "Logout Success";
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public IActionResult ExternalLogin(string provider, string returnUrl = null)
    {
        var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
        var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        return Challenge(properties, provider);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
    {
        if (remoteError != null)
        {
            ErrorMessage = $"Error from external provider: {remoteError}";
            return RedirectToAction(nameof(Login));
        }
        var info = await _signInManager.GetExternalLoginInfoAsync();
        switch (info)
        {
            case null:
                return RedirectToAction(nameof(Login));
        }

        // Sign in the user with this external login provider if the user already has a login.
        var result = await _signInManager.ExternalLoginSignInAsync(
            info.LoginProvider,
            info.ProviderKey,
            isPersistent: false,
            bypassTwoFactor: true);

        switch (result.Succeeded)
        {
            case true:
                _logger.LogInformation("User logged in with {Name} provider.", info.LoginProvider);
                return RedirectToLocal(returnUrl);

            case false when result.IsLockedOut:
                return RedirectToAction(nameof(Lockout));

            default:
                // If the user does not have an account, then ask the user to create an account.
                ViewData["ReturnUrl"] = returnUrl;
                ViewData["LoginProvider"] = info.LoginProvider;
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                return View("ExternalLogin", new VmExternalLogin { Email = email });
        }
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ExternalLoginConfirmation(VmExternalLogin model, string returnUrl = null)
    {
        if (ModelState.IsValid)
        {
            // Get the information about the user from the external login provider
            var info = await _signInManager.GetExternalLoginInfoAsync() ??
                throw new ApplicationException("Error loading external login information during confirmation.");
            var user = new User { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                result = await _userManager.AddLoginAsync(user, info);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created an account using {Name} provider.", info.LoginProvider);
                    return RedirectToLocal(returnUrl);
                }
            }
            AddErrors(result);
        }

        ViewData["ReturnUrl"] = returnUrl;
        return View(nameof(ExternalLogin), model);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> ConfirmEmail(string userId, string code)
    {
        if (userId == null || code == null)
        {
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            throw new ApplicationException($"Unable to load user with ID '{userId}'.");
        }
        var result = await _userManager.ConfirmEmailAsync(user, code);
        return View(result.Succeeded ? "ConfirmEmail" : "Error");
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult ForgotPassword() { return View(); }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ForgotPassword(VmForgotPassword model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !await _userManager.IsEmailConfirmedAsync(user))
            {
                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            }
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = Url.Action(user.Id.ToString(), code, Request.Scheme);
            var result = _emailSender.SendEmailAsync(
                model.Email,
                "Reset Password",
                $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");
            return RedirectToAction(nameof(ForgotPasswordConfirmation));
        }
        return View(model);
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult ForgotPasswordConfirmation() { return View(); }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult ResetPassword(string code = null)
    {
        switch (code)
        {
            case null:
                throw new ApplicationException("A code must be supplied for password reset.");
        }
        var model = new VmResetPassword { Code = code };
        return View(model);
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword(VmResetPassword model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        var user = await _userManager.FindByEmailAsync(model.Email);
        switch (user)
        {
            case null:
                // Don't reveal that the user does not exist
                return RedirectToAction(nameof(ResetPasswordConfirmation));
        }
        var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
        if (result.Succeeded)
        {
            return RedirectToAction(nameof(ResetPasswordConfirmation));
        }
        AddErrors(result);
        return View();
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult ResetPasswordConfirmation() { return View(); }


    [HttpGet]
    public IActionResult AccessDenied() { return View(); }

    #region Helpers
    private void AddErrors(IdentityResult result)
    {
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
    }

    private IActionResult RedirectToLocal(string returnUrl)
    { return Url.IsLocalUrl(returnUrl) ? Redirect(returnUrl) : RedirectToAction(nameof(HomeController.Index), "Home"); }
    #endregion
}
