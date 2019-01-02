using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQStudio
{
    class Program
    {
        static void Main(string[] args)
        {
            School.GetHighMarks();
            NestedGroupQuery.QueryNestedGroups();
            BasicLinqQuery.BasicQuery();
            GroupByExamples.GroupByEx1();
        }
    }
}