using Homework2;
using NUnit.Framework;

namespace Tests;

public class Tests
{
        //SystemUnderTest_StateBeingTested_ExpectedResults
    [Test]
    public void StandardDeviationCalculator_SampleStdDevReceivesNullList_ThrowException()
    {
        //arrange
        var input = new List<double>();

        //act + assert
        Assert.Throws<ArgumentException>(() =>
        {
            DescriptiveStatistics.ComputeSampleStandardDeviation(input);
        });
    }
    
    [Test]
    public void StandardDeviationCalculator_SampleStdDevReceivesList_ComputesCorrectly()
    {
        //arrange
        var input = new List<double> {  9, 6, 8, 5, 7 };

        //act
        var actual = DescriptiveStatistics.ComputeSampleStandardDeviation(input);
        
        //assert
        Assert.That(actual, Is.EqualTo(1.5811388300841898).Within(1e-16));
    }

    [Test]
    public void StandardDeviationCalculator_PopulationStdDevReceivesNullList_ThrowException()
    {
        //arrange
        var input = new List<double>();

        //act + assert
        Assert.Throws<ArgumentException>(() =>
        {
            DescriptiveStatistics.ComputePopulationStandardDeviation(input);
        });
    }
    [Test]
    public void StandardDeviationCalculator_PopulationStdDevReceivesList_ComputesCorrectly()
    {
        //arrange
        var input = new List<double> {   9, 2, 5, 4, 12, 7, 8, 11, 9, 3, 7, 4, 12, 5, 4, 10, 9, 6, 9, 4 };

        //act
        var actual = DescriptiveStatistics.ComputePopulationStandardDeviation(input);
        
        //assert
        Assert.That(actual, Is.EqualTo(2.9832867780352594).Within(1e-16));
    }

    [Test]
    public void StandardDeviationCalculator_ComputeMeanReceivesList_ComputesCorrectly()
    {
        // Arrange
        var valuesList = new List<double> { 1, 2, 3, 4, 5 };

        // Calculate expected mean manually
        var expectedMean = valuesList.Average();

        // Act
        var actualMean = DescriptiveStatistics.ComputeMean(valuesList);

        // Assert
        Assert.That(actualMean, Is.EqualTo(expectedMean).Within(1e-10));
    }

    [Test]
    public void StandardDeviationCalculator_ComputeMeanReceivesList_ThrowException()
    {
        // Arrange
        var emptyValuesList = new List<double>(); // Creates an empty list

        // Act + Assert
        Assert.That(() => Homework2.DescriptiveStatistics.ComputeMean(emptyValuesList),
            Throws.ArgumentException
                .With.Message.EqualTo("valuesList parameter cannot be null or empty"));
    }

   
    [Test]
    public void StandardDeviationCalculator_ComputeSqOfDiff_ThrowException()
    {
        // Arrange
        var emptyValuesList = new List<double>(); // Creates an empty list
        const double mean = 0.0; // Mean is irrelevant for an empty list but needs to be provided

        // Act + Assert
        Assert.That(() => DescriptiveStatistics.ComputeSquareOfDifferences(emptyValuesList, mean),
            Throws.ArgumentException
                .With.Message.EqualTo("valuesList parameter cannot be null or empty"));
    }

    [Test]
    public void StandardDeviationCalculator_ComputeSqOfDiff_ComputesCorrectly()
    {
            // Arrange
            var valuesList = new List<double> { 10, 8, 10, 8, 10 };
            var mean = valuesList.Average(); // Compute the mean

            // Compute the expected square of differences
            var expectedSquareOfDifferences = valuesList
                .Select(value => Math.Pow(value - mean, 2))
                .Sum();

            // Act
            var actualSquareOfDifferences =
                DescriptiveStatistics.ComputeSquareOfDifferences(valuesList, mean);

            // Assert
            Assert.That(actualSquareOfDifferences, Is.EqualTo(expectedSquareOfDifferences).Within(1e-10));
    }

    [Test]
    public void StandardDeviationCalculator_ComputePopVariance_ThrowException()
    {
        //arrange
        const int valueCount = 0;
        const bool isPopulation = true;
        const double squareOfDifferences = 0.0d;

        //act + assert
        //write assertion that calculator threw
        Assert.That(() => DescriptiveStatistics.ComputeVariance(squareOfDifferences, valueCount, isPopulation),
            Throws.ArgumentException
                .With.Message.StartsWith("numValues is too low"));
    }

    [Test]
    public void StandardDeviationCalculator_ComputeSampleVariance_ThrowException()
    {
        //arrange
        const int valueCount = 1;
        const bool isPopulation = false;
        const double squareOfDifferences = 0.0d;

        //act + assert
        //write assertion that calculator threw
        Assert.That(() => DescriptiveStatistics.ComputeVariance(squareOfDifferences, valueCount, isPopulation),
            Throws.ArgumentException
                .With.Message.StartsWith("numValues is too low"));
    }
    
    
}