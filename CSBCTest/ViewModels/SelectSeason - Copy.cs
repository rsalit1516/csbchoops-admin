using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;
using CSBC.Core.Models;
using CSBC.Components;

namespace CSBC.Admin.Web.ViewModels
{
    public class SelectSeasonVM
    {
        public List<Season> Seasons { get; set; }
        [ScaffoldColumn(false)]
        public int SeasonID { get; set; }
        [MaxLength(20)]
        [Display(Name="Season")]
        public string Sea_Desc { get; set; }
        [Display(Name = "From Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> FromDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "From Date")]
        public Nullable<System.DateTime> ToDate { get; set; }
        [Display(Name = "Current")]
        [MaxLength(20)]
        public Nullable<bool> CurrentSeason { get; set; }
        [Display(Name = "Current Schedule")]
        public Nullable<bool> CurrentSchedule { get; set; }
        [Display(Name = "Cur Signups")]
        public Nullable<bool> CurrentSignUps { get; set; }
        /*[Display(Name = "Sign up Date")]
        public Nullable<System.DateTime> SignUpsDate { get; set; }
        [Display(Name = "Sign up End")]
        public Nullable<System.DateTime> SignUpsEND { get; set; }
        */
        public SelectSeasonVM()
        {
            //Seasons = seasons;
        }

        public List<SelectSeasonVM> GetRecords(int companyId)
        {
            //var oSeasons = new CSBC.Components.Season.ClsSeasons();
            //DataTable rsData = new DataTable("Seasons");
            var rep = new SeasonRepository(new Core.Data.CSBCDbContext());
            List<Season> seasons = rep.GetSeasons(companyId);
            List<SelectSeasonVM> seasonVm = new List<SelectSeasonVM>();
            foreach(Season s in seasons)
            {
                var season = new SelectSeasonVM
                {
                    SeasonID = s.SeasonID,
                    Sea_Desc = s.Sea_Desc,
                    FromDate = s.FromDate,
                    ToDate = s.ToDate,
                    CurrentSeason = s.CurrentSeason,
                    CurrentSchedule = s.CurrentSchedule,
                    CurrentSignUps = s.CurrentSignUps
                };
                seasonVm.Add(season);
            }
            //rsData = oSeasons.GetRecords(companyId);
            return seasonVm;
        }
    }
}