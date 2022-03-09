using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L03_AES
{
    public class ArbolB<T> where T : IComparable
    {

        //Arbol Ordenado
        Nodo<T> raiz;

        //Arbol vacio
        public ArbolB()
        {
            raiz = null;
        }

        //Agregar a arbol
        public void Insertar(T dato)
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
                    if (dato.CompareTo(pivot.info) < 0)//dato < pivot.info)
                        pivot = pivot.izq;
                    else
                        pivot = pivot.der;
                }
                if (dato.CompareTo(pivot.info) < 0)
                    anterior.izq = nuevo;
                else
                    anterior.der = nuevo;
            }
        }
        // Imprimir Arbol Preorden
        private void ImprimirPre(Nodo<T> recorrido)
        {
            if (recorrido != null)
            {
                Console.Write(recorrido.info + " ");
                ImprimirPre(recorrido.izq);
                ImprimirPre(recorrido.der);
            }
        }

        public void ImprimirPre()
        {
            ImprimirPre(raiz);
            Console.WriteLine();
        }
        // Imprimir arbol inorder
        private void ImprimirIn(Nodo<T> recorrido)
        {
            if (recorrido != null)
            {
                ImprimirIn(recorrido.izq);
                Console.Write(recorrido.info + " ");
                ImprimirIn(recorrido.der);
            }
        }

        public void ImprimirIn()
        {
            ImprimirIn(raiz);
            Console.WriteLine();
        }

        //Imprimir arbol post order
        private void ImprimirPost(Nodo<T> recorrido)
        {
            if (recorrido != null)
            {
                ImprimirPost(recorrido.izq);
                ImprimirPost(recorrido.der);
                Console.Write(recorrido.info + " ");
            }
        }


        public void ImprimirPost()
        {
            ImprimirPost(raiz);
            Console.WriteLine();
        }
    }
}
