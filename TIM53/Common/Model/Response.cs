using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public enum STATUS_CODES
    {
        REJECTED = 3000,
        BAD_FORMAT = 5000,
        SUCCESS = 2000
    }

    public class Odgovor
    {
        public string Status { get; set; }
        public STATUS_CODES StatusCode { get; set; }
        public object Payload { get; set; }

        public Odgovor(STATUS_CODES code, object payload)
        {
            Status = code.ToString();
            StatusCode = code;
            payload = payload;
        }

        public Odgovor()
        {

        }
    }
}
