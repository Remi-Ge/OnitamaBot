public static class Program {
    public static void Main(string[] args) {
        Board board = new Board();
        board.show();
        Console.ReadKey();
        while (board.isBlueWinner() == null) {
            if (board.IsBlueTurn) {
                List<Move> moves = Move.GenerateMoves(board);
                Console.Write("Enter your move: ");
                string? input = Console.ReadLine();
                if (input == null) {
                    continue;
                }
                if (input == "show") {
                    board.show();
                    continue;
                }
                Move? move = Move.Parse(input, moves);
                if (move != null) {
                    board.MakeMove(move);
                } else {
                    Console.WriteLine("Invalid move. Try again.");
                }
            } else {
                DepthSearch.MoveScore bestMove = DepthSearch.GetBestMove(board, 4);
                if (bestMove.Move != null) {
                    Console.WriteLine($"{bestMove.Move.getNotation()} {bestMove.Score}");
                    board.MakeMove(bestMove.Move);
                } else {
                    Console.WriteLine("No valid moves available.");
                }
            }
        }
    }
}