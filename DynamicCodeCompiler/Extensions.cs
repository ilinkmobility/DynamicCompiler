using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicCodeCompiler
{
    public static class Extensions
    { 
        /// <summary>
        /// Adds context menu options in the source code editor.
        /// </summary>
        /// <param name="rtb"></param>
        public static void AddContextMenu(this RichTextBox rtb)
        {
            if (rtb.ContextMenuStrip == null)
            {
                ContextMenuStrip cms = new ContextMenuStrip { ShowImageMargin = false };
                ToolStripMenuItem tsmiCut = new ToolStripMenuItem("Cut");
                tsmiCut.Click += (sender, e) => rtb.Cut();
                cms.Items.Add(tsmiCut);
                ToolStripMenuItem tsmiCopy = new ToolStripMenuItem("Copy");
                tsmiCopy.Click += (sender, e) => rtb.Copy();
                cms.Items.Add(tsmiCopy);
                ToolStripMenuItem tsmiPaste = new ToolStripMenuItem("Paste");
                tsmiPaste.Click += (sender, e) => rtb.Paste();
                cms.Items.Add(tsmiPaste);
                rtb.ContextMenuStrip = cms;
            }
        }

        /// <summary>
        /// Loads the lists in the specified listview.
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="items"></param>
        public static void LoadList(this ListView listView, List<string> items)
        {
            listView.Items.Clear();
            foreach (var item in items)
            {
                listView.Items.Add(item);
            }
        }
    }
}
