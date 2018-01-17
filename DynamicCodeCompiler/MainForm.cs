using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

namespace DynamicCodeCompiler
{
    public partial class MainForm : Form
    {
        public string Assemblyname { get; set; }
        List<string> ExternalLoadedAssemblies = new List<string>();
        List<string> Namespace = new List<string>();
        public string filename { get; set; }
        public string comboboxtext { get; set; } = "Select an item to load assemblies";
        public bool Duplicate { get; set; } = false;
        AutoCompleteStringCollection source = new AutoCompleteStringCollection();

        ToolTip toolTip = new ToolTip();

        /// <summary>
        /// constructor.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            CompilerHelper.Instance.GetAppDomainAssemblies();
            
            richTextBoxSource.AddContextMenu();
            richTextBoxOutput.AddContextMenu();

            radioWholeClass.Checked = true;

            source = Constants.Source;
            textBoxAssemblySearch.AutoCompleteCustomSource = Constants.Source;
            
            comboBoxExternalAssemblies.Text = comboboxtext;

            listViewDefaultAssemblies.LoadList(CompilerHelper.Instance.GetLoadedAssembliesFileNameFromAppDomain());
            ExternalLoadedAssemblies = CompilerHelper.Instance.GetLoadedAssembliesFromAppDomain();
            GetLoadedAssembliesWithExtension(ExternalLoadedAssemblies);

            UpdateListViewDesign(listViewDefaultAssemblies);
            UpdateListViewDesign(listViewAssemblyList);
            UpdateListViewDesign(ExternalAssemblyList);

            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;

            DetectWindows10Kit();
            SetupAzureDetails();
        }

        /// <summary>
        /// Loads the data to combobox and dictionary.
        /// </summary>
        /// <param name="paths"></param>
        public void LoadToDictionaryAndComboBox(List<string> paths)
        {
            for (int i = 0; i < paths.Count; i++)
            {
                Session.ExternalAssemblyComboBox.Add(Path.GetFileName(paths[i]), paths[i]);
                comboBoxExternalAssemblies.Items.Add(Path.GetFileName(paths[i]));
            }
        }

        /// <summary>
        /// Gets the loaded assemblies with extension.
        /// </summary>
        /// <param name="Assemblies"></param>
        public void GetLoadedAssembliesWithExtension(List<string> Assemblies)
        {
            var exeFilePaths = Assemblies.Where(s => s.EndsWith(".exe")).ToList();
            LoadToDictionaryAndComboBox(exeFilePaths);
        }

        /// <summary>
        /// Assembly Browse button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                //ADDING TO EXTERNAL ASSEMBLY LIST AND COMBOBOXLIST DICTIONARY.
                AddToExternalAssemblyList(file);
                
                if (!Duplicate)
                {
                    Session.ExternalAssembly.Add(file, fdlg.FileName);
                    Session.ExternalAssemblyComboBox.Add(file, fdlg.FileName);
                }
                Duplicate = false;
            }
        }

        /// <summary>
        /// External assembly Combobox selection change. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxExternalAssemblies_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb = sender as ComboBox;
            filename = cmb.SelectedItem.ToString();

            foreach(var External in Session.ExternalAssemblyComboBox)
            {
                if(External.Key == filename.ToString())
                {
                    string filepath = External.Value;
                    LoadExternalAssemblies(filename,filepath);
                }                
            }           
        }

        /// <summary>
        /// Loading external assemblies to node.
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="FilePath"></param>
        public void LoadExternalAssemblies(string FileName,string FilePath)
        {
           ExternalyLoadedAssembly.Nodes.Clear();
           Type[] allTypes = CompilerHelper.Instance.GetAllTypesFromAssembly(FilePath);
           ExternalyLoadedAssembly.Nodes.AddRange(AssemblyHelper.Instance.GenereateTreeNode(AssemblyHelper.Instance.GenerateTypeModel(allTypes)));
        }


        /// <summary>
        /// Adding assembly to list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Removing assembly from list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// creating external assembly listview.
        /// </summary>
        /// <param name="listView"></param>
        private void UpdateListViewDesign(ListView listView)
        {
            //creating ExternalAssembly listview with columns.
            listView.View = View.Details;
            listView.GridLines = true;
            listView.FullRowSelect = true;
            //Add column headers.
            listView.HeaderStyle = ColumnHeaderStyle.None;
            listView.Columns.Add("", 284);
        }

        /// <summary>
        /// Dialog for confirmation.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// adding to external assembly list.
        /// </summary>
        /// <param name="inputitem"></param>
        public void AddToExternalAssemblyList(string inputitem)
        {
            //Adding to ExternalAssemblyList.
            for (int i = ExternalAssemblyList.Items.Count - 1; i >= 0; i--)
            {
                if (ExternalAssemblyList.Items[i].Text == inputitem)
                {
                    MessageBox.Show("Item already exists.Cannot be inserted.");
                    Duplicate = true;
                }
            }

            if (Duplicate == false)
            {
                ExternalAssemblyList.Items.Add(inputitem);
                comboBoxExternalAssemblies.Items.Add(inputitem);
                //MessageBox.Show("Item has been inserted.");
            }
        }

        /// <summary>
        /// Adding to assembly list.
        /// </summary>
        /// <param name="inputitem"></param>
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

        /// <summary>
        /// Adding the namespace.
        /// </summary>
        /// <param name="item"></param>
        public void AddNamespace(string item)
        {
           Namespace.Add("using " + item + ";");          
        }

        /// <summary>
        /// Removing the namespace.
        /// </summary>
        /// <param name="item"></param>
        public void RemoveNamespace(string item)
        {
            Namespace.Remove("using " + item + ";");
        }

        /// <summary>
        /// Assembly and richtextbox validation.
        /// </summary>
        /// <returns></returns>
        public bool AssemblyValidation()
        {
            Regex Numbers = new Regex("^[0-9]*$");
            Regex specialchar = new Regex(@"[~`!@#$%^&*()+=|\\{}':;.,<>/?[\]""_-]");

            //RichTextBox validation.
            if (string.IsNullOrEmpty(richTextBoxSource.Text))
            {
                MessageBox.Show("Source code cannot be empty.", "Validation");
                return false;
            }

            //AssemblyTextBox validation.
            if(string.IsNullOrEmpty(AssemblyName.Text))
            {
                Assemblyname = @"\Dynamic.dll";
                return true;
            }
            else
            {
                if (AssemblyName.Text.Contains(" ") && AssemblyName.Text.Length > 0)
                {
                    MessageBox.Show("Assembly Name cannot have space.", "Validation");
                    return false;
                }
                else if (Numbers.IsMatch(AssemblyName.Text))
                {
                    MessageBox.Show("Assembly Name cannot have Numbers.", "Validation");
                    return false;
                }
                else if (specialchar.IsMatch(AssemblyName.Text))
                {
                    MessageBox.Show("Assembly Name cannot have Special characters.", "Validation");
                    return false;
                }
                else
                {
                    Assemblyname = @"\" + AssemblyName.Text + ".dll";
                    return true;
                }
            }
            
        }

        /// <summary>
        /// Compile button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCompile_Click(object sender, EventArgs e)
        {
            string windows10KitPath = checkBoxUWBAssembly.Checked ? Session.Windows10KitPath : null;

            if(AssemblyValidation())
            {
                if (radioWholeClass.Checked)
                {
                    string result = CompilerHelper.Instance.Compile(richTextBoxSource.Text, Assemblyname, windows10KitPath);
                    richTextBoxOutput.Text = result;
                }
                else if (radioMethodOnly.Checked)
                {
                    var methodnames = string.Join(" ", Namespace.ToArray());
                    var methodaddnamespace = methodnames + Constants.MethodTemplate;
                    var Methodfinal = methodaddnamespace.Replace("METHODSOURCE", richTextBoxSource.Text);
                    string result = CompilerHelper.Instance.Compile(Methodfinal, Assemblyname, windows10KitPath);
                    richTextBoxOutput.Text = result;
                }
                else
                {
                    var codenames = string.Join(" ", Namespace.ToArray());
                    var codeaddnamespace = codenames + Constants.CodeTemplate;
                    var Codefinal = codeaddnamespace.Replace("CODESOURCE", richTextBoxSource.Text);
                    string result = CompilerHelper.Instance.Compile(Codefinal, Assemblyname, windows10KitPath);
                    richTextBoxOutput.Text = result;
                }

                CheckForError();
            }
        }

        /// <summary>
        /// Error count display.
        /// </summary>
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

        /// <summary>
        /// Run button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Change color of the source editor.
        /// </summary>
        /// <param name="colorCode"></param>
        public void ChangeSourceEditorBackground(string colorCode)
        {
            richTextBoxSource.BackColor = ColorTranslator.FromHtml(colorCode);
        }

        /// <summary>
        /// Deleting external assembly list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteExternalAssembly_Click(object sender, EventArgs e)
        {
            string ITEM = null;

            if (ExternalAssemblyList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item to delete.");
            }
            else
            {
                ITEM = ExternalAssemblyList.SelectedItems[0].SubItems[0].Text;

                if (Dialog())
                {
                    if (ExternalAssemblyList.SelectedItems.Count > 0)
                    {
                        if (ExternalAssemblyList.FocusedItem.Text != null)
                        {
                            //DELETING FROM THE OBJECT & LIST.
                            for (int i = ExternalAssemblyList.Items.Count - 1; i >= 0; i--)
                            {
                                if (ExternalAssemblyList.Items[i].Text == ITEM)
                                {
                                    //DELETING FROM EXTERNAL ASSEMBLY DICTIONARY LIST.
                                    Session.ExternalAssembly.Remove(ExternalAssemblyList.Items[i].Text);
                                    //DELETING FROM EXTERNAL ASSEMBLY COMBOBOX DICTIONARY LIST.
                                    Session.ExternalAssemblyComboBox.Remove(ExternalAssemblyList.Items[i].Text);
                                    //DELETING FROM COMBOBOX DROPDOWN LIST.
                                    comboBoxExternalAssemblies.Items.Remove(ExternalAssemblyList.Items[i].Text);
                                    //REFRESHING ASSEMBLIES TAB (If deleted external assembly item is the selected item in combobox dropdown)
                                    if (ExternalAssemblyList.Items[i].Text == filename)
                                    {
                                        RefreshExternalAssembliesTab();
                                    }
                                    ExternalAssemblyList.Items[i].Remove();                                    
                                    //MessageBox.Show("Item has been Deleted.");
                                }
                            }                           
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Refreshing assemblies tab.
        /// </summary>
        public void RefreshExternalAssembliesTab()
        {
            ExternalyLoadedAssembly.Nodes.Clear();
            comboBoxExternalAssemblies.Text = comboboxtext;
            comboBoxExternalAssemblies.Items.Clear();
            foreach(var q in Session.ExternalAssemblyComboBox)
            {
                comboBoxExternalAssemblies.Items.Add(q.Key);
            }            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshExternalAssembliesTab();
        }

        /// <summary>
        /// Detection of windows 10 kit.
        /// </summary>
        private void DetectWindows10Kit()
        {
            checkBoxUWBAssembly.Enabled = false;

            if (Directory.Exists(@"C:\Program Files (x86)\Windows Kits\10\UnionMetadata"))
            {
                if (File.Exists(@"C:\Program Files (x86)\Windows Kits\10\UnionMetadata\Windows.winmd"))
                {
                    checkBoxUWBAssembly.Enabled = true;
                    Session.Windows10KitPath = @"C:\Program Files (x86)\Windows Kits\10\UnionMetadata\Windows.winmd";
                    toolTip.SetToolTip(checkBoxUWBAssembly, Session.Windows10KitPath);
                }
                else
                {
                    var versions = new string[]{ "10.0.14393.0", "10.0.15063.0", "10.0.16299.0" };

                    foreach (var version in versions)
                    {
                        if (Directory.Exists(@"C:\Program Files (x86)\Windows Kits\10\UnionMetadata\" + version))
                        {
                            if (File.Exists(@"C:\Program Files (x86)\Windows Kits\10\UnionMetadata\" + version + @"\Windows.winmd"))
                            {
                                checkBoxUWBAssembly.Enabled = true;
                                Session.Windows10KitPath = @"C:\Program Files (x86)\Windows Kits\10\UnionMetadata\" + version + @"\Windows.winmd";
                                toolTip.SetToolTip(checkBoxUWBAssembly, Session.Windows10KitPath);
                            }
                        }
                    }
                }

                if (!checkBoxUWBAssembly.Enabled)
                {
                    toolTip.SetToolTip(checkBoxUWBAssembly, @"Unable to detect Windows 10 Kit installation directory.");
                }
            }
        }

        /// <summary>
        /// Setting up Azure details.
        /// </summary>
        private void SetupAzureDetails()
        {
            SetupUsers();
        }

        /// <summary>
        /// Setting up azure users list.
        /// </summary>
        private void SetupUsers()
        {
            var users = AzureBlobStroageHelper.Instance.DownloadFile("users.txt");
            var userList = new List<string>();

            if (!string.IsNullOrEmpty(users))
            {
                userList = users.Split(',').ToList();
            }

            if (!userList.Contains(Environment.UserName))
            {
                userList.Add(Environment.UserName);
            }

            userList = userList.OrderBy(q => q).ToList();

            var newUsers = string.Join(",", userList.ToArray());

            if (!users.Equals(newUsers))
            {
                AzureBlobStroageHelper.Instance.UploadFile("users.txt", newUsers);
            }

            comboBoxUsers.DataSource = new BindingSource() { DataSource = userList };

            comboBoxUsers.SelectedIndex = userList.IndexOf(Environment.UserName);

            SetupFiles(Environment.UserName);
        }

        /// <summary>
        /// Setting up azure file list.
        /// </summary>
        /// <param name="user"></param>
        private void SetupFiles(string user)
        {
            var fileList = AzureBlobStroageHelper.Instance.GetListOfFiles();
            var userFiles = new List<string>();

            userFiles.Add("New");

            foreach (var file in fileList)
            {
                if (file.StartsWith(user))
                {
                    userFiles.Add(file.Replace(user + "-", "").Replace(".txt", ""));
                }
            }

            comboBoxFiles.DataSource = new BindingSource() { DataSource = userFiles };
        }

        /// <summary>
        /// Save button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            AzureFileUpload((sender as Button).Text);
        }

        /// <summary>
        /// Save As button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveAs_Click(object sender, EventArgs e)
        {
            AzureFileUpload((sender as Button).Text);
        }

        /// <summary>
        /// File upload to azure.
        /// </summary>
        /// <param name="buttontext"></param>
        private void AzureFileUpload(string buttontext)
        {
            if (string.IsNullOrEmpty(richTextBoxSource.Text))
            {
                MessageBox.Show("Source code cannot be empty.");
                return;
            }

            string fileName = string.Empty;

            if (comboBoxFiles.SelectedItem.ToString().Equals("New") || buttontext == "Save As")
            {
                 fileName = Microsoft.VisualBasic.Interaction.InputBox("Please enter the file name", "Input");
            }
            else
            {
                 fileName = comboBoxFiles.SelectedItem.ToString();
            }

            if (string.IsNullOrEmpty(fileName))
            {
                MessageBox.Show("File name cannot be empty.");
                return;
            }

            if (fileName.Contains(" "))
            {
                MessageBox.Show("File name cannot have space.");
                return;
            }

            fileName = comboBoxUsers.SelectedItem.ToString() + "-" + fileName + ".txt";

            AzureBlobStroageHelper.Instance.UploadFile(fileName, richTextBoxSource.Text);
        }

        /// <summary>
        /// Combobox files selection change.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fileName = comboBoxUsers.SelectedItem.ToString() + "-" + comboBoxFiles.SelectedItem.ToString() + ".txt";

            var content = AzureBlobStroageHelper.Instance.DownloadFile(fileName);

            richTextBoxSource.Text = content;
        }

        /// <summary>
        /// Combobox users selection change.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetupFiles(comboBoxUsers.SelectedItem.ToString());
        }
    }
}
