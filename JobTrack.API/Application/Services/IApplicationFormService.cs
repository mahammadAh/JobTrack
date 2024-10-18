using Domain.Models;

namespace Application.Services;

public interface IApplicationFormService
{
    void Create(ApplicationForm applicationForm);
    
    ApplicationForm Get(Guid id);
    
    List<ApplicationForm> GetAll();
    
}