using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace GB.Models.Static
{
    public static class GBConvert
    {
        private static string format = "dd/MM/yyyy";
        private static CultureInfo provider = CultureInfo.InvariantCulture;

        /// <summary>Conevrti er retourne un objet dynamicjson en JObject </summary>
        public static JObject To_JObject(dynamic dObject)
        {
            return
                JsonConvert.DeserializeObject<JObject>(
                    JsonConvert.SerializeObject(dObject)
                );
        }
        /// <summary>Conevrti er retourne un objet dynamicjson en JObject </summary>
        public static JArray To_JArray(string dObject)
        {
            return
                JsonConvert.DeserializeObject<JArray>(dObject);
        }
        /// <summary>Conevrti er retourne un objet dynamicjson en JToken </summary>
        public static JToken To_JToken(string dObject)
        {
            return
                JsonConvert.DeserializeObject<JToken>(dObject);
        }

        /// <summary>Conevrti er retourne un objet en string </summary>
        public static string To_JavaScript(object dObject)
        {
            try
            {
                return
                    new JavaScriptSerializer().Serialize(dObject);
            }
            catch
            {
                return
                    string.Empty;
            }
        }

        /// <summary>Conevrti er retourne un objet en json string </summary>
        public static string To_JSONString(object Object)
        {
            return
                JsonConvert.SerializeObject(Object);
        }

        /// <summary>Conevrti er retourne un objet dynamicjson en Objetc </summary>
        public static object To_Object(dynamic dObject)
        {
            return
                new JavaScriptSerializer().Deserialize(
                    JsonConvert.SerializeObject(dObject),
                    typeof(object)
                );
        }
        public static T To_Object<T>(object Object)
        {
            return
                new JavaScriptSerializer().ConvertToType<T>(Object);
        }

        /// <summary>Conevrti et retourne un objet en dynamic </summary>
        public static dynamic To_Dynamic(object objet)
        {
            IDictionary<string, object> expando = new ExpandoObject();

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(objet.GetType()))
            {
                expando.Add(property.Name, property.GetValue(objet));
            }

            return expando as ExpandoObject;
        }

        /// <summary>Conevrti et retourne un objet en dynamic </summary>
        public static MemoryStream To_MemoryStream(Stream objet)
        {
            using (var memoryStream = new MemoryStream())
            {
                objet.CopyTo(memoryStream);

                return memoryStream;
            }
        }

        /// <summary>Convertir un byte[] en objet image </summary>
        public static Image To_Image(byte[] bytes)
        {
            return
                Image.FromStream(new MemoryStream(bytes));
        }

        /// <summary>Convertir un byte[] en chaine base64 </summary>
        public static string To_Base64Image(byte[] photo, string extension)
        {
            return
                string.Format(
                    "data:image/{0};base64,{1}",
                        extension,
                        Convert.ToBase64String(photo)
                );
        }

        /// <summary>Convertir un string en chaine base64 </summary>
        public static string To_Base64Image(string url_image)
        {
            return
                string.Format(
                    "data:image/{0};base64,{1}",
                    Path.GetExtension(url_image).Remove(0, 1), Convert.ToBase64String(
                                                                   File.ReadAllBytes(url_image)
                                                               )
                );
        }

        /// <summary>Convertir un Bitmap en chaine base64 </summary>
        public static string To_Base64Image(Bitmap image, string extension)
        {
            return
                string.Format(
                    "data:image/{0};base64,{1}",
                        extension,
                        Convert.ToBase64String(
                            To_ByteArray(image)
                        )
                );
        }

        /// <summary>Convertir un Bitmap en byte[] </summary>
        public static byte[] To_ByteArray(Bitmap image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                return ms.ToArray();
            }
        }

        /// <summary>Conversion d'une image en byte[] </summary>
        public static byte[] To_ByteArray(System.Drawing.Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                return ms.ToArray();
            }
        }

        public static byte[] To_ByteArray(Stream stream)
        {
            return
                To_MemoryStream(stream).ToArray();
        }

        /// <summary>COnverti un object en type_tredefini </summary>
        public static T To<T>(object objet)
        {
            return (T)objet;
        }

        /// <summary>COnverti un object JSON en type_tredefini </summary>
        public static T JSON_To<T>(string objet)
        {
            return
                JsonConvert.DeserializeObject<T>(objet);
        }

        /// <summary>COnverti un object JsonResult en DSNotification </summary>
        //public static DSNotification To_DSNotification(JsonResult objet)
        //{
        //    return
        //        To_Object<DSNotification>(
        //            (objet.Data as Dictionary<string, object>)["notification"]
        //        );
        //}

        /// <summary>Conversion d'un string en ByteArray </summary>
        public static byte[] To_ByteArray(string file)
        {
            return
                Encoding.ASCII.GetBytes(file);
        }

        /// <summary>Conversion d'un string en MemoryStream </summary>
        public static MemoryStream To_MemoryStream(string file)
        {
            return
                new MemoryStream(
                    To_ByteArray(file)
                );
        }

        /// <summary>Conversion d'une date en string en date C# </summary>
        public static DateTime To_DateTime(string date)
        {
            return
                DateTime.ParseExact(date, format, provider);
        }
    }
}