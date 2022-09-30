using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorTracker.Models;
using System.Collections.Generic;
using System;

namespace VendorTracker.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {

    public void Dispose()
    {
      Vendor.ClearAll();
    }

  [TestMethod]
  public void GetName_ReturnsName_String()
  {
    //Arrange
    string name = "Test Vendor";
    Vendor newVendor = new Vendor(name);

    //Act
    string result = newVendor.Name;

    //Assert
    Assert.AreEqual(name, result);
  }

  [TestMethod]
  public void GetId_ReturnsVendorId_Int()
  {
    //Arrange
    string name = "Test Vendor";
    Vendor newVendor = new Vendor(name);
    
      //Act
    int result = newVendor.Id;
    
    //Assert
    Assert.AreEqual(1, result);
  }



    // [TestMethod]
    // public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    // {
    //   Vendor newVendor = new Vendor("test vendor");
    //   Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    // }
//   }
  }
}