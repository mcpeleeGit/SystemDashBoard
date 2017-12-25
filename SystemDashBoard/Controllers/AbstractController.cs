using Adprint.AdminMember.Model;
using Adprint.Manager;
using Adprint.Model;
using Adprint.User.Model;
using JangBoGo.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SystemDashBoard.Controllers
{
    public partial class AbstractController : Controller
    {
        protected UserItem userItem;
        protected AdminMemberItem adminMemberItem;
        protected ErrorAction errorAction;
        protected CodeManager codeManager { set; get; }
        private DateTime ActionStartTime { set; get; }

        protected string GetControllerActionKey()
        {
            return ViewData["ControllerName"].ToString() + "." + ViewData["ActionName"].ToString();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            SpringAutowire.Autowire(this);
            InitSessionFormsAuthentication(filterContext);
        }

        private void InitSessionFormsAuthentication(ActionExecutingContext filterContext)
        {
            ActionStartTime = DateTime.Now;
            ViewData["ExecutingDate"] = DateTime.Now.ToString("yy-MM-dd hh:mm:ss");
            ViewData["ControllerName"] = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            ViewData["ActionName"] = filterContext.ActionDescriptor.ActionName;
            ViewData["ActionParam"] = filterContext.ActionDescriptor.GetParameters();
            SetUserItem();
            errorAction = new ErrorAction() { Request = Request, TempData = TempData, userItem = userItem, Session = Session };
            if (errorAction.NotLoginActionInfo() != null)
            {
                FormsAuthentication.SignOut();
            }
        }
        
        private void SetUserItem()
        {
            if (Session["user"] == null)
            {
                userItem = null;
            }
            else
            {
                userItem = Session["user"] as UserItem;
                //userItem = UserDao.FindById(userItem.Id);
            }
        }
    }
}