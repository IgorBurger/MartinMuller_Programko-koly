using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Piškvorky
{
    
    internal class Model
    {
        
        public  bool CheckWin(Button[,] buttons) 
        {

            int SpaceCheck = 1;
            //Horizontal Check
            for (int i = 0; i < 3; i++) 
            {
                for (int j = 0; j < 2; j++)
                {
                    if (Convert.ToString(buttons[i, j].Content) == Convert.ToString(buttons[i, j + 1].Content)) 
                    {
                        if (buttons[i, j].Content != null)
                        {
                            SpaceCheck++;
                        }          
                    }
                }
                if (SpaceCheck == 3) 
                {
                    return true;
                }
                else 
                {
                    SpaceCheck = 1;
                }
            }

            SpaceCheck = 1;
            //Vertical Check
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (Convert.ToString(buttons[j, i].Content) == Convert.ToString(buttons[j + 1, i].Content))
                    {
                        if (buttons[j, i].Content != null)
                        {
                            SpaceCheck++;
                        }
                    }
                }
                if (SpaceCheck == 3)
                {
                    return true;
                }
                else
                {
                    SpaceCheck = 1;
                }
            }

            //Diagonal Check
            //FUJ HNUS ANI SI TO PROSÍM NEČTĚTE
            if (Convert.ToString(buttons[0, 0].Content) == Convert.ToString(buttons[1, 1].Content) && Convert.ToString(buttons[1, 1].Content) == Convert.ToString(buttons[2,2].Content)) 
            {
                if (buttons[1, 1].Content != null)
                {
                    return true;
                }
            }
            else if (Convert.ToString(buttons[0, 2].Content) == Convert.ToString(buttons[1, 1].Content) && Convert.ToString(buttons[1, 1].Content) == Convert.ToString(buttons[2, 0].Content)) 
            {
                if (buttons[1, 1].Content != null)
                {
                    return true;
                }
            }

            return false;

        }
    }
}
