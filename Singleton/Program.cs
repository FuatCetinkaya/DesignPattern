namespace Singleton;

internal class Program
{
    //Singleton Pattern, bir sınıfın sadece tek bir örneğinin (instance) oluşturulmasını ve bu örneğin uygulama boyunca kolayca erişilebilir olmasını sağlayan bir creational tasarım kalıbıdır.
    //Singleton Pattern, genellikle global durumları yöneten, veritabanı bağlantıları veya konfigürasyon ayarları gibi nesneler için kullanılır.



    //Bu örnekte, DatabaseConnection adında bir sınıf oluşturduk. Bu sınıf, veritabanı bağlantısı için tek bir örnek sağlar.
    //Sınıfın yapıcısını (constructor) private olarak tanımlayarak, sınıfın dışında yeni örnekler oluşturulmasını engelledik.
    //Sınıfın içindeki statik _instance alanı, sınıfın tek örneğini tutar.

    //Instance özelliği ile, eğer örnek daha önce oluşturulmamışsa, örneği oluşturup döndürürüz.Eğer örnek zaten oluşturulmuşsa, mevcut örneği döndürürüz.
    //Bu sayede sınıfın sadece tek bir örneğini elde etmiş oluruz.

    //Singleton Pattern kullanarak, uygulama boyunca sadece tek bir veritabanı bağlantısı oluşturarak, kaynak kullanımını ve performans sorunlarını azaltabilirsiniz.
    //Bu pattern olmadan, her bağlantı için yeni bir örnek oluşturursanız, gereksiz kaynak kullanımı ve performans sorunlarıyla karşılaşabilirsiniz.
    //Singleton Pattern, global durumları ve paylaşılan kaynakları yönetmek için etkili ve performanslı bir yöntem sağlar.

    static void Main(string[] args)
    {
        DatabaseConnection connection1 = DatabaseConnection.Instance;
        DatabaseConnection connection2 = DatabaseConnection.Instance;

        Console.WriteLine($"Connection 1: {connection1.ConnectionString}");
        Console.WriteLine($"Connection 2: {connection2.ConnectionString}");

        Console.WriteLine($"Is both instances equal: {ReferenceEquals(connection1, connection2)}");
    }

    public class DatabaseConnection
    {
        private static DatabaseConnection _instance;
        private static readonly object _lock = new object();

        public string ConnectionString { get; private set; }

        private DatabaseConnection(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public static DatabaseConnection Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DatabaseConnection("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;");
                        }
                    }
                }
                return _instance;
            }
        }
    }

}