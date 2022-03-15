using ToH.Data;
using ToH.Log;

namespace ToH.Screens;

public class Ui : IObserver
{
    private readonly Controller _controller;
    public Screen Screen { get; set; }

    public Ui(Controller controller, Screen screen)
    {
        _controller = controller;
        Screen = screen;
        _controller.Add(this);
    }

    public void Update()
    {
        switch (_controller.Action)
        {
            case Action.None:
                Screen.None(this);
                break;
            case Action.Down:
                Screen.Down(this);
                break;
            case Action.Up:
                Screen.Up(this);
                break;

            default:
                // TODO log
                break;
        }

    }

    public void Print()
    {
        Screen.None(this);
    }
}