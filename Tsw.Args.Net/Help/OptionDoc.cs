namespace Tsw.Args.Net.Help
{
    internal record OptionDoc(
        string Name, 
        string ShortcutName, 
        bool Required, 
        string Text);
}
