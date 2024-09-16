namespace _09
{
    internal class MoveService
    {
        public void MoveHead(string command, Rope rope)
        {
            Action<Rope> action = command switch
            {
                "U" => MoveUp,
                "D" => MoveDown,
                "L" => MoveLeft,
                "R" => MoveRight,
                _ => throw new ArgumentNullException(nameof(command))
            };

            action(rope);
        }

        public void MoveUp(Rope rope)
        {
            rope.PosY--;
        }

        public void MoveDown(Rope rope)
        {
            rope.PosY++;
        }

        public void MoveLeft(Rope rope)
        {
            rope.PosX--;
        }

        public void MoveRight(Rope rope)
        {
            rope.PosX++;
        }
    }
}
