namespace project_pp.Model;
public class User : DbEntity
{
    public string Login { get; set; }
    public string PasswordHash { get; set; }
}
