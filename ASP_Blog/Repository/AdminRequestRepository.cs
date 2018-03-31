using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ASP_Blog.Repository;
using ASP_Blog.Models;

namespace ASP_Blog.Repository
{
    public class AdminRequestRepository
    {
        private Db context;

        public AdminRequestRepository()
        {
            context = new Db();
        }

        public void addAdminRequest(AdminRequestModel a)
        {
            context.AdminRequests.Add(a);
            context.SaveChanges();
        }

        public void updateAdminRequest(AdminRequestModel a)
        {
            context.Entry<AdminRequestModel>(a).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void deleteAdminRequest(AdminRequestModel a)
        {
            context.AdminRequests.Remove(a);
            context.SaveChanges();
        }

        public List<AdminRequestModel> getAllAdminRequests()
        {
            return (from a in context.AdminRequests select a).ToList();
        }

        public bool requestExists(string username)
        {
            if ((from a in context.AdminRequests where a.username == username select a).Count() > 0)
            {
                return true;
            }
            return false;
        }
    }
}