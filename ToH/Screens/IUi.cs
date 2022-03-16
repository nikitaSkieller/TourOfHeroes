namespace ToH.Screens;

public interface IUi
{
    Screen Screen { set; }
    IScreenFactory ScreenFactory { get; }
}