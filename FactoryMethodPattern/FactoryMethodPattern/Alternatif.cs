using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern;

internal class Alternatif
{
    static void Main1(string[] args)
    {
        HayvanCreator creator = new ConcreteHayvanCreator();

        string hayvanTipi = GetHayvanTipiFromAPI(); // API'den hayvan tipini alır.
        Hayvan hayvan = creator.HayvanYarat(hayvanTipi);

        Console.WriteLine("Hayvan: " + hayvan.SesCikar());
    }

    private static string GetHayvanTipiFromAPI()
    {
        return "aslan";
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
        public abstract Hayvan HayvanYarat(string hayvanTipi);
    }

    // Concrete Creator sınıfları
    public class ConcreteHayvanCreator : HayvanCreator
    {
        public override Hayvan HayvanYarat(string hayvanTipi)
        {
            switch (hayvanTipi.ToLower())
            {
                case "aslan":
                    return new Aslan();
                case "kus":
                    return new Kus();
                default:
                    throw new ArgumentException("Geçersiz hayvan tipi.");
            }
        }
    }
}
