using System;
using System.Collections.Generic;
using Urban_Routing_Intelligence;

class Program
{
    static void Main()
    {
        Console.WriteLine("Intelligent Urban Routing and Network Analysis System");
        Console.WriteLine("====================================================");
        Console.WriteLine();

        // -------------------------
        // Select Dataset
        // -------------------------

        Console.WriteLine("Select Dataset:");
        Console.WriteLine("1. Small Dataset - 25 Nodes, 50 Edges");
        Console.WriteLine("2. Medium Dataset - 100 Nodes, 300 Edges");
        Console.WriteLine("3. Large Dataset - 500 Nodes, 1500 Edges");
        Console.WriteLine();

        Console.Write("Enter your choice: ");

        string choice = Console.ReadLine() ?? "";

        string filePath = "";
        string nodesSheetName = "";
        string edgesSheetName = "";
        string endNode = "";

        switch (choice)
        {
            case "1":
                filePath = "Urban_Routing_Small.xlsx";
                nodesSheetName = "Nodes_25";
                edgesSheetName = "Edges_50";
                endNode = "N25";
                break;

            case "2":
                filePath = "Urban_Routing_Medium.xlsx";
                nodesSheetName = "Nodes_100";
                edgesSheetName = "Edges_300";
                endNode = "N100";
                break;

            case "3":
                filePath = "Urban_Routing_Large.xlsx";
                nodesSheetName = "Nodes_500";
                edgesSheetName = "Edges_1500";
                endNode = "N500";
                break;

            default:
                Console.WriteLine("Invalid choice.");
                Console.ReadLine();
                return;
        }

        Console.WriteLine();
        Console.WriteLine("Selected Dataset:");
        Console.WriteLine("File: " + filePath);
        Console.WriteLine("Nodes: " + nodesSheetName);
        Console.WriteLine("Edges: " + edgesSheetName);
        Console.WriteLine();

        // -------------------------
        // Load Excel Data
        // -------------------------

        ExcelReader reader =
            new ExcelReader();

        Graph graph =
            reader.LoadGraph(
                filePath,
                nodesSheetName,
                edgesSheetName
            );

        // -------------------------
        // Check Loaded Graph
        // -------------------------

        if (graph.Nodes.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine(
                "No valid graph data was loaded.");
            Console.WriteLine(
                "The program cannot continue.");
            Console.ReadLine();
            return;
        }

        if (!graph.Nodes.ContainsKey("N1"))
        {
            Console.WriteLine();
            Console.WriteLine(
                "Required start node N1 was not found.");
            Console.WriteLine(
                "The program cannot continue.");
            Console.ReadLine();
            return;
        }

        if (!graph.Nodes.ContainsKey(endNode))
        {
            Console.WriteLine();
            Console.WriteLine(
                "Required end node " +
                endNode +
                " was not found.");

            Console.WriteLine(
                "The program cannot continue.");

            Console.ReadLine();
            return;
        }

        Console.WriteLine(
            "Excel data loaded successfully.");

        Console.WriteLine(
            "Number of Nodes: " +
            graph.Nodes.Count);

        int edgeCount = 0;

        foreach (List<Edge> edges in graph.AdjacencyList.Values)
        {
            edgeCount += edges.Count;
        }

        Console.WriteLine(
            "Number of Edges: " +
            edgeCount);

        // -------------------------
        // BFS
        // -------------------------

        BFS bfs =
            new BFS();

        List<string> bfsResult =
            bfs.Search(graph, "N1");

        Console.WriteLine();
        Console.WriteLine(
            "BFS Traversal starting from N1:");

        foreach (string node in bfsResult)
        {
            Console.Write(node + " ");
        }

        Console.WriteLine();

        // -------------------------
        // DFS
        // -------------------------

        DFS dfs =
            new DFS();

        List<string> dfsResult =
            dfs.Search(graph, "N1");

        Console.WriteLine();
        Console.WriteLine(
            "DFS Traversal starting from N1:");

        foreach (string node in dfsResult)
        {
            Console.Write(node + " ");
        }

        Console.WriteLine();

        // -------------------------
        // Dijkstra
        // -------------------------

        Dijkstra dijkstra =
            new Dijkstra();

        Console.WriteLine();

        dijkstra.FindShortestPath(
            graph,
            "N1",
            endNode
        );

        // -------------------------
        // Constrained Routing
        // -------------------------

        ConstrainedRouting constrainedRouting =
            new ConstrainedRouting();

        constrainedRouting.FindRoute(
            graph,
            "N1",
            endNode,
            20
        );

        // -------------------------
        // Reachability Analysis
        // -------------------------

        ReachabilityAnalysis reachability =
            new ReachabilityAnalysis();

        reachability.FindReachableNodes(
            graph,
            "N1",
            20
        );

        // -------------------------
        // Connectivity Analysis
        // -------------------------

        ConnectivityAnalysis connectivity =
            new ConnectivityAnalysis();

        connectivity.AnalyseConnectivity(
            graph
        );

        // -------------------------
        // Bottleneck Analysis
        // -------------------------

        BottleneckAnalysis bottleneck =
            new BottleneckAnalysis();

        bottleneck.AnalyseBottlenecks(
            graph
        );

        // -------------------------
        // Performance Analysis
        // -------------------------

        PerformanceAnalysis performance =
            new PerformanceAnalysis();

        performance.MeasurePerformance(
            graph,
            "N1"
        );

        // -------------------------
        // Program Completed
        // -------------------------

        Console.WriteLine();
        Console.WriteLine(
            "====================================");

        Console.WriteLine(
            "All analyses completed successfully.");

        Console.WriteLine(
            "====================================");

        Console.ReadLine();
    }
}