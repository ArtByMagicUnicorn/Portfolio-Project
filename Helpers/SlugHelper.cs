using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Portfolio_Project.Helpers;

public static class SlugHelper
{
    public static string GenerateSlug(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return string.Empty;
        }

        var normalized = value.Trim().ToLowerInvariant().Normalize(NormalizationForm.FormD);

        var builder = new StringBuilder();

        foreach (var character in normalized)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(character);

            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                builder.Append(character);
            }
        }

        var withoutDiacritics = builder.ToString().Normalize(NormalizationForm.FormC);

        var slug = Regex.Replace(withoutDiacritics, @"[^a-z0-9\s-]", "");
        slug = Regex.Replace(slug, @"[\s-]+", "-");
        slug = slug.Trim('-');

        return slug;
    }
}