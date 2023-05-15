using DATN_NguyenThiThuHuong.API.Helpers;
using DATN_NguyenThiThuHuong.BL.Interfaces;
using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.DL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AuthenPermissionAttribute : Attribute, IAsyncActionFilter
{
    public AuthenPermissionAttribute()
    {
    }

    public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        //Kiểm tra authen
        if (!((Authentication)context.Controller).IsOke)
        {
            var userToken = ((Authentication)context.Controller).userToken;
            if (userToken is null)
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return Task.CompletedTask;
            }
        }
        next();
        return Task.CompletedTask;
    }
    public string GetRequestBody(HttpRequest request)
    {
        var bodyStream = new StreamReader(request.Body);
        bodyStream.BaseStream.Seek(0, SeekOrigin.Begin);
        var bodyText = bodyStream.ReadToEnd();
        return bodyText;
    }
}
