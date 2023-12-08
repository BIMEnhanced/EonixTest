using System;
using TestEonixDressage.Events;

namespace TestEonixDressage.Models
{
    /// <summary>
    /// Class to store the monkey infos
    /// </summary>
    internal class MonkeyModel : IObservable<TourExecutedEventArgs>
    {
        private HashSet<IObserver<TourExecutedEventArgs>> _observers = new ();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The name of the monkey</param>
        /// <param name="tricks">The list of tricks he can do</param>
        public MonkeyModel(string name, List<TrickModel> tricks)
        {
            Name = name;
            Tricks = tricks;
        }

        public IDisposable Subscribe(IObserver<TourExecutedEventArgs> observer)
        {
            _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private readonly HashSet<IObserver<TourExecutedEventArgs>> _observers;
            private readonly IObserver<TourExecutedEventArgs> _observer;

            public Unsubscriber(HashSet<IObserver<TourExecutedEventArgs>> observers, IObserver<TourExecutedEventArgs> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observers.Contains(_observer))
                {
                    _observers.Remove(_observer);
                }
            }
        }

        /// <summary>
        /// Name of the monkey
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The list of tricks the monkey can do
        /// </summary>
        public List<TrickModel> Tricks { get; set; }

        /// <summary>
        /// Ask the monkey to perform a trick, writting it in console and launching event
        /// </summary>
        /// <param name="trick"></param>
        public void ExecuteTrick(TrickModel trick)
        {
            Console.WriteLine($"{Name} exécute le tour {trick.Name}");
            NotifyObservers(new TourExecutedEventArgs(trick, Name));

        }
        private void NotifyObservers(TourExecutedEventArgs e)
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(e);
            }
        }

    }
}
