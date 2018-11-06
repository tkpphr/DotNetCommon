﻿using System;
using System.Drawing;

namespace DotNetCommon.Utils
{
	public static class MathUtils
	{
		public static T Clamp<T>(T val, T min, T max)
			where T : IComparable<T>
		{
			if (min.CompareTo(max) > 0)
			{
				throw new ArgumentOutOfRangeException("max", "max must be greater than min");
			}
			if (min.CompareTo(val) > 0)
			{
				return min;
			}
			if(val.CompareTo(max) > 0)
			{
				return max;
			}
			return val;
		}

		public static int Gcd(int val1, int val2)
		{
			
			if (val1 < val2)
			{
				val1 += val2;
				val2 = val1 - val2;
				val1 -= val2;
			}
			int temp = val1 % val2;
			while (temp != 0)
			{
				val1 = val2;
				val2 = temp;
				temp = val1 % val2;
			}
			return val2;
		}

		public static Point AspectRatio(int width, int height)
		{
			int gcd = Gcd(width, height);
			return new Point(width / gcd, height / gcd);
		}
	}
}
