#pragma checksum "C:\Users\Morgan\Documents\OIT\CST 465\CST465TermProject\Assignment2\Views\Contact\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9842958b370d1b50c25bec11c0791dc60bc3f1a1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contact_Index), @"mvc.1.0.view", @"/Views/Contact/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Contact/Index.cshtml", typeof(AspNetCore.Views_Contact_Index))]
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
#line 2 "C:\Users\Morgan\Documents\OIT\CST 465\CST465TermProject\Assignment2\Views\Contact\Index.cshtml"
using Assignment2.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9842958b370d1b50c25bec11c0791dc60bc3f1a1", @"/Views/Contact/Index.cshtml")]
    public class Views_Contact_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ContactInfo>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(50, 22, true);
            WriteLiteral("\r\n<h2>Contact</h2>\r\n\r\n");
            EndContext();
#line 7 "C:\Users\Morgan\Documents\OIT\CST 465\CST465TermProject\Assignment2\Views\Contact\Index.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
            BeginContext(107, 21, false);
#line 9 "C:\Users\Morgan\Documents\OIT\CST 465\CST465TermProject\Assignment2\Views\Contact\Index.cshtml"
Write(Html.EditorForModel());

#line default
#line hidden
            EndContext();
            BeginContext(130, 43, true);
            WriteLiteral("    <button type=\"submit\">Submit</button>\r\n");
            EndContext();
#line 11 "C:\Users\Morgan\Documents\OIT\CST 465\CST465TermProject\Assignment2\Views\Contact\Index.cshtml"
}

#line default
#line hidden
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
