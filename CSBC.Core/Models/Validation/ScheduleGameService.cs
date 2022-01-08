using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSBC.Core.Models;
using CSBC.Core.Repositories;
using CSBC.Core.Interfaces;
using CSBC.Core.Data;

namespace CSBC.Core.Models.Validation
{
    public class ScheduleGameService : IScheduleGameService
    {
        private IValidationDictionary _validationDictionary;
        private IScheduleGameRepository _repository;

        public ScheduleGameService(IValidationDictionary validationDictionary, IScheduleGameRepository repository)
        {
            _validationDictionary = validationDictionary;
            _repository = repository;
        }

        public ScheduleGameService(IValidationDictionary validationDictionary)
            : this(validationDictionary, new ScheduleGameRepository(new CSBCDbContext()))
        {

        }

        public bool ValidateScheduleGame(ScheduleGame scheduleGameToValidate)
        {

            if (scheduleGameToValidate.ScheduleNumber == 0)
                _validationDictionary.AddError("ScheduleNumber", "Schedule Number must be greater than 0.");

            if (scheduleGameToValidate.GameNumber ==0)
                _validationDictionary.AddError("GameNumber", "Game Number must be greater than 0.");
            //if (scheduleGameToValidate.Phone.Length > 0 && !Regex.IsMatch(scheduleGameToValidate.Phone, @"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"))
            //    _validationDictionary.AddError("Phone", "Invalid phone number.");
            //if (scheduleGameToValidate.Email.Length > 0 && !Regex.IsMatch(scheduleGameToValidate.Email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            //    _validationDictionary.AddError("Email", "Invalid email address.");
            return _validationDictionary.IsValid;
        }
        #region IScheduleGameService Members

        public bool CreateScheduleGame(ScheduleGame scheduleGameToCreate)
        {
            // Validation logic
            if (!ValidateScheduleGame(scheduleGameToCreate))
                return false;

            // Database logic
            try
            {
                _repository.Insert(scheduleGameToCreate);
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion


        
    }
}
