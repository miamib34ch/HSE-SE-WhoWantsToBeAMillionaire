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
    public partial class RecordWindow : Form
    {
        int score;
        int id;

        public RecordWindow(int score)
        {
            InitializeComponent();
            this.score = score;
            label1.Text = $"Вы набрали: {score}";
            List<Record> mas = Record.sortByScore();
            for (int i = 0; i < mas.Count && i < 10; i++)
                listBox1.Items.Add(mas[i].ToString());
            id = Record.sortByScore().Count();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            new Record(id+1, name.Text, score);
            this.Close();
        }
    }
}
