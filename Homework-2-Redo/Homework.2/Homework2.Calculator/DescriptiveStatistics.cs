namespace Homework2.Console;

using System;
using System.Collections.Generic;

public class DescriptiveStatistics
{



    //# Function to compute the mean (average) of a list of values
    //Function COMPUTE_MEAN(valuesList:
    public static double ComputeMean(List<double> valuesList)
    {
        // If valuesList is empty: Raise Error "valuesList parameter cannot be null or empty"
        if (valuesList == null || valuesList.Count == 0)
        {
            throw new ArgumentException("valuesList parameter cannot be null or empty");
        }

        //sumAccumulator = 0
        double sumAccumulator = 0;
        //For each value in valuesList:
        foreach (var value in valuesList)
        {
            //sumAccumulator = sumAccumulator + value
            sumAccumulator += value;
        }

        return (sumAccumulator / valuesList.Count);
        //# Return the average (sum divided by the number of values we accumulated)
        //Return sumAccumulator / (Number of values in valuesList)
    }

    //# Function to compute the sum of squared differences from the mean
    //Function COMPUTE_SQUARE_OF_DIFFERENCES(valuesList, mean):
    public static double ComputeSquareOfDifferences(List<double> valuesList, double mean)
    {
        //If valuesList is empty:
        //Raise Error "valuesList parameter cannot be null or empty"
        if (valuesList == null || valuesList.Count == 0)
        {
            throw new ArgumentException("valuesList parameter cannot be null or empty");
        }

        //squareAccumulator = 0
        double squareAccumulator = 0;

        //For each value in valuesList:
        foreach (var value in valuesList)
        {
            //difference = value - mean
            double difference = value - mean;
            //squareOfDifference = difference * difference
            double squareOfDifference = difference * difference;
            //squareAccumulator = squareAccumulator + squareOfDifference
            squareAccumulator += squareOfDifference;
        }

        //Return squareAccumulator
        return squareAccumulator;
    }

    //# Function to compute the variance based on squared differences
    public static double ComputeVariance(double squareOfDifferences, int numValues, bool isPopulation)
    {
        /*
        //#   Set isPopulation to true
        isPopulation = true;
        if (isPopulation == true)
        {
            //compute a population standard deviation in COMPUTE_VARIANCE
        }

        isPopulation = false;
        if (isPopulation == false)
        {
            //compute a sample standard deviation in COMPUTE_VARIANCE
        }*/


        //Function COMPUTE_VARIANCE(squareOfDifferences, numValues, isPopulation):

        //# Adjust number of values by minus one if sample where sample is indicated by (not isPopulation)
        //# https://www.quora.com/On-the-sample-standard-deviation-why-do-we-subtract-N-by-1
        //If not isPopulation:
        if (!isPopulation)
        {
            //numValues = numValues - 1
            numValues = numValues - 1;
        }


        //# Test numValues after adjusting for change to numValues 
        //#    We cannot allow numValues to be a 0 denominator (division by zero / undefined)
        //If numValues < 1:
        if (numValues < 1)
        {
            //Raise Error "numValues is too low (sample size must be >= 2, population size must be >= 1)"
            throw new ArgumentException(
                "numValues is to low (samplesize must be >= 2, population size must be >=1");
        }

        //Return squareOfDifferences / numValues
        return (squareOfDifferences / numValues);
    }


    //Function to compute the population or sample standard deviation from a list of values
    //Function COMPUTE_STANDARD_DEVIATION(valuesList, isPopulation):
    static double ComputeStandardDeviation(List<double> valuesList, bool isPopulation)
    {
        //If valuesList is empty:
        if (valuesList == null || valuesList.Count == 0)
        {
            //Raise Error "valuesList parameter cannot be null or empty"
            throw new ArgumentException("valuesList parameter cannot be null or empty");
        }

        //mean = COMPUTE_MEAN(valuesList)
        double mean = ComputeMean(valuesList);
        //squareOfDifferences = COMPUTE_SQUARE_OF_DIFFERENCES(valuesList, mean)
        double squareOfDifferences = ComputeSquareOfDifferences(valuesList, mean);
        //variance = COMPUTE_VARIANCE(squareOfDifferences, (Number of values in valuesList), isPopulation)
        double variance = ComputeVariance(squareOfDifferences, valuesList.Count, isPopulation);
        //Return SquareRoot(variance)
        return Math.Sqrt(variance);
        //where SquareRoot is a math function to compute the square root of the variance
    }

    public static double ComputeSampleStandardDeviation(List<double> valuesList)
    {
        return ComputeStandardDeviation(valuesList, false);
    }

    public static double ComputePopulationStandardDeviation(List<double> valuesList)
    {
        return ComputeStandardDeviation(valuesList, true);
    }
}   
