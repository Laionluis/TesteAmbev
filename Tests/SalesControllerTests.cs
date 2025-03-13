using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TesteAmbev.Controllers;
using TesteAmbev.DTOs;
using TesteAmbev.Features.Commands;
using TesteAmbev.Features.Querys;
using Xunit;

namespace TesteAmbev.Tests
{
    public class SalesControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly SalesController _controller;

        public SalesControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new SalesController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetSale_ReturnsNotFound_WhenSaleDoesNotExist()
        {
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetSaleQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync((SaleDTO)null);

            var result = await _controller.GetSale(Guid.NewGuid());

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetSale_ReturnsSale_WhenSaleExists()
        {
            var saleDto = new SaleDTO { Id = Guid.NewGuid(), SaleDate = DateTime.UtcNow, TotalAmount = 100 };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetSaleQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(saleDto);

            var result = await _controller.GetSale(saleDto.Id);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<SaleDTO>(okResult.Value);
            Assert.Equal(saleDto.Id, returnValue.Id);
        }

        [Fact]
        public async Task CreateSale_ReturnsCreatedSale()
        {
            var saleDto = new SaleDTO { Id = Guid.NewGuid(), SaleDate = DateTime.UtcNow, TotalAmount = 100 };

            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateSaleCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(saleDto);

            var result = await _controller.CreateSale(saleDto);

            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<SaleDTO>(createdResult.Value);
            Assert.Equal(saleDto.Id, returnValue.Id);
        }

        [Fact]
        public async Task CancelSale_ReturnsNoContent()
        {
            _mediatorMock.Setup(m => m.Send(It.IsAny<CancelSaleCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(Unit.Value);

            var result = await _controller.CancelSale(Guid.NewGuid());

            Assert.IsType<NoContentResult>(result);
        }
    }
}
