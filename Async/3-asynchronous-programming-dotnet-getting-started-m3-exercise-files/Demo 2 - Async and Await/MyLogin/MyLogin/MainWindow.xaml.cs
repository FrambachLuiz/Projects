using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MyLogin
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoginButton.IsEnabled = false;
                BusyIndicator.Visibility = Visibility.Visible;

                var result = await LoginAsync();

                LoginButton.Content = result;

                LoginButton.IsEnabled = true;
                BusyIndicator.Visibility = Visibility.Hidden;
            }
            catch (Exception)
            {
                LoginButton.Content = "Internal Error!";
            }
        }

        private async Task<string> LoginAsync()
        {
            try
            {
                var loginTask = Task.Run(() => {

                    Thread.Sleep(2000);

                    return "Login Successful!";
                });
                
                var logTask = Task.Delay(2000); // Log the login
                
                var purchaseTask = Task.Delay(1000); // Fetch purchases

                await Task.WhenAll(loginTask, logTask, purchaseTask);
                
                return loginTask.Result;
            }
            catch (Exception)
            {
                return "Login failed!";
            }
        }
    }
}
