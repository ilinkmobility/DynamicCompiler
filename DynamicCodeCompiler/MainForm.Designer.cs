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
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBoxSource = new System.Windows.Forms.RichTextBox();
            this.tableLayoutOutput = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.tabPageAssemblies = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listViewAssemblyList = new System.Windows.Forms.ListView();
            this.btnRemoveAssembly = new System.Windows.Forms.Button();
            this.btnAddAssembly = new System.Windows.Forms.Button();
            this.btnBrowseAssembly = new System.Windows.Forms.Button();
            this.textBoxAssemblySearch = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioCodeOnly = new System.Windows.Forms.RadioButton();
            this.radioMethodOnly = new System.Windows.Forms.RadioButton();
            this.radioWholeClass = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCompile = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabPageCompiler.SuspendLayout();
            this.tableLayoutCompiler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tableLayoutSource.SuspendLayout();
            this.tableLayoutOutput.SuspendLayout();
            this.tabPageAssemblies.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.tabControlMain.Size = new System.Drawing.Size(937, 444);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageCompiler
            // 
            this.tabPageCompiler.Controls.Add(this.tableLayoutCompiler);
            this.tabPageCompiler.Location = new System.Drawing.Point(4, 22);
            this.tabPageCompiler.Name = "tabPageCompiler";
            this.tabPageCompiler.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCompiler.Size = new System.Drawing.Size(929, 418);
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
            this.tableLayoutCompiler.Size = new System.Drawing.Size(923, 412);
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
            this.splitContainer.Size = new System.Drawing.Size(617, 406);
            this.splitContainer.SplitterDistance = 285;
            this.splitContainer.TabIndex = 0;
            // 
            // tableLayoutSource
            // 
            this.tableLayoutSource.ColumnCount = 1;
            this.tableLayoutSource.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutSource.Controls.Add(this.label1, 0, 0);
            this.tableLayoutSource.Controls.Add(this.richTextBoxSource, 0, 1);
            this.tableLayoutSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutSource.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutSource.Name = "tableLayoutSource";
            this.tableLayoutSource.RowCount = 2;
            this.tableLayoutSource.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutSource.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutSource.Size = new System.Drawing.Size(617, 285);
            this.tableLayoutSource.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(611, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source";
            // 
            // richTextBoxSource
            // 
            this.richTextBoxSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxSource.Location = new System.Drawing.Point(3, 23);
            this.richTextBoxSource.Name = "richTextBoxSource";
            this.richTextBoxSource.Size = new System.Drawing.Size(611, 259);
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
            this.tableLayoutOutput.Size = new System.Drawing.Size(617, 117);
            this.tableLayoutOutput.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(611, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Output";
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxOutput.Location = new System.Drawing.Point(3, 23);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.Size = new System.Drawing.Size(611, 91);
            this.richTextBoxOutput.TabIndex = 1;
            this.richTextBoxOutput.Text = "";
            // 
            // tabPageAssemblies
            // 
            this.tabPageAssemblies.Controls.Add(this.treeView1);
            this.tabPageAssemblies.Location = new System.Drawing.Point(4, 22);
            this.tabPageAssemblies.Name = "tabPageAssemblies";
            this.tabPageAssemblies.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAssemblies.Size = new System.Drawing.Size(929, 418);
            this.tabPageAssemblies.TabIndex = 1;
            this.tabPageAssemblies.Text = "Assemblies";
            this.tabPageAssemblies.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(25, 44);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(237, 350);
            this.treeView1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRun);
            this.panel2.Controls.Add(this.btnCompile);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.listViewAssemblyList);
            this.panel2.Controls.Add(this.btnRemoveAssembly);
            this.panel2.Controls.Add(this.btnAddAssembly);
            this.panel2.Controls.Add(this.btnBrowseAssembly);
            this.panel2.Controls.Add(this.textBoxAssemblySearch);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(294, 406);
            this.panel2.TabIndex = 1;
            // 
            // listViewAssemblyList
            // 
            this.listViewAssemblyList.Location = new System.Drawing.Point(3, 89);
            this.listViewAssemblyList.Name = "listViewAssemblyList";
            this.listViewAssemblyList.Size = new System.Drawing.Size(288, 208);
            this.listViewAssemblyList.TabIndex = 21;
            this.listViewAssemblyList.UseCompatibleStateImageBehavior = false;
            // 
            // btnRemoveAssembly
            // 
            this.btnRemoveAssembly.Location = new System.Drawing.Point(270, 63);
            this.btnRemoveAssembly.Name = "btnRemoveAssembly";
            this.btnRemoveAssembly.Size = new System.Drawing.Size(22, 21);
            this.btnRemoveAssembly.TabIndex = 20;
            this.btnRemoveAssembly.Text = "-";
            this.btnRemoveAssembly.UseVisualStyleBackColor = true;
            this.btnRemoveAssembly.Click += new System.EventHandler(this.btnRemoveAssembly_Click);
            // 
            // btnAddAssembly
            // 
            this.btnAddAssembly.Location = new System.Drawing.Point(243, 63);
            this.btnAddAssembly.Name = "btnAddAssembly";
            this.btnAddAssembly.Size = new System.Drawing.Size(24, 21);
            this.btnAddAssembly.TabIndex = 19;
            this.btnAddAssembly.Text = "+";
            this.btnAddAssembly.UseVisualStyleBackColor = true;
            this.btnAddAssembly.Click += new System.EventHandler(this.btnAddAssembly_Click);
            // 
            // btnBrowseAssembly
            // 
            this.btnBrowseAssembly.Location = new System.Drawing.Point(183, 63);
            this.btnBrowseAssembly.Name = "btnBrowseAssembly";
            this.btnBrowseAssembly.Size = new System.Drawing.Size(58, 21);
            this.btnBrowseAssembly.TabIndex = 18;
            this.btnBrowseAssembly.Text = "Browse";
            this.btnBrowseAssembly.UseVisualStyleBackColor = true;
            this.btnBrowseAssembly.Click += new System.EventHandler(this.btnBrowseAssembly_Click);
            // 
            // textBoxAssemblySearch
            // 
            this.textBoxAssemblySearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxAssemblySearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxAssemblySearch.Location = new System.Drawing.Point(3, 63);
            this.textBoxAssemblySearch.Name = "textBoxAssemblySearch";
            this.textBoxAssemblySearch.Size = new System.Drawing.Size(176, 20);
            this.textBoxAssemblySearch.TabIndex = 17;
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
            // btnCompile
            // 
            this.btnCompile.Location = new System.Drawing.Point(3, 310);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(142, 44);
            this.btnCompile.TabIndex = 23;
            this.btnCompile.Text = "Compile";
            this.btnCompile.UseVisualStyleBackColor = true;
            this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(149, 310);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(142, 44);
            this.btnRun.TabIndex = 24;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 444);
            this.Controls.Add(this.tabControlMain);
            this.Name = "MainForm";
            this.Text = "Dynamic Code Compiler";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageCompiler.ResumeLayout(false);
            this.tableLayoutCompiler.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tableLayoutSource.ResumeLayout(false);
            this.tableLayoutSource.PerformLayout();
            this.tableLayoutOutput.ResumeLayout(false);
            this.tableLayoutOutput.PerformLayout();
            this.tabPageAssemblies.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageCompiler;
        private System.Windows.Forms.TableLayoutPanel tableLayoutCompiler;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TabPage tabPageAssemblies;
        private System.Windows.Forms.TableLayoutPanel tableLayoutSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBoxSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listViewAssemblyList;
        private System.Windows.Forms.Button btnRemoveAssembly;
        private System.Windows.Forms.Button btnAddAssembly;
        private System.Windows.Forms.Button btnBrowseAssembly;
        private System.Windows.Forms.TextBox textBoxAssemblySearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioCodeOnly;
        private System.Windows.Forms.RadioButton radioMethodOnly;
        private System.Windows.Forms.RadioButton radioWholeClass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnCompile;
    }
}

