using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "" && textBox1.Text != null) && (textBox2.Text != "" && textBox2.Text != null)) {
                if (textBox3.Text != "" && textBox3.Text != null)
                {
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.To.Add(textBox3.Text);
                    mailMessage.From = new MailAddress(textBox1.Text);
                    mailMessage.Subject = textBox4.Text;
                    mailMessage.Body = textBox5.Text;

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(textBox1.Text, textBox2.Text);
                    smtp.UseDefaultCredentials = false;
                    try
                    {
                        smtp.Send(mailMessage);
                        MessageBox.Show("Email Sent","Email",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else {
                    error.Visible = true;
                    error.Text = "Please Enter the To Email Address !";
                    return;
                }
            } else
            {
                error.Visible = true;
                error.Text = "Please Enter the Mail id And Password !";
                return;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            error.Visible = false;
        }
    }
}
