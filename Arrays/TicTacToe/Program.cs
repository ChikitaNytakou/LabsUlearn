namespace TicTacToe
{
    public enum Mark
    {
        Empty,
        Cross,
        Circle
    }

    public enum GameResult
    {
        CrossWin,
        CircleWin,
        Draw
    }
    internal class Program
    {
        private static void Run(string description)
        {
            Console.WriteLine(description.Replace(" ", Environment.NewLine));
            Console.WriteLine(GetGameResult(CreateFromString(description)));
            Console.WriteLine();
        }

        public static GameResult GetGameResult(Mark[,] field)
        {
            if (HasWinSequence(field, Mark.Cross) && HasWinSequence(field, Mark.Circle)) return GameResult.Draw;
            if (HasWinSequence(field, Mark.Cross)) return GameResult.CrossWin;
            else if (HasWinSequence(field, Mark.Circle)) return GameResult.CircleWin;
            else return GameResult.Draw;
        }

        public static bool HasWinSequence(Mark[,] field, Mark mark)
        {
            return HasWinningLine(field, mark, 0, 0, 0, 1)
                || HasWinningLine(field, mark, 0, 0, 1, 0)
                || HasWinningLine(field, mark, 0, 0, 1, 1)
                || HasWinningLine(field, mark, 0, 2, 1, 0)
                || HasWinningLine(field, mark, 0, 2, 1, -1)
                || HasWinningLine(field, mark, 0, 1, 1, 0)
                || HasWinningLine(field, mark, 1, 0, 0, 1)
                || HasWinningLine(field, mark, 2, 0, 0, 1);
        }

        public static bool HasWinningLine(Mark[,] field, Mark mark, int startX, int startY, int stepX, int stepY)
        {
            return field[startX, startY] == mark
                && field[startX, startY] == field[startX + stepX, startY + stepY]
                && field[startX, startY] == field[startX + 2 * stepX, startY + 2 * stepY];
        }

        private static Mark[,] CreateFromString(string str)
        {
            var field = str.Split(' ');
            var ans = new Mark[3, 3];
            for (int x = 0; x < field.Length; x++)
                for (var y = 0; y < field.Length; y++)
                    ans[x, y] = field[x][y] == 'X' ? Mark.Cross : (field[x][y] == 'O' ? Mark.Circle : Mark.Empty);
            return ans;
        }
        static void Main(string[] args)
        {
            Run("XXX OO. ...");
            Run("OXO XO. .XO");
            Run("OXO XOX OX.");
            Run("XOX OXO OXO");
            Run("... ... ...");
            Run("XXX OOO ...");
            Run("XOO XOO XX.");
            Run(".O. XO. XOX");
        }
    }
}
