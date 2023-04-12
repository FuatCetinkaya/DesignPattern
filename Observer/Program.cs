namespace Observer;

internal class Program
{
    //Observer Pattern, bir nesnenin durumundaki değişiklikleri izleyen ve bu değişikliklere tepki veren bağlı nesneler arasında bir bağımlılık oluşturan bir tasarım desenidir.
    //Bu desen yaygın olarak olay yönlendirmeli sistemlerde kullanılır ve genellikle bir-çok bağlantı yapısıyla modellenir.

    //Örnek olarak, bir blogdaki yeni yayınları takip eden aboneleri ele alalım.

    //İlk olarak, bir Observer arayüzü ve bir Subject sınıfı oluşturacağız:



    //    Observer Pattern'in avantajları şunlardır:

    //Nesneler arasında düşük bağımlılık sağlar, çünkü aboneler ve yayıncılar arasında sadece arayüz bağımlılığı vardır.
    //Olaylara dinamik olarak tepki verebilir ve uygulamanın geri kalanına etki etmeden yeni gözlemciler ekleyebilir veya mevcut gözlemcileri çıkarabilirsiniz.
    //Yayıncı, abonelerin sayısı ve türü hakkında bilgi sahibi olmadan haberleşebilir.

    static void Main(string[] args)
    {
        Blog myBlog = new Blog();

        Subscriber alice = new Subscriber("Alice");
        Subscriber bob = new Subscriber("Bob");

        myBlog.Subscribe(alice);
        myBlog.Subscribe(bob);

        myBlog.PublishPost("Observer Pattern in C#");

        myBlog.Unsubscribe(bob);

        myBlog.PublishPost("Another interesting post");

    }

    public interface IObserver
    {
        void Update(string blogPostTitle);
    }

    public class Blog
    {
        private List<IObserver> _observers = new List<IObserver>();

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(string blogPostTitle)
        {
            foreach (var observer in _observers)
            {
                observer.Update(blogPostTitle);
            }
        }

        public void PublishPost(string blogPostTitle)
        {
            Notify(blogPostTitle);
        }
    }

    public class Subscriber : IObserver
    {
        private string _name;

        public Subscriber(string name)
        {
            _name = name;
        }

        public void Update(string blogPostTitle)
        {
            Console.WriteLine($"{_name} has been notified about new blog post: {blogPostTitle}");
        }
    }

}