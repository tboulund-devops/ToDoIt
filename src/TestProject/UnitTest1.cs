using BLL;
using DAL.Interfaces;
using Moq;
using System;
using BLL.Interfaces;
using FluentAssertions;
using Model;
using Xunit;

namespace TestProject
{
    public class UnitTest1
    {
        private void CheckPerformance(Action a, int ms)
        {
            DateTime start = DateTime.Now;
            a.Invoke();
            DateTime end = DateTime.Now;
            double time = (end - start).TotalMilliseconds;
            Assert.True(time <= ms);

        }
        [Fact]
        public void testValidAssigneeServiceIsCreated()
        {
            var AssigneeRepositoryMock = new Mock<IAssigneeRepository>();
            Action action = () => new AssigneeService(AssigneeRepositoryMock.Object).Should().NotBe(null);

        }

        [Fact]
        public void ReadAll_withNegativeId_ShouldThrowExeption_Once()
        {
            //arrange
            var assigneeRepositoryMock = new Mock<IAssigneeRepository>();
           IAssigneeService service = new AssigneeService(assigneeRepositoryMock.Object);
           Assignee mockAssignee = new Assignee() {Id = -1};
            //assign
            assigneeRepositoryMock.Setup(rm => rm.ReadAll(-1));
            service.ReadAll(-1);
            //assert
           assigneeRepositoryMock.Verify(rm => rm.ReadAll(-1), Times.Once);


        }


        [Fact]
        public void ReadAll_ShouldMatchReadAllInRepository_Once()
        {
            //arrange
            var AssigneeRepositoryMock = new Mock<IAssigneeRepository>();
            IAssigneeService service = new AssigneeService(AssigneeRepositoryMock.Object);
            //assign
            AssigneeRepositoryMock.Setup(r => r.ReadAll(50));
            service.ReadAll(50);
            //assert
            AssigneeRepositoryMock.Verify(r => r.ReadAll(50), Times.Once());
            CheckPerformance(() => service.ReadAll(50), 1000);
        }
        [Fact]
        public void Delete_ShouldCallDeleteMethodInRepository_withParamAsId_Once()
        {
            //arrange
            var assigneeRepositoryMock = new Mock<IAssigneeRepository>();
           
            IAssigneeService service = new AssigneeService(assigneeRepositoryMock.Object);
            //act
            var deletedAssignee = new Assignee() {Id = 3, Name = "" };
          assigneeRepositoryMock.Setup(r => r.DeleteAssignee(3)).Returns(() => deletedAssignee);
            service.DeleteAssignee(3);
            //assert
           assigneeRepositoryMock.Verify(r => r.DeleteAssignee(3), Times.Once());
            CheckPerformance(() => service.DeleteAssignee(3), 1000);
        }
    }
}
