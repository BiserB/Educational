using Logger_Lib.Models.Enums;

namespace Logger_Lib.Models.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }

        MessageLevel Level { get; }

        void AppendMessage(IMessage message);
    }
}