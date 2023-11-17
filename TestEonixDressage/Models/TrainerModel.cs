namespace TestEonixDressage.Models
{
    /// <summary>
    /// Data model for the trainer
    /// </summary>
    internal class TrainerModel
    {
        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="name">The name of the trainer</param>
        /// <param name="monkey">His MonkeyModel</param>
        public TrainerModel(string name, MonkeyModel monkey)
        {
            Name = name;
            Monkey = monkey;
        }

        /// <summary>
        /// Name of the trainer
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Monkey model
        /// </summary>
        public MonkeyModel Monkey { get; set; }

        /// <summary>
        /// Ask the monkey to perform all of his tricks
        /// </summary>
        public void MakeMonkeyPerformAllTricks()
        {
            foreach (var tour in Monkey.Tricks)
            {
                Monkey.ExecuteTrick(tour);
            }
        }
    }
}
