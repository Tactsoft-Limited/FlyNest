using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.SharedKernel.Core.Default;
using FlyNest.SharedKernel.Core.PaymentGateway;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Specialized;
using System.Text.Json;
using static FlyNest.SharedKernel.Core.PaymentGateway.SSLCommerzGateway;

namespace FlyNest.App.Controllers;

[AllowAnonymous]
public class HolidayController(ITourPackageRepository packageRepository, ICountryRepository countryRepository, IMapper mapper, IConfirmBookingRepository confirmBookingRepository, IOptions<SSLCommerzSetting> sslConfig) : Controller
{
    private readonly ITourPackageRepository _packageRepository = packageRepository;
    private readonly ICountryRepository _countryRepository = countryRepository;
    private readonly IConfirmBookingRepository _confirmBookingRepository = confirmBookingRepository;
    private readonly IMapper _mapper = mapper;
    private readonly SSLCommerzSetting _sslConfig = sslConfig.Value;

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Details()
    {
        return View();
    }

    public IActionResult International()
    {
        var countries = _countryRepository.GetAll();
        return View(_mapper.Map<List<VmCountry>>(countries));
    }

    public IActionResult GetPackagesByCountry(long id)
    {
        var countryPackage = _packageRepository.GetAll().Include(tp => tp.Country).Where(x => x.CountryId == id).ToList();
        var res = _mapper.Map<List<VmTourPackage>>(countryPackage);
        ViewBag.CountryName = _countryRepository.GetCountryNameById(id);
        return View(res);
    }
    public async Task<IActionResult> PackageDetails(long id)
    {
        var details = await _packageRepository.FirstOrDefaultAsync(id, x => x.Country);
        return View(_mapper.Map<VmTourPackage>(details));
    }

    public IActionResult Umrah()
    {
        var package = _packageRepository.GetAll().Where(x => x.PackageType == PackageType.Umrah).ToList();
        return View(_mapper.Map<List<VmTourPackage>>(package));
    }

    public IActionResult ExploreBD()
    {
        var package = _packageRepository.GetAll().Where(x => x.PackageType == PackageType.ExploreBD).ToList();
        return View(_mapper.Map<List<VmTourPackage>>(package));
    }

    [HttpGet]
    public async Task<IActionResult> Booking(long id)
    {

        var tourPackage = _mapper.Map<VmTourPackage>(await _packageRepository.FirstOrDefaultAsync(id));
        var checkout = new VmConfirmBooking
        {
            TourPackageId = tourPackage.Id,
            PackagePrice = tourPackage.PackagePrice,
            PackageTitle = tourPackage.Title,
        };

        return View(checkout);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Booking(VmConfirmBooking checkout)
    {

        if (ModelState.IsValid)
        {
            var storeId = _sslConfig.StoreId;
            var storePass = _sslConfig.StoreSecret;
            var baseUrl = $"{Request.Scheme}://{Request.Host}";
            var postData = new MultipartFormDataContent
            {
                { new StringContent($"{checkout.TotalAmount}"), "total_amount" },
                { new StringContent("BDT"), "currency" },

                // System Information
                { new StringContent($"{storeId}"), "store_id" },
                { new StringContent($"{storePass}"), "store_passwd" },
                { new StringContent($"{checkout.TransactionId}"), "tran_id" },
                { new StringContent($"{baseUrl}/Holiday/PaymentSuccess"), "success_url" },
                { new StringContent($"{baseUrl}/Holiday/PaymentFailed"), "fail_url" }, // "Fail.aspx" page needs to be created
                { new StringContent($"{baseUrl}/Holiday/PaymentCancel"), "cancel_url" }, // "Cancel.aspx" page needs to be created
                { new StringContent($"{baseUrl}/Ipn"), "ipn_url" }, // Backend IPN needs to be implemented

                // Customer Information
                { new StringContent($"{checkout.ClientName}"), "cus_name" },
                { new StringContent($"{checkout.ClientEmail}"), "cus_email" },
                { new StringContent("Address"), "cus_add1" },
                { new StringContent("Dhaka"), "cus_city" },
                { new StringContent("1000"), "cus_postcode" },
                { new StringContent("Bangladesh"), "cus_country" },
                { new StringContent($"{checkout.ClientPhone}"), "cus_phone" },

                // Misc Information
                { new StringContent("NO"), "shipping_method" },
                { new StringContent($"{checkout.TotalPerson}"), "num_of_item" },
                { new StringContent("Tour Package"), "product_category" },
                { new StringContent($"{checkout.PackageTitle}"), "product_name" },
                { new StringContent("physical-goods"), "product_profile" },
                { new StringContent("0"), "emi_option" }
            };

            //string ApiUrl = "https://sandbox.sslcommerz.com/gwprocess/v4/api.php";
            string ApiUrl = _sslConfig.AppUrl;

            var client = new HttpClient();
            var wr = new HttpRequestMessage(HttpMethod.Post, ApiUrl)
            {
                Content = postData
            };
            var r = client.Send(wr);
            var response = r.Content.ReadAsStream();
            SSLCommerzInitRes res = JsonSerializer.Deserialize<SSLCommerzInitRes>(response);
            return Redirect(res?.GatewayPageURL);

        }
        return View(checkout);
    }

    [HttpPost]
    public IActionResult PaymentSuccess()
    {
        if (!(!String.IsNullOrEmpty(Request.Form["status"]) && Request.Form["status"] == "VALID"))
        {
            ViewBag.SuccessInfo = "There some error while processing your payment. Please try again.";
            return View();
        }

        ViewBag.TranId = Request.Form["tran_id"];
        ViewBag.Amount = Request.Form["amount"];
        ViewBag.TranDate = $"{Request.Form["tran_date"]:MMMM dd, yyyy hh:mm tt}";

        return View();
    }
    [HttpPost]
    public IActionResult PaymentFailed()
    {
        ViewBag.FailInfo = "There some error while processing your payment. Please try again.";
        return View();
    }
    [HttpPost]
    public IActionResult PaymentCancel()
    {
        ViewBag.CancelInfo = "Your payment has been cancel";
        return View();
    }
}
