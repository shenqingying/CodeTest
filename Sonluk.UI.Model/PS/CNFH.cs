using Sonluk.UI.Model.PS.CNFHService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.PS
{
    public class CNFH
    {
        private CNFHSoapClient client = new CNFHSoapClient("CNFHSoap", AppConfig.Settings("RemoteAddress") + "PS/CNFH.asmx");
        public CNFHLIST ModifyCNFH(List<ZSL_GXCN> ZSL_GXCNList)
        {
            //return client.ModifyCNFH(ZSL_GXCNList,"");
            return client.ModifyCNFH(ZSL_GXCNList.ToArray(), "");
        }
        public WBSPARMS ReadWBSPARMS()
        {
            return client.ReadWBSPARMS("");
        }
        public ZSL_NetworkList SELECTJGNETWORK(string I_PSPNR, List<ET_TCNRFPT> IT_RFPNT)
        {
            return client.SELECTJGNETWORK(I_PSPNR,IT_RFPNT.ToArray(),"");
        }
        public PS_MSG UpdateNetwork(ZSL_NETWORK[] nodes)
        {
            return client.UpdateNetwork(nodes);
        }
        public ZSL_GXFHTABLE GXFHTABLE(PS_CXFHCS parslist)
        {
            return client.GXFHTABLE(parslist);
        }
        public PS_MSG SYNCCNDATA()
        {
           
            return client.SYNCCNDATA();
        }
        public ZSL_NetworkList NETWORKWARNING(int i_rows)
        {
            return client.NETWORKWARNING(i_rows);
        }

        public PS_MSG ZPSFUG_M_GZCN(ZSL_GZCN I_GZCN,ZSL_GZ_VLSCH[] relsit,string flag)
        {
            return client.ZPSFUG_M_GZCN(I_GZCN, relsit,flag);
        }
       
        public ZSL_GZCNList ZPSFUG_Q_GZCN(string GZMS)
        {
            return client.ZPSFUG_Q_GZCN(GZMS);
        }
        public PS_MSG ZPSFUG_M_CALENDAR(ZSL_CALENDARList nodes, string I_CALENDAY, string I_WORKDAY)
        {
            return client.ZPSFUG_M_CALENDAR(nodes, I_CALENDAY, I_WORKDAY);
        }
        public ZSL_CALENDARList ZPSFUG_Q_CALENDAR(string ksdate, string jsdate)
        {
            return client.ZPSFUG_Q_CALENDAR(ksdate, jsdate);
        }
        public GZCNREPORT ZPSFUG_Q_GZCNREPORT(string ksdate, string jsdate,string flag)
        {
            return client.ZPSFUG_Q_GZCNREPORT(ksdate, jsdate,flag);
        }

    }
}
