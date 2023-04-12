using System.Reflection;

namespace Command;


//Strategy Pattern(Strateji Tasarım Deseni) bir nesne yönelimli programlama tasarım desenidir.
//Bu desen sayesinde, bir işi birden fazla yolla yapabilen, ancak seçilen yönteme bağlı olarak farklı sonuçlar üreten nesneler arasında geçiş yapabiliriz.

//Örneğin, bir uygulama içinde farklı sıralama algoritmaları kullanabiliriz.Ama bu algoritmalar farklı sıralama yöntemlerine sahip olabilirler.
//Bu durumda Strategy Pattern kullanarak, farklı sıralama stratejilerini oluşturabiliriz.

//Ayrıca bu tasarım deseni, kodun yeniden kullanılabilirliğini artırır ve kodun bakımını kolaylaştırır. Aynı zamanda, kodun açık ve anlaşılır olmasını sağlar.

//Örnek kodda, bir dizi sayıyı sıralamak için farklı sıralama stratejileri oluşturacağız.Bunlar sıralama stratejilerimiz olacaklar.
//Bu örnekte, sıralama stratejilerimizden birisi Bubble Sort, diğeri ise Quick Sort olacak.




//Burada ISortingStrategy arayüzünü tanımlıyoruz.Bu arayüz, herhangi bir sıralama stratejisi için uygulanabilir. Daha sonra, bu arayüzü uygulayan BubbleSortStrategy ve QuickSortStrategy sınıflarını oluşturuyoruz. Bu sınıflar, farklı sıralama yöntemlerini uygulamak için kullanılır.

//Son olarak, Sorter sınıfını oluşturuyoruz.Bu sınıf, ISortingStrategy arayüzünü uygulayan bir sıralama stratejisi nesnesi alır. Sorter sınıfı içinde, SetSortingStrategy() yöntemi kullanarak sıralama stratejisi nesnesini ayarlarız.Son olarak, Sort() yöntemi, sıralama stratejisi nesnesini kullanarak, belirtilen diziyi sıralar.
public interface ISortingStrategy
{
    void Sort(int[] data);
}

public class BubbleSortStrategy : ISortingStrategy
{
    public void Sort(int[] data)
    {
        // Bubble sort implementation
    }
}

public class QuickSortStrategy : ISortingStrategy
{
    public void Sort(int[] data)
    {
        // Quick sort implementation
    }
}

public class Sorter
{
    private ISortingStrategy _sortingStrategy;

    public void SetSortingStrategy(ISortingStrategy sortingStrategy)
    {
        _sortingStrategy = sortingStrategy;
    }

    public void Sort(int[] data)
    {
        _sortingStrategy.Sort(data);
    }
}

class Program1
{
    static void Main1(string[] args)
    {
        int[] data = { 1, 5, 3, 2, 6, 4 };
        Sorter sorter = new Sorter();

        sorter.SetSortingStrategy(new BubbleSortStrategy());
        sorter.Sort(data);

        sorter.SetSortingStrategy(new QuickSortStrategy());
        sorter.Sort(data);
    }
}

