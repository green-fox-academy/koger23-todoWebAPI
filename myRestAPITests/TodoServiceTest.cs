using Autofac.Extras.Moq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using myRestAPI;
using myRestAPI.Models;
using myRestAPI.Models.Assignee;
using myRestAPI.Models.User;
using myRestAPI.Profiles;
using myRestAPI.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
        public void CreateTodo_ShouldBeBadRequest()
        {
            // Arrange
            var options = GetTestDbOptions();

            using (var context = new ApplicationContext(options))
            {

                var todoService = new TodoService(context, GetMockMapper());

                var todoDTO = new TodoDTO()
                {
                    Name = "test1",
                    Description = "use mock",
                    AssigneeId = 1,
                    Done = false,
                    UserId = 1
                };
                var expected = new BadRequestResult();

                // Act
                Task<IActionResult> actual = todoService.CreateTodo(todoDTO);

                // Assert
                Assert.IsNotNull(actual);
                Assert.AreEqual(expected.GetType(), actual.Result.GetType());
            }
        }

        [TestMethod]
        public void CreateTodo_ShouldBeOkResult()
        {
            // Arrange
            var options = GetTestDbOptions();

            using (var context = new ApplicationContext(options))
            {
                User user = new User()
                {
                    Id = 1,
                    FirstName = "Test",
                    LastName = "Moq",
                    Username = "test_moq",
                    Role = "User"
                };

                Assignee assignee = new Assignee()
                {
                    Email = "asd@example.com",
                    Name = "Test Assignee",
                };
                context.Add<User>(user);
                context.Add<Assignee>(assignee);

                var todoService = new TodoService(context, GetMockMapper());

                var todoDTO = new TodoDTO()
                {
                    Name = "test1",
                    Description = "use mock",
                    UserId = 1,
                    AssigneeId = 1,
                    Done = false
                };
                var expected = new OkResult();

                // Act
                Task<IActionResult> actual = todoService.CreateTodo(todoDTO);

                // Assert
                Assert.IsNotNull(actual);
                Assert.AreEqual(expected.GetType(), actual.Result.GetType());
            }
        }
    }
}
