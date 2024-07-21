namespace FnafConsole.Core
{
    public class Enemy
    {
        public string Name { get; }
        private int aiLevel;
        private int currentPosition;
        private int[] path;
        private int doorBlockedPosition;
        private int currentPathState;

        public Enemy(string name, int startingAILevel, int[] path, int doorPosition)
        {
            this.path = path;
            currentPathState = 0;
            Name = name;
            aiLevel = startingAILevel;
            doorBlockedPosition = doorPosition;
            Move(path[0]);
        }
        public int GetPosition() => currentPosition+1;

        public void MoveToBlockedPosition() => currentPosition = doorBlockedPosition;

        public void AttemptMove()
        {
            Random random= new Random();

            if (random.Next(0, 20) <= aiLevel && GetPosition() < 14)
                AdvanceForward();
        }

        private void AdvanceForward()
        {
            Move(path[currentPathState]);
            currentPathState++;
        }

        private int Move(int newPosition)
        {
            currentPosition = newPosition;
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            #if DEBUG
            Console.WriteLine($"{Name} moved to position {currentPosition + 1}");
            #endif

            Console.ResetColor();
            return currentPosition;
        }

    }
}
