using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DotNetCommon.Utils;

namespace DotNetCommon.Test
{
	[TestFixture]
	class MathUtilsTest
	{

		[TestCase(0,0,-1,1)]
		[TestCase(1, 1, -1,1)]
		[TestCase(1, 2, -1, 1)]
		[TestCase(-1, -2, -1, 1)]
		public void TestClamp<T>(int expected,T val,T min,T max) where T : IComparable<T>
		{
			Assert.AreEqual(expected, MathUtils.Clamp(val, min, max));
		}

		[TestCase(-2, 1, -1)]
		public void TestClampThrows<T>(T val, T min, T max) where T : IComparable<T>
		{
			var exception = Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(() => MathUtils.Clamp(val, min, max)));
			Assert.That(exception is ArgumentOutOfRangeException);
		}


		[TestCase(1,1,2)]
		[TestCase(1,5,1)]
		[TestCase(4,12,16)]
		[TestCase(8,32,24)]
		[TestCase(12, 12, 36)]
		[TestCase(15,30,75)]
		[TestCase(25,225,100)]
		[TestCase(100, 400, 300)]
		public void TestGcd(int expected,int val1, int val2)
		{
			Assert.AreEqual(expected,MathUtils.Gcd(val1, val2));
		}

		[TestCase(4,3, 640, 480)]
		[TestCase(16,9, 1920, 1080)]
		[TestCase(3, 4, 480,640)]
		[TestCase(9, 16, 1080,1920)]
		public void TestAspectRatio(int expectedX,int expectedY, int val1, int val2)
		{
			var aspectRatio = MathUtils.AspectRatio(val1, val2);
			Assert.AreEqual(expectedX, aspectRatio.X);
			Assert.AreEqual(expectedY, aspectRatio.Y);
		}
	}
}
