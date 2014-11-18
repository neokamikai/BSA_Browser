﻿using System;
using System.Windows.Forms;
using BSA_Browser.Classes;

namespace BSA_Browser.Dialogs
{
    public partial class QuickExtractDialog : Form
    {
        public string Path
        {
            get
            {
                return txtPath.Text;
            }
        }
        public string PathName
        {
            get
            {
                return txtName.Text;
            }
        }
        public bool UseFolderPath
        {
            get
            {
                return chbUseFolderName.Checked;
            }
        }

        public QuickExtractDialog()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(IWin32Window owner, QuickExtractPath path)
        {
            txtName.Text = path.Name;
            txtPath.Text = path.Path;
            chbUseFolderName.Checked = path.UseFolderPath;

            return this.ShowDialog(owner);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog(this) == DialogResult.OK)
                    txtPath.Text = fbd.SelectedPath;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPath.Text))
            {
                MessageBox.Show(this, "Please fill all fields.");
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}