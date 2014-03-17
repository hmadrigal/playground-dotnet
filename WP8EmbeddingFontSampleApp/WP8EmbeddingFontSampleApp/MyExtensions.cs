namespace WP8EmbeddingFontSampleApp
{
    public static class MyExtensions
    {

        private static readonly System.Text.RegularExpressions.Regex _placeHolderRegEx = new System.Text.RegularExpressions.Regex(@"\[\w+\]", System.Text.RegularExpressions.RegexOptions.Compiled | System.Text.RegularExpressions.RegexOptions.CultureInvariant | System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Multiline);

        public static string ReplaceStringTemplate(this string stringTemplate, System.Collections.Generic.Dictionary<string, string> placeHolderValues, System.Text.RegularExpressions.Regex templateRegEx = null)
        {
            if (string.IsNullOrEmpty(stringTemplate))
                return stringTemplate ?? string.Empty;
            if (placeHolderValues == null)
                return stringTemplate ?? string.Empty;

            var selectedRegularExpression = _placeHolderRegEx ?? templateRegEx;
            var stringDocument = selectedRegularExpression.Replace(stringTemplate, (System.Text.RegularExpressions.Match match) =>
            {
                var foundMatch = match.ToString();
                var foundTemplateKey = foundMatch;
                return placeHolderValues.ContainsKey(foundTemplateKey) ? placeHolderValues[foundTemplateKey] : string.Empty;
            });
            return stringDocument;
        }

    }
}
