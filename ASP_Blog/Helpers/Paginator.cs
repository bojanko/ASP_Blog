using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_Blog.Helpers
{
    public class Paginator<T>
    {
        private int prev;

        public int getPrev()
        {
            return prev;
        }

        private int l1;

        public int getL1()
        {
            return l1;
        }

        private int l2;

        public int getL2()
        {
            return l2;
        }

        private int l3;

        public int getL3()
        {
            return l3;
        }

        private int next;

        public int getNext()
        {
            return next;
        }

        private string active;

        public string getActive()
        {
            return active;
        }

        private int page;
        private int per_page;
        private int page_cnt;

        public void setData(List<T> data, int _page = 1, int _per_page = 5){
            prev = l1 = l2 = l3 = next = 0;
            page = _page;
            per_page = _per_page;
            page_cnt = (int) Math.Ceiling(data.Count / (float) per_page);

            calculateLinks();
        }

        private void calculateLinks()
        {
            if (page == 1)
            {
                prev = 0;
                l1 = 1;
                next = l2 = page + 1 <= page_cnt ? page + 1 : 0;
                l3 = page + 2 <= page_cnt ? page + 2 : 0;

                active = "l1";
            }
            else if (page > 1 && page < page_cnt)
            {
                prev = l1 = page - 1;
                l2 = page;
                next = l3 = page + 1;

                active = "l2";
            }
            else
            {
                prev = l1 = page - 1;
                l2 = page;
                next = l3 = 0;

                active = "l2";
            }
        }
    }
}