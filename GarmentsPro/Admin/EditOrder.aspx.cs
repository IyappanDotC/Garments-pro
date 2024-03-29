﻿using System;
using System.Data;
using System.Data.SqlClient;


namespace GarmentsPro.Admin
{
    public partial class EditOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadUsers();
            }
        }
        private string MyConnection()
        {
            return @"Data Source =.; Initial Catalog = GarmentsPro; Integrated Security = SSPI ";
        }
        private void LoadUsers()
        {
            DataTable MyTable = new DataTable();

            string MYQ = "select  OrderID, ClientName, OrderType, Qty, ETA_Time, Created_Date, Status from Orders where OrderID=@ID";
            using (SqlConnection Sqlconnection = new SqlConnection(MyConnection()))
            {
                SqlDataAdapter myada = new SqlDataAdapter(MYQ, Sqlconnection);

                myada.SelectCommand.Parameters.AddWithValue("@ID", Request.QueryString["ID"]);
                myada.Fill(MyTable);
            }
            GridView1.DataSource = MyTable;
            GridView1.DataBind();

            if (MyTable.Rows.Count > 0)
            {
                txtOrderID.Text = MyTable.Rows[0]["OrderID"].ToString();
                txtClinet.Text = MyTable.Rows[0]["ClientName"].ToString();
                ddType.Text = MyTable.Rows[0]["OrderType"].ToString();
                txtQty.Text = MyTable.Rows[0]["Qty"].ToString();
                txtETA.Text = MyTable.Rows[0]["ETA_Time"].ToString();
                DdStatus.Text = MyTable.Rows[0]["Status"].ToString();
                lblWelcome.Text = MyTable.Rows[0]["OrderID"].ToString();
            }
            else
            {
                Response.Redirect("~/Dashboard.aspx");
            }
        }
        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            SqlConnection MyCon = new SqlConnection(MyConnection());
            string MyInsQ = "Update Orders set ClientName=@CN, OrderType=@OType ,QtY=@Qty , ETA_Time=@ETA , Status=@Stat where OrderID=@ID";
            SqlCommand MyCmd = new SqlCommand(MyInsQ, MyCon);

            MyCon.Open();
            MyCmd.Parameters.AddWithValue("@ID", Request.QueryString["ID"]);

            MyCmd.Parameters.AddWithValue("@CN", txtClinet.Text);
            MyCmd.Parameters.AddWithValue("@OType", ddType.SelectedValue);
            MyCmd.Parameters.AddWithValue("@Qty", txtQty.Text);
            MyCmd.Parameters.AddWithValue("@ETA", txtETA.Text);
            MyCmd.Parameters.AddWithValue("@Stat", DdStatus.SelectedValue);

            MyCmd.ExecuteNonQuery();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "swal(' Order Details Updated  ' , 'Details Updated Successfully ' , 'success')", true);
            LoadUsers();
            MyCon.Close();
        }
        protected void BtnDel_Click1(object sender, EventArgs e)
        {
            using (SqlConnection Sqlconnection = new SqlConnection(MyConnection()))
            {
                Sqlconnection.Open();
                string MyQ = "Delete from Orders where OrderID=@ID";
                SqlCommand MyCmd = new SqlCommand(MyQ, Sqlconnection);
                MyCmd.Parameters.AddWithValue("@ID", Request.QueryString["ID"]);
                MyCmd.ExecuteNonQuery();
                Sqlconnection.Close();
                Response.Redirect("~/Admin/Orders.aspx");
            }
            LoadUsers();
        }
    }
}