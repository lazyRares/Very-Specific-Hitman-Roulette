using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Roulette
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Do You Want To See Your Profile, Or Create One? (Y/N)");
        string answerProfile = Console.ReadLine();

        if (answerProfile.Equals("Y", StringComparison.OrdinalIgnoreCase))
        {
            MasteryAndContent mastery = new MasteryAndContent();
            mastery.AskInfo();
        }

        Randomization randomizer = new Randomization();
        randomizer.ChooseSpin();
    }
}
