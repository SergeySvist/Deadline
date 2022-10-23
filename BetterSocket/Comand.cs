using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace BetterSocket
{
    [Serializable]
    public class Command
    {
        public string Action { get; set; }
        public string Sender { get; set; }
        public List<string> Receivers { get; set; }
        public string Description { get; set; }

        public Command(string action, string sender, List<string> receivers, string description)
        {
            Action = action;
            Sender = sender;
            Receivers = new List<string>(receivers);
            Description = description;
        }

        public string Serialize()
        {
            var res = JsonSerializer.SerializeToElement(this);
            return res.GetRawText();
        }

        static public Command Deserialize(string message)
        {
            var res = JsonSerializer.Deserialize(message, typeof(Command));
            return res as Command;
        }
    }
}
