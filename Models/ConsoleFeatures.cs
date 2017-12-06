//////using static Models.Enumss;

////using static Models.Enumss;

////namespace Models
////{
////    public class ConsoleFeatures
////    {

////        public string ConsoleID { get; set; }

////        public string ChipColorLeft { get; set; }
////        public string ChipColorRight { get; set; }

////        public Status CurrentStatus { get; set; } // Defined in Enums class
////        public Status LastStatus { get; set; } // Defined in Enums class

////        /// <summary>
////        /// during technician setup or testing
////        /// </summary>
////        public bool IsInTestMode; // Defaults to false

////        /// <summary>
////        ///  Security of Pinging service
////        ///  Need to continously check if home console is sending signal to home receiver.
////        ///      This possible would be a Job Agent database  function continously running.
////        ///      Ping home base every ## seconds
////        ///      Beyond scope of what can be written.
////        ///          Would have to have table with continously running Job Agent monitoring last time ping was submitted. 
////        ///          Example:
////        ///              Supposed to ping home every ## seconds.  Haven't heard from the console in ## + 1 seconds. 
////        /// </summary>
////        /// 
////        private int _NumberOfTimesPerMinuteConsoleSignalsHome = 30;
////        public int NumberOfTimesPerMinuteConsoleSignalsHome  { get { return _NumberOfTimesPerMinuteConsoleSignalsHome; } set { _NumberOfTimesPerMinuteConsoleSignalsHome = value; } }

////        /// <summary>
////        /// Can the chips only be replace in ONE manner of the board.
////        ///      Or can the chips be "flipped" and work just as well?
////        ///      Example:
////        ///          The first chip is red on left-side & Green on right-side.  Can it be flipped?
////        ///                  Can the chip be flipped and the Green can equally fit on left-side and with the red on right-side?
////        /// </summary>
////        public string ChipCanFlip { get; set; } // Defaults to false

////        /// <summary>
////        /// The secuirty panel might be for a "small" dwelling and only requires THREE chips irregardless of bi, tri, or quad color.
////        ///      Move the panel to an office building and that THREE chips can become (i.e.) EIGHT chips.
////        /// </summary>
////        private int _NumberOfChips = 3;
////        public int NumberOfChips { get { return _NumberOfChips; } set { _NumberOfChips = value; } }

////        /// <summary>
////        /// The bi-colored chips are great, makes life real easy since there are only 2 colors.  We might not want to actually hardcode only for bi-colored colors.
////        ///      Next year, are the requirements going to change and ask us to use TRI-Colored chips.
////        ///          Programmers have got to allow for that.
////        /// </summary>
////        private int _NumberOfColorsPerChip = 3;
////        public int NumberOfColorsPerChip { get { return _NumberOfColorsPerChip; } set { _NumberOfColorsPerChip = value; } }





////    }
////}
