namespace Structural;
// shares a common set of intrinsic states between multiple objects to save memory
public class Character
{
    public char text; // common intrisinic
    public int fontSize;
    public Character(char text, int fontSize)
    {
        this.text = text;
        this.fontSize = fontSize;
    }
    public void show(float x, float y) // extrisinic or unique
    {
        Console.WriteLine($"{text} {fontSize}px at co-ordinates {x} {y} ");
    }
}
public class CharacterGlyphs
{
    private Dictionary<char, Character> dict = new();
    public int count => dict.Count;
    public Character Get(char text, int fontSize)
    {
        if (!dict.ContainsKey(text))
        {
            dict.Add(text, new Character(text, fontSize));
        }
        return dict[text];
    }
}