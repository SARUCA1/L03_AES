﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp
{
    public class AVL<T> : IEnumerable<T>, IEnumerable
    {
        Nodo<T> raiz;
        public int altura;

        public AVL()
        {
            raiz = null;
        }
        public void Insertar(T valornuevo, Comparar<T> comparador)
        {
            Nodo<T> nuevo = new Nodo<T>
            {
                info = valornuevo,
                izq = null,
                der = null
            };
            if (raiz == null)
            {
                raiz = nuevo;
            }
            else
            {
                Nodo<T> anterior = null, pivot;
                pivot = raiz;
                while (pivot != null)
                {
                    anterior = pivot;
                    if (comparador(valornuevo, pivot.info) < 0)
                    {
                        pivot = pivot.izq;
                    }
                    else if (comparador(valornuevo, pivot.info) > 0)
                    {
                        pivot = pivot.der;
                    }
                }
            }
            //Rotaciones
            if (Alturas(raiz.izq) - Alturas(raiz.der) == 2)
            {
                if (comparador(valornuevo, raiz.izq.info) < 0)
                {
                    raiz = rotacionIzquierdaSimple(raiz);
                }
                else
                {
                    raiz = rotacionIzquierdaDoble(raiz);
                }
            }
            if (Alturas(raiz.der) - Alturas(raiz.izq) == 2)
            {
                if (comparador(valornuevo, raiz.der.info) > 0)
                {
                    raiz = rotacionDerechaSimple(raiz);
                }
                else
                {
                    raiz = rotacionDerechaDoble(raiz);
                }
            }
            raiz.altura = max(Alturas(raiz.izq), Alturas(raiz.der)) + 1;
        }

        //rama superior
        public int max(int a, int b)
        {
            return a > b ? a : b;
        }
        public int Alturas(Nodo<T> raiz)
        {
            return raiz == null ? -1 : raiz.altura;
        }

        //rotacion simple izquierda
        public Nodo<T> rotacionIzquierdaSimple(Nodo<T> a)
        {
            Nodo<T> b = a.der;
            a.der = b.izq;
            b.izq = a;
            a.altura = max(Alturas(a.izq), Alturas(a.der)) + 1;
            b.altura = max(Alturas(b.izq), a.altura) + 1;
            return b;
        }

        //Rotacion derecha simple
        public Nodo<T> rotacionDerechaSimple(Nodo<T> b)
        {
            Nodo<T> a = b.izq;
            b.der = a.izq;
            a.izq = b;
            b.altura = max(Alturas(b.izq), Alturas(b.der)) + 1;
            a.altura = max(Alturas(a.izq), b.altura) + 1;
            return a;
        }

        //Rotacion doble izquierda
        public Nodo<T> rotacionIzquierdaDoble(Nodo<T> a)
        {
            a.izq = rotacionDerechaSimple(a.izq);
            return rotacionIzquierdaDoble(a); 
        }

        //Rotacion doble derecha
        public Nodo<T> rotacionDerechaDoble(Nodo<T> a)
        {
            a.der = rotacionIzquierdaSimple(a.der);
            return rotacionIzquierdaDoble(a);
        }
        //altura
        public int Altura(Nodo<T> nodo)
        {
            if (nodo == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(Altura(nodo.izq), Altura(nodo.der));
            }
        }


        private void InOrderAVL(Nodo<T> root, ref ShowList<T> queue)
        {
            if (root != null)
            {
                InOrderAVL(root.izq, ref queue);
                queue.Add(root.info);
                InOrderAVL(root.der, ref queue);
            }
            return;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var queue = new ShowList<T>();
            InOrderAVL(raiz, ref queue);

            while (!queue.Empty())
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
