using System;
using System.Runtime.InteropServices;

namespace AbstractFactory;

internal class Program
{
    //    Abstract Factory, aileler halinde ilişkili nesneler yaratmak için kullanılan bir tasarım kalıbıdır.Bu kalıp, nesnelerin oluşturulma sürecini
    //    soyutlamaya ve somut sınıfların kullanıcı kodundan bağımsız hale gelmesine yardımcı olur.

    //Abstract Factory Pattern'ın avantajları şunlardır:

    //Aileler halinde ilişkili nesneler yaratma sürecini soyutlar.
    //Sınıflar arasındaki bağımlılığı azaltır ve kodun modülerliğini artırır.
    //Yeni nesne ailelerini kolayca eklemeye olanak tanır.




    //Abstract Factory Pattern, birbirleriyle ilişkili veya bağımlı nesne ailelerini yaratmak için bir arayüz sağlayan bir creational tasarım kalıbıdır.Bu kalıp, somut sınıfların yerine soyut sınıflar veya arayüzler kullanarak nesne oluşturma süreçlerini soyutlar ve sınıflar arasındaki bağımlılığı azaltır.Bu sayede, kodun modülerliği ve esnekliği artar ve yeni nesne ailelerini eklemek daha kolay hale gelir. Abstract Factory, nesne oluşturma mantığını merkezi bir yerde toplarken, özellikle ürün aileleri ve bunların birbirleriyle olan ilişkileri karmaşıksa, kodun daha düzenli ve yönetilebilir olmasını sağlar.



//    Eğer Abstract Factory Pattern kullanmazsanız, farklı platformlara özgü bileşenleri doğrudan yaratma ve kullanma sürecinde, işletim sistemine özgü kodlarla uğraşmanız ve uygulamanın farklı kısımlarında platforma özgü nesne yaratma sürecine müdahale etmeniz gerekebilir.Bu da kodun daha az esnek ve daha zor yönetilebilir olmasına yol açar.
//Abstract Factory Pattern sayesinde, nesne yaratma işlemlerini tek bir yerde toplar ve değişiklikleri kolaylaştırır.Bu örnekte, işletim sistemine göre doğru UI bileşenlerini yaratmak için IUIFactory arayüzünü kullanıyoruz.Bu sayede, yeni bir platform eklendiğinde veya mevcut platformlar değiştirildiğinde, yalnızca ilgili IUIFactory alt sınıflarını güncellemeniz yeterlidir ve geri kalan kod üzerinde herhangi bir etkisi olmaz.

    //Abstract Factory Pattern, aileler halinde ilişkili nesnelerin yaratılmasını ve kullanılmasını soyutlayarak kodun esnekliğini ve modülerliğini artırır.Bu, uygulamanın farklı kısımlarında yapılan değişikliklerin birbirlerine olan etkisini en aza indirerek, kodun daha düzenli ve yönetilebilir hale gelmesini sağlar. Bu nedenle, ilişkili nesne ailelerini yaratmak ve kullanmak gereken durumlarda Abstract Factory Pattern tercih edilir.
    static void Main(string[] args)
    {
        IUIFactory uiFactory;

        // İşletim sistemine göre uygun UI factory'yi seçin
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            uiFactory = new WindowsUIFactory();
        }
        else
        {
            uiFactory = new MacUIFactory();
        }

        IButton button = uiFactory.CreateButton();
        ICheckbox checkbox = uiFactory.CreateCheckbox();

        button.Render();
        checkbox.Render();
    }

    // UI bileşenleri için soyut sınıflar
    public interface IButton
    {
        void Render();
    }

    public interface ICheckbox
    {
        void Render();
    }

    // Windows UI bileşenleri
    public class WindowsButton : IButton
    {
        public void Render() => Console.WriteLine("Windows Button");
    }

    public class WindowsCheckbox : ICheckbox
    {
        public void Render() => Console.WriteLine("Windows Checkbox");
    }

    // Mac UI bileşenleri
    public class MacButton : IButton
    {
        public void Render() => Console.WriteLine("Mac Button");
    }

    public class MacCheckbox : ICheckbox
    {
        public void Render() => Console.WriteLine("Mac Checkbox");
    }

    // Abstract Factory sınıfı
    public interface IUIFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }

    // Concrete Factory sınıfları
    public class WindowsUIFactory : IUIFactory
    {
        public IButton CreateButton() => new WindowsButton();
        public ICheckbox CreateCheckbox() => new WindowsCheckbox();
    }

    public class MacUIFactory : IUIFactory
    {
        public IButton CreateButton() => new MacButton();
        public ICheckbox CreateCheckbox() => new MacCheckbox();
    }
}