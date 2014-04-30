using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq; 
using System.Web.Services;
using System.Collections.Generic;
using System.Reflection;
using MongoDB.Bson;
public partial class response : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BsonDocument doc = new BsonDocument();
        if (Request.QueryString["class"] != null && Request.QueryString["method"] != null&& Request.QueryString["param"] != null)
        {

            string str_class = Request.QueryString["class"].ToString();
            string str_method = Request.QueryString["method"].ToString();
            string str_param = Request.QueryString["param"].ToString();

           
            try
            {
                Type reflect_type = Assembly.Load("App_Code").GetType(str_class);
                object reflect_acvtive = Activator.CreateInstance(reflect_type, null);

                MethodInfo method_info = reflect_type.GetMethod(str_method);
                string result = (string)method_info.Invoke(reflect_acvtive, new object[] {str_param});

                Response.Write(result);
            }
            catch (Exception)
            {
                doc.Add(new BsonElement("state", "0"));
                doc.Add(new BsonElement("info", "class or method is wrong!"));
                Response.Write(doc.ToString());
            }

        }
        else
        { 
            doc.Add(new BsonElement("state", "0"));
            doc.Add(new BsonElement("info", "class or method is empty!"));
            Response.Write(doc.ToString());
        }
       
    }
}


