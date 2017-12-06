using Models;
using System;
using System.Collections.Generic;

namespace Calculations
{
    /// <summary>
    /// The philosophy of this classis to be able to EXPANDABILITY without affecting current the current code base.
    ///     NEW HOME CONSOLE boxes might send additional for validation in the future but it CAN'T affect the current code base.
    /// </summary>
    public class ValidateColors
    {
        private Char delimiter = ','; // Delimiter for p_arryChips  NOTE: Can add a new property to Chip p_Chip and make this dynamic

        /// <summary>
        /// This is the method PRIMARY validator that has been used for the last 5 year.
        /// </summary>
        /// <param name="p_Chip">This came from database</param>
        /// <param name="p_lstColors">This came from database. List of valid colors. TODO THIS SHOULD BE A STATIC CLASS used by ALL callers so doesnt have to be passed-in and reloaded each time</param>
        /// <param name="p_arryChips">This came from Home Securit Console</param>
        /// <param name="p_CurrentStatus">This came from Home Securit Console</param>
        /// <returns></returns>
        public bool ValidateFromConsole(Chip p_Chip, List<Models.Colors> p_lstColors, string[] p_arryChips, string p_CurrentStatus)
        {
            if (!String.IsNullOrEmpty(p_CurrentStatus))
            {
                // Check that prior status should come before CurrentStatus in "priority"
                //  Since p_Chip.CurrentStatus came from db & parameter p_CurrentStatus was sent from HOME CONSOLE,
                //      we have all the info required for a secuirty check.
            }
            if (!ValidateChipColors(p_arryChips, p_lstColors))
            {
                return false;
            }
            if (!ValidateColorsOnLeftAndRight(p_Chip.ChipColorLeft, p_Chip.ChipColorRight, p_arryChips))
            {
                return false;
            }

            if (p_Chip.NumberOfChips == 3) // Code Challenge specifies 3 
            {
                switch (p_Chip.NumberOfColorsPerChip)
                {
                    case 2:
                        return Validate3ChipWith2Colors(p_arryChips);
                    case 3:
                        // Bill Gates wants 3 for extra security.  Just validate in the Chip class and doesn't affect anything else 
                        break;
                    case 4:
                        // The Empire State Building wants even more security.  Just validate in the Chip class and doesn't affect anything else 
                        break;
                    default:
                        throw new Exception();
                }
            }
            else
            {
                // NASA wants more then 3 chips for the ultimate security.  Just validate in the Chip class and doesn't affect anything else  
                return ValidateGreaterThen3ChipsWith2Colors(p_arryChips);
            }

            return true;
        }

        /// <summary>
        /// A NEW home console is sending the yyyymmddHHMMSSmiliseconds and although it needs to be validated,
        ///     it cant affect ANY prior code.
        /// </summary>
        /// <param name="p_Chip">This came from database</param>
        /// <param name="p_lstColors">This came from database. List of valid colors. TODO THIS SHOULD BE A STATIC CLASS used by ALL callers so doesnt have to be passed-in and reloaded each time</param>
        /// <param name="p_arryChips">This came from Home Securit Console</param>
        /// <param name="p_CurrentStatus">This came from Home Securit Console</param>
        /// <param name="p_yyyymmddHHMMSSmiliseconds">This came from Home Securit Console and is a NEW input for a NEW kind of console</param>
        /// <returns></returns>
        public bool ValidateFromConsole(Chip p_Chip, List<Models.Colors> p_lstColors, string[] p_arryChips, string p_CurrentStatus, string p_yyyymmddHHMMSSmiliseconds)
        {
            if (!ValidateyyyymmddHHMMSSmiliseconds(p_yyyymmddHHMMSSmiliseconds))
            {
                return false;
            }
            return ValidateFromConsole(p_Chip, p_lstColors, p_arryChips, p_CurrentStatus);
        }






        /// <summary>
        /// At a minimum, 
        ///     the LEFT CIRCLE's color must match the FIRST chip's color and 
        ///     the RIGHT CIRCLE's color must match the LAST chip's color
        /// </summary>
        /// <param name="p_ChipColorLeft"></param>
        /// <param name="p_ChipColorRight"></param>
        /// <param name="p_arryChips"></param>
        /// <returns></returns>
        private bool ValidateColorsOnLeftAndRight(string p_ChipColorLeft, string p_ChipColorRight, string[] p_arryChips)
        {
            if (p_arryChips[0].Split(delimiter)[0] != p_ChipColorLeft || p_arryChips[p_arryChips.Length - 1].Split(delimiter)[1] != p_ChipColorRight)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate ALL colors sent by HOME CONSOLE to make sure payload was not intercepted along the way by hacker theif
        /// </summary>
        /// <param name="p_arryChips"></param>
        /// <param name="p_Colors">TODO THIS SHOULD BE A STATIC CLASS used by ALL callers so doesnt have to be passed-in and reloaded each time</param>
        /// <returns></returns>
        private bool ValidateChipColors(string[] p_arryChips, List<Models.Colors> p_lstColors)
        {
            for (int i = 0; i < p_arryChips.Length; i++)
            {
                System.Console.Write(p_arryChips[i] + "{0}", i < p_arryChips.Length - 1 ? " " : "");

                String[] color = p_arryChips[i].Split(delimiter);
                foreach (string SingleChipColor in color)
                {
                    bool IsFoundColor = false;
                    //Console.WriteLine(s0);
                    foreach (Colors colr in p_lstColors)
                    {
                        if (SingleChipColor == colr.Color)
                        {
                            IsFoundColor = true;
                            break;
                        }
                    }
                    if (!IsFoundColor)
                    {
                        return false;
                    }

                }
            }
            return true;
        }


        /// <summary>
        /// Speed is essential so for 3 chips senario validate color sequence quickly 
        ///     (we don't have to perform LOOP as in ValidateGreaterThen3ChipsWith2Colors() below).
        /// Previously validated the LEFT & RIGHT side circles so do not repeat here.
        /// </summary>
        /// <param name="p_arryChips"></param>
        /// <returns></returns>
        private bool Validate3ChipWith2Colors(string[] p_arryChips)
        {
            var c0 = p_arryChips[0].Split(delimiter); // First chip
            var c1 = p_arryChips[1].Split(delimiter); // Second chip
            var c2 = p_arryChips[2].Split(delimiter); // Third chip

            if (c0[1] == c1[0] && c1[1] == c2[0]) // Chips sequence of colors must match
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Requirements EXPANDED for >3 chips so here we are going to perform a LOOP to validate color sequence.
        /// Previously validated the LEFT & RIGHT side circles so do not repeat here.
        /// </summary>
        /// <param name="p_arryChips"></param>
        /// <returns></returns>
        private bool ValidateGreaterThen3ChipsWith2Colors(string[] p_arryChips)
        {

            return true;
        }

        private bool ValidateyyyymmddHHMMSSmiliseconds(string p_yyyymmddHHMMSSmiliseconds)
        {
            return true;
        }

    }
}
