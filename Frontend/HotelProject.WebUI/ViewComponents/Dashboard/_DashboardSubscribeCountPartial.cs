using HotelProject.WebUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;


namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial : ViewComponent
    {
        //private readonly IHttpClientFactory _httpClientFactory;

        //public _DashboardSubscribeCountPartial(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClientFactory = httpClientFactory;
        //}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofile/sulecelepp"),
                Headers =
            {
                { "X-RapidAPI-Key", "c8dbedaf23msh4532f44e7910a46p1ba9c5jsnfc0c102b101e" },
                { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ResultInstagramFollowersDto resultInstagramFollowersDto = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);
                ViewBag.InstagramFollowers = resultInstagramFollowersDto.followers;
                ViewBag.InstagramFollowing = resultInstagramFollowersDto.following;

            }



            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter32.p.rapidapi.com/getProfile?username=donquijote_dq"),
                Headers =
            {
                { "X-RapidAPI-Key", "c8dbedaf23msh4532f44e7910a46p1ba9c5jsnfc0c102b101e" },
                { "X-RapidAPI-Host", "twitter32.p.rapidapi.com" },
            },
            };
            using (var response2 = await client.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body = await response2.Content.ReadAsStringAsync();
                ResultTwitterFollowersDto resultTwitterFollowersDto = JsonConvert.DeserializeObject<ResultTwitterFollowersDto>(body);
                ViewBag.TwitterFollowers = resultTwitterFollowersDto.data.user_info.followers_count;
                ViewBag.TwitterFollowing = resultTwitterFollowersDto.data.user_info.friends_count;
            }


            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Fsulecelep%2F&include_skills=false"),
                Headers =
            {
                { "X-RapidAPI-Key", "c8dbedaf23msh4532f44e7910a46p1ba9c5jsnfc0c102b101e" },
                { "X-RapidAPI-Host", "fresh-linkedin-profile-data.p.rapidapi.com" },
            },
            };
            using (var response3 = await client.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body = await response3.Content.ReadAsStringAsync();
                ResultLinkedinFollowersDto resultLinkedinFollowersDto = JsonConvert.DeserializeObject<ResultLinkedinFollowersDto>(body);
                ViewBag.LinkedinFollowers = resultLinkedinFollowersDto.data.followers_count;
            }

            //BAZI API'lerin 20 kullanım hakkı var o yüzden hata alınırsa diye
            //ViewBag.InstagramFollowers = 450;
            //ViewBag.InstagramFollowing = 470;
            //ViewBag.TwitterFollowers = 388;
            //ViewBag.TwitterFollowing = 348;
            //ViewBag.LinkedinFollowers = 543;
            return View();
        }
    }
}
