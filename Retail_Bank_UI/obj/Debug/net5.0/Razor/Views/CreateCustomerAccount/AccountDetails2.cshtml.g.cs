#pragma checksum "C:\Users\Kousik Sen\Desktop\Retail-Banking-System\Retail_Bank_UI\Views\CreateCustomerAccount\AccountDetails2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b61d497db6611bdce2e9f23986555a07d38cbac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CreateCustomerAccount_AccountDetails2), @"mvc.1.0.view", @"/Views/CreateCustomerAccount/AccountDetails2.cshtml")]
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
#line 1 "C:\Users\Kousik Sen\Desktop\Retail-Banking-System\Retail_Bank_UI\Views\_ViewImports.cshtml"
using Retail_Bank_UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Kousik Sen\Desktop\Retail-Banking-System\Retail_Bank_UI\Views\_ViewImports.cshtml"
using Retail_Bank_UI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b61d497db6611bdce2e9f23986555a07d38cbac", @"/Views/CreateCustomerAccount/AccountDetails2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82c5bc010e050be5106f11bc4852b01dfff49ddc", @"/Views/_ViewImports.cshtml")]
    public class Views_CreateCustomerAccount_AccountDetails2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AccountMicroservice.Model.Account>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Kousik Sen\Desktop\Retail-Banking-System\Retail_Bank_UI\Views\CreateCustomerAccount\AccountDetails2.cshtml"
  
    ViewData["Title"] = "Account Details";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b61d497db6611bdce2e9f23986555a07d38cbac4493", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>AccountDetails2</title>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8b61d497db6611bdce2e9f23986555a07d38cbac4858", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n \r\n");
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
            WriteLiteral("\r\n\r\n\r\n    <div>\r\n        <div class=\"container-fluid table-responsive py-5\">\r\n            \r\n                    <div class=\"row\">\r\n                        \r\n                        <div class=\"col-sm-2\">\r\n                            <b>");
#nullable restore
#line 23 "C:\Users\Kousik Sen\Desktop\Retail-Banking-System\Retail_Bank_UI\Views\CreateCustomerAccount\AccountDetails2.cshtml"
                          Write(Html.DisplayNameFor(model => model.Sav_AccountId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n\r\n                        </div>\r\n                        <div class=\"col-sm-10\">\r\n\r\n                            ");
#nullable restore
#line 28 "C:\Users\Kousik Sen\Desktop\Retail-Banking-System\Retail_Bank_UI\Views\CreateCustomerAccount\AccountDetails2.cshtml"
                       Write(Html.DisplayFor(model => model.Sav_AccountId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-sm-2\">\r\n                            <b>");
#nullable restore
#line 31 "C:\Users\Kousik Sen\Desktop\Retail-Banking-System\Retail_Bank_UI\Views\CreateCustomerAccount\AccountDetails2.cshtml"
                          Write(Html.DisplayNameFor(model => model.Cur_AccountId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n\r\n                        </div>\r\n                        <div class=\"col-sm-10\">\r\n\r\n\r\n                            ");
#nullable restore
#line 37 "C:\Users\Kousik Sen\Desktop\Retail-Banking-System\Retail_Bank_UI\Views\CreateCustomerAccount\AccountDetails2.cshtml"
                       Write(Html.DisplayFor(model => model.Cur_AccountId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-sm-2\">\r\n                            <b>");
#nullable restore
#line 40 "C:\Users\Kousik Sen\Desktop\Retail-Banking-System\Retail_Bank_UI\Views\CreateCustomerAccount\AccountDetails2.cshtml"
                          Write(Html.DisplayNameFor(model => model.CustomerId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n\r\n                        </div>\r\n                        <div class=\"col-sm-10\">\r\n\r\n                            ");
#nullable restore
#line 45 "C:\Users\Kousik Sen\Desktop\Retail-Banking-System\Retail_Bank_UI\Views\CreateCustomerAccount\AccountDetails2.cshtml"
                       Write(Html.DisplayFor(model => model.CustomerId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-sm-2\">\r\n                            <b>");
#nullable restore
#line 48 "C:\Users\Kousik Sen\Desktop\Retail-Banking-System\Retail_Bank_UI\Views\CreateCustomerAccount\AccountDetails2.cshtml"
                          Write(Html.DisplayNameFor(model => model.accountType));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                        </div>\r\n                        <div class=\"col-sm-10\">\r\n\r\n\r\n                            ");
#nullable restore
#line 53 "C:\Users\Kousik Sen\Desktop\Retail-Banking-System\Retail_Bank_UI\Views\CreateCustomerAccount\AccountDetails2.cshtml"
                       Write(Html.DisplayFor(model => model.accountType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-sm-2\">\r\n                            <b>");
#nullable restore
#line 56 "C:\Users\Kousik Sen\Desktop\Retail-Banking-System\Retail_Bank_UI\Views\CreateCustomerAccount\AccountDetails2.cshtml"
                          Write(Html.DisplayNameFor(model => model.Balance));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                        </div>\r\n                        <div class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 59 "C:\Users\Kousik Sen\Desktop\Retail-Banking-System\Retail_Bank_UI\Views\CreateCustomerAccount\AccountDetails2.cshtml"
                       Write(Html.DisplayFor(model => model.Balance));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-sm-2\">\r\n                            <b>");
#nullable restore
#line 62 "C:\Users\Kousik Sen\Desktop\Retail-Banking-System\Retail_Bank_UI\Views\CreateCustomerAccount\AccountDetails2.cshtml"
                          Write(Html.DisplayNameFor(model => model.MinBalance));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                        </div>\r\n                        <div class=\"col-sm-10\">\r\n                            ");
#nullable restore
#line 65 "C:\Users\Kousik Sen\Desktop\Retail-Banking-System\Retail_Bank_UI\Views\CreateCustomerAccount\AccountDetails2.cshtml"
                       Write(Html.DisplayFor(model => model.MinBalance));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n\r\n\r\n        </div>\r\n   \r\n    </div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AccountMicroservice.Model.Account> Html { get; private set; }
    }
}
#pragma warning restore 1591
