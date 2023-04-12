namespace Facade;

internal class Program
{
    //Facade Pattern, karmaşık bir alt sistemle çalışırken basit bir arayüz sunmak için kullanılan bir yapısal tasarım kalıbıdır.
    //Bu kalıp, alt sistemdeki sınıfların ve işlemlerin karmaşıklığını gizleyerek, istemci uygulamalar için daha kolay bir kullanıcı deneyimi sağlar.


    //Bu örnekte, Subsystem1 ve Subsystem2 adında iki karmaşık alt sistem sınıfı tanımladık. İstemci uygulamanın bu alt sistemlerle doğrudan çalışması yerine,
    //Facade adında bir sınıf tanımlayarak karmaşıklığı gizliyoruz.

    //acade Pattern kullanarak, istemci uygulama alt sistemlerle daha basit ve daha düzenli bir şekilde çalışabilir.Bu, istemci uygulamanın karmaşık
    //alt sistemlere maruz kalmadan, daha düşük bağımlılık ve daha kolay bakım sağlar.
    //Facade Pattern olmadan, istemci kodu doğrudan alt sistemlerle çalışmak zorunda kalır ve bu da daha fazla bağımlılık ve daha zorlu bakım süreçleri doğurabilir.


    static void Main(string[] args)
    {
        Subsystem1 subsystem1 = new Subsystem1();
        Subsystem2 subsystem2 = new Subsystem2();
        Facade facade = new Facade(subsystem1, subsystem2);

        // Facade aracılığıyla karmaşık alt sistemle çalışma
        string result = facade.PerformOperation();
        Console.WriteLine(result);
    }

    // Karmaşık alt sistem sınıfları
    public class Subsystem1
    {
        public string Operation1()
        {
            return "Subsystem1: Operation1\n";
        }

        public string Operation2()
        {
            return "Subsystem1: Operation2\n";
        }
    }

    public class Subsystem2
    {
        public string Operation1()
        {
            return "Subsystem2: Operation1\n";
        }

        public string Operation2()
        {
            return "Subsystem2: Operation2\n";
        }
    }

    // Facade sınıfı
    public class Facade
    {
        private Subsystem1 _subsystem1;
        private Subsystem2 _subsystem2;

        public Facade(Subsystem1 subsystem1, Subsystem2 subsystem2)
        {
            _subsystem1 = subsystem1;
            _subsystem2 = subsystem2;
        }

        public string PerformOperation()
        {
            return "Facade: Performing operation\n" +
                   _subsystem1.Operation1() +
                   _subsystem2.Operation1();
        }
    }
}