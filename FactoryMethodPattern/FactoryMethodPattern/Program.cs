using System;
using System.Runtime.ConstrainedExecution;

namespace FactoryMethodPattern;

//Factory Method, nesne yaratma sürecini alt sınıflara devrederek, bir sınıfın hangi nesnenin örneklerini yaratması gerektiğine karar
//vermesine yardımcı olan bir tasarım kalıbıdır.Bu sayede, nesne yaratma işlemi sırasında kodun esnekliği artar ve değişikliklere daha açık hale gelir.

//Factory Method Pattern'ın avantajları şunlardır:

//Nesne oluşturma sürecini merkezileştirir ve kod tekrarını azaltır.
//Sınıflar arasındaki bağımlılığı azaltır.
//Yeni tipler eklemek kolaydır ve mevcut kodun değiştirilmesini gerektirmez.


//Eğer Factory Method Pattern kullanmazsanız, her yeni hayvan türü eklendiğinde ya da mevcut hayvan türleri değiştirildiğinde, uygulamanın farklı kısımlarında nesne yaratma sürecine müdahale etmeniz gerekebilir.Bu da kodun daha az esnek ve daha zor yönetilebilir olmasına yol açar.Factory Method Pattern sayesinde, nesne yaratma işlemlerini tek bir yerde toplar ve değişiklikleri kolaylaştırır.

internal class Program
{
    static void Main(string[] args)
    {

        HayvanCreator creator = new AslanCreator();
        Hayvan aslan = creator.HayvanYarat();
        Console.WriteLine("Aslan: " + aslan.SesCikar());

        creator = new KusCreator();
        Hayvan kus = creator.HayvanYarat();
        Console.WriteLine("Kuş: " + kus.SesCikar());
    }

    // Hayvan sınıfı
    public abstract class Hayvan
    {
        public abstract string SesCikar();
    }

    // Hayvan alt sınıfları
    public class Aslan : Hayvan
    {
        public override string SesCikar() => "Roar";
    }

    public class Kus : Hayvan
    {
        public override string SesCikar() => "Chirp";
    }

    // Creator sınıfı
    public abstract class HayvanCreator
    {
        public abstract Hayvan HayvanYarat();
    }

    // Concrete Creator sınıfları
    public class AslanCreator : HayvanCreator
    {
        public override Hayvan HayvanYarat() => new Aslan();
    }

    public class KusCreator : HayvanCreator
    {
        public override Hayvan HayvanYarat() => new Kus();
    }
}