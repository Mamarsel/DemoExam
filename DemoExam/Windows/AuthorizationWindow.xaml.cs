using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace DemoExam.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        private static int failcounter = 0;
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void AuthorizeButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new user60Entities())
            {
                if (PhoneTextBox.Text == String.Empty)
                {
                    MessageBox.Show("Введи номер, хуйло!");
                    return;
                }
                if (PasswordTextBox.Text == String.Empty)
                {
                    MessageBox.Show("Введи пароль, хуйло!");
                    return;
                }

                var users = db.Uzer.Include("Uzer_role").ToList();
                var roles = db.Role.ToList();

                foreach (var user in users)
                {
                    if (user.Telephone == PhoneTextBox.Text && user.Password == PasswordTextBox.Text)
                    {
                        foreach (var role in user.Uzer_role)
                        {
                            switch (role.ID_role) 
                            {
                                case 1:
                                    MessageBox.Show("ты педик");
                                    MainWindow mainWindow = new MainWindow();
                                    mainWindow.Show();
                                    this.Hide();
                                    return;
                                case 2:
                                    MessageBox.Show("Ты пидор");
                                    return;
                                case 3:
                                    MessageBox.Show("Ты хуеглот");
                                    return;
                                default:
                                    MessageBox.Show("Ты никто");
                                    return; 
                            }
                        }
                    }
                }
                failcounter++;
                if(failcounter > 2)
                {
                    this.Hide();
                    CaptchaWindow captchaWindow = new CaptchaWindow();
                    captchaWindow.Show();
                    failcounter = 0;
                }
            }
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RegistrationButton_Click_1(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Hide();
        }
    }
}
