using Domain.Models;

namespace Application.Services;

public interface ITestService
{
    void Create(Test test);
    
    Test Get(Guid id);
    
    List<Test> GetAll();
    
    void Delete(Guid id);
    
    void Update(Test test);
}