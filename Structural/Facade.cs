namespace Structural;
// provides single entry point to complex subsystem

# region subsystems
public class Light
{
    public void On() => Console.WriteLine("Lights On");
    public void Dim(int level) => Console.WriteLine($"Lights dimmed to {level}");
    public void Off() => Console.WriteLine("Lights Off");
}
public class DvdPlayer
{
    public void On() => Console.WriteLine("Dvd Player On");
    public void Play(string movie) => Console.WriteLine($"Playing {movie}");
    public void Pause() => Console.WriteLine("Paused");
    public void Off() => Console.WriteLine("Dvd Player Off");
}
public class Projector
{
    public void On() => Console.WriteLine("Projector On");
    public void Off() => Console.WriteLine("Projector Off");
}
public class Sound
{
    public void On() => Console.WriteLine("Speaker On");
    public void SetVolume(int level) => Console.WriteLine($"Increased Volume To {level}");
    public void Off() => Console.WriteLine("Speaker Off");

}
#endregion

public class HomeTheatreFacade
{
    private Light _light;
    private DvdPlayer _dvdPlayer;
    private Projector _projector;
    private Sound _sound;
    public HomeTheatreFacade(Light light, DvdPlayer dvdPlayer, Projector projector, Sound sound)
    {
        _light = light;
        _dvdPlayer = dvdPlayer;
        _projector = projector;
        _sound = sound;
    }
    public void WatchMovie(string movieName, int volume)
    {
        _light.On();
        _projector.On();
        _dvdPlayer.On();
        _dvdPlayer.Play(movieName);
        _sound.On();
        _sound.SetVolume(volume);
        _light.Dim(5);
    }
    public void EndMovie()
    {
        _sound.Off();
        _projector.Off();
        _dvdPlayer.Off();
        _light.Off();
    }
}