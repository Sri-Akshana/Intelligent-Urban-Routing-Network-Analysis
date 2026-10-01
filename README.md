# Intelligent Urban Routing and Network Analysis System

## 1. Project Description

This project implements an Intelligent Urban Routing and Network Analysis System using C#. The system represents an urban road network as a graph, where locations are represented as nodes and road connections are represented as edges.

The system provides graph algorithms and network analysis features to support route finding, connectivity analysis, reachability analysis, constrained routing, and identification of highly connected nodes.

This project was developed as part of the Data Structures and Algorithms module.

## 2. Programming Language and Version

* Programming Language: C#
* Framework: .NET 10.0
* Development Environment: Microsoft Visual Studio
* Project Type: Console Application

## 3. Dependencies

The project uses the following external NuGet package:

* ClosedXML 0.105.1 – used to read and process the Excel dataset files.

The required package can be restored automatically when the project is opened and built in Visual Studio.

## 4. How to Run the Project

1. Clone or download this repository.
2. Open the project in Microsoft Visual Studio.
3. Make sure .NET 10.0 is installed.
4. Restore the required NuGet packages.
5. Ensure the Excel dataset files are available in the project.
6. Build the project.
7. Run the console application.
8. The program will load the selected dataset and perform the implemented routing and network analysis operations.

## 5. Project Structure

The main C# files are:

* `Program.cs` – Main program and execution flow.
* `Node.cs` – Represents a graph node/location.
* `Edge.cs` – Represents a connection between two nodes with a travel-time weight.
* `Graph.cs` – Stores the graph using an adjacency list and provides graph operations.
* `BFS.cs` – Implements Breadth-First Search.
* `DFS.cs` – Implements Depth-First Search.
* `Dijkstra.cs` – Implements Dijkstra's shortest-path algorithm.
* `ExcelReader.cs` – Reads node and edge information from Excel datasets.

## 6. Datasets

The project uses Excel datasets representing an urban road network.

Three datasets are provided for testing different graph sizes:

| Dataset                   | Nodes | Edges |
| ------------------------- | ----: | ----: |
| Urban_Routing_Small.xlsx  |    25 |    50 |
| Urban_Routing_Medium.xlsx |   100 |   300 |
| Urban_Routing_Large.xlsx  |   500 | 1,500 |

The datasets are used to evaluate the correctness, performance, and scalability of the implemented algorithms.

## 7. Implemented Features

The system implements the following features:

* Graph creation using an adjacency list.
* Adding nodes and edges.
* Breadth-First Search (BFS).
* Depth-First Search (DFS).
* Dijkstra's shortest-path algorithm.
* Constrained route finding using a maximum travel-time limit.
* Reachability analysis within a specified travel-time budget.
* Connectivity analysis.
* Identification of highly connected and potential critical nodes.
* Performance testing using different dataset sizes.
* Comparison of algorithm execution times.

## 8. Data Structure

The graph is represented using an adjacency list implemented with a C# `Dictionary`.

The adjacency-list representation was selected because it stores the actual connections between locations without requiring space for every possible pair of nodes. It is suitable for BFS, DFS, and Dijkstra's algorithm.

The graph storage requires `O(V + E)` space, where:

* `V` = number of nodes
* `E` = number of edges

## 9. Algorithms and Complexity

### Breadth-First Search (BFS)

* Time Complexity: `O(V + E)`
* Space Complexity: `O(V)`

### Depth-First Search (DFS)

* Time Complexity: `O(V + E)`
* Space Complexity: `O(V)`

### Dijkstra's Algorithm

The implementation uses a simple selection approach for choosing the next minimum-distance node.

* Time Complexity: `O(V² + E)`
* Space Complexity: `O(V)`

Where:

* `V` = number of vertices/nodes
* `E` = number of edges

## 10. Testing and Evaluation

The system was tested using small, medium, and large datasets to evaluate correctness and scalability.

The largest test dataset contains:

* 500 nodes
* 1,500 edges

The system was tested using BFS, DFS, Dijkstra's shortest-path algorithm, constrained routing, reachability analysis, connectivity analysis, and critical-node analysis.

Performance measurements were also collected for the different dataset sizes to evaluate how execution time changes as the graph size increases.

## 11. Academic Purpose

This project is an academic implementation demonstrating graph data structures, graph traversal algorithms, shortest-path algorithms, complexity analysis, and network analysis techniques.

The system is designed as a prototype for an urban routing and network analysis system and is not intended to replace a production navigation system.

## 12. Notes

The Excel datasets are included with the project and are configured to be copied to the output directory when the project is built.

The project requires .NET 10.0 and the ClosedXML 0.105.1 NuGet package to run successfully.
