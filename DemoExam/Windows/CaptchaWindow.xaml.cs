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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DemoExam.Windows
{
    /// <summary>
    /// Логика взаимодействия для CaptchaWindow.xaml
    /// </summary>
    public partial class CaptchaWindow : Window
    {
        public CaptchaWindow()
        {
            InitializeComponent();
            CapthcaOutput.CreateCaptcha(EasyCaptcha.Wpf.Captcha.LetterOption.Alphanumeric, 5);
        }

        private void InputCapthca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (InputCapthca.Text != CapthcaOutput.CaptchaText)
                {
                    MessageBox.Show("Капча не верна");
                    CapthcaOutput.CreateCaptcha(EasyCaptcha.Wpf.Captcha.LetterOption.Alphanumeric, 5);
                    return;
                }
                else
                {
                    this.Hide();
                    AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                    authorizationWindow.Show();
                }
            }
        }

        private void RefreshCapthca_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            CapthcaOutput.CreateCaptcha(EasyCaptcha.Wpf.Captcha.LetterOption.Alphanumeric, 7);
        }
    }
}
