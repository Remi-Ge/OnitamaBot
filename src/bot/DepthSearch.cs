public class DepthSearch
{
    public static int Search(Board board, int depth)
    {
        if (depth == 0)
        {
            return 0;
        }

        double score = Evaluation.Evaluate(board);
        Console.WriteLine($"Score: {score}");

        List<Move> moves = Move.GenerateMoves(board);
        if (moves.Count == 0)
        {
            return 0;
        }
        int count = 0;
        foreach (Move move in moves)
        {
            Board newBoard = new Board(board);
            newBoard.MakeMove(move);
            count += Search(newBoard, depth - 1);
        }
        return count + moves.Count;
    }
}