using BlackRevival.Common.Enums;

public static class ItemOptionColorExtension
{
    public static string GetColor(this ItemOptionColor color, float point)
    {
        if (color != ItemOptionColor.ADVANTAGE)
        {
            if (color != ItemOptionColor.DISADVANTAGE)
            {
                return "FFFFFF";
            }
            if (point >= 0f)
            {
                return "F22613";
            }
            return "54CA58";
        }
        else
        {
            if (point < 0f)
            {
                return "F22613";
            }
            return "54CA58";
        }
    }
}