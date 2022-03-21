using ToH.BLL;

namespace ToH.PL.Screens;

public class LoginScreen : Screen
{
    private readonly ISessionController _controller;
    private readonly IPrinter _printer;

    public LoginScreen(ISessionController controller, IPrinter printer)
    {
        _controller = controller;
        _printer = printer;
    }
    
    public override void Init()
    {
        _printer.Clear();
        _printer.PrintLine("Write username:");
    }

    public override void Text(IUi ui, string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            Init();
        }
        else
        {
            _controller.Username = username;
            ui.Screen = ui.ScreenFactory.CreateScreen(typeof(DashboardScreen));
        }
    }
}