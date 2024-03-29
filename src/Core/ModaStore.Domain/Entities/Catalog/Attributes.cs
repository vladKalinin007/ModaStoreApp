using ModaStore.Domain.Entities.Common;

namespace ModaStore.Domain.Entities.Catalog;

public class Attributes : BaseEntity
{
    public string Color { get; set; }
    public string Size { get; set; }    
    public string Season { get; set; }
    public string Material { get; set; }
    public string Style { get; set; }
    public string Pattern { get; set; }
    public string Occasion { get; set; }
    public string Sleeve { get; set; }
    public string Neckline { get; set; }
    public string DressLength { get; set; }
    public string Waistline { get; set; }
    public string Silhouette { get; set; }
    public string Decoration { get; set; }
    public string ClosureType { get; set; }
    public string PantClosureType { get; set; }
    public string PantLength { get; set; }
    public string PantStyle { get; set; }
    public string FitType { get; set; }
    
}