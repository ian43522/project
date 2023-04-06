using System.Windows;
using System.Windows.Controls;

namespace project_pp.Views;
/// <summary>
/// Логика взаимодействия для RegisterView.xaml
/// </summary>
public partial class RegisterView : UserControl
{
    public RegisterView()
    {
        InitializeComponent();
    }
    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (this.DataContext != null)
        { ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password; }
    }
}
