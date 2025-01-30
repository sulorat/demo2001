using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using demo2001.Models;

namespace demo2001;

public partial class ParticipantWindow : Window
{
    public ParticipantWindow(Participant participant)
    {
        InitializeComponent();
    }
    public ParticipantWindow() { }
}