using System.ComponentModel.DataAnnotations;

namespace MegaDeskWeb.Models
{
  public class RushOption
  {
    public int RushOptionId { get; set; }
    public int days { get; set; }
    public int calcPrice { get; set; }    
  }
}