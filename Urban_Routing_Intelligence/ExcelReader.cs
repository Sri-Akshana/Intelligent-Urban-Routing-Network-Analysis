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

        using (XLWorkbook workbook = new XLWorkbook(filePath))
        {
            // -------------------------
            // Read Nodes
            // -------------------------

            IXLWorksheet nodesSheet =
                workbook.Worksheet(nodesSheetName);

            IXLRow? lastNodeRow = nodesSheet.LastRowUsed();

            if (lastNodeRow == null)
            {
                return graph;
            }

            int lastNodeRowNumber =
                lastNodeRow.RowNumber();

            for (int row = 2; row <= lastNodeRowNumber; row++)
            {
                string nodeID =
                    nodesSheet.Cell(row, 1).GetString();

                string locationName =
                    nodesSheet.Cell(row, 2).GetString();

                string area =
                    nodesSheet.Cell(row, 3).GetString();

                string nodeType =
                    nodesSheet.Cell(row, 4).GetString();

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

            IXLRow? lastEdgeRow = edgesSheet.LastRowUsed();

            if (lastEdgeRow == null)
            {
                return graph;
            }

            int lastEdgeRowNumber =
                lastEdgeRow.RowNumber();

            for (int row = 2; row <= lastEdgeRowNumber; row++)
            {
                string edgeID =
                    edgesSheet.Cell(row, 1).GetString();

                string fromNode =
                    edgesSheet.Cell(row, 2).GetString();

                string toNode =
                    edgesSheet.Cell(row, 3).GetString();

                double distanceKm =
                    edgesSheet.Cell(row, 4).GetValue<double>();

                double travelTimeMinutes =
                    edgesSheet.Cell(row, 5).GetValue<double>();

                double speedLimitKmh =
                    edgesSheet.Cell(row, 6).GetValue<double>();

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

        return graph;
    }
}