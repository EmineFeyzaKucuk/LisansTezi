using OtoparkData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tema : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["sayfaAdi"] == null)
            Session["sayfaAdi"] = "Hoşgeldiniz...";

        
        if (!Page.IsPostBack)
        {
            try
            {
                lblKullanici.Text = Session["adSoyad"].ToString();
            }
            catch
            {
                Response.Redirect("/login.aspx");
            }

            try
            {
                DataTable dt = DataVer.dtgonderSql(@"SELECT        lu.id, lu.rol_id, lu.menu_id, lu.okuma, dt.tanim
                                            FROM            lu_kullaniciRol AS lu INNER JOIN
                                            dt_menu AS dt ON lu.menu_id = dt.id where rol_id='" + Session["rol_id"].ToString() + "' ", "", "");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Control aa = FindControl(dt.Rows[i]["tanim"].ToString());
                    aa.Visible = (dt.Rows[i]["okuma"].ToString() == "True" ? true : false);
                }
            }
            catch(Exception ex) { }
        }
    }

    protected void btnCikis_Click(object sender, EventArgs e)
    {
        Session["sipDetay"] = null;
        Session["kullanici_id"] = null;
        Session["adSoyad"] = null;
        Session["kullaniciTip"] = null;
        Session["erp_id"] = null;
        Session["dbKullanici_id"] = null;
        Response.Redirect("../../login.aspx");
    }


    protected void btnGiris_Click(object sender, EventArgs e)
    {

    }
}
