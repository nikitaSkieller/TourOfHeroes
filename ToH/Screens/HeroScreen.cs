using ToH.Data;

namespace ToH.Screens;

public class HeroScreen : Screen
{
    private readonly Hero _hero;

    public HeroScreen(Hero hero)
    {
        _hero = hero;
    }

    public override void Init()
    {
        throw new NotImplementedException();
    }
}