﻿using System;
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
            textBox1.AutoCompleteCustomSource = source;

            //creating listview with columns.
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            //Add column headers.
            listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listView1.Columns.Add("",270);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "File Browser";
            fdlg.InitialDirectory = @"c:\";
            //"dll files (*.dll)|*.dll|All files (*.*)|*.*";
            fdlg.Filter = "dll files (*.dll)|*.dll";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;

            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                string file = Path.GetFileName(fdlg.FileName);

                //ADDING TO LIST.
                AddToList(file);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == null)
            {
                MessageBox.Show("Please Browse or type an item to insert.");
            }
            else
            {
                //ADDING TO LIST.
                AddToList(textBox1.Text);
                //DELETING FROM PREDICTION.
                source.Remove(textBox1.Text);
                textBox1.AutoCompleteCustomSource = source;

                textBox1.Text = null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ITEM = null;

            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item to delete.");
            }
            else
            {
                ITEM = listView1.SelectedItems[0].SubItems[0].Text;

                if (Dialog())
                {
                    if (listView1.SelectedItems.Count > 0)
                    {
                        if (listView1.FocusedItem.Text != null)
                        {
                            string x = listView1.FocusedItem.Text.ToString();

                            //DELETING FROM THE LIST.
                            for (int i = listView1.Items.Count - 1; i >= 0; i--)
                            {
                                if (listView1.Items[i].Text == ITEM)
                                {
                                    listView1.Items[i].Remove();
                                    MessageBox.Show("Item has been Deleted.");
                                }
                            }

                            //ADDING TO PREDICTION.
                            source.Add(x);
                            textBox1.AutoCompleteCustomSource = source;
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
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Text == inputitem)
                {
                    MessageBox.Show("Item already exists.Cannot be inserted.");
                    Duplicate = true;
                }
            }

            if (Duplicate == false)
            {
                listView1.Items.Add(inputitem);
                MessageBox.Show("Item has been inserted.");
            }

            Duplicate = false;
        }
    }
}
