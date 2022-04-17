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
    public partial class Victorie : Form
    {
        int prize;
        int id;
        public Victorie(int prize)
        {
            InitializeComponent();
            this.prize = prize;
            label1.Text = $"Вы набрали: {prize}";
            foreach (record item in record.download())
                listBox1.Items.Add(item.ToString());
            id = record.download().Count();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id<11)
                new record(id+1, textBox1.Text, prize);
            else
            {
                //замена рекорда
            }
            this.Close();
        }
    }
}
