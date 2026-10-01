using System;
using System.Collections.Generic;
using Urban_Routing_Intelligence;

public class BFS
{
    public List<string> Search(Graph graph, string startNode)
    {
        List<string> visitedOrder = new List<string>();

        if (!graph.Nodes.ContainsKey(startNode))
        {
            Console.WriteLine("Start node not found: " + startNode);
            return visitedOrder;
        }

        Queue<string> queue = new Queue<string>();
        HashSet<string> visited = new HashSet<string>();

        queue.Enqueue(startNode);
        visited.Add(startNode);

        while (queue.Count > 0)
        {
            string currentNode = queue.Dequeue();

            visitedOrder.Add(currentNode);

            foreach (Edge edge in graph.GetNeighbours(currentNode))
            {
                string neighbour = edge.ToNode;

                if (!visited.Contains(neighbour))
                {
                    visited.Add(neighbour);
                    queue.Enqueue(neighbour);
                }
            }
        }

        return visitedOrder;
    }
}
