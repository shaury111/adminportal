//using new_loginsystem.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Principal;
//using System.Web;
//using System.Web.Security;

//public class UserRoleProvider : RoleProvider
//{
//    public override string ApplicationName
//    {
//        get
//        {
//            throw new NotImplementedException();
//        }

//        set
//        {
//            throw new NotImplementedException();
//        }
//    }

//    public override void AddUsersToRoles(string[] usernames, string[] roleNames)
//    {
//        throw new NotImplementedException();
//    }

//    public override void CreateRole(string roleName)
//    {
//        throw new NotImplementedException();
//    }

//    public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
//    {
//        throw new NotImplementedException();
//    }

//    public override string[] FindUsersInRole(string roleName, string usernameToMatch)
//    {
//        throw new NotImplementedException();
//    }

//    public override string[] GetAllRoles()
//    {
//        throw new NotImplementedException();
//    }

//    public override string[] GetRolesForUser(string username)
//    {
//        throw new NotImplementedException();
//    }

//    //public override string[] GetRolesForUser(string username)
//    //{
//    //    using (JobPortalEntities _Context = new JobPortalEntities())
//    //    {
//    //        string[] arr = new string[] { };

//    //       if (HttpContext.Current.User != null)
//    //        {
//    //            if (HttpContext.Current.User.Identity.IsAuthenticated)
//    //            {
//    //                if (HttpContext.Current.User.Identity is FormsIdentity)
//    //                {
//    //                    FormsIdentity id =
//    //                        (FormsIdentity)HttpContext.Current.User.Identity;
//    //                    FormsAuthenticationTicket ticket = id.Ticket;

//    //                    // Get the stored user-data, in this case, our roles
//    //                    string userData = ticket.UserData;
//    //                    //string[] roles = userData.Split(',');
//    //                    int role = -1;
//    //                    int.TryParse(userData.ToString(),out role);

//    //                   // int rolea = Convert.ToInt32(userData.Split(','));//"1_admin_123_1"
//    //                    var userRoles = _Context.tblroles.Where(x => x.fldroleid == role).Select(x => x.fldrole).ToArray();
//    //                    _Context.Dispose();
//    //                    arr = userRoles;
//    //                    HttpContext.Current.User = new GenericPrincipal(id, userRoles);
//    //                }
//    //            }
//    //        }



//    //        return arr;
//    //    }
//    //}

//    public override string[] GetUsersInRole(string roleName)
//    {
//        throw new NotImplementedException();
//    }

//    public override bool IsUserInRole(string username, string roleName)
//    {
//        throw new NotImplementedException();
//    }

//    public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
//    {
//        throw new NotImplementedException();
//    }

//    public override bool RoleExists(string roleName)
//    {
//        throw new NotImplementedException();
//    }
//}
