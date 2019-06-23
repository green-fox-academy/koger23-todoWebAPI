using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using myRestAPI;
using myRestAPI.Models;
using myRestAPI.Profiles;
using myRestAPI.Services;

namespace myRestAPITests
{
    [TestClass]
    public class TodoServiceTest
    {
        public TodoServiceTest()
        {
        }

        public static DbContextOptions<ApplicationContext> GetTestDbOptions()
        {
            return new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestTodoDb")
                .Options;
        }
        [TestMethod]
        public void FindAll()
        {
            // Arrange
            var options = GetTestDbOptions();
            using (var context = new ApplicationContext(options))
            {
                context.Todos.Add(new Todo { Name = "testTodo1" });
                context.Todos.Add(new Todo { Name = "testTodo2" });
                context.Todos.Add(new Todo { Name = "testTodo3" });
                context.SaveChanges();
            }

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var _mapper = mockMapper.CreateMapper();

            var _todoService = new TodoService(new ApplicationContext(options), _mapper);

            // Act
            var actual = _todoService.FindAll();

            // Assert
            Assert.AreEqual(3, actual.Count);
            Assert.AreEqual("testTodo2", actual[1].Name);
        }
    }
}
