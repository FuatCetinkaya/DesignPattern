using System.Reflection;

namespace Iterator;

internal class Program
{
    //Iterator Pattern, koleksiyonlar üzerinde dolaşmayı sağlayan bir nesne oluşturarak, koleksiyonun uygulanmasından bağımsız olarak onun üzerinde işlem yapmayı sağlar.
    //Bu sayede koleksiyonun iç yapısı ve uygulanması hakkında bilgi sahibi olmadan üzerinde gezinmek mümkün olur.

    //Örnek olarak, basit bir Agac veri yapısı düşünelim ve bu ağacın elemanlarını dolaşan bir iterator oluşturalım:

    //Bu örnekte Agac sınıfı ve onun elemanlarını dolaşan AgacIterator sınıfı kullanılmıştır.
    //AgacAggregate sınıfı, ağacı dolaşmak için bir iterator oluşturur. İstemci, iterator üzerinden ağacın elemanlarını dolaşarak işlem yapabilir.
    //Bu sayede istemci, ağacın iç yapısı ve uygulanması hakkında bilgi sahibi olmadan üzerinde gezinebilir.

    //    Iterator Pattern'in avantajları şunlardır:

    //Koleksiyonun iç yapısı ve uygulanmasından bağımsız olarak işlem yapmaya olanak tanır.
    //Koleksiyonlar üzerinde dolaşmak için ortak bir arayüz sağlar, bu sayede farklı koleksiyon türleri için aynı dolaşma yöntemi kullanılabilir.
    //Koleksiyon üzerinde birden fazla işlem yaparken, her işlem için farklı iteratorlar kullanarak kodun okunabilirliği ve bakımı kolaylaşır.




    static void Main(string[] args)
    {
        Agac<int> agac = new Agac<int>
        {
            Data = 5,
            Left = new Agac<int>
            {
                Data = 3,
                Left = new Agac<int> { Data = 1 },
                Right = new Agac<int> { Data = 4 }
            },
            Right = new Agac<int>
            {
                Data = 7,
                Left = new Agac<int> { Data = 6 },
                Right = new Agac<int> { Data = 8 }
            }
        };

        IAggregate<int> aggregate = new AgacAggregate<int>(agac);
        IIterator<int> iterator = aggregate.CreateIterator();

        Console.WriteLine("Ağacın elemanları:");
        for (int value = iterator.First(); !iterator.IsDone; value = iterator.Next())
        {
            Console.WriteLine(value);
        }
    }

    public interface IIterator<T>
    {
        T First();
        T Next();
        bool IsDone { get; }
        T Current { get; }
    }

    public interface IAggregate<T>
    {
        IIterator<T> CreateIterator();
    }

    public class Agac<T>
    {
        public T Data;
        public Agac<T> Left;
        public Agac<T> Right;
    }

    public class AgacIterator<T> : IIterator<T>
    {
        private Agac<T> _root;
        private Stack<Agac<T>> _stack;

        public AgacIterator(Agac<T> root)
        {
            _root = root;
            _stack = new Stack<Agac<T>>();
        }

        public T First()
        {
            _stack.Clear();
            Agac<T> currentNode = _root;
            while (currentNode != null)
            {
                _stack.Push(currentNode);
                currentNode = currentNode.Left;
            }

            return Current;
        }

        public T Next()
        {
            if (_stack.Count > 0)
            {
                Agac<T> currentNode = _stack.Pop();
                Agac<T> rightNode = currentNode.Right;
                while (rightNode != null)
                {
                    _stack.Push(rightNode);
                    rightNode = rightNode.Left;
                }

                return currentNode.Data;
            }

            return default(T);
        }

        public bool IsDone => _stack.Count == 0;

        public T Current => IsDone ? default(T) : _stack.Peek().Data;
    }

    public class AgacAggregate<T> : IAggregate<T>
    {
        private Agac<T> _root;

        public AgacAggregate(Agac<T> root)
        {
            _root = root;
        }

        public IIterator<T> CreateIterator()
        {
            return new AgacIterator<T>(_root);
        }
    }

}