using TestEonixDressage.Models;

namespace TestEonixDressage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Initialization of trainers and monkeys
            List<TrainerModel> trainers = CreateDummyTrainerData();

            //Initialisation of the spectator
            SpectatorModel spectator = new ();

            //Subscribe the spectator to every monkey tour executed event
            foreach (TrainerModel trainer in trainers)
            {
                //trainer.Monkey.Subscribe(spectator);
                spectator.Subscribe(trainer.Monkey);
            }

            //Ask trainers to make monkeys perform their tricks
            trainers[0].MakeMonkeyPerformAllTricks();
            Console.WriteLine();
            trainers[1].MakeMonkeyPerformAllTricks();
        }

        /// <summary>
        /// Create dummy dataset for trainers and their monkey
        /// </summary>
        /// <returns>A list of trainer models</returns>
        private static List<TrainerModel> CreateDummyTrainerData()
        {         
            //Trainer/monkey 1
            MonkeyModel monkey1 = new("Petit soldat",
                new List<TrickModel>()
                {
                    new ("Défiler", TrickTypeEnum.Accrobatie),
                    new ("Marche impériale", TrickTypeEnum.Music)
                });       
            TrainerModel trainer1 = new("Tony", monkey1);

            //Tainer/monkey 2
            MonkeyModel monkey2 = new ("Michael", 
                new List<TrickModel>()
                {
                    new ("Moon Walk", TrickTypeEnum.Accrobatie),
                    new ("Thriller", TrickTypeEnum.Music),
                    new ("Smooth Criminal", TrickTypeEnum.Music)
                });
            TrainerModel trainer2 = new ("Jade", monkey2);

            return new List<TrainerModel>() { trainer1, trainer2 };
        }
    }
}