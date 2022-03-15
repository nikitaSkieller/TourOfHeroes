using ToH.Data;
using ToH.Log;

namespace ToH.Screens;

public class HeroesListScreen : IScreen
{
    private readonly IDatabase _db;
    private readonly ILog _log;
    private readonly IPrinter _printer;
    private int cursorPosition = 0;

    public HeroesListScreen(IDatabase db, ILog log, IPrinter printer)
    {
        _db = db;
        _log = log;
        _printer = printer;
    }
    public void Print(Action action)
    {
        switch (action)
        {
            case Action.Down when cursorPosition < _db.GetAllHeroes().Count - 1:
                cursorPosition += 1;
                break;
            case Action.Up when cursorPosition > 0:
                cursorPosition -= 1;
                break;
            default:
                _log.Log($"Action() not supported in context");
                break;
        }
        ShowHeroes(cursorPosition);
    }
    
    private void ShowHeroes(int cursorPos)
    {
        var heroes = _db.GetAllHeroes();
        _printer.Clear();

        _printer.PrintLine("   | Id | Name ");
        foreach (var (index, hero) in heroes.Select((value, i) => (i, value)))
        {
            _printer.PrintLine($" {(index == cursorPos ? "*" : " ")} | {hero.Id} | {hero.Name}");
        }
    } 

}