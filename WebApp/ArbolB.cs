using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp
{
    public class ArbolB<T>
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

        internal void Insertar(SATModel model)
        {
            throw new NotImplementedException();
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
        }

    }
}
