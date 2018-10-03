using DataProvider;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;


namespace ViewComponentsWebExample.CustomComponents {
    public class FilmDetailTagHelper : TagHelper {

        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output) {
            if (For == null) {
                output.Content.SetContent("No Film to display");
                return;
            }
            Film film = (Film)For.Model;

            TagBuilder outerDiv = new TagBuilder("div");

            TagBuilder label = new TagBuilder("label");
            label.InnerHtml.AppendHtml(nameof(film.Title).CamelCaseToWords());
            outerDiv.InnerHtml.AppendHtml(label);

            TagBuilder div = new TagBuilder("div");
            div.InnerHtml.AppendHtml(film.Title);
            outerDiv.InnerHtml.AppendHtml(div);

            label = new TagBuilder("label");
            label.InnerHtml.AppendHtml(nameof(film.OpeningCrawl).CamelCaseToWords());
            outerDiv.InnerHtml.AppendHtml(label);

            div = new TagBuilder("div");
            div.InnerHtml.AppendHtml(film.OpeningCrawl);
            outerDiv.InnerHtml.AppendHtml(div);

            output.Content.SetHtmlContent(outerDiv);
        }
    }
}
