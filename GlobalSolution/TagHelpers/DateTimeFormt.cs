using Microsoft.AspNetCore.Razor.TagHelpers;

namespace GlobalSolution.TagHelpers
{
    [HtmlTargetElement("formatted-datetime", Attributes = "datetime")]
    public class DateTimeFormt : TagHelper
    {
        public DateTime DateTime { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            output.Content.SetContent(DateTime.ToString("dd/MM/yyyy HH:mm:ss"));
        }
    }
}
