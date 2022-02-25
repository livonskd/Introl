using System.Windows;

namespace Introl.Assists
{
    /// <summary>
    /// Provides attached properties for setting shadow.
    /// </summary>
    public static class ShadowAssist
    {
        #region Attached Property: Depth
        /// <summary>
        /// Identifies the <see cref="ShadowAssist" />.Depth attached property.
        /// </summary>
        public static readonly DependencyProperty DepthProperty = DependencyProperty.RegisterAttached(
            "Depth",
            typeof(int),
            typeof(ShadowAssist)
        );

        /// <summary>
        /// Gets the value of the <see cref="ShadowAssist" />.Depth attached property from a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element from which to read the property value.
        /// </param>
        /// <returns>
        /// The value of the <see cref="ShadowAssist" />.Depth attached property.
        /// </returns>
        public static int GetDepth(UIElement element) => (int)element.GetValue(DepthProperty);

        /// <summary>
        /// Sets the value of the <see cref="ShadowAssist" />.Depth attached property to a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element on which to set the <see cref="ShadowAssist" />.Depth attached property.
        /// </param>
        /// <param name="value">
        /// The property value to set.
        /// </param>
        public static void SetDepth(UIElement element, int value) => element.SetValue(DepthProperty, value);
        #endregion


        #region Attached Property: Direction
        /// <summary>
        /// Identifies the <see cref="ShadowAssist" />.Direction attached property.
        /// </summary>
        public static readonly DependencyProperty DirectionProperty = DependencyProperty.RegisterAttached(
            "Direction",
            typeof(ShadowDirection),
            typeof(ShadowAssist),
            new PropertyMetadata(ShadowDirection.Bottom)
        );

        /// <summary>
        /// Gets the value of the <see cref="ShadowAssist" />.Direction attached property from a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element from which to read the property value.
        /// </param>
        /// <returns>
        /// The value of the <see cref="ShadowAssist" />.Direction attached property.
        /// </returns>
        public static ShadowDirection GetDirection(UIElement element) => (ShadowDirection)element.GetValue(DirectionProperty);

        /// <summary>
        /// Sets the value of the <see cref="ShadowAssist" />.Direction attached property to a given <see cref="UIElement" />.
        /// </summary>
        /// <param name="element">
        /// The element on which to set the <see cref="ShadowAssist" />.Direction attached property.
        /// </param>
        /// <param name="value">
        /// The property value to set.
        /// </param>
        public static void SetDirection(UIElement element, ShadowDirection value) => element.SetValue(DirectionProperty, value);
        #endregion
    }
}
