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

  [TestMethod]
  public void GetAll_ReturnsAllVendorObjects_VendorList()
  {
    //Arrange
    string name01 = "Broken Robot";
    string name02 = "Just Bob";
    Vendor newVendor1 = new Vendor(name01);
    Vendor newVendor2 = new Vendor(name02);
    List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };

        //Act
    List<Vendor> result = Vendor.GetAll();

    //Assert
    CollectionAssert.AreEqual(newList, result);
  }

    [TestMethod]
    public void Find_ReturnsCorrectVendor_Vendor()
  {
    //Arrange
    string name01 = "Work";
    string name02 = "School";
    Vendor newVendor1 = new Vendor(name01);
    Vendor newVendor2 = new Vendor(name02);

    //Act
    Vendor result = Vendor.Find(2);

    //Assert
    Assert.AreEqual(newVendor2, result);
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