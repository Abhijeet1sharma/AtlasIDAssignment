namespace Domain
{
    public class BinTree
    {
        public int Value { get; }
        public BinTree? Left { get; }
        public BinTree? Right { get; }

        public BinTree(int value, BinTree? left, BinTree? right)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (BinTree)obj;
            return Value == other.Value &&
                   Equals(Left, other.Left) &&
                   Equals(Right, other.Right);
        }

        // Override GetHashCode
        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Left, Right);
        }
    }
}