using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L03_AES
{
    class ArbolB
    {

        //Arbol Ordenado
        class Nodo
        {
            public int info;
            public Nodo izq, der;
        }
        Nodo raiz;

        //Arbol vacio
        public ArbolB()
        {
            raiz = null;
        }

        //Agregar a arbol
        public void Insertar(int dato)
        {
            Nodo nuevo;
            nuevo = new Nodo();
            nuevo.info = dato;
            nuevo.izq = null;
            nuevo.der = null;
            if (raiz == null)
                raiz = nuevo;
            else
            {
                Nodo anterior = null, reco;
                reco = raiz;
                while (reco != null)
                {
                    anterior = reco;
                    if (dato < reco.info)
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
        private void ImprimirPre(Nodo recorrido)
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
        private void ImprimirIn(Nodo recorrido)
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
        private void ImprimirPost(Nodo recorrido)
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
