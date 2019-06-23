using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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

        public static IMapper GetMockMapper()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            return mockMapper.CreateMapper();
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

            var _todoService = new TodoService(new ApplicationContext(options), GetMockMapper());

            // Act
            var actual = _todoService.FindAll();

            // Assert
            Assert.AreEqual(3, actual.Count);
            Assert.AreEqual("testTodo2", actual[1].Name);
        }

        [TestMethod]
        public void CreateTodo()
        {
            var mockSet = new Mock<DbSet<Todo>>();

            var mockContext = new Mock<ApplicationContext>();
            mockContext.Setup(m => m.Todos).Returns(mockSet.Object);
            var service = new TodoService(mockContext.Object, );
        }
    }
}
