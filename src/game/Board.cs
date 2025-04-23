public class Board {
    public Card ExtraCard { get; set; }
    public List<List<Card>> PlayerCards { get; set; }
    public bool IsBlueTurn { get; set; }

    public int[,] Position { get; } = new int[5, 5] {
        {-1, -1, -2, -1, -1},
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0},
        {1, 1, 2, 1, 1}
    };

    public Board() {
        Card.Shuffle();
        this.ExtraCard = Card.Cards[0];
        this.PlayerCards = new List<List<Card>>() {
            new List<Card>() { Card.Cards[1], Card.Cards[2] },
            new List<Card>() { Card.Cards[3], Card.Cards[4] }
        };
        this.IsBlueTurn = ExtraCard.IsBlue;
    }

    public Board(Board board) {
        this.ExtraCard = board.ExtraCard;
        this.PlayerCards = new List<List<Card>>() {
            new List<Card>(board.PlayerCards[0]),
            new List<Card>(board.PlayerCards[1])
        };
        this.IsBlueTurn = board.IsBlueTurn;
        this.Position = (int[,])board.Position.Clone();
    }

    public bool? isBlueWinner() {
        if (this.Position[0, 2] == 2) {
            return false;
        }
        if (this.Position[4, 2] == -2) {
            return true;
        }
        bool redExists = false;
        bool blueExists = false;

        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                if (this.Position[row, col] == 2)
                {
                    blueExists = true;
                }
                if (this.Position[row, col] == -2)
                {
                    redExists = true;
                }
            }
        }
        if (!redExists)
        {
            return true;
        }
        if (!blueExists)
        {
            return false;
        }
        return null;
    }

    public void show() {
        for (int i = 0; i < 2; i++) {
            Console.Write($"Player {(i == 0 ? "Blue" : "Red")}: ");
            foreach (Card card in PlayerCards[i]) {
                Console.Write($"{card.Name} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine($"Extra card: {ExtraCard.Name}");
        Console.WriteLine($"Turn: {(IsBlueTurn ? "Blue" : "Red")}");
        Console.WriteLine("+---+---+---+---+---+");
        for (int row = 0; row < 5; row++) {
            for (int col = 0; col < 5; col++) {
                char piece = this.Position[row, col] switch {
                    -2 => 'm', -1 => 'g', 0 => ' ', 1 => 'G', 2 => 'M',
                    _ => throw new ArgumentOutOfRangeException() };
                Console.Write($"| {piece} ");
            }
            Console.WriteLine("|");
            Console.WriteLine("+---+---+---+---+---+");
        }
    }

    public void MakeMove(Move move) {
        this.Position[move.To.Value, move.To.Key] = Position[move.From.Value, move.From.Key];
        this.Position[move.From.Value, move.From.Key] = 0;
        this.IsBlueTurn = !this.IsBlueTurn;
        this.PlayerCards[IsBlueTurn ? 1 : 0].Remove(move.UsedCard);
        this.PlayerCards[IsBlueTurn ? 1 : 0].Add(this.ExtraCard);
        this.ExtraCard = move.UsedCard;
    }
}