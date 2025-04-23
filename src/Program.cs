public static class Program {
    public static void Main(string[] args) {
        Random rng = new Random();
        Board board = new Board();
        while (board.isBlueWinner() == null) {
            List<Move> moves = Move.GenerateMoves(board);
            if (moves.Count == 0) {
                Console.WriteLine("Aucun coup possible !");
                break;
            }
            Move move = moves[rng.Next(moves.Count)];
            board.MakeMove(move);
            board.show();
        }
        Console.WriteLine("winner: " + (board.isBlueWinner() == true ? "Blue" : "Red"));
        Console.WriteLine("Fin de la partie !");
    }
}