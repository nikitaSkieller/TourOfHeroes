using ToH.Data;

namespace ToH.PL.Screens;

public interface IScreenFactory
{
    Screen? CreateScreen(Type type, Hero? hero = null);
}