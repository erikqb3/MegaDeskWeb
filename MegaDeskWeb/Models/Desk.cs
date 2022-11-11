using System.ComponentModel.DataAnnotations;

namespace MegaDeskWeb.Models
{
  public class Desk
  {
    public int DeskId { get; set; }
    [Required][Display(Name = "Width")] public int width { get; set; }
    [Required][Display(Name="Depth")] public int depth { get; set; }
    [Display(Name="Drawers")]public int drawerCount { get; set; }

    [Required][Display(Name="Material")] public int MaterialId { get; set; }
    [Display(Name="Rush Days")]public int RushOptionId { get; set; }

    public Material? Material { get; set; }
    public RushOption? RushOption { get; set; }

  }
}