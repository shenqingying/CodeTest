using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Models.WX
{
    public class Signature
    {
        private string timestamp;

        public string Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }


        private string noncestr;

        public string Noncestr
        {
            get { return noncestr; }
            set { noncestr = value; }
        }


        private string signa;

        public string Signa
        {
            get { return signa; }
            set { signa = value; }
        }

        


        private string ticket;

        public string Ticket
        {
            get { return ticket; }
            set { ticket = value; }
        }


    }



}