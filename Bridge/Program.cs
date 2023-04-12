namespace Bridge;

internal class Program
{
    //Bridge Pattern, soyutlama ve uygulama katmanlarını ayıran bir yapısal tasarım kalıbıdır. Bu sayede, iki katman bağımsız olarak geliştirilebilir ve değiştirilebilir.
    //Bridge Pattern, soyutlamaların ve onların uygulanmasının arasında oluşabilecek kalıcı bağlantıları önlemeye yardımcı olur.

    //Bu örnekte, IRenderer adında bir arayüz tanımladık.Bu arayüzün iki farklı uygulaması olan VectorRenderer ve RasterRenderer sınıfları bulunmaktadır.
    //Shape adında soyut bir sınıf tanımlayarak, IRenderer arayüzünden bir nesne kullanarak şekilleri çizdik.Circle ve Square adında iki somut sınıf oluşturarak,
    //Shape sınıfını uyguladık.

    //Bridge Pattern kullanarak, Shape soyutlamasının ve IRenderer uygulamalarının bağımsız olarak geliştirilmesine ve değiştirilmesine olanak sağladık.
    //Bu sayede, yeni şekil veya çizim yöntemleri eklendiğinde veya mevcut olanlar değiştirildiğinde, diğer katmanın kodunu etkilemeden değişiklik yapabiliriz.

    //Bridge Pattern olmadan, her şekil ve çizim yöntemi için farklı sınıflar oluşturmanız ve bu sınıfların tüm kombinasyonlarını yönetmeniz gerekebilir.
    //Bu, kod karmaşasına ve zor yönetilen bir yapıya yol açar.Bridge Pattern sayesinde, kodun daha düzenli ve esnek olmasını sağlayabiliriz.
    static void Main(string[] args)
    {
        IRenderer vectorRenderer = new VectorRenderer();
        IRenderer rasterRenderer = new RasterRenderer();

        Shape circle = new Circle(vectorRenderer);
        circle.Draw();

        Shape square = new Square(rasterRenderer);
        square.Draw();
    }

    public interface IRenderer
    {
        void RenderShape(string shapeName);
    }

    public class VectorRenderer : IRenderer
    {
        public void RenderShape(string shapeName)
        {
            Console.WriteLine($"Rendering {shapeName} as vector.");
        }
    }

    public class RasterRenderer : IRenderer
    {
        public void RenderShape(string shapeName)
        {
            Console.WriteLine($"Rendering {shapeName} as raster.");
        }
    }

    public abstract class Shape
    {
        protected readonly IRenderer _renderer;

        protected Shape(IRenderer renderer)
        {
            _renderer = renderer;
        }

        public abstract void Draw();
    }

    public class Circle : Shape
    {
        public Circle(IRenderer renderer) : base(renderer) { }

        public override void Draw()
        {
            _renderer.RenderShape("circle");
        }
    }

    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer) { }

        public override void Draw()
        {
            _renderer.RenderShape("square");
        }
    }
}