using Helper;
using HotelManager.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace HotelManager
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
		protected override void OnStartup(StartupEventArgs e)
		{

			// 定义应用程序启动时要处理的内容 
			if (MyFileHelper.IsExistFile(XmlHelper.PersonXmlPath))
			{
				MyFileHelper.ClearFile(XmlHelper.PersonXmlPath);
			}
			else
			{
				MyFileHelper.CreateFileContent(XmlHelper.PersonXmlPath, "");
			}

			if (!MyFileHelper.IsExistFile(FileHelper.dbpath))
			{
				if (!MyFileHelper.IsExistDirectory(FileHelper.dbfilepath))
				{
					MyFileHelper.CreateDirectory(FileHelper.dbfilepath);
				}
				bool result = MyFileHelper.CopyFile(FileHelper.sourcedbpath, FileHelper.dbpath);
			}
		}
		private static DispatcherOperationCallback exitFrameCallback = new DispatcherOperationCallback(ExitFrame);
		public static void DoEvents()
		{
			DispatcherFrame nestedFrame = new DispatcherFrame();
			DispatcherOperation exitOperation = Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, exitFrameCallback, nestedFrame);
			Dispatcher.PushFrame(nestedFrame);
			if (exitOperation.Status !=
			DispatcherOperationStatus.Completed)
			{
				exitOperation.Abort();
			}
		}

		private static Object ExitFrame(Object state)
		{
			DispatcherFrame frame = state as
			DispatcherFrame;
			frame.Continue = false;
			return null;
		}
	}
}
