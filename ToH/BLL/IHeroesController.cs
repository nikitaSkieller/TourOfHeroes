using ToH.Data;

namespace ToH.BLL;

public interface IHeroesController
{
    IReadOnlyList<Hero> GetAllHeroes();
    IReadOnlyList<Hero> GetDashboardHeroes();
}