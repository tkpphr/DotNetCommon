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
