using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalTour.Services.Extensions
{
    public static class ServiceExtensions
    {
        public static IReadOnlyList<Developer> ToReadOnly(this IEnumerable<Developer> developers)
        {
            List<Developer> list = new List<Developer>();
            foreach (var item in developers)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
