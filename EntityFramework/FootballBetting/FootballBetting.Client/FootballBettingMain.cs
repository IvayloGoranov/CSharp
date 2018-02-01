using System.Linq;
using System.Data.Entity.Validation;
using System;

using FootballBetting.Data;

namespace FootballBetting.Client
{
    public class FootballBettingMain
    {
        public static void Main()
        {
            FootballBettingContext context = new FootballBettingContext();

            try
            {
                int bestCount = context.Bets.Count();
            }
            catch (DbEntityValidationException ex)
            {

                foreach (DbEntityValidationResult dbEntityValidationResult in ex.EntityValidationErrors)
                {
                    foreach (DbValidationError dbValidationError in dbEntityValidationResult.ValidationErrors)
                    {
                        Console.WriteLine(dbValidationError.ErrorMessage);
                    }
                }
            }
        }
    }
}
