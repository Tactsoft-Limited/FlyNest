using FlyNest.Application.ViewModels.RolePermission;
using FlyNest.SharedKernel.Core.Constants;
using FlyNest.SharedKernel.Core.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static FlyNest.SharedKernel.Entities.Identities.IdentityModel;

namespace FlyNest.App.Controllers.Admin;

public class RoleController(RoleManager<Role> roleManager) : Controller
{
    private readonly RoleManager<Role> _roleManager = roleManager;

    [HttpGet]
    [Authorize(Policy = Permissions.Roles.View)]
    public async Task<IActionResult> Index(int? pageNumber, int? pageSize)
    {
        var roles = _roleManager.Roles;

        var rs = await PaginatedList<Role>.CreateFromEfQueryableAsync(
            roles.AsNoTracking(),
            pageNumber ?? 1,
            pageSize ?? 12);
        var rolesViewModel = rs.Select(
            role => new RoleViewModel { Name = role.Name, Description = role.Description, Id = role.Id })
            .ToList();
        var response = new PaginatedList<RoleViewModel>(rolesViewModel, rs.Count, pageNumber ?? 1, pageSize ?? 12);

        return View(response);
    }

    [HttpGet]
    [Authorize(Policy = Permissions.Roles.Create)]
    public IActionResult Add() { return View(new AddRoleViewModel()); }

    [HttpPost]
    [Authorize(Policy = Permissions.Roles.Create)]
    public async Task<IActionResult> Add(AddRoleViewModel addRoleViewModel)
    {
        if(!ModelState.IsValid)
            return View(addRoleViewModel);
        if(await _roleManager.FindByNameAsync(addRoleViewModel.Name) != null)
        {
            ModelState.AddModelError(string.Empty, "The role already exists. Please try a different one!");
            return View(addRoleViewModel);
        }
        var appRole = new Role(addRoleViewModel.Name) { Description = addRoleViewModel.Description };
        var rs = await _roleManager.CreateAsync(appRole);
        if(rs.Succeeded)
            return RedirectToAction(
                "Index",
                "Role",
                new { id = appRole.Id, succeeded = rs.Succeeded, message = rs.ToString() });
        ModelState.AddModelError(string.Empty, rs.ToString());
        return View(addRoleViewModel);
    }

    [HttpGet]
    [Authorize(Policy = Permissions.Roles.ManageClaims)]
    public async Task<IActionResult> ManageRolePermissions(
        long roleId,
        string permissionValue,
        int? pageNumber,
        int? pageSize)
    {
        var role = await _roleManager.FindByIdAsync(roleId.ToString());
        if(role == null)
            return RedirectToAction("Index");
        var roleClaims = await _roleManager.GetClaimsAsync(role);
        var allPermissionss = PermissionHelper.GetAllPermissions();

        if(!string.IsNullOrWhiteSpace(permissionValue))
        {
            allPermissionss = allPermissionss.Where(
                x => x.Value.Contains(permissionValue.Trim(), StringComparison.CurrentCultureIgnoreCase))
                .ToList();
        }
        var managePermissionssClaim = new List<ManageClaimViewModel>();
        foreach(var permission in allPermissionss)
        {
            var managePermissionsClaim = new ManageClaimViewModel { Type = permission.Type, Value = permission.Value };
            if(roleClaims.Any(x => x.Value == permission.Value))
            {
                managePermissionsClaim.Checked = true;
            }
            managePermissionssClaim.Add(managePermissionsClaim);
        }
        var paginatedList = PaginatedList<ManageClaimViewModel>.CreateFromLinqQueryable(
            managePermissionssClaim.AsQueryable(),
            pageNumber ?? 1,
            pageSize ?? 12);
        var manageRolePermissionssViewModel = new ManageRolePermissionsViewModel
        {
            RoleId = roleId,
            RoleName = role.Name,
            PermissionValue = permissionValue,
            ManagePermissionsViewModel = paginatedList
        };
        if(allPermissionss.Count > 0)
            return View(manageRolePermissionssViewModel);
        return RedirectToAction("Index", "Role", new { succeeded = false, message = "No Permissionss exists" });
    }

    [HttpPost]
    [Authorize(Policy = Permissions.Roles.ManageClaims)]
    public async Task<IActionResult> ManageRoleClaims(ManageRoleClaimViewModel manageRoleClaimViewModel)
    {
        if(!ModelState.IsValid)
            return Json(new { Succeeded = false, Messaege = "failed" });
        var roleById = await _roleManager.FindByIdAsync(manageRoleClaimViewModel.RoleId.ToString());
        var roleByName = await _roleManager.FindByNameAsync(manageRoleClaimViewModel.RoleName);
        if(roleById != roleByName)
            return Json(new { Succeeded = false, Messaege = "failed" });
        var allClaims = await _roleManager.GetClaimsAsync(roleById);
        var claimExists =
            allClaims.Where(x => x.Type == manageRoleClaimViewModel.Type && x.Value == manageRoleClaimViewModel.Value)
            .ToList();
        switch(manageRoleClaimViewModel.Checked)
        {
            case true when claimExists.Count == 0:
                await _roleManager.AddClaimAsync(
                    roleById,
                    new Claim(manageRoleClaimViewModel.Type, manageRoleClaimViewModel.Value));
                break;
            case false when claimExists.Count > 0:
                foreach(var claim in claimExists)
                {
                    await _roleManager.RemoveClaimAsync(roleById, claim);
                }
                break;
        }
        return Json(new { Succeeded = true, Message = "Success" });
    }
}

