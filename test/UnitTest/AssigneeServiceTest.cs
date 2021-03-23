
using DAL.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.Interfaces;
using Xunit;

namespace UnitTest
{
    public class AssigneeServiceTest
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
    }
}
