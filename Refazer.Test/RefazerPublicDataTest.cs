﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Refazer.Test
{
    [TestClass]
    public class RefazerPublicDataTest
    {
        [TestMethod]
        public void TestLearn1()
        {
            var before = "x = 0";
            var after = @"x = 1";
            TestUtils.AssertCorrectTransformation(before, after);
        }

        [TestMethod]
        public void TestLearn4()
        {
            var before = @"total = total * term(i)";
            var after = @"total = term(i)*total";
            TestUtils.AssertCorrectTransformation(before, after);
        }

        [TestMethod]
        public void TestLearn6()
        {

            var before = @"product = term(n)";
            var after = @"product = 1";
            TestUtils.AssertCorrectTransformation(before, after);
        }

        [TestMethod]
        public void TestLearn7()
        {
            var before = @"total *= i * term(i)";
            var after = @"total *= term(i)";
            TestUtils.AssertCorrectTransformation(before, after);
        }

        [TestMethod]
        public void TestLearn8()
        {
            var before = @"n >= 1";
            var after = @"n>1";
            TestUtils.AssertCorrectTransformation(before, after);
        }

        [TestMethod]
        public void TestLearn10()
        {
            var before = @"term(i)";
            var after = @"term(i+1)";
            TestUtils.AssertCorrectTransformation(before, after);
        }

        [TestMethod]
        public void TestLearn11()
        {
            var before = @"n, y = 0, 0";
            var after = @"n, y = 1, 0";
            TestUtils.AssertCorrectTransformation(before, after);
        }

        [TestMethod]
        public void TestLearn12()
        {
            var before = @"helper(0,n)";
            var after = @"helper(1, n)";
            TestUtils.AssertCorrectTransformation(before, after);
        }

        [TestMethod]
        public void TestLearnMultipleExamples1()
        {
            var examples = new List<Tuple<string, string>>();
            var before = @"i = 0";
            var after = @"i = 1";
            examples.Add(Tuple.Create(before, after));
            before = @"i, j = 0, 1";
            after = @"i, j = 1, 1";
            examples.Add(Tuple.Create(before, after));
            TestUtils.AssertCorrectTransformation(examples);
        }

    }
}
