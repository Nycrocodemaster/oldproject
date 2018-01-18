﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cart_ShowCart : System.Web.UI.Page
{
   string s;
    string t;
    string[] a = new string[3];
    int count = 0;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[4] { new DataColumn("spname"), new DataColumn("spprice"), new DataColumn("spimg"), new DataColumn("id") });

        if (Request.Cookies["a"] != null)
        {
            s = Convert.ToString(Request.Cookies["a"].Value);

            string[] strArr = s.Split('|');

            for (int i = 0; i < strArr.Length; i++)
            {
                t = Convert.ToString(strArr[i].ToString());
                string[] strArr1 = t.Split(',');
                for (int j = 0; j < strArr1.Length; j++)
                {
                    a[j] = strArr1[j].ToString();
                }
                count = count + (Convert.ToInt32(a[1].ToString()));
                dt.Rows.Add(a[0].ToString(), a[1].ToString(), a[2].ToString(), i.ToString());
                price.Text = count.ToString();
            }
        }
        d1.DataSource = dt;
        d1.DataBind();


    }

    protected void d1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}
