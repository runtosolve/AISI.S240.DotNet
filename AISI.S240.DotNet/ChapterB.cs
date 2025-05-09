namespace AISI.S240.DotNet;

public class ChapterB
{

    public record struct TableB5_2_2_3__1Inputs(
        string sheathing,
        string maxAspectRatio,
        string fastenerSpacing,
        string studBlocking,
        int designationThickness,
        int screwSize)
    {
        public string sheathing = sheathing;
        public string maxAspectRatio = maxAspectRatio;
        public string fastenerSpacing = fastenerSpacing;
        public string studBlocking = studBlocking;
        public int designationThickness = designationThickness;
        public int screwSize = screwSize;
    }

    private Dictionary<TableB5_2_2_3__1Inputs, double> _table;
    
    /// <summary>
    /// Constructor
    /// </summary>
    public ChapterB()
    {
        _table = TableB5_2_2_3__1();
    }
    
    private Dictionary<TableB5_2_2_3__1Inputs, double> TableB5_2_2_3__1()
    {
        
        Dictionary<TableB5_2_2_3__1Inputs, double> table = new Dictionary<TableB5_2_2_3__1Inputs, double>
        {
            {new TableB5_2_2_3__1Inputs("0.018 in. steel sheet", "2:1", "6/12", "No", 33, 8 ), 485.0},
            
            {new TableB5_2_2_3__1Inputs("0.027 in. steel sheet", "4:1", "4/12", "No", 43, 8 ), 1000.0},
            {new TableB5_2_2_3__1Inputs("0.027 in. steel sheet", "4:1", "3/12", "No", 43, 8 ), 1085.0},
            {new TableB5_2_2_3__1Inputs("0.027 in. steel sheet", "4:1", "2/12", "No", 43, 8 ), 1170.0},
            
            {new TableB5_2_2_3__1Inputs("0.027 in. steel sheet", "4:1", "6/12", "No", 33, 8 ), 645.0},
            {new TableB5_2_2_3__1Inputs("0.027 in. steel sheet", "4:1", "4/12", "No", 33, 8 ), 710.0},
            {new TableB5_2_2_3__1Inputs("0.027 in. steel sheet", "4:1", "3/12", "No", 33, 8 ), 780.0},
            {new TableB5_2_2_3__1Inputs("0.027 in. steel sheet", "4:1", "2/12", "No", 33, 8 ), 845.0},
            
            {new TableB5_2_2_3__1Inputs("0.030 in. steel sheet", "4:1", "6/12", "No", 33, 8 ), 795.0},
            {new TableB5_2_2_3__1Inputs("0.030 in. steel sheet", "4:1", "4/12", "No", 33, 8 ), 960.0},
            {new TableB5_2_2_3__1Inputs("0.030 in. steel sheet", "4:1", "3/12", "No", 33, 8 ), 1005.0},
            {new TableB5_2_2_3__1Inputs("0.030 in. steel sheet", "4:1", "2/12", "No", 33, 8 ), 1055.0},
            
            {new TableB5_2_2_3__1Inputs("0.030 in. steel sheet", "4:1", "6/12", "No", 43, 8 ), 910.0},
            {new TableB5_2_2_3__1Inputs("0.030 in. steel sheet", "4:1", "4/12", "No", 43, 8 ), 1015.0},
            {new TableB5_2_2_3__1Inputs("0.030 in. steel sheet", "4:1", "3/12", "No", 43, 8 ), 1040.0},
            {new TableB5_2_2_3__1Inputs("0.030 in. steel sheet", "4:1", "2/12", "No", 43, 8 ), 1070.0},
            
            {new TableB5_2_2_3__1Inputs("0.030 in. steel sheet", "4:1", "2/12", "Yes", 43, 10 ), 1355.0},
            
            {new TableB5_2_2_3__1Inputs("0.033 in. steel sheet", "4:1", "6/12", "No", 33, 8 ), 1035.0},
            {new TableB5_2_2_3__1Inputs("0.033 in. steel sheet", "4:1", "4/12", "No", 33, 8 ), 1145.0},
            {new TableB5_2_2_3__1Inputs("0.033 in. steel sheet", "4:1", "3/12", "No", 33, 8 ), 1225.0},
            {new TableB5_2_2_3__1Inputs("0.033 in. steel sheet", "4:1", "2/12", "No", 33, 8 ), 1300.0},

            {new TableB5_2_2_3__1Inputs("0.033 in. steel sheet", "4:1", "6/12", "No", 43, 8 ), 1055.0},
            {new TableB5_2_2_3__1Inputs("0.033 in. steel sheet", "4:1", "4/12", "No", 43, 8 ), 1170.0},
            {new TableB5_2_2_3__1Inputs("0.033 in. steel sheet", "4:1", "3/12", "No", 43, 8 ), 1235.0},
            {new TableB5_2_2_3__1Inputs("0.033 in. steel sheet", "4:1", "2/12", "No", 43, 8 ), 1305.0},

            {new TableB5_2_2_3__1Inputs("0.033 in. steel sheet", "4:1", "2/12", "Yes", 43, 10 ), 1505.0},
            
            {new TableB5_2_2_3__1Inputs("0.033 in. steel sheet", "4:1", "2/12", "No", 54, 8 ), 1870.0},
            
            {new TableB5_2_2_3__1Inputs("0.033 in. steel sheet", "4:1", "2/12", "Yes", 54, 10 ), 2085.0},
        };
        
        return table;
    }
    
    public double? FetchTableB5_2_2_3__1Strength(string sheathing, string maxAspectRatio, string fastenerSpacing,
        string studBlocking, int designationThickness, int screwSize)
    {
        var table = _table;

        var key = new TableB5_2_2_3__1Inputs(sheathing, maxAspectRatio, fastenerSpacing, studBlocking, designationThickness,
            screwSize);

        double value;
        if (table.TryGetValue(key, out value))
        {
            return table[key];
        }
        else
        {
            return null;
        }
   
    }
}