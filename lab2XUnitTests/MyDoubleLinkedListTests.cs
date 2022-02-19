using System;
using lab2;
using Xunit;

namespace lab2XUnitTests
{
    public class MyDoubleLinkedListTests
    {
        [Fact]
        public void TestListConstructor()
        {
            //ARRANGE
            int expectedSize = 0;

            //ACT
            var list = new MyDoubleLinkedList();
            var initializeResult = list.Length();
            var nullHeadPointer = list.GetHeadNode();
            var nullTailPointer = list.GetTailNode();

            //ASSERT    
            Assert.Equal(expectedSize, initializeResult);
            Assert.Null(nullHeadPointer);
            Assert.Null(nullTailPointer);
        }

        [Fact]
        public void TestListAppend_and_GetChar()
        {
            //ARRANGE
            int expectedSize = 1;
            int firstIndex = 0;
            char sharp = char.Parse("#");

            //ACT
            var list = new MyDoubleLinkedList();
            list.Append(sharp);
            var initializeResult = list.Length();
            var headPointer = list.GetHeadNode();
            var tailPointer = list.GetTailNode();
            var firstNodeChar = list.GetChar(firstIndex);
            var nullHeadNextPointer = list.GetHeadNode().Next;
            var nullHeadPrevPointer = list.GetHeadNode().Prev;
            var nullTailNextPointer = list.GetTailNode().Next;
            var nullTailPrevPointer = list.GetTailNode().Prev;

            //ASSERT    
            Assert.Equal(expectedSize, initializeResult);
            Assert.Equal(headPointer, tailPointer);
            Assert.Equal(sharp, firstNodeChar);
            Assert.Null(nullHeadNextPointer);
            Assert.Null(nullHeadPrevPointer);
            Assert.Null(nullTailNextPointer);
            Assert.Null(nullTailPrevPointer);
        }

        [Fact]
        public void FalledTest()
        {
            //ARRANGE
            int expectedSize = 1;
            char sharp = char.Parse("#");

            //ACT
            var list = new MyDoubleLinkedList();
            list.Append(sharp);
            list.Append(sharp);
            var initializeResult = list.Length();

            //ASSERT    
            Assert.Equal(expectedSize, initializeResult);
        }
    }
}
