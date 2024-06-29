using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Roulette
{
    public static void Main(String[] args)
    {
        string answerProfile = "";

        bool finished = false;
        bool once = false;

        while (finished == false)
        {
            String spinInput = "";

            try
            {
                Console.WriteLine("Would You Like To Spin ? (Y/N)");
                spinInput = Console.ReadLine();
                if (!spinInput.Equals("Y", StringComparison.OrdinalIgnoreCase) && !spinInput.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    spinInput = "Y";
                }
            }
            catch (Exception e)
            {
                spinInput = "Y";
            }


            if (spinInput.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                if (once == false)
                {
                    try
                    {
                        Console.WriteLine("Do You Want To Create A Profile? (Y/N)");
                        answerProfile = Console.ReadLine();
                        
                    }
                    catch (Exception e)
                    {
                        answerProfile = "N";
                    }
                    once = true;
                }
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
