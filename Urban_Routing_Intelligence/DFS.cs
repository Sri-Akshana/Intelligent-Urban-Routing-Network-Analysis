using System;
using System.Collections.Generic;
using Urban_Routing_Intelligence;

public class DFS
{
    public List<string> Search(Graph graph, string startNode)
    {
        List<string> visitedOrder = new List<string>();

        if (!graph.Nodes.ContainsKey(startNode))
        {
            Console.WriteLine("Start node not found: " + startNode);
            return visitedOrder;
        }

        Stack<string> stack = new Stack<string>();
        HashSet<string> visited = new HashSet<string>();

        stack.Push(startNode);

        while (stack.Count > 0)
        {
            string currentNode = stack.Pop();

            if (visited.Contains(currentNode))
            {
                continue;
            }

            visited.Add(currentNode);
            visitedOrder.Add(currentNode);

            List<Edge> neighbours = graph.GetNeighbours(currentNode);

            for (int i = neighbours.Count - 1; i >= 0; i--)
            {
                string neighbour = neighbours[i].ToNode;

                if (!visited.Contains(neighbour))
                {
                    stack.Push(neighbour);
                }
            }
        }

        return visitedOrder;
    }
}
