using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using L03_AES;
using WebApp.Models;

namespace WebApp.Helpers
{
    public class Data
    {
        private static Data _instance = null;

        public ArbolB<SATModel> Lista = new ArbolB<SATModel>();

        public static Data Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Data();
                }
                return _instance;
            }
        }
    }
}
