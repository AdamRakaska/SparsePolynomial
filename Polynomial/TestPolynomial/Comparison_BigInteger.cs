﻿using System;
using System.Numerics;
using PolynomialLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestPolynomial
{
	[TestClass]
	public class Comparison_BigInteger
	{
		private TestContext m_testContext;
		public TestContext TestContext { get { return m_testContext; } set { m_testContext = value; } }

		[TestMethod]
		public void TestEqual()
		{
			bool expected1 = true;
			bool expected2 = false;

			bool actual1 = GenericArithmetic<BigInteger>.Equal(7, 7);
			bool actual2 = GenericArithmetic<BigInteger>.Equal(3, 4);

			Assert.AreEqual(expected1, actual1);
			Assert.AreEqual(expected2, actual2);
		}

		[TestMethod]
		public void TestNotEqual()
		{
			bool expected1 = true;
			bool expected2 = false;

			bool actual1 = GenericArithmetic<BigInteger>.NotEqual(6, 7);
			bool actual2 = GenericArithmetic<BigInteger>.NotEqual(7, 7);

			Assert.AreEqual(expected1, actual1);
			Assert.AreEqual(expected2, actual2);
		}

		[TestMethod]
		public void TestGreaterThan()
		{
			bool expected1 = true;
			bool expected2 = false;

			bool actual1 = GenericArithmetic<BigInteger>.GreaterThan(7, 6);
			bool actual2 = GenericArithmetic<BigInteger>.GreaterThan(7, 8);

			Assert.AreEqual(expected1, actual1);
			Assert.AreEqual(expected2, actual2);
		}

		[TestMethod]
		public void TestLessThan()
		{
			bool expected1 = true;
			bool expected2 = false;

			bool actual1 = GenericArithmetic<BigInteger>.LessThan(7, 8);
			bool actual2 = GenericArithmetic<BigInteger>.LessThan(7, 6);

			Assert.AreEqual(expected1, actual1);
			Assert.AreEqual(expected2, actual2);
		}
	}
}