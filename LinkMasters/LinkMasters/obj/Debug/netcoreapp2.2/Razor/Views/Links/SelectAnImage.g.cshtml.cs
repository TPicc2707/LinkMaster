#pragma checksum "C:\Development\LinkMasters\LinkMasters\Views\Links\SelectAnImage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "03463394dcf520a63c1d276e60b9979310eaa9dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Links_SelectAnImage), @"mvc.1.0.view", @"/Views/Links/SelectAnImage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Links/SelectAnImage.cshtml", typeof(AspNetCore.Views_Links_SelectAnImage))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03463394dcf520a63c1d276e60b9979310eaa9dc", @"/Views/Links/SelectAnImage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b3a952862e55d763632cc5551ece4e83ab851d6", @"/Views/_ViewImports.cshtml")]
    public class Views_Links_SelectAnImage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LinkMasters.Models.Link>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Development\LinkMasters\LinkMasters\Views\Links\SelectAnImage.cshtml"
  
    ViewData["Title"] = "SelectAnImage";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(141, 57, true);
            WriteLiteral("\r\n<div class=\"container-fluid2\">\r\n    <div class=\"row\">\r\n");
            EndContext();
#line 9 "C:\Development\LinkMasters\LinkMasters\Views\Links\SelectAnImage.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(247, 176, true);
            WriteLiteral("            <div class=\"handy-link\">\r\n                <div class=\"thumbex3\">\r\n                    <div class=\"thumbnail3\">                  \r\n                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 423, "\"", 485, 1);
#line 14 "C:\Development\LinkMasters\LinkMasters\Views\Links\SelectAnImage.cshtml"
WriteAttributeValue("", 430, Url.Action("chooseImage","Links", new { id = item.Id}), 430, 55, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(486, 5, true);
            WriteLiteral("><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 491, "\"", 541, 1);
#line 14 "C:\Development\LinkMasters\LinkMasters\Views\Links\SelectAnImage.cshtml"
WriteAttributeValue("", 497, Url.Content("~/Images/Default/Default.jpg"), 497, 44, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(542, 29, true);
            WriteLiteral(" /><span class=\"image-title\">");
            EndContext();
            BeginContext(572, 13, false);
#line 14 "C:\Development\LinkMasters\LinkMasters\Views\Links\SelectAnImage.cshtml"
                                                                                                                                                                                 Write(item.Nickname);

#line default
#line hidden
            EndContext();
            BeginContext(585, 85, true);
            WriteLiteral("</span></a>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 18 "C:\Development\LinkMasters\LinkMasters\Views\Links\SelectAnImage.cshtml"
        }

#line default
#line hidden
            BeginContext(681, 18, true);
            WriteLiteral("    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LinkMasters.Models.Link>> Html { get; private set; }
    }
}
#pragma warning restore 1591