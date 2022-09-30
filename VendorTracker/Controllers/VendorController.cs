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
      List<Order> vendorOrder = selectedVendor.Orders;
      model.Add("vendor", selectedVendor);
      model.Add("orders", vendorOrder);
      return View(model);
    }

  //   [HttpGet("/vendors/{vendorId}/orders/{orderId}")]
  //   public ActionResult Show(int vendorId, int orderId)
  //   {
  //     Order order = Order.Find(orderId);
  //     Vendor vendor = Vendor.Find(vendorId);
  //     Dictionary<string, object> model = new Dictionary<string, object>();
  //     model.Add("order", order);
  //     model.Add("vendor", vendor);
  //     return View(model);
  // }
   // // This one creates new Orders within a given vednor, not new vendors:
    [HttpPost("/vendors/{vendorId}/orders")]
    public ActionResult Create(int vendorId, string orderDescription)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor foundVendor = Vendor.Find(vendorId);
      Order newOrder = new Order(orderDescription);
      foundVendor.AddOrder(newOrder);
      List<Order> vendorOrders = foundVendor.Orders;
      model.Add("orders", vendorOrders);
      model.Add("vendor", foundVendor);
      return View("Show", model);
    }



    // // This one creates new Orders within a given vednor, not new vendors:

    // [HttpPost("/vendors/{vednorId}/order")]
    // public ActionResult Create(int vednorId, string orderDescription)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Vendor foundVendor = Vendor.Find(vendorId);
    //   Order newOrder = new Item(itemDescription);
    //   foundVendor.AddItem(newOrder);
    //   List<Item> vendorItems = foundVendor.Items;
    //   model.Add("order", vendorItems);
    //   model.Add("vendor", foundVendor);
    //   return View("Show", model);
    // }

  }
}