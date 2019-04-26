using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Common
{
    public class RoleProviderCustome: AuthorizeAttribute
    {
        public string RoleName { set; get; }
        private const string loginsession = "loginsession";
        LaptopShopDbContext db = new LaptopShopDbContext();

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = (user)HttpContext.Current.Session[loginsession];
            if (session == null)
            {
                return false;
            }

            var roleName = db.Roles.SingleOrDefault(p => p.Id == session.RoleID);
            if(roleName.RoleName == RoleName)
            {
                return true;
            }
            else
            {
                return false;
            }
            //List<string> privilegeLevels = this.GetCredentialByLoggedInUser(session.username); // Call another method to get rights of the user from DB

            //if (privilegeLevels.Contains(this.RoleName) || session.GroupID == CommonConstants.ADMIN_GROUP)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Areas/Admin/Views/Shared/401.cshtml"
            };
        }
        //private List<string> GetCredentialByLoggedInUser(string userName)
        //{
        //    var credentials = (List<string>)HttpContext.Current.Session[loginsession];
        //    return credentials;
        //}
    }
}