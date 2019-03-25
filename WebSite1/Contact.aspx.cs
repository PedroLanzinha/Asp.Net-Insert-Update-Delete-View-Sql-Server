using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact : System.Web.UI.Page
{

    SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-IALMNF3;Initial Catalog=ASPCRUD;Integrated Security=True;");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnDelete.Enabled = false;
            FillGridView();
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }

    public void Clear()
    {
        hfContactID.Value = "";
        TxtName.Text = TxtMobile.Text = TxtAddress.Text = "";
        lblSucessMessage.Text = "";
        btnSave.Text = "Save";
        btnDelete.Enabled = false;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (sqlCon.State == System.Data.ConnectionState.Closed)
            sqlCon.Open();
        SqlCommand sqlCmd = new SqlCommand("ContactCreateOrUpdate", sqlCon);
        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
        sqlCmd.Parameters.AddWithValue("@ContactID", (hfContactID.Value == "" ? 0 : Convert.ToInt32(hfContactID.Value)));
        sqlCmd.Parameters.AddWithValue("@Name", TxtName.Text.Trim());
        sqlCmd.Parameters.AddWithValue("@Mobile", TxtMobile.Text.Trim());
        sqlCmd.Parameters.AddWithValue("@Address", TxtAddress.Text.Trim());
        sqlCmd.ExecuteNonQuery();
        sqlCon.Close();
        string contactID = hfContactID.Value;
        Clear();

        if (contactID == "")
        {
            lblSucessMessage.Text = "Saved Successfully";
        }
        else
        {
            lblSucessMessage.Text = "Updated Successfully";
        }
        FillGridView();
    }

    void FillGridView()
    {
        if (sqlCon.State == System.Data.ConnectionState.Closed)
            sqlCon.Open();
        SqlDataAdapter sqlDa = new SqlDataAdapter("ContactViewAll", sqlCon);
        sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
        System.Data.DataTable dtbl = new System.Data.DataTable();
        sqlDa.Fill(dtbl);
        sqlCon.Close();
        gvContact.DataSource = dtbl;
        gvContact.DataBind();
    }

    protected void lnk_OnClick(object sender, EventArgs e)
    {
        int contactID = Convert.ToInt32((sender as LinkButton).CommandArgument);
        if (sqlCon.State == System.Data.ConnectionState.Closed)
            sqlCon.Open();
        SqlDataAdapter sqlDa = new SqlDataAdapter("ContactViewByID", sqlCon);
        sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
        sqlDa.SelectCommand.Parameters.AddWithValue("@ContactID", contactID);
        System.Data.DataTable dtbl = new System.Data.DataTable();
        sqlDa.Fill(dtbl);
        sqlCon.Close();
        hfContactID.Value = contactID.ToString();
        TxtName.Text = dtbl.Rows[0]["Name"].ToString();
        TxtMobile.Text = dtbl.Rows[0]["Mobile"].ToString();
        TxtAddress.Text = dtbl.Rows[0]["Address"].ToString();
        btnSave.Text = "Update";
        btnDelete.Enabled = true;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (sqlCon.State == System.Data.ConnectionState.Closed)
            sqlCon.Open();
        SqlCommand sqlCmd = new SqlCommand("ContactDeleteByID", sqlCon);
        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
        sqlCmd.Parameters.AddWithValue("@ContactID", Convert.ToInt32(hfContactID.Value));
        sqlCmd.ExecuteNonQuery();
        sqlCon.Close();
        Clear();
        FillGridView();
        lblSucessMessage.Text = "Deleted Sucessfully";
    }
}
