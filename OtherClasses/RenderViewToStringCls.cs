using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public static class RenderViewToStringCls
{
    public static string RenderViewToString(this Controller controller, string viewName, object model)
    {
        controller.ViewData.Model = model;
        try
        {
            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindView(controller.ControllerContext, viewName, null);
                ViewContext viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(controller.ControllerContext, viewResult.View);

                return sw.ToString();
            }
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
    }

    #region How to Use
    //// Get your Model Object
    //var model = vendors_ViewModels;

    //var output = this.RenderViewToString("~/Views/Admin/VendorRecords.cshtml", model); 
    #endregion
}