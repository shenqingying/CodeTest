using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.Account
{
    public class FullTokenInfo
    {
        //Token字符串
        public string PublicToken { get; set; }
        public string SecretToken { get; set; }

        //Token内信息
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreateTime { get; set; }
        public int ExpireTime { get; set; }

        //Token外信息
        public string Password { get; set; } //一般只有Hash值
        public int StaffID { get; set; }

        //结果信息
        public bool Valid { get; set; }
        public string Type { get; set; } //尽量不用
        public string Message { get; set; }
    }
}
