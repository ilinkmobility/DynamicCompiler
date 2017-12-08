using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
namespace DynamicCodeCompiler
{
    public partial class MainForm : Form
    {
        public bool Duplicate { get; set; } = false;
        AutoCompleteStringCollection source = new AutoCompleteStringCollection();

        public MainForm()
        {
            InitializeComponent();

            CompilerHelper.Instance.GetAppDomainAssemblies();

            richTextBoxSource.AddContextMenu();
            richTextBoxOutput.AddContextMenu();

            listViewAssemblyList.LoadList(CompilerHelper.Instance.GetLoadedAssembliesPathFromAppDomain());

            // Create the list to use as the custom source for prediction. 
            source.AddRange(new string[]
                            {
                        "xamarin.dll",
                        "winforms.dll",
                        "WPF.dll",
                        "WCF.dll",
                        "Angular.dll",
                        "CSharp.dll",
                        "JQuery.dll",
                        "Javascript.dll",
                        "ASP.NET.dll"                 
                            });
            textBoxAssemblySearch.AutoCompleteCustomSource = source;

            //creating listview with columns.
            listViewAssemblyList.View = View.Details;
            listViewAssemblyList.GridLines = true;
            listViewAssemblyList.FullRowSelect = true;
            //Add column headers.
            listViewAssemblyList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listViewAssemblyList.Columns.Add("",300);

            TreeView();
        }

        public void TreeView()
        {
            var Data = Constants.Classes;

            for(int i=0;i<Data.Count;i++)
            {
                List<TreeNode> pnode = new List<TreeNode>();
                List<TreeNode> cnode = new List<TreeNode>();
                List<TreeNode> mnode = new List<TreeNode>();

                //Properties.
                for (int p=0;p<Data[i].Properties.Count;p++)
                {
                    pnode.Add(new TreeNode(
                    Data[i].Properties[p].Type + " : " + Data[i].Properties[p].Name));
                }                
                TreeNode[] PropertiesArray = pnode.ToArray();

                //Constructors.
                for (int c = 0; c < Data[i].Constructors.Count; c++)
                {
                    cnode.Add(new TreeNode(
                    Data[i].Name + "( " + string.Join(" , ", Data[i].Constructors[c].ArgumentTypes) + " )"));
                }
                TreeNode[] ConstructorsArray = cnode.ToArray();

                //Methods.
                for (int m=0;m<Data[i].Methods.Count;m++)
                {
                    mnode.Add(new TreeNode(
                    Data[i].Methods[m].ReturnType + " : " +
                    Data[i].Methods[m].Name +
                    "( " + string.Join(" , ", Data[i].Methods[m].ArgumentTypes) + " )"));
                }
                TreeNode[] MethodsArray = mnode.ToArray();

                //Adding each node.
                TreeNode Properties = new TreeNode("Properties", PropertiesArray);
                TreeNode Constructors = new TreeNode("Constructors", ConstructorsArray);
                TreeNode Methods = new TreeNode("Methods", MethodsArray);
                TreeNode[] MainComponents = new TreeNode[] { Properties, Constructors, Methods };
                
                // Final node.
                TreeNode treeNode = new TreeNode(Data[i].Name, MainComponents);
                treeView1.Nodes.Add(treeNode);                
            }            
        }

        private void btnBrowseAssembly_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "File Browser";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "Dll files (*.dll)|*.dll|Exe files (*.exe)|*.exe|Winmd files (*.winmd)|*.winmd";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;

            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                string file = Path.GetFileName(fdlg.FileName);

                Session.ExternalAssembly.Add(file, fdlg.FileName);

                //ADDING TO LIST.
                AddToList(file);
            }
        }

        private void btnAddAssembly_Click(object sender, EventArgs e)
        {
            if (textBoxAssemblySearch.Text == "" || textBoxAssemblySearch.Text == null)
            {
                MessageBox.Show("Please Browse or type an item to insert.");
            }
            else
            {
                //ADDING TO LIST.
                AddToList(textBoxAssemblySearch.Text);
                //DELETING FROM PREDICTION.
                source.Remove(textBoxAssemblySearch.Text);
                textBoxAssemblySearch.AutoCompleteCustomSource = source;

                textBoxAssemblySearch.Text = null;
            }
        }

        private void btnRemoveAssembly_Click(object sender, EventArgs e)
        {
            string ITEM = null;

            if (listViewAssemblyList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item to delete.");
            }
            else
            {
                ITEM = listViewAssemblyList.SelectedItems[0].SubItems[0].Text;

                if (Dialog())
                {
                    if (listViewAssemblyList.SelectedItems.Count > 0)
                    {
                        if (listViewAssemblyList.FocusedItem.Text != null)
                        {
                            string x = listViewAssemblyList.FocusedItem.Text.ToString();

                            //DELETING FROM THE LIST.
                            for (int i = listViewAssemblyList.Items.Count - 1; i >= 0; i--)
                            {
                                if (listViewAssemblyList.Items[i].Text == ITEM)
                                {
                                    listViewAssemblyList.Items[i].Remove();
                                    MessageBox.Show("Item has been Deleted.");
                                }
                            }

                            //ADDING TO PREDICTION.
                            source.Add(x);
                            textBoxAssemblySearch.AutoCompleteCustomSource = source;
                        }
                    }
                }
            }
            
        }

        public bool Dialog()
        {
            DialogResult result = MessageBox.Show("Do you want to delete this item from the list?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                return true;
            }
            else if (result == DialogResult.No)
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        public void AddToList(string inputitem)
        {
            //ADDING TO LIST.
            for (int i = listViewAssemblyList.Items.Count - 1; i >= 0; i--)
            {
                if (listViewAssemblyList.Items[i].Text == inputitem)
                {
                    MessageBox.Show("Item already exists.Cannot be inserted.");
                    Duplicate = true;
                }
            }

            if (Duplicate == false)
            {
                listViewAssemblyList.Items.Add(inputitem);
                MessageBox.Show("Item has been inserted.");
            }

            Duplicate = false;
        }

        const string MethodTemplate = "using System;namespace DynamicNamespace{public class DynamicClass{ METHODSOURCE }}";
        const string CodeTemplate = "using System;namespace DynamicNamespace{public class DynamicClass{public void DynamicMethod(){ CODESOURCE }}}";

        private void btnCompile_Click(object sender, EventArgs e)
        {
            if (radioWholeClass.Checked)
            {
                string result = CompilerHelper.Instance.Compile(richTextBoxSource.Text);
                richTextBoxOutput.Text = result;
            }
            else if(radioMethodOnly.Checked)
            {
                var Methodfinal = MethodTemplate.Replace("METHODSOURCE", richTextBoxSource.Text);
                string result = CompilerHelper.Instance.Compile(Methodfinal);
                richTextBoxOutput.Text = result;
            }
            else
            {
                var Codefinal = CodeTemplate.Replace("CODESOURCE", richTextBoxSource.Text);
                string result = CompilerHelper.Instance.Compile(Codefinal);
                richTextBoxOutput.Text = result;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            CompilerHelper.Instance.InvokeConstructor();
        }
    }
}
