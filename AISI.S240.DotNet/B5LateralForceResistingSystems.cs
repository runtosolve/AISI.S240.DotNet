namespace AISI.S240.DotNet;

public class B5LateralForceResistingSystems
{
    public static Dictionary<string, double> TableB5_2_2_3__1()
    {

        Dictionary<string, Dictionary<string, double>> table = new Dictionary<string, Dictionary<string, double>>();
        
        
        Dictionary<string, double> wallShearStrength = new Dictionary<string, double>();

        wallShearStrength.Add("6/12", 485.0);
        wallShearStrength.Add("4/12", Double.NaN);
        wallShearStrength.Add("3/12", Double.NaN);
        wallShearStrength.Add("2/12", Double.NaN);

        table.Add("0.18 in. steel sheet", wallShearStrength);
        
        return wallShearStrength;
    }

}