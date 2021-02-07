using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NotifyScreenAPI.Services
{
    public interface ISocialDataService
    {
        Task<T> Read<T>(string path);
        void Write<T>(T model,string path);
    }
    public class SocialDataService : ISocialDataService
    {
        
       
        public async Task<T>  Read<T>(string path)
        {            
            return await Task.Run(()=> JsonConvert.DeserializeObject<T>(File.ReadAllText(path)));           
        }
        public void Write<T>(T model,string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(model));
        }
    }
}
