using System;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using project_pp.Data;
using project_pp.Utils;
using project_pp.ViewModels;

namespace project_pp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    const string ConnectionString = @"Data Source=Database.db";
    public IServiceProvider Services { get; private set; }
    public App()
    {
        Services = new ServiceCollection()
            .AddDbContext<ApplicationDbContext>(options => options.UseSqlite(ConnectionString))
            .AddSingleton<NavigationStore>()
            .AddSingleton<MainViewModel>()

            //Views
            .AddTransient<LoginViewModel>()
            .AddTransient<RegisterViewModel>()
            .AddTransient<ProjectsViewModel>()
            .AddTransient<CreateProjectViewModel>()

            //Navigation services
            .AddTransient<NavigationService<LoginViewModel>>(s => new(s.GetRequiredService<NavigationStore>(), s.GetRequiredService<LoginViewModel>))
            .AddTransient<NavigationService<RegisterViewModel>>(s => new(s.GetRequiredService<NavigationStore>(), s.GetRequiredService<RegisterViewModel>))
            .AddTransient<NavigationService<ProjectsViewModel>>(s => new(s.GetRequiredService<NavigationStore>(), s.GetRequiredService<ProjectsViewModel>))
            .AddTransient<NavigationService<CreateProjectViewModel>>(s => new(s.GetRequiredService<NavigationStore>(), s.GetRequiredService<CreateProjectViewModel>))

            .BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = new MainWindow { DataContext = Services.GetRequiredService<MainViewModel>() };
        MainWindow.Show();
        base.OnStartup(e);
    }
}
