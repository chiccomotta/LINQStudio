using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LINQStudio
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Stopwatch();
            timer.Start();
                
            System.Threading.Thread.Sleep(3000);

            timer.Stop();

            var timeTaken = timer.Elapsed;
            Console.WriteLine($"Time elapsed: {timeTaken.TotalMilliseconds} ms");
            Console.WriteLine($"Time elapsed: {timeTaken.TotalSeconds} sec");
            Console.WriteLine($"Time elapsed: {Math.Round(timeTaken.TotalMilliseconds / 1000, MidpointRounding.AwayFromZero)} sec");

            Console.ReadLine();
            return;

            TestIntersect.Test();
            SimpleGroupBy.BasicGroupBy();
            School.GetHighMarks();
            NestedGroupQuery.QueryNestedGroups();
            BasicLinqQuery.BasicQuery();
            GroupByExamples.GroupByEx1();
            LeftJoinExample.LeftOuterJoinExample();

            var media = new MediaParameter()
            {
                Fase = "CD.MEDIA",
                FlowType = "SS",
                AutostradaCodice = 31139
            };

            var builder = new KeyValuePairBuilder();
            var result = builder.BuildKeyValuePair(media);

            Console.WriteLine("OK");
        }
    }
}