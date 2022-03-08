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

        //public BinaryList<SATModel> Lista = new BinaryList<SATModel>();

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
        public List<SATModel> ListaS = new List<SATModel>
        {
            
        };
    }
}
