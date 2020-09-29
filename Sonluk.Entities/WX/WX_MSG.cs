using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.WX
{
    public class WX_MSG
    {
        public WX_MSG()
        {

        }
        //企业微信用
        string _touser;

        public string touser
        {
            get { return _touser; }
            set { _touser = value; }
        }
        string _toparty;

        public string toparty
        {
            get { return _toparty; }
            set { _toparty = value; }
        }
        string _totag;

        public string totag
        {
            get { return _totag; }
            set { _totag = value; }
        }
        string _msgtype;

        public string msgtype
        {
            get { return _msgtype; }
            set { _msgtype = value; }
        }
        int _agentid;

        public int agentid
        {
            get { return _agentid; }
            set { _agentid = value; }
        }
        TEXT _text;

        public TEXT text
        {
            get
            {
                if (_text == null)
                {
                    _text = new TEXT();
                }
                return _text;
            }
            set { _text = value; }
        }
        int _safe;

        public int safe
        {
            get { return _safe; }
            set { _safe = value; }
        }



        public class TEXT
        {
            string _content;

            public string content
            {
                get { return _content; }
                set { _content = value; }
            }
        }


        //公众号用
        //string _touser;

        //public string touser
        //{
        //    get { return _touser; }
        //    set { _touser = value; }
        //}
        string _template_id;

        public string template_id
        {
            get { return _template_id; }
            set { _template_id = value; }
        }
        string _url;

        public string url
        {
            get { return _url; }
            set { _url = value; }
        }
        MiniProgram _miniprogram;

        public MiniProgram miniprogram
        {
            get
            {
                if (_miniprogram == null)
                {
                    _miniprogram = new MiniProgram();
                }
                return _miniprogram;
            }
            set { _miniprogram = value; }
        }

        Data _data;

        public Data data
        {
            get
            {
                if (_data == null)
                {
                    _data = new Data();
                }
                return _data;
            }
            set { _data = value; }
        }








        public class MiniProgram
        {
            string _appid;

            public string appid
            {
                get { return _appid; }
                set { _appid = value; }
            }
            string _pagepath;

            public string pagepath
            {
                get { return _pagepath; }
                set { _pagepath = value; }
            }
        }

        public class Data
        {
            KeyWord _first;

            public KeyWord first
            {
                get
                {
                    if (_first == null)
                    {
                        _first = new KeyWord();
                    }
                    return _first;
                }
                set { _first = value; }
            }
            KeyWord _keyword1;

            public KeyWord keyword1
            {
                get
                {
                    if (_keyword1 == null)
                    {
                        _keyword1 = new KeyWord();
                    }
                    return _keyword1;
                }
                set { _keyword1 = value; }
            }
            KeyWord _keyword2;

            public KeyWord keyword2
            {
                get
                {
                    if (_keyword2 == null)
                    {
                        _keyword2 = new KeyWord();
                    }
                    return _keyword2;
                }
                set { _keyword2 = value; }
            }
            KeyWord _keyword3;

            public KeyWord keyword3
            {
                get
                {
                    if (_keyword3 == null)
                    {
                        _keyword3 = new KeyWord();
                    }
                    return _keyword3;
                }
                set { _keyword3 = value; }
            }
            KeyWord _keyword4;

            public KeyWord keyword4
            {
                get
                {
                    if (_keyword4 == null)
                    {
                        _keyword4 = new KeyWord();
                    }
                    return _keyword4;
                }
                set { _keyword4 = value; }
            }
            KeyWord _remark;

            public KeyWord remark
            {
                get
                {
                    if (_remark == null)
                    {
                        _remark = new KeyWord();
                    }
                    return _remark;
                }
                set { _remark = value; }
            }
        }

        public class KeyWord
        {
            string _value;

            public string value
            {
                get { return _value; }
                set { _value = value; }
            }
            string _color;

            public string color
            {
                get { return _color; }
                set { _color = value; }
            }
        }



    }
}
