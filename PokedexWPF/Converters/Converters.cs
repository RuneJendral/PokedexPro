using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace PokedexWPF.Converters
{
    public class WeightToKgConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return "0 kg";
            if (double.TryParse(value.ToString(), out var grams))
            {
                var kg = grams / 10.0;
                return $"{kg:0.0} kg";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }

    public class HeihtToMeterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return "0 m";
            if(double.TryParse(value.ToString(),out var dezim))
            {
                var m = dezim / 10.0;
                return $"{m:0.0} m";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }

    public class PokemonTypeToBrushConverter : IValueConverter
    {
        private static readonly Dictionary<string, Color> Map =
            new(StringComparer.OrdinalIgnoreCase)
            {
                ["normal"] = (Color)ColorConverter.ConvertFromString("#FFA8A77A"),
                ["fire"] = (Color)ColorConverter.ConvertFromString("#FFEE8130"),
                ["water"] = (Color)ColorConverter.ConvertFromString("#FF6390F0"),
                ["electric"] = (Color)ColorConverter.ConvertFromString("#FFF7D02C"),
                ["grass"] = (Color)ColorConverter.ConvertFromString("#FF7AC74C"),
                ["ice"] = (Color)ColorConverter.ConvertFromString("#FF96D9D6"),
                ["fighting"] = (Color)ColorConverter.ConvertFromString("#FFC22E28"),
                ["poison"] = (Color)ColorConverter.ConvertFromString("#FFA33EA1"),
                ["ground"] = (Color)ColorConverter.ConvertFromString("#FFE2BF65"),
                ["flying"] = (Color)ColorConverter.ConvertFromString("#FFA98FF3"),
                ["psychic"] = (Color)ColorConverter.ConvertFromString("#FFF95587"),
                ["bug"] = (Color)ColorConverter.ConvertFromString("#FFA6B91A"),
                ["rock"] = (Color)ColorConverter.ConvertFromString("#FFB6A136"),
                ["ghost"] = (Color)ColorConverter.ConvertFromString("#FF735797"),
                ["dragon"] = (Color)ColorConverter.ConvertFromString("#FF6F35FC"),
                ["dark"] = (Color)ColorConverter.ConvertFromString("#FF705746"),
                ["steel"] = (Color)ColorConverter.ConvertFromString("#FFB7B7CE"),
                ["fairy"] = (Color)ColorConverter.ConvertFromString("#FFD685AD"),
            };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var typeName = value as string;
            if (string.IsNullOrWhiteSpace(typeName)) return Brushes.Transparent;

            if (Map.TryGetValue(typeName, out var color))
                return new SolidColorBrush(color);

            return new SolidColorBrush(Colors.Gray); 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }

    public class TypesToGradientBrushConverter : IMultiValueConverter
    {
        private static readonly PokemonTypeToBrushConverter Single = new();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var types = values?.OfType<string>().Where(s => !string.IsNullOrWhiteSpace(s)).ToArray()
                        ?? Array.Empty<string>();
            if (types.Length == 0) return Brushes.Transparent;
            if (types.Length == 1) return Single.Convert(types[0], targetType, parameter, culture);

            var b1 = (Brush)Single.Convert(types[0], targetType, parameter, culture);
            var b2 = (Brush)Single.Convert(types[1], targetType, parameter, culture);

            var lg = new LinearGradientBrush
            {
                StartPoint = new(0, 0),
                EndPoint = new(1, 0),
                ColorInterpolationMode = ColorInterpolationMode.ScRgbLinearInterpolation // smoother
            };
            lg.GradientStops.Add(new GradientStop(((SolidColorBrush)b1).Color, 0.0));
            lg.GradientStops.Add(new GradientStop(((SolidColorBrush)b2).Color, 1.0));
            return lg;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}

