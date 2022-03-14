using System.ComponentModel.DataAnnotations;

namespace WebAPIdemo_DPOTech.DB.Models;

public class Category
{
    public int CategoryId { get; set; }
    [StringLength(25)]
    public string CategoryName { get; set; }
    public string? CategoryDescription { get; set; }

    public ICollection<News> News { get; set; }
}