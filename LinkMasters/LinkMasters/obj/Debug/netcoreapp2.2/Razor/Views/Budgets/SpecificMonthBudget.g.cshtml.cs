#pragma checksum "C:\Development\LinkMasters\LinkMasters\Views\Budgets\SpecificMonthBudget.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87cb9f0a20148b9069792ea4039502bb16daf3ed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Budgets_SpecificMonthBudget), @"mvc.1.0.view", @"/Views/Budgets/SpecificMonthBudget.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Budgets/SpecificMonthBudget.cshtml", typeof(AspNetCore.Views_Budgets_SpecificMonthBudget))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Development\LinkMasters\LinkMasters\Views\_ViewImports.cshtml"
using LinkMasters;

#line default
#line hidden
#line 2 "C:\Development\LinkMasters\LinkMasters\Views\_ViewImports.cshtml"
using LinkMasters.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87cb9f0a20148b9069792ea4039502bb16daf3ed", @"/Views/Budgets/SpecificMonthBudget.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b3a952862e55d763632cc5551ece4e83ab851d6", @"/Views/_ViewImports.cshtml")]
    public class Views_Budgets_SpecificMonthBudget : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LinkMasters.Models.Budget>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("padding-left: 30px; padding-right: 30px; text-align: center;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "YearBudget", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Budgets", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Development\LinkMasters\LinkMasters\Views\Budgets\SpecificMonthBudget.cshtml"
  
    ViewData["Title"] = "SpecificMonthBudget";
    Layout = "~/Views/Shared/_BudgetLayout.cshtml";

#line default
#line hidden
            BeginContext(155, 225, true);
            WriteLiteral("\r\n<div class=\"col-lg-9 budget-div\">\r\n    <table class=\"budget-table\">\r\n        <thead class=\"budget-head\">\r\n            <tr class=\"budget-tr\">\r\n                <th class=\"budget-th\" colspan=\"8\"><h1 style=\"text-align: center\">");
            EndContext();
            BeginContext(381, 13, false);
#line 11 "C:\Development\LinkMasters\LinkMasters\Views\Budgets\SpecificMonthBudget.cshtml"
                                                                            Write(ViewBag.Month);

#line default
#line hidden
            EndContext();
            BeginContext(394, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(396, 12, false);
#line 11 "C:\Development\LinkMasters\LinkMasters\Views\Budgets\SpecificMonthBudget.cshtml"
                                                                                           Write(ViewBag.Year);

#line default
#line hidden
            EndContext();
            BeginContext(408, 31, true);
            WriteLiteral("</h1></th>\r\n            </tr>\r\n");
            EndContext();
            BeginContext(1615, 357, true);
            WriteLiteral(@"            <tr class=""budget-tr"">
                <th colspan=""2"" class=""budget-th"">Expense</th>
                <th colspan=""2"" class=""budget-th"">Place</th>
                <th colspan=""2"" class=""budget-th"">Cost</th>
                <th colspan=""2"" class=""budget-th"">Day</th>
            </tr>
        </thead>
        <tbody class=""budget-body"">
");
            EndContext();
#line 39 "C:\Development\LinkMasters\LinkMasters\Views\Budgets\SpecificMonthBudget.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(2029, 94, true);
            WriteLiteral("                <tr class=\"budget-tr\">\r\n                    <td colspan=\"2\" class=\"budget-td\">");
            EndContext();
            BeginContext(2124, 12, false);
#line 42 "C:\Development\LinkMasters\LinkMasters\Views\Budgets\SpecificMonthBudget.cshtml"
                                                 Write(item.Expense);

#line default
#line hidden
            EndContext();
            BeginContext(2136, 61, true);
            WriteLiteral("</td>\r\n                    <td colspan=\"2\" class=\"budget-td\">");
            EndContext();
            BeginContext(2198, 10, false);
#line 43 "C:\Development\LinkMasters\LinkMasters\Views\Budgets\SpecificMonthBudget.cshtml"
                                                 Write(item.Place);

#line default
#line hidden
            EndContext();
            BeginContext(2208, 62, true);
            WriteLiteral("</td>\r\n                    <td colspan=\"2\" class=\"budget-td\">$");
            EndContext();
            BeginContext(2271, 33, false);
#line 44 "C:\Development\LinkMasters\LinkMasters\Views\Budgets\SpecificMonthBudget.cshtml"
                                                  Write(String.Format("{0:n}", item.Cost));

#line default
#line hidden
            EndContext();
            BeginContext(2304, 61, true);
            WriteLiteral("</td>\r\n                    <td colspan=\"2\" class=\"budget-td\">");
            EndContext();
            BeginContext(2366, 19, false);
#line 45 "C:\Development\LinkMasters\LinkMasters\Views\Budgets\SpecificMonthBudget.cshtml"
                                                 Write(item.Day.DayOfMonth);

#line default
#line hidden
            EndContext();
            BeginContext(2385, 30, true);
            WriteLiteral("</td>\r\n                </tr>\r\n");
            EndContext();
#line 47 "C:\Development\LinkMasters\LinkMasters\Views\Budgets\SpecificMonthBudget.cshtml"
            }

#line default
#line hidden
            BeginContext(2430, 68, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n<div class=\"back-btn\">\r\n    ");
            EndContext();
            BeginContext(2498, 210, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "87cb9f0a20148b9069792ea4039502bb16daf3ed9202", async() => {
                BeginContext(2700, 4, true);
                WriteLiteral("Back");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-personGuid", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 52 "C:\Development\LinkMasters\LinkMasters\Views\Budgets\SpecificMonthBudget.cshtml"
                                                                                                                                                               WriteLiteral(ViewBag.PersonGuid);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["personGuid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-personGuid", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["personGuid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2708, 14, true);
            WriteLiteral("\r\n</div>\r\n\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LinkMasters.Models.Budget>> Html { get; private set; }
    }
}
#pragma warning restore 1591
