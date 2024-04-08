using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
class Randomization
{
    MasteryAndContent mastery = new MasteryAndContent();

    List<string> killsList = new List<string>();
    List<string> disguisesList = new List<string>();
    List<string> targetList = new List<string>();
    List<string> mapsList = new List<string>();
    List<String> previousTarget = new List<String>();

    List<string> elusiveList = new List<string>();
    List<string> elusiveMapList = new List<string>();

    int killsIssued = 0;
    int killsMastery = 0;
    int mapInt = 0;

    String freeRemove = "N";

    Random randomNumber = new Random();
    public void ChooseSpin()
    {
        string mapChosen = "";
        
        StreamReader readerMaps = new StreamReader($"../../txt/AllMaps.txt");

        for (int i = 0; i < 31; i++)
        {
            String data = readerMaps.ReadLine();
            mapsList.Add(data);
        }

        Console.WriteLine("Mode Selection:");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("1. Elusive Targets");
        Console.WriteLine("2. Regular");
        Console.ForegroundColor = ConsoleColor.Gray;
        int modeSelect = Int32.Parse(Console.ReadLine());
        // -------------------------------------------------------------------------- ELUSIVE MODE SELECT
        if (modeSelect == 1)
        {
            string elusiveChosen = "";
            int mapIntElusive = 0;

            StreamReader elusiveMapReader = new StreamReader($"../../txt/Elusives/ElusiveMapList.txt");
            StreamReader elusiveReader = new StreamReader($"../../txt/Elusives/Elusives.txt");

            for (int i = 0; i < 42; i++)
            {
                String data = elusiveMapReader.ReadLine();
                elusiveMapList.Add(data);
            }
            for (int i = 0; i < 42; i++)
            {
                String data = elusiveReader.ReadLine();
                elusiveList.Add(data);
            }

            Console.WriteLine("Would You Like To Choose an Elusive? (Y/N)");
            String manualElusive = Console.ReadLine();

            int elusiveInt= 0;

            if (manualElusive.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {

                Console.WriteLine("Which Elusive Would You Like? Type the respective number");
                Console.WriteLine("Available Elusive Targets are: \n");

                for (int i = 0; i < 42; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{i}: {elusiveList[i]}");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                Console.WriteLine("\n");


                elusiveInt = Convert.ToInt32(Console.ReadLine());
                elusiveChosen = elusiveList[elusiveInt];
                mapIntElusive = Int32.Parse(elusiveMapList[elusiveInt]);
                mapChosen = mapsList[mapIntElusive];
            }
            if (manualElusive.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                elusiveInt = randomNumber.Next(42);
                elusiveChosen = elusiveList[elusiveInt];
                mapIntElusive = Int32.Parse(elusiveMapList[elusiveInt]);
                mapChosen = mapsList[mapIntElusive];
            }

            Console.Write($"\nThe Elusive Target Chosen Was ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{elusiveChosen}!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"\nOn The Map: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{mapChosen} ");
            Console.ForegroundColor = ConsoleColor.Gray;

            int elusiveTargetAmount = 0;

            if (elusiveChosen.Equals("The Ex-Dictator") || elusiveChosen.Equals("The Surgeons") || elusiveChosen.Equals("The Deceivers"))
            {
                elusiveTargetAmount = 2;
            }
            else
            {
                elusiveTargetAmount = 1;
            }

            string elusiveName = "";

            switch (elusiveChosen)
            {
                case "The Forger":
                    elusiveName = "Sergei Larin";
                    break;

                case "The Congressman":
                    elusiveName = "Anthony L. Troutt";
                    break;

                case "The Prince":
                    elusiveName = "Adalrico Candelaria";
                    break;

                case "The Sensation":
                    elusiveName = "Jonathan Smythe";
                    break;

                case "The Gunrunner":
                    elusiveName = "Vito Đurić";
                    break;

                case "The Twin":
                    elusiveName = "Dylan Narváez";
                    break;

                case "The Wildcard":
                    elusiveName = "Gary Busey";
                    break;

                case "The Broker":
                    elusiveName = "Howard Moxon";
                    break;

                case "The Black Hat":
                    elusiveName = "Owen Wagner";
                    break;

                case "The Pharmacist":
                    elusiveName = "Nila Torvik";
                    break;

                case "The Fixer":
                    elusiveName = "Xander Haverfoek";
                    break;

                case "The Identity Thief":
                    elusiveName = "Brendan Conner";
                    break;

                case "The Ex-Dictator":
                    elusiveName = "Richard Ekwensi";
                    break;

                case "The Chef":
                    elusiveName = "Gabriel Santos";
                    break;

                case "The Angel Of Death":
                    elusiveName = "Etta Davis";
                    break;

                case "The Guru":
                    elusiveName = "Richard J. Magee";
                    break;

                case "The Food Critic":
                    elusiveName = "Wen Ts'ai";
                    break;

                case "The Chameleon":
                    elusiveName = "Richard M. Foreman";
                    break;

                case "The Blackmailer":
                    elusiveName = "Walter Williams";
                    break;

                case "The Warlord":
                    elusiveName = "Adeze Oijofor";
                    disguisesList.Add("Military Soldier"); // Adding Marrakesh Disguises Used On This Level + Her Machete
                    disguisesList.Add("Military Officer");
                    if (!killsList.Contains("Nne Obara's Machete"))
                    {
                        killsList.Add("Nne Obara's Machete");
                    }
                    break;

                case "The Surgeons":
                    elusiveName = "Pavel Frydel";
                    break;

                case "The Bookkeeper":
                    elusiveName = "Pertti Järnefelt";
                    break;

                case "The Paparazzo":
                    elusiveName = "Kieran Hudson";
                    break;

                case "The Badboy":
                    elusiveName = "Bartholomew Argus";
                    break;

                case "The Fugitive":
                    elusiveName = "Ji-Hu";
                    break;

                case "The Entertainer":
                    elusiveName = "Mr. Giggles";
                    break;

                case "The Undying":
                    elusiveName = "Mark Faba";
                    killsList.Add("The Krondstadt Pen");
                    break;

                case "The Revolutionary":
                    elusiveName = "Vicente Murillo";
                    break;

                case "The Appraiser":
                    elusiveName = "Miranda Jamison";
                    break;

                case "The Politician":
                    elusiveName = "Dame Barbara Elizabeth Keating";
                    break;

                case "The Undying Returns":
                    elusiveName = "Mark Faba";
                    break;

                case "The Serial Killer":
                    elusiveName = "The Censor";
                    break;

                case "The Stowaway":
                    elusiveName = "Jimmy Chen";
                    break;

                case "The Collector":
                    elusiveName = "Kody Haynes";
                    break;

                case "The Iconoclast":
                    elusiveName = "Joanne Bayswater";
                    break;

                case "The Liability":
                    elusiveName = "Terrence Chesterfield";
                    break;

                case "The Heartbreaker":
                    elusiveName = "Philo Newcombe";
                    break;

                case "The Procurers":
                    elusiveName = "Jack Roe / Robert Burk";
                    break;

                case "The Ascensionist":
                    elusiveName = "Allison Moretta";
                    break;

                case "The Rage":
                    elusiveName = "Sully Bowden";
                    break;

                case "The Drop":
                    elusiveName = "Alexios Laskaridis";
                    disguisesList.Add("Bodyguard");
                    if (!killsList.Contains("The Ornamental Pistol"))  // Adding Alexios' Bodyguard's Ornamental Pistol, Only If It Isn't Already Here.
                    {
                        killsList.Add("The Ornamental Pistol");
                    }
                    break;

                case "The Deceivers":
                    elusiveName = "Anthony L. Troutt";
                    break;
            }

            Console.WriteLine("\nDo You Want To Remove Free Items From The Possible Kills? (Y/N)");
            freeRemove = Console.ReadLine();

            Console.WriteLine($"You Will Have {elusiveTargetAmount} Target(s)!\n");

            StreamReader readerKills = new StreamReader($"../../txt/Kills{mapIntElusive}.txt");
            StreamReader readerDisg = new StreamReader($"../../txt/Disguises{mapIntElusive}.txt");
            StreamReader readerTarget = new StreamReader($"../../txt/Disguises{mapIntElusive}.txt");

            StreamReader readerKillsBroad = new StreamReader($"../../txt/KillsBroad.txt");

            //BROAD OR NOT

            List<int> masteryList = new List<int>();
            List<bool> contentList = new List<bool>();

            string username = "None";
            username = mastery.Username();

            int additions = 0;
            int counterMap = 0;

            masteryList = mastery.ReturnMastery(username);

            int lineCount = File.ReadLines($"../../txt/Kills{mapInt}.txt").Count();

            int mapItemAmount = 0;
            for (int i = 0; i < 21; i++)
            {
                String data = readerKillsBroad.ReadLine();
                killsList.Add(data);
            }

            for (int i = 0; i < lineCount; i++)
            {
                String data = readerKills.ReadLine();
                killsList.Add(data);
                mapItemAmount++;
            }

            while (killsIssued < elusiveTargetAmount)
            {
                int broadint = randomNumber.Next(0, 1);
                bool broad;
                if (broadint == 1)
                {
                    broad = true;
                }
                else
                {
                    broad = false;
                    killsMastery++;
                }
                if (killsMastery > 2)
                {
                    broad = true;
                }

                //LISTS FOR CONDITIONS

                if (broad == true)
                {

                    int killChosenInt = randomNumber.Next(21 + mapItemAmount);
                    String killChosen = killsList[killChosenInt];

                    killsList = killsList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();

                    if (killChosen == null || killChosen.Equals("") || killChosen.Equals("Suit"))
                    {
                        while (killChosen == null || killChosen.Equals("") || killChosen.Equals("Suit"))
                        {
                            killChosenInt = randomNumber.Next(21);
                            killChosen = killsList[killChosenInt];
                        }
                    }

                    if (killsIssued == 1)
                    {
                        if (elusiveChosen.Equals("The Ex-Dictator"))
                        {
                            elusiveName = "Inez Ekwensi";
                        }
                        else if (elusiveChosen.Equals("The Surgeons"))
                        {
                            elusiveName = "Akane Akenawa";
                        }
                        else if (elusiveChosen.Equals("The Deceivers"))
                        {
                            elusiveName = "Richard J. Magee";
                        }
                    }
                    Console.Write($"Eliminate ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"'{elusiveName}'");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write($"With The Method ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{killChosen}");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Disguises(readerDisg);

                    killsIssued++;
                }

                // --------------- Kill List ---------------
                #region Kills
                if (broad == false)
                {
                    for (int i = 0; i < 23; i++)
                    {
                        int masteryLevel = masteryList[i];

                        //PARIS
                        if (counterMap == 0 & i == 0)
                        {
                            if (masteryLevel == 20)
                            {
                                killsList.Add("Jaeger 7");
                                killsList.Add("HWK21");
                                killsList.Add("ICA19 Silverballer");
                                killsList.Add("TAC-SMG");
                                killsList.Add("HWK21 Covert");
                                additions = additions + 5;
                            }
                            else if (masteryLevel >= 12)
                            {
                                killsList.Add("Jaeger 7");
                                killsList.Add("HWK21");
                                killsList.Add("ICA19 Silverballer");
                                killsList.Add("TAC-SMG");
                                additions = additions + 4;
                            }
                            else if (masteryLevel >= 11)
                            {
                                killsList.Add("Jaeger 7");
                                killsList.Add("HWK21");
                                killsList.Add("ICA19 Silverballer");
                                additions = additions + 3;
                            }
                            else if (masteryLevel >= 7)
                            {
                                killsList.Add("Jaeger 7");
                                killsList.Add("HWK21");
                                additions = additions + 2;
                            }
                            else if (masteryLevel >= 5)
                            {
                                killsList.Add("Jaeger 7");
                                additions = additions + 1;
                            }
                        }
                        //SAPIENZA
                        if (counterMap == 1 & i == 1)
                        {
                            if (masteryLevel == 20)
                            {
                                killsList.Add("TAC4-AR Auto");
                                killsList.Add("Combat Knife");
                                killsList.Add("Enram HV");
                                killsList.Add("Jaeger 7 Lancer");
                                additions = additions + 4;
                            }
                            else if (masteryLevel >= 12)
                            {
                                killsList.Add("TAC4-AR Auto");
                                killsList.Add("Combat Knife");
                                killsList.Add("Enram HV");
                                additions = additions + 3;
                            }
                            else if (masteryLevel >= 7)
                            {
                                killsList.Add("TAC4-AR Auto");
                                killsList.Add("Combat Knife");
                                additions = additions + 2;
                            }
                            else if (masteryLevel >= 5)
                            {
                                killsList.Add("TAC4-AR Auto");
                                additions = additions + 1;
                            }

                        }
                        //MARRAKESH
                        if (counterMap == 2 & i == 2)
                        {
                            if (masteryLevel == 20)
                            {
                                killsList.Add("ICA19 F/A");
                                killsList.Add("Janbiya");
                                killsList.Add("Enram HV CM");
                                killsList.Add("TAC4-AR Stealth");
                                additions = additions + 4;
                            }
                            else if (masteryLevel >= 12)
                            {
                                killsList.Add("ICA19 F/A");
                                killsList.Add("Janbiya");
                                killsList.Add("Enram HV CM");
                                additions = additions + 3;
                            }
                            else if (masteryLevel >= 10)
                            {
                                killsList.Add("ICA19 F/A");
                                killsList.Add("Janbiya");
                                additions = additions + 2;
                            }
                            else if (masteryLevel >= 5)
                            {
                                killsList.Add("ICA19 F/A");
                                additions = additions + 1;
                            }

                        }
                        //BANGKOK
                        if (counterMap == 3 & i == 3)
                        {
                            if (masteryLevel == 20)
                            {
                                killsList.Add("Nne Obara's Machete");
                                killsList.Add("Enram HV Covert");
                                killsList.Add("TAC-SMG S");
                                killsList.Add("Jaeger 7 Tiger");
                                killsList.Add("Krugermeier 2-2");
                                additions = additions + 5;
                            }
                            else if (masteryLevel >= 15)
                            {
                                killsList.Add("Nne Obara's Machete");
                                killsList.Add("Enram HV Covert");
                                killsList.Add("TAC-SMG S");
                                killsList.Add("Jaeger 7 Tiger");
                                additions = additions + 4;
                            }
                            else if (masteryLevel >= 7)
                            {
                                killsList.Add("Nne Obara's Machete");
                                killsList.Add("Enram HV Covert");
                                killsList.Add("TAC-SMG S");
                                additions = additions + 3;
                            }
                            else if (masteryLevel >= 5)
                            {
                                killsList.Add("Nne Obara's Machete");
                                killsList.Add("Enram HV Covert");
                                additions = additions + 2;
                            }
                            else if (masteryLevel >= 2)
                            {
                                killsList.Add("Nne Obara's Machete");
                                additions = additions + 1;
                            }


                        }
                        //COLORADO
                        if (counterMap == 4 & i == 4)
                        {
                            if (masteryLevel == 20)
                            {
                                killsList.Add("RS-15");
                                killsList.Add("TAC4 S/A");
                                killsList.Add("ICA19 F/A Stealth");
                                killsList.Add("Sieger 300");
                                killsList.Add("Remote CX Demo Block");
                                additions = additions + 5;
                            }
                            else if (masteryLevel >= 15)
                            {
                                killsList.Add("RS-15");
                                killsList.Add("TAC4 S/A");
                                killsList.Add("ICA19 F/A Stealth");
                                killsList.Add("Sieger 300");
                                additions = additions + 4;
                            }
                            else if (masteryLevel >= 10)
                            {
                                killsList.Add("RS-15");
                                killsList.Add("TAC4 S/A");
                                killsList.Add("ICA19 F/A Stealth");
                                additions = additions + 3;
                            }
                            else if (masteryLevel >= 5)
                            {
                                killsList.Add("RS-15");
                                killsList.Add("TAC4 S/A");
                                additions = additions + 2;
                            }
                            else if (masteryLevel >= 2)
                            {
                                killsList.Add("RS-15");
                                additions = additions + 1;
                            }

                        }
                        //HOKKAIDO
                        if (counterMap == 5 & i == 5)
                        {
                            if (masteryLevel == 20)
                            {
                                killsList.Add("Shuriken");
                                killsList.Add("Custom 5mm");
                                killsList.Add("Masamune");
                                killsList.Add("Concealable Knife");
                                killsList.Add("Sieger 300 Advanced");
                                additions = additions + 5;
                            }
                            else if (masteryLevel >= 12)
                            {
                                killsList.Add("Shuriken");
                                killsList.Add("Custom 5mm");
                                killsList.Add("Masamune");
                                killsList.Add("Concealable Knife");
                                additions = additions + 4;
                            }
                            else if (masteryLevel >= 7)
                            {
                                killsList.Add("Shuriken");
                                killsList.Add("Custom 5mm");
                                killsList.Add("Masamune");
                                additions = additions + 3;
                            }
                            else if (masteryLevel >= 5)
                            {
                                killsList.Add("Shuriken");
                                killsList.Add("Custom 5mm");
                                additions = additions + 2;
                            }
                            else if (masteryLevel >= 2)
                            {
                                killsList.Add("Shuriken");
                                additions = additions + 1;
                            }

                        }
                        //HAWKES BAY
                        if (counterMap == 6 & i == 6)
                        {
                            if (masteryLevel == 5)
                            {
                                killsList.Add("Tanto");
                                additions = additions + 1;
                            }
                        }
                        //MIAMI
                        if (counterMap == 7 & i == 7)
                        {
                            if (masteryLevel >= 16)
                            {
                                killsList.Add("Jaeger Seven MK II");
                                killsList.Add("HWK 21 MK II");
                                killsList.Add("Concept 5");
                                killsList.Add("Fishing Line");
                                additions = additions + 4;
                            }
                            else if (masteryLevel >= 15)
                            {
                                killsList.Add("Jaeger Seven MK II");
                                killsList.Add("HWK 21 MK II");
                                killsList.Add("Concept 5");
                                additions = additions + 3;
                            }
                            else if (masteryLevel >= 7)
                            {
                                killsList.Add("Jaeger Seven MK II");
                                killsList.Add("HWK 21 MK II");
                                additions = additions + 2;
                            }
                            else if (masteryLevel >= 5)
                            {
                                killsList.Add("Jaeger Seven MK II");
                                additions = additions + 1;
                            }
                        }
                        //SANTA FORTUNA
                        if (counterMap == 8 & i == 8)
                        {
                            if (masteryLevel >= 16)
                            {
                                killsList.Add("Shaskha A33 H");
                                killsList.Add("TAC-SMG MK II");
                                killsList.Add("Sacrifical Knife");
                                additions = additions + 3;
                            }
                            else if (masteryLevel >= 13)
                            {
                                killsList.Add("Shaskha A33 H");
                                killsList.Add("TAC-SMG MK II");
                                additions = additions + 2;
                            }
                            else if (masteryLevel >= 10)
                            {
                                killsList.Add("Shaskha A33 H");
                                additions = additions + 1;
                            }

                        }
                        //MUMBAI
                        if (counterMap == 9 & i == 9)
                        {
                            if (masteryLevel == 20)
                            {
                                killsList.Add("ICA19 Silverballer MK II");
                                killsList.Add("Bartoli 12G Short H");
                                killsList.Add("DAK X2 Covert");
                                killsList.Add("Antique Curved Knife");
                                killsList.Add("Druzhina 34");
                                additions = additions + 5;
                            }
                            else if (masteryLevel >= 18)
                            {
                                killsList.Add("ICA19 Silverballer MK II");
                                killsList.Add("Bartoli 12G Short H");
                                killsList.Add("DAK X2 Covert");
                                killsList.Add("Antique Curved Knife");
                                additions = additions + 4;
                            }
                            else if (masteryLevel >= 15)
                            {
                                killsList.Add("ICA19 Silverballer MK II");
                                killsList.Add("Bartoli 12G Short H");
                                killsList.Add("DAK X2 Covert");
                                additions = additions + 3;
                            }
                            else if (masteryLevel >= 5)
                            {
                                killsList.Add("ICA19 Silverballer MK II");
                                killsList.Add("Bartoli 12G Short H");
                                additions = additions + 2;
                            }
                            else if (masteryLevel >= 2)
                            {
                                killsList.Add("ICA19 Silverballer MK II");
                                additions = additions + 1;
                            }

                        }
                        //WHITTLETON CREEK
                        if (counterMap == 10 & i == 10)
                        {
                            if (masteryLevel >= 15)
                            {
                                killsList.Add("TAC-4 AR MK II");
                                killsList.Add("Rude Ruby");
                                additions = additions + 2;
                            }
                            else if (masteryLevel >= 2)
                            {
                                killsList.Add("TAC-4 AR MK II");
                                additions = additions + 1;
                            }

                        }
                        //ISLE OF SGAIL
                        if (counterMap == 11 & i == 11)
                        {
                            if (masteryLevel >= 18)
                            {
                                killsList.Add("Sieger 300 Tactical");
                                killsList.Add("Broadsword");
                                killsList.Add("Enram HV Covert MK II");
                                additions = additions + 3;
                            }
                            else if (masteryLevel >= 15)
                            {
                                killsList.Add("Sieger 300 Tactical");
                                killsList.Add("Broadsword");
                                additions = additions + 2;
                            }
                            else if (masteryLevel >= 10)
                            {
                                killsList.Add("Sieger 300 Tactical");
                                additions = additions + 1;
                            }

                        }
                        //NEW YORK
                        if (counterMap == 12 & i == 12)
                        {
                            if (masteryLevel >= 13)
                            {
                                killsList.Add("Sawed Off Bartoli 12G H");
                                additions = additions + 1;
                            }
                        }
                        //HAVEN ISLAND
                        if (counterMap == 13 & i == 13)
                        {
                            if (masteryLevel == 20)
                            {
                                killsList.Add("Jarl's Pirate Saber");
                                killsList.Add("The Black Almond's Dagger");
                                killsList.Add("Jaeger 7 Tuatara");
                                additions = additions + 3;
                            }
                            else if (masteryLevel >= 15)
                            {
                                killsList.Add("Jarl's Pirate Saber");
                                killsList.Add("The Black Almond's Dagger");
                                additions = additions + 2;
                            }
                            else if (masteryLevel >= 2)
                            {
                                killsList.Add("Jarl's Pirate Saber");
                                additions = additions + 1;
                            }

                        }
                        //SIBERA
                        if (counterMap == 14 & i == 14)
                        {
                            if (masteryLevel == 20)
                            {
                                killsList.Add("Druhzina 34 ICA Arctic");
                                additions = additions + 1;
                            }
                        }
                        //DUBAI
                        if (counterMap == 15 & i == 15)
                        {
                            if (masteryLevel >= 15)
                            {
                                killsList.Add("Ornate Scimitar");
                                killsList.Add("Druhzina 34 DTI");
                                additions = additions + 2;
                            }
                            else if (masteryLevel >= 13)
                            {
                                killsList.Add("Ornate Scimitar");
                                additions = additions + 1;
                            }
                        }
                        //DARTMOOR
                        if (counterMap == 16 & i == 16)
                        {
                            if (masteryLevel == 20)
                            {
                                killsList.Add("ICA19 Shortballer");
                                killsList.Add("Kukri Knife");
                                killsList.Add("Bartoli Woodsman Hunting Rifle");
                                additions = additions + 3;
                            }
                            else if (masteryLevel >= 13)
                            {
                                killsList.Add("ICA19 Shortballer");
                                killsList.Add("Kukri Knife");
                                additions = additions + 2;
                            }
                            else if (masteryLevel >= 5)
                            {
                                killsList.Add("ICA19 Shortballer");
                                additions = additions + 1;
                            }

                        }
                        //BERLIN
                        if (counterMap == 17 & i == 17)
                        {
                            if (masteryLevel >= 7)
                            {
                                killsList.Add("Custom 5mm DTI");
                                additions = additions + 1;
                            }
                        }
                        //CHONGQING
                        if (counterMap == 18 & i == 18)
                        {
                            if (masteryLevel == 20)
                            {
                                killsList.Add("ICA Tactical Shotgun");
                                killsList.Add("ICA SMG Raptor Covert");
                                killsList.Add("Hackl Leviathan Sniper Rifle Covert");
                                additions = additions + 3;
                            }
                            else if (masteryLevel >= 15)
                            {
                                killsList.Add("ICA Tactical Shotgun");
                                killsList.Add("ICA SMG Raptor Covert");
                                additions = additions + 2;
                            }
                            else if (masteryLevel >= 10)
                            {
                                killsList.Add("ICA Tactical Shotgun");
                                additions = additions + 1;
                            }

                        }
                        //MENDOZA
                        if (counterMap == 19 & i == 19)
                        {
                            if (masteryLevel == 20)
                            {
                                killsList.Add("ICA DTI Stealth");
                                killsList.Add("ICA Combat Axe");
                                killsList.Add("Krugermeier 2-2 Silver");
                                killsList.Add("DAK Black Covert");
                                killsList.Add("Sieger 300 Viper");
                                additions = additions + 5;
                            }
                            else if (masteryLevel >= 15)
                            {
                                killsList.Add("ICA DTI Stealth");
                                killsList.Add("ICA Combat Axe");
                                killsList.Add("Krugermeier 2-2 Silver");
                                killsList.Add("DAK Black Covert");
                                additions = additions + 4;
                            }
                            else if (masteryLevel >= 10)
                            {
                                killsList.Add("ICA DTI Stealth");
                                killsList.Add("ICA Combat Axe");
                                killsList.Add("Krugermeier 2-2 Silver");
                                additions = additions + 3;
                            }
                            else if (masteryLevel >= 7)
                            {
                                killsList.Add("ICA DTI Stealth");
                                killsList.Add("ICA Combat Axe");
                                additions = additions + 2;
                            }
                            else if (masteryLevel >= 2)
                            {
                                killsList.Add("ICA DTI Stealth");
                                additions = additions + 1;
                            }

                        }
                        //CARPATHIAN MOUNTAINS
                        if (counterMap == 20 & i == 20)
                        {
                            if (masteryLevel == 5)
                            {
                                killsList.Add("HWK Pale Homemade Silencer");
                                killsList.Add("Goldballer");
                                killsList.Add("Proximity Semtex Demo Block MK III");
                                killsList.Add("ICA Tactical Shotgun Covert");
                                additions = additions + 4;
                            }
                            else if (masteryLevel >= 4)
                            {
                                killsList.Add("HWK Pale Homemade Silencer");
                                killsList.Add("Goldballer");
                                killsList.Add("Proximity Semtex Demo Block MK III");
                                additions = additions + 3;
                            }
                            else if (masteryLevel >= 2)
                            {
                                killsList.Add("HWK Pale Homemade Silencer");
                                killsList.Add("Goldballer");
                                additions = additions + 2;
                            }

                        }
                        //AMBROSE ISLAND
                        if (counterMap == 21 & i == 21)
                        {
                            if (masteryLevel == 20)
                            {
                                killsList.Add("Kukri Machete");
                                killsList.Add("Brine Damaged SMG");
                                killsList.Add("Hook");
                                killsList.Add("Militia Issued HX-10 SMG");
                                killsList.Add("Molotov Cocktail");
                                additions = additions + 5;
                            }
                            else if (masteryLevel >= 13)
                            {
                                killsList.Add("Kukri Machete");
                                killsList.Add("Brine Damaged SMG");
                                killsList.Add("Hook");
                                killsList.Add("Militia Issued HX-10 SMG");
                                additions = additions + 4;
                            }
                            else if (masteryLevel >= 10)
                            {
                                killsList.Add("Kukri Machete");
                                killsList.Add("Brine Damaged SMG");
                                killsList.Add("Hook");
                                additions = additions + 3;
                            }
                            else if (masteryLevel >= 6)
                            {
                                killsList.Add("Kukri Machete");
                                killsList.Add("Brine Damaged SMG");
                                additions = additions + 2;
                            }
                            else if (masteryLevel >= 3)
                            {
                                killsList.Add("Kukri Machete");
                                additions = additions + 1;
                            }

                        }
                        // FREELANCER
                        if (counterMap == 22 & i == 22)
                        {
                            if (masteryLevel >= 60)
                            {
                                killsList.Add("The Ancestral Knife");
                                killsList.Add("The Ancestral Sniper Rifle");
                                killsList.Add("The Ancestral Assault Rifle");
                                killsList.Add("The Ancestral Shotgun");
                                killsList.Add("The Ancestral Pistol");
                                killsList.Add("The Ornamental Sniper Rifle");
                                killsList.Add("The Ornamental SMG");
                                killsList.Add("The Ornamental Shotgun");
                                killsList.Add("The Ornamental Katana");
                                killsList.Add("The Ornamental Assault Rifle");
                                killsList.Add("The Ornamental Pistol");
                                additions = additions + 11;
                            }
                            else if (masteryLevel >= 55)
                            {
                                killsList.Add("The Ancestral Sniper Rifle");
                                killsList.Add("The Ancestral Assault Rifle");
                                killsList.Add("The Ancestral Shotgun");
                                killsList.Add("The Ancestral Pistol");
                                killsList.Add("The Ornamental Sniper Rifle");
                                killsList.Add("The Ornamental SMG");
                                killsList.Add("The Ornamental Shotgun");
                                killsList.Add("The Ornamental Katana");
                                killsList.Add("The Ornamental Assault Rifle");
                                killsList.Add("The Ornamental Pistol");
                                additions = additions + 10;
                            }
                            else if (masteryLevel >= 50)
                            {
                                killsList.Add("The Ancestral Assault Rifle");
                                killsList.Add("The Ancestral Shotgun");
                                killsList.Add("The Ancestral Pistol");
                                killsList.Add("The Ornamental Sniper Rifle");
                                killsList.Add("The Ornamental SMG");
                                killsList.Add("The Ornamental Shotgun");
                                killsList.Add("The Ornamental Katana");
                                killsList.Add("The Ornamental Assault Rifle");
                                killsList.Add("The Ornamental Pistol");
                                additions = additions + 9;
                            }
                            else if (masteryLevel >= 45)
                            {
                                killsList.Add("The Ancestral Shotgun");
                                killsList.Add("The Ancestral Pistol");
                                killsList.Add("The Ornamental Sniper Rifle");
                                killsList.Add("The Ornamental SMG");
                                killsList.Add("The Ornamental Shotgun");
                                killsList.Add("The Ornamental Katana");
                                killsList.Add("The Ornamental Assault Rifle");
                                killsList.Add("The Ornamental Pistol");
                                additions = additions + 8;
                            }
                            else if (masteryLevel >= 40)
                            {
                                killsList.Add("The Ancestral Pistol");
                                killsList.Add("The Ornamental Sniper Rifle");
                                killsList.Add("The Ornamental SMG");
                                killsList.Add("The Ornamental Shotgun");
                                killsList.Add("The Ornamental Katana");
                                killsList.Add("The Ornamental Assault Rifle");
                                killsList.Add("The Ornamental Pistol");
                                additions = additions + 7;
                            }
                            else if (masteryLevel >= 30)
                            {
                                killsList.Add("The Ornamental Sniper Rifle");
                                killsList.Add("The Ornamental SMG");
                                killsList.Add("The Ornamental Shotgun");
                                killsList.Add("The Ornamental Katana");
                                killsList.Add("The Ornamental Assault Rifle");
                                killsList.Add("The Ornamental Pistol");
                                additions = additions + 6;
                            }
                            else if (masteryLevel >= 25)
                            {
                                killsList.Add("The Ornamental SMG");
                                killsList.Add("The Ornamental Shotgun");
                                killsList.Add("The Ornamental Katana");
                                killsList.Add("The Ornamental Assault Rifle");
                                killsList.Add("The Ornamental Pistol");
                                additions = additions + 5;
                            }
                            else if (masteryLevel >= 20)
                            {
                                killsList.Add("The Ornamental Shotgun");
                                killsList.Add("The Ornamental Katana");
                                killsList.Add("The Ornamental Assault Rifle");
                                killsList.Add("The Ornamental Pistol");
                                additions = additions + 4;
                            }
                            else if (masteryLevel >= 15)
                            {
                                killsList.Add("The Ornamental Katana");
                                killsList.Add("The Ornamental Assault Rifle");
                                killsList.Add("The Ornamental Pistol");
                                additions = additions + 3;
                            }
                            else if (masteryLevel >= 10)
                            {
                                killsList.Add("The Ornamental Assault Rifle");
                                killsList.Add("The Ornamental Pistol");
                                additions = additions + 2;
                            }
                            else if (masteryLevel >= 5)
                            {
                                killsList.Add("The Ornamental Pistol");
                                additions = additions + 1;
                            }
                        }
                        counterMap++;
                    }

                    contentList = mastery.ReturnContent(username);

                    bool sevenDeadly = contentList[0];
                    bool deluxe = contentList[1];
                    bool concreteArt = contentList[2];
                    bool makeshiftPack = contentList[3];
                    bool trinityPack = contentList[4];
                    bool undyingPack = contentList[5];

                    if (sevenDeadly == true)
                    {
                        killsList.Add("The Proud Swashbuckler");
                        killsList.Add("The Majestic");
                        killsList.Add("Slapdash SMG");
                        killsList.Add("Serpent's Bite");
                        killsList.Add("The Maximalist Shotgun");
                        killsList.Add("The Cat's Claw");
                        killsList.Add("Jaeger 7 Green Eye");
                        killsList.Add("The Shashka Beast");
                        additions = additions + 8;
                    }
                    if (concreteArt == true)
                    {
                        killsList.Add("The Concrete Bunny Pistol");
                        killsList.Add("The Concrete Shotgun");
                        killsList.Add("The Shark SMG");
                        killsList.Add("The Concrete Assault Rifle");
                        killsList.Add("The Concrete Sniper Rifle");
                        additions = additions + 5;
                    }
                    if (makeshiftPack == true)
                    {
                        killsList.Add("The Makeshift Katana");
                        killsList.Add("The Scrap Gun");
                        killsList.Add("The Makeshift Scrap Shotgun");
                        killsList.Add("The Scrap SMG");
                        killsList.Add("The Makeshift Scrap Assault Rifle");
                        killsList.Add("The Scrappy Sniper Rifle");
                        additions = additions + 5;
                    }
                    if (deluxe == true)
                    {
                        killsList.Add("DAK Gold Covert");
                        killsList.Add("Bartoli Hunting Shotgun Deluxe");
                        killsList.Add("The Golden Dragon");
                        killsList.Add("Sieger 300 Arctic");
                        killsList.Add("White Katana");
                        additions = additions + 5;
                    }
                    if (trinityPack == true)
                    {
                        killsList.Add("ICA19 White Trinity");
                        killsList.Add("ICA19 Red Trinity");
                        killsList.Add("ICA19 Black Trinity");
                        additions = additions + 3;
                    }
                    if (undyingPack == true)
                    {
                        killsList.Add("Krondstadt IOI-1998X Surround Earphones");
                        killsList.Add("Krondstadt Explosive Pen (Gen 2)");
                        additions = additions + 2;
                    }

                    if (!freeRemove.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        killsList.Add("Sieger 300 Ghost");
                        killsList.Add("Floral Baller");
                        killsList.Add("Fiber Wire Classic");
                        killsList.Add("ICA Bartoli Woodsman Hunting Rifle Covert");
                        killsList.Add("TAC-4 AR Desert");
                        killsList.Add("Earphones");
                        killsList.Add("ICA19");
                        killsList.Add("ICA19 Classicballer");
                        killsList.Add("TAC-4 S/A Jungle");
                        killsList.Add("Measuring Tape");
                        killsList.Add("Krugermeier 2-2 Dark");
                        killsList.Add("Sieger AR552 Tactical");
                        killsList.Add("Striker V3");
                        killsList.Add("The Ducky Gun");
                        killsList.Add("The Iridescent Katana");
                        killsList.Add("The White Ruby Rude 300 Sniper Rifle");
                        killsList.Add("IO Elite S2VP Earphones");
                        killsList.Add("Piton");
                        killsList.Add("Quickdraw");
                        killsList.Add("Ice Pick");
                        killsList.Add("Nitroglycerin");
                        killsList.Add("Remote Explosive Present");
                        killsList.Add("Ancestral Fountain Pen");
                        killsList.Add("ICA19 Iceballer");
                        killsList.Add("Shashka A33 Gold");
                        killsList.Add("Explosive Pen");
                        killsList.Add("Professional Screwdriver");
                        killsList.Add("Burial Dagger");
                        killsList.Add("Golden Sawed Off Bartoli 12G");

                        additions = additions + 27;
                    }

                    #endregion

                    int valueList = killsList.Count();
                    int killChosenInt = randomNumber.Next(valueList);
                    String killChosen = killsList[killChosenInt];

                    killsList = killsList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();

                    if (killChosen == null || killChosen.Equals("") || killChosen.Equals("Suit"))
                    {
                        while (killChosen == null || killChosen.Equals("") || killChosen.Equals("Suit"))
                        {
                            killChosenInt = randomNumber.Next(21 + additions);
                            killChosen = killsList[killChosenInt];
                        }
                    }

                    if (killsIssued == 1)
                    {
                        if (elusiveChosen.Equals("The Ex-Dictator"))
                        {
                            elusiveName = "Inez Ekwensi";
                        }
                        else if (elusiveChosen.Equals("The Surgeons"))
                        {
                            elusiveName = "Akane Akenawa";
                        }
                        else if (elusiveChosen.Equals("The Deceivers"))
                        {
                            elusiveName = "Richard J. Magee";
                        }
                    }
                    Console.Write($"Eliminate ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"'{elusiveName}'");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write($"With The Method ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{killChosen}");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Disguises(readerDisg);

                    killsIssued++;
                }
            }
        }
        // --------------------------------------------------------------------------REGULAR 
        if (modeSelect == 2)
        {
            Console.WriteLine("Would You Like To Choose a map? (Y/N)");
            String manualMap = Console.ReadLine();

            mapInt = 0;

            if (manualMap.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {

                Console.WriteLine("Which Map Would You Like? Type the respective number");
                Console.WriteLine("Available Maps are: \n");

                for (int i = 0; i < 31; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{i}: {mapsList[i]}");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                Console.WriteLine("\n");

                mapInt = Convert.ToInt32(Console.ReadLine());
                mapChosen = mapsList[mapInt];
            }
            if (manualMap.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                mapInt = randomNumber.Next(27);
                mapChosen = mapsList[mapInt];
            }

            Console.Write($"\nThe Map Chosen Was ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{mapChosen}!");
            Console.ForegroundColor = ConsoleColor.Gray;

            //RANDOM KILLS

            Console.WriteLine("How Many Targets Do You Want? ");
            float targetAmount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nDo You Only Want ANY/ANY Kills? (Y/N)");
            String anyOnly = Console.ReadLine();

            freeRemove = "N";

            if (!anyOnly.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\nDo You Want To Remove Free Items From The Possible Kills? (Y/N)");
                freeRemove = Console.ReadLine();

            }

            if (targetAmount == 0)
            {
                targetAmount = 1;
            }
            else if (targetAmount > 15)
            {
                targetAmount = 5;
            }

            Console.WriteLine($"You Will Have {targetAmount} Target(s)!\n");

            StreamReader readerKills = new StreamReader($"../../txt/Kills{mapInt}.txt");
            StreamReader readerDisg = new StreamReader($"../../txt/Disguises{mapInt}.txt");
            StreamReader readerTarget = new StreamReader($"../../txt/Disguises{mapInt}.txt");

            StreamReader readerKillsBroad = new StreamReader($"../../txt/KillsBroad.txt");

            //BROAD OR NOT

            List<int> masteryList = new List<int>();
            List<bool> contentList = new List<bool>();

            string username = "None";

            if (!anyOnly.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                username = mastery.Username();
            }

            int additions = 0;
            int counterMap = 0;

            masteryList = mastery.ReturnMastery(username);

            int lineCount = File.ReadLines($"../../txt/Kills{mapInt}.txt").Count();

            int mapItemAmount = 0;

            for (int i = 0; i < 21; i++)
            {
                String data = readerKillsBroad.ReadLine();
                killsList.Add(data);
            }

            for (int i = 0; i < lineCount; i++)
            {
                String data = readerKills.ReadLine();
                killsList.Add(data);
                mapItemAmount++;
            }

            while (killsIssued < targetAmount)
            {

                if (!anyOnly.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    int broadint = randomNumber.Next(0, 1);
                    bool broad;
                    if (broadint == 1)
                    {
                        broad = true;
                    }
                    else
                    {
                        broad = false;
                        killsMastery++;
                    }
                    if (mapInt == 1 || mapInt == 0)
                    {
                        broad = true;
                    }
                    if (killsMastery > 2)
                    {
                        broad = true;
                    }

                    //LISTS FOR CONDITIONS

                    if (broad == true)
                    {

                        int killChosenInt = randomNumber.Next(21 + mapItemAmount);
                        String killChosen = killsList[killChosenInt];

                        killsList = killsList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();

                        if (killChosen == null || killChosen.Equals("") || killChosen.Equals("Suit"))
                        {
                            while (killChosen == null || killChosen.Equals("") || killChosen.Equals("Suit"))
                            {
                                killChosenInt = randomNumber.Next(21);
                                killChosen = killsList[killChosenInt];
                            }
                        }

                        Targets(readerTarget);
                        Console.Write($"With The Method ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{killChosen}");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Disguises(readerDisg);

                        killsIssued++;
                    }

                    // --------------- Kill List ---------------
                    #region Kills
                    if (broad == false)
                    {
                        for (int i = 0; i < 23; i++)
                        {
                            int masteryLevel = masteryList[i];

                            //PARIS
                            if (counterMap == 0 & i == 0)
                            {
                                if (masteryLevel == 20)
                                {
                                    killsList.Add("Jaeger 7");
                                    killsList.Add("HWK21");
                                    killsList.Add("ICA19 Silverballer");
                                    killsList.Add("TAC-SMG");
                                    killsList.Add("HWK21 Covert");
                                    additions = additions + 5;
                                }
                                else if (masteryLevel >= 12)
                                {
                                    killsList.Add("Jaeger 7");
                                    killsList.Add("HWK21");
                                    killsList.Add("ICA19 Silverballer");
                                    killsList.Add("TAC-SMG");
                                    additions = additions + 4;
                                }
                                else if (masteryLevel >= 11)
                                {
                                    killsList.Add("Jaeger 7");
                                    killsList.Add("HWK21");
                                    killsList.Add("ICA19 Silverballer");
                                    additions = additions + 3;
                                }
                                else if (masteryLevel >= 7)
                                {
                                    killsList.Add("Jaeger 7");
                                    killsList.Add("HWK21");
                                    additions = additions + 2;
                                }
                                else if (masteryLevel >= 5)
                                {
                                    killsList.Add("Jaeger 7");
                                    additions = additions + 1;
                                }
                            }
                            //SAPIENZA
                            if (counterMap == 1 & i == 1)
                            {
                                if (masteryLevel == 20)
                                {
                                    killsList.Add("TAC4-AR Auto");
                                    killsList.Add("Combat Knife");
                                    killsList.Add("Enram HV");
                                    killsList.Add("Jaeger 7 Lancer");
                                    additions = additions + 4;
                                }
                                else if (masteryLevel >= 12)
                                {
                                    killsList.Add("TAC4-AR Auto");
                                    killsList.Add("Combat Knife");
                                    killsList.Add("Enram HV");
                                    additions = additions + 3;
                                }
                                else if (masteryLevel >= 7)
                                {
                                    killsList.Add("TAC4-AR Auto");
                                    killsList.Add("Combat Knife");
                                    additions = additions + 2;
                                }
                                else if (masteryLevel >= 5)
                                {
                                    killsList.Add("TAC4-AR Auto");
                                    additions = additions + 1;
                                }

                            }
                            //MARRAKESH
                            if (counterMap == 2 & i == 2)
                            {
                                if (masteryLevel == 20)
                                {
                                    killsList.Add("ICA19 F/A");
                                    killsList.Add("Janbiya");
                                    killsList.Add("Enram HV CM");
                                    killsList.Add("TAC4-AR Stealth");
                                    additions = additions + 4;
                                }
                                else if (masteryLevel >= 12)
                                {
                                    killsList.Add("ICA19 F/A");
                                    killsList.Add("Janbiya");
                                    killsList.Add("Enram HV CM");
                                    additions = additions + 3;
                                }
                                else if (masteryLevel >= 10)
                                {
                                    killsList.Add("ICA19 F/A");
                                    killsList.Add("Janbiya");
                                    additions = additions + 2;
                                }
                                else if (masteryLevel >= 5)
                                {
                                    killsList.Add("ICA19 F/A");
                                    additions = additions + 1;
                                }

                            }
                            //BANGKOK
                            if (counterMap == 3 & i == 3)
                            {
                                if (masteryLevel == 20)
                                {
                                    killsList.Add("Nne Obara's Machete");
                                    killsList.Add("Enram HV Covert");
                                    killsList.Add("TAC-SMG S");
                                    killsList.Add("Jaeger 7 Tiger");
                                    killsList.Add("Krugermeier 2-2");
                                    additions = additions + 5;
                                }
                                else if (masteryLevel >= 15)
                                {
                                    killsList.Add("Nne Obara's Machete");
                                    killsList.Add("Enram HV Covert");
                                    killsList.Add("TAC-SMG S");
                                    killsList.Add("Jaeger 7 Tiger");
                                    additions = additions + 4;
                                }
                                else if (masteryLevel >= 7)
                                {
                                    killsList.Add("Nne Obara's Machete");
                                    killsList.Add("Enram HV Covert");
                                    killsList.Add("TAC-SMG S");
                                    additions = additions + 3;
                                }
                                else if (masteryLevel >= 5)
                                {
                                    killsList.Add("Nne Obara's Machete");
                                    killsList.Add("Enram HV Covert");
                                    additions = additions + 2;
                                }
                                else if (masteryLevel >= 2)
                                {
                                    killsList.Add("Nne Obara's Machete");
                                    additions = additions + 1;
                                }


                            }
                            //COLORADO
                            if (counterMap == 4 & i == 4)
                            {
                                if (masteryLevel == 20)
                                {
                                    killsList.Add("RS-15");
                                    killsList.Add("TAC4 S/A");
                                    killsList.Add("ICA19 F/A Stealth");
                                    killsList.Add("Sieger 300");
                                    killsList.Add("Remote CX Demo Block");
                                    additions = additions + 5;
                                }
                                else if (masteryLevel >= 15)
                                {
                                    killsList.Add("RS-15");
                                    killsList.Add("TAC4 S/A");
                                    killsList.Add("ICA19 F/A Stealth");
                                    killsList.Add("Sieger 300");
                                    additions = additions + 4;
                                }
                                else if (masteryLevel >= 10)
                                {
                                    killsList.Add("RS-15");
                                    killsList.Add("TAC4 S/A");
                                    killsList.Add("ICA19 F/A Stealth");
                                    additions = additions + 3;
                                }
                                else if (masteryLevel >= 5)
                                {
                                    killsList.Add("RS-15");
                                    killsList.Add("TAC4 S/A");
                                    additions = additions + 2;
                                }
                                else if (masteryLevel >= 2)
                                {
                                    killsList.Add("RS-15");
                                    additions = additions + 1;
                                }

                            }
                            //HOKKAIDO
                            if (counterMap == 5 & i == 5)
                            {
                                if (masteryLevel == 20)
                                {
                                    killsList.Add("Shuriken");
                                    killsList.Add("Custom 5mm");
                                    killsList.Add("Masamune");
                                    killsList.Add("Concealable Knife");
                                    killsList.Add("Sieger 300 Advanced");
                                    additions = additions + 5;
                                }
                                else if (masteryLevel >= 12)
                                {
                                    killsList.Add("Shuriken");
                                    killsList.Add("Custom 5mm");
                                    killsList.Add("Masamune");
                                    killsList.Add("Concealable Knife");
                                    additions = additions + 4;
                                }
                                else if (masteryLevel >= 7)
                                {
                                    killsList.Add("Shuriken");
                                    killsList.Add("Custom 5mm");
                                    killsList.Add("Masamune");
                                    additions = additions + 3;
                                }
                                else if (masteryLevel >= 5)
                                {
                                    killsList.Add("Shuriken");
                                    killsList.Add("Custom 5mm");
                                    additions = additions + 2;
                                }
                                else if (masteryLevel >= 2)
                                {
                                    killsList.Add("Shuriken");
                                    additions = additions + 1;
                                }

                            }
                            //HAWKES BAY
                            if (counterMap == 6 & i == 6)
                            {
                                if (masteryLevel == 5)
                                {
                                    killsList.Add("Tanto");
                                    additions = additions + 1;
                                }
                            }
                            //MIAMI
                            if (counterMap == 7 & i == 7)
                            {
                                if (masteryLevel >= 16)
                                {
                                    killsList.Add("Jaeger Seven MK II");
                                    killsList.Add("HWK 21 MK II");
                                    killsList.Add("Concept 5");
                                    killsList.Add("Fishing Line");
                                    additions = additions + 4;
                                }
                                else if (masteryLevel >= 15)
                                {
                                    killsList.Add("Jaeger Seven MK II");
                                    killsList.Add("HWK 21 MK II");
                                    killsList.Add("Concept 5");
                                    additions = additions + 3;
                                }
                                else if (masteryLevel >= 7)
                                {
                                    killsList.Add("Jaeger Seven MK II");
                                    killsList.Add("HWK 21 MK II");
                                    additions = additions + 2;
                                }
                                else if (masteryLevel >= 5)
                                {
                                    killsList.Add("Jaeger Seven MK II");
                                    additions = additions + 1;
                                }
                            }
                            //SANTA FORTUNA
                            if (counterMap == 8 & i == 8)
                            {
                                if (masteryLevel >= 16)
                                {
                                    killsList.Add("Shaskha A33 H");
                                    killsList.Add("TAC-SMG MK II");
                                    killsList.Add("Sacrifical Knife");
                                    additions = additions + 3;
                                }
                                else if (masteryLevel >= 13)
                                {
                                    killsList.Add("Shaskha A33 H");
                                    killsList.Add("TAC-SMG MK II");
                                    additions = additions + 2;
                                }
                                else if (masteryLevel >= 10)
                                {
                                    killsList.Add("Shaskha A33 H");
                                    additions = additions + 1;
                                }

                            }
                            //MUMBAI
                            if (counterMap == 9 & i == 9)
                            {
                                if (masteryLevel == 20)
                                {
                                    killsList.Add("ICA19 Silverballer MK II");
                                    killsList.Add("Bartoli 12G Short H");
                                    killsList.Add("DAK X2 Covert");
                                    killsList.Add("Antique Curved Knife");
                                    killsList.Add("Druzhina 34");
                                    additions = additions + 5;
                                }
                                else if (masteryLevel >= 18)
                                {
                                    killsList.Add("ICA19 Silverballer MK II");
                                    killsList.Add("Bartoli 12G Short H");
                                    killsList.Add("DAK X2 Covert");
                                    killsList.Add("Antique Curved Knife");
                                    additions = additions + 4;
                                }
                                else if (masteryLevel >= 15)
                                {
                                    killsList.Add("ICA19 Silverballer MK II");
                                    killsList.Add("Bartoli 12G Short H");
                                    killsList.Add("DAK X2 Covert");
                                    additions = additions + 3;
                                }
                                else if (masteryLevel >= 5)
                                {
                                    killsList.Add("ICA19 Silverballer MK II");
                                    killsList.Add("Bartoli 12G Short H");
                                    additions = additions + 2;
                                }
                                else if (masteryLevel >= 2)
                                {
                                    killsList.Add("ICA19 Silverballer MK II");
                                    additions = additions + 1;
                                }

                            }
                            //WHITTLETON CREEK
                            if (counterMap == 10 & i == 10)
                            {
                                if (masteryLevel >= 15)
                                {
                                    killsList.Add("TAC-4 AR MK II");
                                    killsList.Add("Rude Ruby");
                                    additions = additions + 2;
                                }
                                else if (masteryLevel >= 2)
                                {
                                    killsList.Add("TAC-4 AR MK II");
                                    additions = additions + 1;
                                }

                            }
                            //ISLE OF SGAIL
                            if (counterMap == 11 & i == 11)
                            {
                                if (masteryLevel >= 18)
                                {
                                    killsList.Add("Sieger 300 Tactical");
                                    killsList.Add("Broadsword");
                                    killsList.Add("Enram HV Covert MK II");
                                    additions = additions + 3;
                                }
                                else if (masteryLevel >= 15)
                                {
                                    killsList.Add("Sieger 300 Tactical");
                                    killsList.Add("Broadsword");
                                    additions = additions + 2;
                                }
                                else if (masteryLevel >= 10)
                                {
                                    killsList.Add("Sieger 300 Tactical");
                                    additions = additions + 1;
                                }

                            }
                            //NEW YORK
                            if (counterMap == 12 & i == 12)
                            {
                                if (masteryLevel >= 13)
                                {
                                    killsList.Add("Sawed Off Bartoli 12G H");
                                    additions = additions + 1;
                                }
                            }
                            //HAVEN ISLAND
                            if (counterMap == 13 & i == 13)
                            {
                                if (masteryLevel == 20)
                                {
                                    killsList.Add("Jarl's Pirate Saber");
                                    killsList.Add("The Black Almond's Dagger");
                                    killsList.Add("Jaeger 7 Tuatara");
                                    additions = additions + 3;
                                }
                                else if (masteryLevel >= 15)
                                {
                                    killsList.Add("Jarl's Pirate Saber");
                                    killsList.Add("The Black Almond's Dagger");
                                    additions = additions + 2;
                                }
                                else if (masteryLevel >= 2)
                                {
                                    killsList.Add("Jarl's Pirate Saber");
                                    additions = additions + 1;
                                }

                            }
                            //SIBERA
                            if (counterMap == 14 & i == 14)
                            {
                                if (masteryLevel == 20)
                                {
                                    killsList.Add("Druhzina 34 ICA Arctic");
                                    additions = additions + 1;
                                }
                            }
                            //DUBAI
                            if (counterMap == 15 & i == 15)
                            {
                                if (masteryLevel >= 15)
                                {
                                    killsList.Add("Ornate Scimitar");
                                    killsList.Add("Druhzina 34 DTI");
                                    additions = additions + 2;
                                }
                                else if (masteryLevel >= 13)
                                {
                                    killsList.Add("Ornate Scimitar");
                                    additions = additions + 1;
                                }
                            }
                            //DARTMOOR
                            if (counterMap == 16 & i == 16)
                            {
                                if (masteryLevel == 20)
                                {
                                    killsList.Add("ICA19 Shortballer");
                                    killsList.Add("Kukri Knife");
                                    killsList.Add("Bartoli Woodsman Hunting Rifle");
                                    additions = additions + 3;
                                }
                                else if (masteryLevel >= 13)
                                {
                                    killsList.Add("ICA19 Shortballer");
                                    killsList.Add("Kukri Knife");
                                    additions = additions + 2;
                                }
                                else if (masteryLevel >= 5)
                                {
                                    killsList.Add("ICA19 Shortballer");
                                    additions = additions + 1;
                                }

                            }
                            //BERLIN
                            if (counterMap == 17 & i == 17)
                            {
                                if (masteryLevel >= 7)
                                {
                                    killsList.Add("Custom 5mm DTI");
                                    additions = additions + 1;
                                }
                            }
                            //CHONGQING
                            if (counterMap == 18 & i == 18)
                            {
                                if (masteryLevel == 20)
                                {
                                    killsList.Add("ICA Tactical Shotgun");
                                    killsList.Add("ICA SMG Raptor Covert");
                                    killsList.Add("Hackl Leviathan Sniper Rifle Covert");
                                    additions = additions + 3;
                                }
                                else if (masteryLevel >= 15)
                                {
                                    killsList.Add("ICA Tactical Shotgun");
                                    killsList.Add("ICA SMG Raptor Covert");
                                    additions = additions + 2;
                                }
                                else if (masteryLevel >= 10)
                                {
                                    killsList.Add("ICA Tactical Shotgun");
                                    additions = additions + 1;
                                }

                            }
                            //MENDOZA
                            if (counterMap == 19 & i == 19)
                            {
                                if (masteryLevel == 20)
                                {
                                    killsList.Add("ICA DTI Stealth");
                                    killsList.Add("ICA Combat Axe");
                                    killsList.Add("Krugermeier 2-2 Silver");
                                    killsList.Add("DAK Black Covert");
                                    killsList.Add("Sieger 300 Viper");
                                    additions = additions + 5;
                                }
                                else if (masteryLevel >= 15)
                                {
                                    killsList.Add("ICA DTI Stealth");
                                    killsList.Add("ICA Combat Axe");
                                    killsList.Add("Krugermeier 2-2 Silver");
                                    killsList.Add("DAK Black Covert");
                                    additions = additions + 4;
                                }
                                else if (masteryLevel >= 10)
                                {
                                    killsList.Add("ICA DTI Stealth");
                                    killsList.Add("ICA Combat Axe");
                                    killsList.Add("Krugermeier 2-2 Silver");
                                    additions = additions + 3;
                                }
                                else if (masteryLevel >= 7)
                                {
                                    killsList.Add("ICA DTI Stealth");
                                    killsList.Add("ICA Combat Axe");
                                    additions = additions + 2;
                                }
                                else if (masteryLevel >= 2)
                                {
                                    killsList.Add("ICA DTI Stealth");
                                    additions = additions + 1;
                                }

                            }
                            //CARPATHIAN MOUNTAINS
                            if (counterMap == 20 & i == 20)
                            {
                                if (masteryLevel == 5)
                                {
                                    killsList.Add("HWK Pale Homemade Silencer");
                                    killsList.Add("Goldballer");
                                    killsList.Add("Proximity Semtex Demo Block MK III");
                                    killsList.Add("ICA Tactical Shotgun Covert");
                                    additions = additions + 4;
                                }
                                else if (masteryLevel >= 4)
                                {
                                    killsList.Add("HWK Pale Homemade Silencer");
                                    killsList.Add("Goldballer");
                                    killsList.Add("Proximity Semtex Demo Block MK III");
                                    additions = additions + 3;
                                }
                                else if (masteryLevel >= 2)
                                {
                                    killsList.Add("HWK Pale Homemade Silencer");
                                    killsList.Add("Goldballer");
                                    additions = additions + 2;
                                }

                            }
                            //AMBROSE ISLAND
                            if (counterMap == 21 & i == 21)
                            {
                                if (masteryLevel == 20)
                                {
                                    killsList.Add("Kukri Machete");
                                    killsList.Add("Brine Damaged SMG");
                                    killsList.Add("Hook");
                                    killsList.Add("Militia Issued HX-10 SMG");
                                    killsList.Add("Molotov Cocktail");
                                    additions = additions + 5;
                                }
                                else if (masteryLevel >= 13)
                                {
                                    killsList.Add("Kukri Machete");
                                    killsList.Add("Brine Damaged SMG");
                                    killsList.Add("Hook");
                                    killsList.Add("Militia Issued HX-10 SMG");
                                    additions = additions + 4;
                                }
                                else if (masteryLevel >= 10)
                                {
                                    killsList.Add("Kukri Machete");
                                    killsList.Add("Brine Damaged SMG");
                                    killsList.Add("Hook");
                                    additions = additions + 3;
                                }
                                else if (masteryLevel >= 6)
                                {
                                    killsList.Add("Kukri Machete");
                                    killsList.Add("Brine Damaged SMG");
                                    additions = additions + 2;
                                }
                                else if (masteryLevel >= 3)
                                {
                                    killsList.Add("Kukri Machete");
                                    additions = additions + 1;
                                }

                            }
                            // FREELANCER
                            if (counterMap == 22 & i == 22)
                            {
                                if (masteryLevel >= 60)
                                {
                                    killsList.Add("The Ancestral Knife");
                                    killsList.Add("The Ancestral Sniper Rifle");
                                    killsList.Add("The Ancestral Assault Rifle");
                                    killsList.Add("The Ancestral Shotgun");
                                    killsList.Add("The Ancestral Pistol");
                                    killsList.Add("The Ornamental Sniper Rifle");
                                    killsList.Add("The Ornamental SMG");
                                    killsList.Add("The Ornamental Shotgun");
                                    killsList.Add("The Ornamental Katana");
                                    killsList.Add("The Ornamental Assault Rifle");
                                    killsList.Add("The Ornamental Pistol");
                                    additions = additions + 11;
                                }
                                else if (masteryLevel >= 55)
                                {
                                    killsList.Add("The Ancestral Sniper Rifle");
                                    killsList.Add("The Ancestral Assault Rifle");
                                    killsList.Add("The Ancestral Shotgun");
                                    killsList.Add("The Ancestral Pistol");
                                    killsList.Add("The Ornamental Sniper Rifle");
                                    killsList.Add("The Ornamental SMG");
                                    killsList.Add("The Ornamental Shotgun");
                                    killsList.Add("The Ornamental Katana");
                                    killsList.Add("The Ornamental Assault Rifle");
                                    killsList.Add("The Ornamental Pistol");
                                    additions = additions + 10;
                                }
                                else if (masteryLevel >= 50)
                                {
                                    killsList.Add("The Ancestral Assault Rifle");
                                    killsList.Add("The Ancestral Shotgun");
                                    killsList.Add("The Ancestral Pistol");
                                    killsList.Add("The Ornamental Sniper Rifle");
                                    killsList.Add("The Ornamental SMG");
                                    killsList.Add("The Ornamental Shotgun");
                                    killsList.Add("The Ornamental Katana");
                                    killsList.Add("The Ornamental Assault Rifle");
                                    killsList.Add("The Ornamental Pistol");
                                    additions = additions + 9;
                                }
                                else if (masteryLevel >= 45)
                                {
                                    killsList.Add("The Ancestral Shotgun");
                                    killsList.Add("The Ancestral Pistol");
                                    killsList.Add("The Ornamental Sniper Rifle");
                                    killsList.Add("The Ornamental SMG");
                                    killsList.Add("The Ornamental Shotgun");
                                    killsList.Add("The Ornamental Katana");
                                    killsList.Add("The Ornamental Assault Rifle");
                                    killsList.Add("The Ornamental Pistol");
                                    additions = additions + 8;
                                }
                                else if (masteryLevel >= 40)
                                {
                                    killsList.Add("The Ancestral Pistol");
                                    killsList.Add("The Ornamental Sniper Rifle");
                                    killsList.Add("The Ornamental SMG");
                                    killsList.Add("The Ornamental Shotgun");
                                    killsList.Add("The Ornamental Katana");
                                    killsList.Add("The Ornamental Assault Rifle");
                                    killsList.Add("The Ornamental Pistol");
                                    additions = additions + 7;
                                }
                                else if (masteryLevel >= 30)
                                {
                                    killsList.Add("The Ornamental Sniper Rifle");
                                    killsList.Add("The Ornamental SMG");
                                    killsList.Add("The Ornamental Shotgun");
                                    killsList.Add("The Ornamental Katana");
                                    killsList.Add("The Ornamental Assault Rifle");
                                    killsList.Add("The Ornamental Pistol");
                                    additions = additions + 6;
                                }
                                else if (masteryLevel >= 25)
                                {
                                    killsList.Add("The Ornamental SMG");
                                    killsList.Add("The Ornamental Shotgun");
                                    killsList.Add("The Ornamental Katana");
                                    killsList.Add("The Ornamental Assault Rifle");
                                    killsList.Add("The Ornamental Pistol");
                                    additions = additions + 5;
                                }
                                else if (masteryLevel >= 20)
                                {
                                    killsList.Add("The Ornamental Shotgun");
                                    killsList.Add("The Ornamental Katana");
                                    killsList.Add("The Ornamental Assault Rifle");
                                    killsList.Add("The Ornamental Pistol");
                                    additions = additions + 4;
                                }
                                else if (masteryLevel >= 15)
                                {
                                    killsList.Add("The Ornamental Katana");
                                    killsList.Add("The Ornamental Assault Rifle");
                                    killsList.Add("The Ornamental Pistol");
                                    additions = additions + 3;
                                }
                                else if (masteryLevel >= 10)
                                {
                                    killsList.Add("The Ornamental Assault Rifle");
                                    killsList.Add("The Ornamental Pistol");
                                    additions = additions + 2;
                                }
                                else if (masteryLevel >= 5)
                                {
                                    killsList.Add("The Ornamental Pistol");
                                    additions = additions + 1;
                                }
                            }
                            counterMap++;
                        }

                        contentList = mastery.ReturnContent(username);

                        bool sevenDeadly = contentList[0];
                        bool deluxe = contentList[1];
                        bool concreteArt = contentList[2];
                        bool makeshiftPack = contentList[3];
                        bool trinityPack = contentList[4];
                        bool undyingPack = contentList[5];

                        if (sevenDeadly == true)
                        {
                            killsList.Add("The Proud Swashbuckler");
                            killsList.Add("The Majestic");
                            killsList.Add("Slapdash SMG");
                            killsList.Add("Serpent's Bite");
                            killsList.Add("The Maximalist Shotgun");
                            killsList.Add("The Cat's Claw");
                            killsList.Add("Jaeger 7 Green Eye");
                            killsList.Add("The Shashka Beast");
                            additions = additions + 8;
                        }
                        if (concreteArt == true)
                        {
                            killsList.Add("The Concrete Bunny Pistol");
                            killsList.Add("The Concrete Shotgun");
                            killsList.Add("The Shark SMG");
                            killsList.Add("The Concrete Assault Rifle");
                            killsList.Add("The Concrete Sniper Rifle");
                            additions = additions + 5;
                        }
                        if (makeshiftPack == true)
                        {
                            killsList.Add("The Makeshift Katana");
                            killsList.Add("The Scrap Gun");
                            killsList.Add("The Makeshift Scrap Shotgun");
                            killsList.Add("The Scrap SMG");
                            killsList.Add("The Makeshift Scrap Assault Rifle");
                            killsList.Add("The Scrappy Sniper Rifle");
                            additions = additions + 5;
                        }
                        if (deluxe == true)
                        {
                            killsList.Add("DAK Gold Covert");
                            killsList.Add("Bartoli Hunting Shotgun Deluxe");
                            killsList.Add("The Golden Dragon");
                            killsList.Add("Sieger 300 Arctic");
                            killsList.Add("White Katana");
                            additions = additions + 5;
                        }
                        if (trinityPack == true)
                        {
                            killsList.Add("ICA19 White Trinity");
                            killsList.Add("ICA19 Red Trinity");
                            killsList.Add("ICA19 Black Trinity");
                            additions = additions + 3;
                        }
                        if (undyingPack == true)
                        {
                            killsList.Add("Krondstadt IOI-1998X Surround Earphones");
                            killsList.Add("Krondstadt Explosive Pen (Gen 2)");
                            additions = additions + 2;
                        }

                        if (!freeRemove.Equals("Y", StringComparison.OrdinalIgnoreCase))
                        {
                            killsList.Add("Sieger 300 Ghost");
                            killsList.Add("Floral Baller");
                            killsList.Add("Fiber Wire Classic");
                            killsList.Add("ICA Bartoli Woodsman Hunting Rifle Covert");
                            killsList.Add("TAC-4 AR Desert");
                            killsList.Add("Earphones");
                            killsList.Add("ICA19");
                            killsList.Add("ICA19 Classicballer");
                            killsList.Add("TAC-4 S/A Jungle");
                            killsList.Add("Measuring Tape");
                            killsList.Add("Krugermeier 2-2 Dark");
                            killsList.Add("Sieger AR552 Tactical");
                            killsList.Add("Striker V3");
                            killsList.Add("The Ducky Gun");
                            killsList.Add("The Iridescent Katana");
                            killsList.Add("The White Ruby Rude 300 Sniper Rifle");
                            killsList.Add("IO Elite S2VP Earphones");
                            killsList.Add("Piton");
                            killsList.Add("Quickdraw");
                            killsList.Add("Ice Pick");
                            killsList.Add("Nitroglycerin");
                            killsList.Add("Remote Explosive Present");
                            killsList.Add("Ancestral Fountain Pen");
                            killsList.Add("ICA19 Iceballer");
                            killsList.Add("Shashka A33 Gold");
                            killsList.Add("Explosive Pen");
                            killsList.Add("Professional Screwdriver");
                            killsList.Add("Burial Dagger");
                            killsList.Add("Golden Sawed Off Bartoli 12G");

                            additions = additions + 27;
                        }

                        #endregion

                        int valueList = killsList.Count();
                        int killChosenInt = randomNumber.Next(valueList);
                        String killChosen = killsList[killChosenInt];

                        killsList = killsList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();

                        if (killChosen == null || killChosen.Equals("") || killChosen.Equals("Suit"))
                        {
                            while (killChosen == null || killChosen.Equals("") || killChosen.Equals("Suit"))
                            {
                                killChosenInt = randomNumber.Next(21 + additions);
                                killChosen = killsList[killChosenInt];
                            }
                        }

                        Targets(readerTarget);
                        Console.Write($"With The Method ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{killChosen}");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Disguises(readerDisg);

                        killsIssued++;
                    }
                }
                else
                {
                    Targets(readerTarget);
                    killsIssued++;
                }
            }
        }

        void Disguises(StreamReader readerDisg)
        {
            int lineCount = File.ReadLines($"../../txt/Disguises{mapInt}.txt").Count();

            for (int i = 0; i < lineCount; i++)
            {
                String data = readerDisg.ReadLine();
                disguisesList.Add(data);
            }

            int disgChosenInt = randomNumber.Next(lineCount);
            String disgChosen = disguisesList[disgChosenInt];

            Console.Write($"While Wearing The Disguise ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"'{disgChosen}'\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        void Targets(StreamReader readerTarget)
        {
            int lineCount = File.ReadLines($"../../txt/Disguises{mapInt}.txt").Count();

            for (int i = 0; i < lineCount; i++)
            {
                String data = readerTarget.ReadLine();
                targetList.Add(data);
            }

            int targetInt = randomNumber.Next(lineCount);
            String targetChosen= targetList[targetInt];

            targetChosen = CheckInvalidDisguises(ref targetChosen, ref targetInt, ref lineCount);
            targetChosen = CheckUniqueDisguises(ref targetChosen, ref targetInt, ref lineCount);

            previousTarget.Add(targetChosen);

            Console.Write($"Eliminate ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"'{targetChosen}'");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        string CheckUniqueDisguises(ref string targetChosen, ref int targetInt, ref int lineCount)
        {
            int lineCountUnique = File.ReadLines($"../../txt/UniqueKills.txt").Count();

            StreamReader readerUnique = new StreamReader($"../../txt/UniqueKills.txt");
            List<String> uniqueList = new List<String>();

            for (int i = 0; i < lineCountUnique; i++)
            {
                String data = readerUnique.ReadLine();
                uniqueList.Add(data);
            }

            for (int i = 0; i < previousTarget.Count(); i++)
            {
                if (targetChosen.Equals(previousTarget[i]))
                {
                    for (int j = 0; j < lineCountUnique; j++)
                    {
                        if (targetChosen.Equals(uniqueList[j]))
                        {
                            //Console.WriteLine("Unique Duplicate!");
                            targetInt = randomNumber.Next(lineCount);
                            targetChosen = targetList[targetInt];
                            targetChosen = CheckInvalidDisguises(ref targetChosen, ref targetInt, ref lineCount);
                            targetChosen = CheckUniqueDisguises(ref targetChosen, ref targetInt, ref lineCount);
                            return targetChosen;
                        }
                    }
                }
            }
            return targetChosen;
        }

        string CheckInvalidDisguises(ref string targetChosen, ref int targetInt, ref int lineCount)
        {
            if (targetChosen.Equals("Suit", StringComparison.OrdinalIgnoreCase) || targetChosen.Equals("Any Disguise", StringComparison.OrdinalIgnoreCase))
            {
                //Console.WriteLine("Previously Was Suit");
                targetInt = randomNumber.Next(lineCount);
                targetChosen = targetList[targetInt];
                targetChosen = CheckInvalidDisguises(ref targetChosen, ref targetInt, ref lineCount);
                targetChosen = CheckUniqueDisguises(ref targetChosen, ref targetInt, ref lineCount);

            }

            #region Disguise Replacements
            if (targetChosen.Equals("Vampire Magician"))
            {
                targetChosen = ("Cameraman");
            }
            if (targetChosen.Equals("Plague Doctor"))
            {
                targetChosen = ("Lab Technician");
            }
            if (targetChosen.Equals("Scarecrow"))
            {
                targetChosen = ("Hacker");
            }
            if (targetChosen.Equals("Baseball Player"))
            {
                targetChosen = ("Patient");
            }
            if (targetChosen.Equals("Motorcyclist"))
            {
                targetChosen = ("Gardener");
            }
            if (targetChosen.Equals("Ninja"))
            {
                targetChosen = ("Doctor");
            }
            if (targetChosen.Equals("Drummer"))
            {
                targetChosen = ("Band Member");
            }
            if (targetChosen.Equals("Arkian Robe"))
            {
                targetChosen = ("Civillian");
            }
            if (targetChosen.Equals("Swimwear"))
            {
                targetChosen = ("Civillian");
            }
            if (targetChosen.Equals("Knight's Armour"))
            {
                targetChosen = ("Elite Guard");
            }
            if (targetChosen.Equals("Gas Suit"))
            {
                targetChosen = ("Tech Crew");
            }
            if (targetChosen.Equals("Skydiving Suit"))
            {
                targetChosen = ("Event Staff");
            }        
            if (targetChosen.Equals("47's Signature Suit with Gloves"))
            {
                targetChosen = ("Gaucho");
            }
            if (targetChosen.Equals("Pale Rider"))
            {
                targetChosen = ("Event Security");
            }
            if (targetChosen.Equals("The Buccaneer"))
            {
                targetChosen = ("Pirate");
            }
            if (targetChosen.Equals("Tactical Wetsuit"))
            {
                targetChosen = ("Civillian");
            }
            if (targetChosen.Equals("Burial Robes"))
            {
                targetChosen = ("Architect");
            }
            #endregion

            return targetChosen;
        }
    }
}
