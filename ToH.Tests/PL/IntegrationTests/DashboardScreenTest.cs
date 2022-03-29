using ToH.BLL;
using ToH.Data;
using ToH.PL.Screens;
using ToH.Tests.PL.IntegrationTests;
using Xunit;

namespace ToH.Tests.Screens;

public class DashboardScreenTest
{
    private ListPrinter _printer;
    private DashboardScreen _uui;
    private HeroesContainer db;
    private HeroesController heroesController;
    private SessionController sessionController;


    public DashboardScreenTest()
    {
        db = new HeroesContainer();
        heroesController = new HeroesController(db);
        sessionController = new SessionController();
        sessionController.Username = "Test";
        _printer = new ListPrinter();
        _uui = new DashboardScreen(heroesController, sessionController, _printer);
    }

    [Fact]
    public void ShouldShowDashboard()
    {
        _uui.Init();

        // Banner consists of 5 lines.
        var printed = _printer.Lines();
        var heroListBeginning = printed.FindLastIndex(s => s.StartsWith("+++++++"));
        Assert.Equal(4, heroListBeginning);
        
        // Top hero list consists of 3 heroes.   +1 is to exclude string "+++++...."
        Assert.Equal(3, printed.Count - (heroListBeginning + 1));
    }
}

