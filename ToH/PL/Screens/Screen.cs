namespace ToH.PL.Screens;

public abstract class Screen
{
    public virtual void None(IUi ui) { }
    public virtual void Up(IUi ui) {}
    public virtual void Down(IUi ui) {}
    public virtual void Enter(IUi ui) {}
    public virtual void Escape(IUi ui) {}
    public virtual void Text(IUi ui, string controllerValue) { }

    public abstract void Init();
}