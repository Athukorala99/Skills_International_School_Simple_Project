using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;



namespace Skills_International_School
{
    class MainClasscs
    {
        public static readonly string con_string = @"Data Source=DESKTOP-G1JFPHN\SQLEXPRESS;Initial Catalog=Student;Integrated Security=True";
        public static SqlConnection con = new SqlConnection(con_string);


        public static void CBFill(string qry, ComboBox cb)
        {
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cb.DisplayMember = "name";
            cb.ValueMember = "id";
            cb.DataSource = dt;
            cb.SelectedIndex = -1;

        }
    }
}
