using System.Text;

class Gold
{
    private long totalGoldAmount;

    public Gold()
    {
        TotalGoldAmount = 0L;
    }

    public long TotalGoldAmount
    {
        get => totalGoldAmount;
        set => totalGoldAmount = value;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"<Gold> ${this.totalGoldAmount}");
        sb.AppendLine($"##Gold - {this.totalGoldAmount}");
        return sb.ToString();
    }
}