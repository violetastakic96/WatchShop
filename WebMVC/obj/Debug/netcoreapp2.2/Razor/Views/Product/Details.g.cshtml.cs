#pragma checksum "C:\Users\Nemanja\source\repos\WatchShop\WebMVC\Views\Product\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91bda5fd6a37b44e48160a432ac859319d73f798"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Details), @"mvc.1.0.view", @"/Views/Product/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Product/Details.cshtml", typeof(AspNetCore.Views_Product_Details))]
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
#line 1 "C:\Users\Nemanja\source\repos\WatchShop\WebMVC\Views\_ViewImports.cshtml"
using WebMVC;

#line default
#line hidden
#line 2 "C:\Users\Nemanja\source\repos\WatchShop\WebMVC\Views\_ViewImports.cshtml"
using WebMVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91bda5fd6a37b44e48160a432ac859319d73f798", @"/Views/Product/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d07e873f05b36c9d83cd6a184d4bfbe1720fee4b", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Business.DataTransferObjects.ShowProductDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(52, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Nemanja\source\repos\WatchShop\WebMVC\Views\Product\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(97, 137, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>ShowProductDto</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(235, 40, false);
#line 14 "C:\Users\Nemanja\source\repos\WatchShop\WebMVC\Views\Product\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(275, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(339, 36, false);
#line 17 "C:\Users\Nemanja\source\repos\WatchShop\WebMVC\Views\Product\Details.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(375, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(438, 47, false);
#line 20 "C:\Users\Nemanja\source\repos\WatchShop\WebMVC\Views\Product\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(485, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(549, 43, false);
#line 23 "C:\Users\Nemanja\source\repos\WatchShop\WebMVC\Views\Product\Details.cshtml"
       Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(592, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(655, 41, false);
#line 26 "C:\Users\Nemanja\source\repos\WatchShop\WebMVC\Views\Product\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(696, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(760, 37, false);
#line 29 "C:\Users\Nemanja\source\repos\WatchShop\WebMVC\Views\Product\Details.cshtml"
       Write(Html.DisplayFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(797, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(860, 46, false);
#line 32 "C:\Users\Nemanja\source\repos\WatchShop\WebMVC\Views\Product\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Waterproof));

#line default
#line hidden
            EndContext();
            BeginContext(906, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(970, 42, false);
#line 35 "C:\Users\Nemanja\source\repos\WatchShop\WebMVC\Views\Product\Details.cshtml"
       Write(Html.DisplayFor(model => model.Waterproof));

#line default
#line hidden
            EndContext();
            BeginContext(1012, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1075, 44, false);
#line 38 "C:\Users\Nemanja\source\repos\WatchShop\WebMVC\Views\Product\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Warranty));

#line default
#line hidden
            EndContext();
            BeginContext(1119, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1183, 40, false);
#line 41 "C:\Users\Nemanja\source\repos\WatchShop\WebMVC\Views\Product\Details.cshtml"
       Write(Html.DisplayFor(model => model.Warranty));

#line default
#line hidden
            EndContext();
            BeginContext(1223, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1286, 46, false);
#line 44 "C:\Users\Nemanja\source\repos\WatchShop\WebMVC\Views\Product\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AvailCount));

#line default
#line hidden
            EndContext();
            BeginContext(1332, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1396, 42, false);
#line 47 "C:\Users\Nemanja\source\repos\WatchShop\WebMVC\Views\Product\Details.cshtml"
       Write(Html.DisplayFor(model => model.AvailCount));

#line default
#line hidden
            EndContext();
            BeginContext(1438, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1501, 45, false);
#line 50 "C:\Users\Nemanja\source\repos\WatchShop\WebMVC\Views\Product\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Mechanism));

#line default
#line hidden
            EndContext();
            BeginContext(1546, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1610, 41, false);
#line 53 "C:\Users\Nemanja\source\repos\WatchShop\WebMVC\Views\Product\Details.cshtml"
       Write(Html.DisplayFor(model => model.Mechanism));

#line default
#line hidden
            EndContext();
            BeginContext(1651, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1714, 42, false);
#line 56 "C:\Users\Nemanja\source\repos\WatchShop\WebMVC\Views\Product\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Gender));

#line default
#line hidden
            EndContext();
            BeginContext(1756, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1820, 38, false);
#line 59 "C:\Users\Nemanja\source\repos\WatchShop\WebMVC\Views\Product\Details.cshtml"
       Write(Html.DisplayFor(model => model.Gender));

#line default
#line hidden
            EndContext();
            BeginContext(1858, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1921, 41, false);
#line 62 "C:\Users\Nemanja\source\repos\WatchShop\WebMVC\Views\Product\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Brand));

#line default
#line hidden
            EndContext();
            BeginContext(1962, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2026, 37, false);
#line 65 "C:\Users\Nemanja\source\repos\WatchShop\WebMVC\Views\Product\Details.cshtml"
       Write(Html.DisplayFor(model => model.Brand));

#line default
#line hidden
            EndContext();
            BeginContext(2063, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(2111, 55, false);
#line 70 "C:\Users\Nemanja\source\repos\WatchShop\WebMVC\Views\Product\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new {  id = Model.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(2166, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(2174, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "91bda5fd6a37b44e48160a432ac859319d73f79811823", async() => {
                BeginContext(2196, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2212, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Business.DataTransferObjects.ShowProductDto> Html { get; private set; }
    }
}
#pragma warning restore 1591