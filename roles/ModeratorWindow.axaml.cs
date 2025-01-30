using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using demo2001.Models;

namespace demo2001;

public partial class ModeratorWindow : Window
{
    public ModeratorWindow(Moderator moderator)
    {
        InitializeComponent();
    }
    public ModeratorWindow() { }
}