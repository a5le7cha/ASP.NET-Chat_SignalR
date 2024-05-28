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
using Microsoft.AspNetCore.SignalR.Client;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HubConnection hubConnection;
        public MainWindow()
        {
            WinUser winUser = new WinUser();
            winUser.ShowDialog();
            InitializeComponent();

            hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7064/chat")
                .Build();

            hubConnection.On<string, string>("Receive", (user, Message) =>
            {
                Dispatcher.Invoke(() =>
                {
                    var newMessage = $"{user}: {Message}";
                    user_mes.Items.Insert(0, newMessage);
                });
            });
        }

        private async void btnUserOK_Click(object sender, RoutedEventArgs e)
        {
            //добавим данные на экран
            //user_mes.Items.Add(textBox.Text);

            try
            {
                // отправка сообщения
                await hubConnection.InvokeAsync("Send", textBox.Text);
            }
            catch (Exception ex)
            {
                user_mes.Items.Add(ex.Message);
            }

            textBox.Clear();
        }

        // обработчик загрузки окна
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // подключемся к хабу
                await hubConnection.StartAsync();
                user_mes.Items.Add("Вы вошли в чат");
                btnUserOK.IsEnabled = true;
            }
            catch (Exception ex)
            {
                user_mes.Items.Add(ex.Message);
            }
        }
    }
}