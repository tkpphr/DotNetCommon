using System;
using System.IO;
using System.Media;

namespace DotNetCommon.Media.Sound
{
	public class DotNetSound : IDisposable
	{
		private SoundPlayer SoundPlayer { get; set; }

		public DotNetSound(string soundLocation)
		{
			SoundPlayer = new SoundPlayer(soundLocation);
		}

		public DotNetSound(Stream stream)
		{
			SoundPlayer = new SoundPlayer(stream);
		}

		public void Dispose()
		{
			SoundPlayer.Dispose();
		}

		public void Play()
		{
			SoundPlayer.Play();
		}

		public void PlaySync()
		{
			SoundPlayer.PlaySync();
		}

		public void PlayLoop()
		{
			SoundPlayer.PlayLooping();
		}

		public void Stop()
		{
			SoundPlayer.Stop();
		}
	}
}
