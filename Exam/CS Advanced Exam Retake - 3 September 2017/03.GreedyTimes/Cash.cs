using System.Collections.Generic;
using System.Linq;
using System.Text;

class Cash
{
    private Dictionary<string, long> kindsOfCash;
    private long totalCashAmount;

    public Cash()
    {
        KindsOfCash = new Dictionary<string, long>();
        TotalCashAmount = 0L;
    }

    public Dictionary<string, long> KindsOfCash
    {
        get => kindsOfCash;
        set => kindsOfCash = value;
    }

    public long TotalCashAmount
    {
        get => totalCashAmount;
        set => totalCashAmount = value;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"<Cash> ${TotalCashAmount}");
        foreach (KeyValuePair<string, long> kvp in KindsOfCash.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
        {
            sb.AppendLine($"##{kvp.Key} - {kvp.Value}");
        }

        return sb.ToString();
    }
}