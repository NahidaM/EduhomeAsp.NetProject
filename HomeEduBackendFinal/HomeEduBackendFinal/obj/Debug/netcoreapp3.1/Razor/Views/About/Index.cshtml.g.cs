#pragma checksum "C:\Users\ACER\Desktop\EduhomeAsp.NetProject\HomeEduBackendFinal\HomeEduBackendFinal\Views\About\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ca0edad561c23296ff5ffdcd09d42b81fe19c7c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_About_Index), @"mvc.1.0.view", @"/Views/About/Index.cshtml")]
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
#line 2 "C:\Users\ACER\Desktop\EduhomeAsp.NetProject\HomeEduBackendFinal\HomeEduBackendFinal\Views\_ViewImports.cshtml"
using HomeEduBackendFinal.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ACER\Desktop\EduhomeAsp.NetProject\HomeEduBackendFinal\HomeEduBackendFinal\Views\_ViewImports.cshtml"
using HomeEduBackendFinal.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca0edad561c23296ff5ffdcd09d42b81fe19c7c1", @"/Views/About/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b62e401a54964c5976e5e8c4c4e1680637162ef", @"/Views/_ViewImports.cshtml")]
    public class Views_About_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AboutVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_partialBanner", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("about"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/icon/section.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("title"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("testimonial"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ACER\Desktop\EduhomeAsp.NetProject\HomeEduBackendFinal\HomeEduBackendFinal\Views\About\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- Banner Area Start -->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ca0edad561c23296ff5ffdcd09d42b81fe19c7c15347", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<!-- Banner Area End -->
<!-- About Start -->
<div class=""about-area pt-145 pb-155"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-6 col-sm-6"">
                <div class=""about-content"">
                    ");
#nullable restore
#line 16 "C:\Users\ACER\Desktop\EduhomeAsp.NetProject\HomeEduBackendFinal\HomeEduBackendFinal\Views\About\Index.cshtml"
               Write(Html.Raw(Model.About.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    <p class=\"hidden-sm\">");
#nullable restore
#line 18 "C:\Users\ACER\Desktop\EduhomeAsp.NetProject\HomeEduBackendFinal\HomeEduBackendFinal\Views\About\Index.cshtml"
                                    Write(Model.About.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <a class=\"default-btn\" href=\"#\">view courses</a>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-md-6 col-sm-6\">\r\n                <div class=\"about-img\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ca0edad561c23296ff5ffdcd09d42b81fe19c7c17586", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 756, "~/img/about/", 756, 12, true);
#nullable restore
#line 24 "C:\Users\ACER\Desktop\EduhomeAsp.NetProject\HomeEduBackendFinal\HomeEduBackendFinal\Views\About\Index.cshtml"
AddHtmlAttributeValue("", 768, Model.About.Image, 768, 18, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
            </div>
        </div>
    </div>
</div>
<!-- About End -->
<!-- Teacher Start -->
<div class=""teacher-area pb-150"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-xs-12"">
                <div class=""section-title text-center"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ca0edad561c23296ff5ffdcd09d42b81fe19c7c19523", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    <h2>meet our teachers</h2>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n            ");
#nullable restore
#line 43 "C:\Users\ACER\Desktop\EduhomeAsp.NetProject\HomeEduBackendFinal\HomeEduBackendFinal\Views\About\Index.cshtml"
       Write(await Component.InvokeAsync("Teacher", 4));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </div>
    </div>
</div>
<!-- Teacher End -->
<!-- Testimonial Area Start -->
<div class=""testimonial-area pt-110 pb-105 text-center"">
    <div class=""container"">
        <div class=""row"">
            <div class=""testimonial-owl owl-theme owl-carousel"">
                <div class=""col-md-8 col-md-offset-2 col-sm-12"">
                    <div class=""single-testimonial"">
                        <div class=""testimonial-info"">
                            <div class=""testimonial-img"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ca0edad561c23296ff5ffdcd09d42b81fe19c7c111632", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1918, "~/img/testimonial/", 1918, 18, true);
#nullable restore
#line 57 "C:\Users\ACER\Desktop\EduhomeAsp.NetProject\HomeEduBackendFinal\HomeEduBackendFinal\Views\About\Index.cshtml"
AddHtmlAttributeValue("", 1936, Model.Testimonial.Image, 1936, 24, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"testimonial-content\">\r\n                                <p> ");
#nullable restore
#line 60 "C:\Users\ACER\Desktop\EduhomeAsp.NetProject\HomeEduBackendFinal\HomeEduBackendFinal\Views\About\Index.cshtml"
                               Write(Model.Testimonial.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <h4>");
#nullable restore
#line 61 "C:\Users\ACER\Desktop\EduhomeAsp.NetProject\HomeEduBackendFinal\HomeEduBackendFinal\Views\About\Index.cshtml"
                               Write(Model.Testimonial.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                <h5>");
#nullable restore
#line 62 "C:\Users\ACER\Desktop\EduhomeAsp.NetProject\HomeEduBackendFinal\HomeEduBackendFinal\Views\About\Index.cshtml"
                               Write(Model.Testimonial.Position);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Testimonial Area End -->
<!-- Notice Start -->
<section class=""notice-area two pt-140 pb-100"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-6 col-sm-6 col-xs-12"">
                <div class=""notice-right-wrapper mb-25 pb-25"">
                    <h3>");
#nullable restore
#line 78 "C:\Users\ACER\Desktop\EduhomeAsp.NetProject\HomeEduBackendFinal\HomeEduBackendFinal\Views\About\Index.cshtml"
                   Write(Model.VideoTour.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                    <div class=\"notice-video\">\r\n                        <div class=\"video-icon video-hover\">\r\n                            <a class=\"video-popup\"");
            BeginWriteAttribute("href", " href=\"", 2950, "\"", 2983, 1);
#nullable restore
#line 81 "C:\Users\ACER\Desktop\EduhomeAsp.NetProject\HomeEduBackendFinal\HomeEduBackendFinal\Views\About\Index.cshtml"
WriteAttributeValue("", 2957, Model.VideoTour.VideoLink, 2957, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                <i class=""zmdi zmdi-play""></i>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-md-6 col-sm-6 col-xs-12"">
                <div class=""notice-left-wrapper"">
                    <h3>notice board</h3>
                    <div class=""notice-left"">
");
#nullable restore
#line 92 "C:\Users\ACER\Desktop\EduhomeAsp.NetProject\HomeEduBackendFinal\HomeEduBackendFinal\Views\About\Index.cshtml"
                         foreach (var notice in Model.NoticeLeftInfos)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"single-notice-left mb-23 pb-20\">\r\n                                <h4>");
#nullable restore
#line 95 "C:\Users\ACER\Desktop\EduhomeAsp.NetProject\HomeEduBackendFinal\HomeEduBackendFinal\Views\About\Index.cshtml"
                               Write(notice.Date.ToString("dddd, dd MMMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                <p>");
#nullable restore
#line 96 "C:\Users\ACER\Desktop\EduhomeAsp.NetProject\HomeEduBackendFinal\HomeEduBackendFinal\Views\About\Index.cshtml"
                              Write(notice.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n");
#nullable restore
#line 98 "C:\Users\ACER\Desktop\EduhomeAsp.NetProject\HomeEduBackendFinal\HomeEduBackendFinal\Views\About\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n<!-- Notice End -->\r\n<!-- Subscribe Start -->\r\n");
#nullable restore
#line 107 "C:\Users\ACER\Desktop\EduhomeAsp.NetProject\HomeEduBackendFinal\HomeEduBackendFinal\Views\About\Index.cshtml"
Write(await Component.InvokeAsync("Subscribe"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- Subscribe End -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AboutVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
