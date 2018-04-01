using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
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

        public void updatePage(PageModel p)
        {
            context.Entry<PageModel>(p).State = EntityState.Modified;
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