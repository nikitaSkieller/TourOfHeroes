using ToH.Data;

namespace ToH.Screens;

public interface IScreenFactory
{
    Screen? CreateScreen(Type type, Hero? hero = null);
}