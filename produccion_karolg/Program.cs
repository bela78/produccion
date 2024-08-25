//public enum MusicFormat
//{
//    MP3,
//    WAV,
//    FLAC,
//}
//public class MusicPlayer
//{
//    public void PlayMusic(MusicFormat format)
//    {
//        switch(format)
//        {
//            case MusicFormat.MP3:
//                Console.WriteLine(
//                    "Reproduciendo archivo MP3..."
//                    );
//                break;
//            case MusicFormat.WAV:
//                Console.WriteLine(
//                    "Reproduciendo archivo WAW..."
//                    );
//                break;
//                case MusicFormat.FLAC:
//                Console.WriteLine(
//                    "Reproduciendo archivo FLAW..."
//                    );
//                break;
//            default:
//                Console.WriteLine(
//                    "Formato no soportado"
//                    ); 
//                break;
//        }
//    }
//}
//class program
//{
//    static void Main(string[]args)
//    {
//        MusicPlayer player = new MusicPlayer();
//        player.PlayMusic(MusicFormat.MP3);
//    }
//}


using System;

public abstract class MusicPlayer
{
    public abstract void Play();
}

public class MP3Player : MusicPlayer
{
    public override void Play()
    {
        Console.WriteLine("Reproduciendo archivo MP3...");
    }
}
public class MP4Player : MusicPlayer
{
    public override void Play()
    {
        Console.WriteLine("reproduciendo archivo MP4...");
    }
}

public class WAVPlayer : MusicPlayer
{ 
    public override void Play()
    {
        Console.WriteLine("Reproduciendo archivo WAV...");
    }
}

public class FLACPlayer : MusicPlayer
{
    public override void Play()
    {
        Console.WriteLine("Reproduciendo archivo FLAC...");
    }
}
public abstract class MusicPlayerFactory
{
    public abstract MusicPlayer CreateMusicPlayer();
}
public class MP3PlayerFactory : MusicPlayerFactory
{
    public override MusicPlayer CreateMusicPlayer()
    {
        return new MP3Player();
    }
}
public class MP4PlayerFactory : MusicPlayerFactory
{
    public override MusicPlayer CreateMusicPlayer()
    {
        return new MP4Player();
    }
}


public class WAVPlayerFactory : MusicPlayerFactory
{
    public override MusicPlayer CreateMusicPlayer()
    {
        return new WAVPlayer();
    }
}

public class FLACPlayerFactory : MusicPlayerFactory
{
    public override MusicPlayer CreateMusicPlayer()
    {
        return new FLACPlayer();
    }
}

public enum MusicFormat
{
    MP3,
    WAV,
    FLAC,
    MP4
    
}
class Program
{
    static void Main(string[] args)
    {
        MusicPlayerFactory factory = GetFactory(MusicFormat.MP4);
        MusicPlayer player = factory.CreateMusicPlayer();
        player.Play();
    }

   
    static MusicPlayerFactory GetFactory(MusicFormat format)
    {
        return format switch
        {
            MusicFormat.MP3 => new MP3PlayerFactory(),
            MusicFormat.WAV => new WAVPlayerFactory(),
            MusicFormat.FLAC => new FLACPlayerFactory(),
            MusicFormat.MP4 => new MP4PlayerFactory(),
    
            _ => throw new ArgumentException("Formato no soportado")
        }; ;
    }
}

