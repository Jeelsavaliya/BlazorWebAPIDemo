using BlazorClass;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;


namespace BlazorWebApp.Pages
{
    public partial class StudentList
    {
        [Inject]
        public HttpClient http { get; set; }
        public List<Student> students { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            students = await http.GetFromJsonAsync<List<Student>>("https://localhost:7041/api/Students");
        }
    }
}
