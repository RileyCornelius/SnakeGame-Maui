namespace SnakeGame.GameLogic;

public class Position
{
    public int Row { get; }
    public int Col { get; }
    public Position(int row, int col)
    {
        Row = row;
        Col = col;
    }

    public Position Transalate(Direction dir)
    {
        return new Position(Row + dir.RowOffset, Col + dir.ColOffset);
    }

    public override bool Equals(object obj)
    {
        return obj is Position posistion &&
               Row == posistion.Row &&
               Col == posistion.Col;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Row, Col);
    }

    public static bool operator ==(Position left, Position right)
    {
        return EqualityComparer<Position>.Default.Equals(left, right);
    }

    public static bool operator !=(Position left, Position right)
    {
        return !(left == right);
    }
}

