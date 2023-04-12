namespace Adapter;

internal class Program
{
    //Adapter Pattern, iki uyumsuz arayüzü uyumlu hale getiren ve birbirleriyle iletişim kurmalarını sağlayan bir structural tasarım kalıbıdır.
    //Bu pattern, mevcut bir sınıfın arayüzünü, başka bir sınıfın arayüzüne uygun hale getirerek, sınıfların birbirleriyle çalışabilmesini sağlar.
    //Adapter Pattern, genellikle mevcut kodları değiştirmeden yeni sistemlere entegre etmek için kullanılır.


    //Bu örnekte, farklı voltaj değerlerine sahip olan EuropeanVoltage ve AmericanVoltage sınıfları bulunmaktadır. İki sınıf da voltaj değeri sağlamakla
    //ilgili olsa da, farklı metod adlarına sahiptirler (GetVoltage ve ProvideVoltage).
    //Bu durumda, iki sınıfı bir arada kullanmak istediğimizde uyumsuzluk yaşarız.

    //Adapter Pattern'i kullanarak, AmericanToEuropeanVoltageAdapter sınıfını oluşturduk.
    //Bu sınıf, IVoltage arayüzünü uygular ve AmericanVoltage nesnesini kabul eder.
    //GetVoltage metodunu uygulayarak, AmericanVoltage nesnesinin voltaj değerini döndürür ve uygun hale getirir.

    //Adapter Pattern kullanarak, mevcut kodları değiştirmeden, uyumsuz arayüzlerin birbiriyle iletişim kurmasını sağlayabiliriz.
    //Bu sayede, eski ve yeni kodları bir arada kullanarak, kod tekrarını önleyebilir ve uygulamanın esnekliğini artırabiliriz.

    //Adapter Pattern olmadan, iki uyumsuz sınıfı bir arada kullanmak için her iki sınıfı da değiştirmeniz veya ekstra kodlar yazmanız gerekebilir.
    //Bu, kod tekrarına ve karmaşıklaşmasına neden olabilir. Adapter Pattern, uyumsuz sınıfları bir arada kullanarak, kodun daha temiz ve esnek olmasını sağlar.


    static void Main(string[] args)
    {
        IVoltage europeanVoltage = new EuropeanVoltage();
        Console.WriteLine($"European Voltage: {europeanVoltage.GetVoltage()}V");

        AmericanVoltage americanVoltage = new AmericanVoltage();
        IVoltage adaptedAmericanVoltage = new AmericanToEuropeanVoltageAdapter(americanVoltage);
        Console.WriteLine($"Adapted American Voltage: {adaptedAmericanVoltage.GetVoltage()}V");
    }

    public interface IVoltage
    {
        int GetVoltage();
    }

    public class EuropeanVoltage : IVoltage
    {
        public int GetVoltage()
        {
            return 230;
        }
    }

    public class AmericanVoltage
    {
        public int ProvideVoltage()
        {
            return 110;
        }
    }

    public class AmericanToEuropeanVoltageAdapter : IVoltage
    {
        private readonly AmericanVoltage _americanVoltage;

        public AmericanToEuropeanVoltageAdapter(AmericanVoltage americanVoltage)
        {
            _americanVoltage = americanVoltage;
        }

        public int GetVoltage()
        {
            return _americanVoltage.ProvideVoltage() * 2;
        }
    }
}