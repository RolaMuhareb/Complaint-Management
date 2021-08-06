using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;

namespace ComplaintManagement.Models
{
    public class MultiSelect : ActionNameSelectorAttribute
    {
            public string Name { set; get; }

            public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
            {
                var btn = controllerContext.Controller.ValueProvider.GetValue(Name);
                if (btn != null)
                { return true; }
                else
                { return false; }

            }
    }
}