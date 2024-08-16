using EARepository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EACQRS.Pipelines.MediatrRequestLogging
{
    public class LoggeableRequest(string commandName, int userId) : EAEntity
    {
        public string CommandName { get; set; } = commandName;
        public int UserId { get; set; } = userId;
    }
}
