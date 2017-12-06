
using Windows.UI.Popups;

namespace DynamicCodeCompilerUWP
{
    public class MessageCenter
    {
        public static void ShowMessage(string message, string title)
        {
            new MessageDialog(message, title).ShowAsync();
        }
    }
}
