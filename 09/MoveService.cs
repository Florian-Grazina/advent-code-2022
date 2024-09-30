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
                _ => throw new ArgumentException(nameof(command))
            };

            action(rope);
        }

        public void MoveTail(Rope tail, Rope head)
        {
            if (TailAndHearAreTouching(tail, head))
                return;

            Direction direction = GetPerpendicularHeadDirection(tail, head);


            if (direction != Direction.NONE)
                Move(tail, direction);

            else
            {
                (Direction, Direction) directions = GetOblicHeadDirection(tail, head);
                Move(tail, directions.Item1);
                Move(tail, directions.Item2);
            }
        }

        public void Move(Rope rope, Direction direction)
        {
            switch (direction)
            {
                case Direction.UP:
                    MoveUp(rope);
                    break;
                case Direction.DOWN:
                    MoveDown(rope);
                    break;
                case Direction.LEFT:
                    MoveLeft(rope);
                    break;
                case Direction.RIGHT:
                    MoveRight(rope);
                    break;
                case Direction.NONE:
                    break;
                default:
                    throw new ArgumentException(nameof(direction));
            }
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

        private bool TailAndHearAreTouching(Rope tail, Rope head)
        {
            int tailX = tail.PosX;
            int tailY = tail.PosY;
            int headX = head.PosX;
            int headY = head.PosY;

            if (tailX == headX && tailY == headY
                || GetDistance(tailX, headX) <= 1 && GetDistance(tailY, headY) <= 1)
                return true;

            return false;
        }

        private int GetDistance(int obj1, int obj2)
        {
            return Math.Abs(obj1 - obj2);
        }

        private Direction GetPerpendicularHeadDirection(Rope tail, Rope head)
        {
            int tailX = tail.PosX;
            int tailY = tail.PosY;
            int headX = head.PosX;
            int headY = head.PosY;

            if (tailX == headX)
            {
                if (tailY > headY)
                    return Direction.UP;
                else
                    return Direction.DOWN;
            }
            else if (tailY == headY)
            {
                if (tailX > headX)
                    return Direction.LEFT;
                else
                    return Direction.RIGHT;
            }
            return Direction.NONE;
        }

        private (Direction, Direction) GetOblicHeadDirection (Rope tail, Rope head)
        {
            (Direction, Direction) directions = new();

            if (tail.PosX < head.PosX)
                directions.Item1 = Direction.RIGHT;
            else
                directions.Item1 = Direction.LEFT;

            if(tail.PosY < head.PosY)
                directions.Item2 = Direction.DOWN;
            else
                directions.Item2 = Direction.UP;

            return directions;
        }
    }
}
