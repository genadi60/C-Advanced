using System.Collections.Generic;
using System.Linq;
using System.Text;

class Gem
{
    private Dictionary<string, long> kindsOfGem;
    private long totalGemAmount;

    public Gem()
    {
        KindsOfGem = new Dictionary<string, long>();
        TotalGemAmount = 0L;
    }

    public Dictionary<string, long> KindsOfGem
    {
        get => kindsOfGem;
        set => kindsOfGem = value;
    }

    public long TotalGemAmount
    {
        get => totalGemAmount;
        set => totalGemAmount = value;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"<Gem> ${TotalGemAmount}");
        foreach (KeyValuePair<string, long> kvp in KindsOfGem.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
        {
            sb.AppendLine($"##{kvp.Key} - {kvp.Value}");
        }
        
        return sb.ToString();
    }
}