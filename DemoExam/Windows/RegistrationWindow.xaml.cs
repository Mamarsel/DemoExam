using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using DemoExam.Models;
using DemoExam.Windows;
using Microsoft.SqlServer.Server;
using Microsoft.Win32;

namespace DemoExam.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        int selectedRole = 0;
        string selectedImage;

        public RegistrationWindow()
        {
            InitializeComponent();

            using (var db = new user60Entities())
            {
                foreach (var roles in db.Role) 
                {
                    RoleCB.Items.Add(roles.Role1);
                }
            }
        }

        private void AddUserBTN_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new user60Entities())
            {
                if (SurnameTB.Text == String.Empty)
                {
                    MessageBox.Show("Введи фамилию, хуйло!");
                    return;
                }
                if (PasswordTB.Text == String.Empty)
                {
                    MessageBox.Show("Введи пароль, хуйло!");
                    return;
                }
                if (PhoneTB.Text == String.Empty)
                {
                    MessageBox.Show("Введи номер, хуйло!");
                    return;
                }
                if (selectedRole == 0)
                {
                    MessageBox.Show("Выбери роль, хуйло!");
                    return;
                }

                foreach (var user in db.Uzer)
                {
                    if (user.Password == PasswordTB.Text && user.Surname == SurnameTB.Text &&
                            user.First_name == FirstNameTB.Text && user.Last_name == LastNameTB.Text)
                    {
                        MessageBox.Show("Такой пользователь уже существует.");
                        return;
                    }
                }

                try
                {
                    Uzer newUser = new Uzer();
                    newUser.First_name = FirstNameTB.Text;
                    newUser.Surname = SurnameTB.Text;
                    newUser.Last_name = LastNameTB.Text;
                    newUser.Password = PasswordTB.Text;
                    newUser.Birth_date = BirthdateСalendar.SelectedDate;
                    newUser.Telephone = PhoneTB.Text;
                    newUser.E_mail = EmailTB.Text;
                    newUser.Photo = this.selectedImage;
                    newUser.Uzer_role = null;
                    newUser.Gender = null;
                    newUser.Direction = null;
                    db.Uzer.Add(newUser);
                    db.SaveChanges();

                    Uzer_role uzer_Role = new Uzer_role();
                    var id = db.Uzer.FirstOrDefault(x => x.Password.Contains(PasswordTB.Text) 
                                && x.Telephone.Contains(PhoneTB.Text));
                    uzer_Role.ID_uzer = id.ID_uzer;
                    uzer_Role.ID_role = this.selectedRole;
                    db.Uzer_role.Add(uzer_Role);

                    db.SaveChanges();
                    MessageBox.Show("Успешно!^^");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BirthdateСalendar_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RoleCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = RoleCB.SelectedItem.ToString();

            if (selected == null)
                return;

            using (var db = new user60Entities())
            {
                var roles = db.Role.FirstOrDefault(x => x.Role1.ToLower().Contains(selected.ToLower()));

                if (roles == null)
                    return;

                this.selectedRole = roles.ID_role;
            }
        }
        private void UserImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SaveFileDialog _saveFile = new SaveFileDialog();
            _saveFile.Title = "Save file";
            _saveFile.Filter = "PNG|*.png";

            if (_saveFile.ShowDialog() == true)
            {
                try
                {
                    UserImage.Source = new BitmapImage(new Uri(_saveFile.FileName));
                    this.selectedImage = _saveFile.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
