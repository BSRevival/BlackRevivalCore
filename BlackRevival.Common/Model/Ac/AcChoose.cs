using BlackRevival.Common.Model;
using BlackRevival.Common.Enums;
using BlackRevival.Common.GameDB.Expedition;
using Serilog;
using Serilog.Core;

namespace BlackRevival.Common.Model;

public class AcChoose
{
    public static int Choose(float[] probs)
    {
        return AcChoose.Choose(new List<float>(probs));
    }

    public static int Choose(List<float> probs)
    {
        float num = 0f;
        foreach (float num2 in probs)
        {
            num += num2;
        }
        return AcChoose.Choose(probs, num);
    }

    public static bool Choose(float prob)
    {
        int num = (prob >= 0.5f) ? 1 : 0;
        return AcChoose.Choose(new float[]
        {
            prob,
            1f - prob
        }) == num;
    }

    private static int Choose(List<float> probs, float total)
    {
        probs.Sort();
        Random random = new Random();
        float num = (float)random.NextDouble() * total;
        float num2 = 0f;
        for (int i = 0; i < probs.Count; i++)
        {
            num2 += probs[i];
            if (num2 >= num)
            {
                return i;
            }
        }
        Log.Error("확률이 이상하네? 여기까지 오면 안 됨");
        return 0;
    }

    public static int[] ChooseMultiple(List<float> probs, int count, bool duplicate = true)
    {
        if (!duplicate && probs.Count < count)
        {
            return null;
        }
        int[] array = new int[count];
        if (duplicate)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = AcChoose.Choose(probs);
            }
        }
        else
        {
            HashSet<int> hashSet = new HashSet<int>();
            while (hashSet.Count < count)
            {
                int num = AcChoose.Choose(probs);
                if (hashSet.Add(num))
                {
                    array[hashSet.Count - 1] = num;
                }
            }
        }
        return array;
    }

    public static AcChoose.AcChoosObject Choose(List<AcChoose.AcChoosObject> probs)
    {
        if (probs == null || probs.Count == 0)
        {
            return null;
        }
        //from param in probs
        //orderby param.prob
        //select param;
        float num = 0f;
        foreach (AcChoose.AcChoosObject acChoosObject in probs)
        {
            num += acChoosObject.prob;
        }
        Random random = new Random();
        float num2 = (float)random.NextDouble() * num;
        float num3 = 0f;
        for (int i = 0; i < probs.Count; i++)
        {
            num3 += probs[i].prob;
            if (num3 >= num2)
            {
                return probs[i];
            }
        }
        Log.Error("확률이 이상하네? 여기까지 오면 안 됨");
        return null;
    }

    public static List<AcChoose.AcChoosObject> ChooseMultiple(List<AcChoose.AcChoosObject> probs, int count, bool duplicate = true)
    {
        if (!duplicate && probs.Count < count)
        {
            return null;
        }
        List<AcChoose.AcChoosObject> list = new List<AcChoose.AcChoosObject>();
        if (duplicate)
        {
            for (int i = 0; i < count; i++)
            {
                list.Add(AcChoose.Choose(probs));
            }
        }
        else
        {
            HashSet<AcChoose.AcChoosObject> hashSet = new HashSet<AcChoose.AcChoosObject>();
            while (hashSet.Count < count)
            {
                AcChoose.AcChoosObject item = AcChoose.Choose(probs);
                if (hashSet.Add(item))
                {
                    list.Add(item);
                }
            }
        }
        return list;
    }

    public class AcChoosObject
    {
        public AcChoosObject(float prob, object data)
        {
            this.prob = prob;
            this.data = data;
        }

        public AcChoosObject(float prob, object data, object data2)
        {
            this.prob = prob;
            this.data = data;
            this.data2 = data2;
        }

        public readonly float prob;

        public readonly object data;

        public readonly object data2;
    }

}
