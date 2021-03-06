#pragma checksum "C:\Development\LinkMasters\LinkMasters\Views\Budgets\PeopleMonthlyBudget.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90b21ca1bcbd72b98d54b56893b012f54f7d45a9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Budgets_PeopleMonthlyBudget), @"mvc.1.0.view", @"/Views/Budgets/PeopleMonthlyBudget.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Budgets/PeopleMonthlyBudget.cshtml", typeof(AspNetCore.Views_Budgets_PeopleMonthlyBudget))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90b21ca1bcbd72b98d54b56893b012f54f7d45a9", @"/Views/Budgets/PeopleMonthlyBudget.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b3a952862e55d763632cc5551ece4e83ab851d6", @"/Views/_ViewImports.cshtml")]
    public class Views_Budgets_PeopleMonthlyBudget : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LinkMasters.Models.Budget>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Development\LinkMasters\LinkMasters\Views\Budgets\PeopleMonthlyBudget.cshtml"
  
    ViewData["Title"] = "SpecificMonthBudget";
    Layout = "~/Views/Shared/_BudgetLayout.cshtml";

#line default
#line hidden
            BeginContext(155, 282, true);
            WriteLiteral(@"
<div class=""col-lg-9 budget-div"">
    <table class=""budget-table"">
        <thead class=""budget-head"">
            <tr class=""budget-tr"">
                <th class=""budget-th"" colspan=""14""><h1 style=""text-align: center"">Everyone's Daily Expenses</h1></th>
            </tr>
");
            EndContext();
            BeginContext(1669, 541, true);
            WriteLiteral(@"            <tr class=""budget-tr"">
                <th colspan=""2"" class=""budget-th"">Name</th>
                <th colspan=""2"" class=""budget-th"">Expense</th>
                <th colspan=""2"" class=""budget-th"">Place</th>
                <th colspan=""2"" class=""budget-th"">Cost</th>
                <th colspan=""2"" class=""budget-th"">Day</th>
                <th colspan=""2"" class=""budget-th"">Month</th>
                <th colspan=""2"" class=""budget-th"">Year</th>
            </tr>
        </thead>
        <tbody class=""budget-body"">
");
            EndContext();
#line 42 "C:\Development\LinkMasters\LinkMasters\Views\Budgets\PeopleMonthlyBudget.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(2267, 94, true);
            WriteLiteral("                <tr class=\"budget-tr\">\r\n                    <td colspan=\"2\" class=\"budget-td\">");
            EndContext();
            BeginContext(2362, 20, false);
#line 45 "C:\Development\LinkMasters\LinkMasters\Views\Budgets\PeopleMonthlyBudget.cshtml"
                                                 Write(item.Person.FullName);

#line default
#line hidden
            EndContext();
            BeginContext(2382, 61, true);
            WriteLiteral("</td>\r\n                    <td colspan=\"2\" class=\"budget-td\">");
            EndContext();
            BeginContext(2444, 12, false);
#line 46 "C:\Development\LinkMasters\LinkMasters\Views\Budgets\PeopleMonthlyBudget.cshtml"
                                                 Write(item.Expense);

#line default
#line hidden
            EndContext();
            BeginContext(2456, 61, true);
            WriteLiteral("</td>\r\n                    <td colspan=\"2\" class=\"budget-td\">");
            EndContext();
            BeginContext(2518, 10, false);
#line 47 "C:\Development\LinkMasters\LinkMasters\Views\Budgets\PeopleMonthlyBudget.cshtml"
                                                 Write(item.Place);

#line default
#line hidden
            EndContext();
            BeginContext(2528, 62, true);
            WriteLiteral("</td>\r\n                    <td colspan=\"2\" class=\"budget-td\">$");
            EndContext();
            BeginContext(2591, 33, false);
#line 48 "C:\Development\LinkMasters\LinkMasters\Views\Budgets\PeopleMonthlyBudget.cshtml"
                                                  Write(String.Format("{0:n}", item.Cost));

#line default
#line hidden
            EndContext();
            BeginContext(2624, 61, true);
            WriteLiteral("</td>\r\n                    <td colspan=\"2\" class=\"budget-td\">");
            EndContext();
            BeginContext(2686, 19, false);
#line 49 "C:\Development\LinkMasters\LinkMasters\Views\Budgets\PeopleMonthlyBudget.cshtml"
                                                 Write(item.Day.DayOfMonth);

#line default
#line hidden
            EndContext();
            BeginContext(2705, 61, true);
            WriteLiteral("</td>\r\n                    <td colspan=\"2\" class=\"budget-td\">");
            EndContext();
            BeginContext(2767, 19, false);
#line 50 "C:\Development\LinkMasters\LinkMasters\Views\Budgets\PeopleMonthlyBudget.cshtml"
                                                 Write(item.Calendar.Month);

#line default
#line hidden
            EndContext();
            BeginContext(2786, 61, true);
            WriteLiteral("</td>\r\n                    <td colspan=\"2\" class=\"budget-td\">");
            EndContext();
            BeginContext(2848, 18, false);
#line 51 "C:\Development\LinkMasters\LinkMasters\Views\Budgets\PeopleMonthlyBudget.cshtml"
                                                 Write(item.Calendar.Year);

#line default
#line hidden
            EndContext();
            BeginContext(2866, 30, true);
            WriteLiteral("</td>\r\n                </tr>\r\n");
            EndContext();
#line 53 "C:\Development\LinkMasters\LinkMasters\Views\Budgets\PeopleMonthlyBudget.cshtml"
            }

#line default
#line hidden
            BeginContext(2911, 44, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n\r\n");
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
