using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_Blog.Repository;
using ASP_Blog.Models;

namespace ASP_Blog.Repository
{
    public class PageRepository
    {
        private Db context;

        public PageRepository()
        {
            context = new Db();
        }

        public void addPage(PageModel p)
        {
            context.Pages.Add(p);
            context.SaveChanges();
        }

        public void updatePage()
        {
            context.SaveChanges();
        }

        public void deletePage(PageModel p)
        {
            context.Pages.Remove(p);
            context.SaveChanges();
        }

        public PageModel getPageByName(string name)
        {
            return (from p in context.Pages where p.pageName == name select p).Single();
        }
    }
}