using System;
using lab4;
using Xunit;

namespace lab4XUnitTests
{
    public class TaskTest
    {
        [Fact]
        public void TestTaskConstructor()
        {
            //ARRANGE
            ulong number = 2;
            string caption = "Zaholovok";
            string description = "Opys v paru sliv, dlia perevirky";
            string deadlineStr = "2022-05-14-22-11";
            DateTime deadlineExpected = new DateTime(2022, 05, 14, 22, 11, 00);
            TaskStatus taskStatus = TaskStatus.Active;

            //ACT
            var task = new Task(number, caption, description, deadlineStr);

            //ASSERT    
            Assert.Equal(number, task.number);
            Assert.Equal(deadlineExpected, task.deadline);
            Assert.Equal(caption, task.caption);
            Assert.Equal(description, task.description);
            Assert.Equal(taskStatus, task.taskStatus);
        }

        [Fact]
        public void TestTaskConstructor2()
        {
            //ARRANGE
            ulong number = 22;
            string caption = "Zaholovok2";
            string description = "Opys v paru sliv, dlia perevirky";
            DateTime deadlineExpected = new DateTime(2022, 04, 14, 22, 11, 00);
            TaskStatus taskStatus = TaskStatus.Overdue;

            //ACT
            var task = new Task(number, caption, description, deadlineExpected, taskStatus);

            //ASSERT
            Assert.Equal(number, task.number);
            Assert.Equal(deadlineExpected, task.deadline);
            Assert.Equal(caption, task.caption);
            Assert.Equal(description, task.description);
            Assert.Equal(taskStatus, task.taskStatus);
        }
    }
}
