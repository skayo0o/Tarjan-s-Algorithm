using System;

namespace TarjanAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество вершин:");
            int V = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество рёбер:");
            int E = int.Parse(Console.ReadLine());

            Graph graph = new Graph(V);

            Console.WriteLine("Введите рёбра в формате 'u v', где u и v - вершины (нумерация с 0):");
            for (int i = 0; i < E; i++)
            {
                var edge = Console.ReadLine().Split(' ');
                int u = int.Parse(edge[0]);
                int v = int.Parse(edge[1]);
                graph.AddEdge(u, v);
            }

            TarjanSCC tarjan = new TarjanSCC(graph);
            var sccs = tarjan.FindSCCs();

            Console.WriteLine("Сильно связанные компоненты:");
            foreach (var scc in sccs)
            {
                scc.Sort(); // Сортировка вершин внутри каждой ССК
                Console.WriteLine(string.Join(", ", scc));
            }
        }
    }
}