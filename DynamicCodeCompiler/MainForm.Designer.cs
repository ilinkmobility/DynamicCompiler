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
            this.tabPageAssemblies = new System.Windows.Forms.TabPage();
            this.tableLayoutCompiler = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tableLayoutSource = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBoxSource = new System.Windows.Forms.RichTextBox();
            this.tableLayoutOutput = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.tabControlMain.SuspendLayout();
            this.tabPageCompiler.SuspendLayout();
            this.tableLayoutCompiler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tableLayoutSource.SuspendLayout();
            this.tableLayoutOutput.SuspendLayout();
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
            // tabPageAssemblies
            // 
            this.tabPageAssemblies.Location = new System.Drawing.Point(4, 22);
            this.tabPageAssemblies.Name = "tabPageAssemblies";
            this.tabPageAssemblies.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAssemblies.Size = new System.Drawing.Size(929, 418);
            this.tabPageAssemblies.TabIndex = 1;
            this.tabPageAssemblies.Text = "Assemblies";
            this.tabPageAssemblies.UseVisualStyleBackColor = true;
            // 
            // tableLayoutCompiler
            // 
            this.tableLayoutCompiler.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tableLayoutCompiler.ColumnCount = 2;
            this.tableLayoutCompiler.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutCompiler.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutCompiler.Controls.Add(this.splitContainer, 1, 0);
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
    }
}

