# Spirographs

## Description
Spirographs is a Windows application written in C# using WPF, and is based on Rod Stephen's Windows Forms based program listed on his C# Helper blog entry **_Draw a hypotrochoid (Spirograph curve) in C#_** at http://csharphelper.com/blog/2014/08/draw-a-hypotrochoid-spirograph-curve-in-c/

![Spirographs - A WPF Application](https://github.com/ClockEndGooner/Spirographs/blob/master/images/Spirographs.png)

## References Used
- Microsoft Windows Presentation Framework & XAML Version 4.0
- XCeed Extended.Wpf.Toolkit Version 3.4.0 (_**NuGet Package:** https://www.nuget.org/packages/Extended.Wpf.Toolkit/_)

## Features Implemented
This project demonstrates the following basic desktop application features:

- Saving and loading the main application window size, position and user display preferences (_**Source Files:** [App.xaml.cs](Spirographs/App.xaml.cs) and [UserSettings.cs](Spirographs/UserSettings.cs)_.)

- Managing and drawing on a WPF Canvas inside a Viewbox, allowing for a dynamically generated graphic to be proportionally scaled as the main application window is resized (_**Source Files:** [MainWindow.xaml](Spirographs/MainWindow.xaml) and [MainWindow.xaml.cs](Spirographs/MainWindow.xaml.cs)_.)

- Saving the contents rendered to a WPF Canvas using a BitmapEncoder to a specified BMP, GIF, JPEG, PNG, TIFF or WMP image file format (_**Source Files:** [Spirograph.cs](Spirographs/Spirograph.cs)_.)

- Creating modal dialog boxes derived from WPF's Window class (_**Source Files:** [AboutSpirographDialog.xaml](Spirographs/AboutSpirographDialog.xaml) and [AboutSpirographDialog.xaml.cs](Spirographs/AboutSpirographDialog.xaml.cs), [SettingsDialog.xaml](Spirographs/SettingsDialog.xaml) and [SettingsDialog.xaml.cs](Spirographs/SettingsDialog.xaml.cs), and [WarningDialog.xaml](Spirographs/WarningDialog.xaml) and [WarningDialog.xaml.cs](Spirographs/WarningDialog.xaml.cs)_.)

- Customizing the appearance of application windows and their child elements using WPF XAML declarations, attributes, resource definitions, styles and triggers (_**Source Files:** MainWindow.xaml, [AboutSpirographDialog.xaml](Spirographs/AboutSpirographDialog.xaml), [SettingsDialog.xaml](Spirographs/SettingsDialog.xaml), and [WarningDialog.xaml](Spirographs/WarningDialog.xaml)_.)

- Using a WPF Hyperlink to open a specified web link using the system's default web browser (_**Source Files:** [AboutSpirographsDialog.xaml](Spirographs/AboutSpirographsDialog.xaml) and [AboutSpirographsDialog.xaml.cs](/Spirographs/AboutSpirographsDialog.xaml.cs)._)

## License
Released under the GNU General Public License Version 3
