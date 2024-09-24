using BlazorClass;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorWebApp.Pages
{
    public partial class AddStudent
    {
        [Inject]
        public HttpClient http {  get; set; }
        [Inject]
        NavigationManager navigationManager { get; set; }
        public Student student { get; set; } = new();

        public async Task Save()
        {
            http.PostAsJsonAsync("https://localhost:7041/api/Students", student);
            StateHasChanged();
            navigationManager.NavigateTo("/student-list", true);
        }

        public void BackToHome()
        {
            navigationManager.NavigateTo("/student-list",true);
        }
    }
}
