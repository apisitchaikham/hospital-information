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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-05G8IMU\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM idhospital WHERE username ='" + bunifuMaterialTextbox1.Text+"'and password='"+ bunifuMaterialTextbox2.Text+"'";
            cmd.ExecuteNonQuery();
            SqlDataAdapter dat = new SqlDataAdapter(cmd);
            DataTable da = new DataTable();
            dat.Fill(da);
             if (da.Rows.Count == 1)
            {
                รีโหลด m = new รีโหลด();
                m.Show();
                this.Hide();

            }
            else 

            {
                validateusername();
                validatepassword();
               bunifuMaterialTextbox1.Focus();
            }
            con.Close();

            
        }
        protected bool validateusername()//code eror username กรณีไม่ใส่username
        {
            bool chk = false;
            Regex r = new Regex(@"^[a-zA-Z]*$");
            if (!(r.IsMatch(bunifuMaterialTextbox1.Text)) || bunifuMaterialTextbox1.Text.Length <5)
            {
                errorProvider1.SetError(bunifuMaterialTextbox1, "กรุณาใส่username");
                chk = true;
            }
            else
                errorProvider1.SetError(bunifuMaterialTextbox1, "");
            return chk;
        
        
        }
        protected bool validatepassword()//code eror password กรณีไม่ใส่username
        {
            bool chk = false;
            Regex r = new Regex(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,15})$");
            if (!(r.IsMatch(bunifuMaterialTextbox2.Text)))
            {
                errorProvider1.SetError(bunifuMaterialTextbox2, "กรุณาใส่ตัวอักษรA-Zผสมตัวเลข 8-15");
                chk = true;
            }
            else
                errorProvider1.SetError(bunifuMaterialTextbox2, "");
            return chk;


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signup sg = new signup();
            sg.Show();
            this.Hide();
        }
    }
}
