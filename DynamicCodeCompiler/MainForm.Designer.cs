namespace DynamicCodeCompiler
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageCompiler = new System.Windows.Forms.TabPage();
            this.tableLayoutCompiler = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tableLayoutSource = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AssemblyName = new System.Windows.Forms.TextBox();
            this.richTextBoxSource = new System.Windows.Forms.RichTextBox();
            this.tableLayoutOutput = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageNamespace = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.listViewAssemblyList = new System.Windows.Forms.ListView();
            this.btnRemoveAssembly = new System.Windows.Forms.Button();
            this.btnAddAssembly = new System.Windows.Forms.Button();
            this.textBoxAssemblySearch = new System.Windows.Forms.TextBox();
            this.tabPageExternalAssembly = new System.Windows.Forms.TabPage();
            this.DeleteExternalAssembly = new System.Windows.Forms.Button();
            this.ExternalAssemblyList = new System.Windows.Forms.ListView();
            this.btnBrowseAssembly = new System.Windows.Forms.Button();
            this.tabPageDefaultAssemblies = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.listViewDefaultAssemblies = new System.Windows.Forms.ListView();
            this.richTextBoxArguments = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.treeViewCompiledAssembly = new System.Windows.Forms.TreeView();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnCompile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioCodeOnly = new System.Windows.Forms.RadioButton();
            this.radioMethodOnly = new System.Windows.Forms.RadioButton();
            this.radioWholeClass = new System.Windows.Forms.RadioButton();
            this.tabPageAssemblies = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ExternalyLoadedAssembly = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxExternalAssemblies = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabPageCompiler.SuspendLayout();
            this.tableLayoutCompiler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tableLayoutSource.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutOutput.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageNamespace.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPageExternalAssembly.SuspendLayout();
            this.tabPageDefaultAssemblies.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPageAssemblies.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageCompiler);
            this.tabControlMain.Controls.Add(this.tabPageAssemblies);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1009, 617);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageCompiler
            // 
            this.tabPageCompiler.Controls.Add(this.tableLayoutCompiler);
            this.tabPageCompiler.Location = new System.Drawing.Point(4, 22);
            this.tabPageCompiler.Name = "tabPageCompiler";
            this.tabPageCompiler.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCompiler.Size = new System.Drawing.Size(1001, 591);
            this.tabPageCompiler.TabIndex = 0;
            this.tabPageCompiler.Text = "Compiler";
            this.tabPageCompiler.UseVisualStyleBackColor = true;
            // 
            // tableLayoutCompiler
            // 
            this.tableLayoutCompiler.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tableLayoutCompiler.ColumnCount = 2;
            this.tableLayoutCompiler.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutCompiler.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutCompiler.Controls.Add(this.splitContainer, 1, 0);
            this.tableLayoutCompiler.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutCompiler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutCompiler.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutCompiler.Name = "tableLayoutCompiler";
            this.tableLayoutCompiler.RowCount = 1;
            this.tableLayoutCompiler.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutCompiler.Size = new System.Drawing.Size(995, 585);
            this.tableLayoutCompiler.TabIndex = 1;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(303, 3);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tableLayoutSource);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tableLayoutOutput);
            this.splitContainer.Size = new System.Drawing.Size(689, 579);
            this.splitContainer.SplitterDistance = 406;
            this.splitContainer.TabIndex = 0;
            // 
            // tableLayoutSource
            // 
            this.tableLayoutSource.ColumnCount = 1;
            this.tableLayoutSource.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutSource.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutSource.Controls.Add(this.richTextBoxSource, 0, 1);
            this.tableLayoutSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutSource.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutSource.Name = "tableLayoutSource";
            this.tableLayoutSource.RowCount = 2;
            this.tableLayoutSource.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutSource.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutSource.Size = new System.Drawing.Size(689, 406);
            this.tableLayoutSource.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.AssemblyName, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(689, 20);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(404, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Assembly Name (Optional):";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AssemblyName
            // 
            this.AssemblyName.Dock = System.Windows.Forms.DockStyle.Left;
            this.AssemblyName.Location = new System.Drawing.Point(541, 0);
            this.AssemblyName.Margin = new System.Windows.Forms.Padding(0);
            this.AssemblyName.MaxLength = 32760;
            this.AssemblyName.Name = "AssemblyName";
            this.AssemblyName.Size = new System.Drawing.Size(144, 20);
            this.AssemblyName.TabIndex = 2;
            // 
            // richTextBoxSource
            // 
            this.richTextBoxSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxSource.Location = new System.Drawing.Point(3, 23);
            this.richTextBoxSource.Name = "richTextBoxSource";
            this.richTextBoxSource.Size = new System.Drawing.Size(683, 380);
            this.richTextBoxSource.TabIndex = 1;
            this.richTextBoxSource.Text = "";
            // 
            // tableLayoutOutput
            // 
            this.tableLayoutOutput.ColumnCount = 1;
            this.tableLayoutOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutOutput.Controls.Add(this.label2, 0, 0);
            this.tableLayoutOutput.Controls.Add(this.richTextBoxOutput, 0, 1);
            this.tableLayoutOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutOutput.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutOutput.Name = "tableLayoutOutput";
            this.tableLayoutOutput.RowCount = 2;
            this.tableLayoutOutput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutOutput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutOutput.Size = new System.Drawing.Size(689, 169);
            this.tableLayoutOutput.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(683, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Output";
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxOutput.Location = new System.Drawing.Point(3, 23);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.Size = new System.Drawing.Size(683, 143);
            this.richTextBoxOutput.TabIndex = 1;
            this.richTextBoxOutput.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Controls.Add(this.richTextBoxArguments);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.treeViewCompiledAssembly);
            this.panel2.Controls.Add(this.btnRun);
            this.panel2.Controls.Add(this.btnCompile);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(294, 579);
            this.panel2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageNamespace);
            this.tabControl1.Controls.Add(this.tabPageExternalAssembly);
            this.tabControl1.Controls.Add(this.tabPageDefaultAssemblies);
            this.tabControl1.Location = new System.Drawing.Point(3, 62);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(291, 183);
            this.tabControl1.TabIndex = 29;
            // 
            // tabPageNamespace
            // 
            this.tabPageNamespace.Controls.Add(this.panel4);
            this.tabPageNamespace.Location = new System.Drawing.Point(4, 22);
            this.tabPageNamespace.Name = "tabPageNamespace";
            this.tabPageNamespace.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNamespace.Size = new System.Drawing.Size(283, 157);
            this.tabPageNamespace.TabIndex = 0;
            this.tabPageNamespace.Text = "Namespace";
            this.tabPageNamespace.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.listViewAssemblyList);
            this.panel4.Controls.Add(this.btnRemoveAssembly);
            this.panel4.Controls.Add(this.btnAddAssembly);
            this.panel4.Controls.Add(this.textBoxAssemblySearch);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(277, 151);
            this.panel4.TabIndex = 0;
            // 
            // listViewAssemblyList
            // 
            this.listViewAssemblyList.Location = new System.Drawing.Point(0, 30);
            this.listViewAssemblyList.Name = "listViewAssemblyList";
            this.listViewAssemblyList.Size = new System.Drawing.Size(277, 118);
            this.listViewAssemblyList.TabIndex = 25;
            this.listViewAssemblyList.UseCompatibleStateImageBehavior = false;
            // 
            // btnRemoveAssembly
            // 
            this.btnRemoveAssembly.Location = new System.Drawing.Point(227, 3);
            this.btnRemoveAssembly.Name = "btnRemoveAssembly";
            this.btnRemoveAssembly.Size = new System.Drawing.Size(47, 21);
            this.btnRemoveAssembly.TabIndex = 24;
            this.btnRemoveAssembly.Text = "-";
            this.btnRemoveAssembly.UseVisualStyleBackColor = true;
            this.btnRemoveAssembly.Click += new System.EventHandler(this.btnRemoveAssembly_Click);
            // 
            // btnAddAssembly
            // 
            this.btnAddAssembly.Location = new System.Drawing.Point(178, 3);
            this.btnAddAssembly.Name = "btnAddAssembly";
            this.btnAddAssembly.Size = new System.Drawing.Size(47, 21);
            this.btnAddAssembly.TabIndex = 23;
            this.btnAddAssembly.Text = "+";
            this.btnAddAssembly.UseVisualStyleBackColor = true;
            this.btnAddAssembly.Click += new System.EventHandler(this.btnAddAssembly_Click);
            // 
            // textBoxAssemblySearch
            // 
            this.textBoxAssemblySearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxAssemblySearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxAssemblySearch.Location = new System.Drawing.Point(0, 3);
            this.textBoxAssemblySearch.Name = "textBoxAssemblySearch";
            this.textBoxAssemblySearch.Size = new System.Drawing.Size(176, 20);
            this.textBoxAssemblySearch.TabIndex = 22;
            // 
            // tabPageExternalAssembly
            // 
            this.tabPageExternalAssembly.Controls.Add(this.DeleteExternalAssembly);
            this.tabPageExternalAssembly.Controls.Add(this.ExternalAssemblyList);
            this.tabPageExternalAssembly.Controls.Add(this.btnBrowseAssembly);
            this.tabPageExternalAssembly.Location = new System.Drawing.Point(4, 22);
            this.tabPageExternalAssembly.Name = "tabPageExternalAssembly";
            this.tabPageExternalAssembly.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExternalAssembly.Size = new System.Drawing.Size(283, 157);
            this.tabPageExternalAssembly.TabIndex = 1;
            this.tabPageExternalAssembly.Text = "External Assembly";
            this.tabPageExternalAssembly.UseVisualStyleBackColor = true;
            // 
            // DeleteExternalAssembly
            // 
            this.DeleteExternalAssembly.Location = new System.Drawing.Point(246, 6);
            this.DeleteExternalAssembly.Name = "DeleteExternalAssembly";
            this.DeleteExternalAssembly.Size = new System.Drawing.Size(31, 21);
            this.DeleteExternalAssembly.TabIndex = 20;
            this.DeleteExternalAssembly.Text = "-";
            this.DeleteExternalAssembly.UseVisualStyleBackColor = true;
            this.DeleteExternalAssembly.Click += new System.EventHandler(this.DeleteExternalAssembly_Click);
            // 
            // ExternalAssemblyList
            // 
            this.ExternalAssemblyList.Location = new System.Drawing.Point(6, 34);
            this.ExternalAssemblyList.Name = "ExternalAssemblyList";
            this.ExternalAssemblyList.Size = new System.Drawing.Size(271, 120);
            this.ExternalAssemblyList.TabIndex = 19;
            this.ExternalAssemblyList.UseCompatibleStateImageBehavior = false;
            // 
            // btnBrowseAssembly
            // 
            this.btnBrowseAssembly.Location = new System.Drawing.Point(6, 6);
            this.btnBrowseAssembly.Name = "btnBrowseAssembly";
            this.btnBrowseAssembly.Size = new System.Drawing.Size(233, 21);
            this.btnBrowseAssembly.TabIndex = 18;
            this.btnBrowseAssembly.Text = "Browse";
            this.btnBrowseAssembly.UseVisualStyleBackColor = true;
            this.btnBrowseAssembly.Click += new System.EventHandler(this.btnBrowseAssembly_Click);
            // 
            // tabPageDefaultAssemblies
            // 
            this.tabPageDefaultAssemblies.Controls.Add(this.panel5);
            this.tabPageDefaultAssemblies.Location = new System.Drawing.Point(4, 22);
            this.tabPageDefaultAssemblies.Name = "tabPageDefaultAssemblies";
            this.tabPageDefaultAssemblies.Size = new System.Drawing.Size(283, 157);
            this.tabPageDefaultAssemblies.TabIndex = 2;
            this.tabPageDefaultAssemblies.Text = "Default Assemblies";
            this.tabPageDefaultAssemblies.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.listViewDefaultAssemblies);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(283, 157);
            this.panel5.TabIndex = 0;
            // 
            // listViewDefaultAssemblies
            // 
            this.listViewDefaultAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewDefaultAssemblies.Location = new System.Drawing.Point(0, 0);
            this.listViewDefaultAssemblies.Name = "listViewDefaultAssemblies";
            this.listViewDefaultAssemblies.Size = new System.Drawing.Size(283, 157);
            this.listViewDefaultAssemblies.TabIndex = 0;
            this.listViewDefaultAssemblies.UseCompatibleStateImageBehavior = false;
            // 
            // richTextBoxArguments
            // 
            this.richTextBoxArguments.Location = new System.Drawing.Point(3, 452);
            this.richTextBoxArguments.Name = "richTextBoxArguments";
            this.richTextBoxArguments.Size = new System.Drawing.Size(289, 64);
            this.richTextBoxArguments.TabIndex = 28;
            this.richTextBoxArguments.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 436);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Arguments (seperate by comma)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-2, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Compiled Assembly";
            // 
            // treeViewCompiledAssembly
            // 
            this.treeViewCompiledAssembly.Location = new System.Drawing.Point(0, 270);
            this.treeViewCompiledAssembly.Name = "treeViewCompiledAssembly";
            this.treeViewCompiledAssembly.Size = new System.Drawing.Size(289, 150);
            this.treeViewCompiledAssembly.TabIndex = 25;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(149, 532);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(142, 44);
            this.btnRun.TabIndex = 24;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnCompile
            // 
            this.btnCompile.Location = new System.Drawing.Point(3, 532);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(142, 44);
            this.btnCompile.TabIndex = 23;
            this.btnCompile.Text = "Compile";
            this.btnCompile.UseVisualStyleBackColor = true;
            this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Source Type";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioCodeOnly);
            this.panel1.Controls.Add(this.radioMethodOnly);
            this.panel1.Controls.Add(this.radioWholeClass);
            this.panel1.Location = new System.Drawing.Point(3, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 31);
            this.panel1.TabIndex = 16;
            // 
            // radioCodeOnly
            // 
            this.radioCodeOnly.AutoSize = true;
            this.radioCodeOnly.Location = new System.Drawing.Point(217, 4);
            this.radioCodeOnly.Name = "radioCodeOnly";
            this.radioCodeOnly.Size = new System.Drawing.Size(74, 17);
            this.radioCodeOnly.TabIndex = 2;
            this.radioCodeOnly.TabStop = true;
            this.radioCodeOnly.Text = "Only Code";
            this.radioCodeOnly.UseVisualStyleBackColor = true;
            // 
            // radioMethodOnly
            // 
            this.radioMethodOnly.AutoSize = true;
            this.radioMethodOnly.Location = new System.Drawing.Point(109, 4);
            this.radioMethodOnly.Name = "radioMethodOnly";
            this.radioMethodOnly.Size = new System.Drawing.Size(85, 17);
            this.radioMethodOnly.TabIndex = 1;
            this.radioMethodOnly.TabStop = true;
            this.radioMethodOnly.Text = "Only Method";
            this.radioMethodOnly.UseVisualStyleBackColor = true;
            // 
            // radioWholeClass
            // 
            this.radioWholeClass.AutoSize = true;
            this.radioWholeClass.Location = new System.Drawing.Point(2, 4);
            this.radioWholeClass.Name = "radioWholeClass";
            this.radioWholeClass.Size = new System.Drawing.Size(84, 17);
            this.radioWholeClass.TabIndex = 0;
            this.radioWholeClass.TabStop = true;
            this.radioWholeClass.Text = "Whole Class";
            this.radioWholeClass.UseVisualStyleBackColor = true;
            // 
            // tabPageAssemblies
            // 
            this.tabPageAssemblies.Controls.Add(this.tableLayoutPanel1);
            this.tabPageAssemblies.Location = new System.Drawing.Point(4, 22);
            this.tabPageAssemblies.Name = "tabPageAssemblies";
            this.tabPageAssemblies.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAssemblies.Size = new System.Drawing.Size(1001, 591);
            this.tabPageAssemblies.TabIndex = 1;
            this.tabPageAssemblies.Text = "Assemblies";
            this.tabPageAssemblies.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(995, 585);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ExternalyLoadedAssembly);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 36);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(989, 546);
            this.panel3.TabIndex = 0;
            // 
            // ExternalyLoadedAssembly
            // 
            this.ExternalyLoadedAssembly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExternalyLoadedAssembly.Location = new System.Drawing.Point(0, 0);
            this.ExternalyLoadedAssembly.Name = "ExternalyLoadedAssembly";
            this.ExternalyLoadedAssembly.Size = new System.Drawing.Size(989, 546);
            this.ExternalyLoadedAssembly.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(995, 33);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.Controls.Add(this.comboBoxExternalAssemblies, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnRefresh, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(989, 27);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // comboBoxExternalAssemblies
            // 
            this.comboBoxExternalAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxExternalAssemblies.FormattingEnabled = true;
            this.comboBoxExternalAssemblies.Location = new System.Drawing.Point(3, 3);
            this.comboBoxExternalAssemblies.Name = "comboBoxExternalAssemblies";
            this.comboBoxExternalAssemblies.Size = new System.Drawing.Size(903, 21);
            this.comboBoxExternalAssemblies.TabIndex = 0;
            this.comboBoxExternalAssemblies.SelectedIndexChanged += new System.EventHandler(this.comboBoxExternalAssemblies_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(912, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(74, 21);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 617);
            this.Controls.Add(this.tabControlMain);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dynamic Code Compiler";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageCompiler.ResumeLayout(false);
            this.tableLayoutCompiler.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tableLayoutSource.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutOutput.ResumeLayout(false);
            this.tableLayoutOutput.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageNamespace.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPageExternalAssembly.ResumeLayout(false);
            this.tabPageDefaultAssemblies.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPageAssemblies.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageCompiler;
        private System.Windows.Forms.TableLayoutPanel tableLayoutCompiler;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TabPage tabPageAssemblies;
        private System.Windows.Forms.TableLayoutPanel tableLayoutSource;
        private System.Windows.Forms.RichTextBox richTextBoxSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnBrowseAssembly;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioCodeOnly;
        private System.Windows.Forms.RadioButton radioMethodOnly;
        private System.Windows.Forms.RadioButton radioWholeClass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnCompile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TreeView ExternalyLoadedAssembly;
        private System.Windows.Forms.TreeView treeViewCompiledAssembly;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBoxArguments;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageNamespace;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListView listViewAssemblyList;
        private System.Windows.Forms.Button btnRemoveAssembly;
        private System.Windows.Forms.Button btnAddAssembly;
        private System.Windows.Forms.TextBox textBoxAssemblySearch;
        private System.Windows.Forms.TabPage tabPageExternalAssembly;
        private System.Windows.Forms.ListView ExternalAssemblyList;
        private System.Windows.Forms.Button DeleteExternalAssembly;
        private System.Windows.Forms.TabPage tabPageDefaultAssemblies;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ListView listViewDefaultAssemblies;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox comboBoxExternalAssemblies;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox AssemblyName;
    }
}

