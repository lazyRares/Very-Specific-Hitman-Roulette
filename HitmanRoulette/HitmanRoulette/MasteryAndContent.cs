using System.Diagnostics.Metrics;
using System.Net.Mime;

class MasteryAndContent
{
    public string Username()
    {
        Console.WriteLine("Enter your Username\n");
        String username = Console.ReadLine();

        return username;
    }
    public void AskInfo()
    {


        string username = Username();

        List<bool> contentList = new List<bool>();

        bool sevenDeadly = false;
        bool deluxe = false;
        bool concreteArt = false;
        bool makeshiftPack = false;


        if (File.Exists($"../../txt/Profiles/{username}_Content.txt"))
        {
            string contentType = "Nothing";
            int counter = 0;
            StreamReader readerContent = new StreamReader($"../../txt/Profiles/{username}_Content.txt");

            for (int i = 0; i < 4; i++)
            {
                counter++;

                string data = readerContent.ReadLine();
                bool dataBool = Convert.ToBoolean(data);

                if (counter == 1)
                {
                    contentType = "Seven Deadly Sins";
                }
                if (counter == 2)
                {
                    contentType = "Hitman 3 Deluxe Edition";
                }
                if (counter == 3)
                {
                    contentType = "Concrete Art Content Pack";
                }
                if (counter == 4)
                {
                    contentType = "Makeshift Weaponry Content Pack";
                }

                contentList.Add(dataBool);
                Console.WriteLine($"{contentType} Content Status is {contentList[i]}!");
            }
        }
        else
        {
            Console.WriteLine("Do you have Seven Deadly Sins? (Y/N)");
            string sevenString = Console.ReadLine();

            if (sevenString.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                sevenDeadly = true;
            }
            else
            {
                sevenDeadly = false;
            }

            Console.WriteLine("Do you have Hitman 3 Deluxe? (Y/N)");
            string deluxeString = Console.ReadLine();

            if (deluxeString.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                deluxe = true;
            }
            else
            {
                deluxe = false;
            }

            Console.WriteLine("Do you have the Street Art Weapon Pack? (Y/N)");
            string concreteString = Console.ReadLine();

            if (concreteString.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                concreteArt = true;
            }
            else
            {
                concreteArt = false;
            }

            Console.WriteLine("Do you have the Makeshift Weapon Pack? (Y/N)");
            string makeshiftString = Console.ReadLine();

            if (makeshiftString.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                makeshiftPack = true;
            }
            else
            {
                makeshiftPack = false;
            }


            for (int i = 0; i < 2; i++)
            {
                StreamWriter writerContent = new StreamWriter($"../../txt/Profiles/{username}_Content.txt");

                writerContent.WriteLine(sevenDeadly);
                writerContent.WriteLine(deluxe);
                writerContent.WriteLine(concreteArt);
                writerContent.WriteLine(makeshiftPack);

                writerContent.Close();
            }
        }

        //MASTERY BELOW HERE

        List<String> allMaps = new List<String>();
        List<float> masteryLevel = new List<float>();

        StreamReader readerMapMastery = new StreamReader("../../txt/AllMapsMastery.txt");

        for (int i = 0; i < 23; i++)
        {
            string data = readerMapMastery.ReadLine();
            allMaps.Add(data);
        }


        if (File.Exists($"../../txt/Profiles/{username}_Mastery.txt"))
        {
            StreamReader readerMastery = new StreamReader($"../../txt/Profiles/{username}_Mastery.txt");

            for (int i = 0; i < 23; i++)
            {
                string data = readerMastery.ReadLine();
                int dataInt = Convert.ToInt32(data);

                masteryLevel.Add(dataInt);
                Console.WriteLine($"Your Mastery on {allMaps[i]} is {masteryLevel[i]}!");
            }
        }
        else
        {
            StreamWriter writerMastery = new StreamWriter($"../../txt/Profiles/{username}_Mastery.txt");

            int counterMap = 0;

            for (int i = 0; i < allMaps.Count(); i++)
            {
                Console.WriteLine($"What Is Your Mastery Level On {allMaps[i]}?");
                counterMap++;

                float masteryLevelNew = Convert.ToInt32(Console.ReadLine());
                writerMastery.WriteLine(masteryLevelNew);

                if (counterMap == 7 || counterMap == 21)
                {
                    if (masteryLevelNew > 5)
                    {
                        Console.WriteLine("On This Map, Mastery Can't Be Higher Than 5");
                        Environment.Exit(0);
                    }
                }
                else if (counterMap == 23)
                {
                    if (masteryLevelNew > 100)
                    {
                        Console.WriteLine("In Freelancer, Mastery Can't Be Higher Than 100");
                        Environment.Exit(0);
                    }
                }
                else if (masteryLevelNew > 20 && counterMap != 23)
                {
                    Console.WriteLine("Can't Be Higher Than 20");
                    Environment.Exit(0);
                }
            }
            writerMastery.Close();
        }
    }

    public List<int> ReturnMastery(string usernamePassed)
    {
        int counter = 0;
        List<int> masteryLevel = new List<int>();
        StreamReader readerMastery = new StreamReader($"../../txt/Profiles/{usernamePassed}_Mastery.txt");

        for (int i = 0; i < 23; i++)
        {
            string data = readerMastery.ReadLine();
            int dataInt = Convert.ToInt32(data);

            masteryLevel.Add(dataInt);
            counter++;
        }
        return masteryLevel;
    }
    public List<bool> ReturnContent(string usernamePassed)
    {
        int counter = 0;
        List<bool> contentList = new List<bool>();
        StreamReader readerContent = new StreamReader($"../../txt/Profiles/{usernamePassed}_Content.txt");

        for (int i = 0; i < 4; i++)
        {
            string data = readerContent.ReadLine();
            bool dataBool = Convert.ToBoolean(data);

            contentList.Add(dataBool);
            counter++;
        }
        return contentList;
    }
}