namespace ToH.Screens;

public abstract class Screen
{
    public virtual void None(IUi ui) { }
    
    public virtual void Up(IUi ui) {}
    
    public virtual void Down(IUi ui) {}
    public virtual void Enter(IUi ui) {}

    public abstract void Init();
}