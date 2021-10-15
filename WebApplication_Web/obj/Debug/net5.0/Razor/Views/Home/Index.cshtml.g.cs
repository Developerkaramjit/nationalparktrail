#pragma checksum "D:\Core program\CoreWebApi\WebApplication_Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2576f2d22244a36a1e4d8b518ef27ee63c3b71d2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\Core program\CoreWebApi\WebApplication_Web\Views\_ViewImports.cshtml"
using WebApplication_Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Core program\CoreWebApi\WebApplication_Web\Views\_ViewImports.cshtml"
using WebApplication_Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2576f2d22244a36a1e4d8b518ef27ee63c3b71d2", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c8a50eca4a85f54347393c76290304f4ecd0a93", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication_Web.Models.ViewModel.IndexVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container backgroundWhite pb-4\">\r\n    <div class=\"card border\">\r\n");
#nullable restore
#line 5 "D:\Core program\CoreWebApi\WebApplication_Web\Views\Home\Index.cshtml"
         foreach (var natonalPark in Model.NationalParkList)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""card-header bg-dark text-light ml-0 row container"">
                <div class=""col-12 col-md-6"">
                    <h1 class=""text-warning""></h1>
                </div>
                <div class=""col-12 col-md-6 text-md-right"">
                    <h1 class=""text-warning"">State : ");
#nullable restore
#line 12 "D:\Core program\CoreWebApi\WebApplication_Web\Views\Home\Index.cshtml"
                                                Write(natonalPark.State);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
                </div>
            </div>
            <div class=""card-body"">
                <div class=""container rounded p-2"">
                    <div class=""row"">
                        <div class=""col-12 col-lg-8"">
                            <div class=""row"">
                                <div class=""col-12"">
                                    <h3 style=""color:#bbb9b9"">Established:");
#nullable restore
#line 21 "D:\Core program\CoreWebApi\WebApplication_Web\Views\Home\Index.cshtml"
                                                                     Write(natonalPark.Established.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h3>\r\n                                </div>\r\n                                <div class=\"col-12\">\r\n");
#nullable restore
#line 24 "D:\Core program\CoreWebApi\WebApplication_Web\Views\Home\Index.cshtml"
                                     if (Model.TrailList.Where(t => t.NationalParkId == natonalPark.Id).Count() > 0)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        <table class=""table table-striped"" style=""border:1px solid #808080 "">
                                            <thead>
                                                <tr class=""table-secondary"">
                                                    <th>
                                                        Trail
                                                    </th>
                                                    <th>Distance</th>
                                                    <th>Elevation Gain</th>
                                                    <th>Difficulty</th>
                                                </tr>
                                            </thead>
                                            <tbody>
");
#nullable restore
#line 38 "D:\Core program\CoreWebApi\WebApplication_Web\Views\Home\Index.cshtml"
                                                 foreach (var trail in Model.TrailList.Where(t => t.NationalParkId == natonalPark.Id))
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <tr>\r\n                                                        <td>");
#nullable restore
#line 41 "D:\Core program\CoreWebApi\WebApplication_Web\Views\Home\Index.cshtml"
                                                       Write(trail.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                        <td>");
#nullable restore
#line 42 "D:\Core program\CoreWebApi\WebApplication_Web\Views\Home\Index.cshtml"
                                                       Write(trail.Distance);

#line default
#line hidden
#nullable disable
            WriteLiteral(" miles</td>\r\n                                                        <td>");
#nullable restore
#line 43 "D:\Core program\CoreWebApi\WebApplication_Web\Views\Home\Index.cshtml"
                                                       Write(trail.Elevation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                        <td>");
#nullable restore
#line 44 "D:\Core program\CoreWebApi\WebApplication_Web\Views\Home\Index.cshtml"
                                                       Write(trail.Difficulty);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    </tr>\r\n");
#nullable restore
#line 46 "D:\Core program\CoreWebApi\WebApplication_Web\Views\Home\Index.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </tbody>\r\n                                        </table>\r\n");
#nullable restore
#line 49 "D:\Core program\CoreWebApi\WebApplication_Web\Views\Home\Index.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <p>No Trail exist for this : ");
#nullable restore
#line 52 "D:\Core program\CoreWebApi\WebApplication_Web\Views\Home\Index.cshtml"
                                                                Write(natonalPark.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 53 "D:\Core program\CoreWebApi\WebApplication_Web\Views\Home\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </div>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"col-12 col-lg-4 text-center\">\r\n");
#nullable restore
#line 58 "D:\Core program\CoreWebApi\WebApplication_Web\Views\Home\Index.cshtml"
                              
                                var base64 = Convert.ToBase64String(natonalPark.Picture);
                                var finalStr = string.Format("data:image/jpg;base64,{0}", base64);
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <img");
            BeginWriteAttribute("src", " src=\"", 3543, "\"", 3558, 1);
#nullable restore
#line 62 "D:\Core program\CoreWebApi\WebApplication_Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 3549, finalStr, 3549, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top p-2 rounded\" width=\"100\" />\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 67 "D:\Core program\CoreWebApi\WebApplication_Web\Views\Home\Index.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication_Web.Models.ViewModel.IndexVM> Html { get; private set; }
    }
}
#pragma warning restore 1591