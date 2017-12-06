using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace DataAccessQueries
{
    public class ChipQueries
    {

        #region Constructors
        #endregion

        #region Queries

        public Models.Chip GetChipByConsoleID(string p_ConsoleID)
        {
            var Chip = ReadJSONFile(); // TODO Convert to LINQ
            foreach (Models.Chip chip in Chip)
            {
                if (chip.ConsoleID == p_ConsoleID)
                {
                    return chip;
                }
            }
            return new Models.Chip();
        }


        #endregion


        #region In REAL life this would be in DataAccessCore 

        /// <summary>
        /// NOTE: TODO In REAL life this would be in DataAccessCore
        /// Never directly call DataAccessCore from anywhere but DataAccessQueries
        /// </summary>
        public List<Models.Chip> ReadJSONFile()
        {
            try
            {
                string json = File.ReadAllText(@"c:\temp\Chips.JSON");
                //var Chip = JsonConvert.DeserializeObject<List<Chip>>(json);
                var Chip = JsonConvert.DeserializeObject<List<Models.Chip>>(json);
                return Chip;
            }
            catch (System.Exception ex)
            {
                throw; // TODO error logging goes here instead of throw
            }
            return new List<Models.Chip>();
        }

        #endregion

    }
}
