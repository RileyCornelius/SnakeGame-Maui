namespace SnakeGame.GameLogic;

public class GameState
{
    public int Rows { get; }
    public int Cols { get; }
    public GridValue[,] Grid { get; }
    public Direction Dir { get; private set; }
    public int Score { get; private set; }
    public int HighScore { get; private set; }
    public bool IsGameOver { get; private set; }

    public readonly Snake Snake = new Snake();
    private readonly LinkedList<Direction> dirBuffer = new LinkedList<Direction>();
    private readonly Random random = new Random();

    public GameState(int rows, int cols)
    {
        Rows = rows;
        Cols = cols;
        Grid = new GridValue[Rows, Cols];
        Dir = Direction.Right;
        HighScore = Preferences.Default.Get("HighScore", 0);

        AddSnake();
        AddFood();
    }

    private void AddSnake()
    {
        int r = Rows / 2;
        for (int c = 0; c < 3; c++)
        {
            Grid[r, c] = GridValue.Snake;
            Snake.AddHead(new Position(r, c));
        }
    }

    private void AddFood()
    {
        List<Position> emptyPos = new List<Position>(EmprtyPostistions());
        if (emptyPos.Count == 0)
            return;

        Position pos = emptyPos[random.Next(emptyPos.Count)];
        Grid[pos.Row, pos.Col] = GridValue.Food;
    }

    private IEnumerable<Position> EmprtyPostistions()
    {
        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Cols; c++)
            {
                if (Grid[r, c] == GridValue.Empty)
                {
                    yield return new Position(r, c);
                }
            }
        }
    }

    public void ChangeDirection(Direction dir)
    {
        if (CanChangeDirection(dir))
            dirBuffer.AddLast(dir);
    }

    private bool CanChangeDirection(Direction newDir)
    {
        if (dirBuffer.Count == 2)
            return false;

        Direction lastDir = GetLastDirection();
        return newDir != lastDir && newDir != lastDir.Opposite();
    }
    private Direction GetLastDirection()
    {
        if (dirBuffer.Count == 0)
            return Dir;

        return dirBuffer.Last.Value;
    }

    public void MoveSnake()
    {
        if (dirBuffer.Count > 0)
        {
            Dir = dirBuffer.First.Value;
            dirBuffer.RemoveFirst();
        }

        Position newHeadPos = Snake.Head.Transalate(Dir);
        GridValue hit = WillHit(newHeadPos);

        if (hit == GridValue.Boarder || hit == GridValue.Snake)
        {
            IsGameOver = true;
        }
        else if (hit == GridValue.Empty)
        {
            RemoveTail();
            AddHead(newHeadPos);
        }
        else if (hit == GridValue.Food)
        {
            AddHead(newHeadPos);
            AddFood();
            AddScore();
        }
    }

    private void AddScore()
    {
        Score++;
        if (HighScore < Score)
        {
            HighScore = Score;
            Preferences.Set("HighScore", HighScore);
        }
    }

    private void AddHead(Position pos)
    {
        Grid[pos.Row, pos.Col] = GridValue.Snake;
        Snake.AddHead(pos);
    }

    private void RemoveTail()
    {
        Grid[Snake.Tail.Row, Snake.Tail.Col] = GridValue.Empty;
        Snake.RemoveTail();
    }

    private bool OutsideGrid(Position pos)
    {
        return pos.Row < 0 || pos.Row >= Rows || pos.Col < 0 || pos.Col >= Cols;
    }

    private GridValue WillHit(Position newHeadPos)
    {
        if (OutsideGrid(newHeadPos))
            return GridValue.Boarder;

        if (newHeadPos == Snake.Tail)
            return GridValue.Empty;

        return Grid[newHeadPos.Row, newHeadPos.Col];
    }
}

