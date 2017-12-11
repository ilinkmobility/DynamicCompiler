Whole Class
-----------

using System;
using System.Windows.Forms;

using DynamicCodeCompiler;

namespace HelloApp
{
	public class HelloApp
	{
		public string Name { get; set; }
		
		public HelloApp()
		{
			//MessageBox.Show("Hello World - Constructor!", "Info", MessageBoxButtons.OK);
		}
		
		public HelloApp(string name)
		{
			MessageBox.Show("Hello, " + name, "Info", MessageBoxButtons.OK);
		}
		
		public void SayHello()
		{
			MessageBox.Show("Hello World!", "Info", MessageBoxButtons.OK);
		}
		
		public void SayHello(string name)
		{
			MessageBox.Show("Hello, " + name, "Info", MessageBoxButtons.OK);
		}
		
		public void SayHello(string firstName, string lastName)
		{
			MessageBox.Show("Hello, " + firstName + " " + lastName, "Info", MessageBoxButtons.OK);
		}
		
		public void ShowTable(int number)
		{
			string table = "";
			
			for(int i=1; i<11; i++)
			{
				table += i + " * " + number + " = " + (i*number) + "\n";
			}
			
			MessageBox.Show(table, "Table", MessageBoxButtons.OK);
		}
		
		public void CloneCompilerWindow()
		{
			new MainForm().Show();
		}
		
		public void ChangeSourceEditorBackground(MainForm mainForm, string colorCode)
		{
			mainForm.ChangeSourceEditorBackground(colorCode);
		}
	}
}

Sample Inputs
-------------
this, #ccff99

Method Only
-----------

public void SayHello()
{
	Console.WriteLine("Hello World!");
}

Code Only
-----------

Console.WriteLine("Hello World!");