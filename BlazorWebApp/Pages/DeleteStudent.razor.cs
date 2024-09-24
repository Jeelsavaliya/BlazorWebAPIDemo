using BlazorClass;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace BlazorWebApp.Pages
{
    public partial class DeleteStudent
    {
        [Inject]
        public HttpClient http { get; set; }
        [Inject]
        NavigationManager navigationManager { get; set; }
        [Parameter]
        public Student student { get; set; }
        protected async Task Delete()
        {
            StateHasChanged();
            //await http.DeleteFromJsonAsync
            navigationManager.NavigateTo("/student-list", true);
        }

        protected async Task Back()
        {
            StateHasChanged();
            await http.GetFromJsonAsync<List<Student>>("https://localhost:7041/api/Students");
            navigationManager.NavigateTo("/student-list", true);
        }
    }
}