namespace Composite;

internal class Alternatif
{
    // bir şirketin çalışanlarını ve departmanlarını modelleyen alternatif bir Composite Pattern örneği 

    // Bu örnekte, IEmployee adlı bir arayüz tanımladık. Employee sınıfı bu arayüzü uygulayarak çalışanları temsil ederken,
    // Department sınıfı da aynı arayüzü uygulayarak departmanları temsil ediyor. Department sınıfı, çalışanları ve alt departmanları saklayarak ve yöneterek
    // hiyerarşik yapıyı oluşturur.

    //Bu örnek sayesinde, şirketin departmanlarını ve çalışanlarını hiyerarşik bir yapıda düzenleyebilir ve tüm çalışanların detaylarını görüntülemek
    //için tek bir çağrı yaparak işlem yapabiliriz.Composite Pattern, bu tür karmaşık yapıları daha düzenli ve kolay yönetilebilir hale getirir
    //ve kodun daha esnek ve okunaklı olmasını sağlar.

    public interface IEmployee
    {
        void ShowEmployeeDetails();
    }

    public class Employee : IEmployee
    {
        private string _name;
        private string _position;

        public Employee(string name, string position)
        {
            _name = name;
            _position = position;
        }

        public void ShowEmployeeDetails()
        {
            Console.WriteLine($"{_position}: {_name}");
        }
    }

    public class Department : IEmployee
    {
        private string _name;
        private List<IEmployee> _employees;

        public Department(string name)
        {
            _name = name;
            _employees = new List<IEmployee>();
        }

        public void AddEmployee(IEmployee employee)
        {
            _employees.Add(employee);
        }

        public void RemoveEmployee(IEmployee employee)
        {
            _employees.Remove(employee);
        }

        public void ShowEmployeeDetails()
        {
            Console.WriteLine($"Department: {_name}");
            foreach (var employee in _employees)
            {
                employee.ShowEmployeeDetails();
            }
        }
    }

    class Program1
    {
        static void Main1(string[] args)
        {
            Employee john = new Employee("John Doe", "Software Developer");
            Employee jane = new Employee("Jane Smith", "Software Developer");

            Department softwareDevelopment = new Department("Software Development");
            softwareDevelopment.AddEmployee(john);
            softwareDevelopment.AddEmployee(jane);

            Employee alice = new Employee("Alice Brown", "HR Specialist");
            Employee bob = new Employee("Bob Johnson", "HR Specialist");

            Department humanResources = new Department("Human Resources");
            humanResources.AddEmployee(alice);
            humanResources.AddEmployee(bob);

            Department company = new Department("Company");
            company.AddEmployee(softwareDevelopment);
            company.AddEmployee(humanResources);

            company.ShowEmployeeDetails();
        }
    }
}
