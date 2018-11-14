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
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace DotNetCommon.Utils
{
	public class ImageUtils
	{

		public static Image CreateImage(string filePath)
		{
			if (File.Exists(filePath))
			{
				return Image.FromFile(filePath);
			}
			else
			{
				return null;
			}
		}

		public static Image CreateImage(byte[] data)
		{
			if (data==null)
			{
				return null;
			}
			else
			{
				using (var memoryStrean=new MemoryStream(data)) {
					try
					{
						return Image.FromStream(memoryStrean);
					}
					catch(ArgumentException e)
					{
						Console.WriteLine(e);
						return null;
					}
				}
			}
		}

		public static Image CompressedImage(Image src, ImageFormat format, long quality)
		{
			return CreateImage(CompressedData(src,format,quality));
		}

		public static byte[] CompressedData(Image src,ImageFormat format,long quality)
		{
			var bitmap = src as Image;
			if (bitmap==null)
			{
				return null;
			}
			var encoder = ImageCodecInfo.GetImageEncoders()
								.Where(codec => codec.FormatID == format.Guid)
								.SingleOrDefault();
			var encoderParameter = new EncoderParameter(Encoder.Quality,quality);
			var encoderParameters = new EncoderParameters(1);
			encoderParameters.Param[0] = encoderParameter;
			using (var memoryStream=new MemoryStream())
			{
				try
				{
					bitmap.Save(memoryStream, encoder,encoderParameters);
					memoryStream.Position = 0;
					byte[] data = new byte[memoryStream.Length];
					memoryStream.Read(data, 0, data.Length);
					return data;
				}
				catch(Exception e)
				{
					Console.WriteLine(e);
					return null;
				}
			}
		}
	}
}
