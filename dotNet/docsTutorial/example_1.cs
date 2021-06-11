using System;

class Example1
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");

        var pair = new Pair<int, string>(1, "two");
        int i = pair.First;
        string s = pair.Second;
    }
}

public class Pair<TFirst, TSecond>
{
    public TFirst First { get; }
    public TSecond Second { get; }

    public Pair(TFirst first, TSecond second) =>
        (First, Second) = (first, second);
}