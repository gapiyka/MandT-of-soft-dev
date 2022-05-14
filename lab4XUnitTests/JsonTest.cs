using System;
using lab4;
using Xunit;

namespace lab4XUnitTests
{
    public class JsonTest
    {
        [Fact]
        public void TestJsonSerialize()
        {
            //ARRANGE
            ulong number = 1;
            string caption = "Zaholovok";
            string description = "Opys v paru sliv, dlia perevirky";
            string deadlineStr = "2022-06-14-22-22";
            string expectedResult = "{\"number\":1,\"caption\":\"Zaholovok\",\"description\":\"Opys v paru sliv, dlia perevirky\",\"deadline\":\"2022-06-14T22:22:00\",\"taskStatus\":0}";

            //ACT
            var task = new Task(number, caption, description, deadlineStr);
            var resultStr = JSONS.TaskToJson(task);

            //ASSERT    
            Assert.Equal(expectedResult, resultStr);
        }

        [Fact]
        public void TestJsonDeserialize()
        {
            //ARRANGE
            ulong expectedNumber = 1;
            string expectedCaption = "Zaholovok";
            string expectedDescription = "Opys v paru sliv";
            DateTime expectedDeadline = new DateTime(2022, 06, 14, 22, 22, 00);
            TaskStatus expectedTaskStatus = TaskStatus.Done;
            string jsonString = "{ \"number\":1,\"caption\":\"Zaholovok\",\"description\":\"Opys v paru sliv\",\"deadline\":\"2022-06-14T22:22:00\",\"taskStatus\":1}";

            //ACT
            var result = JSONS.JsonToTask(jsonString);

            //ASSERT    
            Assert.Equal(expectedNumber, result.number);
            Assert.Equal(expectedCaption, result.caption);
            Assert.Equal(expectedDescription, result.description);
            Assert.Equal(expectedDeadline, result.deadline);
            Assert.Equal(expectedTaskStatus, result.taskStatus);
        }
    }
}
