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
    public class SocialDataController : ControllerBase
    {
        public ISocialDataService _ISocialDataService;
        private Settings _settings;
        public string path;
        public SocialDataController(ISocialDataService ISocialDataService, IConfiguration config,
             IOptions<Settings> settings)
        {
            _ISocialDataService = ISocialDataService;
            _settings = settings.Value;
            path = _settings.Path;
        }
        [Route("getFacebookData")]
        [HttpPost]
        public async Task<ServiceResponse<FacebookResponse>> GetFacebookData(FacebookRequest facebookRequest)
        {
            _ISocialDataService.Write(facebookRequest,path +"facebook.txt");
            var fileJson = await _ISocialDataService.Read<FacebookRequest>(path +"facebook.txt");

            var c = new Comment
            {
                Number = fileJson.CommentsCount
            };

            var l = new Like
            {
                Number = fileJson.LikesCount
            };

            var r = new FacebookResponse
            {
                Comments = c,
                Likes = l
            };

         
            var res =  new ServiceResponse<FacebookResponse>() { Data = r, Message = "Success", Success = true };           
            return  res;
        }

        [Route("getInstagramData")]
        [HttpPost]
        public async Task<ServiceResponse<InstagramResponse>> GetInsatagramData(InstagramRequest instagramRequest)
        {
           
            _ISocialDataService.Write(instagramRequest, path + "instagram.txt");
            var fileJson = await _ISocialDataService.Read<InstagramRequest>(path +"instagram.txt");
            var r = new InstagramResponse() { NumberOfFollowers = fileJson.NumberOfFollowers };
            var res = new ServiceResponse<InstagramResponse>() { Data = r, Message = "Success", Success = true };
            return res;
        }

        [Route("getYoutubeData")]
        [HttpPost]
        public async  Task<ServiceResponse<YouTubeResponse>> GetYouTubeData(YouTubeRequest youtubeRequest)
        {
            
            _ISocialDataService.Write(youtubeRequest, path + "youtube.txt");
            var fileJson = await _ISocialDataService.Read<YouTubeRequest>(path +"youtube.txt");
            var r = new YouTubeResponse() { NumberOfViews = fileJson.NumberOfViews };
            var res = new ServiceResponse<YouTubeResponse>() { Data = r, Message = "Success", Success = true };

            return res;
        }
    }
}
