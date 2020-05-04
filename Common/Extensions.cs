using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MeetApp.Common
{
    public static class Extensions
    {
        public static string ToValidString(this string query)
        {
            return query.Replace("'", "''");
        }
    }
}
