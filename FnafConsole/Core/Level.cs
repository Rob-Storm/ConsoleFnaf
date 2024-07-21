using System.Text.RegularExpressions;

namespace FnafConsole.Core
{
    public class Level
    {
        private string map;
        private int[] positions = new int[13];

        private int[] path1 = { 0, 1, 3, 6, 7, 9, 10, 11, 13 };
        private int[] path2 = { 0, 1, 2, 5, 7, 10, 12, 13 };
        private int[] path3 = { 0, 1, 2, 10, 11, 13 };
        private int[] path4 = { 4, 7, 9, 11 , 13 };

        private List<Enemy> enemies;

        public Level()
        {
            enemies = new List<Enemy>();

            map = File.ReadAllText($@"{Environment.CurrentDirectory}\map.txt");

            enemies.Add(new Enemy("Bonnie", 7, path1, 6));
            enemies.Add(new Enemy("Chica", 5, path2, 5));
            enemies.Add(new Enemy("Freddy", 6, path3, 2));
            enemies.Add(new Enemy("Foxy", 1, path4, 4));

            Game.OnTick += Game_OnTick;
        }

        private void Game_OnTick()
        {
            ClearPositions();

            foreach (Enemy enemy in enemies)
                enemy.AttemptMove();

            for (int i = 0; i < positions.Length; i++)
            {
                if(enemies.Any(e => e.GetPosition() == i))
                    positions[i]++;
            }

            if (enemies.Any(e => e.GetPosition() > 11))
                Console.WriteLine("You hear a noise outside...");
        }

        public void DisplayMap()
        {
            Console.Clear();
            Console.WriteLine(map);
        }

        public void DisplayMapFormatted()
        {
            Console.Clear();
            MatchCollection matches = Regex.Matches(map, @"\d+");

            int lastIndex = 0;

            foreach (Match match in matches)
            {
                Console.Write(map.Substring(lastIndex, match.Index - lastIndex));

                string numberStr = match.Value;
                int number = int.Parse(numberStr);

                ConsoleColor color = ConsoleColor.Green;
                if (enemies.Any(e => e.GetPosition() == number))
                    color = ConsoleColor.Red;

                Console.ForegroundColor = color;
                Console.Write($"{number}");
                Console.ResetColor();

                lastIndex = match.Index + match.Length;
                Thread.Sleep(275);
                Console.Beep(100, 50);
            }

           
            if (lastIndex < map.Length)
            {
                Console.Write(map.Substring(lastIndex));
            }

            Console.WriteLine();

        }

        public void CheckDoors()
        {
            Console.Clear();
            Console.WriteLine("Which door will your check?");
            Console.WriteLine("1. Left Door");
            Console.WriteLine("2. Right Door");
            string? input = Console.ReadLine();
            Console.Beep(500, 50);
            Console.Clear();
            if (input != null)
            {
                switch (input)
                {
                    case "1":
                        Enemy doorEnemy = enemies.FirstOrDefault(e => e.GetPosition() == 11);
                        if (doorEnemy != null)
                        {
                            Console.WriteLine("There is someone at the door... Closing");
                            doorEnemy.MoveToBlockedPosition();
                        }
                        else
                            Console.WriteLine("There is nothing at the door...");
                        break;
                    case "2":
                        Enemy doorEnemy2 = enemies.FirstOrDefault(e => e.GetPosition() == 12);
                        if (doorEnemy2 != null)
                        {
                            Console.WriteLine("There is someone at the door... Closing");
                            doorEnemy2.MoveToBlockedPosition();
                        }
                        else
                            Console.WriteLine("There is nothing at the door...");
                        break;
                    default:
                        Console.WriteLine("Invalid Operation");
                        break;

                }
            }
        }

        public bool CheckPlayerDeath() => enemies.Any(e => e.GetPosition() == 14);

        private void ClearPositions()
        {
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = 0;
            }
        }


    }
}
