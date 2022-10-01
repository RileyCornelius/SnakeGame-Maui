namespace SnakeGame.Services;

public class Snake
{
    public Position Head => Body.First.Value;
    public Position Tail => Body.Last.Value;
    public LinkedList<Position> Body = new LinkedList<Position>();
    public Snake()
    {
    }

    public void AddHead(Position pos)
    {
        Body.AddFirst(pos);
    }

    public void RemoveTail()
    {
        Body.RemoveLast();
    }
}

