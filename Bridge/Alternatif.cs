namespace Bridge;


    //Bu örnekte, IMotor adında bir arayüz tanımladık. Bu arayüzün iki farklı uygulaması olan ElectricMotor ve DieselMotor sınıfları bulunmaktadır.
    //Vehicle adında soyut bir sınıf tanımlayarak, IMotor arayüzünden bir nesne kullanarak araçları sürdük.
    //Car ve Truck adında iki somut sınıf oluşturarak, Vehicle sınıfını uyguladık.

    //Bridge Pattern kullanarak, Vehicle soyutlamasının ve IMotor uygulamalarının bağımsız olarak geliştirilmesine ve değiştirilmesine olanak sağladık.
    //Bu sayede, yeni araç türleri veya motor türleri eklendiğinde veya mevcut olanlar değiştirildiğinde, diğer katmanın kodunu etkilemeden değişiklik yapabiliriz.


    //Bridge Pattern olmadan, her araç ve motor türü için farklı sınıflar oluşturmanız ve bu sınıfların tüm kombinasyonlarını yönetmeniz gerekebilir.
    //Bu, kod karmaşasına ve zor yönetilen bir yapıya yol açar.Bridge Pattern sayesinde, kodun daha düzenli ve esnek olmasını sağlayabiliriz.


    // Motor Interface (Implementation)
    public interface IMotor
    {
        void Start();
    }

    public class ElectricMotor : IMotor
    {
        public void Start()
        {
            Console.WriteLine("Electric motor is starting.");
        }
    }

    public class DieselMotor : IMotor
    {
        public void Start()
        {
            Console.WriteLine("Diesel motor is starting.");
        }
    }

    // Araç Abstract Class (Abstraction)
    public abstract class Vehicle
    {
        protected readonly IMotor _motor;

        protected Vehicle(IMotor motor)
        {
            _motor = motor;
        }

        public abstract void Drive();
    }

    public class Car : Vehicle
    {
        public Car(IMotor motor) : base(motor) { }

        public override void Drive()
        {
            Console.Write("Car ");
            _motor.Start();
        }
    }

    public class Truck : Vehicle
    {
        public Truck(IMotor motor) : base(motor) { }

        public override void Drive()
        {
            Console.Write("Truck ");
            _motor.Start();
        }
    }

    class Program1
    {
        static void Main1(string[] args)
        {
            IMotor electricMotor = new ElectricMotor();
            IMotor dieselMotor = new DieselMotor();

            Vehicle carWithElectricMotor = new Car(electricMotor);
            carWithElectricMotor.Drive();

            Vehicle truckWithDieselMotor = new Truck(dieselMotor);
            truckWithDieselMotor.Drive();
        }
    }

