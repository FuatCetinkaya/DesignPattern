namespace Builder;


    //bir fast-food restoranındaki farklı menülerin siparişlerini oluşturan bir uygulama düşünelim

    public class Meal
    {
        public string MainDish { get; set; }
        public string SideDish { get; set; }
        public string Drink { get; set; }
        public string Dessert { get; set; }
    }

    public interface IMealBuilder
    {
        void SetMainDish(string mainDish);
        void SetSideDish(string sideDish);
        void SetDrink(string drink);
        void SetDessert(string dessert);
        Meal GetMeal();
    }

    public class MealBuilder : IMealBuilder
    {
        private Meal _meal = new Meal();

        public void SetMainDish(string mainDish) => _meal.MainDish = mainDish;
        public void SetSideDish(string sideDish) => _meal.SideDish = sideDish;
        public void SetDrink(string drink) => _meal.Drink = drink;
        public void SetDessert(string dessert) => _meal.Dessert = dessert;

        public Meal GetMeal()
        {
            Meal result = _meal;
            _meal = new Meal();
            return result;
        }
    }

    public class MealDirector
    {
        public Meal BuildAdultMeal(IMealBuilder builder)
        {
            builder.SetMainDish("Burger");
            builder.SetSideDish("Fries");
            builder.SetDrink("Coke");
            builder.SetDessert("Ice Cream");
            return builder.GetMeal();
        }

        public Meal BuildKidsMeal(IMealBuilder builder)
        {
            builder.SetMainDish("Chicken Nuggets");
            builder.SetSideDish("Fries");
            builder.SetDrink("Apple Juice");
            builder.SetDessert("Cookie");
            return builder.GetMeal();
        }
    }

    class Program1
    {
        static void Main1(string[] args)
        {
            //Bu örnekte, fast-food restoranındaki farklı menülerin siparişlerini oluşturan bir uygulama için Builder Pattern kullandık. Meal nesnelerini adım adım oluşturan MealBuilder ve bu süreci yöneten MealDirector sınıflarını kullanarak, farklı menülerin oluşturulmasını daha düzenli ve modüler hale getirdik.
            IMealBuilder builder = new MealBuilder();
            MealDirector director = new MealDirector();

            Meal adultMeal = director.BuildAdultMeal(builder);
            Meal kidsMeal = director.BuildKidsMeal(builder);

            Console.WriteLine("Adult Meal:");
            Console.WriteLine($"Main Dish: {adultMeal.MainDish}, Side Dish: {adultMeal.SideDish}, Drink: {adultMeal.Drink}, Dessert: {adultMeal.Dessert}");

            Console.WriteLine("Kids Meal:");
            Console.WriteLine($"Main Dish: {kidsMeal.MainDish}, Side Dish: {kidsMeal.SideDish}, Drink: {kidsMeal.Drink}, Dessert: {kidsMeal.Dessert}");
        }
    }


