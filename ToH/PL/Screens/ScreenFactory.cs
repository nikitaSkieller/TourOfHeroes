using System.Dynamic;
using System.Reflection.Metadata;
using ToH.BLL;
using ToH.Data;
using ToH.Log;

namespace ToH.PL.Screens;

public class ScreenFactory : IScreenFactory
{
    private readonly IHeroesController _heroesController;
    private readonly IPrinter _printer;
    private readonly ILog _log;
    private HeroesListScreen? _heroesListScreen;
    private HeroScreen? _heroScreen;
    private ISessionController _sessionController;

    public ScreenFactory(IHeroesController heroesController, ISessionController sessionController, IPrinter printer, ILog log)
    {
        _heroesController = heroesController;
        _printer = printer;
        _log = log;
        _sessionController = sessionController;
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
        else if (type == typeof(DashboardScreen))
        {
            return new DashboardScreen(_heroesController, _printer);
        }
        else if (type == typeof(LoginScreen))
        {
            return new LoginScreen(_sessionController, _printer);
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
    
    public Screen HeroesListScreen()
    {
        if (_heroesListScreen == null)
        {
            _heroesListScreen = new HeroesListScreen(_heroesController, _printer);
        }
        return _heroesListScreen;
    }
}