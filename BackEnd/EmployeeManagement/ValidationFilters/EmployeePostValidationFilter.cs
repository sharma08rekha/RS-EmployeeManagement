using Common;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EmployeeManagement.ValidationFilters
{
    public class EmployeePostValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            try
            {
                var jsonPosted = (EmployeeRequestModel)actionContext.ActionArguments["employeeRequestUIModel"];
                ValidateValues(jsonPosted);
            }
            catch (APIException ex)
            {
                actionContext.Result = new BadRequestObjectResult(new JsonResult(new { ex.AdditionalData }));
            }
        }

        private void ValidateValues(EmployeeRequestModel jsonPosted)
        {
            if (jsonPosted.FullName == null || string.IsNullOrEmpty(jsonPosted.FullName.ToString()))
                throw new APIException(HttpStatusCode.BadRequest, "Invalid fullname");

            if (jsonPosted.Position == 0 || string.IsNullOrEmpty(jsonPosted.Position.ToString()) || !IsValidInteger(jsonPosted.Position.ToString()))
                throw new APIException(HttpStatusCode.BadRequest, "Invalid position");

            if (jsonPosted.Address == null || string.IsNullOrEmpty(jsonPosted.Address.ToString()))
                throw new APIException(HttpStatusCode.BadRequest, "Invalid address");
        }

        private bool IsValidInteger(string value)
        {
            if (string.IsNullOrEmpty(value.Trim()))
                return false;

            int outValue;
            return int.TryParse(value, out outValue);
        }
    }
}
