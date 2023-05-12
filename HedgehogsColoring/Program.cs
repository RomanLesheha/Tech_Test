using System;

namespace HedgehogsColoring
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] hedgehogs = { 5, 2, 10 };
            int desiredColor = 1;
            int minMeetings = HedgehogsColoring.MinMeetings(desiredColor, hedgehogs);
            Console.WriteLine(minMeetings);
        }

    }
    
}
