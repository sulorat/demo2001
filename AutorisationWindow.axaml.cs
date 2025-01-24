using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using demo2001.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading.Tasks;

namespace demo2001;

public partial class AutorisationWindow : Window
{
    public AutorisationWindow()
    {
        InitializeComponent();

    }

    private async void ToLogClick(object? sender, RoutedEventArgs e)
    {
        string Id = IdTextBox.Text;
        int fails = 0;
        string Password = PasswordTextBox.Text;

        using var dbContext = new User3Context();

        var participant = await dbContext.Participants.FirstOrDefaultAsync(p => p.Id.ToString() == Id && p.Pasword == Password); 
        var moderator = await dbContext.Moderators.FirstOrDefaultAsync(p => p.Id.ToString() == Id && p.Pasword == Password); 
        var organizator = await dbContext.Organizers.FirstOrDefaultAsync(p => p.Id.ToString() == Id && p.Pasword == Password);

        if (participant != null)
        {

        }
        else if (moderator != null)
        {

        }
        else if (organizator != null)
        {

        }

        else 
        { 
            fails++;
            if (fails >= 3)
            {
                ErrorTextBlock.Text = "Слишком много неверных попыток. Попробуйте снова через 10 секунд.";
                Autorisation.IsEnabled = false;
                await Task.Delay(10000);
                Autorisation.IsEnabled = true;
                ErrorTextBlock.Text = "";
                fails = 0;
            }

            else
            {
                ErrorTextBlock.Text = "Неверные учетные данные!";
                await Task.Delay(3000);
                ErrorTextBlock.Text = "";
                return;
            }
        }
    }


}