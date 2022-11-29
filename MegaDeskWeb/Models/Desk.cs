using System.ComponentModel.DataAnnotations;

namespace MegaDeskWeb.Models
{
  public class Desk
  {
    public int DeskId { get; set; }
    [Range(24,96)][Required][Display(Name = "Width (in.)")] public int width { get; set; }
    [Range(12,48)][Required][Display(Name="Depth (in.)")] public int depth { get; set; }
    [Range(0,7)][Display(Name="Drawers")]public int drawerCount { get; set; }
 

    [Required][Display(Name="Material")] public int MaterialId { get; set; }

    public Material? Material { get; set; }


    public int getSquareIn(int iDepth, int iWidth){
      int sqrIn_area = iDepth * iWidth;
      return sqrIn_area;
    }
    
    public int getAreaCost(int inputDepth, int inputWidth){
      int sqrIn_area = this.getSquareIn(inputDepth, inputWidth);
      int additionalCost = 0;
      if (sqrIn_area > 1000){
        additionalCost = sqrIn_area - 1000;
      }
      return additionalCost;
    }

    public int getDrawerCost(int drawerCount){
      int drawerCost = 0;
      if (drawerCount != 0 ){
        drawerCost = drawerCount*50;
      }
      return drawerCost;
      
    }
  }
}