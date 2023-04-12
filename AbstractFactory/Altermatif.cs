 

namespace AbstractFactory;


    // Veritabanı bağlantısı ve komutları için soyut sınıflar
    public interface IDbConnection
    {
        void Open();
        void Close();
    }

    public interface IDbCommand
    {
        void Execute();
    }

    // SQL Server bağlantısı ve komutları
    public class SqlConnection : IDbConnection
    {
        public void Open() => Console.WriteLine("SQL Server bağlantısı açıldı.");
        public void Close() => Console.WriteLine("SQL Server bağlantısı kapandı.");
    }

    public class SqlCommand : IDbCommand
    {
        public void Execute() => Console.WriteLine("SQL Server komutu çalıştırıldı.");
    }

    // Oracle bağlantısı ve komutları
    public class OracleConnection : IDbConnection
    {
        public void Open() => Console.WriteLine("Oracle bağlantısı açıldı.");
        public void Close() => Console.WriteLine("Oracle bağlantısı kapandı.");
    }

    public class OracleCommand : IDbCommand
    {
        public void Execute() => Console.WriteLine("Oracle komutu çalıştırıldı.");
    }

    // Abstract Factory sınıfı
    public interface IDbFactory
    {
        IDbConnection CreateConnection();
        IDbCommand CreateCommand();
    }

    // Concrete Factory sınıfları
    public class SqlDbFactory : IDbFactory
    {
        public IDbConnection CreateConnection() => new SqlConnection();
        public IDbCommand CreateCommand() => new SqlCommand();
    }

    public class OracleDbFactory : IDbFactory
    {
        public IDbConnection CreateConnection() => new OracleConnection();
        public IDbCommand CreateCommand() => new OracleCommand();
    }

    class Program1
    {
        static void Main1(string[] args)
        {
            IDbFactory dbFactory;

            // Kullanıcı girişi veya yapılandırma dosyasından veritabanı türünü belirleyin
            string dbType = "sql"; // Örnek olarak SQL Server seçtik

            if (dbType == "sql")
            {
                dbFactory = new SqlDbFactory();
            }
            else
            {
                dbFactory = new OracleDbFactory();
            }

            IDbConnection connection = dbFactory.CreateConnection();
            IDbCommand command = dbFactory.CreateCommand();

            connection.Open();
            command.Execute();
            connection.Close();
        }
    }

