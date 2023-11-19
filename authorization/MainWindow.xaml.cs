using authorization.Windows;
using System.Linq;
using System.Windows;

namespace authorization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.currentUser = App.DB.User.Where(users => users.Login == tbLogin.Text &&
                users.Password == tbPassword.Text).First<User>();
                if (App.currentUser.Role.Role1 == "Администратор")
                {
                    WindowAdmin wa = new WindowAdmin();
                    Visibility = Visibility.Hidden;
                    wa.ShowDialog();
                    Visibility = Visibility.Visible;
                }
                if (App.currentUser.Role.Role1 == "Менеджер")
                {
                    WindowAdmin wm = new WindowAdmin();
                    wm.btnAddProduct.Visibility = Visibility.Hidden;
                    wm.btnEditProduct.Visibility = Visibility.Hidden;
                    wm.btnDelete.Visibility = Visibility.Hidden;
                    Visibility = Visibility.Hidden;
                    wm.ShowDialog();
                    Visibility = Visibility.Visible;
                }
                if (App.currentUser.Role.Role1 == "Клиент")
                {
                    WindowAdmin wc = new WindowAdmin();
                    wc.btnAddProduct.Visibility = Visibility.Hidden;
                    wc.btnEditProduct.Visibility = Visibility.Hidden;
                    wc.btnDelete.Visibility = Visibility.Hidden;
                    Visibility = Visibility.Hidden;
                    wc.ShowDialog();
                    Visibility = Visibility.Visible;
                }
                tbLogin.Text = "";
                tbPassword.Text = "";              
            }
            catch { MessageBox.Show("Неверный логин или пароль"); }
        }
        private void btnEnterGuest_Click(object sender, RoutedEventArgs e)
        {
            WindowAdmin wc = new WindowAdmin();
            wc.btnAddProduct.Visibility = Visibility.Hidden;
            wc.btnEditProduct.Visibility = Visibility.Hidden;
            wc.btnDelete.Visibility = Visibility.Hidden;
            Visibility = Visibility.Hidden;
            wc.ShowDialog();
            Visibility = Visibility.Visible;
        }
    }
}