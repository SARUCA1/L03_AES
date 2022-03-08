using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L03_AES
{
    public class Nodo<T>
    {
        public T info;
        public Nodo<T> nodo;
        public Nodo<T> izq;
        public Nodo<T> der;
    }
}
