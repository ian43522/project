using System.Windows.Input;
using project_pp.Commands;
using project_pp.Data;
using project_pp.Model;
using project_pp.Utils;

namespace project_pp.ViewModels;
public class RegisterViewModel : ViewModelBase
{
    private readonly ApplicationDbContext _context;
    private readonly NavigationService<LoginViewModel> _navigationLogin;

    public RegisterViewModel(
        ApplicationDbContext context,
        NavigationService<LoginViewModel> navigationLogin)
    {
        _context = context;
        _navigationLogin = navigationLogin;
    }
    public string Login { get; set; } = "";
    public string Password { get; set; } = "";
    public ICommand RegisterCommand => new Command(arg =>
    {
        if (string.IsNullOrWhiteSpace(Login) | string.IsNullOrWhiteSpace(Password))
        {
            /* TODO: notify user about error */
            return;
        }
        _context.Users.Add(new User { Login = Login, PasswordHash = Password }); /* TODO: use password hasher */
        _context.SaveChanges();
        /* TODO: notify user about success */
        _navigationLogin.Navigate();
    });
    public ICommand BackToLoginCommand => new Command(arg =>
    {
        _navigationLogin.Navigate();
    });
}
