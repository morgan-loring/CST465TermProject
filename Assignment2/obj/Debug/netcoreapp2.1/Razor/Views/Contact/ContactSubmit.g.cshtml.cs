#pragma checksum "C:\Users\Morgan\Documents\OIT\CST 465\CST465TermProject\Assignment2\Views\Contact\ContactSubmit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "44fc0a6f54af6bf8d9392414b8c1358a719fb900"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contact_ContactSubmit), @"mvc.1.0.view", @"/Views/Contact/ContactSubmit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Contact/ContactSubmit.cshtml", typeof(AspNetCore.Views_Contact_ContactSubmit))]
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
#line 1 "C:\Users\Morgan\Documents\OIT\CST 465\CST465TermProject\Assignment2\Views\Contact\ContactSubmit.cshtml"
using Assignment2.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44fc0a6f54af6bf8d9392414b8c1358a719fb900", @"/Views/Contact/ContactSubmit.cshtml")]
    public class Views_Contact_ContactSubmit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ContactInfo>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(47, 37, true);
            WriteLiteral("\r\n<div>\r\n    <ul>\r\n        <li>Name: ");
            EndContext();
            BeginContext(85, 10, false);
#line 6 "C:\Users\Morgan\Documents\OIT\CST 465\CST465TermProject\Assignment2\Views\Contact\ContactSubmit.cshtml"
             Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(95, 33, true);
            WriteLiteral("</li>\r\n        <li>Phone Number: ");
            EndContext();
            BeginContext(129, 17, false);
#line 7 "C:\Users\Morgan\Documents\OIT\CST 465\CST465TermProject\Assignment2\Views\Contact\ContactSubmit.cshtml"
                     Write(Model.PhoneNumber);

#line default
#line hidden
            EndContext();
            BeginContext(146, 26, true);
            WriteLiteral("</li>\r\n        <li>Email: ");
            EndContext();
            BeginContext(173, 11, false);
#line 8 "C:\Users\Morgan\Documents\OIT\CST 465\CST465TermProject\Assignment2\Views\Contact\ContactSubmit.cshtml"
              Write(Model.Email);

#line default
#line hidden
            EndContext();
            BeginContext(184, 28, true);
            WriteLiteral("</li>\r\n        <li>Message: ");
            EndContext();
            BeginContext(213, 13, false);
#line 9 "C:\Users\Morgan\Documents\OIT\CST 465\CST465TermProject\Assignment2\Views\Contact\ContactSubmit.cshtml"
                Write(Model.Message);

#line default
#line hidden
            EndContext();
            BeginContext(226, 24, true);
            WriteLiteral("</li>\r\n    </ul>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ContactInfo> Html { get; private set; }
    }
}
#pragma warning restore 1591