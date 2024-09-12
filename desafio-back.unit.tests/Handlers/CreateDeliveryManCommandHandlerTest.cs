using AutoMapper;
using desafio_back.api.Handlers.Commands;
using desafio_back.domain.Abstractions.Services;
using desafio_back.domain.Entities.DomainEntities;
using dsafio_back.tests.Mocks.Commands;
using dsafio_back.tests.Mocks.Factories;
using FluentAssertions;
using Moq;

namespace desafio_back.tests.Handlers;

public class CreateDeliveryManCommandHandlerTests
{
    private readonly Mock<IDeliverymanService> _serviceMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly CreateDeliveryManCommandHandler _handler;

    public CreateDeliveryManCommandHandlerTests()
    {
        _serviceMock = new Mock<IDeliverymanService>();
        _mapperMock = new Mock<IMapper>();
        _handler = new CreateDeliveryManCommandHandler(_serviceMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task Handle_ValidCommand_ReturnsDeliveryMan()
    {
        // Arrange
        var command = DeliveryManCommandFactory.CreateValidCommand();
        var expectedDeliveryMan = DeliveryManFactory.CreateValidDeliveryMan();

        _mapperMock.Setup(m => m.Map<DeliveryMan>(command)).Returns(expectedDeliveryMan);
        _serviceMock.Setup(s => s.SaveAsync(expectedDeliveryMan)).ReturnsAsync(expectedDeliveryMan);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().BeEquivalentTo(expectedDeliveryMan);
        _mapperMock.Verify(m => m.Map<DeliveryMan>(command), Times.Once);
        _serviceMock.Verify(s => s.SaveAsync(expectedDeliveryMan), Times.Once);
    }

    [Fact]
    public async Task Handle_InvalidCommand_ReturnsNull()
    {
        // Arrange
        var command = DeliveryManCommandFactory.CreateInvalidCommand();

        var expectedDeliveryMan = DeliveryManFactory.CreateInvalidDeliveryMan();

        _mapperMock.Setup(m => m.Map<DeliveryMan>(command)).Returns(expectedDeliveryMan);
        _serviceMock.Setup(s => s.SaveAsync(expectedDeliveryMan)).ReturnsAsync((DeliveryMan)null);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().BeNull();
        _mapperMock.Verify(m => m.Map<DeliveryMan>(command), Times.Once);
        _serviceMock.Verify(s => s.SaveAsync(expectedDeliveryMan), Times.Once);
    }
}
