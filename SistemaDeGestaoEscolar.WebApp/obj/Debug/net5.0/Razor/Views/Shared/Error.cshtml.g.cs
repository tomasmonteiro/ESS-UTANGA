#pragma checksum "C:\SGE\SistemaDeGestaoEscolar\SistemaDeGestaoEscolar.WebApp\Views\Shared\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ae7d8e9b51111ca6ffa5a9422c71e008c5d6a22"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error), @"mvc.1.0.view", @"/Views/Shared/Error.cshtml")]
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
#line 1 "C:\SGE\SistemaDeGestaoEscolar\SistemaDeGestaoEscolar.WebApp\Views\_ViewImports.cshtml"
using SistemaDeGestaoEscolar.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\SGE\SistemaDeGestaoEscolar\SistemaDeGestaoEscolar.WebApp\Views\_ViewImports.cshtml"
using SistemaDeGestaoEscolarWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\SGE\SistemaDeGestaoEscolar\SistemaDeGestaoEscolar.WebApp\Views\_ViewImports.cshtml"
using SistemaDeGestaoEscolar.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ae7d8e9b51111ca6ffa5a9422c71e008c5d6a22", @"/Views/Shared/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"993dcf5ac6458f0f9593cd1524452cf71677f480", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ErrorViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\SGE\SistemaDeGestaoEscolar\SistemaDeGestaoEscolar.WebApp\Views\Shared\Error.cshtml"
  
    ViewData["Title"] = "Erro";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section id=""aa-error"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""aa-error-area"">
                    <h2>500</h2>
                    <span>Ops!</span>
                    <p>Isso é muito embaraçoso! Tivemos um problema técnico e nossos microorganismos cibernéticos estão trabalhando para resolver.</p>
                    <a href=""#""> Acesse a Homepage</a>
                </div>
            </div>
        </div>
    </div>
</section>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ErrorViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
