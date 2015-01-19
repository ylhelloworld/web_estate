<%@ WebHandler Language="C#" Class="response" %>

using System;
using System.Web; 
using System.Web.Services;
using System.Collections.Generic;
using System.Reflection;
using MongoDB.Bson;

public class response : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {

        BsonDocument doc = new BsonDocument();
        if (context.Request.QueryString["class"] != null && context.Request.QueryString["method"] != null && context.Request.QueryString["input"] != null)
        {

            string str_class = context.Request.QueryString["class"].ToString();
            string str_method = context.Request.QueryString["method"].ToString();
            string str_input = context.Request.QueryString["param"].ToString();

            try
            {
                Type reflect_type = Assembly.Load("App_Code").GetType(str_class);
                object reflect_acvtive = Activator.CreateInstance(reflect_type, null);

                MethodInfo method_info = reflect_type.GetMethod(str_method);
                string result = (string)method_info.Invoke(reflect_acvtive, new object[] { str_input });

                context.Response.Write(result);
            }
            catch (Exception)
            {
                doc.Add(new BsonElement("state", "0"));
                doc.Add(new BsonElement("info", "class or method or prama is wrong!"));
                context.Response.Write(doc.ToString());
            }

        }
        else
        {
            doc.Add(new BsonElement("state", "0"));
            doc.Add(new BsonElement("info", "class or method or param is empty!"));
            context.Response.Write(doc.ToString());
        }
       
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}