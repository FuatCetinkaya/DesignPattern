using Command;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace Strategy;
internal class Alternatif2
{

    //Bu pattern ile ilgili başka bir örnek ise, bir uygulama içindeki dosya sıkıştırma işlemlerinde kullanılabilir.Örneğin, kullanıcıların farklı sıkıştırma algoritmaları tercih edebileceği bir uygulama düşünelim.Bunu Strategy Pattern kullanarak yapabiliriz.

    //Bu senaryoda, CompressionStrategy adlı bir soyut sınıfımız olacak. Bu sınıfın içinde Compress adlı bir metot yer alacak.Ardından, bu sınıftan türeyen ConcreteStrategy sınıfları, farklı sıkıştırma algoritmalarını uygulayacaklar.



    //Bu örnekte, CompressionStrategy adlı soyut sınıfımız, Compress adlı bir metot içeriyor.Bu metot ConcreteStrategy sınıfları tarafından uygulanacak ve farklı sıkıştırma algoritmalarını temsil edecek şekilde yazılacak.

    //ConcreteStrategy sınıfları, ZipCompressionStrategy, RarCompressionStrategy ve TarGzCompressionStrategy olarak tanımlanmıştır.Her biri Compress metotunu farklı şekilde uygulamaktadır.

    //CompressionContext sınıfı ise, bir CompressionStrategy nesnesini içerir. CompressFile metodu, _strategy nesnesi üzerinden çağrılır ve stratejinin doğru şekilde uygulanmasını sağlar.

    //Kodda gördüğümüz gibi, bu yapı sayesinde farklı sıkıştırma algoritmaları kolayca uygulanabilir ve CompressionContext sınıfı, farklı algoritmalar arasında geçiş yapabilir.

    // Soyut sınıf
    abstract class CompressionStrategy
    {
        public abstract void Compress(string fileName);
    }

    // Concrete Strategy sınıfları
    class ZipCompressionStrategy : CompressionStrategy
    {
        public override void Compress(string fileName)
        {
            Console.WriteLine($"'{fileName}' isimli dosya Zip algoritmasıyla sıkıştırıldı.");
        }
    }

    class RarCompressionStrategy : CompressionStrategy
    {
        public override void Compress(string fileName)
        {
            Console.WriteLine($"'{fileName}' isimli dosya Rar algoritmasıyla sıkıştırıldı.");
        }
    }

    class TarGzCompressionStrategy : CompressionStrategy
    {
        public override void Compress(string fileName)
        {
            Console.WriteLine($"'{fileName}' isimli dosya Tar+Gz algoritmasıyla sıkıştırıldı.");
        }
    }

    // Context sınıfı
    class CompressionContext
    {
        private CompressionStrategy _strategy;

        public CompressionContext(CompressionStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void SetStrategy(CompressionStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void CompressFile(string fileName)
        {
            _strategy.Compress(fileName);
        }
    }

    class Program2
    {
        static void Main2(string[] args)
        {
            var context = new CompressionContext(new ZipCompressionStrategy());
            context.CompressFile("example.txt");

            context.SetStrategy(new RarCompressionStrategy());
            context.CompressFile("example.txt");

            context.SetStrategy(new TarGzCompressionStrategy());
            context.CompressFile("example.txt");
        }
    }
}
