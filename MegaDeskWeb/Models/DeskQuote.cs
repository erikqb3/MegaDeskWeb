using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaDeskWeb.Models
{
  public class DeskQuote
  {
    public int DeskQuoteId { get; set; }
    
    [Display(Name="Name")] public string customerName { get; set; } = string.Empty;
    [Display(Name="Contact Method")] public string contactMethod { get; set; } = string.Empty;
    [Display(Name="Contact Info")] public string contactInfo { get; set; } = string.Empty;
    [Display(Name="Order Date")][DataType(DataType.Date)] public DateTime startDate { get; set; } = DateTime.Now;
    [Display(Name="Rush Days")]public int RushOptionId { get; set; }
    [Display(Name="Finish Date")][DataType(DataType.Date)]public DateTime finishDate { get; set; }
    [DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")][Display(Name="Total")] public float quoteTotalPrice { get; set; } = 2000; //basePrice
    
    public int DeskId { get; set; }

    public Desk? Desk { get; set; }
    public RushOption? RushOption { get; set; }

    




  }
}