using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.calitha.goldparser;

namespace _W
{
    public partial class Form1 : Form
    {
        MyParser parser;

        public Form1()
        {
            InitializeComponent();
            parser = new MyParser("!W.cgt",listBox1);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            parser.Parse(textBox1.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "!GoodBye\r\n\tdivide(x,y) { \r\n\t\tis y equal to 0?\r\n\t\tyes { return 0 }\r\n\t\tno  { return x / y}\r\n\t} \r\n\tx equals 10\r\n\tfrom i equals 0 to 10 \r\n\tdo {\r\n\t      z equals divide(x,i)\r\n\t}\r\n!Hello";
        }
    }
}
