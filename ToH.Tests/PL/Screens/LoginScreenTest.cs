using Moq;
using ToH.PL;
using ToH.PL.Screens;
using Xunit;

namespace ToH.Tests.Screens;

public class LoginScreenTest
{
    private Mock<IPrinter> _printer;
    private LoginScreen _uut;

    public LoginScreenTest()
    {
        _printer = new Mock<IPrinter>();
        _uut = new LoginScreen(_printer.Object);
    }

    [Fact]
    public void ShouldShowWriteUsername_WhenInitIsCalled()
    {
        // Act
        _uut.Init();
        
        _printer.Verify(p => p.Clear(), Times.Once);
        _printer.Verify(p => p.PrintLine(It.Is<string>(s => s == "Write username:")), Times.Once);
    }
}