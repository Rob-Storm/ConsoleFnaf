using System;

namespace FnafConsole.Core
{
    public class Game
    {
        private bool isRunning;
        private bool isTurnOver;
        private Level level;

        private Time time;

        public static event Action OnTick;

        private string jumpscare;

        public Game()
        {
            level = new Level();
            time = new Time(60); 
            jumpscare = File.ReadAllText($@"{Environment.CurrentDirectory}\jumpscare.txt");
        }

        public void Run()
        {
            Console.WriteLine("Welcome to FNAF Console!");
            Console.WriteLine("Its turn based too, because yeah");

            isRunning = true;
            while (isRunning)
            {
                Update();
            }
        }

        private void Update()
        {
            isTurnOver = false;
            Console.WriteLine($"Current Time: {time.GetTimeFormatted()}");
            Console.WriteLine("1. Check cameras");
            Console.WriteLine("2. Check doors");
            Console.WriteLine("3. End turn");
            Console.Write("What will you do?: ");

            string? input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    Console.Beep(500, 50);
                    level.DisplayMapFormatted(); //THIS METHOD FINALLY WORKS WHOOP WHOOP
                    isTurnOver = false;
                    break;
                case "2":
                    Console.Beep(500, 50);
                    level.CheckDoors();
                    isTurnOver = true;
                    break;
                case "3":
                    Console.Beep(300, 50);
                    Console.Beep(500, 50);
                    Console.Clear();
                    isTurnOver = true;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Clear();
                    Console.WriteLine("Invalid Operation \n");
                    Console.Beep(500, 50);
                    Console.Beep(300, 50);
                    isTurnOver = false;
                    break;
            }

            Console.ResetColor();


            if(isTurnOver)
            {
                if (level.CheckPlayerDeath())
                {
                    Console.WriteLine("Something is in your office...");
                    Thread.Sleep(2500);

                    Console.Beep(500, 50);
                    Console.Beep(500, 50);
                    Console.Beep(500, 50);

                    foreach(char c in jumpscare)
                        Console.Write(c);

                    Console.ResetColor();

                    Console.WriteLine();

                    Console.WriteLine("You have died!");
                    Console.ReadLine();

                    Environment.Exit(0);
                }

                OnTick?.Invoke();
            }

        }
    }
}
