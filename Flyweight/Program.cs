using System.Reflection;
using System.Runtime.ConstrainedExecution;

namespace Flyweight;

internal class Program
{
    //Flyweight Pattern, nesnelerin sayısını azaltarak bellek kullanımını optimize etmeye yönelik bir yapısal tasarım kalıbıdır.
    //Bu kalıp, nesnelerin ortak özelliklerini paylaşarak bellek kullanımını azaltır ve daha fazla nesne oluşturma maliyetinden kaçınır.


    //Bu örnekte, IShape arayüzü ile şekilleri temsil ediyoruz ve Circle sınıfı bu arayüzü uyguluyor. ShapeFactory sınıfı, istenen renkte bir daire oluşturarak ve mevcut daireleri önbellekte saklayarak Flyweight Pattern'i uyguluyor.

    //Flyweight Pattern kullanarak, daha az nesne oluşturma maliyetiyle çalışabilir ve bellek kullanımını optimize edebilirsiniz.Bu özellikle büyük sayıda benzer nesnenin oluşturulması gereken durumlar için kullanışlıdır.Flyweight Pattern olmadan, her bir nesne için benzer özelliklerle yeni nesneler oluşturmak zorunda kalırız ve bu da bellek kullanımını artırır.


    static void Main(string[] args)
    {
        ShapeFactory shapeFactory = new ShapeFactory();

        IShape redCircle = shapeFactory.GetShape("Red");
        redCircle.Draw();

        IShape blueCircle = shapeFactory.GetShape("Blue");
        blueCircle.Draw();

        IShape greenCircle = shapeFactory.GetShape("Green");
        greenCircle.Draw();

        IShape anotherRedCircle = shapeFactory.GetShape("Red");
        anotherRedCircle.Draw();

        Console.WriteLine("Total shapes created: " + shapeFactory.TotalShapesCreated());
    }
    public interface IShape
    {
        void Draw();
    }

    public class Circle : IShape
    {
        public string Color { get; set; }

        public Circle(string color)
        {
            Color = color;
        }

        public void Draw()
        {
            Console.WriteLine("Drawing a " + Color + " circle.");
        }
    }

    public class ShapeFactory
    {
        private Dictionary<string, IShape> _shapes = new Dictionary<string, IShape>();

        public IShape GetShape(string color)
        {
            if (!_shapes.ContainsKey(color))
            {
                _shapes[color] = new Circle(color);
            }
            return _shapes[color];
        }

        public int TotalShapesCreated()
        {
            return _shapes.Count;
        }
    }

}