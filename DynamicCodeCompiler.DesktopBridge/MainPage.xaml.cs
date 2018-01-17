using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DynamicCodeCompiler.DesktopBridge
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Method to receive protocal invocation and process the arguments.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            WwwFormUrlDecoder decoder = new WwwFormUrlDecoder(e.Parameter.ToString());
            try
            {
                bool IsJson = false;
                var content = decoder.GetFirstValueByName("content");
                var isjson = decoder.GetFirstValueByName("isjson");

                if (!string.IsNullOrEmpty(isjson))
                {
                    IsJson = Convert.ToBoolean(isjson);
                }

                if (!string.IsNullOrEmpty(content))
                {
                    if (IsJson)
                    {
                        dynamic data = JObject.Parse(content);
                        txtContent.Text = data.Name;
                    }
                    else
                    {
                        txtContent.Text = content;
                    }
                }
            }
            catch (Exception ex)
            {
                txtContent.Text = ex.Message;
            }
        }
    }
}
