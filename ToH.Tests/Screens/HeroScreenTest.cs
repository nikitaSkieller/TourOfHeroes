using Moq;
using ToH.Data;
using ToH.Screens;
using Xunit;

namespace ToH.Tests.Screens;

public class HeroScreenTest
{
    private Mock<IPrinter> _printer;

    public HeroScreenTest()
    {
        _printer = new Mock<IPrinter>(MockBehavior.Strict);
    }

    [Fact]
    public void ShouldPrintHeroName_WhenInitialized()
    {
        // Arrange
        var hero = new Hero()
        {
            Id = 1,
            Name = "TestHero1"
        };
        var uut = new HeroScreen(hero, _printer.Object);
        var seq = new MockSequence();
        _printer.InSequence(seq).Setup(p => p.Clear());
        _printer.InSequence(seq)
            .Setup(p => p.PrintLine(
                It.Is<string>(s => s.Contains("Hero details"))));
        _printer.InSequence(seq)
            .Setup(p => p.PrintLine(
                It.Is<string>(s => s == "")));
        _printer.InSequence(seq)
            .Setup(p => p.PrintLine(
                It.Is<string>(s => s.Contains("Id: 1"))));
        _printer.InSequence(seq)
            .Setup(p => p.PrintLine(
                It.Is<string>(s => s.Contains("Name: TESTHERO1"))));

        // Act
        uut.Init();
        
        // Assert
        _printer.Verify(p => p.PrintLine(It.IsAny<string>()), Times.Exactly(4));
    }
}