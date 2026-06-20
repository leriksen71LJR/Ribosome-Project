using Fortress.Console.Components.Actions.Contracts;
using Fortress.Console.Components.Actions.Implementations;
using Fortress.Console.Components.Actions.Model;
using Fortress.Console.Components.Infrastructure.Contracts;
using Fortress.Console.Components.Logging.Contracts;
using Fortress.Console.Components.Security.Contracts;
using Moq;
using Xunit;

namespace Fortress.Console.Tests.Components.Actions;

/// <summary>
/// Example unit tests for AddTaskHandler.
/// This file demonstrates the expected testing patterns for Fortress handlers.
/// Aligned with the "Actions Component" naming convention.
/// </summary>
public class AddTaskHandlerTests
{
    private readonly Mock<IConsole> _consoleMock;
    private readonly Mock<IInputService> _inputMock;
    private readonly Mock<IStorageService> _storageMock;
    private readonly Mock<ILoggingService> _loggerMock;
    private readonly Mock<ISessionService> _sessionMock;
    private readonly AddTaskHandler _handler;

    public AddTaskHandlerTests()
    {
        _consoleMock = new Mock<IConsole>();
        _inputMock = new Mock<IInputService>();
        _storageMock = new Mock<IStorageService>();
        _loggerMock = new Mock<ILoggingService>();
        _sessionMock = new Mock<ISessionService>();

        _handler = new AddTaskHandler(
            _consoleMock.Object,
            _inputMock.Object,
            _storageMock.Object,
            _loggerMock.Object,
            _sessionMock.Object);
    }

    [Fact]
    public void IsVisible_ReturnsTrue_WhenSessionIsUnlocked()
    {
        // Arrange
        _sessionMock.Setup(s => s.IsUnlocked).Returns(true);
        var context = new ActionContext();

        // Act
        var result = _handler.IsVisible(context);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsVisible_ReturnsFalse_WhenSessionIsLocked()
    {
        // Arrange
        _sessionMock.Setup(s => s.IsUnlocked).Returns(false);
        var context = new ActionContext();

        // Act
        var result = _handler.IsVisible(context);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Execute_ReturnsFalse_WhenSessionIsLocked()
    {
        // Arrange
        _sessionMock.Setup(s => s.IsUnlocked).Returns(false);
        var context = new ActionContext();

        // Act
        var result = _handler.Execute(context);

        // Assert
        Assert.False(result);
        Assert.Contains(context.ValidationErrors, e => e.Contains("Session must be unlocked"));
    }

    [Fact]
    public void Execute_ReturnsFalse_WhenTitleIsEmpty()
    {
        // Arrange
        _sessionMock.Setup(s => s.IsUnlocked).Returns(true);
        _inputMock.Setup(i => i.ReadLine()).Returns(""); // Empty title
        var context = new ActionContext();

        // Act
        var result = _handler.Execute(context);

        // Assert
        Assert.False(result);
        Assert.Contains(context.ValidationErrors, e => e.Contains("Title is required"));
    }

    [Fact]
    public void Execute_SavesTaskAndReturnsTrue_WhenValidInputProvided()
    {
        // Arrange
        _sessionMock.Setup(s => s.IsUnlocked).Returns(true);
        _sessionMock.Setup(s => s.Touch());

        _inputMock.SetupSequence(i => i.ReadLine())
            .Returns("Buy groceries")           // Title
            .Returns("2026-06-15")              // Due date
            .Returns("1")                       // Priority
            .Returns("food, urgent");           // Tags

        var context = new ActionContext();

        // Act
        var result = _handler.Execute(context);

        // Assert
        Assert.True(result);
        _storageMock.Verify(s => s.SaveItem(It.IsAny<TaskItem>()), Times.Once);
        Assert.Single(context.Items);
        Assert.IsType<TaskItem>(context.Items[0]);
        _loggerMock.Verify(l => l.Info(It.Is<string>(s => s.Contains("Task added")), It.IsAny<object[]>()), Times.Once);
    }

    [Fact]
    public void Execute_HandlesException_AndReturnsFalse()
    {
        // Arrange
        _sessionMock.Setup(s => s.IsUnlocked).Returns(true);
        _inputMock.Setup(i => i.ReadLine()).Returns("Valid title");
        _storageMock.Setup(s => s.SaveItem(It.IsAny<TaskItem>())).Throws(new Exception("DB failure"));

        var context = new ActionContext();

        // Act
        var result = _handler.Execute(context);

        // Assert
        Assert.False(result);
        Assert.Single(context.ExceptionErrors);
        _loggerMock.Verify(l => l.Error(It.IsAny<string>(), It.IsAny<Exception>()), Times.Once);
    }
}
