using System;
using System.Threading.Tasks;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;

namespace GettingHolidays
{
    class Program
    {
        const string apiKey = "AIzaSyCkHEq9efc73mgl0k3Ib7wwI54Gle5hX3M";
        const string pakCalendarID = "en-gb.pk#holiday@group.v.calendar.google.com";
        const string uaeCalendarID = "en-gb.ae.official#holiday@group.v.calendar.google.com";
        

        static async Task Main(string[] args)
        {
            Console.WriteLine("Just Checking");

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                ApiKey = apiKey,
                ApplicationName = "API key Example"
            });
            var request = service.Events.List(pakCalendarID);
            request.Fields = "items(summary,start,end)";
            var response = await request.ExecuteAsync();
            foreach (var item in response.Items)
            {
                Console.WriteLine($"Holiday: {item.Summary} start: {item.Start.Date} End: {item.End.Date}");
            }
            Console.ReadLine();


        }
    }
}
