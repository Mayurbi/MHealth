using Microsoft.AspNetCore.Razor.TagHelpers;

namespace GlobalSolution.TagHelpers
{
    public class MessageTagHelper : TagHelper
    {
        public required string Mensagem { get; set; }

        public override void Process(
                   TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "alert alert-danger");
            output.Content.SetContent(Mensagem);
        }
    }
}

