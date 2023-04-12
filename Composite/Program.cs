namespace Composite;

internal class Program
{
    //Composite Pattern, ağaç benzeri yapıları oluşturmak için kullanılan bir yapısal tasarım kalıbıdır.
    //Bu kalıp, nesnelerin hiyerarşik olarak düzenlenmesine ve grupların ve bireysel nesnelerin aynı arayüzü kullanarak işlem yapabilmesine olanak tanır.

    //Bu örnekte, Component adında soyut bir sınıf oluşturduk. Bu sınıf, Add, Remove ve Display işlemlerini tanımlar. Composite ve Leaf sınıfları,
    //Component sınıfından türetilmiştir. Composite sınıfı, alt bileşenleri saklayarak ve yöneterek ağaç yapısını oluşturur.
    //Leaf sınıfı, hiyerarşinin en altındaki elemanları temsil eder ve alt bileşenlere sahip değildir.

    //Composite Pattern, ağaç benzeri yapıları yönetirken avantaj sağlar.
    //Bu pattern olmadan, her düğüm türü için özel kod yazmak ve her düğüm türü için işlemleri tekrar tekrar gerçekleştirmek zorunda kalırdınız.
    //Bu, kodun karmaşıklığını artırır ve yönetilebilirliğini azaltır.

    static void Main(string[] args)
    {
        Composite root = new Composite("root");
        root.Add(new Leaf("Leaf A"));
        root.Add(new Leaf("Leaf B"));

        Composite comp = new Composite("Composite X");
        comp.Add(new Leaf("Leaf XA"));
        comp.Add(new Leaf("Leaf XB"));

        root.Add(comp);
        root.Add(new Leaf("Leaf C"));

        Leaf leaf = new Leaf("Leaf D");
        root.Add(leaf);
        root.Remove(leaf);

        root.Display(1);
    }

    public abstract class Component
    {
        protected string Name;

        protected Component(string name)
        {
            Name = name;
        }

        public abstract void Add(Component component);

        public abstract void Remove(Component component);

        public abstract void Display(int depth);
    }

    public class Composite : Component
    {
        private readonly List<Component> _children = new List<Component>();

        public Composite(string name) : base(name) { }

        public override void Add(Component component)
        {
            _children.Add(component);
        }

        public override void Remove(Component component)
        {
            _children.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + Name);

            foreach (var component in _children)
            {
                component.Display(depth + 2);
            }
        }
    }

    public class Leaf : Component
    {
        public Leaf(string name) : base(name) { }

        public override void Add(Component component)
        {
            Console.WriteLine("Cannot add to a leaf");
        }

        public override void Remove(Component component)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + Name);
        }
    }
}