using System;
[Serializable]
public class PropabilityTable
{
    public PropabilityTableItem[] items;
    private int propabilitySum;
    private bool inisialized;
    private Random random;

    private void init()
    {
        random = new Random();
        foreach (var item in items)
        {
            propabilitySum += item.propability;
        }
        inisialized = true;
    }

    public UnityEngine.GameObject GetRandomItem()
    {
        if (!inisialized) init();
        int index = random.Next(0, propabilitySum);

        foreach (var item in items)
        {
            index -= item.propability;
            if (index <= 0) return item.value;
        }
        return null;
    }
}