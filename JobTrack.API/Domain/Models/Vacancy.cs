using System.Runtime.InteropServices.JavaScript;

namespace Domain.Models;

public class Vacancy : BaseModel
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public DateOnly Deadline { get; set; }
    
    public bool Status { get; set; }
}