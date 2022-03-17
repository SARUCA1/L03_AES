using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Helpers;

namespace WebApp
{
    public class ArbolB<T> : IEnumerable
    {

        //Arbol Ordenado
        Nodo<T> raiz;

        //Arbol vacio
        public ArbolB()
        {
            raiz = null;
        }

        //Agregar a arbol
        public void Insertar(T dato, Comparar<T> comparador)
        {
            Nodo<T> nuevo = new Nodo<T>
            {
                info = dato,
                izq = null,
                der = null
            };
            if (raiz == null)
                raiz = nuevo;
            else
            {
                Nodo<T> anterior = null, pivot;
                pivot = raiz;
                while (pivot != null)
                {
                    anterior = pivot;
                    if (comparador(dato, pivot.info) < 0)
                        pivot = pivot.izq;
                    else
                        pivot = pivot.der;
                }
                if (comparador(dato, anterior.info) < 0)
                    anterior.izq = nuevo;
                else
                    anterior.der = nuevo;
            }
        }

        private void InOrder(Nodo<T> root, ref ShowList<T> queue)
        {
            if(root == null)
            {
                return;
            }
            InOrder(root.izq, ref queue);
            queue.Add(root.info);
            InOrder(root.der, ref queue);
        }

        public IEnumerator GetEnumerator()
        {
            var queue = new ShowList<T>();
            InOrder(raiz, ref queue);

            while(!queue.Empty())
            {
                yield return queue.Dequeue();
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
