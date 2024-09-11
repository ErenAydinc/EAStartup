using Core.EADomain;

namespace Core.EAApplication.MediatrRequestLogging
{
    public class LoggeableRequest(string commandName, int userId) : EAEntity
    {
        public string CommandName { get; set; } = commandName;
        public int UserId { get; set; } = userId;
    }
}
