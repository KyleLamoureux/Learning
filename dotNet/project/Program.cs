using System;
using System.Linq;


namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
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
        public int Rows { get; }
        public int Cols { get; }
        public char[][] Puzzle { get; }
        public char[][] Solution { get; }

		public PuzzleData((int, int) dim, string puzzle, string solution)
        {
            Rows = dim.Item1;
            Cols = dim.Item2;
            Puzzle = StringTo2DChar(puzzle, Rows);
            Solution = StringTo2DChar(solution, Rows);
            PrintBoard(Puzzle);
            PrintBoard(Solution);
        }

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

        static public char[][] StringTo2DChar(string toConvert, int rows)
        {
            char[] temp = toConvert.ToArray<char>();
            return temp.Select((s, i) => new { Value = s, Index = i})
                .GroupBy(x => x.Index / rows)
                .Select(grp => grp.Select(x => x.Value).ToArray<char>()).ToArray();
        }
    }
}