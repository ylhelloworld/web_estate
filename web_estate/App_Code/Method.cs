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
using MongoDB.Bson.Serialization;
using System.Text;
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

            //Input Information 
            BsonDocument doc_in = BsonSerializer.Deserialize<BsonDocument>(json);



            //数据处理 
            string str_user_name = "User Name:" + doc_in["user_name"].ToString(); 



            //Output Information
            BsonDocument doc = new BsonDocument();
            doc.Add(new BsonElement("state", "1"));
            doc.Add(new BsonElement("info", "connect successful!"));
            doc.Add(new BsonElement("input", doc_in.ToString()));
            doc.Add(new BsonElement("user_info", str_user_name));

            

        

            return doc.ToString(); 
        }
        public string get_input_info(string json)
        { 
            BsonDocument doc_in = BsonSerializer.Deserialize<BsonDocument>(json);
            

            BsonDocument doc = new BsonDocument();
            doc.Add(new BsonElement("state", "1"));
            doc.Add(new BsonElement("info", "connect successful!"));
            doc.Add(new BsonElement("inupt", doc_in.ToString()));
           
            return doc.ToString(); 
        }
    }
  
