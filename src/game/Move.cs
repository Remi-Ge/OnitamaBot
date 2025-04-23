public class Move {
    public KeyValuePair<int, int> From { get; }
    public KeyValuePair<int, int> To { get; }
    public Card UsedCard { get; }

    public Move(KeyValuePair<int, int> from, KeyValuePair<int, int> to, Card usedCard) {
        this.From = from;
        this.To = to;
        this.UsedCard = usedCard;
    }

    public static List<Move> GenerateMoves(Board board) {
        List<Move> moves = new List<Move>();
        for (int row = 0; row < 5; row++) {
            for (int col = 0; col < 5; col++) {
                if (board.Position[row, col] * (board.IsBlueTurn ? 1 : -1) > 0) {
                    foreach (Card card in board.PlayerCards[(board.IsBlueTurn ? 0 : 1)]) {
                        foreach (KeyValuePair<int, int> move in card.Movements) {
                            int xDirection = move.Key * (board.IsBlueTurn ? 1 : -1);
                            int yDirection = move.Value * (board.IsBlueTurn ? -1 : 1);
                            if (col + xDirection < 0 || col + xDirection > 4 ||
                                row + yDirection < 0 || row + yDirection > 4) {
                                continue;
                            }
                            if (board.Position[row + yDirection, col + xDirection]
                                * (board.IsBlueTurn ? 1 : -1) > 0) {
                                continue;
                            }
                            moves.Add(new Move(
                                new KeyValuePair<int, int>(col, row),
                                new KeyValuePair<int, int>(col + xDirection, row + yDirection),
                                card));
                        }
                    }
                }
            }
        }
        return moves;
    }

    public static string getSquareNotation(KeyValuePair<int, int> square) {
        return ((char)(square.Key + 'a')).ToString() + (5 - square.Value).ToString();
    }

    public string getNotation() {
        return $"{getSquareNotation(From)}{getSquareNotation(To)} {UsedCard.Name}";
    }

    public static Move? Parse(string notation, List<Move> legalMoves) {
        foreach (Move move in legalMoves) {
            if (notation == move.getNotation()) {
                return move;
            }
        }
        return null;
    }
}