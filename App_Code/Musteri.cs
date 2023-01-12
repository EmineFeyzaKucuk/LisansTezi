using OtoparkData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Musteri
/// </summary>
public class Musteri
{
    public Musteri()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static bool admin
    {
        get
        {
            try
            {
                return HttpContext.Current.Session["kullanici_id"].ToString() == "-1" ? true : false;
            }
            catch { return false; }
        }

    }
    public static string ErpKodu
    {
        get
        {
            try
            {
                HttpRequest request = HttpContext.Current.Request;
                var url = request.Url.AbsoluteUri.Replace(request.Url.AbsolutePath, String.Empty);
                using (var context = new DbDataContext(ClsConst.ConStr))
                {
                    var index = context.dt_otoparks.First(f => f.domainUrl.IndexOf(HttpContext.Current.Request.Url.Authority) > -1).kodu.ToString();
                    return index;
                }
            }
            catch
            {
                string baseUrl = HttpContext.Current.Request.Url.Authority;
                //throw new Exception(baseUrl);
            }
            return "";
        }
    }
    public static int erpId
    {
        get
        {
            try
            {
                HttpRequest request = HttpContext.Current.Request;
                var url = request.Url.AbsoluteUri.Replace(request.Url.AbsolutePath, String.Empty);
                using (var context = new DbDataContext(ClsConst.ConStr))
                {
                    //var index = context.dt_otoparks.First(f => f.domainUrl.IndexOf(HttpContext.Current.Request.Url.Authority) > -1).id;
                    var index = context.dt_otoparks.First(f => f.kodu.ToString() == HttpContext.Current.Session["ErpKodu"].ToString()).id;
                    return index;
                }
            }
            catch
            {
                string baseUrl = HttpContext.Current.Request.Url.Authority;
                throw new Exception(baseUrl);
            }
            return 0;
        }
    }

    public static string ErpLogo
    {
        get
        {
            var context = new DbDataContext(ClsConst.ConStr);
            return context.dt_otoparks.First(f => f.id == Musteri.erpId).logo;
        }
    }
    public static string ErpAdi
    {
        get
        {
            var context = new DbDataContext(ClsConst.ConStr);
            return context.dt_otoparks.First(f => f.id == Musteri.erpId).otoparkAdi;
        }
    }
}