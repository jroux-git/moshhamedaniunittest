using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
namespace TestNinja.Mocking
{
    public class VideoService
    {
        public IFileReader propFileReader { get; set; }
        private IFileReader _constFileReader { get; set; }
        private IVideoRepository _videoRepository { get; set; }

        public VideoService()
        {
            propFileReader = new FileReader();
        }

        public VideoService(IFileReader fileReader)
        {
            _constFileReader = fileReader;
        }

        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public string ReadVideoTitle_Original()
        {
            var str = File.ReadAllText("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string ReadVideoTitle_MethodInjection(IFileReader fileReader)
        {
            var str = fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            
            if (video == null)
                return "Error parsing the video.";
            
            return video.Title;
        }

        public string ReadVideoTitle_PropertyInjection()
        {
            var str = propFileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            
            if (video == null)
                return "Error parsing the video.";
            
            return video.Title;
        }

        public string ReadVideoTitle_ConstructorInjection()
        {
            var str = _constFileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);

            if (video == null)
                return "Error parsing the video.";
            
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();
            var videos = _videoRepository.GetUnprocessedVideos();

            foreach (var v in videos)
                videoIds.Add(v.Id);

            return String.Join(",", videoIds);
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}