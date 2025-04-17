public class Card {
    public static List<Card> Cards = new List<Card>() {
        new Card("ANGUILLE", true, "00000 01000 00010 01000 00000"),
        new Card("GRENOUILLE", false, "00000 01000 10000 00010 00000"),
        new Card("SINGE", true, "00000 01010 00000 01010 00000"),
        new Card("LAPIN", true, "00000 00010 00001 01000 00000"),
        new Card("OIE", true, "00000 01000 01010 00010 00000"),
        new Card("MANTE", false, "00000 01010 00000 00100 00000"),
        new Card("COBRA", false, "00000 00010 01000 00010 00000"),
        new Card("DRAGON", false, "00000 10001 00000 01010 00000"),
        new Card("GRUE", true, "00000 00100 00000 01010 00000"),
        new Card("CHEVAL", false, "00000 00100 01000 00100 00000"),
        new Card("CRABE", true, "00000 00100 10001 00000 00000"),
        new Card("COQ", false, "00000 00010 01010 01000 00000"),
        new Card("ELEPHANT", false, "00000 01010 01010 00000 00000"),
        new Card("SANGLIER", false, "00000 00100 01010 00000 00000"),
        new Card("TIGRE", true, "00100 00000 00000 00100 00000"),
        new Card("BOEUF", true, "00000 00100 00010 00100 00000")
    };

    public string Name { get; }
    public bool IsBlue { get; }
    public List<KeyValuePair<int, int>> Movements { get; }


    public Card(string name, bool isBlue, string movements) {
        this.Name = name;
        this.IsBlue = isBlue;
        this.Movements = StringToMatrix(movements);
    }

    private List<KeyValuePair<int, int>> StringToMatrix(string movements) {
        List<KeyValuePair<int, int>> result = new List<KeyValuePair<int, int>>();
        string[] lines = movements.Split(' ');
        for (int row = 0; row < 5; row++) {
            for (int col = 0; col < 5; col++) {
                if (lines[row][col] == '1'){
                    result.Add(new KeyValuePair<int, int>(col - 2, 2 - row));
                }
            }
        }
        return result;
    }

    public static void Shuffle()
    {
        Random rand = new Random();
        int n = Cards.Count;
        while (n > 1)
        {
            n--;
            int k = rand.Next(n + 1);
            Card value = Cards[k];
            Cards[k] = Cards[n];
            Cards[n] = value;
        }
    }
}