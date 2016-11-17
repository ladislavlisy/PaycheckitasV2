using NUnit.Framework;
using System;
using Paycheckitas.Common.Core;

namespace Paycheckitas.Tests.Common
{
	[TestFixture()]
	public class TestPeriod
	{
		UInt32 testPeriodCodeJan = 201401u;
		UInt32 testPeriodCodeFeb = 201402u;
		UInt32 testPeriodCode501 = 201501u;
		UInt32 testPeriodCode402 = 201402u;

		[Test]
		public void Should_Compare_Different_Periods_AsEqual_When_2014_01()
		{
			Period testPeriodOne = new Period(testPeriodCodeJan);

			Period testPeriodTwo = new Period(testPeriodCodeJan);

			Assert.AreEqual(testPeriodOne, testPeriodTwo);
		}
		[Test]
		public void Should_Compare_Different_Periods_AsEqual_When_2014_02()
		{
			Period testPeriodOne = new Period(testPeriodCodeFeb);

			Period testPeriodTwo = new Period(testPeriodCodeFeb);

			Assert.AreEqual(testPeriodOne, testPeriodTwo);
		}
		[Test]
		public void Should_Compare_Different_Periods_SameYear_AsGreater()
		{
			Period testPeriodOne = new Period(testPeriodCodeJan);

			Period testPeriodTwo = new Period(testPeriodCodeFeb);

			Assert.AreNotEqual(testPeriodTwo, testPeriodOne);

			Assert.Greater(testPeriodTwo, testPeriodOne);
		}
		[Test]
		public void Should_Compare_Different_Periods_SameYear_AsLess()
		{
			Period testPeriodOne = new Period(testPeriodCodeJan);

			Period testPeriodTwo = new Period(testPeriodCodeFeb);

			Assert.AreNotEqual(testPeriodOne, testPeriodTwo);

			Assert.Less(testPeriodOne, testPeriodTwo);
		}
		[Test]
		public void Should_Compare_Different_Periods_SameMonth_AsGreater()
		{
			Period testPeriodOne = new Period(testPeriodCodeJan);

			Period testPeriodTwo = new Period(testPeriodCode501);

			Assert.AreNotEqual(testPeriodTwo, testPeriodOne);

			Assert.Greater(testPeriodTwo, testPeriodOne);
		}
		[Test]
		public void Should_Compare_Different_Periods_SameMonth_AsLess()
		{
			Period testPeriodOne = new Period(testPeriodCodeJan);

			Period testPeriodTwo = new Period(testPeriodCode501);

			Assert.AreNotEqual(testPeriodOne, testPeriodTwo);

			Assert.Less(testPeriodOne, testPeriodTwo);
		}
		[Test]
		public void Should_Compare_Different_Periods_DifferentYear_AsGreater()
		{
			Period testPeriodOne = new Period(testPeriodCode402);

			Period testPeriodTwo = new Period(testPeriodCode501);

			Assert.AreNotEqual(testPeriodTwo, testPeriodOne);

			Assert.Greater(testPeriodTwo, testPeriodOne);
		}
		[Test]
		public void Should_Compare_Different_Periods_DifferentYear_AsLess()
		{
			Period testPeriodOne = new Period(testPeriodCode402);

			Period testPeriodTwo = new Period(testPeriodCode501);

			Assert.AreNotEqual(testPeriodOne, testPeriodTwo);

			Assert.Less(testPeriodOne, testPeriodTwo);
		}
		[Test]
		public void Should_Return_Periods_Year_And_Month_2014_01()
		{
			Period testPeriodOne = new Period(testPeriodCodeJan);

			Assert.AreEqual(testPeriodOne.Year, 2014);
			Assert.AreEqual(testPeriodOne.Month, 1);
		}
		[Test]
		public void Should_Return_Periods_Year_And_Month_2014_02()
		{
			Period testPeriodTwo = new Period(testPeriodCodeFeb);

			Assert.AreEqual(testPeriodTwo.Year, 2014);
			Assert.AreEqual(testPeriodTwo.Month, 2);
		}
		[Test]
		public void Should_Return_Periods_Month_And_Year_Description()
		{
			Period testPeriodJan = new Period(testPeriodCodeJan);
			Period testPeriodFeb = new Period(testPeriodCodeFeb);
			Period testPeriod501 = new Period(testPeriodCode501);
			Period testPeriod402 = new Period(testPeriodCode402);

			Assert.AreEqual(testPeriodJan.DescriptionEn(), "January 2014");
			Assert.AreEqual(testPeriodFeb.DescriptionEn(), "February 2014");
			Assert.AreEqual(testPeriod501.DescriptionEn(), "January 2015");
			Assert.AreEqual(testPeriod402.DescriptionEn(), "February 2014");
		}
	}
}
