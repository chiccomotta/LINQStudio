using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQStudio
{
    class Program
    {
        static void Main(string[] args)
        {
            TestIntersect.Test();
            
            return;

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