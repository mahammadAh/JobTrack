namespace Domain.Models;

public class ApplicationForm : BaseModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}