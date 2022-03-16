using ToH.Data;

namespace ToH.Screens;

public class HeroScreen : Screen
{
    private readonly Hero _hero;
    private readonly IPrinter _printer;

    public HeroScreen(Hero hero, IPrinter printer)
    {
        _hero = hero;
        _printer = printer;
    }

    public override void Init()
    {
        _printer.Clear();
        _printer.PrintLine("Hero details");
        _printer.PrintLine("");
        _printer.PrintLine($"Id: {_hero.Id}");
        _printer.PrintLine($"Name: {_hero.Name.ToUpper()}");
    }
}