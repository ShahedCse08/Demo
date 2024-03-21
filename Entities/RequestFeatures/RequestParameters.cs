
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        public string OrderBy { get; set; }
        public string Fields { get; set; }
    }
    public class EmployeeParameters : RequestParameters
    {

        public EmployeeParameters()
        {
            OrderBy = "name";
        }

        public uint MinAge { get; set; }
        public uint MaxAge { get; set; } = int.MaxValue;
        public bool ValidAgeRange => MaxAge > MinAge;

        public string SearchTerm { get; set; }


    }


    public class MenuParameters : RequestParameters
    {

        public MenuParameters()
        {
            OrderBy = "price";
        }

     
        public Guid VendorId { get; set; }
        public Guid MealTypeId { get; set; }
        public Guid DayId { get; set; }

        public string SearchTerm { get; set; }


    }

    public class OrderParameters : RequestParameters
    {

        public OrderParameters()
        {
            OrderBy = "price";
        }


        public Guid VendorId { get; set; }

        public Guid CustomerId{ get; set; }
        public Guid MealTypeId { get; set; }
        public Guid DayId { get; set; }
        public Guid OrderStateId { get; set; }
        public string SearchTerm { get; set; }


    }

}
