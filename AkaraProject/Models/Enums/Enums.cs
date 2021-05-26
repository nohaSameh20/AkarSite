using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AkaraProject.Models
{
    public enum BuildingStatus
    {
        ForSale=1,
        ForRent=2,
        Close=3
    }
    public enum AdvertisingStatuse
    {
        Cancelled=1,
        Pending=2,
        Approved=3
    }
    public enum UnitType
    {
        Villa=1,
        Property=2,
        Roof=3
    }
    public enum AdertisingFilterBy
    {
        All=1,
        Sale=2,
        Rent=3
    }
}