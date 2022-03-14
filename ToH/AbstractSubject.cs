namespace ToH;

public abstract class AbstractSubject
{
    private List<IObserver> Observers { get; set; } = new List<IObserver>();

    public void Add(IObserver observer) => Observers.Add(observer);
    public void Remove(IObserver observer) => Observers.Remove(observer);

    protected void Notify()
    {
        foreach (var observer in Observers)
        {
            observer.Update();
        }
    }
    
}