using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 *
 * Puntos ejercicio: 7
 *
 * En este ejercicio, implementaremos algunas operaciones sobre un Doubly
 * Linked List con dummy nodes. En estas operaciones, solo se permite cambiar
 * los campos prev y next de DLinkNode.
 *
 * Las operaciones estan marcadas con el tag TODO.
 *
 * No se permite:
 *   1) Crear arreglos
 *   2) Crear nuevos nodos con operador new
 *   3) Modificar el value en DLinkNode
 *
 * Instrucciones adicionales: 
 *   a) No borren los comments que existen en este codigo
 *   b) No se permite usar las estructuras de datos en java.util.*
 *   c) Se permite agregar campos adicionales en la declaracion de las clases
 *   d) Se permite agregar parametros adicionales a los metodos
 *
 */

// Doubly Linked List, definido con Generics

class IndexOutOfBoundsException : SystemException { }

class DLinkedList<Value>
{
    /**
     * Nodo del Linked List
     */
    class DLinkNode
    {
        public Value value;
        public DLinkNode prev, next;
        public DLinkNode(Value value)
        {
            this.value = value;
        }
    }

    private DLinkNode head, tail;   // head y tail apuntan a dummy nodes
    private int size;                // cantidad de elementos en el Linked List

    public DLinkedList()
    {
        head = new DLinkNode(default(Value));   // dummy head
        tail = new DLinkNode(default(Value));   // dummy tail
        head.next = tail;
        tail.prev = head;
        size = 0;
    }

    public int Size()
    {
        return size;
    }


    /**
     * Agrega un elemento al final del doubly linked list
     */
    public void Append(Value value)
    {
        DLinkNode newNode = new DLinkNode(value);
        newNode.next = tail;
        newNode.prev = tail.prev;
        newNode.prev.next = newNode;
        newNode.next.prev = newNode;
        size++;
    }


    /**
     * Convertir el Linked List a un String para ser impreso en la consola
     */
    override
    public String ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("size = ");
        sb.Append(size);
        sb.Append("  elementos = ( ");
        DLinkNode cur = head.next;
        while (cur != tail)
        {
            if (cur != head.next)
                sb.Append(' ');
            sb.Append(cur.value);
            cur = cur.next;
        }
        sb.Append(" )");
        return sb.ToString();
    }


    /**
     * Insertar la lista L al inicio de la lista 'this'
     * Luego de la operacion, la lista L debe quedar vacia.
     * Ejemplo: si la lista L1 tiene A, B, C y la lista L2 tiene D, E,
     * L1.prepend(L2) 
     */
    public void Prepend(DLinkedList<Value> L)
    {
        // TODO: implementar
        // Complejidad esperada: O(1)
        // Valor: 2 puntos
        L.tail.prev.next = this.head.next;
        this.head.next = L.head.next;
        this.head.next.prev = L.tail.prev;
        L.head.next = L.tail = null;
        this.size += L.size;
        L.size = 0;
    }


    /**
     * Extraer los elementos desde la posicion 'start' hasta la posicion 'end' y
     * devolverlo en un nuevo DLinkedList.  Los elementos extraidos desaparecen
     * de la lista 'this'.
     * Ejemplo: si la lista L contiene, en orden, A B C D E F G H I J K L M,
     * L.subList(3, 7) devuelve la lista D E F G H y deja la lista con los
     * valores A B C I J K L M
     */
    public DLinkedList<Value> subList(int start, int end)
    {
        if (start < 0 || start >= size || end < start || end >= size)
            throw new IndexOutOfBoundsException();

        // TODO: implementar
        // Complejidad esperada: O(N) para buscar las dos posiciones
        //                       O(1) para extraer la sublista
        // Valor: 5 puntos
        DLinkedList<Value> a = new DLinkedList<Value>();
        DLinkNode cur = head.next;
        int pos1 = 0, pos2 = start;
        for (int i = 0; i < size; i++)
        {
            if(pos1 == start)
            {
                a.head.next = cur;
                cur.prev = a.head;
            }
            else if(pos2 == end)
            {
                a.tail.prev = cur;
                cur.next = a.tail;
            }
            else
            {
                cur = cur.next;
            }
            pos1++;
            pos2++;
        }

        return a; 
    }

}


class Lab2d
{
     static void Main(String[] args)
    {
        DLinkedList<String> L2 = new DLinkedList<String>();
        L2.Append("A");
        L2.Append("B");
        L2.Append("C");
        L2.Append("D");
        L2.Append("E");
        L2.Append("F");
        L2.Append("G");
        L2.Append("H");

        DLinkedList<String> L1 = new DLinkedList<String>();
        L1.Append("I");
        L1.Append("J");
        L1.Append("K");
        L1.Append("L");
        L1.Append("M");

        Console.WriteLine("Listas originales");
        Console.WriteLine("L1: " + L1);
        Console.WriteLine("L2: " + L2);
        Console.WriteLine();

        L1.Prepend(L2);
        Console.WriteLine("Despues de L1.prepend(L2)");
        Console.WriteLine("L1: " + L1);
        Console.WriteLine("L2: " + L2);
        Console.WriteLine();

        DLinkedList<String> L3 = L1.subList(3, 7);
        Console.WriteLine("Despues de L1.subList(3, 7)");
        Console.WriteLine("L1: " + L1);
        Console.WriteLine("L3: " + L3);
        Console.WriteLine();

        /*
        Salida esperada:
        Listas originales
        L1: size = 5  elementos = ( I J K L M )
        L2: size = 8  elementos = ( A B C D E F G H )

        Despues de L1.prepend(L2)
        L1: size = 13  elementos = ( A B C D E F G H I J K L M )
        L2: size = 0  elementos = (  )

        Despues de L1.subList(3, 7)
        L1: size = 8  elementos = ( A B C I J K L M )
        L3: size = 5  elementos = ( D E F G H )
        */
    }
}



