using System;
using System.Windows.Forms;

namespace Weather.WinForm
{
	public class DynamicClass
	{
		public string Name = "DynamicClass";
		
		public DynamicClass()
		{
			MessageBox.Show("Example", "Info", MessageBoxButtons.OK);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using Weather.WinForm;

namespace Weather.WinForm
{
	public class DynamicClass
	{		
		public DynamicClass()
		{
			try
			{				
				List<Assembly> assembliesLoadedBefore = AppDomain.CurrentDomain.GetAssemblies().ToList<Assembly>();
				
				string all = string.Empty;
				
				foreach(var assembly in assembliesLoadedBefore)
				{
					all += assembly.FullName + "\n\n";
				}
				
				MessageBox.Show(all, "Info", MessageBoxButtons.OK);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
			}
		}
	}
}

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Policy;

using Weather.WinForm;

namespace Weather.WinForm
{
	public class DynamicClass
	{		
		public DynamicClass()
		{
			try
			{
				AppDomain currentDomain = AppDomain.CurrentDomain;
				
				Evidence asEvidence = currentDomain.Evidence;
				
				currentDomain.Load("DynamicClass", asEvidence);
				
				MessageBox.Show("Test", "Info", MessageBoxButtons.OK);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
			}
		}
	}
}

using System;

using Weather.WinForm;

public class Test
{
	public Test()
	{
		var name = "dynamic";
		
		var weather = Weather();
	}
}

using System;
using System.Windows.Forms;
using System.Drawing;

public class MyForm
{
    public MyForm()
    {
		Form myFrm = new Form();
        myFrm.ClientSize = new System.Drawing.Size(350, 450);
        myFrm.Text = "My First Windows Application";
        myFrm.ResumeLayout(false);
		myFrm.Show();
    }
}

public class Hello
{
	public string Name = "UWP";
}

public class Hello
{
	public string[] data = {"Hello", "UWP"};
}

using System;
using Weather.WinForm;

namespace Weather.WinForm
{
	public class DynamicClass
	{
		public DynamicClass()
		{
			var homeForm = new HomeForm();
			homeForm.Show();
		}
	}	
}

using System;
using Weather.WinForm;

namespace Weather.WinForm
{
	public class DynamicClass
	{
		public DynamicClass(HomeForm homeForm, int index)
		{
			homeForm.ChangeCities(index);
		}
	}	
}


using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using System.Windows.Forms;

namespace UWPAPITest
{
	public class UWPAPITestClass
	{
		public UWPAPITestClass()
		{
			MessageBox.Show("Inside Dynamic Code 1", "Started", MessageBoxButtons.OK);
			ShowUWPMessageDialog();
			MessageBox.Show("Inside Dynamic Code 2", "Started", MessageBoxButtons.OK);
		}
		
		public void ShowUWPMessageDialog()
		{
			var messageDialog = new MessageDialog("No internet connection has been found.");
			messageDialog.ShowAsync();
		}
	}
}


namespace User
{
	public class UserInfo
	{
		public static string GetName()
		{
			return "iLink Systems";
		}
	}
}

using User;
using System.Windows.Forms;

public class Test
{	
	public void TestMethod()
	{
		var userInfo = new UserInfo();
		MessageBox.Show("Name : " + userInfo.GetName());
	}
}

using User;
using System;

public class TestConsole
{
	public static void Main(string[] args)
	{
		Console.WriteLine("Name : " + UserInfo.Name);
		Console.ReadKey();
	}
}

using User;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WFA
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
			this.Text = UserInfo.GetName();
            this.BackColor = Color.Brown;
            this.Size = new Size(350, 125);
            this.Location = new Point(300, 300);
            this.MaximizeBox = false;
			
            Show();
        }
    }
}

using Calculator;
using System;

public class InvokeCalculator
{
	public InvokeCalculator()
	{
		new Calculator.Calculator().Show();
	}
}


using System;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

public class UWPToastExample
{
	public UWPToastExample()
	{
		ShowToastNotification("1", "Hello");
	}
	
	private void ShowToastNotification(string title, string stringContent)
	{
		ToastNotifier ToastNotifier = ToastNotificationManager.CreateToastNotifier();
		Windows.Data.Xml.Dom.XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
		Windows.Data.Xml.Dom.XmlNodeList toastNodeList = toastXml.GetElementsByTagName("text");
		toastNodeList.Item(0).AppendChild(toastXml.CreateTextNode(title));
		toastNodeList.Item(1).AppendChild(toastXml.CreateTextNode(stringContent));
		Windows.Data.Xml.Dom.IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
		Windows.Data.Xml.Dom.XmlElement audio = toastXml.CreateElement("audio");
		audio.SetAttribute("src", "ms-winsoundevent:Notification.SMS");

		ToastNotification toast = new ToastNotification(toastXml);
		toast.ExpirationTime = DateTime.Now.AddSeconds(4);
		ToastNotifier.Show(toast);
	}
}

using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

public class UWPMessageDialog
{
	public UWPMessageDialog()
	{
		ShowDialog();
	}
	
	private async void ShowDialog()
	{
		MessageDialog showDialog = new MessageDialog("Hi Welcome to Windows 10");  
		
		var result = await showDialog.ShowAsync();  
	}
}

using System;
using Windows.UI.Popups;

namespace UWPAPITest
{
	public class UWPAPITestClass
	{
		public UWPAPITestClass()
		{
			ShowUWPMessageDialog();
		}
		
		public async void ShowUWPMessageDialog()
		{
			var messageDialog = new MessageDialog("No internet connection has been found.");
			messageDialog.ShowAsync();
		}
	}
}

using System;
using Windows.UI.Core;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

public class MyPage : Page
{
	public MyPage()
	{
		DoNavigate();
	}
	
	void DoNavigate()
	{
		Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
		{
			ShowToastNotification("1", "Hello");
			this.Frame.Navigate(typeof(MyPage));        
		});
	}
	
	private void ShowToastNotification(string title, string stringContent)
	{
		ToastNotifier ToastNotifier = ToastNotificationManager.CreateToastNotifier();
		Windows.Data.Xml.Dom.XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
		Windows.Data.Xml.Dom.XmlNodeList toastNodeList = toastXml.GetElementsByTagName("text");
		toastNodeList.Item(0).AppendChild(toastXml.CreateTextNode(title));
		toastNodeList.Item(1).AppendChild(toastXml.CreateTextNode(stringContent));
		Windows.Data.Xml.Dom.IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
		Windows.Data.Xml.Dom.XmlElement audio = toastXml.CreateElement("audio");
		audio.SetAttribute("src", "ms-winsoundevent:Notification.SMS");

		ToastNotification toast = new ToastNotification(toastXml);
		toast.ExpirationTime = DateTime.Now.AddSeconds(4);
		ToastNotifier.Show(toast);
	}
}

