using ToH.Data;

namespace ToH.BLL;

public class HeroesController : IHeroesController
{
    private readonly IDatabase _database;

    public HeroesController(IDatabase database)
    {
        _database = database;
    }

    public IReadOnlyList<Hero> GetAllHeroes()
    {
        return _database.GetAllHeroes();
    }

    public IReadOnlyList<Hero> GetDashboardHeroes()
    {
        return _database.GetAllHeroes().Take(2).ToList();
    }
}