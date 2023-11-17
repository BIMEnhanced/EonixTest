using SQLite;

namespace PersonApi.Models
{
    /// <summary>
    /// Class to store information from the person
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Guid of the person
        /// </summary>
        [PrimaryKey]
        [NotNull]
        public Guid Id { get; set; }
        /// <summary>
        /// First name of the person
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of the person
        /// </summary>
        public string LastName { get; set; }
    }
}
