using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ConsoleApp1;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        //2
        [Test]
        public void Test_RecurMaxFinder_aboveZero()
        {
            int[] array = { 0, 7, 1, 10 };
            int answer = Program.RecurMaxFinder(array);
            int realAnswer = 10;
            if (answer == realAnswer)
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void Test_RecurMaxFinder_belowZero()
        {
            int[] array = { -2, -1, -90, -10 };
            int answer = Program.RecurMaxFinder(array);
            int realAnswer = -1;
            if (answer == realAnswer)
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void Test_RecurMaxFinder_belowZero_with_zero()
        {
            int[] array = { -23, -11, 0, -1 };
            int answer = Program.RecurMaxFinder(array);
            int realAnswer = 0;
            if (answer == realAnswer)
                Assert.Pass();
            else
                Assert.Fail();
        }

        //3
        [Test]
        public void Test1_EqualSum()
        {
            double[] array = { 0, 1, 2, 3 };
            int answer = Program.EqualSum(array);
            int realAnswer = -1;
            if (answer == realAnswer)
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void Test2_EqualSum()
        {
            double[] array = { 11.902, 10.312, 420.120 };
            int answer = Program.EqualSum(array);
            int realAnswer = -1;
            if (answer == realAnswer)
                Assert.Pass();
            else
                Assert.Fail();
        }

        //4
        [Test]
        public void Test1_Concat()
        {
            if (Program.Concat("hello", "world!") == "helo wrd!")
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void Test2_Concat()
        {
            if (Program.Concat("hello   ", "    helloworld! ") == "helo wrd!")
                Assert.Pass();
            else
                Assert.Fail();
        }

        //5
        public bool TestCase(int num, int expected)
        {
            int answer = Program.FindNextBiggerNumber(num);
            if (answer == expected)
                return true;
            else
                return false;
        }

        [Test]
        public void Test_FindNextBiggerNumber()
        {
            if (TestCase(3456432, 3462345) && TestCase(10, -1) && TestCase(12, 21))
                Assert.Pass();
            else
                Assert.Fail();
        }

        //6
        [Test]
        public void Test_FilterDigit()
        {
            int[] array = { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            List<int> answer = Program.FilterDigit(7, array);
            List<int> realAnswer = new List<int> { 7, 7, 70, 17 };
            
            if (answer.SequenceEqual(realAnswer))
                Assert.Pass();
            else
                Assert.Fail();
        }
    }
}