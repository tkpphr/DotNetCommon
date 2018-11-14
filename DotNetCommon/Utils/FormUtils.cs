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
using System.Threading;
using System.Windows.Forms;

namespace DotNetCommon.Utils
{
	public static class FormUtils
	{
		public static bool SingleStart(string appName,Type formType)
		{
			if(!formType.IsSubclassOf(typeof(Form)))
			{
				Console.WriteLine("error:Type isn't Form class.\nApplication couldn't start.");
				return false;
			}
			string mutexName = appName;
			Mutex mutex = new Mutex(false, mutexName);
			bool hasHandle = false;
			try
			{
				try
				{
					hasHandle = mutex.WaitOne(0, false);
				}
				catch (AbandonedMutexException)
				{
					hasHandle = true;
				}
				if (!hasHandle)
				{
					return false;
				}
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(Activator.CreateInstance(formType) as Form);
				return true;
			}
			finally
			{
				if (hasHandle)
				{
					mutex.ReleaseMutex();
				}
				mutex.Close();
			}
		}


	}
}
