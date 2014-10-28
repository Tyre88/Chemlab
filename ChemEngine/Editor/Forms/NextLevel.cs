using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChemEngine.Editor.Forms
{
    public partial class NextLevel : Form
    {
        public delegate void SaveEvent(string name);

        public event SaveEvent Save;

        public NextLevel()
        {
            InitializeComponent();
            txtName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save(txtName.Text);
            this.Close();
        }
    }
}
