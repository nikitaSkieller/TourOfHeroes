using ToH.BLL;

namespace ToH.PL.Screens;

public class HeroesListScreen : Screen
{
    private readonly IHeroesController _heroesController;
    private readonly IPrinter _printer;
    private int cursorPosition = 0;

    public HeroesListScreen(IHeroesController heroesController, IPrinter printer)
    {
        _heroesController = heroesController;
        _printer = printer;
    }

    public override void None(IUi ui)
    {
        ShowHeroes();
    }

    public override void Up(IUi ui)
    {
        if (cursorPosition > 0)
        {
            cursorPosition -= 1;
        }
        ShowHeroes();
    }

    public override void Down(IUi ui)
    {
        if (_heroesController.GetAllHeroes().Count - 1 > cursorPosition)
        {
            cursorPosition += 1;
        }
        ShowHeroes();
    }

    public override void Enter(IUi ui)
    {
        var newScreen = ui.ScreenFactory.CreateScreen(typeof(HeroScreen), _heroesController.GetAllHeroes()[cursorPosition]);
        if (newScreen != null)
        {
            ui.Screen = newScreen;
        }
    }

    public override void Init()
    {
        ShowHeroes();
    }

    private void ShowHeroes()
    {
        var heroes = _heroesController.GetAllHeroes();
        _printer.Clear();

        _printer.PrintLine("   | Id | Name ");
        foreach (var (index, hero) in heroes.Select((value, i) => (i, value)))
        {
            _printer.PrintLine($" {(index == cursorPosition ? "*" : " ")} | {hero.Id} | {hero.Name.ToUpper()}");
        }
    } 

}