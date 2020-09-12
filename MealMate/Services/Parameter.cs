using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace MealMate.Services
{
    public class Parameter
    {
        [JsonProperty]
        public string searchbarInput { get; set; }
        [JsonProperty]
        public IEnumerable<int> familyMembers { get; set; }
        [JsonProperty]
        public bool famBlackList { get; set; }
        [JsonProperty]
        public bool usePantryLimits { get; set; }
        [JsonProperty]
        public bool prepTimePivot { get; set; }
        [JsonProperty]
        public bool cookTimePivot { get; set; }
        [JsonProperty]
        public bool CalPivot { get; set; }

        internal IEnumerable<string> searchSettings { get; set; }
        public string search { get; set; }

        public void Normalize()
        {
            string search = this.searchbarInput;
            Regex keyFinder = new Regex(@"(\B:\w+)\s");
            List<string> param = new List<string>();

            while (true)
            {
                Match match = keyFinder.Match(search);
                if (match.Value == "")
                {
                    break;
                }
                param.Add(match.Value);
                search = search.Remove(match.Index, match.Length);
            }
            searchSettings = param.AsEnumerable<string>();
        }
    }
}
