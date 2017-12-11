using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace DynamicCodeCompiler
{
    public partial class MainForm : Form
    {
        List<string> Namespace = new List<string>();
        public bool Duplicate { get; set; } = false;
        AutoCompleteStringCollection source = new AutoCompleteStringCollection();

        public MainForm()
        {
            InitializeComponent();

            CompilerHelper.Instance.GetAppDomainAssemblies();
            
            richTextBoxSource.AddContextMenu();
            richTextBoxOutput.AddContextMenu();

            //listViewAssemblyList.LoadList(CompilerHelper.Instance.GetLoadedAssembliesPathFromAppDomain());

            radioWholeClass.Checked = true;

            source = Constants.Source;
            textBoxAssemblySearch.AutoCompleteCustomSource = Constants.Source;

            //creating listview with columns.
            listViewAssemblyList.View = View.Details;
            listViewAssemblyList.GridLines = true;
            listViewAssemblyList.FullRowSelect = true;
            //Add column headers.
            listViewAssemblyList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listViewAssemblyList.Columns.Add("",284);

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
                
                //Final node.
                TreeNode treeNode = new TreeNode(Data[i].Name, MainComponents);
                //ExternalyLoadedAssembly.Nodes.Add(treeNode);                
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

                Type[] allTypes = CompilerHelper.Instance.GetAllTypesFromAssembly(fdlg.FileName);
                ExternalyLoadedAssembly.Nodes.AddRange(AssemblyHelper.Instance.GenereateTreeNode(AssemblyHelper.Instance.GenerateTypeModel(allTypes)));

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
                                    RemoveNamespace(listViewAssemblyList.Items[i].Text);
                                    listViewAssemblyList.Items[i].Remove();
                                    //MessageBox.Show("Item has been Deleted.");
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
            DialogResult result = MessageBox.Show("Sure to delete item(s) from the list?", "Confirmation", MessageBoxButtons.YesNoCancel);
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
                //MessageBox.Show("Item has been inserted.");
                AddNamespace(inputitem);
            }

            Duplicate = false;
        }

        public void AddNamespace(string item)
        {
           Namespace.Add("using " + item + ";");          
        }

        public void RemoveNamespace(string item)
        {
            Namespace.Remove("using " + item + ";");
        }



        private void btnCompile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBoxSource.Text))
            {
                MessageBox.Show("Source code cannot be empty.", "Error");
            }
            else
            {
                if (radioWholeClass.Checked)
                {
                    string result = CompilerHelper.Instance.Compile(richTextBoxSource.Text);
                    richTextBoxOutput.Text = result;
                }
                else if (radioMethodOnly.Checked)
                {
                    var methodnames = string.Join(" ", Namespace.ToArray());
                    var methodaddnamespace = methodnames + Constants.MethodTemplate;
                    var Methodfinal = methodaddnamespace.Replace("METHODSOURCE", richTextBoxSource.Text);
                    string result = CompilerHelper.Instance.Compile(Methodfinal);
                    richTextBoxOutput.Text = result;
                }
                else
                {
                    var codenames = string.Join(" ", Namespace.ToArray());
                    var codeaddnamespace = codenames + Constants.CodeTemplate;
                    var Codefinal = codeaddnamespace.Replace("CODESOURCE", richTextBoxSource.Text);
                    string result = CompilerHelper.Instance.Compile(Codefinal);
                    richTextBoxOutput.Text = result;
                }

                CheckForError();
            }
        }

        public void CheckForError()
        {
            if (CompilerHelper.Instance.Count > 0)
            {
                label2.Text = "Output" + " , Error(s) : " + CompilerHelper.Instance.Count;
            }
            else
            {
                label2.Text = "Output";

                treeViewCompiledAssembly.Nodes.Clear();
                treeViewCompiledAssembly.Nodes.AddRange(AssemblyHelper.Instance.GenereateTreeNode(AssemblyHelper.Instance.GenerateTypeModel(CompilerHelper.Instance.GetCompiledAssembly())));
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var selectedNode = treeViewCompiledAssembly.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("1. No constructor or methods selected to runn. Please selece a valid one. \n2. Make sure codes are compiled already", "Warning");
            }
            else
            {
                if (selectedNode.Parent.Text == "Constructors")
                {                    
                    var list = CompilerHelper.Instance.GetParameterList(treeViewCompiledAssembly.SelectedNode.Text);
                    var givenParameterValues = (string.IsNullOrEmpty(richTextBoxArguments.Text)) ? new string[0] : richTextBoxArguments.Text.Trim().Split(',').Select(p => p.Trim()).ToArray();

                    if (givenParameterValues.Length == list.Count)
                    {
                        var types = new Type[list.Count];
                        var parameters = new object[list.Count];

                        for (int i = 0; i < list.Count; i++)
                        {
                            types[i] = Type.GetType(list[i].Key);
                            parameters[i] = Convert.ChangeType(givenParameterValues[i], types[i]);
                        }

                        CompilerHelper.Instance.InvokeConstructor(types, parameters);
                    }
                    else
                    {
                        MessageBox.Show("Invalid number of arguments.", "Warning");
                    }
                }
                else if (selectedNode.Parent.Text == "Methods")
                {
                    var methodName = CompilerHelper.Instance.GetMethodName(treeViewCompiledAssembly.SelectedNode.Text);
                    var list = CompilerHelper.Instance.GetParameterList(treeViewCompiledAssembly.SelectedNode.Text);
                    var givenParameterValues = (list.Count == 0) ? new string[0] : richTextBoxArguments.Text.Trim().Split(',').Select(p => p.Trim()).ToArray();

                    if (givenParameterValues.Length == list.Count)
                    {
                        var types = new Type[list.Count];
                        var parameters = new object[list.Count];

                        for (int i = 0; i < list.Count; i++)
                        {
                            types[i] = (givenParameterValues[i] == "this") ? this.GetType() : Type.GetType(list[i].Key);
                            parameters[i] = (givenParameterValues[i] =="this") ? this : Convert.ChangeType(givenParameterValues[i], types[i]);
                        }
                        
                        CompilerHelper.Instance.InvokeMethod(methodName, types, parameters);
                    }
                    else
                    {
                        MessageBox.Show("Invalid number of arguments.", "Warning");
                    }
                }
                else
                {
                    MessageBox.Show("Selected member cannot be executed.", "Warning");
                }
            }
        }

        public void ChangeSourceEditorBackground(string colorCode)
        {
            richTextBoxSource.BackColor = ColorTranslator.FromHtml(colorCode);
        }
    }
}
