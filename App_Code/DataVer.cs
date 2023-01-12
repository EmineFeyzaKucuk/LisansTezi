using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;

public class DataVer
{
    public static string Domain
    {
        get
        {
            try
            {
                return HttpContext.Current.Session["domain"].ToString();
            }
            catch
            {
                return "ADM,GDZ";
                HttpContext.Current.Response.Redirect("../Login.aspx");
                return "";
            }
        }
    }
    public static SqlConnection connSql()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString;//.Replace("sirket", System.Web.HttpContext.Current.Session["sirket"].ToString());
        return con;
    }

    public static SqlConnection connSqlHarici(string srv, string data, string uid, string pass)
    {
        SqlConnection con = new SqlConnection("Data Source=" + srv + ";Initial Catalog=" + data + ";User ID=" + uid + ";PassWord=" + pass);
        return con;
    }

    public static string userInfo(int tip)
    {
        MembershipUser user = Membership.GetUser(HttpContext.Current.User.Identity.Name);
        if (tip == 1)
        {
            Guid loginUser = (Guid)user.ProviderUserKey;
            return loginUser.ToString();
        }

        return "0";
    }

    public static DataTable dtgonderSql(string sorgu, string rol_id, string formAdi)
    {
        SqlConnection con = connSql();
        SqlDataAdapter adap = new SqlDataAdapter(sorgu, con);
        adap.SelectCommand.CommandTimeout = 1111;
        con.Open();
        DataSet ds = new DataSet();
        try
        {
            adap.Fill(ds, "tbl");
        }
        catch (Exception ex)
        {
            StreamWriter wr = new StreamWriter("hata.txt");
            wr.Write(ex.ToString() + "\n" + sorgu);
            wr.Close();
        }
        con.Close();
        return ds.Tables[0];
    }

    public static DataSet dsgonderSqlHarici(string sorgu, string srv, string data, string uid, string pass)
    {
        SqlConnection con = connSqlHarici(srv, data, uid, pass);
        SqlDataAdapter adap = new SqlDataAdapter(sorgu, con);
        con.Open();
        DataSet ds = new DataSet();
        try
        {
            adap.Fill(ds, "tbl");
        }
        catch { }
        con.Close();
        return ds;
    }

    public static string cumlecalistirSql(string sorgu, string rol_id, string formAdi)
    {
        try
        {
            SqlConnection con = connSql();
            SqlCommand komut = new SqlCommand(sorgu, con);
            con.Open();
            komut.ExecuteNonQuery();
            con.Close();
            return "true";
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
    }

    public static string cumlecalistirSqlHarici(string sorgu, string srv, string data, string uid, string pass)
    {
        try
        {
            SqlConnection con = connSqlHarici(srv, data, uid, pass);
            SqlCommand komut = new SqlCommand(sorgu, con);
            con.Open();
            komut.ExecuteNonQuery();
            con.Close();
            return "true";
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
    }

    public static OleDbConnection connOleDb()
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=yonetmelik.mdb");
        return con;
    }

    public static DataSet dsgonderOleDb(string sorgu)
    {
        OleDbConnection con = connOleDb();
        OleDbDataAdapter adap = new OleDbDataAdapter(sorgu, con);
        con.Open();
        DataSet ds = new DataSet();
        adap.Fill(ds, "tbl");
        con.Close();
        return ds;
    }

    public static string cumlecalistirOleDb(string sorgu)
    {
        try
        {
            OleDbConnection con = connOleDb();
            OleDbCommand komut = new OleDbCommand(sorgu, con);
            con.Open();
            komut.ExecuteNonQuery();
            con.Close();
            return "true";
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
    }

    public static string degistir(string ab)
    {
        ab = ab.Replace("Ý", "İ");
        ab = ab.Replace("Þ", "Ş");
        ab = ab.Replace("Ð", "Ğ");
        ab = ab.Replace("ð", "ğ");
        ab = ab.Replace("ý", "ı");

        return ab;
    }

    public static string degistirTersine(string ab)
    {
        ab = ab.Replace("İ", "Ý");
        ab = ab.Replace("Ş", "Þ");
        ab = ab.Replace("Ğ", "Ð");
        ab = ab.Replace("ð", "ğ");
        ab = ab.Replace("ý", "ı");

        return ab;
    }

    public static string ondalikCevir(double sayi)
    {
        string aa = String.Format("{0:0.00}", sayi);
        return aa;
    }

    public static string ondalikCevir(string sayi)
    {
        string aa = String.Format("{0:0.00}", Convert.ToDouble(sayi));
        return aa;
    }

    public static string virgulNokta(string sayi)
    {
        //return sayi;
        string parca1 = "", parca2 = "";
        parca1 = sayi.Substring(0, sayi.IndexOf(","));
        parca2 = sayi.Replace(parca1, "");
        parca1 = parca1.Replace(".", ",");
        parca2 = parca2.Replace(",", ".");

        return parca1 + parca2;
    }

    public static string stokKoduYolla(string ilkKisim)
    {
        DataTable dt = dtgonderSql("select top 1 STOK_KODU from TBLSTSABIT WHERE STOK_KODU LIKE '%" + ilkKisim + "%' ORDER BY STOK_KODU DESC ", "", "");
        if (dt.Rows.Count == 0)
            return ilkKisim + "-0001";
        else
        {
            string stok_kodu = dt.Rows[0]["STOK_KODU"].ToString();
            int sonRakam = int.Parse(stok_kodu.Replace(ilkKisim, "").Replace("-", "")) + 1;
            return ilkKisim + "-" + sonRakam.ToString("0000");
        }
    }

    public static string numaraYolla()
    {
        string numara = DateTime.Today.Year.ToString();
        numara += DateTime.Today.Month.ToString("00");
        numara += DateTime.Today.Day.ToString("00");
        numara += DateTime.Now.Hour.ToString("00");
        numara += DateTime.Now.Minute.ToString("00");
        numara += DateTime.Now.Second.ToString("00") + "0";

        return numara;
    }

    public static string turkceKarakterCevir(string kelime)
    {
        kelime = kelime.Replace("ğ", "g").Replace("ı", "i").Replace("ü", "u").Replace("ö", "o").Replace("ç", "c").Replace("ş", "s");
        return kelime;
    }

    public static string zamanAralik(DateTime dt)
    {
        const int SECOND = 1;
        const int MINUTE = 60 * SECOND;
        const int HOUR = 60 * MINUTE;
        const int DAY = 24 * HOUR;
        const int MONTH = 30 * DAY;

        var ts = new TimeSpan(DateTime.Now.Ticks - dt.Ticks);
        double delta = Math.Abs(ts.TotalSeconds);

        if (delta < 1 * MINUTE)
        {
            return ts.Seconds == 1 ? "1 saniye önce" : ts.Seconds + " saniye önce";
        }
        if (delta < 2 * MINUTE)
        {
            return "1 dakika önce";
        }
        if (delta < 45 * MINUTE)
        {
            return ts.Minutes + " dakika önce";
        }
        if (delta < 90 * MINUTE)
        {
            return "1 saat önce";
        }
        if (delta < 24 * HOUR)
        {
            return ts.Hours + " saat önce";
        }
        if (delta < 48 * HOUR)
        {
            return "dün";
        }
        if (delta < 30 * DAY)
        {
            return ts.Days + " gün önce";
        }
        if (delta < 12 * MONTH)
        {
            int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
            return months <= 1 ? "1 ay önce" : months + " ay önce";
        }
        else
        {
            int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "1 yıl önce" : years + " yıl önce";
        }
    }

    private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("tu89geji340t89u2");

    // This constant is used to determine the keysize of the encryption algorithm.
    private const int keysize = 256;

    public static string Encrypt(string plainText, string passPhrase)
    {
        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
        {
            byte[] keyBytes = password.GetBytes(keysize / 8);
            using (RijndaelManaged symmetricKey = new RijndaelManaged())
            {
                symmetricKey.Mode = CipherMode.CBC;
                using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                            cryptoStream.FlushFinalBlock();
                            byte[] cipherTextBytes = memoryStream.ToArray();
                            return Convert.ToBase64String(cipherTextBytes);
                        }
                    }
                }
            }
        }
    }

    public static string Decrypt(string cipherText, string passPhrase)
    {
        byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
        using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
        {
            byte[] keyBytes = password.GetBytes(keysize / 8);
            using (RijndaelManaged symmetricKey = new RijndaelManaged())
            {
                symmetricKey.Mode = CipherMode.CBC;
                using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
                {
                    using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                        }
                    }
                }
            }
        }
    }

    public static string mailGonder(string[] alici, string[] cc, string baslik, string body, string firma_id)
    {
        MailMessage mailMessage = new MailMessage();
        for (int i = 0; i < alici.Length; i++)
            mailMessage.To.Add(alici[i]);

        for (int i = 0; i < cc.Length; i++)
            mailMessage.CC.Add(cc[i]);

        mailMessage.From = new MailAddress("info@egitimofisi.org");
        mailMessage.Subject = baslik;
        mailMessage.IsBodyHtml = true;
        mailMessage.Body = body;

        SmtpClient smtpClient = new SmtpClient("mail.lbygrup.com", 587);
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new System.Net.NetworkCredential("info@lbygrup.com", "kabalay1web");
        smtpClient.Send(mailMessage);

        return "";
    }

    public static string smsGonder(string mesaj, string[] numaralar, string kullanici_id, string kullanici_tip, string sayfa)
    {
        string ka = "adayioglu", parola = "q1w2e3R4.", org = "EGITIMOFISI";
        string start = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
        start += "<smspack ka=\"" + xmlEncode(ka) + "\" pwd=\"" + xmlEncode(parola) + "\" org=\"" + xmlEncode(org) + "\">";

        string body = "<mesaj><metin>";
        body += xmlEncode(mesaj);
        body += "</metin><nums>";
        foreach (String s in numaralar)
        {
            body += xmlEncode(s) + ",";
        }
        body += "</nums></mesaj>";

        string end = "</smspack>";

        WebClient wc = new WebClient();
        string postData = start + body + end;
        wc.Headers.Add("Content-Type", "text/xml; charset=UTF-8");
        // Apply ASCII Encoding to obtain the string as a byte array.
        byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        byte[] responseArray = wc.UploadData("https://smsgw.mutlucell.com/smsgw-ws/sndblkex", "POST", byteArray);
        String response = Encoding.UTF8.GetString(responseArray);

        cumlecalistirSql("insert into tx_smsHareket values ('" + kullanici_id + "','" + kullanici_tip + "','" + numaralar[0] + "','" + mesaj + "','" + sayfa + "',getdate() )", "", "");

        return response;
    }
    private static String xmlEncode(String s)
    {
        s = s.Replace("&", "&amp;");
        s = s.Replace("<", "&lt;");
        s = s.Replace(">", "&gt;");
        s = s.Replace("'", "&apos;");
        s = s.Replace("\"", "&quot;");
        return s;
    }
}

