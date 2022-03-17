﻿using System;
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

        public ShowList<SATModel> ImpresionMail = new ShowList<SATModel>();

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
