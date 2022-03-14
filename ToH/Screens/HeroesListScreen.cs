using ToH.Log;

namespace ToH.Screens;

public class HeroesListScreen : IScreen
{
    private readonly HeroesContainer _db;
    private readonly ILog _log;
    private int cursorPosition = 0;

    public HeroesListScreen(HeroesContainer db, ILog log)
    {
        _db = db;
        _log = log;
    }
    public void Print(Action action)
    {
        switch (action)
        {
            case Action.Down when cursorPosition < _db.Init().Count - 1:
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
        var heroes = _db.Init();
        Console.Clear();

        Console.WriteLine("   | Id | Name ");
        foreach (var (index, hero) in heroes.Select((value, i) => (i, value)))
        {
            Console.WriteLine($" {(index == cursorPos ? "*" : " ")} | {hero.Id} | {hero.Name}");
        }
    } 

}