namespace TestEonixDressage.Models
{
    /// <summary>
    /// Class to store trick info
    /// </summary>
    internal class TrickModel
    {
        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="name">Name of the trick</param>
        /// <param name="trickType">TrickTypeEnum for the trick type</param>
        public TrickModel(string name, TrickTypeEnum trickType)
        {
            Name = name;
            TrickType = trickType;
        }
        /// <summary>
        /// Name of the trick
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Type of trick (eg Acrobatie or Musique).
        /// </summary>
        public TrickTypeEnum TrickType { get; set; }
    }
}
