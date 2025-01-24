using Avalonia.Controls;
using Avalonia.Interactivity;
using demo2001.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace demo2001
{
    public partial class MainWindow : Window
    {
        public class EventPresenter : Event
        {
            public string EventTitle { get => this.Title; }
            public DateOnly? EventStartDate { get => this.StartDate; }
            public int? EventDuration { get => this.DurationDays; }

        }
        public List<EventPresenter> _events { get; set; }
        public ObservableCollection<EventPresenter> DisplayEvents =  new ObservableCollection<EventPresenter>();

        public MainWindow()
        {
            InitializeComponent();

            using (var dbContext = new User3Context())
            {
                _events = dbContext.Events.Select(service=>new EventPresenter
                {
                    Title = service.Title,
                    StartDate = service.StartDate,
                    DurationDays = service.DurationDays,

                }).ToList();
            }

            EventsListBox.ItemsSource = DisplayEvents;
            DisplayEvent();
        }

        public void DisplayEvent()
        {
            List<EventPresenter> _displayEvents = new List<EventPresenter>(_events);




            if(DisplayEvents.Count> 0)
            {
                DisplayEvents.Clear();
            }
            foreach (EventPresenter events in _displayEvents)
            {
                DisplayEvents.Add(events);
            }
        }

        private void ToAutorisationButtonClick(object? sender, RoutedEventArgs e)
        {
            var autorisWin = new AutorisationWindow();
            autorisWin.Show();  
            this.Hide();
        }
    }
}