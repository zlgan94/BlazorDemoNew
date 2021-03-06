// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorSvrApp.Pages.Employees
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\BlazorDemoNewNew\BlazorDemo\BlazorSvrApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\BlazorDemoNewNew\BlazorDemo\BlazorSvrApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\BlazorDemoNewNew\BlazorDemo\BlazorSvrApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\BlazorDemoNewNew\BlazorDemo\BlazorSvrApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\BlazorDemoNewNew\BlazorDemo\BlazorSvrApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\BlazorDemoNewNew\BlazorDemo\BlazorSvrApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\BlazorDemoNewNew\BlazorDemo\BlazorSvrApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\BlazorDemoNewNew\BlazorDemo\BlazorSvrApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\BlazorDemoNewNew\BlazorDemo\BlazorSvrApp\_Imports.razor"
using BlazorSvrApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\BlazorDemoNewNew\BlazorDemo\BlazorSvrApp\_Imports.razor"
using BlazorSvrApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\BlazorDemoNewNew\BlazorDemo\BlazorSvrApp\Pages\Employees\EmployeesManage.razor"
using BlazorSvrApp.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\BlazorDemoNewNew\BlazorDemo\BlazorSvrApp\Pages\Employees\EmployeesManage.razor"
using System.Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\BlazorDemoNewNew\BlazorDemo\BlazorSvrApp\Pages\Employees\EmployeesManage.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\BlazorDemoNewNew\BlazorDemo\BlazorSvrApp\Pages\Employees\EmployeesManage.razor"
using System.Net;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\BlazorDemoNewNew\BlazorDemo\BlazorSvrApp\Pages\Employees\EmployeesManage.razor"
using Microsoft.Extensions.Logging;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\BlazorDemoNewNew\BlazorDemo\BlazorSvrApp\Pages\Employees\EmployeesManage.razor"
using Microsoft.AspNetCore.WebUtilities;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Employees/Manage")]
    public partial class EmployeesManage : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 71 "C:\BlazorDemoNewNew\BlazorDemo\BlazorSvrApp\Pages\Employees\EmployeesManage.razor"
       

    [Parameter]
    public MyApplicationEditModes pMode { get; set; } = MyApplicationEditModes.Unknown;

    [Parameter]
    public int pID { get; set; }

    private EmployeeViewModel employeeViewModel = new EmployeeViewModel();
    private HttpClient httpClient = new HttpClient();
    private bool isDisabled = false;


    //  https://localhost:44393/Employees/Manage?pMode=New
    //  https://localhost:44393/Employees/Manage?pID=2&pMode=Edit
    //  https://localhost:44393/Employees/Manage?pID=2&pMode=Delete


    protected override async Task OnInitializedAsync()
    {

        // Get the URI for the current page
        var uri = navigationManager.ToAbsoluteUri(navigationManager.Uri);

        // Extract the pID QueryString parameter
        if (uri.ToString().Contains("pID"))
        {
            if (QueryHelpers.ParseNullableQuery(uri.Query).TryGetValue("pID", out var token1))
            {
                var id = token1.FirstOrDefault() ?? "0";
                this.pID = id == "0" ? 0 : int.Parse(id);
            }
        }

        // Extract the pMode QueryString parameter
        if (uri.ToString().Contains("pMode"))
        {
            if (QueryHelpers.ParseNullableQuery(uri.Query).TryGetValue("pMode", out var token2))
            {
                MyApplicationEditModes mode;
                if (Enum.TryParse(token2.FirstOrDefault(), out mode))
                {
                    pMode = mode;
                }
                else
                {
                    pMode = MyApplicationEditModes.Unknown;
                    _logger.LogWarning("unknown edit mode");
                }
            }
        }

        if ((pMode == MyApplicationEditModes.Edit || pMode == MyApplicationEditModes.Delete) && pID != 0)
        {
            var uriApi = $"https://localhost:44393/api/Employees/{pID}";

            this.employeeViewModel = await JsonSerializer.DeserializeAsync<EmployeeViewModel>(
                await this.httpClient.GetStreamAsync(uriApi),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        if (pMode == MyApplicationEditModes.Delete)
        {
            this.isDisabled = true;
        }

        await base.OnInitializedAsync();
    }


    private void onCancel_Handler()
    {
        navigationManager.NavigateTo("/Employees/List");
    }

    private async Task onValidSubmit_Handler()
    {
        string uriApi;
        StringContent jsonEmployee;
        HttpResponseMessage response;

        switch (pMode)
        {
            case MyApplicationEditModes.Add:
                uriApi = $"https://localhost:44393/api/employees/";
                jsonEmployee
                    = new StringContent(JsonSerializer.Serialize(this.employeeViewModel), Encoding.UTF8, "application/json");
                response = await httpClient.PostAsync(uriApi, jsonEmployee);
                if (response.IsSuccessStatusCode)
                {
                    navigationManager.NavigateTo("/Employees/List");
                }
                break;
            case MyApplicationEditModes.Edit:
                uriApi = $"https://localhost:44393/api/employees/{pID}";
                jsonEmployee
                    = new StringContent(JsonSerializer.Serialize(this.employeeViewModel), Encoding.UTF8, "application/json");
                response = await httpClient.PutAsync(uriApi, jsonEmployee);
                if (response.StatusCode == HttpStatusCode.NoContent)     // HTTP StatusCode 204 == Success Code
                {
                    navigationManager.NavigateTo("/Employees/List");
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)  // HTTP StatusCode = 404 == Not Found
                {
                    _logger.LogError($"Update failed: {response.ReasonPhrase}");
                }
                break;
            case MyApplicationEditModes.Delete:
                uriApi = $"https://localhost:44393/api/employees/{pID}";
                response = await httpClient.DeleteAsync(uriApi);
                navigationManager.NavigateTo("/Employees/List");
                break;
            case MyApplicationEditModes.Print:
            case MyApplicationEditModes.View:
            case MyApplicationEditModes.Unknown:
            default:
                break;
        }
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILogger<EmployeesManage> _logger { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager navigationManager { get; set; }
    }
}
#pragma warning restore 1591
