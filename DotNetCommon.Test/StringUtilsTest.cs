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
    public class StringUtilsTest
    {

		[Test]
		public void TestEllipsisBySeparator()
		{
			string path = "C:\\Folder\\Folder\\Folder\\Folder\\Folder\\Folder\\File";
			Assert.AreEqual(path, path.EllipsisBySeparator("\\", 0));
			Assert.AreEqual("C:\\...\\File", path.EllipsisBySeparator("\\",1));
			Assert.AreEqual("C:\\...\\Folder\\File", path.EllipsisBySeparator("\\", 2));
			Assert.AreEqual("C:\\...\\Folder\\Folder\\File", path.EllipsisBySeparator("\\", 3));
			Assert.AreEqual("C:\\...\\Folder\\Folder\\Folder\\File", path.EllipsisBySeparator("\\", 4));
			Assert.AreEqual("C:\\...\\Folder\\Folder\\Folder\\Folder\\File", path.EllipsisBySeparator("\\", 5));
			Assert.AreEqual("C:\\Folder\\Folder\\Folder\\Folder\\Folder\\Folder\\File", path.EllipsisBySeparator("\\", 6));
			Assert.AreEqual("C:\\Folder\\Folder\\Folder\\Folder\\Folder\\Folder\\File", path.EllipsisBySeparator("\\", 7));
			Assert.AreEqual("C:\\Folder\\Folder\\Folder\\Folder\\Folder\\Folder\\File", path.EllipsisBySeparator("\\", 8));
		}

		[Test]
		public void TestEllipsisLeft()
		{
			string text = "123456789abcdef";
			Assert.AreEqual("123456789abcdef", text.EllipsisLeft(15));
			Assert.AreEqual("...6789abcdef", text.EllipsisLeft(10));
			Assert.AreEqual("...bcdef", text.EllipsisLeft(5));
			Assert.AreEqual("...",text.EllipsisLeft(0));
		}

		[Test]
		public void TestEllipsisRight()
		{
			string text = "123456789abcdef";
			Assert.AreEqual("123456789abcdef", text.EllipsisRight(15));
			Assert.AreEqual("123456789a...", text.EllipsisRight(10));
			Assert.AreEqual("12345...", text.EllipsisRight(5));
			Assert.AreEqual("...", text.EllipsisRight(0));
		}
	}
}
