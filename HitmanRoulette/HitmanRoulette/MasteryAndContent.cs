using System.Diagnostics.Metrics;
using System.Net.Mime;

class MasteryAndContent
{
    public string Username()
    {
        String username = "";
        try
        {
            Console.WriteLine("Enter your Username");
            username = Console.ReadLine();
            if (username.Equals("", StringComparison.OrdinalIgnoreCase))
            {
                username = "None";
            }
        }
        catch (Exception ex)
        {
            username = "None";
        }

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
        bool trinityPack = false;
        bool undyingPack = false;
        bool disruptorPack = false;
        bool dropPack = false;
        bool splitterPack = false;
        bool bankerPack = false;
        bool bruceLeePack = false;


        if (File.Exists($"../../txt/Profiles/{username}_Content.txt"))
        {
            string contentType = "Nothing";
            int counter = 0;
            StreamReader readerContent = new StreamReader($"../../txt/Profiles/{username}_Content.txt");

            for (int i = 0; i < 11; i++)
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
                if (counter == 5)
                {
                    contentType = "Trinity Pack";
                }
                if (counter == 6)
                {
                    contentType = "The Undying Pack";
                }
                if (counter == 7)
                {
                    contentType = "The Disruptor Pack";
                }
                if (counter == 8)
                {
                    contentType = "The Drop Pack";
                }
                if (counter == 9)
                {
                    contentType = "The Splitter Pack";
                }
                if (counter == 10)
                {
                    contentType = "The Banker Pack";
                }
                if (counter == 11)
                {
                    contentType = "The Bruce Lee Pack";
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

            Console.WriteLine("Do you have the Trinity Pack? (Y/N)");
            string trinityString = Console.ReadLine();

            if (trinityString.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                trinityPack = true;
            }
            else
            {
                trinityPack = false;
            }

            Console.WriteLine("Do you have The Undying Pack? (Y/N)");
            string undyingString = Console.ReadLine();

            if (undyingString.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                undyingPack = true;
            }
            else
            {
                undyingPack = false;
            }

            Console.WriteLine("Do you have The Disruptor Pack? (Y/N)");
            string disruptorString = Console.ReadLine();

            if (disruptorString.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                disruptorPack = true;
            }
            else
            {
                disruptorPack = false;
            }

            Console.WriteLine("Do you have The Drop Pack? (Y/N)");
            string dropString = Console.ReadLine();

            if (dropString.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                dropPack = true;
            }
            else
            {
                dropPack = false;
            }

            Console.WriteLine("Do you have The Splitter Pack? (Y/N)");
            string splitterString = Console.ReadLine();

            if (dropString.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                splitterPack = true;
            }
            else
            {
                splitterPack = false;
            }

            Console.WriteLine("Do you have The Banker Pack? (Y/N)");
            string bankerString = Console.ReadLine();

            if (bankerString.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                bankerPack = true;
            }
            else
            {
                bankerPack = false;
            }

            Console.WriteLine("Do you have The Bruce Lee Pack? (Y/N)");
            string bruceLeeString = Console.ReadLine();

            if (bruceLeeString.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                bruceLeePack = true;
            }
            else
            {
                bruceLeePack = false;
            }



            for (int i = 0; i < 2; i++)
            {
                StreamWriter writerContent = new StreamWriter($"../../txt/Profiles/{username}_Content.txt");

                writerContent.WriteLine(sevenDeadly);
                writerContent.WriteLine(deluxe);
                writerContent.WriteLine(concreteArt);
                writerContent.WriteLine(makeshiftPack);
                writerContent.WriteLine(trinityPack);
                writerContent.WriteLine(undyingPack);
                writerContent.WriteLine(disruptorPack);
                writerContent.WriteLine(dropPack);
                writerContent.WriteLine(splitterPack);
                writerContent.WriteLine(bankerPack);
                writerContent.WriteLine(bruceLeePack);

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
                Console.Write($"Your Mastery on ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{allMaps[i]} ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($"is ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{masteryLevel[i]}!");
                Console.ForegroundColor = ConsoleColor.Gray;
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

        for (int i = 0; i < 10; i++)
        {
            string data = readerContent.ReadLine();
            bool dataBool = Convert.ToBoolean(data);

            contentList.Add(dataBool);
            counter++;
        }
        return contentList;
    }
}