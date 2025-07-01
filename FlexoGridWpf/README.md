# FlexoGridWPF

**FlexoGrid** is a lightweight WPF layout library that allows you to define `Grid` rows and columns using concise pattern strings like `"Auto,*,2*,100"`.

## Features

- Define layouts with `RowPattern` and `ColumnPattern` using intuitive strings
- Supports `Auto`, star (`*`), and fixed pixel (`100`) values
- Simple syntax for rapid UI prototyping
- Easy integration with standard XAML

## Example

```xml
<f:FlexoGrid RowPattern="Auto,*,Auto" ColumnPattern="Auto,*,Auto">
    <TextBlock Grid.Row="0" Grid.Column="0" Text="Top Left" />
    <TextBlock Grid.Row="1" Grid.Column="1" Text="Center" />
    <TextBlock Grid.Row="2" Grid.Column="2" Text="Bottom Right" />
</f:FlexoGrid>
```

## RowPattern / ColumnPattern Values

- `Auto` or `A` : Auto-size to content
- `*`, `2*`     : Star sizing (relative proportion)
- `100`, `50`   : Fixed pixel values

Example: `"Auto,*,2*,100"` defines 4 rows with mixed sizing.

---
## Implementation Notes
This control was independently designed and implemented from scratch by gamash61.
While it was inspired by public layout paradigms (such as grid string syntax like "Auto,*,2*"), the actual codebase is entirely original and not based on any proprietary or copyrighted library.
It is distributed under the MIT License for free and open use.

---
For more information, visit the [GitHub repository](https://github.com/gamash61/FlexoGridWPF).

## License

Licensed under the [MIT License](https://opensource.org/licenses/MIT).  
© 2025 gamash61 / AWing-Soft
