using System.Collections;

namespace Behavioral;

// it allows the client to access the elements in sequence

#region Custom Implementation
/*
1) Similar to Implementing IEnumerable and IEnumerator
    Iterator<T> => IEnumerator<T>
    IterableCollection<T> = IEnumerable<T>
    hasNext() = MoveNext();
    next() = Current with MoveNext();
    CreateIterator = GetEnumerator()
*/
public interface Iterator<T>
{
    bool hasNext();
    T next();
}
public interface IterableCollection<T>
{
    Iterator<T> CreateIterator();
}
public class MusicPlayer : IterableCollection<string>
{
    public string[] songs;
    int index = -1;
    int size;
    public MusicPlayer(int size)
    {
        songs = new string[size];
        this.size = size;
    }
    public void Add(string song)
    {
        if (index > size) throw new ArgumentOutOfRangeException("Storage Full");
        songs[++index] = song;
    }

    public Iterator<string> CreateIterator()
    {
        return new MusicPlayerIterator(this);
    }

    public int GetSize()
    {
        return songs.Length;
    }
    public string GetSongAt(int index)
    {
        return songs[index];
    }
}
public class MusicPlayerIterator : Iterator<string>
{
    private MusicPlayer musicPlayer;
    int index = 0;
    public MusicPlayerIterator(MusicPlayer musicPlayer)
    {
        this.musicPlayer = musicPlayer;
    }
    public bool hasNext()
    {
        return index < musicPlayer.GetSize();
    }
    public string next()
    {
        return musicPlayer.GetSongAt(index++);
    }
}

#endregion

#region Inbuilt Custom Iterator
public class VLCPlayer : IEnumerable<string>
{
    public string[] songs;
    int index = -1;
    int size;
    public VLCPlayer(int size)
    {
        songs = new string[size];
        this.size = size;
    }
    public void Add(string song)
    {
        if (index > size) throw new ArgumentOutOfRangeException("Storage Full");
        songs[++index] = song;
    }

    public IEnumerator<string> GetEnumerator()
    {
        for (int i = 0; i < songs.Length; i++)
        {
            yield return songs[i];
        }
    }

    public int GetSize()
    {
        return songs.Length;
    }
    public string GetSongAt(int index)
    {
        return songs[index];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator(); // For Non Generic
    }
}
#endregion