using System.Runtime.ConstrainedExecution;
using System;

namespace Decorator;

internal class Alternatif
{
    //Tabii, bir kahve dükkanındaki içecek siparişlerini modelleyen alternatif bir Decorator Pattern örneği 

    //Bu örnekte, IBeverage adlı bir arayüz tanımladık. Espresso sınıfı bu arayüzü kullanarak temel bir içecek nesnesini temsil ediyor.
    //Ardından BeverageAddonDecorator soyut sınıfı oluşturduk ve bu sınıf IBeverage arayüzünü uyguluyor.
    //Milk ve Mocha sınıfları, BeverageAddonDecorator sınıfından türetilerek içecek nesnelerine ek özellikler sunar.

    //Decorator Pattern kullanarak, her bir ek özellik için sadece bir sınıf oluşturarak kodu daha düzenli ve okunaklı hale getirir ve nesne örneği
    //oluşturma sırasında işlevselliği dinamik olarak ekleyebilirsiniz.Bu, daha fazla esneklik sağlar ve kodun yeniden kullanılabilirliğini artırır.
    public interface IBeverage
    {
        string GetDescription();
        double GetCost();
    }

    public class Espresso : IBeverage
    {
        public string GetDescription()
        {
            return "Espresso";
        }

        public double GetCost()
        {
            return 1.99;
        }
    }

    public abstract class BeverageAddonDecorator : IBeverage
    {
        protected IBeverage _beverage;

        public BeverageAddonDecorator(IBeverage beverage)
        {
            _beverage = beverage;
        }

        public virtual string GetDescription()
        {
            return _beverage.GetDescription();
        }

        public virtual double GetCost()
        {
            return _beverage.GetCost();
        }
    }

    public class Milk : BeverageAddonDecorator
    {
        public Milk(IBeverage beverage) : base(beverage) { }

        public override string GetDescription()
        {
            return base.GetDescription() + ", Milk";
        }

        public override double GetCost()
        {
            return base.GetCost() + 0.3;
        }
    }

    public class Mocha : BeverageAddonDecorator
    {
        public Mocha(IBeverage beverage) : base(beverage) { }

        public override string GetDescription()
        {
            return base.GetDescription() + ", Mocha";
        }

        public override double GetCost()
        {
            return base.GetCost() + 0.4;
        }
    }

    class Program1
    {
        static void Main1(string[] args)
        {
            IBeverage beverage = new Espresso();
            Console.WriteLine(beverage.GetDescription() + " - $" + beverage.GetCost());

            beverage = new Milk(beverage);
            Console.WriteLine(beverage.GetDescription() + " - $" + beverage.GetCost());

            beverage = new Mocha(beverage);
            Console.WriteLine(beverage.GetDescription() + " - $" + beverage.GetCost());
        }
    }

}
