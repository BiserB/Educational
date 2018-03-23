namespace Logger_Lib.Models.Contracts
{
    public interface ILayout
    {
        string LayoutFormat(IMessage message);
    }
}