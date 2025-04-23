public class Evaluation {
    static int[,] placementMap = new int[5, 5] {
        {0, 1, 1, 1, 0},
        {1, 2, 2, 2, 1},
        {2, 3, 3, 3, 2},
        {1, 2, 2, 2, 1},
        {0, 1, 1, 1, 0}
    };
    static float placementWeight = 0.1f;
    public static double Evaluate(Board board) {
        bool? winner = board.isBlueWinner();
        if (winner != null) {
            return winner == true ? 100d : -100d;
        }
        double score = 0;
        for (int row = 0; row < 5; row++) {
            for (int col = 0; col < 5; col++) {
                score += board.Position[row, col];
                if (board.Position[row, col] != 0) {
                    score += placementMap[row, col] * (board.Position[row, col] > 0 ? 1 : -1)
                        * placementWeight;
                }
            }
        }
        return score;
    }
}