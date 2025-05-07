namespace AISI.S240.DotNet;

public class B5LateralForceResistingSystems
{

    public record struct WallInputs
    {
        public string sheathing;
        public string maxAspectRatio;
        public string fastenerSpacing;
        public string studBlocking;
        public double designationThickness;
        public int screwSize;
        
        public WallInputs(string theSheathing, string theMaxAspectRatio, string theFastenerSpacing, string theStudBlocking, double theDesignationThickness, int theScrewSize)
        {
            sheathing = theSheathing;
            maxAspectRatio = theMaxAspectRatio;
            fastenerSpacing = theFastenerSpacing;
            studBlocking = theStudBlocking;
            designationThickness = theDesignationThickness;
            screwSize = theScrewSize;
        }
        
    }

    public static Dictionary<WallInputs, double> TableB5_2_2_3__1(string sheathing, string maxAspectRatio, string fastenerSpacing, string studBlocking, double designationThickness, int screwSize)
    {
        
        List<string> sheathingList = new List<string>();
        
        sheathingList.Add("0.018 in. steel sheet");
        sheathingList.Add("0.018 in. steel sheet"); 
        sheathingList.Add("0.027 in. steel sheet"); 
        sheathingList.Add("0.027 in. steel sheet"); 
        sheathingList.Add("0.030 in. steel sheet"); 
        sheathingList.Add("0.030 in. steel sheet"); 
        sheathingList.Add("0.030 in. steel sheet"); 
        sheathingList.Add("0.033 in. steel sheet"); 
        sheathingList.Add("0.033 in. steel sheet"); 
        sheathingList.Add("0.033 in. steel sheet"); 
        sheathingList.Add("0.033 in. steel sheet"); 
        sheathingList.Add("0.033 in. steel sheet");
     
        List<string> maxAspectRatioList = new List<string>();
        
        maxAspectRatioList.Add("2:1");
        maxAspectRatioList.Add("4:1");
        maxAspectRatioList.Add("4:1");
        maxAspectRatioList.Add("4:1");
        maxAspectRatioList.Add("4:1");
        maxAspectRatioList.Add("4:1");
        maxAspectRatioList.Add("4:1");
        maxAspectRatioList.Add("4:1");
        maxAspectRatioList.Add("4:1");
        maxAspectRatioList.Add("4:1");
        maxAspectRatioList.Add("4:1");
        
        List<string> fastenerSpacingList = new List<string>();
        
        fastenerSpacingList.Add("6/12");
        fastenerSpacingList.Add("4/12");
        fastenerSpacingList.Add("3/12");
        fastenerSpacingList.Add("2/12");
        
        List<List<double>> shearStrengthList = new List<List<double>>();
        
        shearStrengthList.Add([485.0, Double.NaN, Double.NaN, Double.NaN]);
        shearStrengthList.Add([Double.NaN, 1000.0, 1085.0, 1170.0]);
        shearStrengthList.Add([645.0, 710.0, 780.0, 845.0]);
        shearStrengthList.Add([795.0, 960.0, 1005.0, 1055.0]);
        shearStrengthList.Add([910.0, 1015.0, 1040.0, 1070.0]);
        shearStrengthList.Add([Double.NaN, Double.NaN, Double.NaN, 1355.0]);
        shearStrengthList.Add([1035.0, 1145.0, 1225.0, 1300.0]);
        shearStrengthList.Add([1055.0, 1170.0, 1235.0, 1305.0]);
        shearStrengthList.Add([Double.NaN, Double.NaN, Double.NaN, 1505.0]);
        shearStrengthList.Add([Double.NaN, Double.NaN, Double.NaN, 1870.0]);
        shearStrengthList.Add([Double.NaN, Double.NaN, Double.NaN, 2085.0]);
        
        
        List<string> studBlockingList = new List<string>();
        
        studBlockingList.Add("No");
        studBlockingList.Add("No");
        studBlockingList.Add("No");
        studBlockingList.Add("No");
        studBlockingList.Add("No");
        studBlockingList.Add("Yes");
        studBlockingList.Add("No");
        studBlockingList.Add("No");
        studBlockingList.Add("Yes");
        studBlockingList.Add("No");
        studBlockingList.Add("Yes");
        
        List<int> designationThicknessList = new List<int>();
        
        designationThicknessList.Add(33);
        designationThicknessList.Add(43);
        designationThicknessList.Add(33);
        designationThicknessList.Add(33);
        designationThicknessList.Add(43);
        designationThicknessList.Add(43);
        designationThicknessList.Add(33);
        designationThicknessList.Add(43);
        designationThicknessList.Add(43);
        designationThicknessList.Add(54);
        designationThicknessList.Add(54);
        
        List<int> screwSizeList = new List<int>();
        
        screwSizeList.Add(8);
        screwSizeList.Add(8);
        screwSizeList.Add(8);
        screwSizeList.Add(8);
        screwSizeList.Add(8);
        screwSizeList.Add(10);
        screwSizeList.Add(8);
        screwSizeList.Add(8);
        screwSizeList.Add(10);
        screwSizeList.Add(8);
        screwSizeList.Add(10);
        
        
        Dictionary<WallInputs, double> table = new Dictionary<WallInputs, double>();
        
        for (int i = 0; i < sheathingList.Count; i++) 
        {
            for (int j = 0; j < fastenerSpacingList.Count; i++)
            {
                table.Add (new WallInputs(sheathingList[i], maxAspectRatioList[i], fastenerSpacingList[j], studBlockingList[i],  designationThicknessList[i], screwSizeList[i]), shearStrengthList[i][j]);

            }
       
        }
        
        return table;
    }
}