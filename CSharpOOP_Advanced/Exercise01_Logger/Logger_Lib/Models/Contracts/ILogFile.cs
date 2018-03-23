namespace Logger_Lib.Models.Contracts
{
    public interface ILogFile
    {
        string Path { get; }

        int Size { get; }

        void Write(string message);
    }
}