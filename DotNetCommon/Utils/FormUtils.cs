
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
