using Domain.Models;

namespace Application.Services;

public interface IVacancyService
{
    void Create(Vacancy vacancy);
    
    Vacancy Get(Guid id);
    
    List<Vacancy> GetAll();
    
    void Delete(Guid id);
    
    void Update(Vacancy vacancy);
}