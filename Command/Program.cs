namespace Command;

internal class Program
{
    // Command Pattern, istemcilerin ve işlem gerçekleştiren nesnelerin doğrudan bağlantısını kaldırmak için kullanılır.
    // İşlemler, Command nesneleri olarak temsil edilir ve istemci bu nesneleri çağırarak işlemleri gerçekleştirir.
    // Bu, işlemlerin kolayca değiştirilmesine, sıralanmasına ve geri alınmasına olanak tanır.

    //Örnek olarak, bir televizyon kumandası düşünelim. Televizyonu açmak, kapatmak ve sesini değiştirmek için farklı komutlar kullanacağız.


    // Bu örnekte, ICommand arabirimi ve onu uygulayan TurnOnCommand, TurnOffCommand ve ChangeVolumeCommand sınıfları kullanılmıştır.
    // RemoteControl sınıfı, bir komut nesnesini alarak istemcinin doğrudan TV ile etkileşime geçmesine gerek kalmadan işlemleri gerçekleştirmesine olanak tanır.

    //Command Pattern'in avantajları şunlardır:

    //İstemci ve işlemi gerçekleştiren nesne arasındaki bağımlılığı azaltır.
    //Komutlar, sıralama ve geri alma gibi özelliklerle genişletilebilir.
    //Yeni komutlar eklemek kolaydır ve mevcut kodu değiştirmeden yapılabilir.
    static void Main(string[] args)
    {
        Tv tv = new Tv();
        ICommand turnOnCommand = new TurnOnCommand(tv);
        ICommand turnOffCommand = new TurnOffCommand(tv);
        ICommand changeVolumeCommand = new ChangeVolumeCommand(tv, 10);

        RemoteControl remote = new RemoteControl();

        remote.PressButton(turnOnCommand);
        remote.PressButton(changeVolumeCommand);
        remote.PressButton(turnOffCommand);
    }
    public interface ICommand
    {
        void Execute();
    }

    public class Tv
    {
        public void TurnOn()
        {
            Console.WriteLine("TV is on.");
        }

        public void TurnOff()
        {
            Console.WriteLine("TV is off.");
        }

        public void ChangeVolume(int volume)
        {
            Console.WriteLine($"TV volume changed to {volume}");
        }
    }

    public class TurnOnCommand : ICommand
    {
        private Tv _tv;

        public TurnOnCommand(Tv tv)
        {
            _tv = tv;
        }

        public void Execute()
        {
            _tv.TurnOn();
        }
    }

    public class TurnOffCommand : ICommand
    {
        private Tv _tv;

        public TurnOffCommand(Tv tv)
        {
            _tv = tv;
        }

        public void Execute()
        {
            _tv.TurnOff();
        }
    }

    public class ChangeVolumeCommand : ICommand
    {
        private Tv _tv;
        private int _volume;

        public ChangeVolumeCommand(Tv tv, int volume)
        {
            _tv = tv;
            _volume = volume;
        }

        public void Execute()
        {
            _tv.ChangeVolume(_volume);
        }
    }

    public class RemoteControl
    {
        public void PressButton(ICommand command)
        {
            command.Execute();
        }
    }
}