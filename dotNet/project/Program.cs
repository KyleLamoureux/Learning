using System;
using System.Linq;
using System.Collections.Generic;

namespace project
{
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
            //Console.WriteLine(lines);
            //int[] dim = Array.ConvertAll(lines[1].Split(" "), int.Parse);
            //Console.WriteLine(dim);
            /*Console.WriteLine(y);*/

            PuzzleData p = new PuzzleData((2, 2), "swag", "yolo");
            Console.WriteLine(p);
            Console.WriteLine(p.Flatten());


            for(int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Equals("# Start of puzzle"))
                {
                    i+=1;
                    int[] dim = Array.ConvertAll(lines[i].Split(" "), int.Parse);
                    Console.WriteLine($"{dim[0]}, {dim[1]}");
                }

            }
            //Console.WriteLine(p);

            /*foreach (string line in lines)
            {
                if (line.Equals("# Start of puzzle"))
                {
                }
            }*/

            Console.WriteLine("Press and key to exit.");

            Console.ReadKey();
        }
    }

    /* Might be wise to store the row, col index as a struct.
     * 
     */

    public class PuzzleData
	{
        public int Rows;
        public int Cols;
        public char[][] Puzzle; // This shouldn't be jagged...
        public char[][] Solution;


		public PuzzleData((int rows, int cols) dim, string puzzle, string solution)
        {
            Rows = dim.rows;
            Cols = dim.cols;
            Puzzle = StringTo2DChar(puzzle, Rows);
            Solution = StringTo2DChar(solution, Rows);
            PrintBoard(Puzzle);
            PrintBoard(Solution);
        }

        /* Can add a operator method. To do comparisons between puzzles. Can flatten then do the conversion
         */

        public string Flatten()
        {
            return string.Join<char>("", this.Puzzle.SelectMany(a => a).ToArray());
        }
        
        public override string ToString()
        {
            return $"({Rows}, {Cols})";
        }

        static public void PrintBoard(char[][] Puzzle)
        {
            foreach(char[] row in Puzzle)
            {
                foreach(char ele in row)
                {
                    Console.Write(ele.ToString());
                }
                Console.WriteLine();
            }
        }

        static public char[][] StringTo2DChar(string toConvert, int rows) => 
            toConvert.ToArray<char>()
                .Select((s, i) => new { Value = s, Index = i})
                .GroupBy(x => x.Index / rows)
                .Select(grp => grp.Select(x => x.Value).ToArray<char>())
                .ToArray();
    }
}