using System;
using System.Collections.Generic;
using Urban_Routing_Intelligence;

public class ConstrainedRouting
{
    public void FindRoute(
        Graph graph,
        string startNode,
        string endNode,
        double maximumTravelTime)
    {
        if (maximumTravelTime < 0)
        {
            Console.WriteLine(
                "Maximum travel time cannot be negative.");
            return;
        }

        if (!graph.Nodes.ContainsKey(startNode))
        {
            Console.WriteLine("Start node not found: " + startNode);
            return;
        }

        if (!graph.Nodes.ContainsKey(endNode))
        {
            Console.WriteLine("End node not found: " + endNode);
            return;
        }

        Dictionary<string, double> distance =
            new Dictionary<string, double>();

        Dictionary<string, string> previous =
            new Dictionary<string, string>();

        HashSet<string> visited =
            new HashSet<string>();

        foreach (string nodeID in graph.Nodes.Keys)
        {
            distance[nodeID] = double.MaxValue;
            previous[nodeID] = "";
        }

        distance[startNode] = 0;

        while (visited.Count < graph.Nodes.Count)
        {
            string currentNode =
                GetClosestUnvisitedNode(distance, visited);

            if (currentNode == "")
            {
                break;
            }

            visited.Add(currentNode);

            foreach (Edge edge in graph.GetNeighbours(currentNode))
            {
                string neighbour = edge.ToNode;

                if (visited.Contains(neighbour))
                {
                    continue;
                }

                // Travel time must be valid for the routing calculation.
                if (double.IsNaN(edge.TravelTimeMinutes) ||
                    double.IsInfinity(edge.TravelTimeMinutes) ||
                    edge.TravelTimeMinutes < 0)
                {
                    Console.WriteLine(
                        "Invalid travel time detected on edge: " +
                        edge.EdgeID);

                    continue;
                }

                double newDistance =
                    distance[currentNode] +
                    edge.TravelTimeMinutes;

                // Only accept routes within the time constraint.
                if (newDistance <= maximumTravelTime &&
                    newDistance < distance[neighbour])
                {
                    distance[neighbour] = newDistance;
                    previous[neighbour] = currentNode;
                }
            }
        }

        Console.WriteLine();
        Console.WriteLine("Constrained Routing");
        Console.WriteLine("-------------------");

        Console.WriteLine("Start Node: " + startNode);
        Console.WriteLine("End Node: " + endNode);
        Console.WriteLine(
            "Maximum Travel Time: " +
            maximumTravelTime.ToString("F2") +
            " minutes");

        if (distance[endNode] == double.MaxValue)
        {
            Console.WriteLine(
                "No route found within the travel time constraint.");

            return;
        }

        List<string> path =
            BuildPath(previous, startNode, endNode);

        Console.WriteLine(
            "Total Travel Time: " +
            distance[endNode].ToString("F2") +
            " minutes");

        Console.WriteLine("Path:");

        for (int i = 0; i < path.Count; i++)
        {
            Console.Write(path[i]);

            if (i < path.Count - 1)
            {
                Console.Write(" -> ");
            }
        }

        Console.WriteLine();
    }

    private string GetClosestUnvisitedNode(
        Dictionary<string, double> distance,
        HashSet<string> visited)
    {
        string closestNode = "";
        double smallestDistance = double.MaxValue;

        foreach (var item in distance)
        {
            if (!visited.Contains(item.Key) &&
                item.Value < smallestDistance)
            {
                smallestDistance = item.Value;
                closestNode = item.Key;
            }
        }

        return closestNode;
    }

    private List<string> BuildPath(
        Dictionary<string, string> previous,
        string startNode,
        string endNode)
    {
        List<string> path =
            new List<string>();

        string currentNode = endNode;

        while (currentNode != "")
        {
            path.Add(currentNode);

            if (currentNode == startNode)
            {
                break;
            }

            currentNode = previous[currentNode];
        }

        path.Reverse();

        return path;
    }
}