using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L03_AES
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
        public void Insertar(T dato)
        {
            Nodo<T> nuevo;
            nuevo = new Nodo<T>();
            nuevo.info = dato;
            nuevo.izq = null;
            nuevo.der = null;
            if (raiz == null)
                raiz = nuevo;
            else
            {
                Nodo<T> anterior = null, reco;
                reco = raiz;
                while (reco != null)
                {
                    anterior = reco;
                    if ()//dato < reco.info)
                        reco = reco.izq;
                    else
                        reco = reco.der;
                }
                if (dato < anterior.info)
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
