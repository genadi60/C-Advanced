using System;
using System.Linq;

 class EngineImpl:Engine
{
    private InputReader reader;
    private ConsoleWriter writer;
    private Bag bag;
    

    public EngineImpl()
    {
        Reader = new InputReader();
        Writer = new ConsoleWriter();
        Bag = new Bag();
    }

    private ConsoleWriter Writer
    {
        get => writer;
        set => writer = value;
    }

    private InputReader Reader
    {
        get => reader;
        set => reader = value;
    }

    private Bag Bag
    {
        get => bag;
        set => bag = value;
    }

    public void Run()
    {
        var input = Reader.ReadLine();
        if (String.IsNullOrEmpty(input))
        {
            return;
        }
        Bag.Capacity = long.Parse(input);
        input = Reader.ReadLine();
        if (String.IsNullOrEmpty(input))
        {
            return;
        }
        var itemsWithAmount = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
         
        for (int i = 0; i < itemsWithAmount.Length; i += 2)
        {
            var kindOfLoot = itemsWithAmount[i];
            var amountOfKind = long.Parse(itemsWithAmount[i + 1]);

            var item = FindItem(kindOfLoot);

            if (item != null && Bag.CheckConditionOfBag(item, amountOfKind))
            {
                Bag.DepositAmount(item, amountOfKind, kindOfLoot);
            }
        }

        Writer.Write(Bag);
    }

    private string FindItem(string kindOfLoot)
    {
        if (kindOfLoot.Length == 3)
        {
            return "Cash";
        }
        if (kindOfLoot.ToLower().EndsWith("gem"))
        {
            return "Gem";
        }
        if (kindOfLoot.ToLower() == "gold")
        {
            return "Gold";
        }
        return null;
    }
}