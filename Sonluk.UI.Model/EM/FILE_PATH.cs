using Sonluk.UI.Model.EM.FILE_PATHService;
using Sonluk.UI.Model.MODEL;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.EM
{
    public class FILE_PATH
    {
        private FILE_PATHSoapClient client = new FILE_PATHSoapClient("FILE_PATHSoap", AppConfig.Settings("RemoteAddress") + "EM/FILE_PATH.asmx");
        public MES_RETURN_UI Upload(string type, byte[] fileData, string fileName, string[] dictionarys)
        {
            MES_RETURN mr = client.UploadService(type, fileData, fileName, dictionarys);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;

        }
        public MES_RETURN_UI DeleteFileService(string[] fileName)
        {
            MES_RETURN mr = client.DeleteFileService(fileName);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;

        }
       
        public MES_RETURN_UI GetURLByReadID(int id, string ptoken)
        {
            MES_RETURN mr = client.GetURLByReadID(id, ptoken);
            MES_RETURN_UI mrui = new MES_RETURN_UI();
            mrui.TYPE = mr.TYPE;
            mrui.MESSAGE = mr.MESSAGE;
            return mrui;
        }
        public EM_FILE_PATH Read(string typems,string token)
        {
            EM_FILE_PATH rst = client.Read(typems, token);
            return rst;
        }
        public EM_FILE_PATH Readbypathid(int typeid, string token)
        {
            EM_FILE_PATH rst = client.ReadByID(typeid, token);
            return rst;
        }
        
    }
}
