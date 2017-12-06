using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace DataAccessQueries
{
    public class ColorsQueries : baseDataAccess
    {

        #region Queries

        public Models.Colors ValidateColor(string p_Color) // Not used because too inefficient
        {
            var colors = ReadJSONFile(); // TODO Convert to LINQ
            foreach (Models.Colors colr in colors)
            {
                if (colr.Color == p_Color)
                {
                    return colr;
                }
            }
            return new Models.Colors();
        }

        /// <summary>
        /// NOTE: TODO In REAL life this would be in DataAccessCore
        ///  Note: Never directly call DataAccessCore from anywhere but DataAccessQueries
        ///         so this has been created
        /// Never directly call DataAccessCore from anywhere but DataAccessQueries. 
        /// </summary>
        /// <param name="p_Color"></param>
        /// <returns></returns>
        public List<Models.Colors> GetAllColors()
        {
            var colors = ReadJSONFile(); // TODO Convert to LINQ
            return colors;
        }


        #endregion


        #region In REAL life this would be in DataAccessCore 

        /// <summary>
        /// NOTE: In REAL life this would be in DataAccessCore
        /// </summary>
        public List<Models.Colors> ReadJSONFile()
        {
            try
            {
                string json = File.ReadAllText(@"c:\temp\Colors.JSON");
                var colrs = JsonConvert.DeserializeObject<List<Models.Colors>>(json);
                return colrs;
            }
            catch (System.Exception ex)
            {
                throw; // TODO error logging goes here instead of throw
            }
            return new List<Models.Colors>();
        }

        #endregion

    }
}
