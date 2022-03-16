using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp
{
    public delegate int Comparar<T>(T a, T b);

    public class Comparar
    {
        public static int CompID(SATModel a, SATModel b)
        {
            if (a.ID != b.ID)
            {
                if (a.ID.CompareTo(b.ID) < 0)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }

        public static int CompEmail(SATModel a, SATModel b)
        {
            if (a.Email != b.Email)
            {
                if (a.Email.CompareTo(b.Email) < 0)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }

        public static int CompSerial(SATModel a, SATModel b)
        {
            if (a.Serie != b.Serie)
            {
                if (a.Serie.CompareTo(b.Serie) < 0)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
