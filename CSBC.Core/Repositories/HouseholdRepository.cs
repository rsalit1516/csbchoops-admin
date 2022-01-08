using CSBC.Components.Security;
using CSBC.Core.Interfaces;
using CSBC.Core.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CSBC.Core.Repositories
{
    public class HouseholdRepository : EFRepository<Household>, IHouseholdRepository
	{
		//protected CSBCDbContext DataContext { get; set; }
		//protected DbSet<Household> DbSet;

        public HouseholdRepository(DbContext context) : base(context) { }

		private string sSQL;

		private CSBC.Components.ClsGlobal sGlobal = new CSBC.Components.ClsGlobal();

        //public HouseholdRepository(CSBCDbContext dataContext)
        //{
        //    DataContext = dataContext;
        //}
		public DataTable GetRecords(int RowId, Int32 CompanyId, string sName = "", string sAddress = "", string sPhone = "", string sEmail = "")
		{
			ClsDatabase DB = new ClsDatabase();
			string sOrder = " Order By";
			try
			{
				sSQL = "SELECT top 1000 HouseId, Name, Address1, Address2, City, State, Zip, Phone, Email, SportsCard, FeeWaived FROM HOUSEHOLDS ";
				sSQL += "WHERE CompanyID =" + CompanyId;
				if (RowId > 0)
					sSQL += " AND HouseID = " + RowId;

				if (!(string.IsNullOrEmpty(sName)))
				{
					sSQL += " AND Name  like " + sGlobal.Quotes(sName + "%");
				}
				if (!(string.IsNullOrEmpty(sAddress)))
				{
					sSQL += " AND Address1 like " + sGlobal.Quotes(sAddress + "%");
				}
				if (!(string.IsNullOrEmpty(sPhone)))
				{
					sSQL += " AND Phone like " + sGlobal.Quotes(sPhone + "%");
				}
				if (!(string.IsNullOrEmpty(sEmail)))
				{
					sSQL += " AND Email like " + sGlobal.Quotes(sEmail + "%");
				}
				if (!(string.IsNullOrEmpty(sName)))
				{
					if (sOrder == " Order By")
					{
						sOrder += " Name ";
					}
					else
					{
						sOrder += ", Name ";
					}
				}

				if (!(string.IsNullOrEmpty(sAddress)))
				{
					if (sOrder == " Order By")
					{
						sOrder += " Address1 ";
					}
					else
					{
						sOrder += ", Address1 ";
					}
				}

				if (!(string.IsNullOrEmpty(sPhone)))
				{
					if (sOrder == " Order By")
					{
						sOrder += " Phone ";
					}
					else
					{
						sOrder += ", Phone ";
					}
				}

				if (!(string.IsNullOrEmpty(sEmail)))
				{
					if (sOrder == " Order By")
					{
						sOrder += " Email ";
					}
					else
					{
						sOrder += ", Email ";
					}
				}
				if (sOrder != " Order By")
					sSQL += sOrder;
				return DB.ExecuteGetSQL(sSQL);
			}
			catch (Exception ex)
			{
				throw new Exception("ClsHouseholds:GetRecords::" + ex.Message);
			}
			finally
			{
				DB = null;
			}
		}

		public IQueryable<Household> GetRecords(int CompanyId = 1, string name = "", string address = "", string phone = "", string email = "")
		{
			var result = from h in Context.Set<Household>()
						 where h.CompanyID == CompanyId
						 select h;
			if (!String.IsNullOrEmpty(name))
				result = from h in result
					where h.Name.StartsWith(name)
					orderby h.Name
					select h;
			if (!String.IsNullOrEmpty(address))
				result = from h in result
						 where h.Address1.Contains(address)
						 orderby h.Address1
						 select h;
			if (!String.IsNullOrEmpty(phone))
				result = from h in result
					where h.Phone.Contains(phone) 
					orderby h.Phone
						 select h;
			if (!String.IsNullOrEmpty(email))
				result = from h in result
						 where h.Email.Contains(email)
						 orderby  h.Email
						 select h;
			return result;
		}
		public void DELRow(long RowId, Int32 CompanyID)
		{
			ClsDatabase DB = new ClsDatabase();
			try
			{
				sSQL = "DELETE FROM Households where HouseId=" + RowId;
				sSQL += " AND CompanyID = " + CompanyID;
				DB.ExecuteUpdSQL(sSQL);
			}
			catch (Exception ex)
			{
				throw new Exception("ClsHouseholds:DELRow::" + ex.Message);
			}
			finally
			{
				DB = null;
			}
		}

		public void UpdRow(int RowId, Household household, Int32 CompanyID, Int32 iTimeZone)
		{
			ClsDatabase DB = new ClsDatabase();
			DataTable dtResults = null;
			try
			{
				sSQL = "EXEC UPDHouse ";
				sSQL += " @Name = " + dbStrField("", household.Name);
				sSQL += ", @HouseID = " + dbIntField(0, RowId);
				sSQL += ", @Address1 = " + dbStrField("", household.Address1);
				sSQL += ", @Address2 = " + dbStrField("", household.Address2);
				sSQL += ", @City = " + dbStrField("", household.City);
				sSQL += ", @Email = " + dbStrField("", household.Email);
				sSQL += ", @EmailList = " + dbBoolField(0, household.EmailList.Value);
				sSQL += ", @Guardian = " + dbIntField(0, household.Guardian.Value);
				sSQL += ", @SportsCard = " + dbStrField("", household.SportsCard);
				sSQL += ", @State = " + dbStrField("", household.State);
				sSQL += ", @Zip = " + dbStrField("", household.Zip);
				sSQL += ", @Phone = " + dbStrField("", household.Phone);
				sSQL += ", @User = " + dbStrField("", household.CreatedUser);
				sSQL += ", @CreateDate = " + sGlobal.Quo(sGlobal.TimeAdjusted(iTimeZone, DateTime.Now).ToShortDateString());
				sSQL += ", @CompanyID = " + dbIntField(0, CompanyID);

				dtResults = DB.ExecuteGetSQL(sSQL);
				household.HouseID = Int32.Parse(dtResults.Rows[0]["HouseID"].ToString());

			}
			catch (Exception ex)
			{
				throw new Exception("ClsHouseholds:UpdRow::" + ex.Message);
			}
			finally
			{
				DB = null;
			}
		}

		public DataTable GetHouseholdCart(int RowID, Int32 SeasonID)
		{
			ClsDatabase DB = new ClsDatabase();
			try
			{
				sSQL = "EXEC GetShoppingCart ";
				sSQL += " @HouseID = " + dbIntField(0, RowID);
				sSQL += ", @SeasonID = " + dbIntField(0, SeasonID);
				return DB.ExecuteGetSQL(sSQL);
			}
			catch (Exception ex)
			{
				throw new Exception("ClsHouseholds:GetHouseholdCart::" + ex.Message);
			}
			finally
			{
				DB = null;
			}
		}


		public DataTable LoadMembers(int RowID, Int32 CompanyID)
		{
			ClsDatabase DB = new ClsDatabase();
			try
			{
				sSQL = "SELECT PeopleID, (FirstName + ' ' + LastName) as Name, Birthdate, gender From People ";
				sSQL += " Where HouseId = " + dbIntField(0, RowID);
				sSQL += " AND People.CompanyID = " + dbIntField(0, CompanyID);
				sSQL += " order by FirstName";
				return DB.ExecuteGetSQL(sSQL);
			}
			catch (Exception ex)
			{
				throw new Exception("ClsHouseholds:LoadMembers::" + ex.Message);
			}
			finally
			{
				DB = null;
			}
		}

		public void UpdMember(int RowId, Int32 CompanyID, int HouseID)
		{
			ClsDatabase DB = new ClsDatabase();
			try
			{
				sSQL = "UPDATE People SET ";
				sSQL += " HouseID = " + dbIntField(0, HouseID);
				sSQL += " WHERE PeopleID = " + dbIntField(0, RowId);
				sSQL += " AND CompanyID = " + dbIntField(0, CompanyID);
				DB.ExecuteUpdSQL(sSQL);
			}
			catch (Exception ex)
			{
				throw new Exception("ClsHouseholds:UpdMember::" + ex.Message);
			}
			finally
			{
				DB = null;
			}
		}

		public void UpdUser(int RowID, Int32 CompanyID, int HouseID)
		{
			ClsDatabase DB = new ClsDatabase();
			try
			{
				sSQL = "UPDATE Users SET ";
				sSQL += " HouseID = " + dbIntField(0, HouseID);
				sSQL += " WHERE HouseID = " + dbIntField(0, RowID);
				sSQL += " AND CompanyID = " + dbIntField(0, CompanyID);
				DB.ExecuteUpdSQL(sSQL);
			}
			catch (Exception ex)
			{
				throw new Exception("ClsHouseholds:UpdUser::" + ex.Message);
			}
			finally
			{
				DB = null;
			}
		}

		public void AddEmail(int RowId, int SeasonID, int CompanyID, string email)
		{
			ClsDatabase DB = new ClsDatabase();
			try
			{
				sSQL = "INSERT INTO Emails (HouseID, CompanyID, SeasonID, EmailAddress) VALUES (" + RowId;
				sSQL += ", " + dbIntField(0, CompanyID);
				sSQL += ", " + dbStrField("", SeasonID.ToString());
				sSQL += ", " + dbStrField("", email);
				sSQL += ")";
				DB.ExecuteUpdSQL(sSQL);
			}
			catch (Exception ex)
			{
				throw new Exception("ClsHouseholds:AddEmail::" + ex.Message);
			}
			finally
			{
				DB = null;
			}
		}

		private int dbIntField(int defautValue, int FieldValue = -1)
		{
			int functionReturnValue = 0;
			if (FieldValue == -1)
			{
				functionReturnValue = defautValue;
			}
			else
			{
				functionReturnValue = FieldValue;
			}
			return functionReturnValue;
		}

		private string dbStrField(string defautValue, string FieldValue = "")
		{
			string functionReturnValue = null;
			if (string.IsNullOrEmpty(FieldValue))
			{
				functionReturnValue = sGlobal.Quo(defautValue);
			}
			else
			{
				if (string.IsNullOrEmpty(FieldValue))
				{
					functionReturnValue = "";
				}
				else
				{
					functionReturnValue = sGlobal.Quotes(FieldValue);
				}
			}
			return functionReturnValue;
		}

		private int dbBoolField(int defaultValue, bool FieldValue)
		{
			int functionReturnValue = default(Int32);
			if (FieldValue == false)
			{
				functionReturnValue = defaultValue;
			}
			else
			{
				functionReturnValue = -2;
			}
			return functionReturnValue;
		}

		private string dbDateField(string defaultValue, string FieldValue = "")
		{
			string functionReturnValue = null;
			try
			{
				DateTime fieldDate = DateTime.Parse(FieldValue);
				functionReturnValue = sGlobal.Quo(FieldValue);
			}
			catch
			{
				functionReturnValue = defaultValue;
			}

			return functionReturnValue;
		}

		public DataTable LoadEmails(int iGroupType, object p2, object p3)
		{
			throw new NotImplementedException();
		}
		#region IRepository<T> Members

		public Household Insert(Household entity)
		{
            if (entity.HouseID == 0)
            {
                entity.HouseID = Context.Set<Household>().Any() ? (Context.Set<Household>().Max(p => p.HouseID) + 1) : 1;
            }
			Context.Set<Household>().Add(entity);
			var no = Context.SaveChanges();
			return entity;
		}

		public void Delete(Household entity)
		{
            Context.Set<Household>().Remove(entity);
            Context.SaveChanges();
		}

		public IQueryable<Household> SearchFor(Expression<Func<Household, bool>> predicate)
		{
			return DbSet.Where(predicate);
		}

		public IQueryable<Household> GetAll()
		{
            return Context.Set<Household>().Select(s => s); ;
		}

		public IQueryable<Household> GetAll(int companyId)
		{
            return Context.Set<Household>().Where(s => s.CompanyID == companyId); ;
		}

		public Household GetById(int id)
		{
            return Context.Set<Household>().Find(id);
		}

		#endregion

		public IQueryable<Household> GetByName(string name)
		{
            var house = Context.Set<Household>().Where(h => h.Name.ToUpper() == name.ToUpper());
			return house;
		}


		public override void Update(Household entity)
		{
			var household = GetById(entity.HouseID);
		    Context.Entry(household).State = System.Data.Entity.EntityState.Modified;
			Context.SaveChanges();
		}

        

	}
}
