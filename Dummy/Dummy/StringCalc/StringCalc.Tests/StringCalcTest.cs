using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc.Tests
{
	[TestFixture]
    public class StringCalcTest
    {
		[Test]
		public void EmptyStringEqualsZero()
		{
			//arrange
			var calculator = new StringCalc();
			//act
			int res = calculator.Add("");
			//assert
			Assert.AreEqual(0, res);
		}
		[Test]
		public void SingleStringEqualsNumber()
		{
			//arrange
			var calculator = new StringCalc();
			//act
			int res = calculator.Add("2");
			//assert
			Assert.AreEqual(2, res);
		}
		[Test]
		public void NumberPlusNumberEqualsAnotherNumber()
		{
			//arrange
			var calculator = new StringCalc();
			//act
			calculator.Parse("3,2");
			int res = calculator.Add("3,2");
			//assert
			Assert.AreEqual(5, res);
		}
    }
}
