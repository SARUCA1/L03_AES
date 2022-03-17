using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Helpers
{
    public class Data
    {
        private static Data _instance = null;

        public ArbolB<SATModel> Lista = new ArbolB<SATModel>();
        public ArbolB<SATModel> ArbolID = new ArbolB<SATModel>();
        public ArbolB<SATModel> ArbolSerial = new ArbolB<SATModel>();

        public AVL<SATModel> AvlMail = new AVL<SATModel>();
        public AVL<SATModel> AvlID = new AVL<SATModel>();
        public AVL<SATModel> AvlSerial = new AVL<SATModel>();

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
