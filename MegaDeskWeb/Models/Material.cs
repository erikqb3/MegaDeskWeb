using System.ComponentModel.DataAnnotations;

namespace MegaDeskWeb.Models
{
  public class Material
  {
    public int MaterialId { get; set; }
    public int name { get; set; }
    public int price { get; set; }
  }
}