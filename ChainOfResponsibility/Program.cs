using System.Security.Cryptography;

namespace ChainOfResponsibility;

internal class Program
{
    //Chain of Responsibility Pattern, istemci ve hedef nesne arasında birden fazla nesnenin bir dizi şeklinde düzenlendiği ve
    //her nesnenin belirli bir sorumluluk üstlendiği bir davranışsal tasarım kalıbıdır.
    //İstek, zincirdeki nesneler arasında ilerler ve her nesne, isteği işleyip sonuç döndürebilir veya işlemi sonraki nesneye devredebilir.
    //Bu, istemcinin hedef nesneyi doğrudan çağırmak yerine, işlemin bir dizi nesne tarafından gerçekleştirileceği bir yapı sağlar.

    //Bu örnekte, BankAccount sınıfı temel hesap işlemlerini gerçekleştirirken, farklı işlem türleri için AccountOperationHandler alt sınıfları oluşturduk.
    //Bu işlemciler, işlem türüne göre işlemi gerçekleştirir veya zincirdeki bir sonraki işlemciye devreder.
    //Bu şekilde, istemci işlemcilerin işleyişini bilmeden işlemleri gerçekleştirebilir ve yeni işlem türleri kolayca eklenebilir.


    static void Main(string[] args)
    {
        AccountOperationHandler withdrawHandler = new WithdrawHandler();
        AccountOperationHandler depositHandler = new DepositHandler();
        AccountOperationHandler balanceHandler = new BalanceHandler();

        withdrawHandler.SetSuccessor(depositHandler);
        depositHandler.SetSuccessor(balanceHandler);

        BankAccount account = new BankAccount();

        withdrawHandler.HandleOperation("deposit", account, 1000);
        withdrawHandler.HandleOperation("withdraw", account, 200);
        withdrawHandler.HandleOperation("balance", account, 0);
    }

    public abstract class AccountOperationHandler
    {
        protected AccountOperationHandler Successor;

        public void SetSuccessor(AccountOperationHandler successor)
        {
            Successor = successor;
        }

        public abstract void HandleOperation(string operation, BankAccount account, decimal amount);
    }

    public class WithdrawHandler : AccountOperationHandler
    {
        public override void HandleOperation(string operation, BankAccount account, decimal amount)
        {
            if (operation == "withdraw")
            {
                account.Withdraw(amount);
                Console.WriteLine($"Withdrew {amount} from account. New balance: {account.Balance}");
            }

            else if (Successor != null)
            {
                Successor.HandleOperation(operation, account, amount);
            }
        }
    }

    public class DepositHandler : AccountOperationHandler
    {
        public override void HandleOperation(string operation, BankAccount account, decimal amount)
        {
            if (operation == "deposit")
            {
                account.Deposit(amount);
                Console.WriteLine($"Deposited {amount} to account. New balance: {account.Balance}");
            }
            else if (Successor != null)
            {
                Successor.HandleOperation(operation, account, amount);
            }
        }
    }

    public class BalanceHandler : AccountOperationHandler
    {
        public override void HandleOperation(string operation, BankAccount account, decimal amount)
        {
            if (operation == "balance")
            {
                Console.WriteLine($"Account balance: {account.Balance}");
            }
            else if (Successor != null)
            {
                Successor.HandleOperation(operation, account, amount);
            }
        }
    }

    public class BankAccount
    {
        public decimal Balance { get; private set; }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
    }
}