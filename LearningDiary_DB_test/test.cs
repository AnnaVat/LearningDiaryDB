using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


public class test

{

    public test()
    {

    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public double EstimatedTimeToMaster { get; set; }

    public double TimeSpent { get; set; }
    public string Source { get; set; }
    public DateTime StartLearningDate { get; set; }
    public bool InProgress { get; set; }
    public DateTime CompletionDate { get; set; }


    public override string ToString()
    {
        string Result = "";
        String Separator = ",";
        Result += Id + Separator;
        Result += Title + Separator;
        Result += Description + Separator;
        Result += EstimatedTimeToMaster + Separator;
        Result += TimeSpent + Separator;
        Result += Source + Separator;
        Result += StartLearningDate + Separator;
        Result += InProgress + Separator;
        Result += CompletionDate;

        return Result;

    }

}