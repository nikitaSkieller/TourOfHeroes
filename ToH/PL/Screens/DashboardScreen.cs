using ToH.BLL;
using ToH.Data;

namespace ToH.PL.Screens;

public class DashboardScreen : Screen
{
    private readonly IHeroesController _heroesController;
    private readonly IPrinter _printer;
    private int cursorPosition = 0;

    public DashboardScreen(IHeroesController heroesController, IPrinter printer)
    {
        _heroesController = heroesController;
        _printer = printer;
    }
    public override void Init()
    {
    }
    
    
}