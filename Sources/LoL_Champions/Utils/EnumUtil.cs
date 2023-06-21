namespace LoL_Champions.Utils
{
    public class EnumUtil<TEnum> where TEnum : struct, Enum
    {
        public IEnumerable<TEnum> Values => Enum.GetValues<TEnum>();
    }
}
