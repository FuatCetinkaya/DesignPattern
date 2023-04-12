namespace Adapter;


    // Bu örnekte, IMediaPlayer ve IVideoPlayer adında iki farklı arayüz tanımladık. MediaPlayer sınıfı, ses dosyalarını oynatan IMediaPlayer arayüzünü uygular.
    // VideoPlayer sınıfı ise, video dosyalarını oynatan IVideoPlayer arayüzünü uygular. İki arayüzün farklı metodları olduğu için, doğrudan birbirleriyle
    // iletişim kuramazlar.

    //VideoPlayerAdapter adında bir adapter sınıfı oluşturarak, IMediaPlayer arayüzünü uyguladık ve IVideoPlayer nesnesini kabul ettik.
    //Bu sayede, VideoPlayerAdapter sınıfı, IMediaPlayer arayüzü ile çalışan sistemlerde kullanılabilir hale geldi.

    //Adapter Pattern sayesinde, IMediaPlayer arayüzüne bağlı olan medya oynatıcısının, IVideoPlayer arayüzü ile çalışan video oynatıcısını kullanabilmesini sağladık.
    //Bu şekilde, mevcut kodları değiştirmeden, farklı arayüzlerin birbiriyle iletişim kurmasını sağlamış olduk.
    //Bu pattern olmadan, her iki sınıfı da değiştirmeniz veya ekstra kodlar yazmanız gerekebilir, bu da kod karmaşasına ve esneklik kaybına neden olabilir.


    // Target Interface
    public interface IMediaPlayer
    {
        void PlayAudio(string fileName);
    }

    public class MediaPlayer : IMediaPlayer
    {
        public void PlayAudio(string fileName)
        {
            Console.WriteLine($"Playing audio: {fileName}");
        }
    }

    // Adaptee Interface
    public interface IVideoPlayer
    {
        void PlayVideo(string fileName);
    }

    public class VideoPlayer : IVideoPlayer
    {
        public void PlayVideo(string fileName)
        {
            Console.WriteLine($"Playing video: {fileName}");
        }
    }

    // Adapter Class
    public class VideoPlayerAdapter : IMediaPlayer
    {
        private readonly IVideoPlayer _videoPlayer;

        public VideoPlayerAdapter(IVideoPlayer videoPlayer)
        {
            _videoPlayer = videoPlayer;
        }

        public void PlayAudio(string fileName)
        {
            _videoPlayer.PlayVideo(fileName);
        }
    }

    class Program1
    {
        static void Main1(string[] args)
        {
            IMediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.PlayAudio("music.mp3");

            IVideoPlayer videoPlayer = new VideoPlayer();
            IMediaPlayer adaptedVideoPlayer = new VideoPlayerAdapter(videoPlayer);
            adaptedVideoPlayer.PlayAudio("video.mp4");
        }
    }


