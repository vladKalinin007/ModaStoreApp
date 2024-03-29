namespace ModaStore.Domain.Specifications;

public class ProductSpecParams
{
    private const int MaxPageSize = 50;
    public int PageIndex { get; set; } = 1;
    
    private int _pageSize = 9;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }

    public string? BrandId { get; set; }
    public string? Brand { get; set; }
    public string? TypeId { get; set; } 
    public string? Type { get; set; }
    public string? Sort { get; set; }
    public string? CategoryId { get; set; }
    public string? Category { get; set; }
    public string? ColorId { get; set; }
    public string? SizeId { get; set; }
    public string? Tag { get; set; }
    public string? Material { get; set; }
    public string? Style { get; set; }
    public string? Pattern { get; set; }
    public string? Season { get; set; }
    public bool? IsBestSeller { get; set; }
    public bool? IsNew { get; set; }
    public bool? IsOnSale { get; set;  }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    

    private string? _search;
    public string? Search
    {
        get => _search;
        set => _search = value.ToLower();
    }
}