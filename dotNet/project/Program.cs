using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace project
{

    static class Helpers
    {
        public static readonly HashSet<char> WALL_DATA = new HashSet<char>(new char[]{'0', '1', '2', '3', '4'});
    }


    class Program
    {
        static int Main(string[] args)
        {

            if (args.Length == 0)
            {

                // return 1;
            }

            string path = ".\\12walls.txt";
            // = System.IO.File.ReadLine(path);
            string[] lines = System.IO.File.ReadAllLines(path);

            List<PuzzleData> puzzles = new List<PuzzleData>();

            for(int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Equals("# Start of puzzle"))
                {
                    i+=2;
                    int[] dim = Array.ConvertAll(lines[i-1].Split(" "), int.Parse);
                    string input_puzzle = string.Join("", lines[i..(i+dim[1])]);
                    i+= 2 + dim[0];
                    string input_solution = Regex.Replace(string.Join("", lines[i..(i+dim[1])]), "#| ", "");
                    i+= dim[0]-1;
                    puzzles.Add(new PuzzleData((dim[0], dim[1]), input_puzzle, input_solution));
                }
            }


            foreach(PuzzleData puzzleData in puzzles)
            {
                puzzleData.PrintPuzzle();
                //puzzleData.PrintSolution();
                //puzzleData.Walls.ForEach(p => Console.WriteLine(p));
                puzzleData.OpenSpaces.ForEach(p => Console.WriteLine(p));
            }
            
            

            Console.WriteLine("---Press and key to exit.---");

            //Console.ReadKey();
            return 0;
        }
    }

    public struct PieceData
    {
        public PieceData(int x, int y, char c) =>
            (X, Y, C) = (x, y, c);
        public PieceData(int x, int y) =>
            (X, Y, C) = (x, y, '_');

        public int X { get; }
        public int Y { get; }
        public char C { get; set; }
        public override string ToString() => $"({X}, {Y}): {C}";
    }

    /* Might be wise to store the row, col index as a struct.
     * 
     */
    public class PuzzleData
	{
        public int Rows;
        public int Cols;
        public char[,] Puzzle; // This shouldn't be jagged... or should it...
        public char[,] Solution;
        public List<PieceData> Walls;
        public List<PieceData> OpenSpaces;


		public PuzzleData((int rows, int cols) dim, string puzzle, string solution)
        {
            Rows = dim.rows;
            Cols = dim.cols;
            Puzzle = StringTo2DChar(puzzle, Rows, Cols);
            Solution = StringTo2DChar(solution, Rows, Cols);
            
            Walls = new List<PieceData>();
            FindWalls(ref Walls);

            OpenSpaces = FindOpenSpaces(Puzzle);
        }

        /* Can add a operator method. To do comparisons between puzzles. Can flatten then do the conversion
         */


        /*
         * I wonder if this could be replaced with functios that process the string with like indexOf
         */
        public List<PieceData> FindWalls(ref List<PieceData> p)
        {
            for(int i = 0; i < this.Puzzle.GetLength(0); i++)
                for(int j = 0; j < this.Puzzle.GetLength(1); j++)
                    if (Helpers.WALL_DATA.Contains(this.Puzzle[i, j]))
                        p.Add(new PieceData(i, j, this.Puzzle[i, j]));
            return p;
        }

        /*
         * I wonder if this could be replaced with functions that process the string with like indexOf
         */
        public List<PieceData> FindOpenSpaces(char[,] p)
        {
            List<PieceData> openSpaces = new List<PieceData>();
            for(int i = 0; i < this.Puzzle.GetLength(0); i++)
                for(int j = 0; j < this.Puzzle.GetLength(1); j++)
                    if (!Helpers.WALL_DATA.Contains(this.Puzzle[i, j]))
                        openSpaces.Add(new PieceData(i, j));
            return openSpaces;
        }


        public string Flatten() => string.Join<char>("", this.Puzzle.Cast<char>().Select(a => a).ToArray());
        public void PrintPuzzle() => PrintBoard(this.Puzzle);
        public void PrintSolution() => PrintBoard(this.Solution, true);

        private static void PrintBoard(char[,] Puzzle, bool solution=false)
        {
            string intro = solution ? "Solution" : "Puzzle State";
            Console.WriteLine(intro);
            for(int i = 0; i < Puzzle.GetLength(0); i++) { 
                for(int j = 0; j < Puzzle.GetLength(1); j++)
                    Console.Write($"{Puzzle[i, j]} ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /* Not perfect but will do for now */
        private static char[,] StringTo2DChar(string toConvert, int rows, int cols){
            char[][] temp = toConvert.ToArray<char>()
                .Select((s, i) => new { Value = s, Index = i})
                .GroupBy(x => x.Index / rows)
                .Select(grp => grp.Select(x => x.Value).ToArray<char>())
                .ToArray(); // Can't figure out how to convert this from a jagged char array to a 2D array in one line

            char[,] res = new char[rows, cols];
            for(int i = 0; i < rows; i++)
                for(int j = 0; j < cols; j++)
                    res[i, j] = temp[i][j];

            return res;
        }
    }
}