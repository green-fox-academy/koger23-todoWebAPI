using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using myRestAPI.Controllers;
using myRestAPI.Models;
using myRestAPI.Services;

namespace myRestAPITests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TodoControllerTest_GetTodoList()
        {
            var mockTodoService = new Mock<ITodoService>();
            //var mockTodoService = new Mock<TodoService>(mockITodoService);

            TodoListDTO todoListDTO = new TodoListDTO();
            mockTodoService.Setup(x => x.FindAll())
                .Returns(todoListDTO);

            TodoController todoController = new TodoController(mockTodoService.Object);

            // Act
            TodoListDTO actionResult = todoController.Get();

            // Assert
            Assert.AreEqual(todoListDTO, actionResult);
        }
        
        [TestMethod]
        public void TodoControllerTest_AddTodo()
        {
            var mockTodoService = new Mock<ITodoService>();
            //var mockTodoService = new Mock<TodoService>(mockITodoService);

            TodoDTO todoDTO = new TodoDTO(name: "test", assigneeId: 1, description: "mock");

            TodoListDTO todoListDTO = new TodoListDTO();
            mockTodoService.Setup(x => x.FindAll())
                .Returns(todoListDTO);

            TodoController todoController = new TodoController(mockTodoService.Object);

            // Act
            IActionResult actionResult = todoController.Post(todoDTO);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }
    }
}
