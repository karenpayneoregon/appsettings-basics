using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SqlServerConnectionLibrary.Preparation
{
    public class JSonHelper
    {
        /// <summary>
        /// Deserialize a concrete class instance
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="json">string representation of object</param>
        /// <returns>Instance of object from json</returns>
        public static T JSonToObject<T>(string json) => JsonSerializer.Deserialize<T>(json);

        /// <summary>
        /// Deserialize a list
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="json">string representation of object</param>
        /// <returns>List of object from json</returns>
        public static List<T> JSonToList<T>(string json) => JsonSerializer.Deserialize<List<T>>(json);

        /// <summary>
        /// Serialize a list to a file
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="sender">Type to serialize</param>
        /// <param name="fileName">File json to this file</param>
        /// <param name="format">true to format json, otherwise no formatting</param>
        /// <returns>Value Tuple, on success return true/null, otherwise false and the exception thrown</returns>
        public static (bool result, Exception exception) JsonToListFormatted<TModel>(List<TModel> sender, string fileName, bool format = true)
        {

            try
            {

                var options = new JsonSerializerOptions { WriteIndented = true, };
                File.WriteAllText(fileName, JsonSerializer.Serialize(sender, format ? options : null));

                return (true, null);

            }
            catch (Exception e)
            {
                return (false, e);
            }

        }
        /// <summary>
        /// Serialize object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sender"></param>
        /// <param name="fileName">file to write json into</param>
        /// <param name="format">True to indent json, false not to indent</param>
        /// <returns>success, exception if failure</returns>
        public static (bool result, Exception exception) JsonToFormatted<T>(T sender, string fileName, bool format = true)
        {

            try
            {

                var options = new JsonSerializerOptions { WriteIndented = true, };
                File.WriteAllText(fileName, JsonSerializer.Serialize(sender, format ? options : null));

                return (true, null);

            }
            catch (Exception e)
            {
                return (false, e);
            }

        }
    }
}