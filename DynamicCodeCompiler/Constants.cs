using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicCodeCompiler
{
    public class Constants
    {
        public static AutoCompleteStringCollection Source = new AutoCompleteStringCollection()
        {
               "System",
               "System.Activities",
               "System.AddIn",
               "System.CodeDom",
               "System.Collections",
               "System.Collections.Generic",
               "System.ComponentModel",
               "System.Configuration",
               "System.Data",
               "System.Deployment",
               "System.Device.Location",
               "System.Diagnostics",
               "System.DirectoryServices",
               "System.Drawing",
               "System.Dynamic",
               "System.EnterpriseServices",
               "System.Globalization",
               "System.IdentityModel",
               "System.IO",
               "System.Linq",
               "System.Management",
               "System.Media",
               "System.Messaging",
               "System.Net",
               "System.Numerics",
               "System.Printing",
               "System.Reflection",
               "System.Resources",
               "System.Runtime",
               "System.Runtime.InteropServices.CustomMarshalers",
               "System.Security",
               "System.ServiceModel",
               "System.ServiceProcess",
               "System.Speech",
               "System.Text",
               "System.Threading",
               "System.Threading.Tasks.Dataflow",
               "System.Timers",
               "System.Transactions",
               "System.Web",
               "System.Windows",
               "System.Windows.Forms",
               "System.Workflow",
               "System.Xaml",
               "System.Xml",
               "Accessibility",
               "Microsoft.Activities",
               "Microsoft.Build",
               "Microsoft.CSharp",
               "Microsoft.JScript",
               "Microsoft.SqlServer.Server",
               "Microsoft.VisualBasic",
               "Microsoft.VisualC",
               "Microsoft.Win32",
               "Microsoft.Windows",
               "XamlGeneratedNamespace"
        };

        public static string MethodTemplate = @"namespace DynamicNamespace"
            + "{ "
            + "   public class DynamicClass"
            + "   {"
            + "       METHODSOURCE"
            + "   }"
            + "}";

        public static string CodeTemplate = @"namespace DynamicNamespace"
            + "{"
            + "     public class DynamicClass"
            + "     {"
            + "         public void DynamicMethod()"
            + "         {"
            + "             CODESOURCE"
            + "         }"
            + "     }"
            + "}";
    }
}
