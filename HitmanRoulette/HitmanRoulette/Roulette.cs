using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Roulette
{
    public static void Main(String[] args)
    {

        bool finished = false;

        while (finished == false)
        {
            Console.WriteLine("Would You Like To Spin ? (Y/N)");
            String spinInput = Console.ReadLine();

            if (spinInput.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Do You Want To Create A Profile? (Y/N)");
                string answerProfile = Console.ReadLine();

                if (answerProfile.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    MasteryAndContent mastery = new MasteryAndContent();
                    mastery.AskInfo();
                }

                Randomization randomizer = new Randomization();
                randomizer.ChooseSpin();
            }
            else
            {
                finished = true;
            }
         }
        if (finished == true)
        {
            Console.WriteLine("Thanks For Playing!");
            Environment.Exit(2);
        }
    }
}
