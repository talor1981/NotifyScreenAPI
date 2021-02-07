using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NotifyScreenAPI.Models;
using NotifyScreenAPI.Models.Facebook;
using NotifyScreenAPI.Models.Instagram;
using NotifyScreenAPI.Models.YouTube;
using NotifyScreenAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotifyScreenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FetchController : ControllerBase
    {
        public ISocialDataService _ISocialDataService;
        private readonly IConfiguration _config;
        private Settings _settings;


        public FetchController(ISocialDataService ISocialDataService, IConfiguration config,
            IOptions<Settings> settings)
        {
            _ISocialDataService = ISocialDataService;
            _config = config;
            _settings = settings.Value;

        }
        [Route("getData")]
        [HttpGet]
        public async Task<ServiceResponse<FetchResponse>> getData()
        {
            var path = _settings.Path;
            var facebookJson = await _ISocialDataService.Read<FacebookRequest>(path + "facebook.txt");
            var instagramJson = await _ISocialDataService.Read<InstagramRequest>(path + "instagram.txt");
            var youtubeJson = await _ISocialDataService.Read<YouTubeRequest>(path+ "youtube.txt");

            var r = new FetchResponse();
            r.facebook = new FacebookData() { Comments = facebookJson.CommentsCount, Likes = facebookJson.LikesCount };
        
            r.instagram = new InstagramData() { Follows = instagramJson.NumberOfFollowers };
            r.youtube = new YouTubeData() { Views = youtubeJson.NumberOfViews };

            var res = new ServiceResponse<FetchResponse>() { Data = r, Message = "Success", Success = true };
            return res;
        }
    }
}
