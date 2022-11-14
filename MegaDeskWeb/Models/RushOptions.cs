using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MegaDeskWeb.Models
{
  public class RushOption
  {
    public int RushOptionId { get; set; }
    public int days { get; set; }
    public int basePrice { get; set; }
    public int modifier { get; set; } 

    public static void RushOptionSeed(IServiceProvider serviceProvider) 
    {
      using (var context = new MegaDeskWebContext(
        serviceProvider.GetRequiredService<
          DbContextOptions<MegaDeskWebContext>>()))
          {
            if (context == null || context.RushOption == null){
              throw new ArgumentNullException("Null MegaDeskWebContext");
            }
            if (context.RushOption.Any()){
              return;
            }

            context.RushOption.AddRange(
              new RushOption{
                days = 3,
                basePrice = 60,
                modifier = 10
              },
              new RushOption{
                days = 5,
                basePrice = 40,
                modifier = 10
              },
              new RushOption{
                days = 7,
                basePrice = 30,
                modifier = 5
              }
            );
            context.SaveChanges();
          }
    }
  }

}