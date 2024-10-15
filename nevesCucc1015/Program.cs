using nevesCucc1015.src;
using System.Collections.Concurrent;
using System.Text;

List<Competitor> competitors = new();

using StreamReader sr = new StreamReader(
    path: @"..\..\..\src\forras.txt",
    encoding: Encoding.UTF8
    );
while (!sr.EndOfStream)
{
    competitors.Add(new Competitor(sr.ReadLine()));
}
sr.Close();

Console.WriteLine($"Célba érkezők száma: {competitors.Count}");

//első célbaért női versenyző
var f1 = competitors.Where(x=> !x.Gender).MinBy(x => x.TotalTime);
Console.WriteLine($"első célbaért nő {f1}");

//hány % férfi a versenyzőknek
var f2 = competitors.Count(c=> c.Gender)/ (float)competitors.Count *100;
Console.WriteLine($"A versenyzőknek {f2:0.00}% férfi");

//átlagos depóban töltött idő
var f3 = competitors.Average(x => (x.RaceTimes["1st depot"] + x.RaceTimes["2nd depot"]).TotalSeconds)/2;
Console.WriteLine($"átlagosan depóban töltött idő: {f3:0.00}másodperc");

//korkategóriánként a versenyzők száma
var f4 = competitors.GroupBy(x => x.AgeCategory).OrderBy(x=> x.Key);

Console.WriteLine("versenyzők száma kategóriák szerint");
foreach (var f in f4)
{
    Console.WriteLine($"\t{f.Key,11} : {f.Count(),2}fő");
}