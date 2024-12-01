using System.Collections.Frozen;

namespace Day1;

public static class Dif
{
    public static int CalculateTotalDifference(string filename)
    {
        

        var pairs = File.ReadAllLines(filename)
            .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .Select(line => new {first = int.Parse(line[0]), second = int.Parse(line[1])})
            .ToList();
        
        var firstList = pairs.Select(p => p.first).Order().ToList();
        var secondList = pairs.Select(p => p.second).Order().ToList();

        return firstList
            .Select((first, i) => Math.Abs(first - secondList[i]))
            .Sum();
    }

    public static int CalculateTotalSimilarity(string filename)
    {
        

        var pairs = File.ReadAllLines(filename)
            .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .Select(line => new {first = int.Parse(line[0]), second = int.Parse(line[1])})
            .ToList();
        
        var firstList = pairs.Select(p => p.first).Order().ToList();
        var secondList = pairs.Select(p => p.second).GroupBy(v => v).ToFrozenDictionary(grp => grp.Key, grp => grp.Count());

        return firstList
            .Select(first => secondList.TryGetValue(first, out var value) ? value * first : 0)
            .Sum();
    }
}