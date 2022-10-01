namespace SnakeGame.Services;
//public class Game
//{
//    public int Score;
//    public bool IsGameOver;
//    public Food Food;
//    public Snake Snake;

//    public Game()
//    {
//        Score = 0;
//        IsGameOver = false;
//        Snake = new Snake();
//        Food = new Food();
//    }

//    public void MoveSnake()
//    {
//        Snake.Move();
//        Checks();
//    }

//    private void Checks()
//    {
//        if (Snake.Crashed())
//            EndGame();

//        if (Snake.Head == Food.Position)
//        {
//            Score++;
//            Snake.Eat();
//            Food.NewPosition();
//            while (Snake.Head == Food.Position || Snake.Body.Contains(Food.Position))
//                Food.NewPosition();
//        }
//    }

//    private void EndGame() => IsGameOver = true;
//}

//public class Snake
//{
//    public Point Head;
//    public Point PrevHead;
//    public Point PrevTail;
//    public List<Point> Body;
//    public Direction CurrentDirection;

//    public Snake()
//    {
//        Head = new Point(2, 2);
//        PrevHead = new Point(2, 1);
//        PrevTail = new Point(2, 1);
//        CurrentDirection = Direction.Right;
//        Body = new List<Point> { new Point(0, 0), };
//    }

//    public void ChangeDirection(Direction direction)
//    {
//        if (!IsPossibleToChangeDirection(direction))
//            return;

//        CurrentDirection = direction;
//    }

//    private bool IsPossibleToChangeDirection(Direction direction)
//    {
//        return direction switch
//        {
//            Direction.Down when CurrentDirection == Direction.Up => false,
//            Direction.Up when CurrentDirection == Direction.Down => false,
//            Direction.Left when CurrentDirection == Direction.Right => false,
//            Direction.Right when CurrentDirection == Direction.Left => false,
//            _ => true
//        };


//        switch (direction)
//        {
//            case Direction.Up: return CurrentDirection != Direction.Down;
//            case Direction.Down: return CurrentDirection != Direction.Up;
//            case Direction.Left: return CurrentDirection != Direction.Right;
//            case Direction.Right: return CurrentDirection != Direction.Left;
//            default: return true;
//        }
//    }

//    public void Move()
//    {
//        Point PrevHead = Head;
//        switch (CurrentDirection)
//        {
//            case Direction.Up: Head = new Point(Head.X, Head.Y - 1); break;
//            case Direction.Down: Head = new Point(Head.X, Head.Y + 1); break;
//            case Direction.Left: Head = new Point(Head.X - 1, Head.Y); break;
//            case Direction.Right: Head = new Point(Head.X + 1, Head.Y); break;
//        }



//        PrevTail = Body.Last();
//        Body.RemoveAt(Body.Count - 1);
//        Body.Insert(0, PrevHead);
//    }

//    public bool Crashed()
//    {
//        if (CrashedInToEdge() || CrashedInToBody())
//            return true;
//        return false;
//    }
//    public bool CrashedInToEdge() =>
//        Head.X == 0 || Head.X == GameBoard.Width - 1 || Head.Y == 0 || Head.Y == GameBoard.Height - 1;
//    public bool CrashedInToBody() => Body.Contains(Head);
//    public void Eat() => Body.Add(PrevTail);
//}

//public class Food
//{
//    public Point Position;
//    Random _random;

//    public Food()
//    {
//        _random = new Random();
//        NewPosition();
//    }

//    public void NewPosition()
//    {
//        Position = new Point(_random.Next(GameBoard.Width - 1), _random.Next(GameBoard.Height - 1));
//    }
//}

////[DebuggerDisplay("X: {X}, Y: {Y}")]
//public class Point
//{
//    public int X { get; set; }
//    public int Y { get; set; }
//    public Point() { X = 0; Y = 0; }
//    public Point(int x, int y) { X = x; Y = y; }
//}

//public static class GameBoard
//{
//    public static int Width = 80;
//    public static int Height = 20;
//    public static int GridSize = 20;
//}


//public enum GridValue
//{
//    Empty,
//    Snake,
//    Food,
//    Boarder,
//}
