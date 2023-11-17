namespace UnitTest
{
    /// <summary>
    /// List of unit test for the person controller
    /// </summary>
    public class PersonControllerUnitTests : TestBase
    {
        [Fact]
        public async Task AddPerson_WithValidPerson_ReturnsCreatedResponse()
        {
            // Arrange
            using var context = await GetDbContext();
            var controller = new PersonController(context);
            var newPerson = new Person { FirstName = "John", LastName = "Doe" };

            // Act
            var result = await controller.AddPerson(newPerson);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var model = Assert.IsType<Person>(createdResult.Value);
            Assert.Equal("John", model.FirstName);
            Assert.Equal("Doe", model.LastName);
        }

        [Fact]
        public async Task AddPerson_WithInvalidPerson_ReturnsBadRequest()
        {
            // Arrange
            using var context = await GetDbContext();
            var controller = new PersonController(context);
            var invalidPerson = new Person(); // This person is invalid because it lacks required properties.

            // Act
            var result = await controller.AddPerson(invalidPerson);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetPeople_ReturnsListOfPeople()
        {
            // Arrange
            using var context = await GetDbContext();
            await PopulateDB(context);
            var controller = new PersonController(context);


            // Act
            var result = await controller.GetPeople();

            // Assert
            var model = Assert.IsAssignableFrom<IEnumerable<Person>>(result.Value);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task GetPeople_WithFilters_ReturnsFilteredPeople()
        {
            // Arrange
            using var context = await GetDbContext();
            await PopulateDB(context);
            var controller = new PersonController(context);

            // Act
            var result = await controller.GetPeople("mon", "Dujo");

            // Assert
            var model = Assert.IsAssignableFrom<IEnumerable<Person>>(result.Value);
            Assert.Single(model); // Assuming there is only one person with the specified first and last names
            Assert.Contains(model, p => p.FirstName == "Simon" && p.LastName == "Dujoin");
        }

        [Fact]
        public async Task GetPerson_WithValidId_ReturnsPerson()
        {
            // Arrange
            using var context = await GetDbContext();
            await PopulateDB(context);
            Guid id = context.Persons.FirstOrDefault().Id;
            PersonController controller = new (context);

            // Act
            var result = await controller.GetPerson(id.ToString());

            // Assert
            var model = Assert.IsType<ActionResult<Person>>(result);
            Assert.NotNull(model.Value);
            Assert.Equal(id.ToString(), model.Value.Id.ToString());
        }

        [Fact]
        public async Task DeletePerson_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            using var context = await GetDbContext();
            var controller = new PersonController(context);
            await PopulateDB(context);

            // Act
            var result = await controller.DeletePerson("11111111-1111-1111-1111-111111111111");

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
