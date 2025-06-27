# FlexoGrid

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![Language](https://img.shields.io/badge/language-C%23-239120.svg)
![Platform](https://img.shields.io/badge/platform-WPF-blueviolet)

FlexoGrid は、簡潔な記述で WPF の Grid レイアウトを設定できる軽量なライブラリです。`RowPattern` と `ColumnPattern` を指定することで、従来の XAML より直感的にレイアウト構築が可能です。

---

## 📦 プロジェクト構成

```
/
├── FlexGridWPF/           # FlexoGrid ライブラリ (DLL)
│   └── FlexoGrid.csproj
├── FlexoGridSample/       # サンプル WPF アプリ
│   └── FlexoGridSample.csproj
├── README.md              # このファイル
├── LICENCE                # ライセンス
```

---

## 🚀 使用方法

### 1. XAML での使用例

```xml
<Window x:Class="SampleApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:f="clr-namespace:FlexGridWPF;assembly=FlexGridWPF"
        ... >

    <f:FlexoGrid RowPattern="Auto,*,Auto" ColumnPattern="Auto,*,Auto">
        <TextBlock Grid.Row="0" Grid.Column="0" Text="Top Left" />
        <TextBlock Grid.Row="1" Grid.Column="1" Text="Center" />
        <TextBlock Grid.Row="2" Grid.Column="2" Text="Bottom Right" />
    </f:FlexoGrid>
</Window>
```

### 2. RowPattern / ColumnPattern の形式

- `Auto`または`A`: コンテンツサイズに合わせる
- `*` や `2*`: スターサイズ（比率）
- 数値: ピクセル固定値

例：`"Auto,*,2*,100"` → 4行構成

---

## 🛠️ ビルド方法

Visual Studio または `dotnet` CLI でビルド可能です。

```bash
dotnet build FlexGridWPF/FlexoGrid.csproj
dotnet run --project FlexoGridSample/FlexoGridSample.csproj
```

---

## 📄 ライセンス

このプロジェクトは [MIT License](https://opensource.org/licenses/MIT) の下で公開されています。自由に利用・改変・配布が可能です。

---

## 🙏 クレジット

本ライブラリは参考実装に基づき、独自に再設計・再構成されたものです。
