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

        public void MoveTail(Rope tail, Rope head)
        {
            if (TailAndHearAreTouching(tail, head))
                return;

            Direction direction = GetPerpendicularHeadDirection(tail, head);

            switch (direction)
            {
                case Direction.UP:
                    MoveUp(tail);
                    break;
                case Direction.DOWN:
                    MoveDown(tail);
                    break;
                case Direction.LEFT:
                    MoveLeft(tail);
                    break;
                case Direction.RIGHT:
                    MoveRight(tail);
                    break;
                case Direction.NONE:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if(direction == Direction.NONE)
            {
                if()
            }
        }



        private bool TailAndHearAreTouching(Rope tail, Rope head)
        {
            int tailX = tail.PosX;
            int tailY = tail.PosY;
            int headX = head.PosX;
            int headY = head.PosY;

            if (tailX == headX && tailY == tailX
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

        private Direction GetOblicHeadDirection(Rope tail, Rope head)
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
    }
}
