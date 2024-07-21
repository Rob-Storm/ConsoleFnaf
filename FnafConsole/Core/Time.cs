namespace FnafConsole.Core
{
    public class Time
    {
        private int currentTime;
        private int winTime;

        public Time(int WinTime)
        {
            currentTime = 0;
            winTime = WinTime;
            Game.OnTick += IncrementTime;
        }

        public string GetTimeFormatted()
        {
            if (CheckRange(currentTime, 0, 9))
                return "12:00 AM";
            else if (CheckRange(currentTime, 10, 19))
                return "01:00 AM";
            else if (CheckRange(currentTime, 20, 29))
                return "02:00 AM";
            else if (CheckRange(currentTime, 30, 39))
                return "03:00 AM";
            else if (CheckRange(currentTime, 40, 49))
                return "04:00 AM";
            else if (CheckRange(currentTime, 50, 59))
                return "05:00 AM";
            else return "FUCK YOU";
        }

        private bool CheckRange(int value, int min, int max) => value >= min && value <= max;
        private void IncrementTime()
        {
            currentTime++;
            CheckTime();
        }

        private void CheckTime()
        {
            if (currentTime >= winTime)
            {
                Console.WriteLine("06:00 AM");

                //Grandfather clock chime
                Console.Beep(329, 750);
                Console.Beep(415, 750);
                Console.Beep(369, 750);
                Console.Beep(246, 750);

                Console.Beep(329, 750);
                Console.Beep(369, 750);
                Console.Beep(415, 750);
                Console.Beep(329, 750);

                Console.Beep(415, 750);
                Console.Beep(329, 750);
                Console.Beep(369, 750);
                Console.Beep(246, 750);

                Console.Beep(246, 750);
                Console.Beep(369, 750);
                Console.Beep(415, 750);
                Console.Beep(329, 750);

                Console.WriteLine("You win!");
                Console.Read();
                Environment.Exit(0);
            }
        }
    }
}
