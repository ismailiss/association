#pragma checksum "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a63a22cbcbffeffb5604fd6d256c8e4877a4bc44"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FacturesGenerees_Details), @"mvc.1.0.view", @"/Views/FacturesGenerees/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/FacturesGenerees/Details.cshtml", typeof(AspNetCore.Views_FacturesGenerees_Details))]
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
#line 1 "C:\Users\ismail\source\repos\association2802\association\association\Views\_ViewImports.cshtml"
using association;

#line default
#line hidden
#line 2 "C:\Users\ismail\source\repos\association2802\association\association\Views\_ViewImports.cshtml"
using association.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a63a22cbcbffeffb5604fd6d256c8e4877a4bc44", @"/Views/FacturesGenerees/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2faaaaa8c7fdc027f2665c2452d954a4adc3997", @"/Views/_ViewImports.cshtml")]
    public class Views_FacturesGenerees_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<association.Models.FacturesGeneree>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Factures", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
  
    ViewData["Title"] = "Détails";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(135, 129, true);
            WriteLiteral("\r\n<h2>Détails</h2>\r\n\r\n<div>\r\n    <h4>FacturesGeneree</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(265, 48, false);
#line 15 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DateFactures));

#line default
#line hidden
            EndContext();
            BeginContext(313, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(357, 44, false);
#line 18 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
       Write(Html.DisplayFor(model => model.DateFactures));

#line default
#line hidden
            EndContext();
            BeginContext(401, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(445, 50, false);
#line 21 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DateGeneration));

#line default
#line hidden
            EndContext();
            BeginContext(495, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(539, 46, false);
#line 24 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
       Write(Html.DisplayFor(model => model.DateGeneration));

#line default
#line hidden
            EndContext();
            BeginContext(585, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(629, 45, false);
#line 27 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FactureDe));

#line default
#line hidden
            EndContext();
            BeginContext(674, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(718, 41, false);
#line 30 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
       Write(Html.DisplayFor(model => model.FactureDe));

#line default
#line hidden
            EndContext();
            BeginContext(759, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(803, 47, false);
#line 33 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Association));

#line default
#line hidden
            EndContext();
            BeginContext(850, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(894, 57, false);
#line 36 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
       Write(Html.DisplayFor(model => model.Association.AssociationID));

#line default
#line hidden
            EndContext();
            BeginContext(951, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(998, 73, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "644fb2ffe566467d8edc2451ed532a7f", async() => {
                BeginContext(1059, 8, true);
                WriteLiteral("Modifier");
                EndContext();
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
#line 41 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
                           WriteLiteral(Model.FacturesGenereeID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1071, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1079, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27d99f22cd4b498f8434f1efcb6873f3", async() => {
                BeginContext(1101, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1117, 46, true);
            WriteLiteral("\r\n</div>\r\n<hr />\r\n<p>\r\n    <h4>Factures</h4>\r\n");
            EndContext();
            BeginContext(1275, 119, true);
            WriteLiteral("\r\n</p>\r\n<div>\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1395, 80, false);
#line 55 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Factures.FirstOrDefault().CompteurEau.Client));

#line default
#line hidden
            EndContext();
            BeginContext(1475, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1543, 87, false);
#line 58 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Factures.FirstOrDefault().CompteurEau.CompteurEauID));

#line default
#line hidden
            EndContext();
            BeginContext(1630, 69, true);
            WriteLiteral("\r\n                </th>\r\n\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1700, 73, false);
#line 62 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Factures.FirstOrDefault().DateFacture));

#line default
#line hidden
            EndContext();
            BeginContext(1773, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1841, 69, false);
#line 65 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Factures.FirstOrDefault().Montant));

#line default
#line hidden
            EndContext();
            BeginContext(1910, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1978, 76, false);
#line 68 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Factures.FirstOrDefault().ValeurCompteur));

#line default
#line hidden
            EndContext();
            BeginContext(2054, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(2122, 86, false);
#line 71 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Factures.FirstOrDefault().ValeurCompteurPrecedente));

#line default
#line hidden
            EndContext();
            BeginContext(2208, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(2276, 69, false);
#line 74 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Factures.FirstOrDefault().isPayee));

#line default
#line hidden
            EndContext();
            BeginContext(2345, 110, true);
            WriteLiteral("\r\n                </th>\r\n\r\n\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
            EndContext();
#line 82 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
             foreach (var item in Model.Factures)
            {

#line default
#line hidden
            BeginContext(2521, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2582, 63, false);
#line 86 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
               Write(Html.DisplayFor(modelItem => item.CompteurEau.Client.NomPrenom));

#line default
#line hidden
            EndContext();
            BeginContext(2645, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2713, 48, false);
#line 89 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
               Write(Html.DisplayFor(modelItem => item.CompteurEauID));

#line default
#line hidden
            EndContext();
            BeginContext(2761, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2829, 46, false);
#line 92 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
               Write(Html.DisplayFor(modelItem => item.DateFacture));

#line default
#line hidden
            EndContext();
            BeginContext(2875, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2943, 42, false);
#line 95 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
               Write(Html.DisplayFor(modelItem => item.Montant));

#line default
#line hidden
            EndContext();
            BeginContext(2985, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(3053, 49, false);
#line 98 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
               Write(Html.DisplayFor(modelItem => item.ValeurCompteur));

#line default
#line hidden
            EndContext();
            BeginContext(3102, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(3170, 59, false);
#line 101 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
               Write(Html.DisplayFor(modelItem => item.ValeurCompteurPrecedente));

#line default
#line hidden
            EndContext();
            BeginContext(3229, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(3297, 42, false);
#line 104 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
               Write(Html.DisplayFor(modelItem => item.isPayee));

#line default
#line hidden
            EndContext();
            BeginContext(3339, 69, true);
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(3408, 90, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "54d086aa61624cbeb9ec11606ec5e156", async() => {
                BeginContext(3486, 8, true);
                WriteLiteral("Modifier");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 108 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
                                                                     WriteLiteral(item.FactureID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3498, 24, true);
            WriteLiteral(" |\r\n                    ");
            EndContext();
            BeginContext(3522, 92, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0cf0a392412c43298e532a5750fb98cb", async() => {
                BeginContext(3603, 7, true);
                WriteLiteral("Détails");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 109 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
                                                                        WriteLiteral(item.FactureID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3614, 24, true);
            WriteLiteral(" |\r\n                    ");
            EndContext();
            BeginContext(3638, 93, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d633ae3b084f494c87543403ce4f8561", async() => {
                BeginContext(3718, 9, true);
                WriteLiteral("Supprimer");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 110 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
                                                                       WriteLiteral(item.FactureID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3731, 46, true);
            WriteLiteral("\r\n\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 114 "C:\Users\ismail\source\repos\association2802\association\association\Views\FacturesGenerees\Details.cshtml"
            }

#line default
#line hidden
            BeginContext(3792, 42, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<association.Models.FacturesGeneree> Html { get; private set; }
    }
}
#pragma warning restore 1591
