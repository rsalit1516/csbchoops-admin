using System;

namespace CSBC.Admin.Web.ViewModels
{
    public class DraftListVM
    {
        string DraftNumber { get; set; }
        string Rating { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
        DateTime BirthDate { get; set; }
        string Phone { get; set; }
        string Grade { get; set; }
        string DraftNotes { get; set; }
        Decimal Balance {get; set;}
        
        //public List<SeasonPlayer> GetPLayers(int division)
        //{
        //    using (var db = new CSBCDbContext())
        //    {
        //        var repo = new PlayerRepository(db);
        //        var players = repo.GetDivisionPlayers(757);
        //    }
        //}
    }
}