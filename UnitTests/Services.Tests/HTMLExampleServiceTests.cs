using Data;
using Data.Models;
using NUnit.Framework;
using Services.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitTests.Common;
using UnitTests.Data;

namespace UnitTests.Services.Tests
{
    [TestFixture]
    public class HTMLExampleServiceTests
    {
        [Test]
        public async Task AddOrUpdate_Adds()
        {
            // Arrange
            List<HTMLExample> examples = new List<HTMLExample>{ HTMLExamples.Example1 };

            ApplicationDbContext context = InMemoryFactory.InitializeContext();
            await DataSeeder.SeedDataInDbContext(context, examples);

            HTMLExampleService service = new HTMLExampleService(context);

            var exampleToAdd = HTMLExamples.ExampleToAdd;

            // Act
            var exampleAdded = await service.AddOrUpdate(exampleToAdd);

            // Assert
            Assert.IsNotNull(await service.Get(exampleAdded.Id));
        }

        [Test]
        public async Task AddOrUpdate_Updates()
        {
            // Arrange
            List<HTMLExample> examples = new List<HTMLExample> { HTMLExamples.Example1, HTMLExamples.Example2 };

            ApplicationDbContext context = InMemoryFactory.InitializeContext();
            await DataSeeder.SeedDataInDbContext(context, examples);

            HTMLExampleService service = new HTMLExampleService(context);

            var exampleToUpdate = HTMLExamples.Example2;
            var updatedValue = "<p>Test</p>";
            exampleToUpdate.HTMLCode = updatedValue;

            // Act
            var exampleUpdated = await service.AddOrUpdate(exampleToUpdate);

            // Assert
            Assert.That((await service.Get(exampleUpdated.Id)).HTMLCode == updatedValue);
        }

        [Test]
        public async Task Get_ReturnsExample()
        {
            // Arrange
            List<HTMLExample> examples = new List<HTMLExample> { HTMLExamples.Example1, HTMLExamples.Example2 };

            ApplicationDbContext context = InMemoryFactory.InitializeContext();
            await DataSeeder.SeedDataInDbContext(context, examples);

            HTMLExampleService service = new HTMLExampleService(context);
            var exampleId = HTMLExamples.Example1.Id;

            // Act
            var example = await service.Get(exampleId);

            // Assert
            Assert.IsInstanceOf<HTMLExample>(example);
        }
    }
}
