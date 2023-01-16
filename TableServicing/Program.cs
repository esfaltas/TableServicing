using TableServicing.Repostitory;
using TableServicing.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var MainMealRepository = new MealsRepository();
        var AppetizersRepository = new AppetizersRepository();
        var drinkRepository = new DrinksRepository();
        var VeggiesRepository = new TablesRepository();
        var menu = new Menu();
        menu.InitiateMenu();
    }
}