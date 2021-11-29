using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IVideoRepository
    {
        IEnumerable<Video> GetUnprocessedVideos();
        bool AddVideo(Video video);
    }

    public class VideoRepository: IVideoRepository
    {
        private VideoContext _videoContext { get; set; }

        public VideoRepository()
        {
            _videoContext = new VideoContext();
        }

        public IEnumerable<Video> GetUnprocessedVideos()
        {
            using (_videoContext)
            {
                return (from video in _videoContext.Videos
                        where !video.IsProcessed
                        select video).ToList();
            }
        }

        public bool AddVideo(Video video)
        {
            using (_videoContext)
            {
                _videoContext.Videos.Add(video);
                _videoContext.SaveChanges();
            }

            return true;
        }
    }
}
