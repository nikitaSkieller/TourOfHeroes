using Moq;
using ToH.Data;
using ToH.Screens;
using Xunit;

namespace ToH.Tests.Screens;

public class ScreenFactoryTest
{
    private ScreenFactory _uut;
    private Mock<IPrinter> _printer;
    private Mock<IDatabase> _database;

    public ScreenFactoryTest()
    {
        _database = new Mock<IDatabase>();
        _printer = new Mock<IPrinter>();
        _uut = new ScreenFactory(_database.Object, _printer.Object);
    }
    
    [Fact]
    public void ShouldCreateAHeroListScreen_WhenGivenHeroListScreenType()
    {
        // act
        var screen = _uut.CreateScreen(typeof(HeroesListScreen));
        
        // Assert
        Assert.IsType<HeroesListScreen>(screen);
    }

    [Fact]
    public void ShouldCreateAHeroScreen_WhenGivenHeroScreenType()
    {
        // Arrange
        var hero = new Hero()
        {
            Id = 1,
            Name = "TestHero1"
        };
        
        // Act
        var screen = _uut.CreateScreen(typeof(HeroScreen), hero);

        // Assert
        Assert.IsType<HeroScreen>(screen);
    }
    
    [Fact]
    public void ShouldAttachHeroToHeroScreen_WhenGivenHeroScreenType()
    {
        // Arrange
        var hero = new Hero()
        {
            Id = 1,
            Name = "TestHero1"
        };
        
        // Act
        HeroScreen screen = (HeroScreen) _uut.CreateScreen(typeof(HeroScreen), hero);

        // Assert
        Assert.Equal(hero, screen.Hero);
    }
    
    [Fact]
    public void ShouldUpdateHeroScreen_WhenGivenANewHeroScreenType()
    {
        // Arrange
        var hero1 = new Hero()
        {
            Id = 1,
            Name = "TestHero1"
        };
        _uut.CreateScreen(typeof(HeroScreen), hero1);
        var hero2 = new Hero()
        {
            Id = 2,
            Name = "TestHero2"
        };
        
        // Act
        var screen = (HeroScreen) _uut.CreateScreen(typeof(HeroScreen), hero2);


        // Assert
        Assert.Equal(hero2, screen.Hero);
    }
}