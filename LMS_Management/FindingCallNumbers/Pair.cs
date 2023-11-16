using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LMS_Management.FindingCallNumbers
{
    public class Pair : IComparable<Pair>
    {

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        //Code Attribution
        //Link:https://stackoverflow.com/questions/37769751/c-sharp-generic-class-types-and-icomparable-cannot-compare-type-t
        //Author: Rob Lyndon
        public int CompareTo(Pair other)
        {
            return Number.CompareTo(other.Number);
        }
    }
}
