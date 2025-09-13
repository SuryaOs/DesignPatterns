namespace Behavioral;

/*
it captures and stores the state as checkpoint and restore it later.
keys
    originator - the object whose states needs to be saved
    memento - the object that stores the state snapshot
    caretaker - the object that keeps track of mementos
*/
public interface IMemento
{
    string GetState();
}
public class TextEditorMemento : IMemento
{
    private string state;
    public TextEditorMemento(string state)
    {
        this.state = state;
    }
    public string GetState()
    {
        return state;
    }
}
public class TextEditor
{
    private string content = "";
    public void Set(string words)
    {
        content += words;
    }
    public string Get()
    {
        return content;
    }
    public IMemento Save()
    {
        return new TextEditorMemento(content);
    }
    public void Restore(IMemento memento)
    {
        content = memento.GetState();
    }
}
public class History
{
    private Stack<IMemento> _history = new();
    private TextEditor _textEditor;
    public History(TextEditor textEditor)
    {
        _textEditor = textEditor;
    }
    public void Push()
    {
        _history.Push(_textEditor.Save());
    }
    public void Pop()
    {
        if (_history.Count > 0)
            _textEditor.Restore(_history.Pop());
        else
            Console.WriteLine("No history found");
    }
}