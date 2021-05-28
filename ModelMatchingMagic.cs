using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ModelMatchingMagic
{

    public class ModelMatchingMagic
    {
        public List<Model_Override> model_overrides { get; set; } = new List<Model_Override>();
        public List<Airline_Group> airline_groups { get; set; } = new List<Airline_Group>();
        public List<Aircraft_Type> aircraft_types { get; set; } = new List<Aircraft_Type>();

        public string path { get; set; }
        public bool include_IVAO_models { get; set; }
    }

    public class Model_Override
    {
        public string model { get; set; }
        public string airline { get; set; }
        public string type { get; set; }
        public bool? exclude { get; set; }
    }

    public class Airline_Group
    {
        public string name { get; set; }
        public string[] codes { get; set; }
    }

    public class Aircraft_Type
    {
        public string type { get; set; }
        
        private string _regexStr;
        private Regex _regex;
        public string regex { 
            get
            {
                return _regexStr;
            }
            set
            {
                _regexStr = value;
                _regex = null;
            }
        }
        public bool isMatch(string input)
        {
            if (String.IsNullOrWhiteSpace(_regexStr))
            {
                return false;
            }
            if (_regex == null)
            {
                _regex = new Regex(_regexStr);
            }
            return _regex.IsMatch(input);
        }

        public Tags tags { get; set; }
    }

    public class Tags
    {
        public string manufacturer { get; set; }
        public int size { get; set; }
        public string engine { get; set; }
    }

}
