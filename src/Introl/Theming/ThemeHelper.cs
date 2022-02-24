using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Introl.Theming
{
    /// <summary>
    /// Provides methods for theming.
    /// </summary>
    public static class ThemeHelper
    {
        /// <summary>
        /// Gets or sets a collection of theme key, theme dictionary pairs.
        /// </summary>
        /// <remarks>
        /// The <see cref="BaseTheme" /> elements are used by default.
        /// </remarks>
        public static IDictionary<object, Uri> ThemeDictionaries { get; set; } = new Dictionary<object, Uri>
        {
            { BaseTheme.Light, new Uri("pack://application:,,,/Introl;component/Themes/Light.xaml") },
            { BaseTheme.Dark, new Uri("pack://application:,,,/Introl;component/Themes/Dark.xaml") }
        };


        /// <summary>
        /// Gets a key of contained theme dictionary.
        /// </summary>
        /// <param name="root">
        /// The root dictionary to get theme.
        /// </param>
        /// <returns>
        /// The theme key from <see cref="ThemeDictionaries" />.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The <paramref name="root" /> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The theme dictionary from <see cref="ThemeDictionaries" /> not found.
        /// </exception>
        public static object GetTheme(this ResourceDictionary root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            ResourceDictionary actualTheme = FindThemeOrNull(root);
            if (actualTheme == null)
            {
                throw new InvalidOperationException("The root dictionary not contains theme dictionary.");
            }

            return ThemeDictionaries.FirstOrDefault(pair => pair.Value.Equals(actualTheme.Source)).Key;
        }

        /// <summary>
        /// Sets a theme dictionary by specified <paramref name="key" />.
        /// </summary>
        /// <param name="root">
        /// The root dictionary to set theme.
        /// </param>
        /// <param name="key">
        /// The theme key from <see cref="ThemeDictionaries" />.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// The <paramref name="root" /> or <paramref name="key" /> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The specified key not defined in <see cref="ThemeDictionaries" />.
        /// </exception>
        public static void SetTheme(this ResourceDictionary root, object key)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (!ThemeDictionaries.ContainsKey(key))
            {
                throw new ArgumentException($"The given theme key not defined. Key: '{ key }'.");
            }

            ResourceDictionary actualTheme = FindThemeOrNull(root);

            root.MergedDictionaries.Add(new ResourceDictionary { Source = ThemeDictionaries[key] });

            if (actualTheme != null)
            {
                root.MergedDictionaries.Remove(actualTheme);
            }
        }


        private static ResourceDictionary FindThemeOrNull(ResourceDictionary root)
        {
            return root.MergedDictionaries.FirstOrDefault(dict => ThemeDictionaries.Values.Contains(dict.Source));
        }
    }
}
