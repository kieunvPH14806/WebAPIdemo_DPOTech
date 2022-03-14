using System.ComponentModel.DataAnnotations;

namespace WebAPIdemo_DPOTech.DB.Models;

public class News
{
    public int NewsId { get; set; }
    public int CategoryId { get; set; }
    [StringLength(200)]
    public string NewsName { get; set; }
    public int? NewsContent { get; set; }
    public Category Category { get; set; }
    
}