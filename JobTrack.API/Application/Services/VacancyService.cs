using Domain.IRepositories;
using Domain.Models;

namespace Application.Services;

public class VacancyService : IVacancyService
{
    
    private readonly IVacancyRepository _vacancyRepository;

    public VacancyService(IVacancyRepository vacancyRepository)
    {
        _vacancyRepository = vacancyRepository;
    }
    
    public void Create(Vacancy vacancy)
    {
        if (vacancy == default) 
            throw new ArgumentNullException(nameof(vacancy));
        
        _vacancyRepository.Create(vacancy);
    }

    public Vacancy Get(Guid id)
    {
        if (id == default) 
            throw new ArgumentNullException(nameof(id));
        
        return _vacancyRepository.Get(id);
    }

    public List<Vacancy> GetAll()
    {
        return _vacancyRepository.GetAll();
    }

    public void Delete(Guid id)
    {
        if (id == default) 
        throw new ArgumentNullException(nameof(id));
        
        _vacancyRepository.Delete(id);
    }

    public void Update(Vacancy vacancy)
    {
        if (vacancy == default) 
            throw new ArgumentNullException(nameof(vacancy));
        
        _vacancyRepository.Update(vacancy);
    }
}