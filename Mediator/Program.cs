using System;
using System.Collections.Generic;
using static Mediator.Program;

namespace Mediator;

internal class Program
{
    // Mediator Pattern, nesneler arasındaki iletişimi kolaylaştırmak ve düzenlemek için kullanılan bir davranışsal tasarım desenidir.
    // Bu desen, nesneler arasındaki doğrudan bağımlılıkları azaltmak için aracı bir nesne (Mediator) kullanır.
    // Böylece nesneler birbirlerinin varlığından haberdar olabilir, ancak birbirlerine doğrudan bağlı olmazlar.
    static void Main(string[] args)
    {
        IMediator mediator = new ConcreteMediator();

        IColleague colleagueA = new ConcreteColleagueA(mediator);
        IColleague colleagueB = new ConcreteColleagueB(mediator);

        mediator.AddColleague(colleagueA);
        mediator.AddColleague(colleagueB);

        colleagueA.Send("Hello");
        colleagueB.Send("Goodbye");
    }

    public interface IMediator
    {
        void AddColleague(IColleague colleague);
        void Send(string message, IColleague sender);
    }

    public class ConcreteMediator : IMediator
    {
        private readonly List<IColleague> _colleagues = new List<IColleague>();

        public void AddColleague(IColleague colleague)
        {
            _colleagues.Add(colleague);
        }

        public void Send(string message, IColleague sender)
        {
            foreach (var colleague in _colleagues)
            {
                if (colleague != sender)
                {
                    colleague.Receive(message);
                }
            }
        }
    }

    public interface IColleague
    {
        void Send(string message);
        void Receive(string message);
    }

    public class ConcreteColleagueA : IColleague
    {
        private readonly IMediator _mediator;

        public ConcreteColleagueA(IMediator mediator)
        {
            _mediator = mediator;
            _mediator.AddColleague(this);
        }

        public void Send(string message)
        {
            _mediator.Send(message, this);
        }

        public void Receive(string message)
        {
            Console.WriteLine("Colleague A received message: " + message);
        }
    }

    public class ConcreteColleagueB : IColleague
    {
        private readonly IMediator _mediator;

        public ConcreteColleagueB(IMediator mediator)
        {
            _mediator = mediator;
            _mediator.AddColleague(this);
        }

        public void Send(string message)
        {
            _mediator.Send(message, this);
        }

        public void Receive(string message)
        {
            Console.WriteLine("Colleague B received message: " + message);
        }
    }

}