using Domain.IRepositories;
using Domain.Models;

namespace Application.Services;

public class ApplicationFormService : IApplicationFormService
{
    
    private readonly IApplicationFormRepository _applicationFormRepository;

    public ApplicationFormService(IApplicationFormRepository applicationFormRepository)
    {
        _applicationFormRepository = applicationFormRepository;
    }

    public void Create(ApplicationForm applicationForm)
    {
        if (applicationForm == default) 
            throw new ArgumentNullException(nameof(applicationForm));
        
        _applicationFormRepository.Create(applicationForm);
    }

    public ApplicationForm Get(Guid id)
    {
        if (id == default) 
            throw new ArgumentNullException(nameof(id));
        
        return _applicationFormRepository.Get(id);
    }

    public List<ApplicationForm> GetAll()
    {
        return _applicationFormRepository.GetAll();
    }
}