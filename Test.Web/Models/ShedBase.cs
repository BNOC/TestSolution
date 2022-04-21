using Microsoft.AspNetCore.Components;
using Test.Web.Services.Contracts;

namespace Test.Web.Models
{
    public class ShedBase : ComponentBase
    {
        [Inject]
        public IShedService ShedService { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        //public IEnumerable<Box> Boxes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var shed = await ShedService.GetShed(1);
            Id = shed.Id;
            Name = shed.Name;
        }
    }
}
