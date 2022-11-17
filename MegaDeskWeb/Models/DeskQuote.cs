using System.ComponentModel.DataAnnotations;

namespace MegaDeskWeb.Models
{
  public class DeskQuote
  {
    public int DeskQuoteId { get; set; }
    
    [Required][Display(Name="Name")] public string customerName { get; set; } = string.Empty;
    [Required][Display(Name="Contact Method")] public string contactMethod { get; set; } = string.Empty;
    [Required][Display(Name="Contact Info")] public string contactInfo { get; set; } = string.Empty;
    [Required][Display(Name="Order Date")][DataType(DataType.Date)] public DateTime startDate { get; set; } = DateTime.Now;
    [Required][Display(Name="Finish Date")][DataType(DataType.Date)]public DateTime finishDate { get; set; }
    [Required][Display(Name="Total")] public float quoteTotalPrice { get; set; } 
    
    public int DeskId { get; set; }

    public Desk? Desk { get; set; }

    




  }
}