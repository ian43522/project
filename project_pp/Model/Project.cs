using System;

namespace project_pp.Model;

public class Project : DbEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Budget { get; set; }
}
