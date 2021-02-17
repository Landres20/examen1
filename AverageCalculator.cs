using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParallelismExam1.Console
{
    public class AverageCalculator
    {
        private readonly IEnumerable<double> values;

        public AverageCalculator(IEnumerable<double> values)
        {
            this.values = values;
        }

        public double Execute()
        {
            return CalculateAverage(this.values.ToArray(), 0, this.values.Count());
        }

        private double CalculateAverage(double[] listOfValues, int start, int end)
        {
            double average = 0;
            for (int i = start; i < end; i++)
            {
                average += listOfValues[i];
            }
            return average / (end - start);
        }

        private int[] balanceTheLoad(int availableThreads, int sizeOfList, int threadID){

            int indexPerThread=sizeOfList/availableThreads;

            int startPosition=indexPerThread*threadID;

            int endPosition=indexPerThread+startPosition;

            int[] retList={startPosition, endPosition};


            
            return retList;

        }

    }
}
