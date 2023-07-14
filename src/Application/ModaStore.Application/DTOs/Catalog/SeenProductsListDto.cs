namespace ModaStore.Application.DTOs.Catalog;

public class SeenProductsListDto
{
    public SeenProductsListDto()
    {
        SeenProducts = new List<SeenProductDto>();
    }
    
    public string Id { get; set; }
    
    public List<SeenProductDto> SeenProducts { get; set; }
}