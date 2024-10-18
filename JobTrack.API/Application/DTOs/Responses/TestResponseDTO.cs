namespace Application.DTOs.Responses;

public class TestResponseDTO
{
    public Guid Id { get; set; }
    
    public string Category { get; set; }
    
    public string  Question { get; set; }
    
    public string Variant1 { get; set; }
    
    public string Variant2 { get; set; }
    
    public string Variant3 { get; set; }
    
    public string Variant4 { get; set; }
    
    public int Answer { get; set; }
}