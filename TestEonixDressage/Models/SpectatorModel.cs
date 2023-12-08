using TestEonixDressage.Events;

namespace TestEonixDressage.Models
{
    /// <summary>
    /// Class to store the data for the spectator
    /// </summary>
    internal class SpectatorModel : IObserver<TourExecutedEventArgs>
    {

        private IDisposable unsubscriber; // Used to unsubscribe from the observable

        /// <summary>
        /// Subscribe to the observable (MonkeyModel)
        /// </summary>
        /// <param name="observable"></param>
        public void Subscribe(MonkeyModel observable)
        {
            unsubscriber = observable.Subscribe(this);
        }

        /// <summary>
        /// Unsubscribe from the observable
        /// </summary>
        public void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        /// <summary>
        /// Define how the spectator will react to a monkey trick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnNext(TourExecutedEventArgs e)
        {
            if (e.Trick.TrickType == TrickTypeEnum.Accrobatie)
            {
                Applause(e.Trick.Name, e.MonkeyName);
            }
            else if (e.Trick.TrickType == TrickTypeEnum.Music)
            {
                Wistle(e.Trick.Name, e.MonkeyName);
            }
        }
        /// <summary>
        /// Write in console how the spectator applause
        /// </summary>
        /// <param name="trick"></param>
        /// <param name="monkeyName"></param>
        public void Applause(string trick, string monkeyName)
        {
            Console.WriteLine($"Spectateur applaudit pendant le tour {trick} du singe {monkeyName}");
        }
        /// <summary>
        /// Write in console how the spectator wistle
        /// </summary>
        /// <param name="trick"></param>
        /// <param name="monkeyName"></param>
        public void Wistle(string trick, string monkeyName)
        {
            Console.WriteLine($"Spectateur siffle pendant le tour {trick} du singe {monkeyName}");
        }

        // Implementing IObserver interface
        public void OnCompleted() { }
        public void OnError(Exception error) { }
    }
}
