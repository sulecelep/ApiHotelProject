using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5057/api/Contact");
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("http://localhost:5057/api/Contact/GetContactCount");
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client1.GetAsync("http://localhost:5057/api/SendMessage/GetSendMessageCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();

                //var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
                ViewBag.contactCount = jsonData1;
                ViewBag.sendMessageCount = jsonData2;
            
                return View(values);
            }
            return View();

        }
        public async Task<IActionResult> Sendbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5057/api/SendMessage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendboxDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddSendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto model)
        {
            model.SenderMail = "admin@gmail.com";
            model.SenderName = "admin";
            model.Date = DateTime.Parse(DateTime.Now.ToShortDateString());


            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5057/api/SendMessage", stringcontent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }
            return View();
        }

        public PartialViewResult SideBarAdminContactPartial()
        {
            
            return PartialView();
        }
        public PartialViewResult SideBarAdminContactCategoryPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public async Task<IActionResult> MessageDetailsBySendbox(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5057/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIDDto>(jsonData);

                return View(values);
            }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> MessageDetailsByInbox(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5057/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InboxContactDto>(jsonData);

                return View(values);
            }
            return View();

        }

    }
}
