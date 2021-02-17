using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public double ExecuteTask(int totalThreads)
        {
            List<Task> lista = new List<Task>();
            double promedio = 0.0;
            double[] arr=new double[totalThreads];

            for (int i =0;i<totalThreads;i++) {

                var totask = new Task(() =>
                {
                    var tupla = balanceTheLoad(totalThreads, this.values.ToArray().Length, i);
                    
                    arr[i]=CalculateAverage(this.values.ToArray(), tupla[0], tupla[1]);
                });
            }

            promedio = arr.Sum();
            return promedio;
        }

        public double ExecuteParallel(int totalThreads)
        {
            double promedio = 0.0;
            double[] arr=new double[totalThreads];
            Parallel.For(0, totalThreads, i =>
            {
                var tupla = balanceTheLoad(totalThreads, this.values.ToArray().Length, i);
                    
                arr[i]=CalculateAverage(this.values.ToArray(), tupla[0], tupla[1]);
            });
            promedio = arr.Sum();
            return promedio;
        }

    }
}
