namespace Strategy;

internal class Program
{
    static void Main(string[] args)
    {
        var cart = new ShoppingCart();
        cart.AddProduct(new Product("Shoes", 50));
        cart.AddProduct(new Product("Shirt", 20));
        cart.SetPaymentStrategy(new CreditCardPaymentStrategy("John Doe", "1234567890123456", "123", "10/2024"));
        cart.Pay();

        cart.SetPaymentStrategy(new PayPalPaymentStrategy("example@example.com", "password"));
        cart.Pay();
    }

    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }


    // Strategy Interface
    public interface IPaymentStrategy
    {
        void Pay(int amount);
    }

    // Concrete Strategies
    public class CreditCardPaymentStrategy : IPaymentStrategy
    {
        private string _name;
        private string _cardNumber;
        private string _cvv;
        private string _expiryDate;

        public CreditCardPaymentStrategy(string name, string cardNumber, string cvv, string expiryDate)
        {
            _name = name;
            _cardNumber = cardNumber;
            _cvv = cvv;
            _expiryDate = expiryDate;
        }

        public void Pay(int amount)
        {
            Console.WriteLine($"{amount} paid with credit/debit card.");
        }
    }

    public class PayPalPaymentStrategy : IPaymentStrategy
    {
        private string _email;
        private string _password;

        public PayPalPaymentStrategy(string email, string password)
        {
            _email = email;
            _password = password;
        }

        public void Pay(int amount)
        {
            Console.WriteLine($"{amount} paid using PayPal.");
        }
    }

    // Context
    public class ShoppingCart
    {
        private List<Product> _products;
        private IPaymentStrategy _paymentStrategy;

        public ShoppingCart()
        {
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            _products.Remove(product);
        }

        public int CalculateTotal()
        {
            int total = 0;
            foreach (var product in _products)
            {
                total += product.Price;
            }
            return total;
        }

        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public void Pay()
        {
            int total = CalculateTotal();
            _paymentStrategy.Pay(total);
        }
    }

}