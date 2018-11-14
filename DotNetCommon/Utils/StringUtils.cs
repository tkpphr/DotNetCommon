/*
Copyright 2018 tkpphr

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
using System;

namespace DotNetCommon.Utils
{
	public static class StringUtils
	{

		public static string EllipsisLeft(this string str, int len)
		{
			if (str.Length > len)
			{
				return len <= 0 ? "..." : "..." + str.Substring(str.Length - len);
			}
			else
			{
				return str;
			}
		}

		public static string EllipsisRight(this string str, int len)
		{
			if (str.Length > len)
			{
				return len <= 0 ? "..." : str.Substring(0,len) + "...";
			}
			else
			{
				return str;
			}
		}

		public static string EllipsisBySeparator(this string str,string separator, int depth)
		{
			if (depth == 0)
			{
				return str;
			}
			string[] split = str.Split(new string[]{ separator },StringSplitOptions.None);
			int length = split.Length;
			if (length <= depth + 2)
			{
				return str;
			}
			else
			{
				string ellipsizedPath = split[0] + separator +"...";
				for (int i = length - depth; i < length; i++)
				{
					ellipsizedPath += separator+split[i];
				}
				return ellipsizedPath;
			}
		}

		
	}
}
