using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LMS_Management.FindingCallNumbers
{
    public class CreateTreeFile
    {
        public string TreeFileName = "Tree.json";

        //Code Attribution
        //Link: https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/how-to?pivots=dotnet-8-0
        //Author: Microsoft
        public void CreateFile()
        {
            PopulateTree populateTree = new PopulateTree();
            Tree<Pair> tree = populateTree.CreateTree();

            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

            string json = JsonSerializer.Serialize(tree, options);

            using StreamWriter streamWriter = File.CreateText(TreeFileName);
            streamWriter.WriteLine(json);
        }

        public Tree<Pair> ReadFile()
        {
            return JsonSerializer.Deserialize<Tree<Pair>>(File.ReadAllText(TreeFileName));
        }

        public bool FileExists()
        {
            return File.Exists(TreeFileName);
        }
    }
}
