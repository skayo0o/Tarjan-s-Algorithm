using System;
using System.Collections.Generic;

namespace TarjanAlgorithm
{
    public class TarjanSCC
    {
        private int index = 0;
        private Stack<int> stack = new Stack<int>();
        private Dictionary<int, int> indices = new Dictionary<int, int>();
        private Dictionary<int, int> lowlinks = new Dictionary<int, int>();
        private HashSet<int> onStack = new HashSet<int>();
        private List<List<int>> sccs = new List<List<int>>();
        private Graph graph;

        // Конструктор, принимающий граф
        public TarjanSCC(Graph graph)
        {
            this.graph = graph;
        }

        // Метод для нахождения сильно связанных компонент
        public List<List<int>> FindSCCs()
        {
            for (int i = 0; i < graph.Vertices; i++)
            {
                if (!indices.ContainsKey(i))
                {
                    StrongConnect(i);
                }
            }

            return sccs;
        }

        // Метод для поиска сильно связанных компонент, начиная с вершины node
        private void StrongConnect(int node)
        {
            indices[node] = index;
            lowlinks[node] = index;
            index++;
            stack.Push(node);
            onStack.Add(node);

            foreach (var neighbor in graph.AdjacencyList[node])
            {
                if (!indices.ContainsKey(neighbor))
                {
                    StrongConnect(neighbor);
                    lowlinks[node] = Math.Min(lowlinks[node], lowlinks[neighbor]);
                }
                else if (onStack.Contains(neighbor))
                {
                    lowlinks[node] = Math.Min(lowlinks[node], indices[neighbor]);
                }
            }

            if (lowlinks[node] == indices[node])
            {
                var scc = new List<int>();
                int w;
                do
                {
                    w = stack.Pop();
                    onStack.Remove(w);
                    scc.Add(w);
                } while (w != node);
                sccs.Add(scc);
            }
        }
    }
}
