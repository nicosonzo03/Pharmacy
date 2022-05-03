#pragma checksum "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4f3934676a5e03da1985ff80be559c898da666e4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Pharmacy.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace Pharmacy.Pages
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
#line 1 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pages\_ViewImports.cshtml"
using Pharmacy;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f3934676a5e03da1985ff80be559c898da666e4", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57402bc52d450868f7b30685936a3de54c45052d", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pages\Index.cshtml"
 if (Model.User != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"text-center\">\r\n        <h1 class=\"display-4,text\">Welcome ");
#nullable restore
#line 10 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pages\Index.cshtml"
                                      Write(Model.User.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    </div>\r\n");
#nullable restore
#line 12 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pages\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"text-center\">\r\n        <h1 class=\"display-4,text\">Welcome on Pharmacy</h1>\r\n    </div>\r\n");
#nullable restore
#line 18 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pages\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container mt-5\">\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-1\">\r\n        </div>\r\n");
#nullable restore
#line 23 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pages\Index.cshtml"
         if (Model.User != null && Model.User.IsVerified)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""col rounded shadow m-3"">
                <div class=""text-center mb-3"">
                    <p>Discover the disease you are looking for</p>
                    <h1 class=""display-4 mb-4"">Search</h1>
                    <a href=""/Symptoms/"" class=""btn btn-outline-primary""><i class=""bi bi-search""></i> Search now</a>
                </div>
            </div>
            <div class=""col rounded shadow m-3"">
                <div class=""text-center mb-3"">
                    <p>Find diseases you have recently searched</p>
                    <h1 class=""display-4 mb-4"">History</h1>
                    <a href=""/history/"" class=""btn btn-outline-primary""><i class=""bi bi-clock-history""></i> View history</a>
                </div>
            </div>
            <div class=""col rounded shadow m-3"">
                <div class=""text-center mb-3"">
                    <p>Monitor diseases you are interested in</p>
                    <h1 class=""display-4 mb-4"">Favourites</h1>
        ");
            WriteLiteral("            <a href=\"/history/\" class=\"btn btn-outline-primary\"><i class=\"bi bi-heart\"></i> View favourites</a>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 46 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pages\Index.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""col rounded shadow m-3"">
                <div class=""text-center mb-3"">
                    <p>Become a user for more exclusive utilities</p>
                    <h1 class=""display-4 mb-4"">Register</h1>
                    <a href=""/users/register"" class=""btn btn-outline-primary""><i class=""bi bi-list""></i> Register now</a>
                </div>
            </div>
            <div class=""col rounded shadow m-3"">
                <div class=""text-center mb-3"">
                    <p>Recover your account for extra functions</p>
                    <h1 class=""display-4 mb-4"">Login</h1>
                    <a href=""/users/login"" class=""btn btn-outline-primary""><i class=""bi bi-box-arrow-in-right""></i> Log in</a>
                </div>
            </div>
");
#nullable restore
#line 63 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pages\Index.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-sm-1\">\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
