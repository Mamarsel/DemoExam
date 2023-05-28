using DemoExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoExam.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            using (var db = new user60Entities())
            {
                var events = db.Event.ToList();
                EventsListView.ItemsSource = events;
                var directions = db.Direction.ToList();
                var types = db.Type_event.ToList();

                foreach (var item in directions)
                {
                    DirectionsCB.Items.Add(item.Direction1);
                }
                DirectionsCB.Items.Insert(0, "Все направления");

                foreach (var item in types)
                {
                    TypesCB.Items.Add(item.Tipe_event);
                }
                TypesCB.Items.Insert(0, "Все типы");

                DirectionsCB.SelectedIndex = 0;
                TypesCB.SelectedIndex = 0;
            }
        }
        public object foreachitem = new object();
        private void Update()
        {
            using (var db = new user60Entities())
            {
                EventsListView.ItemsSource = null;

                var events = db.Event.Include("Event_type_event").ToList();
                var directions = db.Direction.ToList();
                var types = db.Type_event.ToList();
                var removeevents = new List<Event>();

                if(DirectionsCB.SelectedIndex > 0)
                {
                    events = events.Where(x => x.Event_type_event.
                        Any(y => y.ID_direction == directions.
                        FirstOrDefault(z => z.Direction1 == DirectionsCB.
                            SelectedItem.ToString()).ID_direction)).ToList();
                }

                if (TypesCB.SelectedIndex > 0)
                {
                    events = events.Where(x => x.Event_type_event.
                        Any(y => y.ID_type_event == types.
                        FirstOrDefault(z => z.Tipe_event == TypesCB.
                            SelectedItem.ToString()).ID_type_event)).ToList();
                }

                if (DateStartCalendar.SelectedDate != null)
                    events = events.Where(x => x.Date_start > DateStartCalendar.SelectedDate).ToList();

                EventsListView.ItemsSource = events;
            }
        }
        private void DateStartCalendar_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void DirectionsCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void TypesCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
    }
}
