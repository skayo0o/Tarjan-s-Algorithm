using System.Collections.Generic;

namespace TarjanAlgorithm
{
    public class Graph
    {
        public int Vertices { get; private set; }
        public List<int>[] AdjacencyList { get; private set; }

        // Конструктор, инициализирующий граф с заданным количеством вершин
        public Graph(int vertices)
        {
            Vertices = vertices;
            // Создаем список смежности для каждой вершины
            AdjacencyList = new List<int>[vertices];
            for (int i = 0; i < vertices; i++)
            {
                AdjacencyList[i] = new List<int>();
            }
        }

        // Метод для добавления ребра в граф
        public void AddEdge(int u, int v)
        {
            AdjacencyList[u].Add(v);
        }
    }
}
