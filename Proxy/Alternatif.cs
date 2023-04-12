

namespace Proxy
{
    //Bu örnekte, IImage arayüzü ile resimleri temsil ediyoruz ve RealImage sınıfı bu arayüzü uyguluyor.
    //ProxyImage sınıfı, gerçek nesneye erişim için aracı görevi görür ve gecikmeli yükleme işlemini gerçekleştirir.

    //Proxy Pattern kullanarak, gerçek nesnelerin yaratılması ve kullanılması üzerinde daha fazla kontrol sağlar,
    //önbellekleme veya gecikmeli yükleme gibi ek özellikler ekleyebilirsiniz.Proxy Pattern olmadan,
    //istemci kodu doğrudan gerçek nesnelerle çalışır ve bu ek kontrolleri ve özellikleri uygulamak daha zor ve karışık olabilir.

    internal class Alternatif
    {
        // Ortak arayüz
        public interface IImage
        {
            void Display();
        }

        // Gerçek nesne
        public class RealImage : IImage
        {
            private string _fileName;

            public RealImage(string fileName)
            {
                _fileName = fileName;
                LoadImageFromDisk();
            }

            private void LoadImageFromDisk()
            {
                Console.WriteLine($"Loading {_fileName}");
            }

            public void Display()
            {
                Console.WriteLine($"Displaying {_fileName}");
            }
        }

        // Proxy nesne
        public class ProxyImage : IImage
        {
            private RealImage _realImage;
            private string _fileName;

            public ProxyImage(string fileName)
            {
                _fileName = fileName;
            }

            public void Display()
            {
                if (_realImage == null)
                {
                    _realImage = new RealImage(_fileName);
                }
                _realImage.Display();
            }
        }

        // İstemci kodu
        class Program1
        {
            static void Main1(string[] args)
            {
                IImage image = new ProxyImage("testImage.jpg");

                // İlk çağrıda gerçek nesne yüklenir ve görüntülenir
                image.Display();
                Console.WriteLine("");

                // İkinci çağrıda gerçek nesne önbellekten kullanılır ve tekrar yüklenmez
                image.Display();
            }
        }

    }
}
