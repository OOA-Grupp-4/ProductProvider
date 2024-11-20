
using Business.Factories;
using Business.Models;
using Business.Service;
using FluentAssertions;

namespace Business_Tests;

public class OrderServiceTests
{
    private readonly OrderService _orderService;
    public OrderServiceTests()
    {
        _orderService = new OrderService();
    }

    [Fact]
    public void Admin__Can__ViewOrderDetails()
    {
        // Arrange
        
        var expectedOrder = new Order { Id = "Test ID", CustomerName = "Test Name", Status = OrderStatusFactory.Create("Pending"), Price = 100M, Quantity = 1 };
        _orderService.AddOrder(expectedOrder);

        // Act
        var result = _orderService.GetOrderDetails(expectedOrder.Id);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expectedOrder);
    }

    [Fact]
    public void Admin__Can__Update__OrderStatus()
    {
        // Arrange
        var order = new Order { Id = "Test ID", Status = OrderStatusFactory.Create("Pending")  };
        _orderService.AddOrder(order);

        // Act
        var updateOrder =  _orderService.UpdateOrderStatus("Test ID", "Shipped");
        var updatedOrderStatus = _orderService.GetOrders().FirstOrDefault(order => order.Id == "Test ID");

        // Assert
        updateOrder.Should().BeTrue();
        updatedOrderStatus?.Status.Status.Should().Be("Shipped");
    }

    [Fact]
    public void Admin__Can__ViewAllOrders()
    {
        // Arrange
        var order = new Order { Id = "Test Id", CustomerName = "Test Customer", Price = 1, Quantity = 1, Status = OrderStatusFactory.Create("Delivered") };
        _orderService.AddOrder(order);

        // Act
        var orderList = _orderService.GetOrders();

        // Assert
        orderList.Should().HaveCount(1);
        orderList.Should().Contain(order);
    }

    [Fact]
    public void Admin__Can__Update__OrderDelivery()
    {
        // Arrange
        var order = new Order { Id = "Test ID", CustomerName = "Test Name", Price = 500, Quantity = 2, Status = OrderStatusFactory.Create("Pending"),  };
        _orderService.AddOrder(order);

        // Act
        var result = _orderService.UpdateOrderDelivery(order.Id, "New delivery address", "New customer details", "New delivery date");
        var updatedOrderDelivery = _orderService.GetOrders().FirstOrDefault(o => o.Id == order.Id);


        // Assert
        result.Should().BeTrue();
        updatedOrderDelivery.Should().NotBeNull();
        updatedOrderDelivery!.Delivery.Address.Should().Be("New delivery address");
        updatedOrderDelivery.Delivery.CustomerDetails.Should().Be("New customer details");
        updatedOrderDelivery.Delivery.Date.Should().Be("New delivery date");
    }



 

}
