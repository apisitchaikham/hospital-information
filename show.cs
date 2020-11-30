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
    public partial class show : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-05G8IMU\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
        public show()
        {
            InitializeComponent();
            data_show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

                datasert();
                data_show(); 

                
            
            


            
           

            

        }
         private void data_show()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *from Sickhistory ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            con.Close();
            

        }
        private void datasert()
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Sickhistory values  ('" + tx1.Text + "','" + tx2.Text + "','" + tx3.Text + "','" + tx4.Text
                + "','" + tx5.Text + "','" + tx6.Text + "','" + tx7.Text + "','" + tx8.Text + "','" + tx9.Text + "','" + tx10.Text
                + "','" + tx11.Text + "','" + tx12.Text + "','" + tx13.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();


        }
        private void data_eror()
        {

            

        }

        private void show_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectDataSet.Sickhistory' table. You can move, or remove it, as needed.
            this.sickhistoryTableAdapter.Fill(this.projectDataSet.Sickhistory);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e) //ลบข้อมูล
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Sickhistory where id='"+txdelete.Text+"'";
            cmd.ExecuteNonQuery();
            con.Close();
            data_show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Sickhistory where id='" + textBox10.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            bunifuCustomDataGrid1.DataSource = dt;
            con.Close();
            
        }
    }
}
