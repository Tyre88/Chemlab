using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChemEngine.Editor
{
    public partial class SetLevelName : Form
    {
        public delegate void ReturnName(string name, string goal);

        public event ReturnName Save;

        public SetLevelName()
        {
            InitializeComponent();
            txtName.Focus();
            txtName.TabIndex = 1;
            txtGoal.TabIndex = 2;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save(txtName.Text, txtGoal.Text);
            this.Close();
        }
    }
}
