using Introl.Assists;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Effects;

namespace Introl.Converters
{
    /// <summary>
    /// Converters depth and direction of shadow into a <see cref="DropShadowEffect" />.
    /// </summary>
    public class ShadowConverter : IMultiValueConverter
    {
        /// <summary>
        /// Provides a converter instance for access from XAML.
        /// </summary>
        public static ShadowConverter Instance { get; } = new ShadowConverter();


        /// <summary>
        /// Converters depth and direction of shadow into a <see cref="DropShadowEffect" />.
        /// </summary>
        /// <param name="values">
        /// The array of depth (<see cref="int" />) and direction (<see cref="ShadowDirection" />).
        /// </param>
        /// <param name="targetType">
        /// This parameter is not used.
        /// </param>
        /// <param name="parameter">
        /// This parameter is not used.
        /// </param>
        /// <param name="culture">
        /// This parameter is not used.
        /// </param>
        /// <returns>
        /// A <see cref="DropShadowEffect" /> of shadow.
        /// </returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2 && values[0] is int depth && values[1] is ShadowDirection direction)
            {
                return GetShadowEffect(depth, direction);
            }

            return DependencyProperty.UnsetValue;
        }

        /// <summary>
        /// Not supported.
        /// </summary>
        /// <exception cref="NotSupportedException">
        /// The method was called.
        /// </exception>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }


        private static Effect GetShadowEffect(int depth, ShadowDirection direction)
        {
            return new DropShadowEffect
            {
                BlurRadius = depth * 2,
                ShadowDepth = depth * 2 / 3.5,
                Direction = (double)direction,
                Opacity = .38
            };
        }
    }
}
