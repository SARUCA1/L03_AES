using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp
{
    public class NodeList <T>
    {
        public T value;
        public NodeList<T> Next;
    }
}
