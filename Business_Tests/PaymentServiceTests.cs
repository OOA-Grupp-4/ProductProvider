using Business.Interfaces;
using FluentAssertions;
using Moq;

namespace Business_Tests;

public class PaymentServiceTests
{


    [Fact]
    public void User__Can__PayWithPayPal__Successfully()
    {
        // Arrange
        var mockPaymentService = new Mock<IPaymentService>();

        mockPaymentService.Setup(service => service.PayWithPayPal(It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<string>())).Returns(true);

        var paymentService = mockPaymentService.Object;

        // Act
        var result = paymentService.PayWithPayPal("Test User", 250000M, "testaccount@paypal.com");

        // Assert
        result.Should().Be(true);
    }
}
