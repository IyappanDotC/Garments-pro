﻿using System;
using System.Data;
using System.Data.SqlClient; 

namespace Garments_Pro.Departments.Finished_Goods
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserName"] != null)
          //{



            LoadInP();
            LoadOnHold();
            LoadFinished();
            LoadYStart();
            //}
            //else
            //{
            //    Response.Redirect("~/Admin/AdminLogin.aspx");
            //}

        }
        private string MyConnection()
        {
            return @"Data Source =.; Initial Catalog = GarmentsPro; Integrated Security = SSPI ";
        }
        private void LoadYStart()
        {
            DataTable MyTable = new DataTable();

            SqlConnection Sqlconnection = new SqlConnection(MyConnection());
            string MYQ = "select count(*) as Total from OrderStatus where Current_Department='5' and Status='1'";
            SqlCommand mYcMD = new SqlCommand(MYQ, Sqlconnection);

            Sqlconnection.Open();
            YAN1.Text = Convert.ToString(mYcMD.ExecuteScalar());
            Sqlconnection.Close();
        }
        private void LoadInP()
        {
            DataTable MyTable = new DataTable();

            SqlConnection Sqlconnection = new SqlConnection(MyConnection());
            string MYQ = "select count(*) as Total from OrderStatus where Current_Department='5' and Status='2'";
            SqlCommand mYcMD = new SqlCommand(MYQ, Sqlconnection);

            Sqlconnection.Open();
            YAN2.Text = Convert.ToString(mYcMD.ExecuteScalar());
            Sqlconnection.Close();
        }
        private void LoadOnHold()
        {


            DataTable MyTable = new DataTable();

            SqlConnection Sqlconnection = new SqlConnection(MyConnection());
            string MYQ = "select count(*) as Total from OrderStatus  where Status='3' and Current_Department='5'";
            SqlCommand mYcMD = new SqlCommand(MYQ, Sqlconnection);

            Sqlconnection.Open();
            YAN3.Text = Convert.ToString(mYcMD.ExecuteScalar());
            Sqlconnection.Close();
        }
        private void LoadFinished()
        {
            DataTable MyTable = new DataTable();

            SqlConnection Sqlconnection = new SqlConnection(MyConnection());
            string MYQ = "SELECT count(*) FROM  OrderHistory WHERE Current_Department='5' and Status='4' and Created_Date >= DATEADD (day, -30, GETDATE())";
            SqlCommand mYcMD = new SqlCommand(MYQ, Sqlconnection);

            Sqlconnection.Open();
            YAN4.Text = Convert.ToString(mYcMD.ExecuteScalar());
            Sqlconnection.Close();
        }
    }
}