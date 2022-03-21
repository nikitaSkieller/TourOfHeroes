namespace ToH.PL.Screens;

public class LoginScreen : Screen
{
    private readonly IPrinter _printer;

    public LoginScreen(IPrinter printer)
    {
        _printer = printer;
    }
    
    public override void Init()
    {
        _printer.Clear();
        _printer.PrintLine("Write username:");
    }

    public override void Enter(IUi ui)
    {
        base.Enter(ui);
    }
}