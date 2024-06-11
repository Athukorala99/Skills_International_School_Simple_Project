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
using System.Collections;
using System.Net.Mail;
using System.Net;
using System.Web;


namespace Skills_International_School
{
    public partial class Registerstu : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-G1JFPHN\SQLEXPRESS;Initial Catalog=Student;Integrated Security=True");
        
        public Registerstu()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {


        }

        private void lnkExit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void lnkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 lgout = new Form1();
            lgout.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cleardata();
        }
        public  void cleardata()
        {
            cmbRegNo.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtMobilePhone.Text = "";
            txtHomePhone.Text = "";
            txtParentName.Text = "";
            txtNIC.Text = "";
            txtContactNumber.Text = "";
            dtpDate.Value = DateTime.Now.Date;
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (radMale.Checked)
            {
                try
                {
                    con.Open();
                    string sturegmale = "insert into Registration(regNO,firstName,lastName,dateOfBirth,gender,address,email,mobilePhone,homePhone,parentName,nic,contactNo) VALUES ('" + cmbRegNo.Text + "' , '" + txtFirstName.Text + "' , '" + txtLastName.Text + "' , '" + dtpDate.Text + "' , '" + radMale.Text + "' ,' " + txtAddress.Text + "' , '" + txtEmail.Text + "' , '" + txtMobilePhone.Text + "' , '" + txtHomePhone.Text + "' ,' " + txtParentName.Text + "' , '" + txtNIC.Text + "' ,' " + txtContactNumber.Text + "')";
                    SqlDataAdapter sda2 = new SqlDataAdapter(sturegmale, con);
                    sda2.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Rrecode Added Succesfully", "Register Student", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DateTime datetime = DateTime.Now;
                    string to, from, pass, mail;
                    to = txtEmail.Text;
                    from = "himanthaathukorala@gmail.com";
                    pass = "ivoifqgtxfboqszf";
                    mail ="Date :"+ "\t" + datetime + "\n" + "Name :" + "\t" + txtFirstName.Text + " " + txtLastName.Text + "\n" + " Your information has been entered into the School System";
                    MailMessage msg = new MailMessage();
                    msg.To.Add(to);
                    msg.From = new MailAddress(from);
                    msg.Body = mail;
                    msg.Subject = "Skills International School";
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(from, pass);

                    try
                    {
                        smtp.Send(msg);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                    cleardata();
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in insert Data" + ex);
                }
                finally
                {
                    con.Close();
                }
            }
            else if (radFemale.Checked)
            {
                try
                {
                    con.Open();
                   

                    string sturegfe = "insert into Registration(regNO,firstName,lastName,dateOfBirth,gender,address,email,mobilePhone,homePhone,parentName,nic,contactNo) VALUES ('" + cmbRegNo.Text + "' , '" + txtFirstName.Text + "' , '" + txtLastName.Text + "' , '" + dtpDate.Text + "' , '" + radFemale.Text + "' ,' " + txtAddress.Text + "' , '" + txtEmail.Text + "' , '" + txtMobilePhone.Text + "' , '" + txtHomePhone.Text + "' ,' " + txtParentName.Text + "' , '" + txtNIC.Text + "' ,' " + txtContactNumber.Text + "')";
                    //com = new SqlCommand(sturegfe, con);
                    SqlDataAdapter sda1 = new SqlDataAdapter(sturegfe, con);
                    sda1.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Rrecode Added Succesfully", "Register Student", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DateTime datetime = DateTime.Now;
                    string to, from, pass, mail;
                    to = txtEmail.Text;
                    from = "himanthaathukorala@gmail.com";
                    pass = "ivoifqgtxfboqszf";
                    mail = "Date :" + "\t" + datetime + "\n" + "Name :" + "\t" + txtFirstName.Text + " " + txtLastName.Text + "\n" + " Your information has been entered into the School System";
                    MailMessage msg = new MailMessage();
                    msg.To.Add(to);
                    msg.From = new MailAddress(from);
                    msg.Body = mail;
                    msg.Subject = "Skills International School";
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(from, pass);

                    try
                    {
                        smtp.Send(msg);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                    cleardata();
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in insert Data" + ex);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Somthing is wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //com.ExecuteNonQuery();
            cleardata();
            //con.Close();
        }
        public int id = 0;
        public int rID = 0;
        private void Registerstu_Load(object sender, EventArgs e)
        {
            cleardata(); 
        }

        private void cmbRegNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
                string qry = "Select * From Registration where regNO = '" + cmbRegNo.Text + "'";

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(qry, con);
                da.Fill(dt);
                da.SelectCommand.ExecuteNonQuery();



                foreach (DataRow dr in dt.Rows)
                {
                    txtFirstName.Text = dr["firstName"].ToString();
                    txtLastName.Text = dr["lastName"].ToString();

                    if (dr["gender"].ToString() == "Male")
                    {
                        radMale.Checked = true;
                    }
                    else
                    {
                        radFemale.Checked = true;
                    }
                    txtAddress.Text = dr["address"].ToString();
                    txtEmail.Text = dr["email"].ToString();
                    txtMobilePhone.Text = dr["mobilePhone"].ToString();
                    txtHomePhone.Text = dr["homePhone"].ToString();
                    txtParentName.Text = dr["parentName"].ToString();
                    txtNIC.Text = dr["nic"].ToString();
                    txtContactNumber.Text = dr["contactNo"].ToString();
                    dtpDate.Text = dr["dateOfBirth"].ToString();
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in insert Data" + ex);
            }
            finally
            {
                con.Close();
            }
        }
        public void cmbRegNo_DropDown(object sender, EventArgs e)
        {
            string qry = "Select regNO 'id' , regNO name from Registration";
            MainClasscs.CBFill(qry, cmbRegNo);

            if (rID > 0)
            {
                cmbRegNo.SelectedValue = rID;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure,Do you really want to Delete this Record..?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    string qryd = "Delete Registration where regNO = '" + cmbRegNo.Text + "'";
                    SqlDataAdapter da2 = new SqlDataAdapter(qryd, con);
                    da2.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Succesfully", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cleardata();
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete data" + ex);
                }
                finally
                {
                    con.Close();
                }
            }
        }
        
        
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (radMale.Checked)
            {
                try
                {
                    con.Open();
                    string qryd = "Update Registration set firstName = '" + txtFirstName.Text + "',lastName = '" + txtLastName.Text + "' ,dateOfBirth = '" + dtpDate.Text + "',gender = '" + radMale.Text + "',address = '" + txtAddress.Text + "',email = '" + txtEmail.Text + "',mobilePhone ='" + txtMobilePhone.Text + "' ,homePhone = '" + txtHomePhone.Text + "',parentName ='" + txtParentName.Text + "' ,nic = '" + txtNIC.Text + "',contactNo = '" + txtContactNumber.Text + "'  where regNO = '" + cmbRegNo.Text + "'";
                    SqlDataAdapter da2 = new SqlDataAdapter(qryd, con);
                    da2.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Succesfully", "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cleardata();
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in insert Data" + ex);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                try
                {
                    con.Open();
                    string qryd = "Update Registration set firstName = '" + txtFirstName.Text + "',lastName = '" + txtLastName.Text + "' ,dateOfBirth = '" + dtpDate.Text + "',gender = '" + radFemale.Text + "',address = '" + txtAddress.Text + "',email = '" + txtEmail.Text + "',mobilePhone ='" + txtMobilePhone.Text + "' ,homePhone = '" + txtHomePhone.Text + "',parentName ='" + txtParentName.Text + "' ,nic = '" + txtNIC.Text + "',contactNo = '" + txtContactNumber.Text + "'  where regNO = '" + cmbRegNo.Text + "'";
                    SqlDataAdapter da2 = new SqlDataAdapter(qryd, con);
                    da2.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Succesfully", "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cleardata();
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in insert Data" + ex);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
