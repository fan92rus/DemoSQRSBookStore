using System.Text.RegularExpressions;

namespace App.Models.Filters
{
    public class TextFilter : IFilter<string>
    {

        public TextFilter(string value)
        {
            this.Value = value;
        }
        public string Value { get; set; }
        public bool Check(string value) => Regex.IsMatch(value, this.Value, RegexOptions.IgnoreCase);

        public static explicit operator TextFilter(string value) => new TextFilter(value);
    }
}