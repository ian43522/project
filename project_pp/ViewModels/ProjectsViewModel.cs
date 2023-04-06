using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using project_pp.Commands;
using project_pp.Data;
using project_pp.Model;
using project_pp.Utils;

namespace project_pp.ViewModels;
public class ProjectsViewModel : ViewModelBase
{
    private readonly ApplicationDbContext _context;
    private readonly NavigationService<CreateProjectViewModel> _navigationCreateProject;
    private string _searchText = "";

    public ProjectsViewModel(ApplicationDbContext context, NavigationService<CreateProjectViewModel> navigationCreateProject)
    {
        _context = context;
        _navigationCreateProject = navigationCreateProject;
    }
    public string SearchText
    {
        get => _searchText;
        set
        {
            _searchText = value;
            RaisePropertyChanged(nameof(Projects));
        }
    }
    public IEnumerable<Project> Projects => _context.Projects
        .Where(proj => proj.Name.Contains(SearchText) | proj.Description.Contains(SearchText))
        .ToArray();
    public ICommand CreateProjectCommand => new Command(arg =>
    {
        _navigationCreateProject.Navigate();
    });
    public ICommand SearchCommand => new Command(arg =>
    {

    });
}
