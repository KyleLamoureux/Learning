using System;
using System.Collections.Generic;
using System.Linq;
using LinqFaroShuffle;
using System.IO;

class Example
{
    static void Main(string[] args)
    {
        var startingDeck = (from s in Suits().LogQuery("Suit Generation")
                        from r in Ranks().LogQuery("Value Generation")
                        select new { Suit = s, Rank = r })
                        .LogQuery("Starting Deck")
                        .ToArray();

        foreach (var c in startingDeck)
        {
            Console.WriteLine(c);
        }

        Console.WriteLine();

        var times = 0;
        var shuffle = startingDeck;

        do
        {
            /*
            shuffle = shuffle.Take(26)
                .LogQuery("Top Half")
                .InterleaveSequenceWith(shuffle.Skip(26).LogQuery("Bottom Half"))
                .LogQuery("Shuffle")
                .ToArray();
            */

            shuffle = shuffle.Skip(26)
                .LogQuery("Bottom Half")
                .InterleaveSequenceWith(shuffle.Take(26).LogQuery("Top Half"))
                .LogQuery("Shuffle")
                .ToArray();

            foreach (var c in shuffle)
            {
                Console.WriteLine(c);
            }

            times++;
        } while (!startingDeck.SequenceEquals(shuffle));
        Console.WriteLine(times);

    }


    static IEnumerable<string> Suits()
    {
        yield return "clubs";
        yield return "diamonds";
        yield return "hearts";
        yield return "spades";
    }
    static IEnumerable<string> Ranks()
    {
        yield return "two";
        yield return "three";
        yield return "four";
        yield return "five";
        yield return "six";
        yield return "seven";
        yield return "eight";
        yield return "nine";
        yield return "ten";
        yield return "jack";
        yield return "queen";
        yield return "king";
        yield return "ace";
    }

}


/* In order to add some functionaility to how you interact with the IEnumerable<t> you'll get back from LINQ queries, you can use an extension method.
 * Extension methods add new functionality to an already-existing type without having to modifty the original type you want to add functionality to.
 */
namespace LinqFaroShuffle
{
    public static class Extensions
    {
        public static IEnumerable<T> InterleaveSequenceWith<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            var firstIter = first.GetEnumerator();
            var secondIter = second.GetEnumerator();
            while(firstIter.MoveNext() && secondIter.MoveNext())
            {
                yield return firstIter.Current;
                yield return secondIter.Current;
            }
        }

        public static bool SequenceEquals<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            var firstIter = first.GetEnumerator();
            var secondIter = second.GetEnumerator();
            while(firstIter.MoveNext() && secondIter.MoveNext())
            {
                if (!firstIter.Current.Equals(secondIter.Current))
                    return false;
            }
            return true;
        }

        public static IEnumerable<T> LogQuery<T>(this IEnumerable<T> sequence, string tag)
        {
            using (var writer = File.AppendText("debug.log"))
            {
                writer.WriteLine($"Executing Query {tag}");
            }
            return sequence;
        }
    }
}

