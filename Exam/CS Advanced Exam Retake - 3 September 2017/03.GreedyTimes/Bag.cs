using System.Collections.Generic;
using System.Text;

public class Bag
{
    private Gold gold;
    private Gem gem;
    private Cash cash;
    private long capacity;
    private List<string> bagContent;
    
    public Bag()
    {
        this.gold = new Gold();
        this.gem = new Gem();
        this.cash = new Cash();
        BagContent = new List<string>();
    }

    public List<string> BagContent
    {
        get => bagContent;
        set => bagContent = value;
    }

    public long Capacity
    {
        get => capacity;
        set => capacity = value;
    }

    public void DepositAmount(string item, long amountOfKind, string kindOfLoot)
    {
        switch (item)
        {
            case "Gold":
                gold.TotalGoldAmount += amountOfKind;
                break;

            case "Gem":
                gem.TotalGemAmount += amountOfKind;
                if (!gem.KindsOfGem.ContainsKey(kindOfLoot))
                {
                    gem.KindsOfGem[kindOfLoot] = 0L;
                }
                gem.KindsOfGem[kindOfLoot] += amountOfKind;
                break;

            case "Cash":
                cash.TotalCashAmount += amountOfKind;
                if (!cash.KindsOfCash.ContainsKey(kindOfLoot))
                {
                    cash.KindsOfCash[kindOfLoot] = 0L;
                }
                cash.KindsOfCash[kindOfLoot] += amountOfKind;
                break;
        }

        Capacity -= amountOfKind;
        if (!BagContent.Contains(item))
        {
            BagContent.Add(item);
        }
    }

    public bool CheckConditionOfBag(string item, long amountOfKind)
    {
        if (Capacity < amountOfKind)
        {
            return false;
        }

        switch (item)
        {
            case "Gem":
                if (BagContent.Contains("Gold"))
                {
                    if ((gem.TotalGemAmount + amountOfKind) > gold.TotalGoldAmount)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                
                break;

            case "Cash":
                if (BagContent.Contains("Gem"))
                {
                    if ((cash.TotalCashAmount + amountOfKind) > gem.TotalGemAmount)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                
                break;
        }

        return true;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        if (BagContent.Contains("Gold"))
        {
            sb.Append(this.gold.ToString());
            if (BagContent.Contains("Gem"))
            {
                sb.Append(this.gem.ToString());
                if (BagContent.Contains("Cash"))
                {
                    sb.Append(this.cash.ToString());
                }
            }
        }
        return sb.ToString();
    }
}