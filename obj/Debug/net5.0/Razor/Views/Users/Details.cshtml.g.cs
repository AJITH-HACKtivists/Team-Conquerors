#pragma checksum "C:\Users\Administrator\source\repos\PizzaHut\Views\Users\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "82905ac9f829b48964e4580e65b54c14ec234f82"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_Details), @"mvc.1.0.view", @"/Views/Users/Details.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Administrator\source\repos\PizzaHut\Views\_ViewImports.cshtml"
using PizzaHut;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Administrator\source\repos\PizzaHut\Views\_ViewImports.cshtml"
using PizzaHut.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82905ac9f829b48964e4580e65b54c14ec234f82", @"/Views/Users/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8efdecd17e5559cbb270cc9907425448905b2398", @"/Views/_ViewImports.cshtml")]
    public class Views_Users_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "82905ac9f829b48964e4580e65b54c14ec234f823238", async() => {
                WriteLiteral("\r\n    <title></title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "82905ac9f829b48964e4580e65b54c14ec234f824227", async() => {
                WriteLiteral("\r\n    <script>\r\n        alert(\"Added to Cart Successfully\");\r\n\r\n    </script>\r\n\r\n    <p>");
#nullable restore
#line 16 "C:\Users\Administrator\source\repos\PizzaHut\Views\Users\Details.cshtml"
  Write(ViewBag.UserID);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n    <p>Pizza</p>\r\n");
#nullable restore
#line 18 "C:\Users\Administrator\source\repos\PizzaHut\Views\Users\Details.cshtml"
     for (int i = 0; i < TempData["Pizza"].ToString().Length; i++)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\Administrator\source\repos\PizzaHut\Views\Users\Details.cshtml"
   Write(TempData["Pizza"].ToString()[i]);

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\Administrator\source\repos\PizzaHut\Views\Users\Details.cshtml"
                                        ;
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("    <p>Toppings</p>\r\n");
#nullable restore
#line 23 "C:\Users\Administrator\source\repos\PizzaHut\Views\Users\Details.cshtml"
     if (TempData["Toppings"] != null)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\Administrator\source\repos\PizzaHut\Views\Users\Details.cshtml"
         for (int i = 0; i < TempData["Toppings"].ToString().Length; i++)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\Administrator\source\repos\PizzaHut\Views\Users\Details.cshtml"
       Write(TempData["Toppings"].ToString()[i]);

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\Administrator\source\repos\PizzaHut\Views\Users\Details.cshtml"
                                               ;
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\Administrator\source\repos\PizzaHut\Views\Users\Details.cshtml"
         
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 31 "C:\Users\Administrator\source\repos\PizzaHut\Views\Users\Details.cshtml"
Write(Html.ActionLink("Go Back", "Pizzas", "Users"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591