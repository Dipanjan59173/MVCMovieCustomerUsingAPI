using MovieCustomerWithAuthMVC_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieCustomerWithAuthMVC_app.Controllers.Api
{
    
    public class MembershipController : ApiController
    {
        private ApplicationDbContext _context;
        public MembershipController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<MembershipType> GetMembershipType()
        {
            var memberships = _context.MembershipTypes.ToList();
            return memberships;
            
        }

    }
}
