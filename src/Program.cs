public static class Program {
    public static void Main(string[] args) {
        Board board = new Board();
        board.show();
        for (int i = 1; i < 8; i++){
            DepthSearch.MoveScore moveScore = DepthSearch.GetBestMove(board, i);
            Console.WriteLine($"Depth: {i} Best move: {moveScore.Move?.getNotation()} with score {moveScore.Score}");
        }
    }
}