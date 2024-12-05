﻿using NUnit.Framework;

using System;

using TestApp.Store;

namespace TestApp.UnitTests;

public class ShopTests
{
    //тестове на клас Shop
    private Shop shop; //помощен обект, чрез който ще извиквам методите от класа

    [SetUp]
    public void SetUp()
    {
        shop = new Shop(); //нов празен обект
    }

    [Test]
    public void Test_AddAndGetBoxes_ReturnsSortedBoxes()
    {
        // Arrange
        //1 продукт се съхранява в една 1 кутия
        string[] products =
        {
            "12345 Widget 5 10", // boxPrice = 50.00
            "54321 Gadget 3 15", // boxPrice = 45.00
            "98765 Gizmo 2 8"   // boxPrice = 16.00
            
        };
        string expected = $"12345{Environment.NewLine}-- Widget - $10.00: 5{Environment.NewLine}-- $50.00{Environment.NewLine}" +
                          $"54321{Environment.NewLine}-- Gadget - $15.00: 3{Environment.NewLine}-- $45.00{Environment.NewLine}" +
                          $"98765{Environment.NewLine}-- Gizmo - $8.00: 2{Environment.NewLine}-- $16.00";

        // Act
        string result = shop.AddAndGetBoxes(products);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddAndGetBoxes_ReturnsEmptyString_WhenNoProductsGiven()
    {
        //Arrange
        string[] products = Array.Empty<string>(); //празен масив с продукти
        string expected = string.Empty; //""

        //Act
        string result = shop.AddAndGetBoxes(products);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}