namespace Tsw.Args.Net.Help
{
    internal record ArgumentDoc(
        string Name, 
        int Position, 
        bool Required, 
        string Text, 
        bool FixedValue);
}
