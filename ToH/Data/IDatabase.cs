namespace ToH.Data;

public interface IDatabase
{
    public IReadOnlyList<Hero> GetAllHeroes();
} 