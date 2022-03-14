using ToH.Log;

namespace ToH.Screens;

public class Ui : IObserver
{
    private readonly Controller _controller;
    private readonly IScreen _screen;

    public Ui(Controller controller, IScreen screen)
    {
        _controller = controller;
        _screen = screen;
        _controller.Add(this);
    }
    
    public void Update()
    {
        _screen.Print(_controller.Action);
           
    }

    public void Print()
    {
        _screen.Print(Action.None);
    }

    // TODO Move
    public void ShowHero(Hero hero) {
    }
    
    // TODO Move
    public void ShowDashboard(List<Hero> heroes) {
    }
}