using System.Dynamic;
using System.Reflection.Metadata;
using ToH.Data;
using ToH.Log;

namespace ToH.PL.Screens;

public class ScreenFactory : IScreenFactory
{
    private readonly IDatabase _database;
    private readonly IPrinter _printer;
    private readonly ILog _log;
    private HeroesListScreen? _heroesListScreen;
    private HeroScreen? _heroScreen;

    public ScreenFactory(IDatabase database, IPrinter printer, ILog log)
    {
        _database = database;
        _printer = printer;
        _log = log;
    }

    public Screen? CreateScreen(Type type, Hero? hero = null)
    {
        Console.WriteLine(type);
        if (type == typeof(HeroesListScreen))
        {
            return HeroesListScreen();
        }
        else if (type == typeof(HeroScreen) && hero != null)
        {
            return HeroScreen(hero);
        }
        _log.Log($"ScreenFactory.createScreen: Cant create type {type} with parameters {hero}");
        return null; // TODO replace with something usefull
    }

    private Screen HeroScreen(Hero hero)
    {
        if (_heroScreen == null)
        {
            _heroScreen = new HeroScreen(hero, _printer);
        }
        _heroScreen!.Hero = hero;
        return _heroScreen;
    }

    private Screen HeroesListScreen()
    {
        if (_heroesListScreen == null)
        {
            _heroesListScreen = new HeroesListScreen(_database, _printer);
        }
        return _heroesListScreen;
    }
}