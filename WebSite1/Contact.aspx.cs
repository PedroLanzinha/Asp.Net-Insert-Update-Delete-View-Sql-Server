using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnDelete.Enabled = false;
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
        lblSucessMessage.Text = "Save";
        btnDelete.Enabled = false;
    }
}
