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
            double maxScore = moveScores.Max(ms => ms.Score);
            List<MoveScore> best = moveScores.Where(ms => ms.Score == maxScore).ToList();
            Random rd = new Random();
            return best[rd.Next(best.Count)];
        } else {
            double minScore = moveScores.Min(ms => ms.Score);
            List<MoveScore> best = moveScores.Where(ms => ms.Score == minScore).ToList();
            Random rd = new Random();
            return best[rd.Next(best.Count)];
        }
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