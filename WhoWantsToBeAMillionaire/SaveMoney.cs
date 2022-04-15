using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhoWantsToBeAMillionaire
{
    public partial class SaveMoney : Form
    {
        static public string select {get;set;}

        public SaveMoney()
        {
            InitializeComponent();
        }

        private void lstLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            select = ((ListBox)sender).SelectedItem.ToString();
            this.Close();
        }
    }
}
