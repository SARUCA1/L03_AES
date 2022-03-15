using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L03_AES
{
    public class ArbolB<T> : IEnumerable<T>, IEnumerable where T : IComparable //: IEnumerable<T>, IEnumerable
    {

        //Arbol Ordenado
        Nodo<T> raiz;
        public delegate Comparison<T> comparador (T value1, T value2);
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
                    if (comparador(dato, pivot.info))
                        pivot = pivot.izq;
                    else
                        pivot = pivot.der;
                }
                if (dato.CompareTo(anterior.info) < 0)
                    anterior.izq = nuevo;
                else
                    anterior.der = nuevo;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            yield return raiz.izq.info;
            yield return raiz.info;
            yield return raiz.der.info;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
