using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Numerics;

namespace Projektas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> PlayerName = new List<string>{ null, null};
            int[] PlayerScores = { 0, 0, 0, 0, 0, 0};
            Dictionary<List<string>, int[]> PlayerData = new Dictionary<List<string>, int[]>() //Added additional "players" for rankings display
            {
                {new List<string>{"Player", "One"}, new int[] {23, 12, 0, 43, 37, 8 } },
                {new List<string>{"Player", "Two"}, new int[] {16, 27, 2, 19, 0, 24 } },
                {new List<string>{"Player", "Three"}, new int[] {0, 36, 12, 22, 39, 10 } },
                {new List<string>{"Player", "Four"}, new int[] {5, 10, 4, 32, 43, 0 } },
                {new List<string>{"Player", "Five"}, new int[] {0, 8, 0, 13, 17, 31} }
            };
            string[] QuestionCategories = {"Filmai", "Sportas", "Istorija", "Geografija", "Gamta" , "Menas"};
            string input = "q";
            int MenuSteps = 0;
            while (true)
            {
                //(MenuSteps = 0) - program start (login, register, start menu); (MenuSteps = 1) - program main menu (game, scoreboard, rules, rankings);
                if (input == "q" && MenuSteps == 0) StartMenu(ref input, ref MenuSteps);
                if (input == "1" && MenuSteps == 0) Login(ref input, ref MenuSteps, ref PlayerData, ref PlayerName);
                if (input == "2" && MenuSteps == 0) Registration(ref input, ref MenuSteps, ref PlayerData, ref PlayerScores, ref PlayerName);
                if (MenuSteps == 1) MainMenu(ref input, ref MenuSteps, ref PlayerName);
                if (input == "1" && MenuSteps == 1) StartGame(ref input, ref QuestionCategories, ref MenuSteps, ref PlayerData, ref PlayerName);
                if (input == "2" && MenuSteps == 1) MainMenuRules(ref input, ref MenuSteps);
                if (input == "3" && MenuSteps == 1) MainMenuPersonalScoreboard(ref input, ref MenuSteps, ref PlayerData, ref QuestionCategories, ref PlayerName);
                if (input == "4" && MenuSteps == 1) MainMenuRankings(ref input, ref MenuSteps, ref PlayerData, ref QuestionCategories, ref PlayerName);
                if (input == "q" && MenuSteps == -1) break;
            }
        }
        public static void StartMenu(ref string input, ref int MenuSteps)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("P");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("R");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("O");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("T");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("M");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("U");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Š");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("I");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("S");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Sveiki atvyke!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1 - Prisijungti");
            Console.WriteLine("2 - Registruotis");
            Console.WriteLine("q - Išeiti");
            input = Console.ReadLine();
            while (input != "1" && input != "2" && input != "q")
            {
                Console.WriteLine("Bloga Ivestis");
                input = Console.ReadLine();
            }
            if (input == "q")
            {
                MenuSteps = -1;
            }
        }
        public static void Login(ref string input, ref int MenuSteps, ref Dictionary<List<string>, int[]> PlayerData, ref List<string> PlayerName)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Prisijungimas");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Iveskite varda pavarde");
            PlayerName[0] = Console.ReadLine();
            PlayerName[1] = Console.ReadLine();
            bool LoginSucess = false;
            foreach (var player in PlayerData)
            {
                if (PlayerName[0] == player.Key[0] && PlayerName[1] == player.Key[1])
                {
                    LoginSucess = true;
                }

            }
            if (LoginSucess == true)
            {
                Console.Clear();
                Console.WriteLine("Sekmingai prisijungete");
                Thread.Sleep(2000);
                MenuSteps = 1;
            }
            else
            {
                Console.Clear(); ;
                Console.WriteLine("Toks zaidejas neegzistuoja");
                Thread.Sleep(2000);
                Console.Clear();
                MenuSteps = 0;
                input = "q";
            }
        }
        public static void Registration(ref string input, ref int MenuSteps, ref Dictionary<List<string>, int[]> PlayerData, ref int[] PlayerScores, ref List<string> PlayerName)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Registracija");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Iveskite varda pavarde");
            string[] PlayerNameInput = {null, null};
            PlayerName[0] = Console.ReadLine();
            PlayerName[1] = Console.ReadLine();
            bool CheckIfPlayerAlreadyRegistered = false;
            while (CheckIfPlayerAlreadyRegistered == false) 
            {
                foreach (var Player in PlayerData)
                {
                    if (PlayerName[0] == Player.Key[0] && PlayerName[1] == Player.Key[1]) CheckIfPlayerAlreadyRegistered = true;
                }
                if (CheckIfPlayerAlreadyRegistered == true)
                {
                    Console.WriteLine("Toks zaidejas jau egzistuoja");
                    Thread.Sleep(2000);
                    MenuSteps = 0;
                    input = "q";
                }
                else
                {
                    CheckIfPlayerAlreadyRegistered = true;
                    PlayerData.Add(PlayerName.ToList(), PlayerScores);
                    Console.Clear();
                    Console.WriteLine("Sekmingai prisiregistravote");
                    Thread.Sleep(2000);
                    MenuSteps = 1;
                }
            }
        } 
        public static void MainMenu(ref string input, ref int MenuSteps, ref List<string> PlayerName)
        {
            MenuSteps = 1;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Sveikiname prisijungus, " + PlayerName[0] + " " + PlayerName[1]);
            Console.WriteLine("Pagrindinis meniu:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1 - Pradėti žaidimą");
            Console.WriteLine("2 - Taisykės");
            Console.WriteLine("3 - Jūsų rezultatai");
            Console.WriteLine("4 - Reitingai");
            Console.WriteLine("q - Iseiti");
            input = Console.ReadLine();
            while (input != "1" && input != "2" && input != "3" && input != "4" && input != "q")
            {
                Console.WriteLine("Bloga Ivestis");
                input = Console.ReadLine();
            }
            if (input == "q") MenuSteps = 0;
        }
        public static void MainMenuRules(ref string input, ref int MenuSteps)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Taisykles:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Zaidimo tikslas - teisingai atsakyti į klausimus.");
            Console.WriteLine("Kiekvienas teisingas klausimas prideda 5 taškus.");
            Console.WriteLine("Pradėkite naują žaidimą ir pasirinkite dominančią temą.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Sėkmės!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Irašykite bet ką norint grįžti atgal");
            input = Console.ReadLine();
            Console.Clear();
            MenuSteps = 1;
        }
        public static void MainMenuPersonalScoreboard(ref string input, ref int MenuSteps, ref Dictionary<List<string>, int[]> PlayerData, ref string[] QuestionCategories, ref List<string> PlayerName) 
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Jusu rezultatai:");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var Player in PlayerData) 
            { 
                if(PlayerName[0] == Player.Key[0] && PlayerName[1] == Player.Key[1])
                {
                    int[] Playerpoints = PlayerData[Player.Key];
                    for (int i = 0; i < Playerpoints.Length; i++)
                    {
                        if (i >= 7) break;
                        Console.WriteLine((i+1) + ") " + QuestionCategories[i] + "; Taškai: " + Playerpoints[i]);
                    }
                }
            }
            Console.WriteLine("Irašykite bet ką norint grįžti atgal");
            input = Console.ReadLine();
            Console.Clear();
            MenuSteps = 1;
        }
        public static void StartGame(ref string input, ref string[] QuestionCategories, ref int MenuSteps, ref Dictionary<List<string>, int[]> PlayerData, ref List<string> PlayerName)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Pradėti žaidimą");
            Console.WriteLine("Pasirinkite kategoriją:");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0;i < QuestionCategories.Length;i++)
            {
                Console.WriteLine((i + 1) + " - " + QuestionCategories[i]);
            }
            Console.WriteLine("q - Grįžti atgal");
            input = Console.ReadLine();
            while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5" && input != "6" && input != "7" && input != "q")
            {
                Console.WriteLine("Bloga Ivestis");
                input = Console.ReadLine();
            }
            if (input == "q") MenuSteps = 1;
            else if (input == "1" || input == "2" || input == "3" || input == "4" || input == "5" || input == "6" || input == "7")
            {
                int.TryParse(input, out int CurrentCategory);
                CurrentCategory--;
                int Playerscore = 0;
                //Create Random Array for questions:

                List<int> RandomList = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }; // needs changing
                Random rnd = new Random();
                int[] QuestionSequence = new int[10];
                for (int i = 0; i < 10; i++)
                {
                    int temp = rnd.Next(0, RandomList.Count);
                    QuestionSequence[i] = RandomList[temp];
                    RandomList.RemoveAt(temp);
                }

                //Game starts
                for (int i = 0; i < 10; i++)
                {
                    int CurrentRandomQuestionPick = new int();
                    string CurrentQuestion = null;
                    string[] CurrentAnswers = new string[4];
                    int CurrentCorrectAnswer = 0;
                    GameQuestions(ref CurrentCategory, ref CurrentQuestion, ref CurrentAnswers, ref CurrentCorrectAnswer, ref QuestionSequence[i]);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(i + 1 + " Klausimas:");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(CurrentQuestion);
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int j = 0; j < 4; j++)
                    {
                        Console.WriteLine(j + 1 + ") " + CurrentAnswers[j]);
                    }
                    input = Console.ReadLine();
                    while (input != "1" && input != "2" && input != "3" && input != "4")
                    {
                        Console.WriteLine("Bloga Ivestis");
                        input = Console.ReadLine();
                    }

                    // Showing answers
                    Console.Clear(); 
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(i + 1 + " Klausimas:");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(CurrentQuestion);
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int j = 0; j < 4; j++)
                    {
                        if (input == (CurrentCorrectAnswer + 1).ToString() && CurrentCorrectAnswer == j)
                        {
                            Playerscore = Playerscore + 5;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(j + 1 + ") " + CurrentAnswers[j]);
                        }
                        else if (j == CurrentCorrectAnswer)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(j + 1 + ") " + CurrentAnswers[j]);
                        }
                        else if (input == (j + 1).ToString() && input != (CurrentCorrectAnswer + 1).ToString())
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(j + 1 + ") " + CurrentAnswers[j]);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(j + 1 + ") " + CurrentAnswers[j]);
                        }
                    }
                    Thread.Sleep(2000);
                }
                Console.Clear();
                // Showing points and adding them to PlayerData
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Jusu taskai: " + Playerscore);
                Thread.Sleep(3000);
                foreach (var PlayerPoints in PlayerData)
                {
                    if (PlayerPoints.Key[0] == PlayerName[0] && PlayerPoints.Key[1] == PlayerName[1])
                    {
                        PlayerPoints.Value[CurrentCategory] = Playerscore;
                    }
                }
                input = "q";
                MenuSteps = 1;
            }
        }
        public static void MainMenuRankings(ref string input, ref int MenuSteps, ref Dictionary<List<string>, int[]> PlayerData, ref string[] QuestionCategories, ref List<string> PlayerName)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Reitingai");
            Console.WriteLine("Pasirinkite kategoriją:");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < QuestionCategories.Length; i++)
            {
                Console.WriteLine((i + 1) + " - " + QuestionCategories[i]);
            }
            Console.WriteLine("7 - Bendri rezultatai ");
            Console.WriteLine("q - Grįžti atgal");
            input = Console.ReadLine();
            while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5" && input != "6" && input != "7" && input != "q")
            {
                Console.WriteLine("Bloga Ivestis");
                input = Console.ReadLine();
            }
            var SortedPlayerData = PlayerData;
            string[,] SortedPlayerName = new string[PlayerData.Count, 2];
            int[,] SortedPlayerScores = new int[PlayerData.Count, 8];
            int foreachCycle = 0;
            // Showing results by category
            foreach (var player in PlayerData)
            {
                SortedPlayerName[foreachCycle, 0] = player.Key[0];
                SortedPlayerName[foreachCycle, 1] = player.Key[1];

                SortedPlayerScores[foreachCycle, 0] = player.Value[0];
                SortedPlayerScores[foreachCycle, 1] = player.Value[1];
                SortedPlayerScores[foreachCycle, 2] = player.Value[2];
                SortedPlayerScores[foreachCycle, 3] = player.Value[3];
                SortedPlayerScores[foreachCycle, 4] = player.Value[4];
                SortedPlayerScores[foreachCycle, 5] = player.Value[5];
                foreachCycle++;
            }
            if (input == "q")
            {
                MenuSteps = 1;
            }
            else if (input == "1" || input == "2" || input == "3" || input == "4" || input == "5" || input == "6")
            {
                for (int i = 0; i < QuestionCategories.Length; i++)
                {
                    if (input == (i+1).ToString())
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Reitingai - " + QuestionCategories[i]);
                        Console.ForegroundColor = ConsoleColor.White;
                        for (int b = 0; b < PlayerData.Count; b++)
                        {
                            int temp = SortedPlayerScores[0, i];
                            int CorrectPosition = 0;
                            for (int j = 0; j < PlayerData.Count; j++)
                            {
                                if (SortedPlayerScores[j, i] > temp)
                                {
                                    CorrectPosition = j;
                                    temp = SortedPlayerScores[j, i];
                                }
                            }
                            for (int j = 0; j < PlayerData.Count; j++)
                            {
                                if (SortedPlayerScores[j, i] == temp) SortedPlayerScores[j, i] = -1;
                            }
                            if (b == 0) Console.ForegroundColor = ConsoleColor.Yellow;
                            else if (b == 1) Console.ForegroundColor = ConsoleColor.Gray;
                            else if (b == 2) Console.ForegroundColor = ConsoleColor.DarkYellow;
                            else Console.ForegroundColor = ConsoleColor.White;

                            if (SortedPlayerName[CorrectPosition, 0] == PlayerName[0] && SortedPlayerName[CorrectPosition, 1] == PlayerName[1]) Console.ForegroundColor = ConsoleColor.Green;

                            if (temp <= 0) break;
                            else Console.WriteLine((b + 1) + ") " + SortedPlayerName[CorrectPosition, 0] + " " + SortedPlayerName[CorrectPosition, 1] + " " + temp); //i nesikeicia
                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Irašykite bet ką norint grįžti atgal");
                input = Console.ReadLine();
                MenuSteps = 1;
                Console.Clear();
            }
            // Showing summed up results
            else if (input == "7")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Bendri taškų reitingai:");
                Console.ForegroundColor = ConsoleColor.White;
                int[] TotalScore = new int[PlayerData.Count];
                for (int i = 0; i < SortedPlayerScores.GetLength(0); i++)
                {
                    int sum = 0;
                    for (int j = 0; j < SortedPlayerScores.GetLength(1); j++)
                    {
                        sum = sum + SortedPlayerScores[i, j];
                    }
                    TotalScore[i] = sum;
                }
                int temp = TotalScore[0];
                int CorrectPosition = 0;
                for (int i = 0;i < TotalScore.Length; i++)
                {
                    for (int j = 0; j < TotalScore.Length; j++)
                    {
                        if (TotalScore[j] > temp)
                        {
                            CorrectPosition = j;
                            temp = TotalScore[j];
                        }
                    }
                    for (int j = 0; j < TotalScore.Length; j++)
                    {
                        if (TotalScore[CorrectPosition] == temp) TotalScore[CorrectPosition] = -1;
                    }
                    if (i == 0) Console.ForegroundColor = ConsoleColor.Yellow;
                    else if (i == 1) Console.ForegroundColor = ConsoleColor.Gray;
                    else if (i == 2) Console.ForegroundColor = ConsoleColor.DarkYellow;
                    else Console.ForegroundColor = ConsoleColor.White;
                    if (SortedPlayerName[CorrectPosition, 0] == PlayerName[0] && SortedPlayerName[CorrectPosition, 1] == PlayerName[1]) Console.ForegroundColor = ConsoleColor.Green;
                    if (temp > 0) Console.WriteLine(i+1 + ") " + SortedPlayerName[CorrectPosition, 0] + " " + SortedPlayerName[CorrectPosition, 1] + " " + temp);
                    temp = 0;
                    CorrectPosition = 0;
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Irašykite bet ką norint grįžti atgal");
                input = Console.ReadLine();
                MenuSteps = 1;
                Console.Clear();
            }
        }
        public static void GameQuestions(ref int CurrentCategory, ref string CurrentQuestion, ref string[] CurrentAnswers, ref int CurrentCorrectAnswer, ref int CurrentRandomQuestionPick)
        {
            string[,] questions = new string[6, 10];
            string[,,] answers = new string[6, 10, 4];
            int[,] correctanswers = new int[6, 10];
            //Filmai
            {
                questions[0, 0] = "Kokia yra ilgiausio sukurto filmo \"The Logistics of the Firm\" trukmė?";
                answers[0, 0, 0] = "1) 5h";
                answers[0, 0, 1] = "2) 12h";
                answers[0, 0, 2] = "3) 237h";
                answers[0, 0, 3] = "4) 857h";
                correctanswers[0, 0] = 3;

                questions[0, 1] = "Koks yra pirmojo 3D filmo pavadinimas, kuris buvo isleistas 1922m.?";
                answers[0, 1, 0] = "\"The Cat and the Kit\"";
                answers[0, 1, 1] = "\"The Power of Love\"";
                answers[0, 1, 2] = "\"Alpine Antics\"";
                answers[0, 1, 3] = "\"Little Red Riding Hood\"";
                correctanswers[0, 1] = 1;

                questions[0, 2] = "Koks yra visų laikų daugiausiai uždirbęs filmas (2,9 mlrd. $)?";
                answers[0, 2, 0] = "\"Avatar\"";
                answers[0, 2, 1] = "\"Avengers: Endgame\"";
                answers[0, 2, 2] = "\"Titanic\"";
                answers[0, 2, 3] = "\"The Lion King\"";
                correctanswers[0, 2] = 0;

                questions[0, 3] = "Koks filmas savo siužete turi daugiausiai žudikų?";
                answers[0, 3, 0] = "\" Scarface\"";
                answers[0, 3, 1] = "\"Expendables 3\"";
                answers[0, 3, 2] = "\"John Wick: Chapter 3 - Parabellum\"";
                answers[0, 3, 3] = "\"The Godfather\"";
                correctanswers[0, 3] = 2;

                questions[0, 4] = "Koks yra pirmasis animacinis filmas, sukurtas \"Pixar\" studijos?";
                answers[0, 4, 0] = "\"Monsters, Inc.\"";
                answers[0, 4, 1] = "\"A Bug's Life\"";
                answers[0, 4, 2] = "\"Toy Story\"";
                answers[0, 4, 3] = "\"The Lion King\"";
                correctanswers[0, 4] = 2;

                questions[0, 5] = "Kuris iš šių aktoriu nevaidino Jokerio?";
                answers[0, 5, 0] = "Jack Nicholson";
                answers[0, 5, 1] = "Aaron Eckhart";
                answers[0, 5, 2] = "Heath Ledger";
                answers[0, 5, 3] = "Joaquin Phoenix";
                correctanswers[0, 5] = 1;

                questions[0, 6] = "Kas sukūrė Krikštatėvį? (\"Godfather\")";
                answers[0, 6, 0] = "Francis Ford Coppola";
                answers[0, 6, 1] = "Sergio Leone";
                answers[0, 6, 2] = "Robert Wise";
                answers[0, 6, 3] = "Stanley Kubrick";
                correctanswers[0, 6] = 0;

                questions[0, 7] = "Kuris iš šių herojų buvo sukurtas pirmas?";
                answers[0, 7, 0] = "Betmenas";
                answers[0, 7, 1] = "Supermenas";
                answers[0, 7, 2] = "Geležinis žmogus";
                answers[0, 7, 3] = "Žmogus Voras";
                correctanswers[0, 7] = 1;

                questions[0, 8] = "Su kuriuo veikėju yra sukurta daugiausiai kino filmu?";
                answers[0, 8, 0] = "Betmenas";
                answers[0, 8, 1] = "Halkas";
                answers[0, 8, 2] = "Godzila";
                answers[0, 8, 3] = "Haris Poteris";
                correctanswers[0, 8] = 2;

                questions[0, 9] = "Koks aktorius vaidino pirmąjį \"James Bond\"?";
                answers[0, 9, 0] = "George Lazenby";
                answers[0, 9, 1] = "Roger Moore";
                answers[0, 9, 2] = "David Niven";
                answers[0, 9, 3] = "Sean Connery";
                correctanswers[0, 9] = 3;
            }
            //sportas
            {
                questions[1, 0] = "Koks yra populiariausias futbolo klubas pasaulyje?";
                answers[1, 0, 0] = "Real Madrid";
                answers[1, 0, 1] = "Manchester City";
                answers[1, 0, 2] = "Bayern Munchen";
                answers[1, 0, 3] = "Liverpool FC";
                correctanswers[1, 0] = 0;

                questions[1, 1] = "Kurioje šalyje gimė boksas?";
                answers[1, 1, 0] = "Amerikoje";
                answers[1, 1, 1] = "Vokietijoje";
                answers[1, 1, 2] = "Anglijoje";
                answers[1, 1, 3] = "Airijoje";
                correctanswers[1, 1] = 2;

                questions[1, 2] = "Kokia yra ilgiausia oficiali maratono distancija?";
                answers[1, 2, 0] = "42,195 Km";
                answers[1, 2, 1] = "37,265 Km";
                answers[1, 2, 2] = "16,270 Km";
                answers[1, 2, 3] = "40,355 Km";
                correctanswers[1, 2] = 3;

                questions[1, 3] = "Koks yra greičiausias rekordinis pasaulio įrašas 100 metrų begimo srityje?";
                answers[1, 3, 0] = "9,58 s";
                answers[1, 3, 1] = "10.73 s";
                answers[1, 3, 2] = "12.67 s";
                answers[1, 3, 3] = "13.04 s";
                correctanswers[1, 3] = 0;

                questions[1, 4] = "Kada Buvo išrastas krepšinis";
                answers[1, 4, 0] = "1873 m.";
                answers[1, 4, 1] = "1891 m.";
                answers[1, 4, 2] = "1903 m.";
                answers[1, 4, 3] = "1912 m.";
                correctanswers[1, 4] = 1;

                questions[1, 5] = "NBA komandos treneris, turintis daugiausiai pergalių (1364)?";
                answers[1, 5, 0] = "Don Nelson";
                answers[1, 5, 1] = "Gregg Popovich ";
                answers[1, 5, 2] = "Jerry Sloan";
                answers[1, 5, 3] = "George Karl";
                correctanswers[1, 5] = 1;

                questions[1, 6] = "Kelintais metais disko metikas V. Alekna pirmą karta iškovojo auksą?";
                answers[1, 6, 0] = "2000 m.";
                answers[1, 6, 1] = "2001 m.";
                answers[1, 6, 2] = "2002 m.";
                answers[1, 6, 3] = "2003 m.";
                correctanswers[1, 6] = 0;

                questions[1, 7] = "Koks plaukikas laimėjo daugiausiai olimpinių aukso medalių?";
                answers[1, 7, 0] = "Mark Spitz";
                answers[1, 7, 1] = "Michael Phelps";
                answers[1, 7, 2] = "Ian Thorpe";
                answers[1, 7, 3] = "Caeleb Dressel";
                correctanswers[1, 7] = 1;

                questions[1, 8] = "Kokia yra populiariausia sporto šaka Kinijoje?";
                answers[1, 8, 0] = "Plaukimas";
                answers[1, 8, 1] = "Krepšinis";
                answers[1, 8, 2] = "Futbolas";
                answers[1, 8, 3] = "Tinklinis";
                correctanswers[1, 8] = 3;

                questions[1, 9] = "Garsiausias WRC (World Rally Championship) lenktynininkas:";
                answers[1, 9, 0] = "Walter Rohrl";
                answers[1, 9, 1] = "Carlos Sainz";
                answers[1, 9, 2] = "Sebastien Loeb";
                answers[1, 9, 3] = "Colin McRae";
                correctanswers[1, 9] = 2;
            }
            //Istorija
            {
                questions[2, 0] = "Pirmojo pasaulinio karo pabaiga:";
                answers[2, 0, 0] = "1914";
                answers[2, 0, 1] = "1918";
                answers[2, 0, 2] = "1920";
                answers[2, 0, 3] = "1911";
                correctanswers[2, 0] = 1;

                questions[2, 1] = "Kelintame amžiuje Krikščionių Bažnyčia skilo į Rytų ir Vakarų bažnyčias?";
                answers[2, 1, 0] = "V a. ";
                answers[2, 1, 1] = "X a. ";
                answers[2, 1, 2] = "XI a. ";
                answers[2, 1, 3] = "XIII a.";
                correctanswers[2, 1] = 1;

                questions[2, 2] = "Kuri asmenybė XVI a. išleido pirmąją spausdintą Lietuvos Didžiosios Kunigaikštystės istoriją?";
                answers[2, 2, 0] = "Mikalojus Daukša";
                answers[2, 2, 1] = "Abraomas Kulvietis";
                answers[2, 2, 2] = "Martynas Mažvydas";
                answers[2, 2, 3] = "Motiejus Strijkovskis";
                correctanswers[2, 2] = 3;

                questions[2, 3] = "Kurioje valstybėje spaudos  draudimo laikotarpiu susitelkė lietuviškos spaudos leidyba?";
                answers[2, 3, 0] = "Austrijos- Vengrijos imperijoje";
                answers[2, 3, 1] = "Jungtinėse Amerikos valstijose ";
                answers[2, 3, 2] = "Lenkijos karalystėje";
                answers[2, 3, 3] = "Vokietijos imperijoje.";
                correctanswers[2, 3] = 3;

                questions[2, 4] = "Kada Čingischanas pradėjo Azijos užkariavimą";
                answers[2, 4, 0] = "1205 m";
                answers[2, 4, 1] = "1206 m";
                answers[2, 4, 2] = "1207 m";
                answers[2, 4, 3] = "1208 m";
                correctanswers[2, 4] = 2;

                questions[2, 5] = "Antrojo pasaulinio karo pradžia:";
                answers[2, 5, 0] = "1935";
                answers[2, 5, 1] = "1939";
                answers[2, 5, 2] = "1942";
                answers[2, 5, 3] = "1945";
                correctanswers[2, 5] = 1;

                questions[2, 6] = "Kuri valstybė nedalyvavo 1938m, pasirašant Miuncheno susitarimą?";
                answers[2, 6, 0] = "Didžioji Britanija";
                answers[2, 6, 1] = "Italija";
                answers[2, 6, 2] = "Prancūzija";
                answers[2, 6, 3] = "Sovietų sąjunga";
                correctanswers[2, 6] = 3;

                questions[2, 7] = "Kada vyko pirmasis ATR (Abiejų Tautų Respublikos) padalijimas?";
                answers[2, 7, 0] = "XVI a.";
                answers[2, 7, 1] = "XVII a.";
                answers[2, 7, 2] = "XVIII a.";
                answers[2, 7, 3] = "XIV a.";
                correctanswers[2, 7] = 2;

                questions[2, 8] = "Kuri institucija pagal 1992 m. Lietuvos Respublikos Konstituciją nustato valstybinius mokesčius ir kitus privalomus mokėjimus?";
                answers[2, 8, 0] = "Lietuvos bankas";
                answers[2, 8, 1] = "Seimas";
                answers[2, 8, 2] = "Valstybės kontrolė";
                answers[2, 8, 3] = "Vyriausybė";
                correctanswers[2, 8] = 1;

                questions[2, 9] = "Kada vyko Saulės mūšis?";
                answers[2, 9, 0] = "1232";
                answers[2, 9, 1] = "1235";
                answers[2, 9, 2] = "1236";
                answers[2, 9, 3] = "1240";
                correctanswers[2, 9] = 2;
            }
            //Geografija
            {
                questions[3, 0] = "Kuri iš šių šalių yra dykumoje?";
                answers[3, 0, 0] = "Angola";
                answers[3, 0, 1] = "Indija";
                answers[3, 0, 2] = "Tadžikistanas";
                answers[3, 0, 3] = "Mauritanija";
                correctanswers[3, 0] = 3;

                questions[3, 1] = "Kuri iš šių šalių yra arčiausiai pusiaujo?";
                answers[3, 1, 0] = "Tunisas";
                answers[3, 1, 1] = "Indonezija";
                answers[3, 1, 2] = "Venesuela";
                answers[3, 1, 3] = "Argentina";
                correctanswers[3, 1] = 1;

                questions[3, 2] = "Ką apjungia Panamos kanalas?";
                answers[3, 2, 0] = "Baltijos jūrą ir Šiaurės jūrą";
                answers[3, 2, 1] = "Viduržemio jūrą ir Atlanto vandenyną";
                answers[3, 2, 2] = "Viduržemio jūrą ir Raudonąją jūrą";
                answers[3, 2, 3] = "Ramųjį Vandenyną ir Karibų jūrą";
                correctanswers[3, 2] = 3;

                questions[3, 3] = "Kokia yra didžiausia JAV valstija pagal plotą?";
                answers[3, 3, 0] = "Nebraska";
                answers[3, 3, 1] = "Ohajus";
                answers[3, 3, 2] = "Aliaska";
                answers[3, 3, 3] = "Vašingtonas";
                correctanswers[3, 3] = 2;

                questions[3, 4] = "Koks yra didžiausias pasaulio miestas?";
                answers[3, 4, 0] = "Tokijas";
                answers[3, 4, 1] = "Mumbajus";
                answers[3, 4, 2] = "Beijingas";
                answers[3, 4, 3] = "Delhis";
                correctanswers[3, 4] = 0;

                questions[3, 5] = "Kas yra aukščiausias pasaulio kalnas?";
                answers[3, 5, 0] = "Kančendžanga";
                answers[3, 5, 1] = "Monblanas";
                answers[3, 5, 2] = "Everestas";
                answers[3, 5, 3] = "Alpės";
                correctanswers[3, 5] = 2;

                questions[3, 6] = "Kuris vandenynas didžiausias?";
                answers[3, 6, 0] = "Antarkties";
                answers[3, 6, 1] = "Ramusis";
                answers[3, 6, 2] = "Atlanto";
                answers[3, 6, 3] = "Indijos";
                correctanswers[3, 6] = 2;

                questions[3, 7] = "Kokia yra mažiausia pasaulyje valstybė?";
                answers[3, 7, 0] = "Monakas";
                answers[3, 7, 1] = "Vatikanas";
                answers[3, 7, 2] = "San Marinas";
                answers[3, 7, 3] = "Nauru";
                correctanswers[3, 7] = 1;

                questions[3, 8] = "Koks yra didžiausias žemynas?";
                answers[3, 8, 0] = "Pietų Amerika";
                answers[3, 8, 1] = "Australija";
                answers[3, 8, 2] = "Afrika";
                answers[3, 8, 3] = "Azija";
                correctanswers[3, 8] = 3;

                questions[3, 9] = "Kokia yra didžiausia pasaulio upė?";
                answers[3, 9, 0] = "Amazonė";
                answers[3, 9, 1] = "Nilas";
                answers[3, 9, 2] = "Tigras";
                answers[3, 9, 3] = "Eufratas";
                correctanswers[3, 9] = 0;

            }
            //Gamta
            {
                questions[4, 0] = "Kaip vadinamas procesas, kai augalai naudoja saulės šviesą, vandenį ir anglies dvideginį, kad gamintų gliukozę ir deguonį?";
                answers[4, 0, 0] = "Osmosas";
                answers[4, 0, 1] = "Ksiliozė";
                answers[4, 0, 2] = "Fotosintezė";
                answers[4, 0, 3] = "Difuzija";
                correctanswers[4, 0] = 2;

                questions[4, 1] = "Kurį iš šių augalų nerasite natūraliai augančių Lietuvoje?";
                answers[4, 1, 0] = "Vaistinė kraujalakė";
                answers[4, 1, 1] = "Miltinė meškauogė";
                answers[4, 1, 2] = "Baltasis Dobilas";
                answers[4, 1, 3] = "Chrizantema";
                correctanswers[4, 1] = 3;

                questions[4, 2] = "Kuris iš šių medžių yra spygliuotis?";
                answers[4, 2, 0] = "Banksėja";
                answers[4, 2, 1] = "Raudonasis kaštonas";
                answers[4, 2, 2] = "Gėlauogės klevas";
                answers[4, 2, 3] = "Youtan Poluo";
                correctanswers[4, 2] = 0;

                questions[4, 3] = "Kuri šalis užaugina daugiausiai Cinamono?";
                answers[4, 3, 0] = "Indija";
                answers[4, 3, 1] = "Indonezija";
                answers[4, 3, 2] = "Vietnamas";
                answers[4, 3, 3] = "Šri Lanka";
                correctanswers[4, 3] = 1;

                questions[4, 4] = "Kokia yra penkta planeta Saulės Sistemoje?";
                answers[4, 4, 0] = "Venera";
                answers[4, 4, 1] = "Marsas";
                answers[4, 4, 2] = "Žemė";
                answers[4, 4, 3] = "Jupiteris";
                correctanswers[4, 4] = 3;

                questions[4, 5] = "Koki gyvūną galima rasti visuose žemynuose (išskyrus Antarktidą)?";
                answers[4, 5, 0] = "Meška";
                answers[4, 5, 1] = "Varna";
                answers[4, 5, 2] = "Lapė";
                answers[4, 5, 3] = "Vilkas";
                correctanswers[4, 5] = 2;

                questions[4, 6] = "Kokioje galaktikoje randasi Saulės Sistema?";
                answers[4, 6, 0] = "Andromedoje";
                answers[4, 6, 1] = "Paukščių Take";
                answers[4, 6, 2] = "Kentauro";
                answers[4, 6, 3] = "Spiralinėje";
                correctanswers[4, 6] = 1;

                questions[4, 7] = "Kuris iš šių augalų žydi mėlynai?";
                answers[4, 7, 0] = "Ramunė";
                answers[4, 7, 1] = "Medetka";
                answers[4, 7, 2] = "Levanda";
                answers[4, 7, 3] = "Aguona";
                correctanswers[4, 7] = 3;

                questions[4, 8] = "Kiek procentų Žemės paviršiaus užima vanduo?";
                answers[4, 8, 0] = "68%";
                answers[4, 8, 1] = "79%";
                answers[4, 8, 2] = "71%";
                answers[4, 8, 3] = "63%";
                correctanswers[4, 8] = 2;

                questions[4, 9] = "Kuri iš šių planetų dujinė?";
                answers[4, 9, 0] = "Marsas";
                answers[4, 9, 1] = "Venera";
                answers[4, 9, 2] = "Merkurijos";
                answers[4, 9, 3] = "Uranas";
                correctanswers[4, 9] = 3;
            }
            //Menas
            {
                questions[5, 0] = "Kokia yra populiariausia tapybos spalva?";
                answers[5, 0, 0] = "Raudona";
                answers[5, 0, 1] = "Mėlyna";
                answers[5, 0, 2] = "Žalia";
                answers[5, 0, 3] = "Geltona";
                correctanswers[5, 0] = 1;

                questions[5, 1] = "Kas yra garsiausias architektas pasaulyje?";
                answers[5, 1, 0] = "Frank Lloyd Wright";
                answers[5, 1, 1] = "Jeanne Gang";
                answers[5, 1, 2] = "Philip Johnson";
                answers[5, 1, 3] = "Louis Sullivan";
                correctanswers[5, 1] = 0;

                questions[5, 2] = "Koks buvo populiariausias meno stilius XX a. pradžioje?";
                answers[5, 2, 0] = "Romantizmas";
                answers[5, 2, 1] = "Klasicizmas";
                answers[5, 2, 2] = "Realizmas";
                answers[5, 2, 3] = "Modernizmas";
                correctanswers[5, 2] = 3;

                questions[5, 3] = "Kuris iš šių dailininkų nutapė daugiausia paveikslų?";
                answers[5, 3, 0] = "Leonardo da Vinci";
                answers[5, 3, 1] = "Pablo Picasso";
                answers[5, 3, 2] = "Vincent van Gogh";
                answers[5, 3, 3] = "Rembrandt";
                correctanswers[5, 3] = 1;

                questions[5, 4] = "Kuria iš šių skulptūrų sukūrė Mikelangelas?";
                answers[5, 4, 0] = "Laokoonas ir jo sūnūs";
                answers[5, 4, 1] = "Milo Venera";
                answers[5, 4, 2] = "Mastytojas";
                answers[5, 4, 3] = "Dovydas";
                correctanswers[5, 4] = 3;

                questions[5, 5] = "kada buvo nutapyta Siksto koplyčia";
                answers[5, 5, 0] = "15 a.";
                answers[5, 5, 1] = "16 a.";
                answers[5, 5, 2] = "17 a.";
                answers[5, 5, 3] = "18 a.";
                correctanswers[5, 5] = 1;

                questions[5, 6] = "Kas yra garsiausias baroko dailininkas?";
                answers[5, 6, 0] = "Jacques-Louis David";
                answers[5, 6, 1] = "Eugène Delacroix";
                answers[5, 6, 2] = "Caravaggio";
                answers[5, 6, 3] = "Angelica Kauffmann";
                correctanswers[5, 6] = 2;

                questions[5, 7] = "Kas nutapė \"La Guernica\"?";
                answers[5, 7, 0] = "Pablo Picasso";
                answers[5, 7, 1] = "Angelica Kauffmann";
                answers[5, 7, 2] = "Vincent van Gogh";
                answers[5, 7, 3] = "Jacques-Louis David";
                correctanswers[5, 7] = 0;

                questions[5, 8] = "Kur eksponuojama Leonardo da Vinci „Mona Liza“?";
                answers[5, 8, 0] = "Guimet Museum";
                answers[5, 8, 1] = "Museo Fabre";
                answers[5, 8, 2] = "Halle Saint-Pierre";
                answers[5, 8, 3] = "Louvre Museum";
                correctanswers[5, 8] = 3;

                questions[5, 9] = "Kokios tautybės buvo menininkas Henri Matisse?";
                answers[5, 9, 0] = "Italijos";
                answers[5, 9, 1] = "Prancuzijos";
                answers[5, 9, 2] = "Austrijos";
                answers[5, 9, 3] = "Vokietijos";
                correctanswers[5, 9] = 2;
            }
            CurrentQuestion = questions[CurrentCategory, CurrentRandomQuestionPick];
            for (int i =0; i < 4; i++)
            {
                CurrentAnswers[i] = answers[CurrentCategory, CurrentRandomQuestionPick, i];
            }
            CurrentCorrectAnswer = correctanswers[CurrentCategory, CurrentRandomQuestionPick];

        } 
    }
}