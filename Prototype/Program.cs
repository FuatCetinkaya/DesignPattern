namespace Prototype;

internal class Program
{

    //Prototype Pattern, mevcut bir nesnenin kopyalarını oluşturarak yeni nesneler yaratmayı sağlayan bir creational tasarım kalıbıdır.
    //Bu kalıp, nesnelerin oluşturulması için pahalı veya karmaşık işlemleri yeniden yapmak yerine, mevcut nesnelerin kopyalarını kullanarak
    //işlem süresini ve kaynak kullanımını azaltmaya yardımcı olur.

    // Örnek olarak, belirli bir şekil çeşidi için bir sınıf hiyerarşisi düşünelim.Bu sınıfların her biri, şekillerin çizilmesi ve kopyalanması
    // gibi bazı temel işlevleri uygular.


//    Bu örnekte, Shape adlı soyut bir sınıf oluşturduk ve bu sınıftan türetilen Rectangle ve Circle sınıflarını kullandık.Shape sınıfında, tüm şekillerde ortak olan özellikler ve işlemler bulunmaktadır. Clone metodunu soyut olarak tanımlayarak, türetilen sınıfların kendi kopyalama işlemlerini gerçekleştirecek şekilde uyarlamalarını sağladık.

//Prototype Pattern kullanarak, nesnelerin kopyalarını hızlı ve etkili bir şekilde oluşturabiliriz. Bu sayede, nesne oluşturma maliyetini
//azaltarak daha performanslı bir uygulama elde edebiliriz.

//Eğer Prototype Pattern kullanmazsanız, her nesne için yeni bir örnek oluşturmak ve özelliklerini atamak zorunda kalırsınız.
//Bu, özellikle nesne oluşturma işlemi pahalı olduğunda veya büyük miktarda nesne kopyalaması gerektiğinde, performans problemlerine yol açabilir.

//Prototype Pattern, nesne oluşturma ve kopyalama süreçlerini daha hızlı ve etkili hale getirerek, uygulamanın performansını artırmaya yardımcı olur.
//Bu sayede, karmaşık nesne hiyerarşileri ve yapılarında bile nesnelerin kopyalarını kolayca oluşturabilir ve yönetebilirsiniz.

    static void Main(string[] args)
    {
        Rectangle rect1 = new Rectangle
        {
            X = 10,
            Y = 20,
            Color = "Red",
            Width = 100,
            Height = 50
        };

        Rectangle rect2 = rect1.Clone() as Rectangle;
        rect2.X = 30;
        rect2.Color = "Blue";

        Console.WriteLine($"rect1: X = {rect1.X}, Y = {rect1.Y}, Color = {rect1.Color}, Width = {rect1.Width}, Height = {rect1.Height}");
        Console.WriteLine($"rect2: X = {rect2.X}, Y = {rect2.Y}, Color = {rect2.Color}, Width = {rect2.Width}, Height = {rect2.Height}");

        Circle circle1 = new Circle
        {
            X = 5,
            Y = 15,
            Color = "Green",
            Radius = 42
        };

        Circle circle2 = circle1.Clone() as Circle;
        circle2.Y = 25;
        circle2.Color = "Yellow";

        Console.WriteLine($"circle1: X = {circle1.X}, Y = {circle1.Y}, Color = {circle1.Color}, Radius = {circle1.Radius}");
        Console.WriteLine($"circle2: X = {circle2.X}, Y = {circle2.Y}, Color = {circle2.Color}, Radius = {circle2.Radius}");
    }


    public abstract class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Color { get; set; }

        public Shape() { }

        public Shape(Shape source)
        {
            if (source != null)
            {
                X = source.X;
                Y = source.Y;
                Color = source.Color;
            }
        }

        public abstract Shape Clone();
    }

    public class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle() { }

        public Rectangle(Rectangle source) : base(source)
        {
            if (source != null)
            {
                Width = source.Width;
                Height = source.Height;
            }
        }

        public override Shape Clone()
        {
            return new Rectangle(this);
        }
    }

    public class Circle : Shape
    {
        public int Radius { get; set; }

        public Circle() { }

        public Circle(Circle source) : base(source)
        {
            if (source != null)
            {
                Radius = source.Radius;
            }
        }

        public override Shape Clone()
        {
            return new Circle(this);
        }
    }
}