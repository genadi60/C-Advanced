using System;
using System.Collections.Generic;
using System.Linq;

class KeyRevolver
{
    static void Main()
    {
        var buletPrice = int.Parse(Console.ReadLine());
        var barrelSize = int.Parse(Console.ReadLine());
        var bulletsValues = Console.ReadLine().Split()
            .Select(int.Parse);
        var lockQueue = new Queue<int>(Console.ReadLine().Split()
            .Select(int.Parse));
        var intelligence = int.Parse(Console.ReadLine());
        var stackBullets = new Stack<int>(bulletsValues);
        var bulletsCount = stackBullets.Count;
        var barrelsCount = barrelSize;
        bool isFinish = false;
        
            while (true)
            {
                for (int counter = 0; counter < barrelSize; counter++)
                {
                    if (lockQueue.Count > 0 && stackBullets.Count > 0)
                    {
                        barrelsCount--;
                        var bullet = stackBullets.Pop();
                        var lockSize = lockQueue.Peek();
                        if (bullet <= lockSize)
                        {
                            Console.WriteLine("Bang!");
                            lockQueue.Dequeue();
                            
                        }
                        else
                        {
                            Console.WriteLine("Ping!");
                        }
                    }
                    else
                    {
                        isFinish = true;
                        break;
                    }

                    
                }

                if (isFinish)
                {
                    break;
                }

                if (barrelsCount == 0 && stackBullets.Count > 0)
                {
                Console.WriteLine("Reloading!");
                    barrelsCount = barrelSize;
                }
                
            }

        if (stackBullets.Count < lockQueue.Count)
        {
            Console.WriteLine($"Couldn't get through. Locks left: {lockQueue.Count}");
        }
        else
        {
            Console.WriteLine($"{stackBullets.Count} bullets left. Earned ${intelligence - (bulletsCount - stackBullets.Count) * buletPrice}");
        }
    }
}