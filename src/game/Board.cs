public class Board {
    public Card ExtraCard { get; }
    public List<List<Card>> PlayerCards { get; }
    public bool IsBlueTurn { get; }

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
}