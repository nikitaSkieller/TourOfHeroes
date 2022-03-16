using ToH.Data;
using ToH.Log;

namespace ToH.Screens;

public class HeroesListScreen : Screen
{
    private readonly IDatabase _db;
    private readonly IPrinter _printer;
    private int cursorPosition = 0;

    public HeroesListScreen(IDatabase db, IPrinter printer)
    {
        _db = db;
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
        if (_db.GetAllHeroes().Count - 1 > cursorPosition)
        {
            cursorPosition += 1;
        }
        ShowHeroes();
    }

    public override void Enter(IUi ui)
    {
        ui.Screen = new HeroScreen(_db.GetAllHeroes()[cursorPosition], _printer);
    }

    public override void Init()
    {
        ShowHeroes();
    }

    private void ShowHeroes()
    {
        var heroes = _db.GetAllHeroes();
        _printer.Clear();

        _printer.PrintLine("   | Id | Name ");
        foreach (var (index, hero) in heroes.Select((value, i) => (i, value)))
        {
            _printer.PrintLine($" {(index == cursorPosition ? "*" : " ")} | {hero.Id} | {hero.Name.ToUpper()}");
        }
    } 

}