using Domain.IRepositories;
using Domain.Models;

namespace Application.Services;

public class TestService : ITestService
{
    
    private readonly ITestRepository _testRepository;

    public TestService(ITestRepository testRepository)
    {
        _testRepository = testRepository;
    }
    
    public void Create(Test test)
    {
        if (test == default) 
            throw new ArgumentNullException(nameof(test));
        
        _testRepository.Create(test);
    }

    public Test Get(Guid id)
    {
        if (id == default) 
            throw new ArgumentNullException(nameof(id));
        
        return _testRepository.Get(id);
    }

    public List<Test> GetAll()
    {
        return _testRepository.GetAll();
    }

    public void Delete(Guid id)
    {
        if (id == default) 
            throw new ArgumentNullException(nameof(id));
        
        _testRepository.Delete(id);
    }

    public void Update(Test test)
    {
        if (test == default) 
            throw new ArgumentNullException(nameof(test));
        
        _testRepository.Update(test);
    }
}