#pragma checksum "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pharmacy\Pages\Favourites\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ac6d3a92ec6f0d50e3d96bdbc1a5629661192888"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Pharmacy.Pages.Favourites.Pages_Favourites_Index), @"mvc.1.0.razor-page", @"/Pages/Favourites/Index.cshtml")]
namespace Pharmacy.Pages.Favourites
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
#line 1 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pharmacy\Pages\_ViewImports.cshtml"
using Pharmacy;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac6d3a92ec6f0d50e3d96bdbc1a5629661192888", @"/Pages/Favourites/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57402bc52d450868f7b30685936a3de54c45052d", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Favourites_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/users/register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/users/login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pharmacy\Pages\Favourites\Index.cshtml"
  
    ViewData["Title"] = "Favourites";

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pharmacy\Pages\Favourites\Index.cshtml"
 if (Model.User != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script>\r\n    function setFavorite(pId) {\r\n        var el = document.getElementById(\'m_\' + pId);\r\n        if (el.classList.contains(\"bi-heart-fill\")) {\r\n                fetch(\'/Favourites/Index?handler=DeleteFavorite&userId=");
#nullable restore
#line 12 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pharmacy\Pages\Favourites\Index.cshtml"
                                                                  Write(Model.User.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"&diseaseId=' + pId)
                .then(r => {
                        el.classList.add(""bi-heart"");
                        el.classList.remove(""bi-heart-fill"");
                });
        } else {
            fetch('/Favourites/Index?handler=SetFavorite&userId=");
#nullable restore
#line 18 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pharmacy\Pages\Favourites\Index.cshtml"
                                                           Write(Model.User.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("&diseaseId=\' + pId)\r\n                .then(r => {\r\n                        el.classList.add(\"bi-heart-fill\");\r\n                        el.classList.remove(\"bi-heart\");\r\n                });\r\n    }\r\n    }\r\n    </script>\r\n");
#nullable restore
#line 26 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pharmacy\Pages\Favourites\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 28 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pharmacy\Pages\Favourites\Index.cshtml"
 if (Model.User == null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"text-center\">\r\n        <h1 class=\"display-4,text\">");
#nullable restore
#line 31 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pharmacy\Pages\Favourites\Index.cshtml"
                              Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    </div>\r\n    <div class=\"text-center mt-5\">\r\n        <p>You are not logged in! ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac6d3a92ec6f0d50e3d96bdbc1a56296611928886813", async() => {
                WriteLiteral("Register");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" or ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac6d3a92ec6f0d50e3d96bdbc1a56296611928887968", async() => {
                WriteLiteral("Log in");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</p>\r\n    </div>\r\n");
#nullable restore
#line 36 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pharmacy\Pages\Favourites\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"text-center\">\r\n        <h1 class=\"display-4,text\">");
#nullable restore
#line 40 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pharmacy\Pages\Favourites\Index.cshtml"
                              Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 40 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pharmacy\Pages\Favourites\Index.cshtml"
                                                   Write(Model.User.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    </div>\r\n");
#nullable restore
#line 42 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pharmacy\Pages\Favourites\Index.cshtml"
     if (!Model.User.IsVerified)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"text-center mt-5\">\r\n            <p>You are not verified! ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac6d3a92ec6f0d50e3d96bdbc1a562966119288810348", async() => {
                WriteLiteral("Register another account");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" or ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac6d3a92ec6f0d50e3d96bdbc1a562966119288811520", async() => {
                WriteLiteral("Log into another account");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</p>\r\n        </div>\r\n");
#nullable restore
#line 47 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pharmacy\Pages\Favourites\Index.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac6d3a92ec6f0d50e3d96bdbc1a562966119288812956", async() => {
                WriteLiteral("\r\n            <div class=\"container mt-5\">\r\n");
#nullable restore
#line 52 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pharmacy\Pages\Favourites\Index.cshtml"
                 if (Model.Diseases != null)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pharmacy\Pages\Favourites\Index.cshtml"
                     foreach (var disease in Model.Diseases)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        <div class=""row mt-5 rounded shadow"">
                            <div class=""col-sm-1"">
                            </div>
                            <div class=""col-sm"">
                                <div class=""row"">
                                    <div class=""col"">
                                        <h3 class=""display-4,text"">");
#nullable restore
#line 62 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pharmacy\Pages\Favourites\Index.cshtml"
                                                              Write(disease.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n                                    </div>\r\n                                    <div class=\"col text-right mt-2 mr-3\">\r\n                                        <span class=\"float-right\">\r\n                                            <a");
                BeginWriteAttribute("href", " href=\"", 2451, "\"", 2496, 4);
                WriteAttributeValue("", 2458, "javascript:", 2458, 11, true);
                WriteAttributeValue(" ", 2469, "setFavorite(\'", 2470, 14, true);
#nullable restore
#line 66 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pharmacy\Pages\Favourites\Index.cshtml"
WriteAttributeValue("", 2483, disease.Id, 2483, 11, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2494, "\')", 2494, 2, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                                <i");
                BeginWriteAttribute("id", " id=\"", 2550, "\"", 2568, 2);
                WriteAttributeValue("", 2555, "m_", 2555, 2, true);
#nullable restore
#line 67 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pharmacy\Pages\Favourites\Index.cshtml"
WriteAttributeValue("", 2557, disease.Id, 2557, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""bi bi-heart-fill"" style=""font-size: 2.3em; ""></i>
                                            </a>
                                        </span>
                                    </div>
                                </div>
                                <br />
                                <div class=""row"">
                                    <div class=""col"">
                                        <h3>");
#nullable restore
#line 75 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pharmacy\Pages\Favourites\Index.cshtml"
                                       Write(disease.Description);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n                                    </div>\r\n                                    <div class=\"col text-right mb-5 mr-3\">\r\n                                        <a class=\"btn btn-outline-primary float-right\"");
                BeginWriteAttribute("href", " href=\"", 3234, "\"", 3241, 0);
                EndWriteAttribute();
                WriteLiteral(" target=\"_blank\"><i class=\"bi bi-cart3\"></i> Vedi medicinali</a> <!--link alla pagina details-->\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 83 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pharmacy\Pages\Favourites\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 83 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pharmacy\Pages\Favourites\Index.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 87 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pharmacy\Pages\Favourites\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 87 "C:\Users\NbkHp\Documents\GitHub\Pharmacy\Pharmacy\Pharmacy\Pharmacy\Pages\Favourites\Index.cshtml"
     
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pharmacy.Pages.Favourites.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pharmacy.Pages.Favourites.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pharmacy.Pages.Favourites.IndexModel>)PageContext?.ViewData;
        public Pharmacy.Pages.Favourites.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591