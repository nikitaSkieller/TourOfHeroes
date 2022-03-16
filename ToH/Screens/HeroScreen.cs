using ToH.Data;

namespace ToH.Screens;

public class HeroScreen : Screen
{
    public Hero Hero { get; set; }
    private readonly IPrinter _printer;

    public HeroScreen(Hero hero, IPrinter printer)
    {
        Hero = hero;
        _printer = printer;
    }

    public override void Init()
    {
        _printer.Clear();
        _printer.PrintLine("Hero details");
        _printer.PrintLine("");
        _printer.PrintLine($"Id: {Hero.Id}");
        _printer.PrintLine($"Name: {Hero.Name.ToUpper()}");
    }

    public override void Escape(IUi ui)
    {
        var newScreen = ui.ScreenFactory.CreateScreen(typeof(HeroesListScreen));
        if (newScreen != null)
        {
            ui.Screen = newScreen;
        }
    }
}