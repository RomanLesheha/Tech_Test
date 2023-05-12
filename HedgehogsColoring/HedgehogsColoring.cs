using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HedgehogsColoring
{
    public class HedgehogsColoring
    {
        public static int MinMeetings(int desiredColor, int[] hedgehogs)
        {
            if (hedgehogs.Length < 3)
            {
                // Масив містить менше трьох елементів
                return -1;
            }
            int[] colors = new int[3];
            int totalHedgehogs = 0; //загальна кількість їжачків

            for (int i = 0; i < 3; i++)
            {
                colors[i] = hedgehogs[i];
                totalHedgehogs += colors[i];
            }

            if (colors[desiredColor] == totalHedgehogs)
            {
                // Якщо усі їжачки вже одного кольору , то зустрічі непотрібні
                return 0;
            }

            int meeting = 0; // мінімальну кількість зустрічей, необхідних для зміни всіх їжачків у заданий колір

            while (colors[desiredColor] != totalHedgehogs)
            {
                // Знаходжу дві найблільші популяції їжачків
                int maxColor1 = 0;
                int maxColor2 = 0;

                
                for (int i = 0; i < colors.Length; i++)
                {
                    if (colors[i] > colors[maxColor1])
                    {
                        maxColor2 = maxColor1;
                        maxColor1 = i;
                    }
                    else if (colors[i] > colors[maxColor2])
                    {
                        maxColor2 = i;
                    }
                }

                int numMeetings = Math.Min(colors[maxColor1], colors[maxColor2]); //знаходжу мінімальну кількість зустрічів для двох найблільших популяцій 
                colors[maxColor1] -= numMeetings; //зменшую кількість першої популяції
                colors[maxColor2] -= numMeetings; //зменшую кількість другої популяції
                colors[3 - maxColor1 - maxColor2] += numMeetings; //збільшую кількість бажаної популяції

                totalHedgehogs -= 2* numMeetings;
                meeting += numMeetings;

                if (totalHedgehogs == 0)
                {
                    // Якщо їжачків вже не залишилось
                    return -1;
                }
            }

            return meeting;
        }
    }
}
