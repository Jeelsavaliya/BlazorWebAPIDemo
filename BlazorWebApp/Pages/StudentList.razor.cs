using BlazorClass;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;


namespace BlazorWebApp.Pages
{
    public partial class StudentList
    {
        [Inject]
        public HttpClient http { get; set; }
        [Inject]
        NavigationManager navigationManager { get; set; }
        public List<Student> students { get; set; } = new();

        //public Student student = new();


        protected override async Task OnInitializedAsync()
        {
            students = await http.GetFromJsonAsync<List<Student>>("https://localhost:7041/api/Students");

        }
        public void AddStd()
        {
            navigationManager.NavigateTo("/add-student", true);
        }

        public async void Delete(int Id)
        {
            await http.DeleteAsync("https://localhost:7041/api/Students/" + Id);
            StateHasChanged();
            navigationManager.NavigateTo("/student-list", true);
        }

        public async void UpdateStudent(int Id)
        {
            navigationManager.NavigateTo($"/edit-student/{Id}", true);
        }
    }

}
