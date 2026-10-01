using System;
using System.IO;
using ClosedXML.Excel;
using Urban_Routing_Intelligence;

public class ExcelReader
{
    public Graph LoadGraph(
        string filePath,
        string nodesSheetName,
        string edgesSheetName)
    {
        Graph graph = new Graph();

        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine(
                    "Dataset file not found: " +
                    filePath);

                return graph;
            }

            using (XLWorkbook workbook = new XLWorkbook(filePath))
            {
                // -------------------------
                // Read Nodes
                // -------------------------

                IXLWorksheet nodesSheet =
                    workbook.Worksheet(nodesSheetName);

                IXLRow? lastNodeRow =
                    nodesSheet.LastRowUsed();

                if (lastNodeRow == null)
                {
                    Console.WriteLine(
                        "The nodes sheet contains no data.");

                    return graph;
                }

                int lastNodeRowNumber =
                    lastNodeRow.RowNumber();

                for (int row = 2;
                     row <= lastNodeRowNumber;
                     row++)
                {
                    string nodeID =
                        nodesSheet.Cell(row, 1).GetString();

                    string locationName =
                        nodesSheet.Cell(row, 2).GetString();

                    string area =
                        nodesSheet.Cell(row, 3).GetString();

                    string nodeType =
                        nodesSheet.Cell(row, 4).GetString();

                    if (string.IsNullOrWhiteSpace(nodeID))
                    {
                        Console.WriteLine(
                            "Invalid node data at row " +
                            row +
                            ". Node skipped.");

                        continue;
                    }

                    Node node = new Node(
                        nodeID,
                        locationName,
                        area,
                        nodeType
                    );

                    graph.AddNode(node);
                }

                // -------------------------
                // Read Edges
                // -------------------------

                IXLWorksheet edgesSheet =
                    workbook.Worksheet(edgesSheetName);

                IXLRow? lastEdgeRow =
                    edgesSheet.LastRowUsed();

                if (lastEdgeRow == null)
                {
                    Console.WriteLine(
                        "The edges sheet contains no data.");

                    return graph;
                }

                int lastEdgeRowNumber =
                    lastEdgeRow.RowNumber();

                for (int row = 2;
                     row <= lastEdgeRowNumber;
                     row++)
                {
                    string edgeID =
                        edgesSheet.Cell(row, 1).GetString();

                    string fromNode =
                        edgesSheet.Cell(row, 2).GetString();

                    string toNode =
                        edgesSheet.Cell(row, 3).GetString();

                    if (string.IsNullOrWhiteSpace(edgeID) ||
                        string.IsNullOrWhiteSpace(fromNode) ||
                        string.IsNullOrWhiteSpace(toNode))
                    {
                        Console.WriteLine(
                            "Invalid edge data at row " +
                            row +
                            ". Edge skipped.");

                        continue;
                    }

                    double distanceKm;
                    double travelTimeMinutes;
                    double speedLimitKmh;

                    try
                    {
                        distanceKm =
                            edgesSheet.Cell(row, 4)
                            .GetValue<double>();

                        travelTimeMinutes =
                            edgesSheet.Cell(row, 5)
                            .GetValue<double>();

                        speedLimitKmh =
                            edgesSheet.Cell(row, 6)
                            .GetValue<double>();
                    }
                    catch
                    {
                        Console.WriteLine(
                            "Invalid numeric data in edge row " +
                            row +
                            ". Edge skipped.");

                        continue;
                    }

                    // Dijkstra requires non-negative travel times.
                    if (double.IsNaN(travelTimeMinutes) ||
                        double.IsInfinity(travelTimeMinutes) ||
                        travelTimeMinutes < 0)
                    {
                        Console.WriteLine(
                            "Invalid travel time in edge row " +
                            row +
                            ". Edge skipped.");

                        continue;
                    }

                    string roadType =
                        edgesSheet.Cell(row, 7).GetString();

                    string congestion =
                        edgesSheet.Cell(row, 8).GetString();

                    string roadName =
                        edgesSheet.Cell(row, 9).GetString();

                    Edge edge = new Edge(
                        edgeID,
                        fromNode,
                        toNode,
                        distanceKm,
                        travelTimeMinutes,
                        speedLimitKmh,
                        roadType,
                        congestion,
                        roadName
                    );

                    graph.AddEdge(edge);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine(
                "Error loading the Excel dataset.");
            Console.WriteLine(
                "Details: " +
                ex.Message);

            return graph;
        }

        return graph;
    }
}