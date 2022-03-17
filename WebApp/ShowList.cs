using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp
{
    public class ShowList<T>
    {
        NodeList<T> Head;
        NodeList<T> Cola;
        NodeList<T> Return;

        public void Add(T Value)
        {
            NodeList<T> Nuevo = new NodeList<T>();
            Nuevo.value = Value;

            if (Head == null)
            {
                Head = Nuevo;
                Cola = Nuevo;
            }
            else
            {
                Cola.Next = Nuevo;
                Cola = Nuevo;
            }
        }
        public NodeList<T> Dequeue()
        {
            if(Head != null)
            {
                Return = Head;
                Head = Head.Next;
                if(Head == null)
                {
                    Cola = null;
                }
            }
            return Return;
        }
        public bool Empty()
        {
            return Head == null;
        }
    }
}
