using Moq;
using ToH.BLL;
using ToH.Data;
using ToH.PL;
using ToH.PL.Screens;

namespace ToH.Tests.Screens;

public class DashboardScreenTest
{
    private Mock<IPrinter> _printer;
    private DashboardScreen _uui;
    private Mock<IHeroesController> _heroesController;
    private Mock<SessionController> _sessionController;

    public DashboardScreenTest()
    {
        _heroesController = new Mock<IHeroesController>();
        _sessionController = new Mock<SessionController>();
        _printer = new Mock<IPrinter>();
        _uui = new DashboardScreen(_heroesController.Object, _sessionController.Object, _printer.Object);
    }
}