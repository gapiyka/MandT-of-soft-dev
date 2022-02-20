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

        /*[Fact]
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
           }*/

        [Fact]
        public void TestListInsert()
        {
            //ARRANGE
            int expectedSize = 4;
            string str = "Mail";
            char changingChar = char.Parse("0");

            //ACT
            var list = new MyDoubleLinkedList();
            list.Append(str[0]);
            list.Append(str[1]);
            list.Append(str[2]);
            list.Append(str[3]);
            var tempSecondChar = list.GetChar(1);
            var tempThirdChar = list.GetChar(2);
            list.Insert(changingChar, 1);
            list.Insert(changingChar, 2);
            var insertedCharFromHeadNode = list.GetHeadNode().Next.Character;
            var sizeResult = list.Length();
            var secondChar = list.GetChar(1);
            var thirdChar = list.GetChar(2);

            //ASSERT    
            Assert.Equal(expectedSize, sizeResult);
            Assert.Equal(char.Parse("a"), tempSecondChar);
            Assert.Equal(char.Parse("i"), tempThirdChar);
            Assert.Equal(changingChar, secondChar);
            Assert.Equal(changingChar, thirdChar);
            Assert.Equal(changingChar, insertedCharFromHeadNode);
        }

        [Fact]
        public void TestListDelete()
        {
            //ARRANGE
            int expectedSize = 3;
            string str = "Stop";

            //ACT
            var list = new MyDoubleLinkedList();
            list.Append(str[0]);
            list.Append(str[1]);
            list.Append(str[2]);
            list.Append(str[3]);
            var tempFirstChar = list.GetChar(0);
            list.Delete(0);
            var newCharFromHeadNode = list.GetHeadNode().Character;
            var secondChar = list.GetChar(1);
            var thirdChar = list.GetChar(2);
            var sizeResult = list.Length();

            //ASSERT    
            Assert.Equal(expectedSize, sizeResult);
            Assert.Equal(str[0], tempFirstChar);
            Assert.Equal(str[1], newCharFromHeadNode);
            Assert.Equal(str[2], secondChar);
            Assert.Equal(str[3], thirdChar);
        }

        [Fact]
        public void TestListDeleteAll()
        {
            //ARRANGE
            int expectedSize = 2;
            string str = "Mama";
            char removeChar = char.Parse("a");

            //ACT
            var list = new MyDoubleLinkedList();
            list.Append(str[0]);
            list.Append(str[1]);
            list.Append(str[2]);
            list.Append(str[3]);
            list.DeleteAll(removeChar);
            var firstChar = list.GetChar(0);
            var secondChar = list.GetChar(1);
            var sizeResult = list.Length();

            //ASSERT    
            Assert.Equal(expectedSize, sizeResult);
            Assert.Equal(str[0], firstChar);
            Assert.Equal(str[2], secondChar);
        }

        [Fact]
        public void TestListClone()
        {
            //ARRANGE
            int expectedSize = 3;
            string str = "DUP";

            //ACT
            var list = new MyDoubleLinkedList();
            list.Append(str[0]);
            list.Append(str[1]);
            list.Append(str[2]);
            var firstListChar1 = list.GetChar(0);
            var firstListChar2 = list.GetChar(1);
            var firstListChar3 = list.GetChar(2);
            var cloneList = list.Clone();
            var secondListChar1 = cloneList.GetChar(0);
            var secondListChar2 = cloneList.GetChar(1);
            var secondListChar3 = cloneList.GetChar(2);
            var sizeResult = cloneList.Length();

            //ASSERT    
            Assert.Equal(expectedSize, sizeResult);
            Assert.Equal(str[0], firstListChar1);
            Assert.Equal(str[0], secondListChar1);
            Assert.Equal(str[1], firstListChar2);
            Assert.Equal(str[1], secondListChar2);
            Assert.Equal(str[2], firstListChar3);
            Assert.Equal(str[2], secondListChar3);

        }

        [Fact]
        public void TestListReverse()
        {
            //ARRANGE
            int expectedSize = 3;
            string str = "DUP";

            //ACT
            var list = new MyDoubleLinkedList();
            list.Append(str[0]);
            list.Append(str[1]);
            list.Append(str[2]);
            var firstListChar1 = list.GetChar(0);
            var firstListChar2 = list.GetChar(1);
            var firstListChar3 = list.GetChar(2);
            list.Reverse();
            var secondListChar1 = list.GetChar(0);
            var secondListChar2 = list.GetChar(1);
            var secondListChar3 = list.GetChar(2);
            var sizeResult = list.Length();

            //ASSERT    
            Assert.Equal(expectedSize, sizeResult);
            Assert.Equal(str[0], firstListChar1);
            Assert.Equal(str[0], secondListChar3);
            Assert.Equal(str[1], firstListChar2);
            Assert.Equal(str[1], secondListChar2);
            Assert.Equal(str[2], firstListChar3);
            Assert.Equal(str[2], secondListChar1);

        }

        [Fact]
        public void TestListFindFirstAndFindLast()
        {
            //ARRANGE
            int expectedSize = 6;
            int expectedFirstIndex = 1;
            int expectedLastIndex = 4;
            string str = "baobab";

            //ACT
            var list = new MyDoubleLinkedList();
            foreach(char iChar in str)
            {
                list.Append(iChar);
            }
            var firstFindA = list.FindFirst(char.Parse("a"));
            var lastFindA = list.FindLast(char.Parse("a"));
            var sizeResult = list.Length();

            //ASSERT    
            Assert.Equal(expectedSize, sizeResult);
            Assert.Equal(expectedFirstIndex, firstFindA);
            Assert.Equal(expectedLastIndex, lastFindA);
        }

        [Fact]
        public void TestListClear()
        {
            //ARRANGE
            int expectedSize = 6;
            int expectedSizeClear = 0;
            string str = "baobab";

            //ACT
            var list = new MyDoubleLinkedList();
            foreach(char iChar in str)
            {
                list.Append(iChar);
            }
            var sizeResult = list.Length();
            list.Clear();
            var sizeResultClear = list.Length();
            var nullHeadNode = list.GetHeadNode();
            var nullTailNode = list.GetHeadNode();

            //ASSERT    
            Assert.Equal(expectedSize, sizeResult);
            Assert.Equal(expectedSizeClear, sizeResultClear);
            Assert.Null(nullHeadNode);
            Assert.Null(nullTailNode);
        }

        [Fact]
        public void TestListExtend()
        {
            //ARRANGE
            int expectedSize = 4;
            int expectedSizeExtend = 5;
            string str = "Hello";

            //ACT
            var list = new MyDoubleLinkedList();
            var subList = new MyDoubleLinkedList();
            list.Append(str[0]);
            list.Append(str[1]);
            list.Append(str[2]);
            list.Append(str[3]);
            subList.Append(str[4]);
            var sizeResult = list.Length();
            var firstTail = list.GetTailNode().Character;
            list.Extend(subList);
            var sizeResultExtend = list.Length();
            var newTail = list.GetTailNode().Character;

            //ASSERT    
            Assert.Equal(expectedSize, sizeResult);
            Assert.Equal(expectedSizeExtend, sizeResultExtend);
            Assert.Equal(str[3], firstTail);
            Assert.Equal(str[4], newTail);

        }
    }
}
