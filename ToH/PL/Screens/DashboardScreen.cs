using ToH.BLL;
using ToH.Data;

namespace ToH.PL.Screens;

public class DashboardScreen : Screen
{
    private readonly IHeroesController _heroesController;
    private readonly ISessionController _sessionController;
    private readonly IPrinter _printer;
    private int cursorPosition = 0;

    public DashboardScreen(IHeroesController heroesController, ISessionController sessionController, IPrinter printer)
    {
        _heroesController = heroesController;
        _sessionController = sessionController;
        _printer = printer;
    }
    public override void Init()
    {
        DrawDashboard();
    }
    
    public override void Up(IUi ui)
    {
        if (cursorPosition > 0)
        {
            cursorPosition -= 1;
        }
        DrawDashboard();
    }

    public override void Down(IUi ui)
    {
        if (_heroesController.GetAllHeroes().Count > cursorPosition)
        {
            cursorPosition += 1;
        }
        DrawDashboard();
    }

    public override void Enter(IUi ui)
    {
        if (cursorPosition == 0)
        {
            ui.Screen = ui.ScreenFactory.CreateScreen(typeof(HeroesListScreen));
        }
        else
        {
            var heroIndex = cursorPosition - 1;
            // TODO how to go back to right place
            ui.Screen = ui.ScreenFactory.CreateScreen(typeof(HeroScreen), _heroesController.GetDashboardHeroes()[heroIndex]);
        }
        
    }
    
    private void DrawDashboard()
    {
        var heroes = _heroesController.GetDashboardHeroes();

        _printer.Clear();
        _printer.PrintLine($"Welcome: " + _sessionController.Username.ToUpper());        
        _printer.PrintLine("+++++++++++++++++++++++++");
        _printer.PrintLine("   | GOTO Action / Hero ");
        _printer.PrintLine($" {(0 == cursorPosition ? "*" : " ")} | Heroes list");
        _printer.PrintLine("+++++++++++++++++++++++++");
        foreach (var (index, hero) in heroes.Select((value, i) => (i, value)))
        {
            _printer.PrintLine($" {(index + 1 == cursorPosition ? "*" : " ")} | {hero.Name.ToUpper()}");
        }
    }
}