using Moq;
using ToH.Screens;
using Xunit;

namespace ToH.Tests.Screens;

public class UiTest
{
    private readonly Ui uut;
    private Mock<Controller> _controller;
    private Mock<Screen> _screen;

    public UiTest()
    {
        _controller = new Mock<Controller>();
        _screen = new Mock<Screen>();
        uut = new Ui(_controller.Object, _screen.Object);
    }

    [Fact]
    public void ShouldExecuteNoneActionOnScren_WhenPrintIsCalled()
    {
        // Act
        uut.Print();
        
        // Assert
        _screen.Verify(screen => screen.None(It.Is<Ui>(ui => ui.Equals(uut))), Times.Once);
    }
    
    [Fact]
    public void ShouldExecuteNoneActionOnScren_WhenUpdateIscalledAndControllerActionIsNone()
    {
        // Arrange
        _controller.Setup(controller => controller.Action).Returns(Action.None);
        
        // Act
        uut.Print();
        
        // Assert
        _screen.Verify(screen => screen.None(It.Is<Ui>(ui => ui.Equals(uut))), Times.Once);
    }
}