namespace AdvancedCSharpProgrammingCourse.ConsoleApp;

public class Program
{
    private static void Main(string[] args)
    {
        var musicPlayer = new MusicPlayer();
        Subscriber sub1 = new("user1");
        Subscriber sub2 = new("user2");

        musicPlayer.SongPlayed += sub1.SongPlayedHandler;
        musicPlayer.SongPaused += sub1.SongPausedHandler;
        musicPlayer.SongStopped += sub1.SongStoppedHandler;
        musicPlayer.SongSkipped += sub1.SongSkippedHandler;

        musicPlayer.SongPlayed += sub2.SongPlayedHandler;
        musicPlayer.SongPaused += sub2.SongPausedHandler;
        musicPlayer.SongStopped += sub2.SongStoppedHandler;
        musicPlayer.SongSkipped += sub2.SongSkippedHandler;

        while (true)
        {
            Console.WriteLine("\nEnter the action (play, pause, stop, skip) or 'exit' to end:");

            string action = Console.ReadLine().ToLower();

            if (action == "exit")
                break;

            Console.WriteLine("Enter the song title:");

            string songTitle = Console.ReadLine();

            switch (action)
            {
                case "play":
                    musicPlayer.Play(songTitle);
                    break;
                case "pause":
                    musicPlayer.Pause(songTitle);
                    break;
                case "stop":
                    musicPlayer.Stop(songTitle);
                    break;
                case "skip":
                    Console.WriteLine("Enter the next song title:");
                    string nextSongTitle = Console.ReadLine();
                    musicPlayer.Skip(songTitle, nextSongTitle);
                    break;
                default:
                    Console.WriteLine("Invalid action. Please enter play, pause, stop, skip, or exit.");
                    break;
            }
        }
    }
}

public class Subscriber
{
    public string Name { get; }

    public Subscriber(string name)
    {
        Name = name;
    }

    public void SongPlayedHandler(string songTitle)
    {
        Console.WriteLine($"{Name} is now enjoying: {songTitle}");
    }

    public void SongPausedHandler(string songTitle)
    {
        Console.WriteLine($"{Name} paused: {songTitle}");
    }

    public void SongStoppedHandler(string songTitle)
    {
        Console.WriteLine($"{Name} stopped: {songTitle}");
    }

    public void SongSkippedHandler(string nextSongTitle)
    {
        Console.WriteLine($"{Name} skipped to: {nextSongTitle}");
    }
}

public delegate void SongEventHandler(string songTitle);

public class MusicPlayer
{
    public event SongEventHandler SongPlayed;

    public event SongEventHandler SongPaused;

    public event SongEventHandler SongSkipped;

    public event SongEventHandler SongStopped;

    public void Play(string songTitle)
    {
        Console.WriteLine($"Now playing: {songTitle}");

        SongPlayed?.Invoke(songTitle);
    }

    public void Pause(string songTitle)
    {
        Console.WriteLine($"Now pausing: {songTitle}");

        SongPaused.Invoke(songTitle);
    }

    public void Stop(string songTitle)
    {
        Console.WriteLine($"Now stoping: {songTitle}");

        SongStopped.Invoke(songTitle);
    }

    public void Skip(string currentSongTitle, string nextSongTitle)
    {
        Console.WriteLine($"Skipped from: {currentSongTitle} to: {nextSongTitle}");

        SongSkipped?.Invoke(nextSongTitle);
    }
}