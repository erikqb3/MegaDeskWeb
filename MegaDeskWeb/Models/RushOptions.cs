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

    public Desk? Desk { get; set; }

    // public int getExtraCost(){
    //   int deskArea = this.Desk.getSquareIn();
    //   int extraCost = 0;
    //   return extraCost;
    // }

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
              },
              new RushOption{
                days = 14,
                basePrice = 0,
                modifier = 0
              }
            );
            context.SaveChanges();
          }
    }
  }

}