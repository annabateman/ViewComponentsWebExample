using DataProvider;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;


namespace ViewComponentsWebExample.CustomComponents {
    public class FilmDetailTagHelper : TagHelper {

        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

        public bool ShowDetails { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output) {
            if (For == null) {
                output.Content.SetContent("No Film to display");
                return;
            }
            Film film = (Film)For.Model;
            output.TagName = "div";

            TagBuilder label = new TagBuilder("label");
            label.InnerHtml.AppendHtml(nameof(film.Title).CamelCaseToWords());
            output.Content.AppendHtml(label);

            TagBuilder div = new TagBuilder("div");
            div.InnerHtml.AppendHtml(film.Title);
            output.Content.AppendHtml(div);
            if (ShowDetails) { 
                label = new TagBuilder("label");
                label.InnerHtml.AppendHtml(nameof(film.OpeningCrawl).CamelCaseToWords());
                output.Content.AppendHtml(label);

                div = new TagBuilder("div");
                div.InnerHtml.AppendHtml(film.OpeningCrawl);
                output.Content.AppendHtml(div);
            }
        }
    }
}
