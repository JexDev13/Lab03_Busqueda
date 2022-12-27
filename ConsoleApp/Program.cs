using System;
namespace ConsoleApp;
class Program
{
    static void Main(string[] args)
    {
        menu();
    }

    static void menu()
    {
        int[] vector = new int[20];
        int opc, n;
        do
        {
            Console.Write("\nLABORATORIO 03 - BUSQUEDA \n" +
                "--Menu-- \n" +
                "1. Generar vector \n" +
                "2. Busqueda Lineal \n" +
                "3. Busqueda Binaria \n" +
                "4. Busqueda secuencial \n" +
                "0. Salir \n" +
                "Seleccione: ");
            opc = Convert.ToInt32(Console.ReadLine());
            switch (opc)
            {
                case 0: //salir
                    Environment.Exit(0);
                    break;
                case 1: // generar vector
                    Console.Write("Generador de vector\n");
                    llenarVector(vector);
                    Console.Write("El vector es: \n");
                    imprimirVector(vector);
                    break;
                case 2: // Busqueda lineal
                    Console.Write("BUSQUEDA LINEAL\n");
                    Console.Write("Ingrese el elemento a buscar en el arreglo: ");
                    n = Convert.ToInt32(Console.ReadLine());
                    busquedaLineal(vector, n);
                    break;
                case 3: // Busqueda Binaria
                    Console.Write("BUSQUEDA BINARIA\n");
                    Console.Write("Ingrese el elemento a buscar en el arreglo: ");
                    n = Convert.ToInt32(Console.ReadLine());
                    busquedaBinaria(vector, n);
                    break;
                case 4: // Busqueda secuencial
                    busquedaSecuancial();
                    break;
                default:
                    Console.Write("---ERROR---\n" +
                                "Opcion no valida, reintentelo");
                    break;
            }
        } while (opc > -1 && opc < 11);
    }

    static void imprimirVector(int[] vector)
    {
        int pos;
        for (int i = 0; i < vector.Length; i++)
        {
            pos = i + 1;
            Console.Write("| Posicion: " + pos + " Elemento: " + vector[i] + " | \n");
        }
        Console.Write(" | ");
        for (int i = 0; i < vector.Length; i++)
        {
            pos = i + 1;
            Console.Write(vector[i] + " | ");
        }
        Console.Write("\n");
    }

    static void llenarVector(int[] vector)
    {
        Random random = new Random();
        for (int i = 0; i < vector.Length; i++)
        {
            vector[i] = random.Next(1, 100);
        }
    }

    static void busquedaLineal(int[] vector, int opc)
    {
        int tiempo1, tiempo2, aux, pos;
        tiempo1 = int.Parse($"{DateTime.Now:fffff}");
        for (int i = 0; i < vector.Length; i++)
        {
            if (vector[i] == opc)
            {
                pos = i + 1;
                Console.Write("El elemento " + opc + " fue encontrado en la posicion: " + pos + " \n");
                tiempo2 = int.Parse($"{DateTime.Now:fffff}");
                aux = tiempo2 - tiempo1;
                Console.Write("Hora de inicio: " + $"{DateTime.Now:HH:mm:ss}" + ":" + tiempo1 + "\n");
                Console.Write("Hora de finalizacion: " + $"{DateTime.Now:HH:mm:ss}" + ":" + tiempo2 + "\n");
                Console.Write("El tiempo de ejecucion para la busqueda linea fue " + aux + " milisegundos\n");
                break;
            }
            else
            {
                pos = -1;
                Console.Write("Elemento no encontrado en el arreglo\n");
                break;
            }
        }
    }

    static void busquedaBinaria(int[] vector, int opc)
    {
        int tiempo1, tiempo2, aux, central, bajo = 0, alto = (vector.Length - 1), posCentro;
        Array.Sort(vector);
        tiempo1 = int.Parse($"{DateTime.Now:fffff}");
        while (bajo <= alto)
        {
            central = (bajo + alto) / 2;
            posCentro = vector[central];
            if (vector[central] == opc)
            {
                Console.Write("El elemento " + opc + " fue encontrado en la posicion: " + central + " \n");
                tiempo2 = int.Parse($"{DateTime.Now:fffff}");
                aux = tiempo2 - tiempo1;
                Console.Write("Hora de inicio: " + $"{DateTime.Now:HH:mm:ss}" + ":" + tiempo1 + "\n");
                Console.Write("Hora de finalizacion: " + $"{DateTime.Now:HH:mm:ss}" + ":" + tiempo2 + "\n");
                Console.Write("El tiempo de ejecucion para la busqueda linea fue " + aux + " milisegundos\n");
                break;
            }
            else if (opc < vector[central])
            {
                alto = central - 1;
            }
            else
            {
                bajo = central + 1;
            }
        }
    }

    static void busquedaSecuancial()
    {
        int contador = 0, pos;
        int[] vector = new int[100];
        Random random = new Random();
        Console.Write("El vector de 100 elementos es: \n");
        Console.Write("| ");
        for (int i = 0; i < vector.Length; i++)
        {
            vector[i] = random.Next(1, 200);
            Console.Write(vector[i] + " | ");
        }
        Console.Write("\n");
        
        int[] vectorAux = new int[50];
        Console.Write("Los 50 elementos a buscar son es: \n");
        Console.Write("| ");
        for (int i = 0; i < vectorAux.Length; i++)
        {
            vectorAux[i] = random.Next(1, 200);
            Console.Write(vectorAux[i] + " | ");
        }
        Console.Write("\n");
        Console.Write("--BUSQUEDA SECUENCIAL--\n");
        Array.Sort(vector);
        Console.Write("--Elementos en orden creciente--\n");
        imprimirVector(vector);
        for (int i = 0; i < vector.Length; i++)
        {
            for (int j = 0; j < vectorAux.Length; j++)
            {
                if (vector[i] == vectorAux[j])
                {
                    pos = i + 1;
                    Console.Write("Elemento "+ vector[i]+ " encontrado en la posicion "+ pos + "\n");
                    contador++;
                }
            }
        }
        double porcentajeExt, portFra; 
        int bad;
        porcentajeExt = ((Convert.ToDouble(contador))/50)*100;
        portFra = 100-porcentajeExt;
        Console.Write("--ESTADISTICAS--\n");
        Console.Write("Numero de exitos encontrados: " + contador + "\n");
        Console.Write("Porcentaje de exitos: " + porcentajeExt + "%\n");
        bad = vectorAux.Length - contador;
        Console.Write("Numero de fracasos encontrados: " + bad + "\n");
        Console.Write("Porcentaje de fracasos: " + portFra + "%\n");
    }
}