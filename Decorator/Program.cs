namespace Decorator;

internal class Program
{
    //Decorator Pattern, mevcut bir nesnenin işlevselliğini dinamik olarak genişletmek için kullanılan bir yapısal tasarım kalıbıdır.
    //Bu kalıp, alt sınıflar oluşturarak bir nesnenin işlevselliğini genişletmek yerine, işlevselliği nesne örneği oluşturma sırasında eklemek için kullanılır.

    //Bu örnekte, IPizza adlı bir arayüz tanımladık. BasicPizza sınıfı bu arayüzü kullanarak temel bir pizza nesnesini temsil ediyor. Ardından PizzaDecorator soyut sınıfı oluşturduk ve bu sınıf IPizza arayüzünü uyguluyor. Cheese ve Pepperoni sınıfları, PizzaDecorator sınıfından türetilerek pizza nesnelerine ek özellikler sunar.

    //Decorator Pattern olmadan, her pizza çeşidi için ayrı bir sınıf oluşturmanız gerekebilir ve bu da büyük miktarda kod tekrarı ve karmaşıklığa neden olur.
    //Decorator Pattern kullanarak, her bir ek özellik için sadece bir sınıf oluşturarak kodu daha düzenli ve okunaklı hale getirir ve nesne örneği oluşturma
    //sırasında işlevselliği dinamik olarak ekleyebilirsiniz.Bu, daha fazla esneklik sağlar ve kodun yeniden kullanılabilirliğini artırır.

    static void Main(string[] args)
    {
        IPizza pizza = new BasicPizza();
        Console.WriteLine(pizza.GetDescription() + " - $" + pizza.GetCost());

        pizza = new Cheese(pizza);
        Console.WriteLine(pizza.GetDescription() + " - $" + pizza.GetCost());

        pizza = new Pepperoni(pizza);
        Console.WriteLine(pizza.GetDescription() + " - $" + pizza.GetCost());
    }

    public interface IPizza
    {
        string GetDescription();

        double GetCost();
    }

    public class BasicPizza : IPizza
    {
        public string GetDescription()
        {
            return "Basic Pizza";
        }

        public double GetCost()
        {
            return 5.0;
        }
    }

    public abstract class PizzaDecorator : IPizza
    {
        protected IPizza _pizza;

        public PizzaDecorator(IPizza pizza)
        {
            _pizza = pizza;
        }

        public virtual string GetDescription()
        {
            return _pizza.GetDescription();
        }

        public virtual double GetCost()
        {
            return _pizza.GetCost();
        }
    }

    public class Cheese : PizzaDecorator
    {
        public Cheese(IPizza pizza) : base(pizza) { }

        public override string GetDescription()
        {
            return base.GetDescription() + ", Cheese";
        }

        public override double GetCost()
        {
            return base.GetCost() + 1.5;
        }
    }

    public class Pepperoni : PizzaDecorator
    {
        public Pepperoni(IPizza pizza) : base(pizza) { }

        public override string GetDescription()
        {
            return base.GetDescription() + ", Pepperoni";
        }

        public override double GetCost()
        {
            return base.GetCost() + 2.0;
        }
    }
}