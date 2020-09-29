using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class ZSL_BCST100
    {

        private string type;
        private string id;
        private string number;
        private string message;
        private string log_no;
        private string log_msg_no;
        private string message_v1;
        private string message_v2;
        private string message_v3;
        private string message_v4;
        private string parameter;
        private string row;
        private string field;
        private string system;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Number
        {
            get { return number; }
            set { number = value; }
        }        

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public string Log_no
        {
            get { return log_no; }
            set { log_no = value; }
        }

        public string Log_msg_no
        {
            get { return log_msg_no; }
            set { log_msg_no = value; }
        }        

        public string Message_v1
        {
            get { return message_v1; }
            set { message_v1 = value; }
        }        

        public string Message_v2
        {
            get { return message_v2; }
            set { message_v2 = value; }
        }        

        public string Message_v3
        {
            get { return message_v3; }
            set { message_v3 = value; }
        }       

        public string Message_v4
        {
            get { return message_v4; }
            set { message_v4 = value; }
        }        

        public string Parameter
        {
            get { return parameter; }
            set { parameter = value; }
        }        

        public string Row
        {
            get { return row; }
            set { row = value; }
        }        

        public string Field
        {
            get { return field; }
            set { field = value; }
        }        

        public string System
        {
            get { return system; }
            set { system = value; }
        }
    }
}
