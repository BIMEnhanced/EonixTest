using TestEonixDressage.Models;

namespace TestEonixDressage.Events
{
    /// <summary>
    /// Event arg to store data about a trick done by a monkey.
    /// </summary>
    internal class TourExecutedEventArgs : EventArgs
    {
        /// <summary>
        /// Full construcor
        /// </summary>
        /// <param name="trick">The trick done</param>
        /// <param name="monkeyName">The name of the monkey</param>
        internal TourExecutedEventArgs(TrickModel trick, string monkeyName)
        {
            Trick = trick;
            MonkeyName = monkeyName;
        }

        /// <summary>
        /// Trick model
        /// </summary>
        internal TrickModel Trick { get; }
        /// <summary>
        /// Name of the monkey
        /// </summary>
        internal string MonkeyName { get; }


    }
}
