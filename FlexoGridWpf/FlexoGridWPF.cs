
// MIT License
// Copyright (c) 2025 gamash61
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace FlexoGridWpf
{
    public class FlexoGrid : Grid
    {
        [Description("Defines the row layout. Format: 'Auto,*,2*' etc."), Category("Layout")]
        public string RowPattern
        {
            get => (string)GetValue(RowPatternProperty);
            set => SetValue(RowPatternProperty, value);
        }

        [Description("Defines the column layout. Format: '100,Auto,*' etc."), Category("Layout")]
        public string ColumnPattern
        {
            get => (string)GetValue(ColumnPatternProperty);
            set => SetValue(ColumnPatternProperty, value);
        }

        public static readonly DependencyProperty RowPatternProperty =
            DependencyProperty.Register(nameof(RowPattern), typeof(string), typeof(FlexoGrid),
                new PropertyMetadata(string.Empty, (d, e) => ((FlexoGrid)d).UpdateRowDefinitions()));

        public static readonly DependencyProperty ColumnPatternProperty =
            DependencyProperty.Register(nameof(ColumnPattern), typeof(string), typeof(FlexoGrid),
                new PropertyMetadata(string.Empty, (d, e) => ((FlexoGrid)d).UpdateColumnDefinitions()));

        private void UpdateRowDefinitions()
        {
            RowDefinitions.Clear();
            foreach (var length in ParseLayoutPattern(RowPattern))
                RowDefinitions.Add(new RowDefinition { Height = length });
        }

        private void UpdateColumnDefinitions()
        {
            ColumnDefinitions.Clear();
            foreach (var length in ParseLayoutPattern(ColumnPattern))
                ColumnDefinitions.Add(new ColumnDefinition { Width = length });
        }

        private static IEnumerable<GridLength> ParseLayoutPattern(string pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern))
                yield break;

            var parts = pattern.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                var trimmed = part.Trim();

                // Handle "Auto"
                if (Regex.IsMatch(trimmed, @"^(auto|a)$", RegexOptions.IgnoreCase))
                {
                    yield return new GridLength(1, GridUnitType.Auto);
                }
                // Handle star sizing like "*", "2*"
                else if (Regex.IsMatch(trimmed, @"^\d*(\.\d+)?\*$"))
                {
                    var starValue = trimmed.TrimEnd('*');
                    if (string.IsNullOrEmpty(starValue)) starValue = "1";
                    if (double.TryParse(starValue, out var starSize))
                    {
                        yield return new GridLength(starSize, GridUnitType.Star);
                    }
                    else
                    {
                        throw new FormatException($"Invalid star value in layout pattern: '{trimmed}'");
                    }
                }
                // Handle pixel values
                else if (double.TryParse(trimmed, out var pixelSize))
                {
                    yield return new GridLength(pixelSize, GridUnitType.Pixel);
                }
                else
                {
                    throw new FormatException($"Unrecognized grid size value: '{trimmed}'");
                }
            }
        }
    }
}
