using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace โปรเจค
{
    public partial class signup : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-05G8IMU\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
        public signup()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into idhospital values('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("สมัครสำเร็จ");
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
           

            
        }
    }
}
