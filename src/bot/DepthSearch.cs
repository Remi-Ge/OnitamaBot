public class DepthSearch
{
    public static MoveScore GetBestMove(Board board, int depth) {
        List<Move> moves = Move.GenerateMoves(board);
        if (moves.Count == 0 || depth == 0) {
            return new MoveScore(null, Evaluation.Evaluate(board));
        }
        List<MoveScore> moveScores = new List<MoveScore>();
        foreach (Move move in moves) {
            Board newBoard = new Board(board);
            newBoard.MakeMove(move);
            MoveScore moveScore = GetBestMove(newBoard, depth - 1);
            moveScores.Add(new MoveScore(move, moveScore.Score));
        }
        if (board.IsBlueTurn) {
            return moveScores.OrderByDescending(ms => ms.Score).First();
        }
        return moveScores.OrderBy(ms => ms.Score).First(); 
    }

    public struct MoveScore
    {
        public Move? Move;
        public double Score;

        public MoveScore(Move? move, double score)
        {
            Move = move;
            Score = score;
        }
    }
}