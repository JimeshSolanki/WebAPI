﻿using System;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class BaseController : ApiController
    {
        public static Response BuildResponse(int Status, int Count, string Message, Object Object, Exception e)
        {
            return new Response
            {
                Status = Status,
                Count = Count,
                Message = Message ?? e.ToString() ?? string.Empty,
                Obj = Object ?? string.Empty
            };
        }

        public static bool IsValidId(string str)
        {
            return isStr(str) && Convert.ToInt32(str) > 0;
        }

        public static bool isStr(string str)
        {
            return !String.IsNullOrEmpty(str) ? true : false;
        }

        public string ToStr(string str)
        {
            return isStr(str) ? str : string.Empty;
        }

        public static int ToInt(string str)
        {
            return isStr(str) ? Convert.ToInt32(str) : 0;
        }

        public static int ToInt(int? number)
        {
            return number != null ? Convert.ToInt32(number) : 0;
        }

        public static Decimal ToDecimal(string str)
        {
            return isStr(str) ? Convert.ToDecimal(str) : 0;
        }

        public static Decimal ToDecimal(decimal? number)
        {
            return number != null ? Convert.ToDecimal(number) : 0;
        }
    }
}
