namespace UnitTest
{
    /// <summary>
    /// Abstract base class for the unit tests
    /// </summary>
    public abstract class TestBase
    {
        /// <summary>
        /// Create the db context for the test.
        /// </summary>
        /// <returns></returns>
        public async Task<AppDbContext> GetDbContext()
        {
            var dbContext = new AppDbContext("DataSource=:memory:");
            await dbContext.Database.OpenConnectionAsync();
            dbContext.Database.EnsureCreated();
            return dbContext;
        }

        /// <summary>
        /// Initialize db data with 2 persons
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        protected static async Task PopulateDB(AppDbContext dbContext)
        {
            dbContext.Persons.Add(new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Simon",
                LastName = "Dujoin"
            });

            dbContext.Persons.Add(new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Albert",
                LastName = "Camu"
            });
            await dbContext.SaveChangesAsync();
        }
    }
}