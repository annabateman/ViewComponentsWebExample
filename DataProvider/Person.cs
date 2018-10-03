using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace DataProvider
{
    public class Person
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public int Mass { get; set; }

        [JsonProperty("hair_color")]
        public string HairColor { get; set; }

        [JsonProperty("eye_color")]
        public string EyeColor { get; set; }

        [JsonProperty("birth_year")]
        public string BirthYear { get; set; }

        public string Gender { get; set; }

        public string HomeWorld { get; set; }

        public string Url { get; set; }
        
        public int Id => int.Parse(Regex.Match(Url, @"\d+").Value);
    }
}
