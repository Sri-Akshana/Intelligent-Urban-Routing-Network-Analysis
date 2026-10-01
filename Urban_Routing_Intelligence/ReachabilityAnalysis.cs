using System;
using System.Collections.Generic;
using Urban_Routing_Intelligence;

public class ReachabilityAnalysis
{
    public void FindReachableNodes(
        Graph graph,
        string startNode,
        double maximumTravelTime)
    {
        if (!graph.Nodes.ContainsKey(startNode))
        {
            Console.WriteLine("Start node not found: " + startNode);
            return;
        }

        Dictionary<string, double> distance =
            new Dictionary<string, double>();

        HashSet<string> visited =
            new HashSet<string>();

        foreach (string nodeID in graph.Nodes.Keys)
        {
            distance[nodeID] = double.MaxValue;
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

                double newDistance =
                    distance[currentNode] +
                    edge.TravelTimeMinutes;

                if (newDistance <= maximumTravelTime &&
                    newDistance < distance[neighbour])
                {
                    distance[neighbour] = newDistance;
                }
            }
        }

        Console.WriteLine();
        Console.WriteLine("Reachability Analysis");
        Console.WriteLine("---------------------");

        Console.WriteLine("Start Node: " + startNode);

        Console.WriteLine(
            "Maximum Travel Time: " +
            maximumTravelTime.ToString("F2") +
            " minutes");

        Console.WriteLine();
        Console.WriteLine("Reachable Nodes:");

        int reachableCount = 0;

        foreach (string nodeID in graph.Nodes.Keys)
        {
            if (distance[nodeID] != double.MaxValue &&
                distance[nodeID] <= maximumTravelTime)
            {
                Console.WriteLine(
                    nodeID +
                    " - " +
                    distance[nodeID].ToString("F2") +
                    " minutes");

                reachableCount++;
            }
        }

        Console.WriteLine();
        Console.WriteLine(
            "Total Reachable Nodes: " +
            reachableCount);
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
}