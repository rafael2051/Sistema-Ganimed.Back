using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Ganimedes.Domain.Entities
{
    public class ResponseMessage
    {
        public string message { get; set; }

        public ResponseMessage(string message)
        {
            this.message = message;
        }
    }
}
