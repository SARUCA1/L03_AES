using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp
{
    public class AVL
    {
        public int valor;
        public AVL NodoIzquierdo;
        public AVL NodoDerecho;
        public AVL NodoPadre;
        public int altura;
        public AVL(int valornuevo, AVL izquierdo, AVL derecho, AVL padre)
        {
            valor = valornuevo;
            NodoIzquierdo = izquierdo;
            NodoDerecho = derecho;
            NodoPadre = padre;
            altura = 0;
        }

        public AVL Insertar(int valornuevo, AVL raiz)
        {
            if (raiz == null)
            {
                raiz = new AVL(valornuevo, null, null, null);
            }
            else if (valornuevo < raiz.valor)
            {
                raiz.NodoIzquierdo = Insertar(valornuevo, raiz.NodoIzquierdo);
            }
            else if (valornuevo > raiz.valor)
            {
                raiz.NodoDerecho = Insertar(valornuevo, raiz.NodoDerecho);
            }
            //Rotaciones
            if (Alturas(raiz.NodoIzquierdo) - Alturas(raiz.NodoDerecho) == 2)
            {
                if (valornuevo < raiz.NodoIzquierdo.valor)
                {
                    raiz = rotacionIzquierdaSimple(raiz);
                }
                else
                {
                    raiz = rotacionIzquierdaDoble(raiz);
                }
            }
            if (Alturas(raiz.NodoDerecho) - Alturas(raiz.NodoIzquierdo) == 2)
            {
                if (valornuevo < raiz.NodoDerecho.valor)
                {
                    raiz = rotacionDerechaSimple(raiz);
                }
                else
                {
                    raiz = rotacionDerechaDoble(raiz);
                }
            }
            raiz.altura = max(Alturas(raiz.NodoIzquierdo), Alturas(raiz.NodoDerecho)) + 1;
            return raiz;
        }

        //rama superior
        private static int max(int a, int b)
        {
            return a > b ? a : b;
        }
        private static int Alturas(AVL raiz)
        {
            return raiz == null ? -1 : raiz.altura;
        }

        //rotacion simple izquierda
        private static AVL rotacionIzquierdaSimple(AVL a)
        {
            AVL b = a.NodoIzquierdo;
            a.NodoIzquierdo = b.NodoDerecho;
            b.NodoDerecho = a;
            a.altura = max(Alturas(a.NodoIzquierdo), Alturas(a.NodoDerecho)) + 1;
            b.altura = max(Alturas(b.NodoIzquierdo), a.altura) + 1;
            return b;
        }

        //Rotacion derecha simple
        private static AVL rotacionDerechaSimple(AVL b)
        {
            AVL a = b.NodoIzquierdo;
            b.NodoDerecho = a.NodoIzquierdo;
            a.NodoIzquierdo = b;
            b.altura = max(Alturas(b.NodoIzquierdo), Alturas(b.NodoDerecho)) + 1;
            a.altura = max(Alturas(a.NodoIzquierdo), b.altura) + 1;
            return a;
        }

        //Rotacion doble izquierda
        private static AVL rotacionIzquierdaDoble(AVL a)
        {
            a.NodoIzquierdo = rotacionDerechaSimple(a.NodoIzquierdo);
            return rotacionIzquierdaDoble(a); 
        }

        //Rotacion doble derecha
        private static AVL rotacionDerechaDoble(AVL a)
        {
            a.NodoDerecho = rotacionIzquierdaSimple(a.NodoDerecho);
            return rotacionIzquierdaDoble(a);
        }
        //altura
        public int Altura(AVL nodo)
        {
            if (nodo == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(Altura(nodo.NodoIzquierdo), Altura(nodo.NodoDerecho));
            }
        }
    }
}
