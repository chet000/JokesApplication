using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Jokes
    {
        public int Id { get; set; }
        public String Jokequestion { get; set; }
        public String Jokeanswer { get; set; }
        public Jokes()
        {

        }

        internal static object Equals(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}