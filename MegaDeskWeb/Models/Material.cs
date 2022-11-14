using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
// using MegaDeskWeb.Data;

namespace MegaDeskWeb.Models
{
  public class Material
  {
    public int MaterialId { get; set; }
    public string name { get; set; } = string.Empty;
    public decimal price { get; set; }
  
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
            price = 200M
          },
          new Material
          {
            name = "Laminated",
            price = 100M
          },
          new Material
          {
            name = "Pine",
            price = 50M
          },
          new Material
          {
            name = "Rosewood",
            price = 300M
          },
          new Material
          {
            name = "Veneer",
            price = 125M
          },
          new Material
          {
            name = "Mahogany",
            price = 999M
          }
        );
        context.SaveChanges();
      }
    }

  }
}