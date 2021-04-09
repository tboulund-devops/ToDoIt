using BLL;
using DAL;
using FluentAssertions;
using Model;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTest
{
    public class ToDoItUnitTaskTest
    {
        private List<Task> _tasks = null;
        private readonly Mock<IRepository<Task>> _TaskRepoMock;
        private List<Assignee> _assignees = null;
        public readonly Mock<IRepository<Assignee>> _AssigneeRepoMock;

        public ToDoItUnitTaskTest()
        {
            _TaskRepoMock = new Mock<IRepository<Task>>();
            _TaskRepoMock.Setup(repo => repo.Read()).Returns(() => _tasks);

            _AssigneeRepoMock = new Mock<IRepository<Assignee>>();
            _AssigneeRepoMock.Setup(repo => repo.Read()).Returns(() => _assignees);
        }

        #region ServiceTests

        [Fact]
        public void CreateServiceWithValidRepositoryTest()
        {
            //Arrange
            var repo = _TaskRepoMock.Object;

            //Act
            var service = new TaskService(repo);

            //Assert
            Assert.NotNull(service);
        }

        [Fact]
        public void CreateServiceWithInvalidRepositoryTest()
        {
            //Arrange
            IRepository<Task> repo = null;

            //Act
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                var service = new TaskService(repo);
            });

            //Assert
            Assert.Equal("Repository is missing", ex.Message);
        }

        #endregion

        #region TaskCRUDFunctionality
        [Fact]
        public void CreateTaskWithValidInputTest()
        {
            //Arrange
            var task = new Task()
            {
                Description = "Some Description",
                Assignee = new Assignee(),
                IsCompleted = false,
                DueDate = DateTime.Now
            };

            var service = new TaskService(_TaskRepoMock.Object);

            _tasks = new List<Task>();

            //Act
            var newTask = service.Create(task);
            _tasks.Add(task);

            //Assert
            _TaskRepoMock.Setup(repo => repo.Create(task)).Returns(newTask);
            _TaskRepoMock.Verify(repo => repo.Create(task), Times.Once);
            _tasks.Should().Contain(task);
        }

        [Fact]
        public void CreateTaskWithInvalidInputTest()
        {
            //Arrange
            var task = new Task()
            {
                Description = null,
                Assignee = null,
                IsCompleted = false,
                DueDate = null
            };

            var service = new TaskService(_TaskRepoMock.Object);

            //Act
            var ex = Assert.Throws<ArgumentException>(() => service.Create(task));

            //Assert
            Assert.Equal("Invalid Task", ex.Message);
            _TaskRepoMock.Verify(repo => repo.Create(It.Is<Task>(t => t == task)), Times.Never);
        }

        [Fact]
        public void DeleteTaskTest()
        {
            // ARRANGE
            var task = new Task()
            {
                Assignee = new Assignee(),
                Id = 1,
                Description = "Some description",
                DueDate = DateTime.Now,
                IsCompleted = false
            };

            var service = new TaskService(_TaskRepoMock.Object);

            // check if existing
            _TaskRepoMock.Setup(repo => repo.Get(It.Is<int>(t => t == task.Id))).Returns(() => task);

            // ACT
            var deletedTask = service.Delete(task);

            // ASSERT
            _TaskRepoMock.Verify(repo => repo.Delete(task), Times.Once);
            deletedTask.Should().BeNull();
        }

        [Fact]
        public void UpdateTaskWithValidInputTest()
        {
            // ARRANGE
            var task = new Task()
            {
                Assignee = new Assignee(),
                Id = 1,
                Description = "Some description",
                DueDate = DateTime.Now,
                IsCompleted = false
            };

            var service = new TaskService(_TaskRepoMock.Object);

            _TaskRepoMock.Setup(repo => repo.Get(It.Is<int>(z => z == task.Id))).Returns(() => task);

            // ACT
            var updatedTask = service.Update(task);

            // ASSERT
            _TaskRepoMock.Verify(repo => repo.Update(It.Is<Task>(t => t == task)), Times.Once);
        }

        [Fact]
        public void UpdateTaskWithInvalidInputTest()
        {
            // ARRANGE
            var task = new Task()
            {
                Description = null,
                Assignee = null,
                IsCompleted = false,
                DueDate = null
            };

            var service = new TaskService(_TaskRepoMock.Object);

            _TaskRepoMock.Setup(repo => repo.Get(It.Is<int>(z => z == task.Id))).Returns(() => task);

            // ACT
            var ex = Assert.Throws<InvalidOperationException>(() => service.Update(task));

            // ASSERT
            Assert.Equal("Invalid Task", ex.Message);
            _TaskRepoMock.Verify(repo => repo.Update(It.Is<Task>(t => t == task)), Times.Never);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void GetAllTasksTest(int listCount)
        {
            // ARRANGE
            var _tasks = new List<Task>()
            {
                new Task()
            {
                Assignee = new Assignee(),
                Id = 1,
                Description = "Some description",
                DueDate = DateTime.Now,
                IsCompleted = false
            },
            new Task()
            {
                Assignee = new Assignee(),
                Id = 2,
                Description = "Some description",
                DueDate = DateTime.Now,
                IsCompleted = false
            }
        };

            var service = new TaskService(_TaskRepoMock.Object);

            _TaskRepoMock.Setup(repo => repo.Read()).Returns(() => _tasks.GetRange(0, listCount));

            // ACT
            var tasksFound = service.Read();

            // ASSERT
            Assert.Equal(_tasks.GetRange(0, listCount), tasksFound);
            _TaskRepoMock.Verify(repo => repo.Read(), Times.Once);
        }
        #endregion

        #region ServiceTests

        [Fact]
        public void CreateAssigneeServiceWithValidRepositoryTest()
        {
            //Arrange
            var repo = _AssigneeRepoMock.Object;

            //Act
            var service = new AssigneeService(repo);

            //Assert
            Assert.NotNull(service);
        }

        [Fact]
        public void CreateAssigneeServiceWithInvalidRepositoryTest()
        {
            //Arrange
            IRepository<Assignee> repo = null;

            //Act
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                var service = new AssigneeService(repo);
            });

            //Assert
            Assert.Equal("Repository is missing", ex.Message);
        }

        #endregion

        #region AssigneeCRUDFunctionality
        [Fact]
        public void CreateAssigneeWithValidInputTest()
        {
            //Arrange
            var assignee = new Assignee()
            {
                Id = 1,
                Name = "John Doe"
            };

            var service = new AssigneeService(_AssigneeRepoMock.Object);

            _assignees = new List<Assignee>();

            //Act
            var newAssignee = service.Create(assignee);
            _assignees.Add(assignee);

            //Assert
            _AssigneeRepoMock.Setup(repo => repo.Create(assignee)).Returns(newAssignee);
            _AssigneeRepoMock.Verify(repo => repo.Create(assignee), Times.Once);
            _assignees.Should().Contain(assignee);
        }

        [Fact]
        public void CreateAssigneeWithInvalidInputTest()
        {
            //Arrange
            var assignee = new Assignee()
            {
                Id = 1,
                Name = null
            };

            var service = new AssigneeService(_AssigneeRepoMock.Object);

            //Act
            var ex = Assert.Throws<ArgumentException>(() => service.Create(assignee));

            //Assert
            Assert.Equal("Invalid Assignee", ex.Message);
            _AssigneeRepoMock.Verify(repo => repo.Create(It.Is<Assignee>(a => a == assignee)), Times.Never);
        }

        [Fact]
        public void DeleteAssigneeTest()
        {
            // ARRANGE
            var assignee = new Assignee()
            {
                Id = 1,
                Name = "John Doe"
            };

            var service = new AssigneeService(_AssigneeRepoMock.Object);

            // check if existing
            _AssigneeRepoMock.Setup(repo => repo.Get(It.Is<int>(t => t == assignee.Id))).Returns(() => assignee);

            // ACT
            var deletedTask = service.Delete(assignee);

            // ASSERT
            _AssigneeRepoMock.Verify(repo => repo.Delete(assignee), Times.Once);
            deletedTask.Should().BeNull();
        }

        [Fact]
        public void UpdateAssigneeWithValidInputTest()
        {
            // ARRANGE
            var assignee = new Assignee()
            {
                Id = 1,
                Name = "John Doe"
            };

            var service = new AssigneeService(_AssigneeRepoMock.Object);

            _AssigneeRepoMock.Setup(repo => repo.Get(It.Is<int>(z => z == assignee.Id))).Returns(() => assignee);

            // ACT
            var updatedAssignee = service.Update(assignee);

            // ASSERT
            _AssigneeRepoMock.Verify(repo => repo.Update(It.Is<Assignee>(a => a == assignee)), Times.Once);
        }

        [Fact]
        public void UpdateAssigneeWithInvalidInputTest()
        {
            // ARRANGE
            var assignee = new Assignee()
            {
                Id = 1,
                Name = ""
            };

            var service = new AssigneeService(_AssigneeRepoMock.Object);

            _AssigneeRepoMock.Setup(repo => repo.Get(It.Is<int>(z => z == assignee.Id))).Returns(() => assignee);

            // ACT
            var ex = Assert.Throws<ArgumentException>(() => service.Update(assignee));

            // ASSERT
            Assert.Equal("Invalid Assignee", ex.Message);
            _AssigneeRepoMock.Verify(repo => repo.Update(It.Is<Assignee>(a => a == assignee)), Times.Never);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void GetAllAssigneesTest(int listCount)
        {
            // ARRANGE
        var _assignees = new List<Assignee>()
        {
            new Assignee()
            {
                Id = 1,
                Name = "John Doe"
            },
            new Assignee()
            {
                Id = 1,
                Name = "John Doe"
            }
        };

            var service = new AssigneeService(_AssigneeRepoMock.Object);

            _AssigneeRepoMock.Setup(repo => repo.Read()).Returns(() => _assignees.GetRange(0, listCount));

            // ACT
            var assigneesFound = service.Read();

            // ASSERT
            Assert.Equal(_assignees.GetRange(0, listCount), assigneesFound);
            _AssigneeRepoMock.Verify(repo => repo.Read(), Times.Once);
        }
        #endregion
    }


}
