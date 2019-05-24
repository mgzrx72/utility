using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rand = UnityEngine.Random;


public static class UtilityMethods
{
    public static bool RandBool()
    {
        return Rand.Range(0, 2) == 0;
    }
    public static T TwoChoices<T>(T item1, T item2)
    {
        return RandBool() ? item1 : item2;
    }
    public static T AraayChoices<T>(T[] araay)
    {
        return araay[Rand.Range(0, araay.Length)];
    }
    public static T ListChoices<T>(List<T> list)
    {
        return list[Rand.Range(0, list.Count)];
    }
    public static T EnumChoices<T>()
    {
        var enumCount = Enum.GetValues(typeof(T));
        return (T)enumCount.GetValue(Rand.Range(0, enumCount.Length));
    }
    public static int WeightRandom(int[] weight)
    {

        int totalWeight = weight.Sum();
        int value = Rand.Range(1, totalWeight + 1);
        int retIndex = 0;
        for (int i = 0; i < weight.Length; i++)
        {
            if (weight[i] >= value)
            {
                retIndex = i;
                break;
            }

        }
        return retIndex;
    }
    public static float WeightRandom(float[] weight)
    {
        float totalWeight = weight.Sum();
        float value = Rand.Range(0f, totalWeight + 1);
        int retIndex = 0;
        for (int i = 0; i < weight.Length; i++)
        {
            if (weight[i] >= value)
            {
                retIndex = i;
                break;
            }

        }
        return retIndex;
    }
    public static List<int> Slot(int[] weight)
    {
        List<int> result=new List<int>();
        float totalWeight = weight.Sum();
        for (int j = 0; j < 10; j++)
        {
            float value = Rand.Range(0, totalWeight + 1);
            
            for (int i = 0; i < weight.Length; i++)
            {
                if (weight[i] >= value)
                {
                     result[j]= i;
                    break;
                }

            }
        }

        return result;
    }
}


