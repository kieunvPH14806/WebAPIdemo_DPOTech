using System.ComponentModel.DataAnnotations;

namespace WebAPIdemo_DPOTech.DB.Models;

public class Category
{
    public Guid CategoryId { get; set; }
    [StringLength(25)]
    public string CategoryName { get; set; }
    [StringLength(200)]
    public string? CategoryDescription { get; set; }
    public bool CategoryStatus { get; set; }
    public ICollection<News> News { get; set; }
}