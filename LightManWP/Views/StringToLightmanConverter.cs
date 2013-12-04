using System;
using System.Globalization;
using System.Windows.Data;
using LightManWP.Notifications;

namespace LightManWP.Views
{
    public class StringToLightmanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var lightman = Lightman.Lightman1And2;
            var lightmanString = value as string;
            if (!string.IsNullOrWhiteSpace(lightmanString))
            {
                if (lightmanString.Equals(Lightman.Lightman1.ToString()))
                {
                    lightman = Lightman.Lightman1;
                }
                else if (lightmanString.Equals(Lightman.Lightman2.ToString()))
                {
                    lightman = Lightman.Lightman2;
                }
            }

            return lightman;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
