using System;
using System.Linq;
using System.Data.Entity;
using System.Diagnostics;

namespace Event_Attendees_Tracker_DAL.DBQueries
{
    public class Roles
    {
        static Event_Attendees_Tracker_DAL.Database_Context.EAT_DBContext _eatDBContext = Event_Attendees_Tracker_DAL.Instances.DBInstance.getDBInstance();

        public static string FetchUserRoles(int UserID)
        {
            try
            {
                //TODO:
                //When Drop down in UI will add make request based on the requested role
                //&& role.Master_DBRoles.ID == roleID
                var responseRoles = _eatDBContext.UserMappedRoles
                    .Include(role => role.Master_DBRoles)
                    .Where(role => role.UserDetails.ID == UserID)
                    .ToList();

                return responseRoles[0].Master_DBRoles.RoleName;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
