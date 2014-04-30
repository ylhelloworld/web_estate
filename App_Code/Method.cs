using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using MongoDB.Bson;
    /// <summary>
    ///Method 的摘要说明
    /// </summary>
    public class UserMethod
    {
        public UserMethod()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public string get_user_info(string json)
        {
            BsonDocument doc = new BsonDocument();
            doc.Add(new BsonElement("state", "1"));
            doc.Add(new BsonElement("info", "connect successful!"));

            doc.Add(new BsonElement("user_name", "yanglong"));
            doc.Add(new BsonElement("user_no", "CY120467"));

            return doc.ToString(); 
        }
        public string get_param_info(string json)
        {
            BsonDocument doc = new BsonDocument();
            doc.Add(new BsonElement("state", "1"));
            doc.Add(new BsonElement("info", "connect successful!"));

            if (json.Trim().Length > 2)
            {
                doc.Add("param_info", json);
            }
            return doc.ToString(); 
        }
    }
  
