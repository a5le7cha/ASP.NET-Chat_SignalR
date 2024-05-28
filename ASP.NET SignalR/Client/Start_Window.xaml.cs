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
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для WinUser.xaml
    /// </summary>
    /// 
    public partial class WinUser : Window
    {
        //public static List<Student> listStudents = new List<Student>(); //список участников тренажера

        public WinUser()
        {
            InitializeComponent();
        }

        private void btnUserOK_Click(object sender, RoutedEventArgs e)
        {
            User user = new User(NameUser.Text, Password.Text);
            //проверка на то, что он существует в базе
            Close();
        }
    }
}