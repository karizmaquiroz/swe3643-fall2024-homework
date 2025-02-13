namespace Homework2.Console;

public static class Program

{
    public static void Main()
    {
        List<double> sampleValuesList = new List<double> { 9, 6, 8, 5, 7 };
        double sampleStdDev = DescriptiveStatistics.ComputeSampleStandardDeviation(sampleValuesList);

        Console.WriteLine("Sample StdDev =" + sampleStdDev);
        //# Writes "Sample StdDev=1.5811388300841898"
        //# From https://www.cuemath.com/sample-standard-deviation-formula/
        
        
         

        List<double> populationValuesList = new List<double> { 9, 2, 5, 4, 12, 7, 8, 11, 9, 3, 7, 4, 12, 5, 4, 10, 9, 6, 9, 4 };
        double popStdDev = DescriptiveStatistics.ComputePopulationStandardDeviation(populationValuesList);
        Console.WriteLine("Population StdDev =" + popStdDev);
        //# Writes "Population StdDev=2.9832867780352594"
        //# From https://www.thoughtco.com/population-standard-deviation-calculation-609522*/
        
    }
}