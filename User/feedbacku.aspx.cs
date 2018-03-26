﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;


public partial class User_feedbacku : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Login"] != null)
        {
            Label2.Text = Request.Cookies["Login"]["Username"].ToString();
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        HttpCookie mycookie = new HttpCookie("Login");
        mycookie.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(mycookie);
        Response.Redirect("Login.aspx");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            MailMessage Msg = new MailMessage();
            // Sender e-mail address.
            Msg.From = new MailAddress(txtEmail.Text);
            // Recipient e-mail address.
            Msg.To.Add("kaushalp798@gmail.com");
            Msg.Subject = txtSubject.Text;
            Msg.Body = txtMessage.Text;
            // your remote SMTP server IP.
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("kaushalp798@gmail.com", "kaushal007");
            smtp.EnableSsl = true;
            smtp.Send(Msg);
            //Msg = null;
            lbltxt.Text = "Thanks for Contact us";
            // Clear the textbox valuess
            txtName.Text = "";
            txtSubject.Text = "";
            txtMessage.Text = "";
            txtEmail.Text = "";
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Exception caught.", ex);
        }
    }
}