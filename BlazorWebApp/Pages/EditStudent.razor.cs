using BlazorClass;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorWebApp.Pages
{
    public partial class EditStudent
    {
        [Inject]
        public HttpClient http { get; set; }

        [Parameter]
        public int Id { get; set; }
        [Inject]
        NavigationManager navigationManager { get; set; }

        public Student student { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            student = await http.GetFromJsonAsync<Student>($"https://localhost:7041/api/Students/{Id}");
        }
        public async Task UpdateStudnet()
        {
            await http.PutAsJsonAsync<Student>($"https://localhost:7041/api/Students/{student.Id}", student);
            StateHasChanged();
            navigationManager.NavigateTo("/student-list");
        }
        
        public async Task BackToHome()
        {
            navigationManager.NavigateTo("/student-list");
        }
    }
}
