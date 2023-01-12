using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using OtoparkData;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)  
    {
        if (!Page.IsPostBack)
        {
            if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
            {
                txtKullaniciAdi.Value = Request.Cookies["erpUserName"].Value;
                txtSifre.Value = Request.Cookies["erpPassword"].Value;
            }
        }
    }

    protected void btnGiris_Click(object sender, EventArgs e)
    {
        DataTable dt = DataVer.dtgonderSql("select * from dt_kullanici where aktif=1 and kullaniciAdi='" + txtKullaniciAdi.Value.ToString() + "' and sifre='" + txtSifre.Value + "' ", "", "");
        if (dt.Rows.Count > 0)
        {
            if (chkBeniHatirla.Checked)
            {
                Response.Cookies["erpUserName"].Value = txtKullaniciAdi.Value.ToString();
                Response.Cookies["erpPassword"].Value = txtSifre.Value.ToString();
            }

            Session["kullanici_id"] = dt.Rows[0]["id"].ToString();
            Session["rol_id"] = dt.Rows[0]["rol_id"].ToString();
            Session["adSoyad"] = dt.Rows[0]["adSoyad"].ToString();
            Response.Redirect("/Genel/Tanimlar/default.aspx");
        }
        else
        {
            ntfUyari.Text = "Kullanıcı girişi hatalı.!!!";
            ntfUyari.Show();
        }
    }

}