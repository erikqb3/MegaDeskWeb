using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
// using MegaDeskWeb.Data;

namespace MegaDeskWeb.Models
{
  public class Material
  {
    public int MaterialId { get; set; }
    public string name { get; set; } = string.Empty;
     [DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")] public int price { get; set; }
  
    public static void Initialize(IServiceProvider serviceProvider)
    {
      using (var context = new MegaDeskWebContext(
        serviceProvider.GetRequiredService<
          DbContextOptions<MegaDeskWebContext>>()))
      {
        if (context == null || context.Material == null){
          throw new ArgumentNullException("Null MegaDeskWebContext");
        }

        if (context.Material.Any()) {
          return;
        }

        context.Material.AddRange(
          new Material
          {
            name = "Oak",
            price = 200
          },
          new Material
          {
            name = "Laminated",
            price = 100
          },
          new Material
          {
            name = "Pine",
            price = 50
          },
          new Material
          {
            name = "Rosewood",
            price = 300
          },
          new Material
          {
            name = "Veneer",
            price = 125
          },
          new Material
          {
            name = "Mahogany",
            price = 999
          }
        );
        context.SaveChanges();
      }
    }

    public int getMaterialCost(Material mObject){
      int materialCost = 0;
      Console.WriteLine(mObject.name);
      Console.WriteLine(mObject.price);


      return materialCost;
    }
  }
}