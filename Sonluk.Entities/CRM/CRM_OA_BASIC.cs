using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_OA_BASIC
    {

        string _LoginName;

        public string LoginName
        {
            get { return _LoginName; }
            set { _LoginName = value; }
        }
        string _TemplateCode;

        public string TemplateCode
        {
            get { return _TemplateCode; }
            set { _TemplateCode = value; }
        }
        string _Subject;

        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }
    }
}
