using TUnit.Core;

namespace Day1.Test;

public class DifTest
{
    [Test]
    public async Task CalculateTotalDif()
    {
        var result = Dif.CalculateTotalDifference("data.txt");
        await Assert.That(result).IsEqualTo(11);
    }
    
    [Test]
    public async Task CalculateTotalSimilarity()
    {
        var result = Dif.CalculateTotalSimilarity("data.txt");
        await Assert.That(result).IsEqualTo(31);
    }
}