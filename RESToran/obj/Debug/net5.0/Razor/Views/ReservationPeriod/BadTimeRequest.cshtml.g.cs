#pragma checksum "C:\Users\misla\fer\1.semestar_diplomski\OO\seminar\web-app\RESToran\RESToran\Views\ReservationPeriod\BadTimeRequest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "97e30727c8c82c84777f9155c4d336c57b96ebbb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ReservationPeriod_BadTimeRequest), @"mvc.1.0.view", @"/Views/ReservationPeriod/BadTimeRequest.cshtml")]
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
#line 1 "C:\Users\misla\fer\1.semestar_diplomski\OO\seminar\web-app\RESToran\RESToran\Views\_ViewImports.cshtml"
using RESToran;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\misla\fer\1.semestar_diplomski\OO\seminar\web-app\RESToran\RESToran\Views\_ViewImports.cshtml"
using RESToran.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"97e30727c8c82c84777f9155c4d336c57b96ebbb", @"/Views/ReservationPeriod/BadTimeRequest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a6bf0488963afb14daa1f8cf02109fa28eb3c9c3", @"/Views/_ViewImports.cshtml")]
    public class Views_ReservationPeriod_BadTimeRequest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RESToran.Models.ReservationPeriod>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary float-right mt-5"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\misla\fer\1.semestar_diplomski\OO\seminar\web-app\RESToran\RESToran\Views\ReservationPeriod\BadTimeRequest.cshtml"
  
    ViewData["Title"] = "Create";
    Restaurant restaurant = ViewBag.Restaurant;
    string date = ViewBag.Date;
    string startTime = ViewBag.StartTime;
    string endTime = ViewBag.EndStart;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3 class=\"text-center\" style=\"color:blue\">");
#nullable restore
#line 11 "C:\Users\misla\fer\1.semestar_diplomski\OO\seminar\web-app\RESToran\RESToran\Views\ReservationPeriod\BadTimeRequest.cshtml"
                                      Write(restaurant.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n<p class=\"mt-40\">All the tables on date: ");
#nullable restore
#line 13 "C:\Users\misla\fer\1.semestar_diplomski\OO\seminar\web-app\RESToran\RESToran\Views\ReservationPeriod\BadTimeRequest.cshtml"
                                    Write(date);

#line default
#line hidden
#nullable disable
            WriteLiteral(" in period: ");
#nullable restore
#line 13 "C:\Users\misla\fer\1.semestar_diplomski\OO\seminar\web-app\RESToran\RESToran\Views\ReservationPeriod\BadTimeRequest.cshtml"
                                                     Write(startTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("  from: ");
#nullable restore
#line 13 "C:\Users\misla\fer\1.semestar_diplomski\OO\seminar\web-app\RESToran\RESToran\Views\ReservationPeriod\BadTimeRequest.cshtml"
                                                                       Write(endTime);

#line default
#line hidden
#nullable disable
            WriteLiteral(" are alredy reserved, please try another period.</p>\r\n\r\n\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "97e30727c8c82c84777f9155c4d336c57b96ebbb5790", async() => {
                WriteLiteral("Try again");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 17 "C:\Users\misla\fer\1.semestar_diplomski\OO\seminar\web-app\RESToran\RESToran\Views\ReservationPeriod\BadTimeRequest.cshtml"
                             WriteLiteral(restaurant.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RESToran.Models.ReservationPeriod> Html { get; private set; }
    }
}
#pragma warning restore 1591
