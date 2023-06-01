using Model;
using System.Globalization;

namespace LoL_Champions.Converters
{
    public class ClassToClassIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ChampionClass)value)
            {
                case ChampionClass.Unknown:
                    return "";
                case ChampionClass.Assassin:
                    return "assassin_icon.png";
                case ChampionClass.Fighter:
                    return "fighter_icon.png";
                case ChampionClass.Mage:
                    return "mage_icon.png";
                case ChampionClass.Marksman:
                    return "marksman_icon.png";
                case ChampionClass.Support:
                    return "support_icon.png";
                case ChampionClass.Tank:
                    return "tank_icon.png";
                default:
                    return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
