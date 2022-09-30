using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models;

namespace VendorTracker.Controllers
{
  public class vendorsController : Controller
  {

    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendor> allvendors = Vendor.GetAll();
      return View(allvendors);
    }

    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string vendorName)
    {
      Vendor newVendor = new Vendor(vendorName);
      return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor selectedVendor = Vendor.Find(id);
      List<Order> vendorOrders = selectedvendor.Orders;
      model.Add("vendor", selectedVendor);
      model.Add("order", vednorOrders);
      return View(model);
    }


    // This one creates new Orders within a given vednor, not new vendors:

    [HttpPost("/vendors/{vednorId}/order")]
    public ActionResult Create(int vednorId, string orderDescription)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor foundVendor = Vendor.Find(vendorId);
      Order newOrder = new Item(itemDescription);
      foundVendor.AddItem(newOrder);
      List<Item> vendorItems = foundVendor.Items;
      model.Add("order", vendorItems);
      model.Add("vendor", foundVendor);
      return View("Show", model);
    }

  }
}