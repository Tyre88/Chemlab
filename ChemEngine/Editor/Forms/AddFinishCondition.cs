using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ChemEngine.GameObjects;

namespace ChemEngine.Editor.Forms
{
    public partial class AddFinishCondition : Form
    {
        public delegate void SaveEvent(string type, int count);

        public event SaveEvent Save;

        int _count;

        public AddFinishCondition()
        {
            InitializeComponent();

            foreach (GameObjectType type in Enum.GetValues(typeof(GameObjectType)))
            {
                ddlType.Items.Add(type);
            }

            ddlType.SelectedIndex = 0;
        }

        public void Reset()
        {
            ddlType.SelectedIndex = 0;
            txtAmount.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save != null)
            {
                int.TryParse(txtAmount.Text, out _count);
                Save(ddlType.SelectedItem.ToString(), _count);
                this.Close();
            }
        }
    }
}
