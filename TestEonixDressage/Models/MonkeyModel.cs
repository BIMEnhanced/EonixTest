using TestEonixDressage.Events;

namespace TestEonixDressage.Models
{
    /// <summary>
    /// Class to store the monkey infos
    /// </summary>
    internal class MonkeyModel
    {
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
            OnTourExecuted(new TourExecutedEventArgs(trick, Name));
        }

        /// <summary>
        /// Handle for the TourExecuted event
        /// </summary>
        public event EventHandler<TourExecutedEventArgs> TourExecuted;
        /// <summary>
        /// Invoke the TourExecuted
        /// </summary>
        /// <param name="e">TourExecutedEventArgs</param>
        protected virtual void OnTourExecuted(TourExecutedEventArgs e)
        {
            TourExecuted?.Invoke(this, e);
        }
    }
}
