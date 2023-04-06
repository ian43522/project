using System.Linq;
using System.Windows.Input;
using project_pp.Commands;
using project_pp.Data;
using project_pp.Utils;

namespace project_pp.ViewModels;
public class LoginViewModel : ViewModelBase
{
    private readonly ApplicationDbContext _context;
    private readonly NavigationService<ProjectsViewModel> _navigationProjects;
    private readonly NavigationService<RegisterViewModel> _navigationRegister;

    public LoginViewModel(
        ApplicationDbContext context,
        NavigationService<ProjectsViewModel> navigationProjects,
        NavigationService<RegisterViewModel> navigationRegister)
    {
        _context = context;
        _navigationProjects = navigationProjects;
        _navigationRegister = navigationRegister;
    }

    public string Login { get; set; } = "";
    public string Password { get; set; } = "";

    public ICommand LoginCommand => new Command(arg =>
    {
        if (_context.Users.Any(user => user.Login == Login && user.PasswordHash == Password)) /* TODO: use password hash */
        {
            _navigationProjects.Navigate();
        }
        else
        {
            /* TODO: notify user about error */
        }
    });
    public ICommand ToRegisterCommand => new Command(arg =>
    {
        _navigationRegister.Navigate();
    });
}
