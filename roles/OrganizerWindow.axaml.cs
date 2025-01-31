using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using demo2001.Models;
using System;

namespace demo2001;

public partial class OrganizerWindow : Window
{
    private string greeting;
    Organizer organizer1;
    public OrganizerWindow( Organizer organizer)
    {
        InitializeComponent();


        organizer1 = organizer;
        GetGreeting();
        
        HelloTextBlock.Text = greeting;
    }
    public OrganizerWindow() { }

    private void GetGreeting()
    {
        TimeSpan currentTime = DateTime.Now.TimeOfDay;

        if (currentTime >= new TimeSpan(9, 0, 0) && currentTime <= new TimeSpan(11, 0, 0))
        {
            greeting = string.Format("Доброе утро, {0} {1} {2}", organizer1.LastName, organizer1.FirstName, organizer1.Patronymic);
        }
        else if (currentTime >= new TimeSpan(11, 1, 0) && currentTime <= new TimeSpan(18, 0, 0))
        {
            greeting = string.Format("Добрый день, {0} {1} {2}", organizer1.LastName, organizer1.FirstName, organizer1.Patronymic);
        }
        else if (currentTime >= new TimeSpan(18, 1, 0) && currentTime <= new TimeSpan(23, 59, 59))
        {
            greeting = string.Format("Добрый вечер, {0} {1} {2}", organizer1.LastName,organizer1.FirstName,organizer1.Patronymic);
        }
        else
        {
            greeting = string.Format("Добро пожаловать, {0} {1} {2}", organizer1.LastName,organizer1.FirstName,organizer1.Patronymic);
        }
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var createWindow = new CreateWindow();
        createWindow.Show();
        Hide(); 
    }
}