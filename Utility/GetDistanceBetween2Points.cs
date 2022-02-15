using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;

namespace Ecommerce.Utility
{
    public class GetDistanceBetween2Points
    {
        static private string GetXmlString(XmlDocument xmlDoc)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            xw.Formatting = System.Xml.Formatting.Indented;
            xmlDoc.WriteTo(xw);
            return sw.ToString();
        }

        /// <summary>
        /// for ex :  https://maps.googleapis.com/maps/api/distancematrix/json?origins=25.859960+85.786339&destinations=25.804744+85.738462&mode=driving&transit_mode=bus&key=AIzaSyDSFMY227bo8wHuGqaaKARM099ql8x3Kik
        /// </summary>
        /// <param name="Source">Address or Latitude and Longitude --> insteed of (space) put (+) </param>
        /// <param name="Destination">Address or Latitude and Longitude --> insteed of (space) put (+) </param>
        /// <returns></returns>
        static public int GetDistance(string Source, string Destination, GeoMapTransitMode.Mode mode = GeoMapTransitMode.Mode.driving, GeoMapTransitMode.Transit_Mode transit_Mode = GeoMapTransitMode.Transit_Mode.bus)
        {
            string strErr = "";
            try
            {
                string createdURL = "";
                //createdURL = "https://maps.googleapis.com/maps/api/distancematrix/json?origins=Hari+Om+Commercial+Complex+Exhibition+Road+Patna&destinations=Danapur+Station+Patna&mode=transit&transit_mode=train&key=AIzaSyDSFMY227bo8wHuGqaaKARM099ql8x3Kik";
                //createdURL = "https://maps.googleapis.com/maps/api/distancematrix/json?origins=25.859960+85.786339&destinations=25.804744+85.738462&mode=driving&transit_mode=bus&key=AIzaSyDSFMY227bo8wHuGqaaKARM099ql8x3Kik";
                //createdURL = "https://maps.googleapis.com/maps/api/distancematrix/json?origins=25.859960+85.786339&destinations=25.804744+85.738462&mode=transit&transit_mode=bus&key=AIzaSyDSFMY227bo8wHuGqaaKARM099ql8x3Kik";

                createdURL = "https://maps.googleapis.com/maps/api/distancematrix/json?origins=" + Source + "&destinations=" + Destination + "&mode=" + mode + "&transit_mode=" + transit_Mode + "&key=AIzaSyDSFMY227bo8wHuGqaaKARM099ql8x3Kik";

                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(createdURL);
                HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                StreamReader respStreamReader = new StreamReader(myResp.GetResponseStream());
                string responseString = respStreamReader.ReadToEnd();
                respStreamReader.Close();
                myResp.Close();


                //Convert Json --> xml --> Dataset            
                XmlDocument doc = JsonConvert.DeserializeXmlNode(responseString, "root");
                string xmlString = GetXmlString(doc);
                DataSet ds = new DataSet();
                //ds.ReadXml(xmlString);
                byte[] buffer = Encoding.UTF8.GetBytes(xmlString);
                using (MemoryStream stream = new MemoryStream(buffer))
                {
                    XmlReader reader = XmlReader.Create(stream);
                    ds.ReadXml(reader);
                }

                #region MyRegion
                ////var result = JsonConvert.DeserializeObject<T>(responseString);
                //strErr = responseString;
                //var json_serializer = new JavaScriptSerializer();
                //var routes_list = (IDictionary<string, object>)json_serializer.DeserializeObject(responseString);

                //string s = "";
                ////foreach (KeyValuePair<string, object> kvp in routes_list.Values)
                ////{
                ////    s += kvp.Key + "--" + kvp.Value + "\n";                    
                ////}

                //string json = responseString;
                //var data = (JObject)JsonConvert.DeserializeObject(json);

                //string jsonString = "{\"displayName\":\"Alex Wu\",\"signInNames\":[{\"type\":\"emailAddress\",\"value\":\"AlexW@example.com\"},{\"type\":\"emailAddress\",\"value\":\"AlexW2@example.com\"}]}";
                //JObject jObject = JObject.Parse(jsonString);
                //string displayName = (string)jObject.SelectToken("displayName");
                //string type = (string)jObject.SelectToken("signInNames[0].type");
                //string value = (string)jObject.SelectToken("signInNames[0].value");
                ////Console.WriteLine("{0}, {1}, {2}", displayName, type, value);
                //JArray signInNames = (JArray)jObject.SelectToken("signInNames");
                //foreach (JToken signInName in signInNames)
                //{
                //    type = (string)signInName.SelectToken("type");
                //    value = (string)signInName.SelectToken("value");
                //    //Console.WriteLine("{0}, {1}", type, value);
                //}


                //JObject jObject1 = JObject.Parse(json);
                //string destination_addresses = (string)jObject.SelectToken("destination_addresses");
                ////string type = (string)jObject.SelectToken("signInNames[0].type");
                //string distance = (string)jObject.SelectToken("elements[0].distance[0].text");
                ////string value = (string)jObject.SelectToken("signInNames[0].value");
                //////Console.WriteLine("{0}, {1}, {2}", displayName, type, value);
                ////JArray signInNames = (JArray)jObject.SelectToken("signInNames");
                ////foreach (JToken signInName in signInNames)
                ////{
                ////    type = (string)signInName.SelectToken("type");
                ////    value = (string)signInName.SelectToken("value");
                ////    Console.WriteLine("{0}, {1}", type, value);
                ////}

                //////if (strErr.Contains("Invalid Request"))
                //////if (strErr.Contains("Invalid") || strErr.Contains("Less"))
                ////if (strErr.Contains("LogID=") == false && strErr.Trim().Length != 19)
                ////{
                ////    //throw new Exception(strErr);
                ////    strErr = responseString;
                ////    return false;
                ////}
                ////else
                ////{
                ////    strErr = "Message Sent Successfully...";
                ////    return true;
                ////} 
                #endregion

                if (ds.Tables.Contains("distance"))
                {
                    //return Convert.ToInt32(ds.Tables["distance"].Rows[0]["text"].ToString());
                    return Convert.ToInt32(ds.Tables["distance"].Rows[0]["value"].ToString());
                }
                else
                    return -1;   
            }
            catch (Exception ex)
            {
                strErr = ex.Message;
                return -1;
            }
        }
    }
}