namespace Proxy;

internal class Program
{
    //Proxy Pattern, bir nesnenin başka bir nesneye erişimi için aracı görevi gören yapısal bir tasarım kalıbıdır.
    //Bu kalıp, başka bir nesneye (gerçek nesne) yapılan isteklerin ön işlemlerden geçmesini sağlar.
    //Bu ön işlemler, erişim kontrolü, önbellekleme veya gecikmeli yükleme gibi işlemler olabilir.


    //Bu örnekte, IDocument arayüzü ile belgeleri temsil ediyoruz ve Document sınıfı bu arayüzü uyguluyor.
    //AutoSaveDocument sınıfı, gerçek nesneye erişim için aracı görevi görür ve içerik değiştirildiğinde otomatik olarak belgeyi kaydeder.

    //Proxy Pattern kullanarak, gerçek nesnelerin yaratılması ve kullanılması üzerinde daha fazla kontrol sağlar,otomatik kaydetme gibi ek özellikler ekleyebilirsiniz.
    //Proxy Pattern olmadan, istemci kodu doğrudan gerçek nesnelerle çalışır ve bu ek kontrolleri ve özellikleri uygulamak daha zor ve karışık olabilir.

    static void Main(string[] args)
    {
        IDocument document = new AutoSaveDocument("Initial content");

        // İçerik değiştirildiğinde otomatik olarak kaydedilir
        document.Content = "Updated content";
    }


    // Ortak arayüz
    public interface IDocument
    {
        string Content { get; set; }
        void Save();
    }

    // Gerçek nesne
    public class Document : IDocument
    {
        public string Content { get; set; }

        public Document(string content)
        {
            Content = content;
        }

        public void Save()
        {
            Console.WriteLine($"Saving document: {Content}");
        }
    }

    // Proxy nesne
    public class AutoSaveDocument : IDocument
    {
        private Document _document;

        public AutoSaveDocument(string content)
        {
            _document = new Document(content);
        }

        public string Content
        {
            get { return _document.Content; }
            set
            {
                _document.Content = value;
                Save();
            }
        }

        public void Save()
        {
            _document.Save();
        }
    }
}