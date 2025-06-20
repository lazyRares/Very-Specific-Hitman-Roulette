using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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

    string freeRemove = "Y";

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
        int modeSelect;
        try
        {
            modeSelect = Int32.Parse(Console.ReadLine());
            if (modeSelect > 2)
            {
                modeSelect = 2;
            }
        }
        catch (Exception e)
        {
            modeSelect = 2;
        }

        // -------------------------------------------------------------------------- ELUSIVE MODE SELECT
        if (modeSelect == 1)
        {
            string elusiveChosen = "";
            int valiantClones = 0;
            int mapIntElusive = 0;
            int maxMasteryKills = 2;

            StreamReader elusiveMapReader = new StreamReader($"../../txt/Elusives/ElusiveMapList.txt");
            StreamReader elusiveReader = new StreamReader($"../../txt/Elusives/Elusives.txt");

            for (int i = 0; i < 45; i++)
            {
                String data = elusiveMapReader.ReadLine();
                elusiveMapList.Add(data);
            }
            for (int i = 0; i < 45; i++)
            {
                String data = elusiveReader.ReadLine();
                elusiveList.Add(data);
            }

            Console.WriteLine("Would You Like To Choose an Elusive? (Y/N)");
            String manualElusive = "";

            try
            {
                manualElusive = Console.ReadLine();
                if (!manualElusive.Equals("N", StringComparison.OrdinalIgnoreCase) && !manualElusive.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    manualElusive = "N";
                }
            }
            catch (Exception e)
            {
                manualElusive = "N";
            }

            int elusiveInt = 0;

            if (manualElusive.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {

                Console.WriteLine("Which Elusive Would You Like? Type the respective number");
                Console.WriteLine("Available Elusive Targets are: \n");

                for (int i = 0; i < 45; i++)
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
                elusiveInt = randomNumber.Next(0, 45);
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

            if (elusiveChosen.Equals("The Ex-Dictator") || elusiveChosen.Equals("The Surgeons") || elusiveChosen.Equals("The Deceivers") || elusiveChosen.Equals("The Procurers"))
            {
                elusiveTargetAmount = 2;
            }
            else if (elusiveChosen.Equals("The Splitter"))
            {
                elusiveTargetAmount = 1;
                valiantClones = 7;
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
                    disguisesList.Add("Bodyguard Leader");
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
                    elusiveName = "Jack Roe";
                    disguisesList.Remove("Private Investigator");
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

                case "The Disruptor":
                    elusiveName = "The Disruptor";
                    disguisesList.Add("Tim Quinn");
                    break;

                case "The Splitter":
                    elusiveName = "Max Valliant";

                    disguisesList.Remove("Facility Guard");
                    disguisesList.Remove("Facility Security");

                    // Not Sure But Safe Guesses
                    disguisesList.Remove("Facility Analyst");
                    disguisesList.Remove("Perfect Test Subject");
                    disguisesList.Remove("Block Guard");
                    break;

                case "The Banker":
                    elusiveName = "Le Chiffre";

                    disguisesList.Remove("Helmut Kruger");
                    disguisesList.Remove("Sheikh");
                    disguisesList.Remove("Stylist");

                    disguisesList.Add("Croupier");
                    disguisesList.Add("Agent Smith's Suit");
                    disguisesList.Add("Murillo Bodyguard");
                    break;
            }

            try
            {
                Console.WriteLine("\nDo You Want To Remove Free Items From The Possible Kills? (Y/N)");
                freeRemove = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid, Defaulting To YES. ");
                Console.ForegroundColor = ConsoleColor.Gray;
                freeRemove = "Y";
            }

            Console.WriteLine($"You Will Have {elusiveTargetAmount} Target(s)!\n");
            if (valiantClones != 0)
            {
                disguisesList.Remove("Facility Guard");
                disguisesList.Remove("Facility Security");

                // Not Sure But Safe Guesses
                disguisesList.Remove("Facility Analyst");
                disguisesList.Remove("Perfect Test Subject");
                disguisesList.Remove("Block Guard");

                killsList.Add("Militia Issued HX-10 SMG");
                killsList.Add("The Splitter SMG");
                killsList.Add("Katana");

                killsList.Remove("Fusil X2000 Stealth");

                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine($"As Well As {valiantClones} Valliant Clones!");
                Console.WriteLine($"The Clones In The Tanks Do Not Count!\n");
                Console.ForegroundColor = ConsoleColor.Gray;

                maxMasteryKills = 1;
                elusiveTargetAmount = 8;
            }

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
            for (int i = 0; i < 36; i++)
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
                int broadint = randomNumber.Next(0, 2);
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

                //LISTS FOR CONDITIONS

                if (broad == true)
                {
                    int killChosenInt = randomNumber.Next(9 + mapItemAmount);
                    if (mapInt == 1 || mapInt == 0)
                    {
                        killsList.Remove("Electrocution");
                        killsList.Remove("Poison");
                        killsList.Remove("Injected Poison");
                        killsList.Remove("SMG");
                        killsList.Remove("Assault Rifle");
                        killsList.Remove("Sniper Rifle");
                        killsList.Remove("Silenced SMG");
                        killsList.Remove("Silenced Assault Rifle");
                        killsList.Remove("Silenced Sniper Rifle");
                        killsList.Remove("Silenced Shotgun");
                        killsList.Remove("Loud Shotgun");
                        killsList.Remove("Loud SMG");
                        killsList.Remove("Loud Assault Rifle");
                        killsList.Remove("Loud SMG");
                        killsList.Remove("Loud Pistol Elimination");
                        killsList.Remove("Silenced Pistol Elimination");
                        killsList.Remove("Loud SMG Elimination");
                        killsList.Remove("Silenced SMG Elimination");
                        killsList.Remove("Loud Sniper Rifle");
                        killsList.Remove("Explosive Device");
                        killsList.Remove("Any Axe");
                        killsList.Remove("Any Sword");
                        killsList.Remove("Any Machete");
                        killsList.Remove("Any Knife");

                        killsList.Add("Silenced Pistol");
                        killsList.Add("Fiber Wire");

                        if (mapInt == 1)
                        {
                            killsList.Add("Loud Pistol Elimination");
                            killsList.Add("Silenced Pistol Elimination");
                            killsList.Add("Loud Assault Rifle");
                            killsList.Add("Assault Rifle");
                        }

                        if (killsMastery > 2)
                        {
                            broad = true;
                            killsList.Remove("Fiber Wire");
                            killsList.Remove("Poison");
                            killsList.Remove("Injected Poison");
                            killsList.Remove("Explosive Device");
                            killsList.Remove("SMG");
                            killsList.Remove("Assault Rifle");
                            killsList.Remove("Sniper Rifle");
                            killsList.Remove("Silenced SMG");
                            killsList.Remove("Silenced Assault Rifle");
                            killsList.Remove("Silenced Pistol");
                            killsList.Remove("Silenced Sniper Rifle");
                            killsList.Remove("Silenced Shotgun");
                            killsList.Remove("Loud Shotgun");
                            killsList.Remove("Loud SMG");
                            killsList.Remove("Loud Assault Rifle");
                            killsList.Remove("Loud SMG");
                            killsList.Remove("Loud Sniper Rifle");
                            killsList.Remove("Any Axe");
                            killsList.Remove("Any Sword");
                            killsList.Remove("Any Knife");
                            killsList.Remove("Any Machete");

                        }

                        killChosenInt = randomNumber.Next(2 + mapItemAmount);
                    }
                    else if (killsMastery > maxMasteryKills && mapInt != 1 || mapInt != 0)
                    {
                        killChosenInt = randomNumber.Next(9 + mapItemAmount);
                    }
                    else if (killsMastery < maxMasteryKills && mapInt != 1 || mapInt != 0)
                    {
                        killChosenInt = randomNumber.Next(30 + mapItemAmount);
                    }

                    if (killChosenInt != 0)
                    {
                        killChosenInt--;
                    }
                    String killChosen = killsList[killChosenInt];

                    killsList = killsList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();

                    if (killChosen == null || killChosen.Equals("") || killChosen.Equals("Suit"))
                    {
                        while (killChosen == null || killChosen.Equals("") || killChosen.Equals("Suit"))
                        {
                            killChosenInt = randomNumber.Next(32);
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
                        else if (elusiveChosen.Equals("The Procurers"))
                        {
                            elusiveName = "Robert Burk";
                            disguisesList.Remove("Private Investigator");
                        }
                    }

                    if (killsIssued > 0 && elusiveChosen.Equals("The Splitter"))
                    {
                        elusiveName = "Max Vallient Clone";

                        disguisesList.Remove("Facility Guard");
                        disguisesList.Remove("Facility Security");

                        // Not Sure But Safe Guesses
                        disguisesList.Remove("Facility Analyst");
                        disguisesList.Remove("Perfect Test Subject");
                        disguisesList.Remove("Block Guard");

                        killsList.Remove("Fusil X2000 Stealth");
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
                                killsList.Add("DAK X2 Covert Special");
                                killsList.Add("Antique Curved Knife");
                                killsList.Add("Druzhina 34");
                                additions = additions + 5;
                            }
                            else if (masteryLevel >= 18)
                            {
                                killsList.Add("ICA19 Silverballer MK II");
                                killsList.Add("Bartoli 12G Short H");
                                killsList.Add("DAK X2 Covert Special");
                                killsList.Add("Antique Curved Knife");
                                additions = additions + 4;
                            }
                            else if (masteryLevel >= 15)
                            {
                                killsList.Add("ICA19 Silverballer MK II");
                                killsList.Add("Bartoli 12G Short H");
                                killsList.Add("DAK X2 Covert Special");
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
                    bool disruptorPack = contentList[6];
                    bool dropPack = contentList[7];
                    bool splitterPack = contentList[8];
                    bool bankerPack = contentList[9];

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
                    if (disruptorPack == true)
                    {
                        killsList.Add("The Disruptor Resistance Band");
                        additions = additions + 1;
                    }
                    if (dropPack == true)
                    {
                        killsList.Add("The Club Boom 12\" Vinyl Sampler");
                        additions = additions + 1;
                    }
                    if (splitterPack == true)
                    {
                        killsList.Add("The Splitter SMG");
                        killsList.Add("The Splitter Kukri Knife");
                        additions = additions + 2;
                    }

                    if (bankerPack == true)
                    {
                        killsList.Add("The Banker Silenced Pistol");
                        killsList.Add("The Banker Rope");
                        additions = additions + 2;
                    }

                    if (freeRemove.Equals("N", StringComparison.OrdinalIgnoreCase))
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
                        killsList.Add("Ice Axe");
                        killsList.Add("Nitroglycerin");
                        killsList.Add("Remote Explosive Present");
                        killsList.Add("Ancestral Fountain Pen");
                        killsList.Add("ICA19 Iceballer");
                        killsList.Add("Shashka A33 Gold");
                        killsList.Add("Explosive Pen");
                        killsList.Add("Professional Screwdriver");
                        killsList.Add("Burial Dagger");
                        killsList.Add("Golden Sawed Off Bartoli 12G");
                        killsList.Add("Purple Streak ICA19 Classic Baller");
                        

                        additions = additions + 30;
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
                            killChosenInt = randomNumber.Next(30 + additions);
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

                    if (elusiveChosen.Equals("The Stowaway"))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"'Retrieve Dictaphone'");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    if (elusiveChosen.Equals("The Warlord"))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"'Retrieve Files'");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    if (elusiveChosen.Equals("The Entertainer"))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"'Retrieve Guest List'");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    if (elusiveChosen.Equals("The Fixer"))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"'Retrieve The Diamonds'");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    if (elusiveChosen.Equals("The Collector"))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"'Retrieve Painting'");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    if (elusiveChosen.Equals("The Broker"))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"'Retrieve The Ivory White'");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    if (elusiveChosen.Equals("The Fixer"))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"'Retrieve The Diamonds'");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    killsIssued++;
                }
            }
        }
        // --------------------------------------------------------------------------REGULAR 
        if (modeSelect == 2)
        {
            String manualMap = "";
            try
            {
                Console.WriteLine("Would You Like To Choose a map? (Y/N)");
                manualMap = Console.ReadLine();
                if (!manualMap.Equals("Y", StringComparison.OrdinalIgnoreCase) && !manualMap.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    manualMap = "N";
                }
            }
            catch (Exception ex)
            {
                manualMap = "N";
            }

            mapInt = 0;

            if (manualMap.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                try
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
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("None Chosen, Choosing Random... ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    mapInt = randomNumber.Next(31);
                    mapChosen = mapsList[mapInt];
                }
            }
            if (manualMap.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                mapInt = randomNumber.Next(31);
                mapChosen = mapsList[mapInt];
            }

            Console.Write($"\nThe Map Chosen Was ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{mapChosen}!");
            Console.ForegroundColor = ConsoleColor.Gray;

            //RANDOM KILLS

            float targetAmount = 5;

            try
            {
                Console.WriteLine("How Many Targets Do You Want? ");
                Console.WriteLine("WARNING: Target Amounts Above 5 Not Guaranteed To Be Possible. ");
                targetAmount = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("None Chosen, Defaulting To 5. ");
                Console.ForegroundColor = ConsoleColor.Gray;
                targetAmount = 5;
            }

            int modifierSelect;

            if (mapInt == 1 || mapInt == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Extra Conditions s on ICA Maps! Sorry.");
                Console.ForegroundColor = ConsoleColor.Gray;
                modifierSelect = 1;
            }
            else
            {
                Console.WriteLine("\nModifier Selection:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. None");
                Console.WriteLine("2. Axe-Faced Lunatic");
                Console.WriteLine("3. ICA Medieval Division");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nWARNING: Modifier Spins Are Not Guaranteed To Be Completable:");
                Console.ForegroundColor = ConsoleColor.Gray;
                try
                {
                    modifierSelect = Int32.Parse(Console.ReadLine());
                    if (modifierSelect > 4)
                    {
                        modifierSelect = 1;
                    }
                }
                catch (Exception e)
                {
                    modifierSelect = 1;
                }

            }


            // --------------------------------------------------------------------------MODIFIERS



            String anyOnly = "";

            if (modifierSelect == 1)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nDo You Only Want ANY/ANY Kills? (Y/N)");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    anyOnly = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid, Defaulting To NO. ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    anyOnly = "N";
                }
            }

            try
            {
                if (!anyOnly.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Do You Want To Remove Free Items From The Possible Kills? (Y/N)");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    freeRemove = Console.ReadLine();

                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid, Defaulting To YES. ");
                Console.ForegroundColor = ConsoleColor.Gray;
                freeRemove = "Y";
            }

            if (targetAmount == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not Enough Targets Chosen. Defaulting To 1.");
                Console.ForegroundColor = ConsoleColor.Gray;
                targetAmount = 1;
            }
            else if (targetAmount > 15)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Too Many Targets Chosen, Lowering To 15.");
                Console.ForegroundColor = ConsoleColor.Gray;
                targetAmount = 15;
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

            for (int i = 0; i < 36; i++)
            {
                String data = readerKillsBroad.ReadLine();
                killsList.Add(data);
            }

            for (int i = 0; i < lineCount; i++)
            {
                String data = readerKills.ReadLine();
                killsList.Add(data);
                mapItemAmount++;
                switch (modifierSelect)
                {
                    case 2:
                        killsList.RemoveAll(item =>
                        !item.Contains("axe", StringComparison.OrdinalIgnoreCase) &&
                        !item.Contains("hatchet", StringComparison.OrdinalIgnoreCase));
                        break;
                    case 3:
                        killsList.RemoveAll(item =>
                            !item.Contains("axe", StringComparison.OrdinalIgnoreCase) &&
                            !item.Contains("sword", StringComparison.OrdinalIgnoreCase) &&
                            !item.Contains("broad", StringComparison.OrdinalIgnoreCase) &&
                            !item.Contains("saber", StringComparison.OrdinalIgnoreCase) &&
                            !item.Contains("scrap", StringComparison.OrdinalIgnoreCase) &&
                            !item.Contains("knife", StringComparison.OrdinalIgnoreCase) &&
                            !item.Contains("dagger", StringComparison.OrdinalIgnoreCase));
                        break;
                }
            }

            while (killsIssued < targetAmount)
            {

                if (!anyOnly.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    int broadint = randomNumber.Next(0, 2);
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

                    // Trying without this for now, kills were getting way too stale. not sure if it'll be balanced or not. But we'll see I suppose.

                    
                    if (killsMastery > 2)
                    {
                        broad = true;
                        killsList.Remove("Fiber Wire");
                        killsList.Remove("Poison");
                        killsList.Remove("Injected Poison");
                        killsList.Remove("Explosive Device");
                        killsList.Remove("SMG");
                        killsList.Remove("Assault Rifle");
                        killsList.Remove("Sniper Rifle");
                        killsList.Remove("Silenced SMG");
                        killsList.Remove("Silenced Assault Rifle");
                        killsList.Remove("Silenced Pistol");
                        killsList.Remove("Silenced Sniper Rifle");
                        killsList.Remove("Silenced Shotgun");
                        killsList.Remove("Loud Shotgun");
                        killsList.Remove("Loud SMG");
                        killsList.Remove("Loud Assault Rifle");
                        killsList.Remove("Loud SMG");
                        killsList.Remove("Loud Sniper Rifle");
                        killsList.Remove("Any Axe");
                        killsList.Remove("Any Sword");
                        killsList.Remove("Any Knife");
                        killsList.Remove("Any Machete");

                    }

                    

                    //LISTS FOR CONDITIONS

                    if (broad == true)
                    {
                        int killChosenInt = randomNumber.Next(9 + mapItemAmount);
                        if (mapInt == 1 || mapInt == 0)
                        {
                            killsList.Remove("Electrocution");
                            killsList.Remove("Poison");
                            killsList.Remove("Injected Poison");
                            killsList.Remove("SMG");
                            killsList.Remove("Assault Rifle");
                            killsList.Remove("Sniper Rifle");
                            killsList.Remove("Silenced SMG");
                            killsList.Remove("Silenced Assault Rifle");
                            killsList.Remove("Silenced Sniper Rifle");
                            killsList.Remove("Silenced Shotgun");
                            killsList.Remove("Loud Shotgun");
                            killsList.Remove("Loud SMG");
                            killsList.Remove("Loud Assault Rifle");
                            killsList.Remove("Loud SMG");
                            killsList.Remove("Loud Pistol Elimination");
                            killsList.Remove("Silenced Pistol Elimination");
                            killsList.Remove("Loud SMG Elimination");
                            killsList.Remove("Silenced SMG Elimination");
                            killsList.Remove("SMG Elimination");
                            killsList.Remove("Loud Sniper Rifle");
                            killsList.Remove("Explosive Device");
                            killsList.Remove("Any Axe");
                            killsList.Remove("Any Sword");
                            killsList.Remove("Any Machete");
                            killsList.Remove("Any Knife");

                            killsList.Add("Silenced Pistol");
                            killsList.Add("Fiber Wire");

                            if (mapInt == 1)
                            {
                                killsList.Remove("Silenced Pistol Elimination");
                                killsList.Remove("Loud Pistol Elimination");
                                killsList.Add("Loud Assault Rifle");
                                killsList.Add("Assault Rifle");
                            }

                            killChosenInt = randomNumber.Next(2 + mapItemAmount);
                        }
                        else if (killsMastery > 2 && mapInt != 1 || mapInt != 0)
                        {
                            if (modifierSelect != 1)
                            {
                                int listAmountModifier = killsList.Count();
                                killsList.Remove("White Katana");
                                killsList.Remove("Masamune");
                                killsList.Remove("The Proud Swashbuckler");
                                killsList.Remove("The Iridescent Katana");
                                killsList.Remove("The Cat's Claw");
                                killsList.Remove("Ice Axe");
                                killsList.Remove("The Ornamental Katana");
                                killsList.Remove("The Black Almond's Dagger");
                                killsList.Remove("The Makeshift Katana");
                                killsList.Remove("Hobby Knife");
                                killsList.Remove("Tanto");
                                killsList.Remove("Concealable Knife");
                                if (mapInt != 21)
                                {
                                    killsList.Remove("Broadsword");
                                }
                                if (mapInt != 30 && mapInt != 23)
                                {
                                    killsList.Remove("Jarl's Pirate Saber");
                                }
                                if (listAmountModifier > killsList.Count())
                                {
                                    listAmountModifier = killsList.Count() -1;
                                }
                                killChosenInt = randomNumber.Next(listAmountModifier);
                            }
                            else
                            {
                                killChosenInt = randomNumber.Next(9 + mapItemAmount);
                            }
                        }
                        else if (killsMastery < 2 && mapInt != 1 || mapInt != 0)
                        {
                            if (modifierSelect != 1)
                            {
                                int listAmountModifier = killsList.Count();
                                killChosenInt = randomNumber.Next(listAmountModifier);
                            }
                            else
                            {
                                killChosenInt = randomNumber.Next(30 + mapItemAmount);
                            }
                        }

                        if (killChosenInt != 0)
                        {
                            killChosenInt--;
                        }
                        String killChosen = killsList[killChosenInt];

                        killsList = killsList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();

                        if (killChosen == null || killChosen.Equals("") || killChosen.Equals("Suit"))
                        {
                            while (killChosen == null || killChosen.Equals("") || killChosen.Equals("Suit"))
                            {
                                killChosenInt = randomNumber.Next(32);
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
                                    killsList.Add("DAK X2 Covert Special");
                                    killsList.Add("Antique Curved Knife");
                                    killsList.Add("Druzhina 34");
                                    additions = additions + 5;
                                }
                                else if (masteryLevel >= 18)
                                {
                                    killsList.Add("ICA19 Silverballer MK II");
                                    killsList.Add("Bartoli 12G Short H");
                                    killsList.Add("DAK X2 Covert Special");
                                    killsList.Add("Antique Curved Knife");
                                    additions = additions + 4;
                                }
                                else if (masteryLevel >= 15)
                                {
                                    killsList.Add("ICA19 Silverballer MK II");
                                    killsList.Add("Bartoli 12G Short H");
                                    killsList.Add("DAK X2 Covert Special");
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
                        bool disruptorPack = contentList[6];
                        bool dropPack = contentList[7];
                        bool splitterPack = contentList[8];
                        bool bankerPack = contentList[8];

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
                        if (disruptorPack == true)
                        {
                            killsList.Add("The Disruptor Resistance Band");
                            additions = additions + 1;
                        }
                        if (dropPack == true)
                        {
                            killsList.Add("The Club Boom 12\" Vinyl Sampler");
                            additions = additions + 1;
                        }
                        if (splitterPack == true)
                        {
                            killsList.Add("The Splitter SMG");
                            killsList.Add("The Splitter Kukri Knife");
                            additions = additions + 2;
                        }

                        if (bankerPack == true)
                        {
                            killsList.Add("The Banker Silenced Pistol");
                            killsList.Add("The Banker Rope");
                            additions = additions + 2;
                        }

                        if (freeRemove.Equals("N", StringComparison.OrdinalIgnoreCase))
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
                            killsList.Add("Ice Axe");
                            killsList.Add("Nitroglycerin");
                            killsList.Add("Remote Explosive Present");
                            killsList.Add("Ancestral Fountain Pen");
                            killsList.Add("ICA19 Iceballer");
                            killsList.Add("Shashka A33 Gold");
                            killsList.Add("Explosive Pen");
                            killsList.Add("Professional Screwdriver");
                            killsList.Add("Burial Dagger");
                            killsList.Add("Golden Sawed Off Bartoli 12G");
                            killsList.Add("Purple Streak ICA19 Classic Baller");

                            additions = additions + 30;
                        }

                        #endregion

                        if (modifierSelect != 1)
                        {
                            switch (modifierSelect)
                            {
                                case 2:
                                    killsList.RemoveAll(item => !item.Contains("axe", StringComparison.OrdinalIgnoreCase));
                                    break;
                                case 3:
                                    killsList.RemoveAll(item =>
                                        !item.Contains("axe", StringComparison.OrdinalIgnoreCase) &&
                                        !item.Contains("sword", StringComparison.OrdinalIgnoreCase) &&
                                        !item.Contains("broad", StringComparison.OrdinalIgnoreCase) &&
                                        !item.Contains("saber", StringComparison.OrdinalIgnoreCase) &&
                                        !item.Contains("swashbuckler", StringComparison.OrdinalIgnoreCase) &&
                                        !item.Contains("claw", StringComparison.OrdinalIgnoreCase) &&
                                        !item.Contains("katana", StringComparison.OrdinalIgnoreCase) &&
                                        !item.Contains("tanto", StringComparison.OrdinalIgnoreCase) &&
                                        !item.Contains("masamune", StringComparison.OrdinalIgnoreCase) &&
                                        !item.Contains("dagger", StringComparison.OrdinalIgnoreCase));
                                    break;
                            }
                        }

                        int valueList = killsList.Count();
                        int killChosenInt = randomNumber.Next(valueList);
                        String killChosen = killsList[killChosenInt];

                        killsList = killsList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();

                        if (killChosen == null || killChosen.Equals("") || killChosen.Equals("Suit"))
                        {
                            while (killChosen == null || killChosen.Equals("") || killChosen.Equals("Suit"))
                            {
                                if (modifierSelect == 1)
                                {
                                    killChosenInt = randomNumber.Next(30 + additions);
                                    killChosen = killsList[killChosenInt];
                                }
                                else
                                {
                                    switch (modifierSelect)
                                    {
                                        case 2:
                                            killsList.RemoveAll(item => !item.Contains("axe", StringComparison.OrdinalIgnoreCase));
                                            break;
                                        case 3:
                                            killsList.RemoveAll(item =>
                                                !item.Contains("axe", StringComparison.OrdinalIgnoreCase) &&
                                                !item.Contains("sword", StringComparison.OrdinalIgnoreCase) &&
                                                !item.Contains("broad", StringComparison.OrdinalIgnoreCase) &&
                                                !item.Contains("scrap", StringComparison.OrdinalIgnoreCase) &&
                                                !item.Contains("saber", StringComparison.OrdinalIgnoreCase) &&
                                                !item.Contains("knife", StringComparison.OrdinalIgnoreCase) &&
                                                !item.Contains("dagger", StringComparison.OrdinalIgnoreCase));
                                            break;
                                    }
                                    killChosenInt = randomNumber.Next(valueList);
                                    killChosen = killsList[killChosenInt];
                                }
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
            String targetChosen = targetList[targetInt];

            targetChosen = CheckInvalidDisguises(ref targetChosen, ref targetInt, ref lineCount);
            targetChosen = CheckUniqueDisguises(ref targetChosen, ref targetInt, ref lineCount, mapInt);

            previousTarget.Add(targetChosen);

            Console.Write($"Eliminate ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"'{targetChosen}'");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        void AddToUniqueList(ref List<String> uniqueList, string targetRetrieved)
        {
            targetRetrieved = targetRetrieved.Trim();
            uniqueList.Add(targetRetrieved);
        }

        string CheckUniqueDisguises(ref string targetChosen, ref int targetInt, ref int lineCount, int mapID)
        {
            int lineCountUnique = File.ReadLines($"../../txt/UniqueKills.txt").Count();

            StreamReader readerUnique = new StreamReader($"../../txt/UniqueKills.txt");
            List<String> uniqueList = new List<String>();
            if (mapID == 6)
            {
                AddToUniqueList(ref uniqueList, "Mansion Chef");
                AddToUniqueList(ref uniqueList, "Housekeeper");
            }
            else if (mapID == 8)
            {
                AddToUniqueList(ref uniqueList, "Bodyguard");
            }
            else if (mapID == 9)
            {
                AddToUniqueList(ref uniqueList, "Handyman");
            }
            else if (mapID == 23)
            {
                AddToUniqueList(ref uniqueList, "Bodyguard");
            }

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
                            targetChosen = CheckUniqueDisguises(ref targetChosen, ref targetInt, ref lineCount, mapInt);
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
                targetChosen = CheckUniqueDisguises(ref targetChosen, ref targetInt, ref lineCount, mapInt);

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
