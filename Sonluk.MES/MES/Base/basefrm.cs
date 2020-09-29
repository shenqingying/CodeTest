using Sonluk.MES.MES.model;
using Sonluk.UI.Model.MES.MES_LoginService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sonluk.UI.Model.MES.PD_SCRWService;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
using Sonluk.UI.Model.MES.TM_TMINFOService;
using Sonluk.UI.Model.MES.TM_CZRService;
using Sonluk.UI.Model.MODEL;
using Sonluk.MES.MES.publics;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using Sonluk.MES.MES.main;
using System.Threading;
using Sonluk.UI.Model.MES.MES_WLKCBSService;
using Sonluk.UI.Model.MES.SY_MATERIALService;
namespace Sonluk.MES.MES.Base
{
    public partial class basefrm : Form
    {
        #region enum区域
        public enum Date_Type
        {
            year = 1,
            month = 2,
            day = 3,
            hour = 4,
            min = 5

        }
        public enum Print_Type
        {
            none = 0,
            rk = 374,
            lot = 375,
            zjlot = 376,
            fujilot = 377,
            zxlot = 378,
            bblot = 411,
            zfsd = 379,
            wlrk = 373,
            zhdc = 414,
            wlrkLot = 451,
            zswllot = 621,
            zswlbsk = 622,
            cphwbs = 380

        }
        public enum TM_Type
        {
            none = 0,
            staffno = 1,
            gd = 2,
            ph = 3,
            tpm = 4,
            rwd = 5,
            sbbh = 6,
            wllot = 7
        }
        public enum Rigth_Type
        {
            none = 0,
            gangketl_cc = 82,
            jidiantitl_cc = 83,
            fujitl = 84,
            fujicc = 85,
            zhengjicc = 87,
            zhuxiantl = 88,
            zhuxiancc = 89,
            baobiaocc = 90,
            baozhuangcc = 94,
            wlrkdy = 97,
            gmgtl_cc = 99,
            mfqqingxi = 100,
            fujifengkoujitl_cc = 101,
            zhujizhengjitl = 102,
            tmbd = 105,
            sgsm = 106,
            dczztl_cc = 107,
            configSetting = 110,
            ddjtl_cc = 114,//导电剂投料产出
            rwdsm = 115,
            tbprint = 116,
            tmInfoUpdate = 118,
            sudianfangong = 120,
            zhengjifengkoujitl_cc = 122,
            tmbdLimit = 400,   //和条码补打功能一样，控制工厂和工作中心的权限
            zswllotdy = 401    //物料lot打印

        }
        public enum Msg_Type
        {
            fieldcxh,

            unamenotempty
            ,
            pwdnotempty
                ,
            msgtitle
                ,
            roleisnull
                ,
            frmActionTitle
                ,
            choiceCX
                ,
            accountnotgcrole
                ,
            rwdexcept
                ,
            sbhempty
                ,
            rolegdexcept
                ,
            titlemesgd
                ,
            titlegd
                ,
            titlewlxx
                ,
            titlewllb
                ,
            titlerwd
                ,
            titledcdj
                ,
            titledcxh
                ,
            titletskc
                ,
            fieldxh
                ,
            fieldwlxx
                ,
            fieldwllb
                ,
            fieldwllbdm
                ,
            fieldstatus
                ,
            fieldgdxx
                ,
            fieldtm
                ,
            fielddelete
                ,
            fieldtmdm
                ,
            fieldgc
                ,
            fieldtltmdm
                ,
            msgscangd
                ,
            msgscangdforczr
                ,
            msgscantminvalid
                ,
            msgbomunfinish
                ,
            msgczrnotempty
                ,
            msgbominvalid
                ,
            msgtmcf
                ,
            msgtlsuccess
                ,
            msgnoreplacerw
                ,
            fieldtpm
                ,
            msgscantpm
                ,
            msgscantpmforgl
                ,
            msgdayrwonlyone
                ,
            msgtpmnoempty
                ,
            msgglsuccess
                ,
            fonttype
                ,
            msgrwdempty
                ,
            titlechoice
                ,
            msgbsnoempty
                ,
            msgxdnoempty
                ,
            msgmbslnoempty
                ,
            msgsbcdnoempty
                ,
            msgprintnoempty
                ,
            msgbbpmnoempty
                ,
            titleyps
                ,
            titletpm
                ,
            msgbindsuccess
                ,
            msgbindfail
                ,
            msgprintnamenoempty
                ,
            msgbindA5success
                ,
            msgbindLotsuccess
                ,
            msgpleasebindLot
                ,
            msgpleasebindA5
                ,
            msgprintsettingfinish
                ,
            msgfirstbindA5
                ,
            msgfirstbindRM
                ,
            msgtestA5
                ,
            msgtestRM
                ,
            fieldA5paper
                ,
            fieldLotB
                ,
            fieldA5
                ,
            fieldLot
                ,
            msgwhetherdeleteprint
                ,
            msgunbindprint
                ,
            titlewlpzxmnd
                ,
            titlegysxx
                ,
            titlepo
                ,
            msgxcunfinish
                ,
            msgwhethercanclcz
                ,
            fieldrwreplace
                ,
            fieldconfirm
                ,
            fieldcancel
                ,
            msggdchocierow
                ,
            fieldrwd
                ,
            fieldgddm
                ,
            fieldmesgd
                ,
            fielderpgd
                ,
            fieldbcms
                ,
            fieldpldh
                ,
            fieldpfdh
                ,
            fieldqyrq
                ,
            fieldjsrq
                ,
            fieldsavesueecss
                ,
            msgscangh
                ,
            msgdelsuccess
                ,
            msgscantm
                ,
            msgtmnoexistorunrole
                ,
            msgtmexcept
                ,
            msggzzxnoempty
                ,
            msggcnoempty
                ,
            msgnosbh
                ,
            fieldsdscx
                ,
            msgnorw
                ,
            msgnodata
                ,
            msgscannosbh
                ,
            msgsbhnomacthgzzz
                ,
            msgsystemerror
                ,
            msgtlsjnoempty
                ,
            msgtlsjformat
                ,
            msgccsjnoempty
                ,
            msgccsjformat
                ,
            msgcpztnoempty
                ,
            msgsbznoempty
                ,
            msgslnoempey
                ,
            msgsbnorwd
                ,
            fieldrwqd
                ,
            fieldtodayrwfinish
                ,
            titleth
                ,
            titlepfdh
                ,
            titlepldh
                ,
            titlexfcd
                ,
            titlexfph
                ,
            fieldnotl
                ,
            fieldytl
                ,
            fieldycc
                ,
            fieldtlzt
                ,
            fielddylot
                ,
            titlepf
                ,
            titlezt
                ,
            titlewaitingfortl
                ,
            fieldth
                ,
            fieldpfh
                ,
            fieldgcpc
                ,
            fieldtlsj
                ,
            fieldwczt
                ,
            fieldxfcd
                ,
            fieldgyspc
                ,
            fieldsbh
                ,
            fieldrwwc
                ,
            filedwctl
                ,
            msgzsnorw
                ,
            msgxgcg
                ,
            msgtodaynodata
                ,
            msgnodataclickinvalid
                ,
            msgchoiceprintdata
                ,
            msgtmexceptnoprint
                ,
            msgmanytimesprint
                ,
            msgtmnoempty
                ,
            fieldrygl
                ,
            fieldgh
                ,
            fieldname
                ,
            fieldgw
                ,
            fieldrydm
                ,
            fieldxggw
                ,
            fieldscbzgl
                ,
            fieldslgl
                ,
            msgaddcontentnoempty
                ,
            msginsertsuccess
                ,
            msgaccountnoempty
                ,
            msgoldpwdnoempty
                ,
            msgnewpwdnoempty
                ,
            msgcqpwdnoempty
                ,
            msgnpwdnqopwd
                ,
            msgnpwdnqcpwd
                ,
            msgbindthenrestart
                ,
            titlexbcrw
                ,
            titleslspace
                ,
            titlexsspace
                ,
            titleztspace
                ,
            fielddyrkbs
                ,
            fielddylotB
                ,
            msgthdataexcept
                ,
            msginserttmfail
                ,
            msgcctsnoempty
                ,
            msgccxsnoempty
                ,
            msgccslnoempty
                ,
            msgccslextend
                ,
            msgscanlybtm
                ,
            msgchoiceprint
                ,
            msgloadtmfail
                ,
            msgtmsxecpect
                ,
            msggdroleexcept
                ,
            msggdgc
                ,
            msgcpscanrkbs
                ,
            msgrwdroleexcept
                ,
            msgtmnoonly
                ,
            msgscantmnosbh
                ,
            titlesbh
                ,
            fieldxfph
                ,
            msgtimesprintbxwctl
                ,
            msgwllbnoempty
                ,
            msgchoicetmlb
                ,
            msgkssjformat
                ,
            msgjssjformat
                ,
            msgksgtjs
                ,
            msgpcnoempty
                ,
            msgthnoempty
                ,
            msggzzxinvalid
                ,
            msgtmnorw
                ,
            msgbcnoempty
                ,
            msgbcnoemptyforlyb
                ,
            msgbcnoemptyforlotb
                ,
            fieldwlh
                ,
            msgtmstartwithP
                ,
            msgthisdigital
                ,
            msgerpdglengtheigth
                ,
            msgrwdlengtheleven
                ,
            msgscrqformat
                ,
            msgjlksrqformat
                ,
            msgjljsrqformat
                ,
            msgnotmclickinvalid
                ,
            msgnowlpzclickinvalid
                ,
            msgchoiceexportdata
                ,
            fieldtmInfoArr
                ,
            fieldtmInfoArr_zs
                ,
            titletmxx
                ,
            msgexportsuccess
                ,
            msgmacaddress
                ,
            msgscdatenoempty
                ,
            msgscdateformat
                ,
            msgtmsxempty
                ,
            msgprintdataexpect
                ,
            msgnotmreplacesure
                ,
            msgwhetherreplacetmtlxx
                ,
            msgslkssjnoempty
                ,
            msgsljssjnoempty
                ,
            msgslksqtjs
                ,
            msggzksformat
                ,
            msggzjsformat
                ,
            msggzksqtjs
                ,
            msgwlpzlengthtendigital
                ,
            msgtmlengthtwelve
                ,
            msgdbpzneedkcdf
                ,
            msgneedxcm
                ,
            msgatleastone
                ,
            msglengthqteigth
                ,
            fieldwlkcArr
                ,
            titlewlrkdc
                ,
            msgmtslnodigital
                ,
            msgfirstcreate
                ,
            msgcreatetmexpect
                ,
            msgcctmtsnoempty
                ,
            msgqsthqtone
                ,
            msgchoicerowalreadytm
                ,
            msgcreatetmsuccess
                ,
            msgpfdhnoempty
                ,
            msgpldhnoempty
                ,
            msgscbznoempty
                ,
            msgslnoempty
                ,
            msggdnomepty
                ,
            msggdnone
                ,
            fieldgd
                ,
            fieldqhpld
                ,
            msgqhpldsuccess
                ,
            msgqhpldthzero
                ,
            fieldzh
                ,
            fieldkssj
                ,
            fieldjssj
                ,
            fielddcxh
                ,
            fielddcdj
                ,
            fieldjltime
                ,
            fieldprint
                ,
            fieldmodify
                ,
            msgczrnoempty
                ,
            msgrwonlyone
                ,
            msgrwunexistbom
                ,
            titledcdjandxh
                ,
            fieldhidden
                ,
            msgrwexcept
                ,
            fieldshown
                ,
            msglr61havesdxt
                ,
            msgzhnoempty
                ,
            msgjssjnoempty
                ,
            msgkssjnqjssj
                ,
            msgpclengthten
                ,
            msgprintnoexsit
                ,
            msglocalnoprintinfo
                ,
            msgnoprinttypekey
                ,
            fieldtmgktlcc
                ,
            fieldjdttlcc
                ,
            fieldxgtl
                ,
            fieldxgcc
                ,
            fieldzjfcc
                ,
            fieldzxtl
                ,
            fieldzxcc
                ,
            fieldbbcc
                ,
            fieldbzcc
                ,
            fieldmfqqx
                ,
            fieldgmgtlcc
                ,
            fieldfjfkjtlcc
                ,
            fieldzzdctlcc
                ,
            fieldddjtlcc
                ,
            fieldzjfkj
                ,
            msgdyjexcept
                ,
            printbh
                ,
            printbhformat
                ,
            printdj
                ,
            printwlkcbs
                ,
            printckdj
                ,
            printzlxx
                ,
            printgc
                ,
            printkcdd
                ,
            printwlbm
                ,
            printgys
                ,
            printsl
                ,
            printxs
                ,
            printts
                ,
            printcz
                ,
            printpc
                ,
            printzydh
                ,
            printrkrq
                ,
            printbz
                ,
            printgyspc
                ,
            printbzxx
                ,
            printxctmxx
                ,
            printwl
                ,
            printwllotb
                ,
            printxh
                ,
            printscsj
                ,
            printgcpc
                ,
            printwlsx
                ,
            printwlms
                ,
            printtgf
                ,
            printsbh
                ,
            printcpzt
                ,
            printczg
                ,
            printxcm
                ,
            printpcxx
                ,
            printddtd
                ,
            printth
                ,
            printpfh
                ,
            printpldh
                ,
            printsycpgg
                ,
            printsbz
                ,
            printwlxx
                ,
            printzfsdhzb
                ,
            printscx
                ,
            printdcxh
                ,
            printz
                ,
            printzflb
                ,
            printsdzsl
                ,
            printzh
                ,
            printscsjd
                ,
            printcfts
                ,
            printscrq
                ,
            printsdslj
                ,
            printsdyt
                ,
            printtdrq
                ,
            printjyyqr
                ,
            printtbsspace
                ,
            printtuohao
                ,
            printclcj
                ,
            printgylx
                ,
            printsbjlotb
                ,
            printch
                ,
            printyps
                ,
            printddsl
                ,
            printbbpm
                ,
            printbzsl
                ,
            printhgx
                ,
            printzhuangtai
                ,

            printxcbzxx
                ,
            printshuanglu
                ,
            printsdlotb
                ,
            printzcdd
                ,
            printtsdd
                ,
            printxcf
                ,
            printtian
                ,

            printycl
                ,
            printwlrkbszz
                ,
            printxiang
                ,
            printshiyang
                ,
            printjz
                ,
            printkssj
                ,
            printjssj
                ,
            printmjh
                ,
            printmfq
                ,
            printwqh
                ,
            printjyq
                ,
            printys
                ,
            printwlbsk
            ,
            printclpbdm
                ,
            printwlmc
                ,
            printwcrq
                , printzan
            , printdcdj
            , printhg
            , printgtsl
            , printckdjno
        }
        #endregion
        #region set && get && property 及打印相关
        int _tempCount;

        public int TempCount
        {
            get { return _tempCount; }
            set { _tempCount = value; }
        }
        int _tempItem;

        public int TempItem
        {
            get { return _tempItem; }
            set { _tempItem = value; }
        }
        private int _fycount;

        public int Fycount
        {
            get { return _fycount; }
            set { _fycount = value; }
        }
        int _TuoHao;

        public int TuoHao
        {
            get { return _TuoHao; }
            set { _TuoHao = value; }
        }
        int _count;
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
        string _xs;
        public string Xs
        {
            get { return _xs; }
            set { _xs = value; }
        }
        string _ts;
        public string Ts
        {
            get { return _ts; }
            set { _ts = value; }
        }
        Print_Type _PrintType;

        public Print_Type PrintType
        {
            get { return _PrintType; }
            set { _PrintType = value; }
        }


        Rigth_Type _RigthType;

        public Rigth_Type RigthType
        {
            get { return _RigthType; }
            set { _RigthType = value; }
        }
        string _czlList;

        public string CzlList
        {
            get { return _czlList; }
            set { _czlList = value; }
        }
        List<ZSL_BCS303_BS> _wlrkList;

        public List<ZSL_BCS303_BS> WlrkList
        {
            get { return _wlrkList; }
            set { _wlrkList = value; }
        }
        Sonluk.UI.Model.MES.TM_TMINFOService.SELECT_MES_TM_TMINFO_PRINT[] _printList;

        public Sonluk.UI.Model.MES.TM_TMINFOService.SELECT_MES_TM_TMINFO_PRINT[] PrintList
        {
            get { return _printList; }
            set { _printList = value; }
        }
        List<Sonluk.UI.Model.MES.TM_TMINFOService.SELECT_MES_TM_TMINFO_PRINT> _tempPrintList;

        public List<Sonluk.UI.Model.MES.TM_TMINFOService.SELECT_MES_TM_TMINFO_PRINT> TempPrintList
        {
            get { return _tempPrintList; }
            set { _tempPrintList = value; }
        }


        Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_LIST _printHead;

        public Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_LIST PrintHead
        {
            get { return _printHead; }
            set { _printHead = value; }
        }
        Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_LIST[] _printChild;

        public Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_LIST[] PrintChild
        {
            get { return _printChild; }
            set { _printChild = value; }
        }
        private Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_ZFDCMX[] _PrintChildMX;

        public Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_ZFDCMX[] PrintChildMX
        {
            get { return _PrintChildMX; }
            set { _PrintChildMX = value; }
        }

        [DllImport("user32.dll")]
        public static extern int MessageBoxTimeoutA(IntPtr hwnd, string txt, string caption, int wtype, int wlange, int dwtimeout);
        protected basefactory factory = new basefactory();
        protected Rectangle rect = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
        protected IniFile ini = new IniFile();
        protected ServcieModel ServicModel = new ServcieModel();
        protected Judge judge = new Judge();
        string _SBHID;

        public string SBHID
        {
            get { return _SBHID; }
            set { _SBHID = value; }
        }
        CRM_JURISDICTION_GROUP[] _jList;

        public CRM_JURISDICTION_GROUP[] JList
        {
            get { return _jList; }
            set { _jList = value; }
        }
        MES_TM_TMINFO_INSERT_GL _MES_TM_TMINFO_INSERT_GL;

        public MES_TM_TMINFO_INSERT_GL MES_TM_TMINFO_INSERT_GL
        {
            get { return _MES_TM_TMINFO_INSERT_GL; }
            set { _MES_TM_TMINFO_INSERT_GL = value; }
        }
        public const string key_A5 = "A5";
        public const string key_lot = "LOT";
        public bool preview = false;
       
        private const string ZZWLGROUP = "30000006";
        public const string ZXVerifyStr = "原材料：";
        public const string BranchGC = "8020";
        public String_Zh zhlangu = new String_Zh();
        public String_Vi vilangu = new String_Vi();
        public int sl_currentHeight = 0;
        public int lotwidth = 276;
        public int lotTableWidth_left;
        public int lotTableWidth_right;
        public int line_part1 = 0;
        public int line_part2 = 0;
        public int line_part3 = 0;
        public int line_part4 = 0;
        public int line_part5 = 0;
        public int line_part6 = 0;
        public Font sl_font7;
        public Font sl_font7_Bold;
        public Font sl_font8;
        public Font sl_font8_Bold;
        public Font sl_font9;
        public Font sl_font9_Bold;
        public Font sl_font10;
        public Font sl_font10_Bold;
        public Font sl_font11;
        public Font sl_font11_Bold;
        public Font sl_font12;
        public Font sl_font12_Bold;
        public Font sl_font13;
        public Font sl_font13_Bold;
        public Font sl_font14;
        public Font sl_font14_Bold;
        public Font sl_font15;
        public Font sl_font15_Bold;
        public Font sl_font16;
        public Font sl_font16_Bold;
        public Font sl_font17;
        public Font sl_font17_Bold;
        public Font sl_font18;
        public Font sl_font18_Bold;
        public Font sl_font19;
        public Font sl_font19_Bold;
        public Font sl_font20;
        public Font sl_font20_Bold;
        public Font sl_font21;
        public Font sl_font21_Bold;
        public Font sl_font22;
        public Font sl_font22_Bold;
        public Font sl_font23;
        public Font sl_font23_Bold;
        public Font sl_font24;
        public Font sl_font24_Bold;
        public Font sl_font25;
        public Font sl_font25_Bold;
        public Font sl_font26;
        public Font sl_font26_Bold;
        public Font sl_font27;
        public Font sl_font27_Bold;
        public Font sl_font28;
        public Font sl_font28_Bold;
        public Font sl_font29;
        public Font sl_font29_Bold;
        public Font sl_font30;
        public Font sl_font30_Bold;
        public int lot_margin = 6;
        public int standardRowHeight = 20;
        public int standardTableRowHeight = 18;
        Pen sl_Pen = new Pen(Color.Black, 1);        
        Brush sl_bru = Brushes.Black;      
        StringFormat strFormatNear_Near = new StringFormat();
        StringFormat strFormatNear_Center = new StringFormat();
        StringFormat strFormatNear_Far = new StringFormat();
        StringFormat strFormatCenter_Near = new StringFormat();
        StringFormat strFormatCenter_Center = new StringFormat();
        StringFormat strFormatCenter_Far = new StringFormat();
        StringFormat strFormatFar_Near = new StringFormat();
        StringFormat strFormatFar_Center = new StringFormat();
        StringFormat strFormatFar_Far = new StringFormat();
        public basefrm()
        {
            InitializeComponent();
        }
        public string q(Msg_Type msgtype)
        {
            string inilangu = ini.IniReadValue(ini.Section_UserInfo, "langu");
            if (string.IsNullOrEmpty(inilangu)) inilangu = "zh-CN";
            string field = msgtype.ToString();
            string msg = "";
            switch (inilangu)
            {

                case "zh-CN":
                    try
                    {
                        msg = zhlangu.GetType().GetField(field).GetValue(zhlangu).ToString();
                    }
                    catch (Exception e)
                    {

                        msg = "zh-CN" + e.Message;
                    }

                    break;
                case "vi-VN":
                    try
                    {
                        msg = vilangu.GetType().GetField(field).GetValue(vilangu).ToString();
                    }
                    catch (Exception e)
                    {
                        msg = "vi-VN" + e.Message;
                    }

                    break;
                default:

                    break;
            }
            return msg;
        }
        /// <summary>
        /// 切换界面
        /// </summary>
        /// <param name="form"></param>
        public void push(Form form)
        {
            push(form, this);

            //this.Visible = false;
            //form.StartPosition = FormStartPosition.CenterScreen;
            //form.ShowDialog();
            //this.Hide();
            //this.Close();


        }
        public void push(Form form, Form currentForm)
        {

            currentForm.Visible = false;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
            currentForm.Hide();
            currentForm.Close();


        }
        /// <summary>
        /// dialog
        /// </summary>
        /// <param name="form"></param>
        public void show(Form form)
        {
            int ScreenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int ScreenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            //计算窗体显示的坐标值，可以根据需要微调几个像素

            form.StartPosition = FormStartPosition.CenterScreen;

            //this.Visible = false;

            form.ShowDialog();
            

        }
        #region 得到系统配置参数和统一方法
        public string getToken()
        {
            //return ini.IniReadValue(ini.Section_token, ini.Section_token);
            //public MES_LoginSoapClient client = new MES_LoginSoapClient("MES_LoginSoap", AppConfig.Settings("RemoteAddress") + "MES/MES_Login.asmx");
            //OperationConfig fig = new OperationConfig();
            //try
            //{
            //    OperationConfig.SetConfigValue("RemoteAddress", "http://192.168.0.15/API");
            //    //fig.modifyItem("RemoteAddress", "http://192.168.0.15/API");
            //    string a = fig.valueItem("RemoteAddress");
            //MES_LoginINFO loginfo = ServicModel.MES_Login.Login(getUserInfo("username"), getUserInfo("password"), "", "", 0, 1, 0);
            //    Common.token = loginfo.TokenInfo.access_token;

            //}
            //catch (Exception e)
            //{
            //    OperationConfig.SetConfigValue("RemoteAddress", "http://192.168.0.16/API");
            //    //fig.modifyItem("RemoteAddress", "http://192.168.0.16/API");
            //    string a = fig.valueItem("RemoteAddress");
            //    MES_LoginINFO loginfo = ServicModel.MES_Login.Login(getUserInfo("username"), getUserInfo("password"), "", "", 0, 1, 0);
            //    Common.token = loginfo.TokenInfo.access_token;

            //}
            return Common.token;

        }
        public string getGC(string key)
        {
            return ini.IniReadValue(ini.Section_GC, key);
        }
        public string getPrinter(string key)
        {
            return ini.IniReadValue(ini.Section_Print, key);
        }

        public string getUserInfo(string key)
        {
            return ini.IniReadValue(ini.Section_UserInfo, key);
        }
        public MES_SY_TYPEMXLIST[] GetDictionaryMX(int typeID)
        {
            MES_SY_TYPEMX TYPEMX = new MES_SY_TYPEMX();
            TYPEMX.TYPEID = typeID;
            TYPEMX.GC = Convert.ToString(getGC("value"));
            return ServicModel.SY_TYPEMX.SELECT(TYPEMX, getToken());
        }
        public MES_SY_TYPEMXLIST[] GetDictionaryMX(int typeID, string gc)
        {
            MES_SY_TYPEMX TYPEMX = new MES_SY_TYPEMX();
            TYPEMX.TYPEID = typeID;
            TYPEMX.GC = gc;
            return ServicModel.SY_TYPEMX.SELECT(TYPEMX, getToken());
        }
        public SELECT_MES_PD_SCRW GetRWbySBBH(string sbbh)
        {
            MES_PD_SCRW model = new MES_PD_SCRW();
            model.SBBH = sbbh;
            model.GC = getGC("value");
            //model.GZZXBH = getUserInfo("gzzxvalue");
            model.ZPRQ = GetSystemDate(Date_Type.hour, 0, "yyyy-MM-dd");
            return ServicModel.PD_SCRW.SELECT(model, getToken());
        }
        public string GetSystemDate(Date_Type type, int values, string format)
        {
            // year = 1,
            //month = 2,
            //day = 3,
            //hour = 4,
            //min = 5
            string currentdate = "";
            switch (type)
            {
                case Date_Type.year:
                    break;
                case Date_Type.month:
                    break;
                case Date_Type.day:
                    break;
                case Date_Type.hour:
                    currentdate = Convert.ToDateTime(ServicModel.PUBLIC_FUNC.GET_TIME(getToken())).AddHours(values).ToString(format);
                    break;
                case Date_Type.min:
                    break;
                default:
                    break;
            }
            return currentdate;
        }
        public string GetwllbRightTypeString(Rigth_Type rtype)
        {
            string Wllb = "";
            switch (rtype)
            {
                case Rigth_Type.gangketl_cc:
                    //Gzzxlb = 10;
                    Wllb = "涂膜钢壳";
                    break;
                case Rigth_Type.jidiantitl_cc:
                    Wllb = "集电体";
                    break;
                case Rigth_Type.fujitl:
                    //Gzzxlb = 12;
                    Wllb = "锌膏";
                    break;
                case Rigth_Type.fujicc:
                    //Gzzxlb = 12;
                    Wllb = "锌膏";
                    break;
                case Rigth_Type.zhengjicc:
                    //Gzzxlb = 11;
                    Wllb = "正极粉";
                    break;
                case Rigth_Type.zhuxiantl:
                    //Gzzxlb = 7;
                    Wllb = "素电";
                    break;
                case Rigth_Type.zhuxiancc:
                    //Gzzxlb = 7;
                    Wllb = "素电";
                    break;
                case Rigth_Type.baobiaocc:
                    //Gzzxlb = 14;
                    Wllb = "包标电池";
                    break;
                case Rigth_Type.baozhuangcc:
                    //Gzzxlb = 241;
                    Wllb = "成品";
                    break;
                case Rigth_Type.fujifengkoujitl_cc:
                    //Gzzxlb = 394;
                    Wllb = "负极封口剂";
                    break;
                case Rigth_Type.gmgtl_cc:
                    //Gzzxlb = 389;
                    Wllb = "隔膜管";
                    break;
                case Rigth_Type.mfqqingxi:
                    //Gzzxlb = 399;
                    Wllb = "密封圈";
                    break;
                case Rigth_Type.dczztl_cc:
                    //Gzzxlb = 14;
                    Wllb = "包标电池";
                    break;
                case Rigth_Type.ddjtl_cc:
                    Wllb = "导电剂";
                    break;
                case Rigth_Type.zhengjifengkoujitl_cc:
                    Wllb = "正极封口剂";
                    break;
                default:
                    break;
            }
            return Wllb;
        }
        public MsgReturn RrintTypebyPrinter(Print_Type ptype)
        {
            MsgReturn meg = new MsgReturn();
            string key = "";
            switch (ptype)
            {
                case Print_Type.none:
                    break;
                case Print_Type.rk:
                    key = key_A5;
                    break;
                case Print_Type.lot:
                    key = key_lot;//"LOT";
                    break;
                case Print_Type.zjlot:
                    key = key_lot;//"LOT";
                    break;
                case Print_Type.fujilot:
                    key = key_lot;//"LOT";
                    break;
                case Print_Type.zxlot:
                    key = key_A5;//"A5";
                    break;
                case Print_Type.bblot:
                    key = key_lot;//"LOT";
                    break;
                case Print_Type.zfsd:
                    key = key_A5;//"A5";
                    break;
                case Print_Type.wlrk:
                    key = key_A5;//"A5";
                    break;
                case Print_Type.zhdc:
                    key = key_lot;//"A5";
                    break;
                case Print_Type.wlrkLot:
                    key = key_lot;
                    break;
                case Print_Type.zswlbsk:
                    key = key_A5;
                    break;
                case Print_Type.zswllot:
                    key = key_lot;
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(key))
            {
                string printName = getPrinter(key);
                List<string> printArr = PrintPublic.GetLocalPrinters();
                //int exist = printArr.Count(p => p.Equals(printName));
                if (printArr.Count(p => p.Equals(printName)) != 1)
                {
                    meg.Pass = false;
                    meg.Msg = q(Msg_Type.msgprintnoexsit);//"系统设置的打印机不存在,请查看配置的打印机是否在本机存在";
                    return meg;
                }
                if (!string.IsNullOrEmpty(printName))
                {
                    meg.Pass = true;
                    meg.Msg = printName;
                    return meg;
                }
                else
                {
                    meg.Pass = false;
                    meg.Msg = q(Msg_Type.msglocalnoprintinfo);//"本地没有存储打印机信息";
                    return meg;
                }
            }
            else
            {
                meg.Pass = false;
                meg.Msg = q(Msg_Type.msgnoprinttypekey);//"打印类型找不到对应的key,请找管理员";
                return meg;
            }


        }
        /// <summary>
        /// ID,MNUMBER,WKINFO,GCID
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string getMachineInfo(string key)
        {
            return ini.IniReadValue(ini.Section_Machine, key);
        }
        public TM_Type TMtype(string tm)
        {
            tm = tm.ToUpper();
            if (tm.Length == 12 && tm.StartsWith("P") == false)
            {
                return TM_Type.tpm;
            }
            else if (tm.Length == 12 && tm.StartsWith("P"))
            {
                return TM_Type.ph;
            }
            else if (tm.Length == 5)
            {
                return TM_Type.staffno;
            }
            else if (tm.Length == 8)
            {
                return TM_Type.gd;
            }
            else if (tm.Length == 11 && tm.StartsWith("R"))
            {
                return TM_Type.rwd;
            }
            else if (tm.Length == 10 && tm.StartsWith("0"))
            {
                return TM_Type.sbbh;
            }
            else if (tm.Length == 6)
            {
                return TM_Type.wllot;
            }
            else
            {
                return TM_Type.none;
            }

        }
        public string GetFormName(Rigth_Type type)
        {
            string formName = "";
            switch (type)
            {
                case Rigth_Type.gangketl_cc:
                    formName = q(Msg_Type.fieldtmgktlcc);//"涂膜钢壳投料产出";
                    break;
                case Rigth_Type.jidiantitl_cc:
                    formName = q(Msg_Type.fieldjdttlcc);//"集电体投料产出";
                    break;
                case Rigth_Type.fujitl:
                    formName = q(Msg_Type.fieldxgtl);//"锌膏投料";
                    break;
                case Rigth_Type.fujicc:
                    formName = q(Msg_Type.fieldxgcc);//"锌膏产出";
                    break;
                case Rigth_Type.zhengjicc:
                    formName = q(Msg_Type.fieldzjfcc);//"正极粉产出";
                    break;
                case Rigth_Type.zhuxiantl:
                    formName = q(Msg_Type.fieldzxtl);//"主线投料";
                    break;
                case Rigth_Type.zhuxiancc:
                    formName = q(Msg_Type.fieldzxcc);//"主线产出";
                    break;
                case Rigth_Type.baobiaocc:
                    formName = q(Msg_Type.fieldbbcc);//"包标产出";
                    break;
                case Rigth_Type.baozhuangcc:
                    formName = q(Msg_Type.fieldbzcc);//"包装产出";
                    break;
                case Rigth_Type.mfqqingxi:
                    formName = q(Msg_Type.fieldmfqqx);//"密封圈清洗";
                    break;
                case Rigth_Type.gmgtl_cc:
                    formName = q(Msg_Type.fieldgmgtlcc);//"隔膜管投料产出";
                    break;
                case Rigth_Type.zhujizhengjitl:
                    formName = q(Msg_Type.fieldzxtl);//"主线投料";
                    break;
                case Rigth_Type.fujifengkoujitl_cc:
                    formName = q(Msg_Type.fieldfjfkjtlcc);//"负极封口剂投料产出";
                    break;
                case Rigth_Type.dczztl_cc:
                    formName = q(Msg_Type.fieldzzdctlcc);//"组装电池投料产出";
                    break;
                case Rigth_Type.ddjtl_cc:
                    formName = q(Msg_Type.fieldddjtlcc);//"导电剂投料产出";
                    break;
                case Rigth_Type.zhengjifengkoujitl_cc:
                    formName = q(Msg_Type.fieldzjfkj);//"正极封口剂";
                    break;
                default:
                    break;
            }
            return formName;
        }

        public string GetWLLBName(Rigth_Type type)
        {
            string Wllb = "";
            //int Gzzxlb = 0;
            switch (RigthType)
            {
                case Rigth_Type.gangketl_cc:
                    //Gzzxlb = 10;
                    Wllb = "涂膜钢壳";
                    break;
                case Rigth_Type.jidiantitl_cc:
                    Wllb = "集电体";
                    break;
                case Rigth_Type.fujitl:
                    //Gzzxlb = 12;
                    Wllb = "锌膏";
                    break;
                case Rigth_Type.fujicc:
                    //Gzzxlb = 12;
                    Wllb = "锌膏";
                    break;
                case Rigth_Type.zhengjicc:
                    //Gzzxlb = 11;
                    Wllb = "正极粉";
                    break;
                case Rigth_Type.zhuxiantl:
                    //Gzzxlb = 7;
                    Wllb = "素电";
                    break;
                case Rigth_Type.zhuxiancc:
                    //Gzzxlb = 7;
                    Wllb = "素电";
                    break;
                case Rigth_Type.baobiaocc:
                    //Gzzxlb = 14;
                    Wllb = "包标电池";
                    break;
                case Rigth_Type.baozhuangcc:
                    //Gzzxlb = 241;
                    Wllb = "成品";
                    break;
                case Rigth_Type.fujifengkoujitl_cc:
                    //Gzzxlb = 394;
                    Wllb = "负极封口剂";
                    break;
                case Rigth_Type.gmgtl_cc:
                    //Gzzxlb = 389;
                    Wllb = "隔膜管";
                    break;
                case Rigth_Type.mfqqingxi:
                    //Gzzxlb = 399;
                    Wllb = "密封圈";
                    break;
                case Rigth_Type.dczztl_cc:
                    //Gzzxlb = 14;
                    Wllb = "包标电池";
                    break;
                case Rigth_Type.zhujizhengjitl:
                    //Gzzxlb = 7;
                    Wllb = "素电";
                    break;
                case Rigth_Type.ddjtl_cc:
                    Wllb = "导电剂";
                    break;
                case Rigth_Type.zhengjifengkoujitl_cc:
                    Wllb = "正极封口剂";
                    break;
                default:
                    break;
            }
            return Wllb;
        }
        public void ShowMeg(string content)
        {
            MessageBox.Show(content, q(Msg_Type.msgtitle));
            return;
        }
        public void ShowMeg(string content, int time)
        {
            MessageBoxTimeoutA(this.Handle, content, q(Msg_Type.msgtitle), 64, 0, time);

            return;
        }
        public SELECT_MES_TM_TMINFO_BYTM ReadphTM(MES_TM_TMINFO model, int status)
        {

            return ServicModel.TM_TMINFO.SELECT_BYTM(model, status, getToken());
        }
        public SELECT_MES_TM_TMINFO_BYTM ReadphJS(string rwbh)
        {
            return ServicModel.TM_TMINFO.SELECT_TL_LAST(rwbh, getToken());
        }
        public MES_RETURN_UI AddCzr(MES_TM_CZR czrInfo)
        {
            return ServicModel.TM_CZR.INSERT(czrInfo, getToken());
        }
        public MES_TM_CZR_SELECT_CZR_NOW SelectCZR(MES_TM_CZR crzInfo)
        {
            return ServicModel.TM_CZR.SELECT_CZR_NOW(crzInfo, getToken());
        }
        public MES_TM_CZR_SELECT_CZR_NOW ReadCzr(MES_TM_CZR czrInfo)
        {
            return ServicModel.TM_CZR.SELECT_CZR_NOW(czrInfo, getToken());
        }
        public void ReduceCzr(int staffid)
        {
            //暂时没有 考虑
        }
        public MES_SY_TYPEMXLIST[] ReadTYPEMX(int TYPEID)
        {
            MES_SY_TYPEMX TYPEMX = new MES_SY_TYPEMX();
            TYPEMX.TYPEID = TYPEID;
            TYPEMX.GC = Convert.ToString(getGC("value"));
            return ServicModel.SY_TYPEMX.SELECT(TYPEMX, getToken());
        }
        public void DataGridBuild(string[] cols, string[] colss, DataGridView datagridGiew, string[] vcols)
        {
            datagridGiew.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            for (int i = 0; i < cols.Length; i++)
            {
                DataGridViewTextBoxColumn acCode = new DataGridViewTextBoxColumn();
                acCode.Name = cols[i];
                acCode.DataPropertyName = colss[i];
                acCode.HeaderText = cols[i];

                if (cols[i] == q(Msg_Type.fieldwlxx))//"物料信息"
                {
                    acCode.Width = 300;
                    acCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                else if (cols[i] == q(Msg_Type.fieldgdxx))//"工单信息"
                {
                    acCode.Width = 300;
                    acCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                else
                {
                    acCode.Width = 120;
                    acCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (vcols.Count(p => p == cols[i]) > 0)
                {
                    acCode.Visible = false;
                }

                datagridGiew.Columns.Add(acCode);

                //datagridGiew.RowTemplate.Height = 35;
                //datagridGiew.RowTemplate.DefaultCellStyle.Font = new Font(q(Msg_Type.fonttype), 11);
            }

            //datagridGiew.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn item in datagridGiew.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        public void printTest(Print_Type type)
        {
            PrintType = type;
            baseprintDocument.PrinterSettings.PrinterName = getPrinter(key_A5);
            baseprintDocument.Print();
        }





        #endregion
        #region  class
        public class MsgReturn
        {
            bool pass;

            public bool Pass
            {
                get { return pass; }
                set { pass = value; }
            }
            string msg;

            public string Msg
            {
                get { return msg; }
                set { msg = value; }
            }
        }

        public class TPYEMX
        {
            int _ID;

            public int ID
            {
                get { return _ID; }
                set { _ID = value; }
            }
            string _MXNAME;

            public string MXNAME
            {
                get { return _MXNAME; }
                set { _MXNAME = value; }
            }
        }
        #endregion
        #region 屏蔽系统规则
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x112)
            {
                switch ((int)m.WParam)
                {
                    //禁止双击标题栏关闭窗体
                    //case 0xF063:
                    //case 0xF093:
                    //    m.WParam = IntPtr.Zero;
                    //    break;
                    //禁止拖拽标题栏还原窗体
                    //case 0xF012:
                    //case 0xF010:
                    //    m.WParam = IntPtr.Zero;
                    //    break;
                    //禁止双击标题栏
                    case 0xf122:
                        m.WParam = IntPtr.Zero;
                        break;
                    ////禁止关闭按钮
                    //case 0xF060:
                    //    m.WParam = IntPtr.Zero;
                    //    break;
                    ////禁止最大化按钮
                    //case 0xf020:
                    //    m.WParam = IntPtr.Zero;
                    //    break;
                    ////禁止最小化按钮
                    //case 0xf030:
                    //    m.WParam = IntPtr.Zero;
                    //    break;
                    ////禁止还原按钮
                    //case 0xf120:
                    //    m.WParam = IntPtr.Zero;
                    //    break;
                }
            }
            base.WndProc(ref m);
        }
        #endregion
        #region 打印画图
        /// <summary>
        /// 打印的print（）事件,该方法是用来绘制页面的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void baseprintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            switch (PrintType)
            {
                //物流部统一打印入库标识,所以rk不再使用
                case Print_Type.rk:
                    PrintHead = PrintList[TempItem].MES_TM_TMINFO_LIST;
                    PrintChild = PrintList[TempItem].MES_TM_TMINFO_LIST_CHILD;
                    CzlList = PrintList[TempItem].CZR;
                    DrawRK(e);
                    MultiplePrint(e);
                    break;
                case Print_Type.lot:
                    PrintHead = PrintList[TempItem].MES_TM_TMINFO_LIST;
                    PrintChild = PrintList[TempItem].MES_TM_TMINFO_LIST_CHILD;
                    CzlList = PrintList[TempItem].CZR;
                    //DrawLot(e);
                    DrawLot_N(e);//改造
                    MultiplePrint(e);
                    break;
                case Print_Type.fujilot:
                    PrintHead = PrintList[TempItem].MES_TM_TMINFO_LIST;
                    PrintChild = PrintList[TempItem].MES_TM_TMINFO_LIST_CHILD;
                    CzlList = PrintList[TempItem].CZR;
                    //DrawFujiLot(e);
                    DrawFujiLot_N(e);
                    MultiplePrint(e);
                    break;
                case Print_Type.zjlot:
                    PrintHead = PrintList[TempItem].MES_TM_TMINFO_LIST;
                    PrintChild = PrintList[TempItem].MES_TM_TMINFO_LIST_CHILD;
                    CzlList = PrintList[TempItem].MES_TM_TMINFO_LIST.BCMS;
                    //DrawZJlot(e);
                    DrawZJlot_N(e);
                    MultiplePrint(e);
                    break;
                case Print_Type.zxlot:
                    PrintHead = PrintList[TempItem].MES_TM_TMINFO_LIST;
                    PrintChild = PrintList[TempItem].MES_TM_TMINFO_LIST_CHILD;
                    CzlList = PrintList[TempItem].CZR;
                    DrawZXLot(e);
                    MultiplePrint(e);
                    break;
                case Print_Type.bblot:
                    PrintHead = PrintList[TempItem].MES_TM_TMINFO_LIST;
                    PrintChild = PrintList[TempItem].MES_TM_TMINFO_LIST_CHILD;
                    CzlList = PrintList[TempItem].CZR;
                    //Drawbblot(e);
                    Drawbblot_N(e);
                    MultiplePrint(e);
                    break;
                case Print_Type.zfsd:
                    PrintHead = PrintList[TempItem].MES_TM_TMINFO_LIST;
                    PrintChild = PrintList[TempItem].MES_TM_TMINFO_LIST_CHILD;
                    CzlList = PrintList[TempItem].CZR;
                    int row = (PrintList[TempItem].MES_TM_ZFDCMX.Length - 1) / 16;
                    int lastcount = (PrintList[TempItem].MES_TM_ZFDCMX.Length) % 16;
                    if (row > Fycount)
                    {
                        Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_ZFDCMX[] r = new UI.Model.MES.TM_TMINFOService.MES_TM_ZFDCMX[16];
                        Array.ConstrainedCopy(PrintList[TempItem].MES_TM_ZFDCMX, Fycount * 16, r, 0, 16);
                        PrintChildMX = r;
                    }
                    else
                    {
                        Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_ZFDCMX[] r = new UI.Model.MES.TM_TMINFOService.MES_TM_ZFDCMX[lastcount];
                        Array.ConstrainedCopy(PrintList[TempItem].MES_TM_ZFDCMX, Fycount * 16, r, 0, lastcount);
                        PrintChildMX = r;
                    }
                    if (Fycount <= row)
                    {
                        DrawZFSD(e);
                    }
                    MultiplePrint(e, true);
                    break;
                case Print_Type.wlrk:
                    PrintHead = PrintList[TempItem].MES_TM_TMINFO_LIST;
                    PrintChild = PrintList[TempItem].MES_TM_TMINFO_LIST_CHILD;
                    CzlList = PrintList[TempItem].CZR;
                    if (WlrkList == null)
                    {
                        Xs = "";
                        Ts = "";
                    }
                    else
                    {
                        Xs = WlrkList[TempItem].XS.ToString();
                        Ts = WlrkList[TempItem].TS.ToString();
                    }
                    DrawWLRK(e);
                    MultiplePrint(e);
                    break;
                case Print_Type.wlrkLot:
                    PrintHead = PrintList[TempItem].MES_TM_TMINFO_LIST;
                    if (WlrkList != null)
                    {
                        PrintHead.SL = Convert.ToDecimal(WlrkList[TempItem].MTSL);
                        Xs = WlrkList[TempItem].XS.ToString();
                        Ts = WlrkList[TempItem].TS.ToString();
                    }

                    PrintChild = PrintList[TempItem].MES_TM_TMINFO_LIST_CHILD;
                    //DrawWLRKLOT(e);
                    DrawWLRKLOT_N(e);
                    //MultiplePrint(e,Print_Type.wlrkLot);     
                    MultiplePrint(e);
                    break;
                case Print_Type.zswllot:
                    PrintHead = PrintList[TempItem].MES_TM_TMINFO_LIST;
                    CzlList = PrintList[TempItem].CZR;
                    //DrawZSWLLOT(e);
                    DrawZSWLLOT_N(e);
                    MultiplePrint(e);
                    break;
                case Print_Type.zswlbsk:
                    PrintHead = PrintList[TempItem].MES_TM_TMINFO_LIST;
                    CzlList = PrintList[TempItem].CZR;
                    DrawZSWLBSK(e);
                    MultiplePrint(e);
                    break;
                default:
                    break;
            }
            if (preview && PrintType != Print_Type.zfsd)
            {
                e.HasMorePages = false;
            }


        }
        /// <summary>
        /// 暂放素电的打印
        /// </summary>
        /// <param name="e"></param>
        /// <param name="isZFSD"></param>
        public void MultiplePrint(System.Drawing.Printing.PrintPageEventArgs e, bool isZFSD)
        {
            if (PrintType == Print_Type.zfsd)
            {

                Fycount++;
                int a = (PrintList[0].MES_TM_ZFDCMX.Length - 1) % 16;
                int b = (PrintList[0].MES_TM_ZFDCMX.Length - 1) % 16;
                if (Fycount <= (PrintList[0].MES_TM_ZFDCMX.Length) / 16)
                {
                    e.HasMorePages = true;
                }
                else
                {
                    TempCount++;
                    if (TempCount == Count)
                    {
                        e.HasMorePages = false;
                    }
                    else
                    {
                        Fycount = 0;
                        e.HasMorePages = true;
                    }

                }
            }
            else
            {
                TempCount++;
                e.HasMorePages = !(TempCount == Count);
            }
        }
        /// <summary>
        /// 物流入库的条码多条打印函数
        /// </summary>
        /// <param name="e"></param>
        /// <param name="rtype"></param>
        public void MultiplePrint(System.Drawing.Printing.PrintPageEventArgs e, Print_Type rtype)
        {
            TempCount++;
            if (TempCount == Count)
            {
                TempCount = 0;

                if (TuoHao == Convert.ToInt32(WlrkList[TempItem].TS) + Convert.ToInt32(WlrkList[TempItem].QSTH) - 1)
                {

                    TempItem++;

                    if (TempItem == PrintList.Length)
                    {
                        e.HasMorePages = false;
                    }
                    else
                    {
                        TuoHao = Convert.ToInt32(WlrkList[TempItem].QSTH);
                        e.HasMorePages = true;
                    }
                }
                else
                {
                    TuoHao++;
                    e.HasMorePages = true;
                }
            }
            else
            {
                e.HasMorePages = true;
            }
        }
        /// <summary>
        /// 正常多份打印函数
        /// </summary>
        /// <param name="e"></param>
        public void MultiplePrint(System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (PrintList.Length == 1)
            {
                TempCount++;
                e.HasMorePages = !(TempCount == Count);
            }
            else
            {
                //如果有多个条码,多份的话该处理过程就是先打印所有条码在多份打印
                //TempItem++;
                //if (TempItem == PrintList.Length)
                //{
                //    TempCount++;
                //    if (TempCount < Count && Count != 1)
                //    {

                //        TempItem = 0;
                //        e.HasMorePages = true;
                //    }
                //    else
                //    {
                //        e.HasMorePages = false;
                //    }
                //}
                //else
                //{
                //    e.HasMorePages = true;
                //}
                //如果有多个条码,多份的话该处理过程就是多份打印单个条码然后依次打印
                TempCount++;
                if (TempCount == Count)
                {
                    TempCount = 0;
                    if (TempItem == PrintList.Length - 1)
                    {
                        e.HasMorePages = false;
                    }
                    else
                    {
                        TempItem++;
                        e.HasMorePages = true;
                    }
                }
                else
                {
                    e.HasMorePages = true;
                }
            }
        }

        public void SetDYJ(string ip)
        {
            PrintPublic.SetDefaultPrinter(ip);
        }

        public void PrintInfoByTM(string tm, string gc, int fs, Rigth_Type rtype, Print_Type ptype)
        {
            Sonluk.UI.Model.MES.TM_TMINFOService.SELECT_MES_TM_TMINFO_PRINT res2 = ServicModel.TM_TMINFO.SELECT_BYID_CHILD(gc, tm, getToken());
            if (res2.MES_RETURN.TYPE.Equals("S"))
            {
                List<Sonluk.UI.Model.MES.TM_TMINFOService.SELECT_MES_TM_TMINFO_PRINT> nodes = new List<Sonluk.UI.Model.MES.TM_TMINFOService.SELECT_MES_TM_TMINFO_PRINT>();
                nodes.Add(res2);
                PrintInfo(fs, "", "", nodes.ToArray(), rtype, ptype);
            }
            else
            {
                ShowMeg(res2.MES_RETURN.MESSAGE);
            }


        }
        public void PrintView(string tm)
        {
            MES_TM_TMINFO TMINFOmodel = new MES_TM_TMINFO();
            TMINFOmodel.TM = tm;
            SELECT_MES_TM_TMINFO_BYTM tminfiRes = ServicModel.TM_TMINFO.SELECT(TMINFOmodel, getToken());
            if (tminfiRes.MES_RETURN.TYPE.Equals("S"))
            {

                if (tminfiRes.MES_TM_TMINFO_LIST.Length == 1)
                {
                    Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_LIST tmINFO = tminfiRes.MES_TM_TMINFO_LIST[0];
                    Print_Type ptype = (Print_Type)tmINFO.TMSX;
                    Rigth_Type r;
                    bool isNormal = true;
                    switch (ptype)
                    {
                        case Print_Type.none:
                            isNormal = false;
                            break;
                        case Print_Type.rk:
                            r = Rigth_Type.gangketl_cc;

                            break;
                        case Print_Type.lot:
                            r = Rigth_Type.gangketl_cc;
                            PrintInfoByTM_READONLY(tmINFO.TM, tmINFO.GC, 1, r, ptype);
                            break;
                        case Print_Type.zjlot:
                            r = Rigth_Type.zhengjicc;
                            PrintInfoByTM_READONLY(tmINFO.TM, tmINFO.GC, 1, r, ptype);
                            break;
                        case Print_Type.fujilot:
                            r = Rigth_Type.fujitl;
                            PrintInfoByTM_READONLY(tmINFO.TM, tmINFO.GC, 1, r, ptype);
                            break;
                        case Print_Type.zxlot:
                            r = Rigth_Type.zhuxiancc;
                            PrintInfoByTM_READONLY(tmINFO.TM, tmINFO.GC, 1, r, ptype);
                            break;
                        case Print_Type.bblot:
                            r = Rigth_Type.baobiaocc;
                            PrintInfoByTM_READONLY(tmINFO.TM, tmINFO.GC, 1, r, ptype);
                            break;
                        case Print_Type.zfsd:
                            r = Rigth_Type.zhuxiancc;
                            PrintInfoByTM_READONLY(tmINFO.TM, tmINFO.GC, 1, r, ptype);
                            break;
                        case Print_Type.wlrk:
                            r = Rigth_Type.wlrkdy;
                            PrintInfoByTM_READONLY(tmINFO.TM, tmINFO.GC, 1, r, ptype);
                            break;
                        case Print_Type.wlrkLot:
                            r = Rigth_Type.wlrkdy;
                            PrintInfoByTM_READONLY(tmINFO.TM, tmINFO.GC, 1, r, ptype);
                            break;
                        case Print_Type.zswllot:
                            r = Rigth_Type.zswllotdy;
                            PrintInfoByTM_READONLY(tmINFO.TM, tmINFO.GC, 1, r, ptype);
                            break;
                        case Print_Type.zswlbsk:
                            r = Rigth_Type.none;
                            PrintInfoByTM_READONLY(tmINFO.TM, tmINFO.GC, 1, r, ptype);
                            break;
                        default:
                            isNormal = false;
                            break;

                    }
                    if (isNormal == false)
                    {
                        ShowMeg(q(Msg_Type.msgtmsxecpect));//"条码属性读取异常,请联系管理员");

                        return;
                    }


                }
                else
                {
                    ShowMeg(q(Msg_Type.msgloadtmfail));//"读取扫描条码信息失败");
                }

            }
            else
            {
                ShowMeg(tminfiRes.MES_RETURN.MESSAGE);
                return;
            }
        }
        public void PrintInfoByTM_READONLY(string tm, string gc, int fs, Rigth_Type rtype, Print_Type ptype)
        {
            Sonluk.UI.Model.MES.TM_TMINFOService.SELECT_MES_TM_TMINFO_PRINT res2 = ServicModel.TM_TMINFO.SELECT_BYID_CHILD(gc, tm, getToken());
            if (res2.MES_RETURN.TYPE.Equals("S"))
            {
                List<Sonluk.UI.Model.MES.TM_TMINFOService.SELECT_MES_TM_TMINFO_PRINT> nodes = new List<Sonluk.UI.Model.MES.TM_TMINFOService.SELECT_MES_TM_TMINFO_PRINT>();
                nodes.Add(res2);
                PrintInfo_ReadOnly(fs, "", "", nodes.ToArray(), rtype, ptype);
            }
            else
            {
                ShowMeg(res2.MES_RETURN.MESSAGE);
            }


        }
        public void PrintInfo_ReadOnly(int count, string xs, string ts, Sonluk.UI.Model.MES.TM_TMINFOService.SELECT_MES_TM_TMINFO_PRINT[] printlist, Rigth_Type rtype, Print_Type ptype)
        {

            PrintList = printlist;
            Xs = xs;
            Ts = ts;
            PrintType = ptype;
            RigthType = rtype;
            Count = count;



            if (Count > 0 && PrintList.Length > 0)
            {
                TempCount = 0;
                TempItem = 0;
                Fycount = 0;
                //printPreviewDialog1.
                PrintPreviewDialog dia = new PrintPreviewDialog();

                dia.Document = baseprintDocument;
                PaperSize ps = new PaperSize();
                ps.Height = 600;
                //ps.Kind = "Custom";                
                ps.PaperName = "zs";
                ps.RawKind = 167;
                ps.Width = 866;
                if (PrintType == Print_Type.wlrk || PrintType == Print_Type.zxlot || PrintType == Print_Type.zfsd || PrintType == Print_Type.zswlbsk)
                {

                    dia.PrintPreviewControl.Zoom = 1;


                    baseprintDocument.DefaultPageSettings.PaperSize = ps;
                    dia.StartPosition = FormStartPosition.CenterScreen;
                    dia.Height = rect.Height;
                    dia.AutoSize = true;
                    dia.Width = 650;
                    baseprintDocument.PrinterSettings.PrinterName = getPrinter(key_A5);
                }
                else
                {

                    dia.PrintPreviewControl.Zoom = 1.5;
                    baseprintDocument.PrinterSettings.PrinterName = getPrinter(key_lot);
                    baseprintDocument.DefaultPageSettings.PaperSize = new PaperSize("Custom", 300, 1000);
                    dia.StartPosition = FormStartPosition.CenterScreen;
                    dia.Height = rect.Height;
                    dia.Width = 300;

                    dia.AutoSize = true;
                    //printPreviewDialog1.Width  = 800;


                }
                preview = true;
                dia.ShowDialog();
                preview = false;

                //dia.Dispose();
            }
        }
        public void PrintWLKCLot(List<ZSL_BCS303_BS> wlkcList, int count, Print_Type ptype)
        {
            MsgReturn msgreturn = RrintTypebyPrinter(ptype);
            if (!msgreturn.Pass)
            {
                //frmBindPrint form = new frmBindPrint(ptype);
                frmBindPrint_1 form = new frmBindPrint_1();
                show(form);
                return;
            }
            string printname = getPrinter(key_lot);
            PrintPublic.PrinterStatus status = PrintPublic.GetPrinterStat(printname);

            if (status == PrintPublic.PrinterStatus.打印中 || status == PrintPublic.PrinterStatus.空闲 || status == PrintPublic.PrinterStatus.预热 || status == PrintPublic.PrinterStatus.正在打印)
            {

            }
            else
            {
                ShowMeg(string.Format(q(Msg_Type.msgdyjexcept), printname, status));//"打印机" + printname + "当前状态为“" + status + "”,暂时无法打印,请联系管理员");
                return;
            }
            baseprintDocument.PrinterSettings.PrinterName = printname;
            TempPrintList = new List<UI.Model.MES.TM_TMINFOService.SELECT_MES_TM_TMINFO_PRINT>();

            for (int i = 0; i < wlkcList.Count; i++)
            {
                Sonluk.UI.Model.MES.TM_TMINFOService.SELECT_MES_TM_TMINFO_PRINT tmInfo = ServicModel.TM_TMINFO.SELECT_BYID_CHILD(wlkcList[i].WERKS, wlkcList[i].TM, getToken());
                TempPrintList.Add(tmInfo);

            }
            TempCount = 0;
            TempItem = 0;

            WlrkList = wlkcList;
            PrintType = ptype;
            PrintList = TempPrintList.ToArray();
            //TuoHao = Convert.ToInt32(wlkcList[0].QSTH);
            Count = count;

            baseprintDocument.Print();

        }
        /// <summary>
        /// wlrolot 前台生成的方式
        /// </summary>
        /// <param name="wlkcList"></param>
        /// <param name="count"></param>
        /// <param name="ptype"></param>
        public void PrintWLKC(List<ZSL_BCS303_BS> wlkcList, int count, Print_Type ptype)
        {
            if (ptype == Print_Type.wlrkLot)
            {
                MsgReturn msgreturn = RrintTypebyPrinter(ptype);
                if (!msgreturn.Pass)
                {
                    //frmBindPrint form = new frmBindPrint(ptype);
                    frmBindPrint_1 form = new frmBindPrint_1();
                    show(form);
                    return;
                }
                string printname = getPrinter(key_lot);
                PrintPublic.PrinterStatus status = PrintPublic.GetPrinterStat(printname);

                if (status == PrintPublic.PrinterStatus.打印中 || status == PrintPublic.PrinterStatus.空闲 || status == PrintPublic.PrinterStatus.预热 || status == PrintPublic.PrinterStatus.正在打印)
                {

                }
                else
                {
                    //ShowMeg("打印机" + printname + "当前状态为“" + status + "”,暂时无法打印,请联系管理员");
                    ShowMeg(string.Format(q(Msg_Type.msgdyjexcept), printname, status));
                    return;
                }
                baseprintDocument.PrinterSettings.PrinterName = printname;
                TempPrintList = new List<UI.Model.MES.TM_TMINFOService.SELECT_MES_TM_TMINFO_PRINT>();

                for (int i = 0; i < wlkcList.Count; i++)
                {
                    Sonluk.UI.Model.MES.TM_TMINFOService.SELECT_MES_TM_TMINFO_PRINT tmInfo = ServicModel.TM_TMINFO.SELECT_BYID_CHILD(wlkcList[i].WERKS, wlkcList[i].TM, getToken());
                    TempPrintList.Add(tmInfo);

                }
                TempCount = 0;
                TempItem = 0;

                WlrkList = wlkcList;
                PrintType = ptype;
                PrintList = TempPrintList.ToArray();
                TuoHao = Convert.ToInt32(wlkcList[0].QSTH);
                Count = count;

                baseprintDocument.Print();
            }
            else
            {
                MsgReturn msgreturn = RrintTypebyPrinter(ptype);
                if (!msgreturn.Pass)
                {
                    frmBindPrint_1 form = new frmBindPrint_1();
                    show(form);
                    return;
                }
                string printname = getPrinter(key_A5);
                PrintPublic.PrinterStatus status = PrintPublic.GetPrinterStat(printname);

                if (status == PrintPublic.PrinterStatus.打印中 || status == PrintPublic.PrinterStatus.空闲 || status == PrintPublic.PrinterStatus.预热 || status == PrintPublic.PrinterStatus.正在打印)
                {

                }
                else
                {
                    //ShowMeg("打印机" + printname + "当前状态为“" + status + "”,暂时无法打印,请联系管理员");
                    ShowMeg(string.Format(q(Msg_Type.msgdyjexcept), printname, status));
                    return;
                }
                baseprintDocument.PrinterSettings.PrinterName = printname;
                TempPrintList = new List<UI.Model.MES.TM_TMINFOService.SELECT_MES_TM_TMINFO_PRINT>();

                for (int i = 0; i < wlkcList.Count; i++)
                {
                    Sonluk.UI.Model.MES.TM_TMINFOService.SELECT_MES_TM_TMINFO_PRINT tmInfo = ServicModel.TM_TMINFO.SELECT_BYID_CHILD(wlkcList[i].WERKS, wlkcList[i].TM, getToken());
                    if (!tmInfo.MES_RETURN.TYPE.Equals("S"))
                    {
                        ShowMeg(tmInfo.MES_RETURN.MESSAGE);
                        return;
                    }
                    else
                    {
                        TempPrintList.Add(tmInfo);
                    }
                }
                TempCount = 0;
                TempItem = 0;
                WlrkList = wlkcList;
                PrintType = ptype;
                PrintList = TempPrintList.ToArray();

                Count = count;

                baseprintDocument.Print();
            }

        }
        public void PrintInfo(int count, string xs, string ts, Sonluk.UI.Model.MES.TM_TMINFOService.SELECT_MES_TM_TMINFO_PRINT[] printlist, Rigth_Type rtype, Print_Type ptype)
        {
            MsgReturn msgreturn = RrintTypebyPrinter(ptype);
            if (!msgreturn.Pass)
            {
                frmBindPrint_1 form = new frmBindPrint_1();
                show(form);
                return;
            }
            PrintList = printlist;

            Xs = xs;
            Ts = ts;
            PrintType = ptype;
            RigthType = rtype;
            Count = count;
            string printname = "";
            switch (PrintType)
            {
                case Print_Type.none:
                    break;
                case Print_Type.rk:
                    printname = getPrinter(key_A5);
                    break;
                case Print_Type.lot:
                    printname = getPrinter(key_lot);
                    break;
                case Print_Type.zjlot:
                    printname = getPrinter(key_lot);
                    break;
                case Print_Type.fujilot:
                    printname = getPrinter(key_lot);
                    break;
                case Print_Type.zxlot:
                    printname = getPrinter(key_A5);
                    break;
                case Print_Type.bblot:
                    printname = getPrinter(key_lot); ;
                    break;
                case Print_Type.zfsd:
                    printname = getPrinter(key_A5); ;
                    break;
                case Print_Type.wlrk:
                    printname = getPrinter(key_A5); ;
                    break;
                case Print_Type.zhdc:
                    printname = getPrinter(key_lot); ; ;
                    break;
                case Print_Type.wlrkLot:
                    printname = getPrinter(key_lot);
                    break;
                case Print_Type.zswllot:
                    printname = getPrinter(key_lot);
                    break;
                case Print_Type.zswlbsk:
                    printname = getPrinter(key_A5);
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(printname))
            {
                PrintPublic.PrinterStatus status = PrintPublic.GetPrinterStat(printname);

                if (status == PrintPublic.PrinterStatus.打印中 || status == PrintPublic.PrinterStatus.空闲 || status == PrintPublic.PrinterStatus.预热 || status == PrintPublic.PrinterStatus.正在打印)
                {

                }
                else
                {
                    //ShowMeg("打印机" + printname + "当前状态为“"+ status +"”,暂时无法打印,请联系管理员");
                    ShowMeg(string.Format(q(Msg_Type.msgdyjexcept), printname, status));
                    return;
                }
            }
            else
            {
                ShowMeg(q(Msg_Type.msgnoprinttypekey));//"无法获得打印类型");
                return;
            }
            baseprintDocument.PrinterSettings.PrinterName = printname;
            //PaperSize s = baseprintDocument.DefaultPageSettings.PaperSize;
            if (Count > 0 && PrintList.Length > 0)
            {
                TempCount = 0;
                TempItem = 0;
                Fycount = 0;

                baseprintDocument.Print();
            }
        }

        private void DrawWLRK(PrintPageEventArgs e)
        {
            float wid = (float)1.3;
            Pen blackPen = new Pen(Color.Black, 1);
            Pen cuPen = new Pen(Color.Black, 1);
            Pen pen2 = new Pen(Color.Black, wid);
            pen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            pen2.DashPattern = new float[] { 1f, 1f };
            Font font22 = new Font(q(Msg_Type.fonttype), 22);
            Font font14 = new Font(q(Msg_Type.fonttype), 14);
            Font font12 = new Font(q(Msg_Type.fonttype), 12);
            Font font10 = new Font(q(Msg_Type.fonttype), 10);
            Font font5 = new Font(q(Msg_Type.fonttype), 5);

            Font font10cu = new Font(q(Msg_Type.fonttype), 10, FontStyle.Bold);
            Font font16 = new Font(q(Msg_Type.fonttype), 16, FontStyle.Bold);
            Font font26 = new Font(q(Msg_Type.fonttype), 26, FontStyle.Bold);
            Brush bru = Brushes.Black;
            Graphics g = e.Graphics;//画布
            StringFormat strFormat = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat.Alignment = StringAlignment.Center;//水平居中
            StringFormat strFormat1 = new StringFormat();
            strFormat1.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat1.Alignment = StringAlignment.Near;//水平居中
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;//抗锯齿           
            int width = 827;
            //int height = 565;
            int xmargin = 5;
            int rowmargin = 40;
            Rectangle recHead = new Rectangle(xmargin, 30, width - 10, rowmargin);//矩形
            Rectangle recHead1 = new Rectangle(xmargin, 30 + 25, width - 10, rowmargin);//矩形
            string a = PrintHead.GCDYMS;
            string LotNo = string.IsNullOrEmpty(PrintHead.LOTNO) ? string.Format(q(Msg_Type.printbhformat), "WL4001A") : q(Msg_Type.printbh) + PrintHead.LOTNO;//"编号: WL4001A"   "编号: "
            g.DrawString(LotNo, font14, bru, 25, 0);
            g.DrawRectangle(pen2, new Rectangle(width - 170, 15, 100, 70));
            g.DrawString(q(Msg_Type.printdj), font14, bru, new Rectangle(width - 170, 15, 100, 70), strFormat);//"待检"
            g.DrawString(PrintHead.GCDYMS, font22, bru, recHead, strFormat);
            g.DrawString(q(Msg_Type.printwlkcbs), font14, bru, recHead1, strFormat);//"物料库存标识"

            string zydh = "";
            if (!string.IsNullOrEmpty(PrintHead.NOBILL))
            {
                zydh += PrintHead.NOBILL + "-" + PrintHead.NOBILLMX;
            }
            string ckdj = q(Msg_Type.printckdj);//"参考单据:";// +PrintHead.WLPZBH + "/" + PrintHead.WLPZH + "(" + PrintHead.WLPZND + ")";
            if (!string.IsNullOrEmpty(PrintHead.WLPZBH))
            {
                ckdj += PrintHead.WLPZBH + "/" + PrintHead.WLPZH + "(" + PrintHead.WLPZND + ")";
                if (!string.IsNullOrEmpty(PrintHead.CGBILL))
                {
                    ckdj += "-" + PrintHead.CGBILL + "/" + PrintHead.CGBILLMX;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(PrintHead.CGBILL))
                {
                    ckdj += PrintHead.CGBILL + "/" + PrintHead.CGBILLMX;
                }
            }
            if (Xs.Equals("0"))
            {
                Xs = "";
            }
            if (Ts.Equals("0"))
            {
                Ts = "";
            }
            string zlxx = q(Msg_Type.printzlxx);//"质量信息:";
            if (!string.IsNullOrEmpty(PrintHead.SBHMS))
            {
                zlxx += PrintHead.SBHMS + "/";
            }
            if (!string.IsNullOrEmpty(PrintHead.CLCJ))
            {
                zlxx += PrintHead.CLCJ + "/";
            }
            if (!string.IsNullOrEmpty(PrintHead.GYLX))
            {
                zlxx += PrintHead.GYLX + "/";
            }
            if (!string.IsNullOrEmpty(PrintHead.SBHMS) || !string.IsNullOrEmpty(PrintHead.CLCJ) || !string.IsNullOrEmpty(PrintHead.GYLX))
            {
                zlxx = zlxx.Substring(0, zlxx.Length - 1);
            }
            if (string.IsNullOrEmpty(PrintHead.SBHMS) && string.IsNullOrEmpty(PrintHead.CLCJ) && string.IsNullOrEmpty(PrintHead.GYLX))
            {
                zlxx = "";
            }
            string gysStr = PrintHead.GYS;
            if (!string.IsNullOrEmpty(gysStr) && !string.IsNullOrEmpty(PrintHead.GYSMS))
            {
                gysStr += "-" + PrintHead.GYSMS;
            }

            string[] contentArr = { q(Msg_Type.printgc), PrintHead.GC, q(Msg_Type.printkcdd), PrintHead.KCDD + "-" + PrintHead.KCDDNAME, q(Msg_Type.printwlbm), PrintHead.WLH, q(Msg_Type.printwlmc), PrintHead.WLMS, q(Msg_Type.printgys), gysStr, ckdj, q(Msg_Type.printsl), PrintHead.SL.ToString("0.##") + "/" + PrintHead.UNITSNAME, q(Msg_Type.printxs) + Xs, q(Msg_Type.printts) + Ts, q(Msg_Type.printcz) + "    KG", q(Msg_Type.printpc), PrintHead.PC, q(Msg_Type.printzydh), zydh, q(Msg_Type.printrkrq), PrintHead.SCDATE, q(Msg_Type.printbz), zlxx };
            //"工厂"  "库存地点" "物料编码"  "物料名称" "供应商" "数量" "箱数:"
            int w = 135;
            int m = 25;
            int firstrow = 30;
            //第一行
            g.DrawRectangle(blackPen, new Rectangle(m, 100, w - firstrow, rowmargin));
            g.DrawString(contentArr[0], font10, bru, new Rectangle(m, 100, w - firstrow, rowmargin), strFormat1);

            g.DrawRectangle(blackPen, new Rectangle(m + w - firstrow, 100, w + firstrow, rowmargin));
            g.DrawString(contentArr[1], font10, bru, new Rectangle(m + w - firstrow, 100, w + firstrow, rowmargin), strFormat1);

            g.DrawRectangle(blackPen, new Rectangle(m + w * 2, 100, w - 30, rowmargin));
            g.DrawString(contentArr[2], font10, bru, new Rectangle(m + w * 2, 100, w, rowmargin), strFormat1);

            g.DrawRectangle(blackPen, new Rectangle(m + w * 3 - 30, 100, w * 3 - 20, rowmargin));
            g.DrawString(contentArr[3], font10cu, bru, new Rectangle(m + w * 3 - 30, 100, w * 3 - 30, rowmargin), strFormat1);
            //第二行
            g.DrawRectangle(blackPen, new Rectangle(m, 100 + rowmargin, w - firstrow, rowmargin));
            g.DrawString(contentArr[4], font10, bru, new Rectangle(m, 100 + rowmargin, w - firstrow, rowmargin), strFormat1);

            g.DrawRectangle(blackPen, new Rectangle(m + w - firstrow, 100 + rowmargin, w + firstrow, rowmargin));
            g.DrawString(contentArr[5], font10, bru, new Rectangle(m + w - firstrow, 100 + rowmargin, w + firstrow, rowmargin), strFormat1);

            g.DrawRectangle(blackPen, new Rectangle(m + w * 2, 100 + rowmargin, w - 30, rowmargin));
            g.DrawString(contentArr[6], font10, bru, new Rectangle(m + w * 2, 100 + rowmargin, w, rowmargin), strFormat1);

            g.DrawRectangle(blackPen, new Rectangle(m + w * 3 - 30, 100 + rowmargin, w * 3 - 20, rowmargin));
            g.DrawString(contentArr[7], font16, bru, new Rectangle(m + w * 3 - 30, 100 + rowmargin, w * 3, rowmargin), strFormat1);
            //第三行
            g.DrawRectangle(blackPen, new Rectangle(m, 100 + rowmargin * 2, w - firstrow, rowmargin));
            g.DrawString(contentArr[8], font10, bru, new Rectangle(m, 100 + rowmargin * 2, w - firstrow, rowmargin), strFormat1);

            //g.DrawRectangle(blackPen, new Rectangle(m + w - firstrow, 100 + rowmargin * 2, w * 2 + firstrow - 32, rowmargin));
            g.DrawString(contentArr[9], font16, bru, new Rectangle(m + w - firstrow, 100 + rowmargin * 2, w * 2 + firstrow, rowmargin), strFormat1);

            g.DrawRectangle(blackPen, new Rectangle(m + w * 3 - 30, 100 + rowmargin * 2, w * 3 - 20, rowmargin));
            g.DrawString(contentArr[10], font10, bru, new Rectangle(m + w * 3 - 30, 100 + rowmargin * 2, w * 3 - 20, rowmargin), strFormat1);
            //第四行
            g.DrawRectangle(blackPen, new Rectangle(m, 100 + rowmargin * 3, w - firstrow, rowmargin));
            g.DrawString(contentArr[11], font10, bru, new Rectangle(m, 100 + rowmargin * 3, w - firstrow, rowmargin), strFormat1);

            g.DrawRectangle(blackPen, new Rectangle(m + w - firstrow, 100 + rowmargin * 3, w + firstrow, rowmargin));
            g.DrawString(contentArr[12], font16, bru, new Rectangle(m + w - firstrow, 100 + rowmargin * 3, w + firstrow, rowmargin), strFormat1);

            g.DrawRectangle(blackPen, new Rectangle(m + w * 2, 100 + rowmargin * 3, w - 30, rowmargin));
            g.DrawString(contentArr[13], font16, bru, new Rectangle(m + w * 2, 100 + rowmargin * 3, w, rowmargin), strFormat1);

            g.DrawRectangle(blackPen, new Rectangle(m + w * 3 - 30, 100 + rowmargin * 3, w + 30, rowmargin));
            g.DrawString(contentArr[14], font16, bru, new Rectangle(m + w * 3 - 30, 100 + rowmargin * 3, w, rowmargin), strFormat1);

            g.DrawRectangle(blackPen, new Rectangle(m + w * 4, 100 + rowmargin * 3, w * 2 - 50, rowmargin));
            g.DrawString(contentArr[15], font10, bru, new Rectangle(m + w * 4, 100 + rowmargin * 3, w * 2 - 20, rowmargin), strFormat1);
            //第五行
            g.DrawRectangle(blackPen, new Rectangle(m, 100 + rowmargin * 4, w * 2, rowmargin));
            g.DrawString(contentArr[16], font10, bru, new Rectangle(m, 100 + rowmargin * 4, w * 2, rowmargin), strFormat1);

            g.DrawRectangle(blackPen, new Rectangle(m + w * 2, 100 + rowmargin * 4, w * 4 - 50, rowmargin));
            g.DrawString(contentArr[17], font26, bru, new Rectangle(m + w * 2, 100 + rowmargin * 4, w * 4 - 20, rowmargin), strFormat);
            //第六行
            g.DrawRectangle(blackPen, new Rectangle(m, 100 + rowmargin * 5, w * 2, rowmargin));
            g.DrawString(contentArr[18], font10, bru, new Rectangle(m, 100 + rowmargin * 5, w * 2, rowmargin), strFormat1);

            g.DrawRectangle(blackPen, new Rectangle(m + w * 2, 100 + rowmargin * 5, w * 4 - 50, rowmargin));
            g.DrawString(contentArr[19], font26, bru, new Rectangle(m + w * 2, 100 + rowmargin * 5, w * 4 - 20, rowmargin), strFormat);
            //第七行
            g.DrawRectangle(blackPen, new Rectangle(m, 100 + rowmargin * 6, w * 2, rowmargin));
            g.DrawString(contentArr[20], font10, bru, new Rectangle(m, 100 + rowmargin * 6, w * 2, rowmargin), strFormat1);

            g.DrawRectangle(blackPen, new Rectangle(m + w * 2, 100 + rowmargin * 6, w * 4 - 50, rowmargin));
            g.DrawString(contentArr[21], font16, bru, new Rectangle(m + w * 2, 100 + rowmargin * 6, w * 4 - 20, rowmargin), strFormat);

            g.DrawString(contentArr[22], font10, bru, m, 20 + 130 + rowmargin * 6);

            g.DrawString(contentArr[23], font16, bru, m, 40 + 130 + rowmargin * 6);

            int subHeight = 0;
            int subHeight1 = 0;
            if (contentArr[23].Length < 6)
            {
                subHeight += 35;
                subHeight1 -= 35;
            }
            if (string.IsNullOrEmpty(PrintHead.GYSPC))
            {
                subHeight += 35;
                subHeight1 -= 35;
            }
            else
            {
                g.DrawString(q(Msg_Type.printgys) + PrintHead.GYSPC, font16, bru, m, 70 + 130 + rowmargin * 6 + subHeight1);//"供应商批次:"

            }
            if (string.IsNullOrEmpty(PrintHead.REMARK))
            {

            }
            else
            {
                g.DrawString(q(Msg_Type.printbzxx) + PrintHead.REMARK, font16, bru, m, 70 + 30 + 130 + rowmargin * 6 + subHeight1);//"备注信息:"
                subHeight -= 35;
            }

            for (int i = 0; i < PrintChild.Length; i++)
            {
                Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_LIST data = PrintChild[i];
                g.DrawString(q(Msg_Type.printxctmxx), font10, bru, m, 40 + 200 + rowmargin * 6 + 60 * i - subHeight);//"下层条码信息"
                g.DrawString(q(Msg_Type.printwl) + PrintChild[i].TM + "/" + PrintChild[i].WLMS + "/" + PrintChild[i].PC, font10, bru, m, 60 + 200 + rowmargin * 6 + 60 * i - subHeight);//"物料:"                
                string xczlxx = q(Msg_Type.printzlxx);// "质量信息:";
                if (!string.IsNullOrEmpty(data.SBHMS))
                {
                    xczlxx += data.SBHMS + "/";
                }
                if (!string.IsNullOrEmpty(data.CLCJ))
                {
                    xczlxx += data.CLCJ + "/";
                }
                if (!string.IsNullOrEmpty(data.GYLX))
                {
                    xczlxx += data.GYLX + "/";
                }
                if (!string.IsNullOrEmpty(data.SBHMS) || !string.IsNullOrEmpty(data.CLCJ) || !string.IsNullOrEmpty(data.GYLX))
                {
                    xczlxx = xczlxx.Substring(0, xczlxx.Length - 1);
                }
                if (string.IsNullOrEmpty(data.SBHMS) && string.IsNullOrEmpty(data.CLCJ) && string.IsNullOrEmpty(data.GYLX))
                {
                    xczlxx = "";
                }
                g.DrawString(xczlxx, font10, bru, m, 80 + 200 + rowmargin * 6 + 60 * i - subHeight);

            }
            //  一维码
            //byte[] bytes = ServicModel.BarCode.CreateBarCode(PrintHead.TM, "CODE128", 380, 60, 1);
            //MemoryStream ms = new MemoryStream(bytes);
            //Image returnImage = Image.FromStream(ms);
            //g.DrawImage(returnImage, width - 180 - 80 - 100 -20, 70 + 150 + rowmargin * 5 + 22, 380, 60);
            //g.DrawString(PrintHead.TM, font22, bru, width - 180 - 5 - 50 - 30 - 50, 70 + 150 + rowmargin * 5 + 60 + 18);
            byte[] bytes = ServicModel.BarCode.CreateBarCode(PrintHead.TM, "QRCODE", 70, 70, 1);
            MemoryStream ms = new MemoryStream(bytes);
            Image returnImage = Image.FromStream(ms);
            g.DrawImage(returnImage, width - 180, 150 + rowmargin * 5 + 40 + 45, 70, 70);
            g.DrawString(PrintHead.TM, font14, bru, width - 210, 150 + rowmargin * 5 + 45 + 70 + 40);


            int len = 5;
            g.DrawRectangle(blackPen, new Rectangle(m, 100 + rowmargin * 7, w * 6 - 50, 80 + len * 20 - 20));
            //this.Close();
            //物料库存标识(自制)
        }
        private void DrawLot(PrintPageEventArgs e)
        {
            #region EPSON

            Pen blackPen = new Pen(Color.Black, 1);
            Font font22 = new Font(q(Msg_Type.fonttype), 22, FontStyle.Bold);
            Font font14 = new Font(q(Msg_Type.fonttype), 14, FontStyle.Bold);
            Font font13 = new Font(q(Msg_Type.fonttype), 13, FontStyle.Bold);
            Font font12 = new Font(q(Msg_Type.fonttype), 12, FontStyle.Bold);
            Font font10 = new Font(q(Msg_Type.fonttype), 10, FontStyle.Bold);
            Font font8 = new Font(q(Msg_Type.fonttype), 8, FontStyle.Bold);
            Brush bru = Brushes.Black;
            Graphics g = e.Graphics;//画布
            StringFormat strFormat = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat.Alignment = StringAlignment.Center;//水平居中

            StringFormat strFormat1 = new StringFormat();
            strFormat1.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat1.Alignment = StringAlignment.Near;//水平居中
            StringFormat strFormat2 = new StringFormat();
            strFormat2.LineAlignment = StringAlignment.Near;//垂直居中
            strFormat2.Alignment = StringAlignment.Near;//水平居中
            int width = 272;
            //int xmargin = 5;
            int hrowmargin = 20;
            int rowmargin = 18;
            int grid = width / 2;
            int bzHeight = 0;
            int margin = 8;//开始间隔
            if (PrintChild != null && PrintChild.Length > 0)
            {
                bzHeight = 11 * rowmargin + 5 + PrintChild.Length * 75;
            }
            else
            {
                bzHeight = 11 * rowmargin + 20;
            }

            int subWidth = -70;
            Rectangle recHead = new Rectangle(margin, 0, width, hrowmargin);//矩形
            g.DrawString(PrintHead.GCDYMS, font13, bru, recHead, strFormat);

            g.DrawString(q(Msg_Type.printwllotb), font10, bru, margin + 95, hrowmargin + 10 - 15);//"物料LOT表"


            byte[] bytes = ServicModel.BarCode.CreateBarCode(PrintHead.TM, "QRCODE", 70, 70, 1);
            MemoryStream ms = new MemoryStream(bytes);
            Image returnImage = Image.FromStream(ms);
            g.DrawImage(returnImage, margin + 95, hrowmargin + 10, 70, 70);
            g.DrawString(PrintHead.TM, font8, bru, margin + 95, hrowmargin + 80);

            string LotNo = string.IsNullOrEmpty(PrintHead.LOTNO) ? string.Format(q(Msg_Type.printbhformat), "JS4002A") : q(Msg_Type.printbh) + PrintHead.LOTNO;//"编号: JS4002A" "编号: "
            g.DrawString(LotNo, font8, bru, margin, hrowmargin + 80);
            if (PrintHead.TH > 0)
            {
                if (RigthType == Rigth_Type.jidiantitl_cc)
                {
                    g.DrawString(q(Msg_Type.printxh) + PrintHead.TH.ToString(), font10, bru, margin + 220, hrowmargin + 80);// "序号:"
                }
                else
                {
                    g.DrawString(q(Msg_Type.printxh) + PrintHead.TH.ToString(), font10, bru, margin + 220, hrowmargin + 80);//"序号:"
                }

            }

            for (int i = 0; i < 10; i++)
            {
                g.DrawLine(blackPen, margin, rowmargin * (i + 2) + 10 - subWidth, width + margin, rowmargin * (i + 2) + 10 - subWidth);
            }

            string scrq = "";
            string scrq2 = q(Msg_Type.printscsj);// "生产时间";
            if (!string.IsNullOrEmpty(PrintHead.BCMS))
            {
                //scrq = PrintHead.SCDATE + "/" + PrintHead.BCMS;
                scrq = PrintHead.SCDATEP + "/" + PrintHead.BCMS;
            }
            else
            {
                scrq = PrintHead.SCDATEP;
            }


            string pc = q(Msg_Type.printgcpc);// "工厂批次";
            string pccontent = PrintHead.PC;
            if (RigthType == Rigth_Type.dczztl_cc)
            {
                pc = q(Msg_Type.printwlsx);//"物料属性";
                if (!string.IsNullOrEmpty(PrintHead.NOBILL))
                {
                    pccontent = PrintHead.NOBILL + "-" + PrintHead.NOBILLMX + "/" + PrintHead.PC;
                }
            }
            string tgf = PrintHead.GZZXBH;
            if (!string.IsNullOrEmpty(PrintHead.GZZXMS))
            {
                tgf += "-" + PrintHead.GZZXMS;
            }

            string[] contentArr = {q(Msg_Type.printwlbm), PrintHead.WLH, q(Msg_Type.printwlms), PrintHead.WLMS, pc, pccontent, scrq2, 
                                      scrq,q(Msg_Type.printtgf) , tgf, q(Msg_Type.printsbh), PrintHead.SBHMS, q(Msg_Type.printsl), PrintHead.SL.ToString("0.##") + " " + PrintHead.UNITSNAME,q(Msg_Type.printcpzt) , PrintHead.CPZTNAME,q(Msg_Type.printczg) , CzlList };
            //string[] contentArr = { "物料编码", PrintHead.WLH, "物料描述", PrintHead.WLMS, pc, pccontent, scrq2, 
            //scrq, "提供方", tgf, "设备号", PrintHead.SBHMS, "数量"  , PrintHead.SL.ToString("0.##") + " " + PrintHead.UNITSNAME, "产品状态", PrintHead.CPZTNAME, "操作工", CzlList };

            for (int i = 0; i < contentArr.Length; i++)
            {
                int index = i % 2 == 0 ? 0 : 1;
                if (index == 0)
                {
                    g.DrawString(contentArr[i], font10, bru, new Rectangle(margin + width / 4 * index, rowmargin * 2 + 12 + rowmargin * (i / 2) - subWidth, width, rowmargin), strFormat1);
                }
                else
                {

                    g.DrawString(contentArr[i], font10, bru, new Rectangle(margin + width / 4 * index, rowmargin * 2 + 12 + rowmargin * (i / 2) - subWidth, width, rowmargin), strFormat1);

                }

            }


            int addheigth = 15;
            for (int i = 0; i < PrintChild.Length; i++)
            {
                List<ChildPrint> nodes = new List<ChildPrint>();
                ChildPrint node1 = new ChildPrint();
                node1.Content = q(Msg_Type.printxcm) + PrintChild[i].TM;//"下层码"
                node1.Font = font8;
                nodes.Add(node1);
                ChildPrint node2 = new ChildPrint();
                node2.Content = q(Msg_Type.printwl) + PrintChild[i].WLMS;//"物料:"
                node2.Font = font10;
                nodes.Add(node2);
                if (PrintHead.WLLBNAME.Equals("集电体"))
                {
                    if (!string.IsNullOrEmpty(PrintChild[i].PC))
                    {
                        ChildPrint node3 = new ChildPrint();
                        node3.Content = q(Msg_Type.printpcxx);//"批次信息:";
                        node3.Content += PrintChild[i].PC;
                        node3.Font = font10;
                        nodes.Add(node3);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(PrintChild[i].PC) || PrintChild[i].TH != 0)
                    {
                        ChildPrint node3 = new ChildPrint();
                        node3.Content = q(Msg_Type.printpcxx);// "批次信息:";
                        if (!string.IsNullOrEmpty(PrintChild[i].PC))
                        {
                            node3.Content += PrintChild[i].PC;
                            if (PrintChild[i].TH != 0)
                            {
                                node3.Content += "/" + PrintChild[i].TH.ToString();
                            }
                        }
                        else
                        {
                            node3.Content += PrintChild[i].TH.ToString();
                        }
                        node3.Font = font10;
                        nodes.Add(node3);
                    }
                }
                if (PrintHead.WLLBNAME.Equals("集电体"))
                {
                    if (!string.IsNullOrEmpty(PrintChild[i].GYSMS) || !string.IsNullOrEmpty(PrintChild[i].SBHMS))
                    {
                        ChildPrint node4 = new ChildPrint();
                        node4.Font = font10;
                        if (PrintChild[i].WLLBNAME.Equals("电镀铜钉"))
                        {
                            if (!string.IsNullOrEmpty(PrintChild[i].GYSMS))
                            {
                                node4.Content = q(Msg_Type.printzlxx) + PrintChild[i].GYSMS;//"质量信息:"
                                nodes.Add(node4);
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(PrintChild[i].GYSMS))
                            {
                                node4.Content = q(Msg_Type.printzlxx) + PrintChild[i].GYSMS;//"质量信息:"
                                if (!string.IsNullOrEmpty(PrintChild[i].SBHMS))
                                {
                                    node4.Content += "/" + PrintChild[i].SBHMS;
                                }
                                nodes.Add(node4);
                            }
                            else
                            {
                                node4.Content = q(Msg_Type.printzlxx) + PrintChild[i].SBHMS;//"质量信息:"
                                nodes.Add(node4);
                            }
                        }


                    }
                }
                else
                {

                    if (!string.IsNullOrEmpty(PrintChild[i].GYSMS) || !string.IsNullOrEmpty(PrintChild[i].SBHMS))
                    {
                        ChildPrint node4 = new ChildPrint();
                        node4.Font = font10;

                        if (!string.IsNullOrEmpty(PrintChild[i].GYSMS))
                        {
                            node4.Content = q(Msg_Type.printzlxx) + PrintChild[i].GYSMS;//"质量信息:"
                            if (!string.IsNullOrEmpty(PrintChild[i].SBHMS))
                            {
                                node4.Content += "/" + PrintChild[i].SBHMS;
                            }

                        }
                        else
                        {
                            node4.Content = q(Msg_Type.printzlxx) + PrintChild[i].SBHMS;//"质量信息:"

                        }

                        nodes.Add(node4);

                    }

                }
                if (!PrintHead.WLLBNAME.Equals("集电体"))
                {
                    if (!string.IsNullOrEmpty(PrintChild[i].CLCJ) || !string.IsNullOrEmpty(PrintChild[i].GYLX))
                    {
                        ChildPrint node5 = new ChildPrint();
                        node5.Font = font10;
                        if (!string.IsNullOrEmpty(PrintChild[i].CLCJ))
                        {
                            node5.Content = PrintChild[i].CLCJ;
                            if (!string.IsNullOrEmpty(PrintChild[i].GYLX))
                            {
                                node5.Content += "/" + PrintChild[i].GYLX;
                            }
                        }
                        else
                        {
                            node5.Content = PrintChild[i].GYLX;
                        }
                        nodes.Add(node5);
                    }
                }
                if (!string.IsNullOrEmpty(PrintChild[i].REMARK))
                {
                    ChildPrint node6 = new ChildPrint();
                    node6.Font = font10;
                    node6.Content = q(Msg_Type.printbz) + ":" + PrintChild[i].REMARK;//"备注" 
                    nodes.Add(node6);
                }

                for (int j = 0; j < nodes.Count; j++)
                {
                    g.DrawString(nodes[j].Content, nodes[j].Font, bru, margin + 5, 11 * rowmargin + addheigth - subWidth);
                    addheigth += 15;
                }


            }
            for (int i = 0; i < 3; i++)
            {
                if (i != 1)
                {
                    g.DrawLine(blackPen, margin + grid * i, rowmargin * 2 + 10 - subWidth, grid * i + margin, 11 * rowmargin + addheigth - subWidth + 30);
                }
                else
                {
                    g.DrawLine(blackPen, margin + width / 4, rowmargin * 2 + 10 - subWidth, width / 4 + margin, rowmargin * 11 + 10 - subWidth);
                }

            }
            g.DrawLine(blackPen, margin, 11 * rowmargin + addheigth - subWidth + 30, width + margin, 11 * rowmargin + addheigth - subWidth + 30);
            g.DrawString(q(Msg_Type.printbz) + ":" + PrintHead.REMARK, font8, bru, new Rectangle(margin + 5, 11 * rowmargin + addheigth - subWidth + 10, width, 30));//"备注"


            //int sub_height = 0;
            //int s_height = 75;
            //int sub_count = 0;
            //for (int i = 0; i < PrintChild.Length; i++)
            //{

            //    string wl = "物料:";
            //    if (!string.IsNullOrEmpty(PrintChild[i].WLMS))
            //    {
            //        wl += PrintChild[i].WLMS;
            //    }
            //    string zlxxStr = "质量信息:";
            //    if (!string.IsNullOrEmpty(PrintChild[i].GYSMS))
            //    {
            //        zlxxStr += PrintChild[i].GYSMS;
            //    }
            //    if (!string.IsNullOrEmpty(PrintChild[i].SBHMS))
            //    {
            //        if (!string.IsNullOrEmpty(PrintChild[i].GYSMS))
            //        {
            //            zlxxStr += "/" + PrintChild[i].SBHMS;
            //        }
            //        else
            //        {
            //            zlxxStr += PrintChild[i].SBHMS;
            //        }
            //    }
            //    string zlxxStr1 = "";

            //    if (!string.IsNullOrEmpty(PrintChild[i].CLCJ))
            //    {
            //        zlxxStr1 += PrintChild[i].CLCJ;
            //    }
            //    if (!string.IsNullOrEmpty(PrintChild[i].GYLX))
            //    {
            //        if (!string.IsNullOrEmpty(PrintChild[i].CLCJ))
            //        {
            //            zlxxStr1 += "/" + PrintChild[i].GYLX;
            //        }
            //        else
            //        {
            //            zlxxStr1 += PrintChild[i].GYLX;
            //        }
            //    } string wl2 = "批次信息:";
            //    if (!string.IsNullOrEmpty(PrintChild[i].PC))
            //    {

            //        wl2 += PrintChild[i].PC;

            //    }
            //    if (PrintChild[i].TH != 0)
            //    {
            //        if (!string.IsNullOrEmpty(PrintChild[i].PC))
            //        {
            //            wl2 += "/" + PrintChild[i].TH.ToString();
            //        }
            //        else
            //        {
            //            wl2 += PrintChild[i].TH.ToString();
            //        }
            //    }

            //    if (PrintHead.WLLBNAME.Equals("集电体"))
            //    {
            //        s_height = 60;
            //        g.DrawString("下层码: " + PrintChild[i].TM, font5, bru, margin + 5, 11 * rowmargin + 15 + s_height * i - subWidth - sub_height);
            //        wl2 = "批次信息:" + PrintChild[i].PC;
            //        g.DrawString(wl, font7, bru, margin + 5, 11 * rowmargin + 30 + s_height * i - subWidth - sub_height);
            //        g.DrawString(wl2, font7, bru, margin + 5, 11 * rowmargin + 45 + s_height * i - subWidth - sub_height);
            //        if (PrintChild[i].WLLBNAME.Equals("电镀铜钉"))
            //        {
            //            zlxxStr = "质量信息:" + PrintChild[i].GYSMS;
            //        }


            //        g.DrawString(zlxxStr, font7, bru, margin + 5, 11 * rowmargin + 60 + s_height * i - subWidth - sub_height);



            //    }
            //    else
            //    {
            //        g.DrawString("下层码: " + PrintChild[i].TM, font5, bru, margin + 5, 11 * rowmargin + 15 + 75 * i - subWidth);
            //        g.DrawString(wl, font7, bru, margin + 5, 11 * rowmargin + 30 + s_height * i - subWidth);
            //        g.DrawString(wl2, font7, bru, margin + 5, 11 * rowmargin + 45 + s_height * i - subWidth);
            //        g.DrawString(zlxxStr, font7, bru, margin + 5, 11 * rowmargin + 60 + s_height * i - subWidth);
            //        g.DrawString(zlxxStr1, font7, bru, margin + 5, 11 * rowmargin + 75 + s_height * i - subWidth);

            //    }

            //}
            //bzHeight = bzHeight - sub_count * 15 - (75 - s_height) * PrintChild.Length;
            //g.DrawString("备注:" + PrintHead.REMARK, font5, bru, new Rectangle(margin + 5, bzHeight - subWidth + 15, width, 30));
            //for (int i = 0; i < 3; i++)
            //{
            //    if (i != 1)
            //    {
            //        g.DrawLine(blackPen, margin + grid * i, rowmargin * 2 + 10 - subWidth, grid * i + margin, bzHeight + 30 - subWidth);
            //    }
            //    else
            //    {
            //        g.DrawLine(blackPen, margin + width / 4, rowmargin * 2 + 10 - subWidth, width / 4 + margin, rowmargin * 11 + 10 - subWidth);
            //    }

            //}
            //g.DrawLine(blackPen, margin, bzHeight + 30 - subWidth, width + margin, bzHeight + 30 - subWidth);
            #endregion
            #region 佳博
            //Pen blackPen = new Pen(Color.Black, 1);
            //Font font22 = new Font(q(Msg_Type.fonttype), 22, FontStyle.Bold);
            //Font font14 = new Font(q(Msg_Type.fonttype), 14, FontStyle.Bold);
            //Font font13 = new Font(q(Msg_Type.fonttype), 13, FontStyle.Bold);
            //Font font9 = new Font(q(Msg_Type.fonttype), 12, FontStyle.Bold);
            //Font font7 = new Font(q(Msg_Type.fonttype), 10, FontStyle.Bold);
            //Font font5 = new Font(q(Msg_Type.fonttype), 8, FontStyle.Bold);
            //Brush bru = Brushes.Black;
            //Graphics g = e.Graphics;//画布
            //StringFormat strFormat = new StringFormat();
            //strFormat.LineAlignment = StringAlignment.Center;//垂直居中
            //strFormat.Alignment = StringAlignment.Center;//水平居中

            //StringFormat strFormat1 = new StringFormat();
            //strFormat1.LineAlignment = StringAlignment.Center;//垂直居中
            //strFormat1.Alignment = StringAlignment.Near;//水平居中
            //StringFormat strFormat2 = new StringFormat();
            //strFormat2.LineAlignment = StringAlignment.Near;//垂直居中
            //strFormat2.Alignment = StringAlignment.Near;//水平居中
            //int width = 272;
            //int xmargin = 5;
            //int hrowmargin = 20;
            //int rowmargin = 18;
            //int grid = width / 2;
            //int bzHeight = 0;
            //int margin = 0;//开始间隔
            //if (PrintChild != null)
            //{
            //    bzHeight = 11 * rowmargin + 20 + PrintChild.Length * 60;
            //}
            //else
            //{
            //    bzHeight = 11 * rowmargin + 20;
            //}

            //int subWidth = 15;
            //Rectangle recHead = new Rectangle(0, 0, width, hrowmargin);//矩形
            //g.DrawString(PrintHead.GCDYMS, font13, bru, recHead, strFormat);
            //g.DrawString("编号: JS4501A", font5, bru, 0, hrowmargin + 12 - subWidth);
            //g.DrawString("LOT表", font7, bru, 110, hrowmargin + 10 - subWidth);
            //for (int i = 0; i < 10; i++)
            //{
            //    g.DrawLine(blackPen, 0, rowmargin * (i + 2) + 10 - subWidth, width, rowmargin * (i + 2) + 10 - subWidth);
            //}
            //for (int i = 0; i < 3; i++)
            //{
            //    if (i != 1)
            //    {
            //        g.DrawLine(blackPen, grid * i, rowmargin * 2 + 10 - subWidth, grid * i, bzHeight + 110 - subWidth);
            //    }
            //    else
            //    {
            //        g.DrawLine(blackPen, width / 4, rowmargin * 2 + 10 - subWidth, width / 4, rowmargin * 11 + 10 - subWidth);
            //    }

            //}
            //g.DrawLine(blackPen, 0, bzHeight + 110 - subWidth, width, bzHeight + 110 - subWidth);
            //string scrq = "";
            //string scrq2 = "生产时间";
            //if (!string.IsNullOrEmpty(PrintHead.BCMS))
            //{
            //    scrq = PrintHead.SCDATE + "/" + PrintHead.BCMS;
            //}
            //else
            //{
            //    scrq = PrintHead.SCDATE;
            //}


            //string pc = "工厂批次";
            //string pccontent = PrintHead.PC;
            //if (RigthType == Rigth_Type.dczztl_cc)
            //{
            //    pc = "物料属性";
            //    if (!string.IsNullOrEmpty(PrintHead.NOBILL))
            //    {
            //        pccontent = PrintHead.NOBILL + "-" + PrintHead.NOBILLMX + "/" + PrintHead.PC;
            //    }
            //}
            //string tgf = PrintHead.GZZXBH;
            //if (!string.IsNullOrEmpty(PrintHead.GZZXMS))
            //{
            //    tgf += "-" + PrintHead.GZZXMS;
            //}

            //string[] contentArr = { "物料编码", PrintHead.WLH, "物料描述", PrintHead.WLMS, pc, pccontent, scrq2, 
            //                          scrq, "提供方", tgf, "设备号", PrintHead.SBHMS, "数量"  , PrintHead.SL.ToString("0.##") + " " + PrintHead.UNITSNAME, "产品状态", PrintHead.CPZTNAME, "操作工", CzlList };

            //for (int i = 0; i < contentArr.Length; i++)
            //{
            //    int index = i % 2 == 0 ? 0 : 1;
            //    if (index == 0)
            //    {
            //        g.DrawString(contentArr[i], font7, bru, new Rectangle(width / 4 * index, rowmargin * 2 + 12 + rowmargin * (i / 2) - subWidth, width, rowmargin), strFormat1);
            //    }
            //    else
            //    {

            //        g.DrawString(contentArr[i], font7, bru, new Rectangle(width / 4 * index, rowmargin * 2 + 12 + rowmargin * (i / 2) - subWidth, width, rowmargin), strFormat1);

            //    }

            //}


            //for (int i = 0; i < PrintChild.Length; i++)
            //{
            //    g.DrawString("下层码: " + PrintChild[i].TM, font5, bru, 5, 11 * rowmargin + 15 + 55 * i - subWidth);
            //    g.DrawString("物料: " + PrintChild[i].WLMS + "/" + PrintChild[i].PC, font5, bru, 5, 11 * rowmargin + 30 + 55 * i - subWidth);
            //    string zlxxStr = "质量信息:";
            //    if (!string.IsNullOrEmpty(PrintChild[i].GYSMS))
            //    {
            //        zlxxStr += PrintChild[i].GYSMS;
            //    }
            //    if (!string.IsNullOrEmpty(PrintChild[i].SBHMS))
            //    {
            //        if (!string.IsNullOrEmpty(PrintChild[i].GYSMS))
            //        {
            //            zlxxStr += "/" + PrintChild[i].SBHMS;
            //        }
            //        else
            //        {
            //            zlxxStr += PrintChild[i].SBHMS;
            //        }
            //    }
            //    if (!string.IsNullOrEmpty(PrintChild[i].CLCJ))
            //    {
            //        if (!string.IsNullOrEmpty(PrintChild[i].GYSMS) || !string.IsNullOrEmpty(PrintChild[i].GYSMS))
            //        {
            //            zlxxStr += "/" + PrintChild[i].CLCJ;
            //        }
            //        else
            //        {
            //            zlxxStr += PrintChild[i].CLCJ;
            //        }
            //    }
            //    if (!string.IsNullOrEmpty(PrintChild[i].GYLX))
            //    {
            //        if (!string.IsNullOrEmpty(PrintChild[i].GYSMS) || !string.IsNullOrEmpty(PrintChild[i].GYSMS) || !string.IsNullOrEmpty(PrintChild[i].CLCJ))
            //        {
            //            zlxxStr += "/" + PrintChild[i].GYLX;
            //        }
            //        else
            //        {
            //            zlxxStr += PrintChild[i].GYLX;
            //        }
            //    }
            //    g.DrawString(zlxxStr, font5, bru, new Rectangle(5, 11 * rowmargin + 45 + 55 * i - subWidth, width, 30), strFormat2);
            //}
            //g.DrawString("备注:" + PrintHead.REMARK, font5, bru, 5, bzHeight - subWidth);
            //byte[] bytes = ServicModel.BarCode.CreateBarCode(PrintHead.TM, "QRCODE", 70, 70, 1);
            //MemoryStream ms = new MemoryStream(bytes);
            //Image returnImage = Image.FromStream(ms);
            //g.DrawImage(returnImage, 10, bzHeight + 15 - subWidth, 70, 70);
            //g.DrawString(PrintHead.TM, font7, bru, 10, bzHeight + 15 + 80 - subWidth);
            #endregion

        }
        private void DrawLot_FORMATE(PrintPageEventArgs e)
        {
            #region EPSON

            Pen blackPen = new Pen(Color.Black, 1);
            Font font22 = new Font(q(Msg_Type.fonttype), 22, FontStyle.Bold);
            Font font14 = new Font(q(Msg_Type.fonttype), 14, FontStyle.Bold);
            Font font13 = new Font(q(Msg_Type.fonttype), 13, FontStyle.Bold);
            Font font9 = new Font(q(Msg_Type.fonttype), 12, FontStyle.Bold);
            Font font7 = new Font(q(Msg_Type.fonttype), 10, FontStyle.Bold);
            Font font5 = new Font(q(Msg_Type.fonttype), 8, FontStyle.Bold);
            Brush bru = Brushes.Black;
            Graphics g = e.Graphics;//画布
            StringFormat strFormat = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat.Alignment = StringAlignment.Center;//水平居中

            StringFormat strFormat1 = new StringFormat();
            strFormat1.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat1.Alignment = StringAlignment.Near;//水平居中
            StringFormat strFormat2 = new StringFormat();
            strFormat2.LineAlignment = StringAlignment.Near;//垂直居中
            strFormat2.Alignment = StringAlignment.Near;//水平居中
            int width = 272;
            //int xmargin = 5;
            int hrowmargin = 20;
            int rowmargin = 18;
            int grid = width / 2;
            int bzHeight = 0;
            int margin = 8;//开始间隔
            if (PrintChild != null && PrintChild.Length > 0)
            {
                bzHeight = 11 * rowmargin + 5 + PrintChild.Length * 75;
            }
            else
            {
                bzHeight = 11 * rowmargin + 20;
            }

            int subWidth = -70;
            Rectangle recHead = new Rectangle(margin, 0, width, hrowmargin);//矩形
            g.DrawString(PrintHead.GCDYMS, font13, bru, recHead, strFormat);

            g.DrawString("物料LOT表", font7, bru, margin + 95, hrowmargin + 10 - 15);


            byte[] bytes = ServicModel.BarCode.CreateBarCode(PrintHead.TM, "QRCODE", 70, 70, 1);
            MemoryStream ms = new MemoryStream(bytes);
            Image returnImage = Image.FromStream(ms);
            g.DrawImage(returnImage, margin + 95, hrowmargin + 10, 70, 70);
            g.DrawString(PrintHead.TM, font5, bru, margin + 95, hrowmargin + 80);
            g.DrawString("编号: JS4002A", font5, bru, margin, hrowmargin + 80);
            if (PrintHead.TH > 0)
            {
                if (RigthType == Rigth_Type.jidiantitl_cc)
                {
                    g.DrawString("序号:" + PrintHead.TH.ToString(), font7, bru, margin + 220, hrowmargin + 80);
                }
                else
                {
                    g.DrawString("序号:" + PrintHead.TH.ToString(), font7, bru, margin + 220, hrowmargin + 80);
                }

            }

            for (int i = 0; i < 10; i++)
            {
                g.DrawLine(blackPen, margin, rowmargin * (i + 2) + 10 - subWidth, width + margin, rowmargin * (i + 2) + 10 - subWidth);
            }

            string scrq = "";
            string scrq2 = "生产时间";
            if (!string.IsNullOrEmpty(PrintHead.BCMS))
            {
                scrq = PrintHead.SCDATE + "/" + PrintHead.BCMS;
            }
            else
            {
                scrq = PrintHead.SCDATE;
            }


            string pc = "工厂批次";
            string pccontent = PrintHead.PC;
            if (RigthType == Rigth_Type.dczztl_cc)
            {
                pc = "物料属性";
                if (!string.IsNullOrEmpty(PrintHead.NOBILL))
                {
                    pccontent = PrintHead.NOBILL + "-" + PrintHead.NOBILLMX + "/" + PrintHead.PC;
                }
            }
            string tgf = PrintHead.GZZXBH;
            if (!string.IsNullOrEmpty(PrintHead.GZZXMS))
            {
                tgf += "-" + PrintHead.GZZXMS;
            }

            string[] contentArr = { "物料编码", PrintHead.WLH, "物料描述", PrintHead.WLMS, pc, pccontent, scrq2, 
                                      scrq, "提供方", tgf, "设备号", PrintHead.SBHMS, "数量"  , PrintHead.SL.ToString("0.##") + " " + PrintHead.UNITSNAME, "产品状态", PrintHead.CPZTNAME, "操作工", CzlList };

            for (int i = 0; i < contentArr.Length; i++)
            {
                int index = i % 2 == 0 ? 0 : 1;
                if (index == 0)
                {
                    g.DrawString(contentArr[i], font7, bru, new Rectangle(margin + width / 4 * index, rowmargin * 2 + 12 + rowmargin * (i / 2) - subWidth, width, rowmargin), strFormat1);
                }
                else
                {

                    g.DrawString(contentArr[i], font7, bru, new Rectangle(margin + width / 4 * index, rowmargin * 2 + 12 + rowmargin * (i / 2) - subWidth, width, rowmargin), strFormat1);

                }

            }

            int sub_height = 0;
            int s_height = 75;
            int sub_count = 0;
            for (int i = 0; i < PrintChild.Length; i++)
            {

                string wl = "物料:";
                if (!string.IsNullOrEmpty(PrintChild[i].WLMS))
                {
                    wl += PrintChild[i].WLMS;
                }
                string zlxxStr = "质量信息:";
                if (!string.IsNullOrEmpty(PrintChild[i].GYSMS))
                {
                    zlxxStr += PrintChild[i].GYSMS;
                }
                if (!string.IsNullOrEmpty(PrintChild[i].SBHMS))
                {
                    if (!string.IsNullOrEmpty(PrintChild[i].GYSMS))
                    {
                        zlxxStr += "/" + PrintChild[i].SBHMS;
                    }
                    else
                    {
                        zlxxStr += PrintChild[i].SBHMS;
                    }
                }
                string zlxxStr1 = "";

                if (!string.IsNullOrEmpty(PrintChild[i].CLCJ))
                {
                    zlxxStr1 += PrintChild[i].CLCJ;
                }
                if (!string.IsNullOrEmpty(PrintChild[i].GYLX))
                {
                    if (!string.IsNullOrEmpty(PrintChild[i].CLCJ))
                    {
                        zlxxStr1 += "/" + PrintChild[i].GYLX;
                    }
                    else
                    {
                        zlxxStr1 += PrintChild[i].GYLX;
                    }
                } string wl2 = "批次信息:";
                if (!string.IsNullOrEmpty(PrintChild[i].PC))
                {

                    wl2 += PrintChild[i].PC;

                }
                if (PrintChild[i].TH != 0)
                {
                    if (!string.IsNullOrEmpty(PrintChild[i].PC))
                    {
                        wl2 += "/" + PrintChild[i].TH.ToString();
                    }
                    else
                    {
                        wl2 += PrintChild[i].TH.ToString();
                    }
                }

                if (PrintHead.WLLBNAME.Equals("集电体"))
                {
                    s_height = 60;
                    g.DrawString("下层码: " + PrintChild[i].TM, font5, bru, margin + 5, 11 * rowmargin + 15 + s_height * i - subWidth - sub_height);
                    wl2 = "批次信息:" + PrintChild[i].PC;
                    g.DrawString(wl, font7, bru, margin + 5, 11 * rowmargin + 30 + s_height * i - subWidth - sub_height);
                    g.DrawString(wl2, font7, bru, margin + 5, 11 * rowmargin + 45 + s_height * i - subWidth - sub_height);
                    if (PrintChild[i].WLLBNAME.Equals("电镀铜钉"))
                    {
                        zlxxStr = "质量信息:" + PrintChild[i].GYSMS;
                    }


                    g.DrawString(zlxxStr, font7, bru, margin + 5, 11 * rowmargin + 60 + s_height * i - subWidth - sub_height);



                }
                else
                {
                    g.DrawString("下层码: " + PrintChild[i].TM, font5, bru, margin + 5, 11 * rowmargin + 15 + 75 * i - subWidth);
                    g.DrawString(wl, font7, bru, margin + 5, 11 * rowmargin + 30 + s_height * i - subWidth);
                    g.DrawString(wl2, font7, bru, margin + 5, 11 * rowmargin + 45 + s_height * i - subWidth);
                    g.DrawString(zlxxStr, font7, bru, margin + 5, 11 * rowmargin + 60 + s_height * i - subWidth);
                    g.DrawString(zlxxStr1, font7, bru, margin + 5, 11 * rowmargin + 75 + s_height * i - subWidth);

                }

            }
            bzHeight = bzHeight - sub_count * 15 - (75 - s_height) * PrintChild.Length;
            g.DrawString("备注:" + PrintHead.REMARK, font5, bru, new Rectangle(margin + 5, bzHeight - subWidth + 15, width, 30));
            for (int i = 0; i < 3; i++)
            {
                if (i != 1)
                {
                    g.DrawLine(blackPen, margin + grid * i, rowmargin * 2 + 10 - subWidth, grid * i + margin, bzHeight + 30 - subWidth);
                }
                else
                {
                    g.DrawLine(blackPen, margin + width / 4, rowmargin * 2 + 10 - subWidth, width / 4 + margin, rowmargin * 11 + 10 - subWidth);
                }

            }
            g.DrawLine(blackPen, margin, bzHeight + 30 - subWidth, width + margin, bzHeight + 30 - subWidth);
            #endregion
            #region 佳博
            //Pen blackPen = new Pen(Color.Black, 1);
            //Font font22 = new Font(q(Msg_Type.fonttype), 22, FontStyle.Bold);
            //Font font14 = new Font(q(Msg_Type.fonttype), 14, FontStyle.Bold);
            //Font font13 = new Font(q(Msg_Type.fonttype), 13, FontStyle.Bold);
            //Font font9 = new Font(q(Msg_Type.fonttype), 12, FontStyle.Bold);
            //Font font7 = new Font(q(Msg_Type.fonttype), 10, FontStyle.Bold);
            //Font font5 = new Font(q(Msg_Type.fonttype), 8, FontStyle.Bold);
            //Brush bru = Brushes.Black;
            //Graphics g = e.Graphics;//画布
            //StringFormat strFormat = new StringFormat();
            //strFormat.LineAlignment = StringAlignment.Center;//垂直居中
            //strFormat.Alignment = StringAlignment.Center;//水平居中

            //StringFormat strFormat1 = new StringFormat();
            //strFormat1.LineAlignment = StringAlignment.Center;//垂直居中
            //strFormat1.Alignment = StringAlignment.Near;//水平居中
            //StringFormat strFormat2 = new StringFormat();
            //strFormat2.LineAlignment = StringAlignment.Near;//垂直居中
            //strFormat2.Alignment = StringAlignment.Near;//水平居中
            //int width = 272;
            //int xmargin = 5;
            //int hrowmargin = 20;
            //int rowmargin = 18;
            //int grid = width / 2;
            //int bzHeight = 0;
            //int margin = 0;//开始间隔
            //if (PrintChild != null)
            //{
            //    bzHeight = 11 * rowmargin + 20 + PrintChild.Length * 60;
            //}
            //else
            //{
            //    bzHeight = 11 * rowmargin + 20;
            //}

            //int subWidth = 15;
            //Rectangle recHead = new Rectangle(0, 0, width, hrowmargin);//矩形
            //g.DrawString(PrintHead.GCDYMS, font13, bru, recHead, strFormat);
            //g.DrawString("编号: JS4501A", font5, bru, 0, hrowmargin + 12 - subWidth);
            //g.DrawString("LOT表", font7, bru, 110, hrowmargin + 10 - subWidth);
            //for (int i = 0; i < 10; i++)
            //{
            //    g.DrawLine(blackPen, 0, rowmargin * (i + 2) + 10 - subWidth, width, rowmargin * (i + 2) + 10 - subWidth);
            //}
            //for (int i = 0; i < 3; i++)
            //{
            //    if (i != 1)
            //    {
            //        g.DrawLine(blackPen, grid * i, rowmargin * 2 + 10 - subWidth, grid * i, bzHeight + 110 - subWidth);
            //    }
            //    else
            //    {
            //        g.DrawLine(blackPen, width / 4, rowmargin * 2 + 10 - subWidth, width / 4, rowmargin * 11 + 10 - subWidth);
            //    }

            //}
            //g.DrawLine(blackPen, 0, bzHeight + 110 - subWidth, width, bzHeight + 110 - subWidth);
            //string scrq = "";
            //string scrq2 = "生产时间";
            //if (!string.IsNullOrEmpty(PrintHead.BCMS))
            //{
            //    scrq = PrintHead.SCDATE + "/" + PrintHead.BCMS;
            //}
            //else
            //{
            //    scrq = PrintHead.SCDATE;
            //}


            //string pc = "工厂批次";
            //string pccontent = PrintHead.PC;
            //if (RigthType == Rigth_Type.dczztl_cc)
            //{
            //    pc = "物料属性";
            //    if (!string.IsNullOrEmpty(PrintHead.NOBILL))
            //    {
            //        pccontent = PrintHead.NOBILL + "-" + PrintHead.NOBILLMX + "/" + PrintHead.PC;
            //    }
            //}
            //string tgf = PrintHead.GZZXBH;
            //if (!string.IsNullOrEmpty(PrintHead.GZZXMS))
            //{
            //    tgf += "-" + PrintHead.GZZXMS;
            //}

            //string[] contentArr = { "物料编码", PrintHead.WLH, "物料描述", PrintHead.WLMS, pc, pccontent, scrq2, 
            //                          scrq, "提供方", tgf, "设备号", PrintHead.SBHMS, "数量"  , PrintHead.SL.ToString("0.##") + " " + PrintHead.UNITSNAME, "产品状态", PrintHead.CPZTNAME, "操作工", CzlList };

            //for (int i = 0; i < contentArr.Length; i++)
            //{
            //    int index = i % 2 == 0 ? 0 : 1;
            //    if (index == 0)
            //    {
            //        g.DrawString(contentArr[i], font7, bru, new Rectangle(width / 4 * index, rowmargin * 2 + 12 + rowmargin * (i / 2) - subWidth, width, rowmargin), strFormat1);
            //    }
            //    else
            //    {

            //        g.DrawString(contentArr[i], font7, bru, new Rectangle(width / 4 * index, rowmargin * 2 + 12 + rowmargin * (i / 2) - subWidth, width, rowmargin), strFormat1);

            //    }

            //}


            //for (int i = 0; i < PrintChild.Length; i++)
            //{
            //    g.DrawString("下层码: " + PrintChild[i].TM, font5, bru, 5, 11 * rowmargin + 15 + 55 * i - subWidth);
            //    g.DrawString("物料: " + PrintChild[i].WLMS + "/" + PrintChild[i].PC, font5, bru, 5, 11 * rowmargin + 30 + 55 * i - subWidth);
            //    string zlxxStr = "质量信息:";
            //    if (!string.IsNullOrEmpty(PrintChild[i].GYSMS))
            //    {
            //        zlxxStr += PrintChild[i].GYSMS;
            //    }
            //    if (!string.IsNullOrEmpty(PrintChild[i].SBHMS))
            //    {
            //        if (!string.IsNullOrEmpty(PrintChild[i].GYSMS))
            //        {
            //            zlxxStr += "/" + PrintChild[i].SBHMS;
            //        }
            //        else
            //        {
            //            zlxxStr += PrintChild[i].SBHMS;
            //        }
            //    }
            //    if (!string.IsNullOrEmpty(PrintChild[i].CLCJ))
            //    {
            //        if (!string.IsNullOrEmpty(PrintChild[i].GYSMS) || !string.IsNullOrEmpty(PrintChild[i].GYSMS))
            //        {
            //            zlxxStr += "/" + PrintChild[i].CLCJ;
            //        }
            //        else
            //        {
            //            zlxxStr += PrintChild[i].CLCJ;
            //        }
            //    }
            //    if (!string.IsNullOrEmpty(PrintChild[i].GYLX))
            //    {
            //        if (!string.IsNullOrEmpty(PrintChild[i].GYSMS) || !string.IsNullOrEmpty(PrintChild[i].GYSMS) || !string.IsNullOrEmpty(PrintChild[i].CLCJ))
            //        {
            //            zlxxStr += "/" + PrintChild[i].GYLX;
            //        }
            //        else
            //        {
            //            zlxxStr += PrintChild[i].GYLX;
            //        }
            //    }
            //    g.DrawString(zlxxStr, font5, bru, new Rectangle(5, 11 * rowmargin + 45 + 55 * i - subWidth, width, 30), strFormat2);
            //}
            //g.DrawString("备注:" + PrintHead.REMARK, font5, bru, 5, bzHeight - subWidth);
            //byte[] bytes = ServicModel.BarCode.CreateBarCode(PrintHead.TM, "QRCODE", 70, 70, 1);
            //MemoryStream ms = new MemoryStream(bytes);
            //Image returnImage = Image.FromStream(ms);
            //g.DrawImage(returnImage, 10, bzHeight + 15 - subWidth, 70, 70);
            //g.DrawString(PrintHead.TM, font7, bru, 10, bzHeight + 15 + 80 - subWidth);
            #endregion

        }
        private void DrawZJlot(PrintPageEventArgs e)
        {
            #region EPSON
            Pen blackPen = new Pen(Color.Black, 1);
            Font font22 = new Font(q(Msg_Type.fonttype), 22, FontStyle.Bold);
            Font font14 = new Font(q(Msg_Type.fonttype), 14, FontStyle.Bold);
            Font font18 = new Font(q(Msg_Type.fonttype), 18, FontStyle.Bold);
            Font font16 = new Font(q(Msg_Type.fonttype), 16, FontStyle.Bold);
            Font font13 = new Font(q(Msg_Type.fonttype), 13, FontStyle.Bold);
            Font font12 = new Font(q(Msg_Type.fonttype), 12, FontStyle.Bold);
            Font font15 = new Font(q(Msg_Type.fonttype), 15, FontStyle.Bold);
            Font font10 = new Font(q(Msg_Type.fonttype), 10, FontStyle.Bold);
            Font font8 = new Font(q(Msg_Type.fonttype), 8, FontStyle.Bold);
            Brush bru = Brushes.Black;
            Graphics g = e.Graphics;//画布
            StringFormat strFormat = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat.Alignment = StringAlignment.Center;//水平居中

            StringFormat strFormat1 = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat.Alignment = StringAlignment.Center;//水平居中
            int width = 272;
            int margin = 5;
            int hrowmargin = 20;
            int rowmargin = 18;
            int grid = width / 2;
            int bzHeight = 0;
            if (PrintChild != null)
            {
                bzHeight = 11 * rowmargin + 20 + PrintChild.Length * 45;
            }
            else
            {
                bzHeight = 11 * rowmargin + 20;
            }

            int subWidth = 15;
            Rectangle recHead = new Rectangle(margin, 0, width, hrowmargin);//矩形
            g.DrawString(PrintHead.GCDYMS, font13, bru, recHead, strFormat);

            g.DrawString(q(Msg_Type.printwllotb), font10, bru, margin + 95, hrowmargin + 10 - subWidth);//"物料LOT表"
            byte[] bytes = ServicModel.BarCode.CreateBarCode(PrintHead.TM, "QRCODE", 70, 70, 1);
            MemoryStream ms = new MemoryStream(bytes);
            Image returnImage = Image.FromStream(ms);

            //g.DrawImage(returnImage, margin + 95, hrowmargin + 10, 70, 70);
            //g.DrawString(PrintHead.TM, font5, bru, margin + 95, hrowmargin + 80);

            g.DrawImage(returnImage, margin + 95, hrowmargin + 10, 70, 70);
            g.DrawString(PrintHead.TM, font8, bru, margin + 95, hrowmargin + 80);
            string LotNo = string.IsNullOrEmpty(PrintHead.LOTNO) ? string.Format(q(Msg_Type.printbhformat), "JS4002A") : q(Msg_Type.printbh) + PrintHead.LOTNO;//"编号: JS4002A""编号: "
            g.DrawString(LotNo, font8, bru, margin, hrowmargin + 80);
            //g.DrawString("编号: JS5002A", font5, bru, margin, hrowmargin + 12 - subWidth);
            subWidth -= 80;
            string scrq = "";
            string scrq2 = q(Msg_Type.printscsj);//"生产时间";
            if (RigthType == Rigth_Type.zhengjicc)
            {
                scrq = Convert.ToDateTime(PrintHead.JLTIME).ToString("yy-MM-dd");
                //scrq = Convert.ToDateTime(PrintHead.SCDATEP).ToString("yy-MM-dd") + " " + scrq.Split(' ')[1];
                scrq = PrintHead.SCDATEP.Substring(2, PrintHead.SCDATEP.Length - 2) + " " + scrq.Split(' ')[1];
            }
            else if (RigthType == Rigth_Type.fujicc)
            {
                //scrq = Convert.ToDateTime(PrintHead.KSTIME).ToString("MM.dd HH:mm").ToString() + " - " + Convert.ToDateTime(PrintHead.JSTIME).ToString("MM.dd HH:mm").ToString();
            }
            else
            {
                //if (!string.IsNullOrEmpty(PrintHead.BCMS))
                //{
                //    scrq = PrintHead.SCDATE + "/" + PrintHead.BCMS;
                //}
                //else
                //{
                //    scrq = PrintHead.SCDATE;
                //}
                //scrq = PrintHead.SCDATE + "/" + PrintHead.BCMS;
            }
            string tgf = PrintHead.GZZXBH;
            if (!string.IsNullOrEmpty(PrintHead.GZZXMS))
            {
                tgf += "-" + PrintHead.GZZXMS;
            }
            string[] contentArr = {q(Msg_Type.printwlbm), PrintHead.WLH,q(Msg_Type.printwlms), PrintHead.WLMS, q(Msg_Type.printgcpc), PrintHead.PC, scrq2, 
                                      scrq,q(Msg_Type.printtgf) , tgf,q(Msg_Type.printsbh), PrintHead.SBHMS, q(Msg_Type.printsl)  , PrintHead.SL.ToString("0.##") + " " + PrintHead.UNITSNAME, q(Msg_Type.printcpzt), PrintHead.CPZTNAME, q(Msg_Type.printczg), CzlList };
            //string[] contentArr = { "物料编码", PrintHead.WLH, "物料描述", PrintHead.WLMS, "工厂批次", PrintHead.PC, scrq2, 
            //scrq, "提供方", tgf, "设备号", PrintHead.SBHMS, "数量"  , PrintHead.SL.ToString("0.##") + " " + PrintHead.UNITSNAME, "产品状态", PrintHead.CPZTNAME, "操作工", CzlList };

            for (int i = 0; i < 3; i++)
            {
                int empty1 = string.IsNullOrEmpty(PrintHead.SYCPGG) ? -15 : 0;
                if (i == 0)//左右直线
                {
                    g.DrawLine(blackPen, margin + grid * i, rowmargin * 2 + 10 - subWidth, grid * i + margin, bzHeight + 15 + 125 - subWidth + empty1);
                }
                else if (i == 1) //10行分割线
                {
                    g.DrawLine(blackPen, margin + width / 4, rowmargin * 2 + 10 - subWidth, width / 4 + margin, rowmargin * 11 + 10 - subWidth + 20);
                }
                else if (i == 2)
                {
                    g.DrawLine(blackPen, 5 + margin + grid * i, rowmargin * 2 + 10 - subWidth, grid * i + margin + 5, bzHeight + 15 + 125 - subWidth + empty1);
                }

            }
            for (int i = 0; i < contentArr.Length; i++)
            {
                int index = i % 2 == 0 ? 0 : 1;

                //int m = i > 11 ? 10 : 0;
                int m = 0;
                if (i > 11)
                {
                    m = 20;
                }
                else if (i > 7)
                {
                    m = 10;
                }
                if (index == 0)
                {
                    if (i == 10 || i == 6)
                    {
                        g.DrawString(contentArr[i], font10, bru, new Rectangle(margin + width / 4 * index, 6 + m + rowmargin * 2 + 12 + rowmargin * (i / 2) - subWidth, width, rowmargin), strFormat1);
                    }
                    else
                    {
                        g.DrawString(contentArr[i], font10, bru, new Rectangle(margin + width / 4 * index, m + rowmargin * 2 + 12 + rowmargin * (i / 2) - subWidth, width, rowmargin), strFormat1);
                    }



                }
                else
                {
                    if (i == 11)
                    {
                        g.DrawString(contentArr[i], font22, bru, new Rectangle(margin + width / 4 * index, m - 3 + rowmargin * 2 + 12 + rowmargin * (i / 2) - subWidth, width, rowmargin + 10), strFormat1);

                    }
                    else if (i == 7)
                    {
                        g.DrawString(contentArr[i], font16, bru, new Rectangle(margin + width / 4 * index, m + +rowmargin * 2 + 12 + rowmargin * (i / 2) - subWidth, width, rowmargin + 10), strFormat1);
                    }
                    else
                    {
                        g.DrawString(contentArr[i], font10, bru, new Rectangle(margin + width / 4 * index, m + rowmargin * 2 + 12 + rowmargin * (i / 2) - subWidth, width, rowmargin), strFormat1);
                    }



                }

            }
            for (int i = 0; i < 10; i++)
            {
                if (i == 6 || i == 4)
                {
                    g.DrawLine(blackPen, margin, rowmargin * (i + 2) + 10 - subWidth + 10, 5 + width + margin, rowmargin * (i + 2) + 10 - subWidth + 10);
                    subWidth -= 10;
                }
                else
                {
                    g.DrawLine(blackPen, margin, rowmargin * (i + 2) + 10 - subWidth, 5 + width + margin, rowmargin * (i + 2) + 10 - subWidth);
                }

            }




            //string[] subArr = { "备注", "桶号:" + PrintHead.TH, "配料单号:" + PrintHead.PLDH, "配方号:" + PrintHead.PFDH, "适用产品规格:" + PrintHead.SYCPGG, "适用生产线:" + PrintHead.SYSCX, "备注信息:" + PrintHead.REMARK };
            string[] subArr = { q(Msg_Type.printbz), q(Msg_Type.printth) + PrintHead.TH, q(Msg_Type.printpfh) + PrintHead.PFDH, q(Msg_Type.printpldh) + PrintHead.PLDH, q(Msg_Type.printsycpgg) + PrintHead.SYCPGG, q(Msg_Type.printbzxx) + PrintHead.REMARK };
            //string[] subArr = { "备注", "桶号:" + PrintHead.TH, "配方号:" + PrintHead.PFDH, "配料单号:" + PrintHead.PLDH, "适用产品规格:" + PrintHead.SYCPGG, "备注信息:" + PrintHead.REMARK };

            g.DrawString(subArr[0], font8, bru, margin + 10, 11 * rowmargin + 12 + 15 * 0 - subWidth);
            g.DrawString(subArr[1], font22, bru, margin + 5, 11 * rowmargin + 12 + 15 * 1 - subWidth);
            g.DrawString(subArr[2], font22, bru, margin + 5, 11 * rowmargin + 12 + 15 + 30 * 1 - subWidth);
            g.DrawString(subArr[3], font15, bru, margin + 8, 11 * rowmargin + 12 + 45 + 30 * 1 - subWidth);
            int empty = 0;
            if (!string.IsNullOrEmpty(PrintHead.SYCPGG))
            {
                g.DrawString(subArr[4], font8, bru, margin + 10, 11 * rowmargin + 15 + 80 + 15 * 1 - subWidth);
                empty = 15;

            }
            g.DrawString(subArr[5], font8, bru, margin + 10, 11 * rowmargin + 15 + 80 + 15 * 1 + empty - subWidth);

            empty = empty == 0 ? -15 : 0;
            //底下边框线
            g.DrawLine(blackPen, margin, bzHeight + 120 - subWidth + empty, 5 + margin + width, bzHeight + 120 - subWidth + empty);

            #endregion
            #region 佳博
            //Pen blackPen = new Pen(Color.Black, 1);
            //Font font22 = new Font(q(Msg_Type.fonttype), 22, FontStyle.Bold);
            //Font font14 = new Font(q(Msg_Type.fonttype), 14, FontStyle.Bold);
            //Font font13 = new Font(q(Msg_Type.fonttype), 13, FontStyle.Bold);
            //Font font9 = new Font(q(Msg_Type.fonttype), 12, FontStyle.Bold);
            //Font font9cu = new Font(q(Msg_Type.fonttype), 12,FontStyle.Bold);
            //Font font7 = new Font(q(Msg_Type.fonttype), 10, FontStyle.Bold);
            //Font font5 = new Font(q(Msg_Type.fonttype), 8, FontStyle.Bold);
            //Brush bru = Brushes.Black;
            //Graphics g = e.Graphics;//画布
            //StringFormat strFormat = new StringFormat();
            //strFormat.LineAlignment = StringAlignment.Center;//垂直居中
            //strFormat.Alignment = StringAlignment.Center;//水平居中

            //StringFormat strFormat1 = new StringFormat();
            //strFormat.LineAlignment = StringAlignment.Center;//垂直居中
            //strFormat.Alignment = StringAlignment.Center;//水平居中
            //int width = 272;
            //int xmargin = 5;
            //int hrowmargin = 20;
            //int rowmargin = 18;
            //int grid = width / 2;
            //int bzHeight = 0;
            //if (PrintChild != null)
            //{
            //    bzHeight = 11 * rowmargin + 20 + PrintChild.Length * 45;
            //}
            //else
            //{
            //    bzHeight = 11 * rowmargin + 20;
            //}

            //int subWidth = 15;
            //Rectangle recHead = new Rectangle(0, 0, width, hrowmargin);//矩形
            //g.DrawString(PrintHead.GCDYMS, font13, bru, recHead, strFormat);
            //g.DrawString("编号: JS4501A", font5, bru, 0, hrowmargin + 12 - subWidth);
            //g.DrawString("LOT表", font7, bru, 110, hrowmargin + 10 - subWidth);
            //for (int i = 0; i < 10; i++)
            //{
            //    g.DrawLine(blackPen, 0, rowmargin * (i + 2) + 10 - subWidth, width, rowmargin * (i + 2) + 10 - subWidth);
            //}
            //for (int i = 0; i < 3; i++)
            //{
            //    if (i != 1)
            //    {
            //        g.DrawLine(blackPen, grid * i, rowmargin * 2 + 10 - subWidth, grid * i, bzHeight + 110 - subWidth);
            //    }
            //    else
            //    {
            //        g.DrawLine(blackPen, width / 4, rowmargin * 2 + 10 - subWidth, width / 4, rowmargin * 11 + 10 - subWidth);
            //    }

            //}
            //g.DrawLine(blackPen, 0, bzHeight + 110 - subWidth, width, bzHeight + 110 - subWidth);
            //string scrq = "";
            //string scrq2 = "生产时间";
            //if (RigthType == Rigth_Type.zhengjicc)
            //{
            //    scrq = PrintHead.JLTIME;
            //}
            //else if (RigthType == Rigth_Type.fujicc)
            //{
            //    scrq = Convert.ToDateTime(PrintHead.KSTIME).ToString("MM.dd HH:mm").ToString() + " - " + Convert.ToDateTime(PrintHead.JSTIME).ToString("MM.dd HH:mm").ToString();
            //}
            //else
            //{
            //    if (!string.IsNullOrEmpty(PrintHead.BCMS))
            //    {
            //        scrq = PrintHead.SCDATE + "/" + PrintHead.BCMS;
            //    }
            //    else
            //    {
            //        scrq = PrintHead.SCDATE;
            //    }
            //    //scrq = PrintHead.SCDATE + "/" + PrintHead.BCMS;
            //}
            //string tgf = PrintHead.GZZXBH;
            //if (!string.IsNullOrEmpty(PrintHead.GZZXMS))
            //{
            //    tgf += "-" + PrintHead.GZZXMS;
            //}
            //string[] contentArr = { "物料编码", PrintHead.WLH, "物料描述", PrintHead.WLMS, "工厂批次", PrintHead.PC, scrq2, 
            //                          scrq, "提供方", tgf, "设备号", PrintHead.SBHMS, "数量"  , PrintHead.SL.ToString("0.##") + " " + PrintHead.UNITSNAME, "产品状态", PrintHead.CPZTNAME, "操作工", CzlList };

            //for (int i = 0; i < contentArr.Length; i++)
            //{
            //    int index = i % 2 == 0 ? 0 : 1;
            //    if (index == 0)
            //    {
            //        g.DrawString(contentArr[i], font7, bru, new Rectangle(width / 4 * index, rowmargin * 2 + 12 + rowmargin * (i / 2) - subWidth, width, rowmargin), strFormat1);
            //    }
            //    else
            //    {

            //        g.DrawString(contentArr[i], font7, bru, new Rectangle(width / 4 * index, rowmargin * 2 + 12 + rowmargin * (i / 2) - subWidth, width, rowmargin), strFormat1);


            //    }

            //}


            //string[] subArr = { "备注", "桶号:" + PrintHead.TH, "配料单号:" + PrintHead.PLDH, "配方号:" + PrintHead.PFDH, "适用产品规格" + PrintHead.SYCPGG, "适用生产线:" + PrintHead.SYSCX, "备注信息:" + PrintHead.REMARK };
            ////for (int i = 0; i < subArr.Length; i++)
            ////{
            ////    g.DrawString(subArr[i], font5, bru, 5, 11 * rowmargin + 15 + 15 * i);
            ////}
            //g.DrawString(subArr[0], font5, bru, 5, 11 * rowmargin + 12 + 15 * 0 - subWidth);
            //g.DrawString(subArr[1], font9cu, bru, 5, 11 * rowmargin + 12 + 15 * 1 - subWidth);
            //g.DrawString(subArr[2], font9cu, bru, 5, 11 * rowmargin + 12 + 15 * 2 - subWidth);
            //g.DrawString(subArr[3], font9cu, bru, 5, 11 * rowmargin + 12 + 15 * 3 - subWidth);
            //g.DrawString(subArr[4], font5, bru, 5, 11 * rowmargin + 15 + 15 * 4 - subWidth);
            //g.DrawString(subArr[5], font5, bru, 5, 11 * rowmargin + 15 + 15 * 5 - subWidth);
            //g.DrawString(subArr[6], font5, bru, 5, 11 * rowmargin + 15 + 15 * 6 - subWidth);
            //byte[] bytes = ServicModel.BarCode.CreateBarCode(PrintHead.TM, "QRCODE", 70, 70, 1);
            //MemoryStream ms = new MemoryStream(bytes);
            //Image returnImage = Image.FromStream(ms);

            //g.DrawImage(returnImage, 180, 11 * rowmargin + 25 - subWidth, 70, 70);
            //g.DrawString(PrintHead.TM, font7, bru, 180, 11 * rowmargin + 25 + 80 - subWidth);
            #endregion


        }
        private void DrawFujiLot(PrintPageEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 1);
            Font font22 = new Font(q(Msg_Type.fonttype), 22, FontStyle.Bold);
            Font font14 = new Font(q(Msg_Type.fonttype), 14, FontStyle.Bold);
            Font font13 = new Font(q(Msg_Type.fonttype), 13, FontStyle.Bold);
            Font font12 = new Font(q(Msg_Type.fonttype), 12, FontStyle.Bold);
            Font font16 = new Font(q(Msg_Type.fonttype), 16, FontStyle.Bold);
            Font font10 = new Font(q(Msg_Type.fonttype), 10, FontStyle.Bold);
            Font font8 = new Font(q(Msg_Type.fonttype), 8, FontStyle.Bold);
            Brush bru = Brushes.Black;
            Graphics g = e.Graphics;//画布
            StringFormat strFormat = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat.Alignment = StringAlignment.Near;//水平居中

            StringFormat strFormat1 = new StringFormat();
            StringFormat strFormat2 = new StringFormat();
            strFormat2.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat2.Alignment = StringAlignment.Center;//水平居中
            int width = 272 + 2;
            int margin = 5;
            int hrowmargin = 20;
            int rowmargin = 18;
            int grid = width / 2;
            int bzHeight = 0;
            //负极打印为正常格式不体现下层码 所以不需要下层*45
            //if (PrintChild != null)
            //{
            //    bzHeight = 11 * rowmargin + 20 + PrintChild.Length * 45;
            //}
            //else
            //{
            //    bzHeight = 11 * rowmargin + 20;
            //}
            bzHeight = 11 * rowmargin + 65;
            int subWidth = 0;
            Rectangle recHead = new Rectangle(margin, 0, width, hrowmargin);//矩形
            g.DrawString(PrintHead.GCDYMS, font13, bru, recHead, strFormat2);
            string LotNo = string.IsNullOrEmpty(PrintHead.LOTNO) ? string.Format(q(Msg_Type.printbh), "JS4002A") : q(Msg_Type.printbh) + PrintHead.LOTNO;// "编号: "
            g.DrawString(LotNo, font8, bru, margin, hrowmargin + 12 - subWidth);
            g.DrawString(q(Msg_Type.printwllotb), font10, bru, margin + 95, hrowmargin + 10 - subWidth);//"物料LOT表"
            for (int i = 0; i < 10; i++)
            {
                //g.DrawLine(blackPen, 0, rowmargin * (i + 2) + 10, width, rowmargin * (i + 2) + 10);
                if (i == 6)
                {
                    g.DrawLine(blackPen, margin, rowmargin * (i + 2) + 20 - subWidth, margin + width, rowmargin * (i + 2) + 20 - subWidth);
                }
                else if (i > 6)
                {
                    g.DrawLine(blackPen, margin, rowmargin * (i + 2) + 20 - subWidth, margin + width, rowmargin * (i + 2) + 20 - subWidth);
                }
                else
                {
                    g.DrawLine(blackPen, margin, rowmargin * (i + 2) + 10 - subWidth, margin + width, rowmargin * (i + 2) + 10 - subWidth);
                }

            }

            string scrq = "";
            string scrq2 = q(Msg_Type.printscsj);//"生产时间";
            scrq = Convert.ToDateTime(PrintHead.JSTIME).ToString("yyyy-MM-dd HH:mm");
            scrq = PrintHead.SCDATEP + " " + scrq.Split(' ')[1];


            string tgf = PrintHead.GZZXBH;
            if (!string.IsNullOrEmpty(PrintHead.GZZXMS))
            {
                tgf += "-" + PrintHead.GZZXMS;
            }
            string[] contentArr = {q(Msg_Type.printwlbm), PrintHead.WLH, q(Msg_Type.printwlms), PrintHead.WLMS, q(Msg_Type.printgcpc), PrintHead.PC, scrq2, 
                                      scrq, q(Msg_Type.printtgf), tgf,q(Msg_Type.printsbh), PrintHead.SBHMS, q(Msg_Type.printsl), PrintHead.SIZENAME + " " + PrintHead.UNITSNAME, q(Msg_Type.printcpzt), PrintHead.CPZTNAME, q(Msg_Type.printczg), CzlList };
            //string[] contentArr = { "物料编码", PrintHead.WLH, "物料描述", PrintHead.WLMS, "工厂批次", PrintHead.PC, scrq2, 
            //scrq, "提供方", tgf, "设备号", PrintHead.SBHMS, "数量"  , PrintHead.SIZENAME + " " + PrintHead.UNITSNAME, "产品状态", PrintHead.CPZTNAME, "操作工", CzlList };

            for (int i = 0; i < contentArr.Length; i++)
            {
                int index = i % 2 == 0 ? 0 : 1;
                if (index == 0)
                {


                    if (i > 9 && i != 10)
                    {
                        g.DrawString(contentArr[i], font10, bru, new Rectangle(margin + width / 4 * index, 10 + rowmargin * 2 + 12 + rowmargin * (i / 2) - subWidth, width, rowmargin), strFormat1);
                    }
                    else if (i == 10)
                    {
                        g.DrawString(contentArr[i], font10, bru, new Rectangle(margin + width / 4 * index, 5 + rowmargin * 2 + 12 + rowmargin * (i / 2) - subWidth, width, rowmargin), strFormat);
                    }
                    else
                    {
                        g.DrawString(contentArr[i], font10, bru, new Rectangle(margin + width / 4 * index, rowmargin * 2 + 12 + rowmargin * (i / 2) - subWidth, width, rowmargin), strFormat1);
                    }
                }
                else
                {
                    if (i > 10)
                    {
                        if (i == 7)
                        {
                            g.DrawString(contentArr[i], font12, bru, new Rectangle(margin + width / 4 * index, 10 + rowmargin * 2 + 12 + rowmargin * (i / 2) - subWidth, width, rowmargin), strFormat1);
                        }
                        else if (i == 11)
                        {
                            g.DrawString(contentArr[i], font16, bru, new Rectangle(margin + width / 4 * index, rowmargin * 2 + 12 + rowmargin * (i / 2) - subWidth, width, rowmargin + 3), strFormat1);
                        }
                        else
                        {
                            g.DrawString(contentArr[i], font10, bru, new Rectangle(margin + width / 4 * index, 10 + rowmargin * 2 + 12 + rowmargin * (i / 2) - subWidth, width, rowmargin), strFormat1);
                        }
                    }
                    else
                    {
                        if (i == 7)
                        {

                            g.DrawString(contentArr[i], font12, bru, new Rectangle(margin + width / 4 * index, rowmargin * 2 + 12 + rowmargin * (i / 2) - subWidth, width, rowmargin), strFormat1);
                        }
                        else if (i == 11)
                        {
                            g.DrawString(contentArr[i], font22, bru, new Rectangle(margin + width / 4 * index, rowmargin * 2 + 12 + rowmargin * (i / 2) - subWidth, width, rowmargin), strFormat1);
                        }
                        else
                        {
                            g.DrawString(contentArr[i], font10, bru, new Rectangle(margin + width / 4 * index, rowmargin * 2 + 12 + rowmargin * (i / 2) - subWidth, width, rowmargin), strFormat1);
                        }
                    }






                }

            }
            string[] subArr = { q(Msg_Type.printbz), q(Msg_Type.printth) + PrintHead.TH, q(Msg_Type.printpldh) + PrintHead.PLDH, q(Msg_Type.printpfh) + PrintHead.PFDH, q(Msg_Type.printsbz) + PrintHead.SBZ + " g/ml", q(Msg_Type.printbzxx) + PrintHead.REMARK };
            //string[] subArr = { "备注", "桶号:" + PrintHead.TH, "配料单号:" + PrintHead.PLDH, "配方号:" + PrintHead.PFDH, "视比重:" + PrintHead.SBZ + " g/ml", "备注信息:" + PrintHead.REMARK };
            //for (int i = 0; i < subArr.Length; i++)
            //{
            //    if (i == 2 || i == 3 || i == 1 )
            //    {
            //        g.DrawString(subArr[i], font7cu, bru,margin + 5, 11 * rowmargin + 25 + 22 * i - subWidth);
            //    }
            //    else
            //    {
            //        g.DrawString(subArr[i], font5, bru, margin + 5, 11 * rowmargin + 25 + 22 * i - subWidth);
            //    }

            //}

            //第1行
            g.DrawString(subArr[0], font8, bru, margin + 5, 11 * rowmargin + 25 + 22 * 0 - subWidth);
            //第2行
            g.DrawString(subArr[1], font13, bru, margin + 5, 11 * rowmargin + 20 + 22 * 1 - subWidth);
            //第3行
            g.DrawString(subArr[2], font13, bru, margin + 5, 11 * rowmargin + 20 + 22 * 2 - subWidth);
            //第4行
            g.DrawString(subArr[3], font13, bru, margin + 5, 11 * rowmargin + 20 + 22 * 3 - subWidth);
            //第5行
            g.DrawString(subArr[4], font13, bru, margin + 5, 11 * rowmargin + 20 + 22 * 4 - subWidth);
            //第6行
            g.DrawString(subArr[5], font13, bru, new Rectangle(margin + 5, 11 * rowmargin + 20 + 22 * 5 - subWidth, width, 40), strFormat1);



            byte[] bytes = ServicModel.BarCode.CreateBarCode(PrintHead.TM, "QRCODE", 70, 70, 1);
            MemoryStream ms = new MemoryStream(bytes);
            Image returnImage = Image.FromStream(ms);
            g.DrawImage(returnImage, margin + 180, 11 * rowmargin + 25 - subWidth, 70, 70);
            g.DrawString(PrintHead.TM, font8, bru, margin + 180, 11 * rowmargin + 25 + 70 - subWidth);
            for (int i = 0; i < 3; i++)
            {
                if (i != 1)
                {
                    //两侧线
                    g.DrawLine(blackPen, margin + grid * i, rowmargin * 2 + 10, margin + grid * i, bzHeight + 70 + 40);
                }
                else
                {
                    //10行中间分割线
                    g.DrawLine(blackPen, margin + width / 4, rowmargin * 2 + 10 - subWidth, margin + width / 4, rowmargin * 11 + 10 + 10 - subWidth);
                }

            }

            //底线
            g.DrawLine(blackPen, margin, bzHeight + 70 + 40, margin + width, bzHeight + 70 + 40);





            //this.Close();
        }
        private void DrawZFSD(PrintPageEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 1);
            Font font22 = new Font(q(Msg_Type.fonttype), 22);
            Font font14 = new Font(q(Msg_Type.fonttype), 14);
            Font font12 = new Font(q(Msg_Type.fonttype), 12);
            Font font10 = new Font(q(Msg_Type.fonttype), 10);
            Font font8 = new Font(q(Msg_Type.fonttype), 8);
            Font font7 = new Font(q(Msg_Type.fonttype), 7);
            Brush bru = Brushes.Black;
            Graphics g = e.Graphics;//画布
            StringFormat strFormat = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat.Alignment = StringAlignment.Center;//水平居中

            StringFormat strFormat1 = new StringFormat();
            strFormat1.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat1.Alignment = StringAlignment.Near;//水平居中
            int width = 827;
            //int height = 565;
            int xmargin = 5;
            int rowmargin = 30;
            int grid = width / 8;
            Rectangle recHead = new Rectangle(xmargin, 10, width - 10, rowmargin);//矩形
            Rectangle recHead1 = new Rectangle(xmargin, 10 + 25, width - 10, rowmargin);//矩形
            string a = PrintHead.GCDYMS;

            g.DrawString(PrintHead.GCDYMS, font22, bru, recHead, strFormat);

            byte[] bytes = ServicModel.BarCode.CreateBarCode(PrintHead.TM, "QRCODE", 70, 70, 1);
            MemoryStream ms = new MemoryStream(bytes);
            Image returnImage = Image.FromStream(ms);
            g.DrawImage(returnImage, width - 130, 10, 70, 70);
            g.DrawString(PrintHead.TM, font10, bru, width - 130, 90);

            //g.DrawString("物料信息:" + PrintHead.WLH + "-" + PrintHead.WLMS, font10, bru, 10, 60 + 30);
            //g.DrawString("编号:JS4717A", font10, bru, 10, 60 + 20 + 30);
            g.DrawString(q(Msg_Type.printwlxx) + PrintHead.WLH + "-" + PrintHead.WLMS, font10, bru, 10, 60 + 20 + 30);//"物料信息:"
            string LotNo = string.IsNullOrEmpty(PrintHead.LOTNO) ? string.Format(q(Msg_Type.printbhformat), "JS4717A") : q(Msg_Type.printbh) + PrintHead.LOTNO;
            g.DrawString(LotNo, font10, bru, 10, 60 + 30);

            g.DrawString(q(Msg_Type.printzfsdhzb), font10, bru, 827 / 2 - 80, 60);//"暂放素电汇总表"

            g.DrawString(PrintHead.PC, font10, bru, width - 120, 60 + 20 + 30);

            string date = Convert.ToDateTime(PrintHead.KSTIME).ToString("yyyy-MM-dd") + "至" + Convert.ToDateTime(PrintHead.JSTIME).ToString("yyyy-MM-dd");
            string[] contentArr = { q(Msg_Type.printscx), PrintHead.SBHMS, q(Msg_Type.printdcxh), PrintHead.DCXHMS + "/" + PrintHead.DCDJMS, q(Msg_Type.printzflb), PrintHead.ZFDCLBNAME, q(Msg_Type.printsdzsl), PrintHead.SL.ToString("0.##"), q(Msg_Type.printth), PrintHead.TH.ToString(), q(Msg_Type.printscsjd), date, q(Msg_Type.printcfts), PrintHead.CFTS.ToString(), q(Msg_Type.printrkrq), PrintHead.SCDATE };
            //string[] contentArr = { "生产线", PrintHead.SBHMS, "电池型号", PrintHead.DCXHMS + "/" + PrintHead.DCDJMS, "暂放类别", PrintHead.ZFDCLBNAME, "素电总数量", PrintHead.SL.ToString("0.##"), "幢号", PrintHead.TH.ToString(), "生产时间段", date, "存放天数", PrintHead.CFTS.ToString(), "入库日期", PrintHead.SCDATE };
            //生产线
            int w = 91;
            int w2 = 820;
            int row1h = 130;

            //第1行  第1单元格
            g.DrawRectangle(blackPen, 10 + 1, row1h + (0 / 8) * rowmargin, 60, rowmargin);
            g.DrawString(contentArr[0], font10, bru, 13 + w * 0, row1h + (1 / 8) * rowmargin + 10);
            //第2行  第1单元格
            g.DrawRectangle(blackPen, 10 + 1, row1h + rowmargin, 60, rowmargin);
            g.DrawString(contentArr[8], font10, bru, 13 + w * 0, row1h + (1 / 8) * rowmargin + rowmargin * 1 + 10);
            //第1行 第2单元格
            g.DrawRectangle(blackPen, 10 + 1 + 60 * 1, row1h + (0 / 8) * rowmargin, 60, rowmargin);
            g.DrawString(contentArr[1], font10, bru, 13 + 60 * 1, row1h + (1 / 8) * rowmargin + 10);
            //第2行 第2单元格
            g.DrawRectangle(blackPen, 10 + 1 + 60 * 1, row1h + (0 / 8) * rowmargin + rowmargin * 1, 60, rowmargin);
            g.DrawString(contentArr[9], font10, bru, 13 + 60 * 1, row1h + (1 / 8) * rowmargin + 10 + rowmargin * 1);
            //第1行  第3单元格
            g.DrawRectangle(blackPen, 10 + 1 + 60 * 2, row1h + (0 / 8) * rowmargin, 90, rowmargin);
            g.DrawString(contentArr[2], font10, bru, 13 + 60 * 2, row1h + (1 / 8) * rowmargin + 10);
            //第2行  第3单元格
            g.DrawRectangle(blackPen, 10 + 1 + 60 * 2, row1h + (0 / 8) * rowmargin + rowmargin, 90, rowmargin);
            g.DrawString(contentArr[10], font10, bru, 13 + 60 * 2, row1h + (1 / 8) * rowmargin + rowmargin + 10);
            //第1行  第4单元格
            g.DrawRectangle(blackPen, 10 + 1 + 60 * 2 + 90, row1h + (0 / 8) * rowmargin, 180, rowmargin);
            g.DrawString(contentArr[3], font10, bru, 13 + 60 * 2 + 90, row1h + (1 / 8) * rowmargin + 10);
            //第2行  第4单元格
            g.DrawRectangle(blackPen, 10 + 1 + 60 * 2 + 90, row1h + (0 / 8) * rowmargin + rowmargin, 180, rowmargin);
            g.DrawString(contentArr[11], font10, bru, 13 + 60 * 2 + 90, row1h + (1 / 8) * rowmargin + 10 + rowmargin);
            //第1行  第5单元格
            g.DrawRectangle(blackPen, 10 + 1 + 60 * 2 + 90 + 180, row1h + (0 / 8) * rowmargin, 90, rowmargin);
            g.DrawString(contentArr[4], font10, bru, 13 + 60 * 2 + 90 + 180, row1h + (1 / 8) * rowmargin + 10);
            //第2行  第5单元格
            g.DrawRectangle(blackPen, 10 + 1 + 60 * 2 + 90 + 180, row1h + (0 / 8) * rowmargin + rowmargin, 90, rowmargin);
            g.DrawString(contentArr[12], font10, bru, 13 + 60 * 2 + 90 + 180, row1h + (1 / 8) * rowmargin + 10 + rowmargin);
            //第1行  第6单元格
            g.DrawRectangle(blackPen, 10 + 1 + 60 * 2 + 90 + 180 + 90, row1h + (0 / 8) * rowmargin, 90, rowmargin);
            g.DrawString(contentArr[5], font10, bru, 13 + 60 * 2 + 90 + 180 + 90, row1h + (1 / 8) * rowmargin + 10);
            //第2行  第6单元格
            g.DrawRectangle(blackPen, 10 + 1 + 60 * 2 + 90 + 180 + 90, row1h + (0 / 8) * rowmargin + rowmargin, 90, rowmargin);
            g.DrawString(contentArr[13], font10, bru, 13 + 60 * 2 + 90 + 180 + 90, row1h + (1 / 8) * rowmargin + 10 + rowmargin);
            //第1行  第7单元格
            g.DrawRectangle(blackPen, 10 + 1 + 60 * 2 + 90 + 180 + 90 + 90, row1h + (0 / 8) * rowmargin, 90, rowmargin);
            g.DrawString(contentArr[6], font10, bru, 13 + 60 * 2 + 90 + 180 + 90 + 90, row1h + (1 / 8) * rowmargin + 10);
            //第2行  第7单元格
            g.DrawRectangle(blackPen, 10 + 1 + 60 * 2 + 90 + 180 + 90 + 90, row1h + (0 / 8) * rowmargin + rowmargin, 90, rowmargin);
            g.DrawString(contentArr[14], font10, bru, 13 + 60 * 2 + 90 + 180 + 90 + 90, row1h + (1 / 8) * rowmargin + 10 + rowmargin);
            //第1行  第8单元格
            g.DrawRectangle(blackPen, 10 + 1 + 60 * 2 + 90 + 180 + 90 + 90 + 90, row1h + (0 / 8) * rowmargin, 120, rowmargin);
            g.DrawString(contentArr[7], font10, bru, 13 + 60 * 2 + 90 + 180 + 90 + 90 + 90, row1h + (1 / 8) * rowmargin + 10);
            //第2行  第8单元格
            g.DrawRectangle(blackPen, 10 + 1 + 60 * 2 + 90 + 180 + 90 + 90 + 90, row1h + (0 / 8) * rowmargin + rowmargin, 120, rowmargin);
            g.DrawString(contentArr[15], font10, bru, 13 + 60 * 2 + 90 + 180 + 90 + 90 + 90, row1h + (1 / 8) * rowmargin + 10 + rowmargin);
            for (int i = 0; i < 36; i++)
            {
                int index = i % 4;
                if (index == 0 || index == 2)
                {
                    //g.DrawString(contentArr[9], font9, bru, new Rectangle(grid * 3, 3 + rowmargin * 3, grid * 3, rowmargin), strFormat1);
                    index = index == 0 ? 0 : 1;
                    if (index == 0)
                    {
                        g.DrawRectangle(blackPen, 1 + 10, row1h + rowmargin * 2 + i / 4 * rowmargin, 210, rowmargin);
                    }
                    else
                    {
                        g.DrawRectangle(blackPen, 1 + 5 + index * 395, row1h + rowmargin * 2 + i / 4 * rowmargin, 210, rowmargin);
                    }

                    if (i == 0)
                    {
                        g.DrawString(q(Msg_Type.printscrq), font10, bru, new Rectangle(1 + w2 * index / 2, row1h + rowmargin * 2 + i / 4 * rowmargin, w2 * 3 / 10, rowmargin), strFormat);
                    }
                    else if (i == 2)
                    {
                        g.DrawString(q(Msg_Type.printscrq), font10, bru, new Rectangle(380, row1h + rowmargin * 2 + i / 4 * rowmargin, w2 * 3 / 10, rowmargin), strFormat);
                    }
                    else
                    {
                    }
                }
                else
                {
                    index = index == 1 ? 0 : 1;
                    if (index == 0)
                    {
                        g.DrawRectangle(blackPen, 220 + 1, row1h + rowmargin * 2 + i / 4 * rowmargin, 180, rowmargin);
                    }
                    else
                    {
                        g.DrawRectangle(blackPen, 220 + 1 + 390, row1h + rowmargin * 2 + i / 4 * rowmargin, 180, rowmargin);
                    }

                    if (i == 1)
                    {
                        g.DrawString(q(Msg_Type.printsdslj), font10, bru, new Rectangle(220 + 1, row1h + rowmargin * 2 + i / 4 * rowmargin, w2 * 2 / 10, rowmargin), strFormat);
                    }
                    else if (i == 3)
                    {
                        g.DrawString(q(Msg_Type.printsdslj), font10, bru, new Rectangle(220 + 1 + 400, row1h + rowmargin * 2 + i / 4 * rowmargin, w2 * 2 / 10, rowmargin), strFormat);
                    }
                    else
                    {

                    }

                }
            }
            for (int i = 0; i < PrintChildMX.Length; i++)
            {
                int index = i % 8;
                string contentStr = Convert.ToDateTime(PrintChildMX[i].KSTIME).ToString("yyyy-MM-dd") + " 至 " + Convert.ToDateTime(PrintChildMX[i].JSTIME).ToString("yyyy-MM-dd");

                g.DrawString(contentStr, font10, bru, new Rectangle(-10 + (i / 8) * 395, row1h + rowmargin * 3 + index * rowmargin, w2 * 3 / 10, rowmargin), strFormat);
                g.DrawString(PrintChildMX[i].SL.ToString(), font10, bru, new Rectangle((i / 8) * 395 + 220, row1h + rowmargin * 3 + index * rowmargin, w2 * 2 / 10, rowmargin), strFormat);

            }





            g.DrawRectangle(blackPen, 1 + 10, row1h + rowmargin * 11, 210, rowmargin);
            g.DrawString(q(Msg_Type.printsdyt), font10, bru, new Rectangle(1 + 10, row1h + rowmargin * 11, w2 * 3 / 10, rowmargin), strFormat1);
            g.DrawRectangle(blackPen, 210 + 1 + 10, row1h + rowmargin * 11, 390, rowmargin);
            g.DrawString(q(Msg_Type.printtdrq), font10, bru, new Rectangle(1 + 230 - 10, row1h + rowmargin * 11, w2 * 5 / 10, rowmargin), strFormat1);
            g.DrawRectangle(blackPen, 210 + 1 + 10 + 390, row1h + rowmargin * 11, 180, rowmargin);
            g.DrawString(q(Msg_Type.printjyyqr), font10, bru, new Rectangle(1 + 230 + 390 - 10, row1h + rowmargin * 11, w2 * 2 / 10 - 50, rowmargin), strFormat1);
            g.DrawRectangle(blackPen, 1 + 10, row1h + rowmargin * 12, 210 + 10 + 390 + 170, 55);
            g.DrawString(q(Msg_Type.printbz) + PrintHead.REMARK, font10, bru, new Rectangle(1 + 10, row1h + rowmargin * 12, 210 + 1 + 10 + 390 + 180, 55), strFormat1);




        }
        private void DrawWLRKLOT(PrintPageEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 1);
            Font font22 = new Font(q(Msg_Type.fonttype), 22, FontStyle.Bold);
            Font font20 = new Font(q(Msg_Type.fonttype), 20, FontStyle.Bold);
            Font font14 = new Font(q(Msg_Type.fonttype), 14, FontStyle.Bold);
            Font font13 = new Font(q(Msg_Type.fonttype), 13, FontStyle.Bold);
            Font font9 = new Font(q(Msg_Type.fonttype), 12, FontStyle.Bold);
            Font font7 = new Font(q(Msg_Type.fonttype), 10, FontStyle.Bold);
            Font font8 = new Font(q(Msg_Type.fonttype), 8, FontStyle.Bold);
            Brush bru = Brushes.Black;
            Graphics g = e.Graphics;//画布
            StringFormat centerFormat = new StringFormat();
            centerFormat.LineAlignment = StringAlignment.Center;//垂直居中
            centerFormat.Alignment = StringAlignment.Center;//水平居中
            StringFormat defalutFormat = new StringFormat();
            defalutFormat.LineAlignment = StringAlignment.Center;//垂直居中
            defalutFormat.Alignment = StringAlignment.Near;//水平居中
            int width = 273;
            int leftWidth = 91 - 23;
            int rigthWidth = 182 + 23;
            int hrowmargin = 20;
            int margin = 5;
            Rectangle recHead = new Rectangle(0, 0, width, hrowmargin);//矩形
            g.DrawString(PrintHead.GCDYMS, font13, bru, recHead, centerFormat);
            //g.DrawString("LOT表", font7, bru, 110, hrowmargin + 15);
            //g.DrawString("编号: JS4501A", font5, bru, margin, hrowmargin + 15);
            g.DrawString(q(Msg_Type.printtbsspace), font8, bru, margin + 97, hrowmargin);

            byte[] bytes = ServicModel.BarCode.CreateBarCode(PrintHead.TM, "QRCODE", 70, 70, 1);
            MemoryStream ms = new MemoryStream(bytes);
            Image returnImage = Image.FromStream(ms);
            g.DrawImage(returnImage, 100, hrowmargin + 10, 70, 70);
            g.DrawString(PrintHead.TM, font8, bru, 100, hrowmargin + 80);

            //g.DrawString("托号:" + TuoHao.ToString(), font14, bru, new Rectangle(205, hrowmargin + 70, rigthWidth, 25), defalutFormat);
            g.DrawString(q(Msg_Type.printtuohao) + PrintHead.TH.ToString(), font14, bru, new Rectangle(205, hrowmargin + 70, rigthWidth, 25), defalutFormat);


            int defaultrow = 2;
            //标题
            string[] headlineArr = { q(Msg_Type.printwlbm), q(Msg_Type.printwlms), q(Msg_Type.printgcpc), q(Msg_Type.printzydh), q(Msg_Type.printrkrq), q(Msg_Type.printtgf), q(Msg_Type.printsl), q(Msg_Type.printckdjno) };
            //string[] headlineArr = { "物料编码", "物料描述", "工厂批次", "作业单号", "入库日期", "提供方", "数量", "参考单据" };
            string zydh = "";
            if (!string.IsNullOrEmpty(PrintHead.NOBILL))
            {
                zydh = PrintHead.NOBILL + "-" + PrintHead.NOBILLMX;
            }
            string sl = "";
            if (!string.IsNullOrEmpty(PrintHead.SL.ToString()) && PrintHead.SL != 0)
            {
                sl = PrintHead.SL.ToString("0.##") + " " + PrintHead.UNITSNAME;
            }
            else
            {

            }
            int defaultHeight = 65;
            int subK = 10;
            int subZ = 12;
            string tgf = PrintHead.GYSMS;
            //if (!string.IsNullOrEmpty(PrintHead.GYSMS))
            //{
            //    tgf += "-" + PrintHead.GYSMS;
            //}
            //标题对应内容
            string ckdj = "";// +PrintHead.WLPZBH + "/" + PrintHead.WLPZH + "(" + PrintHead.WLPZND + ")";
            if (!string.IsNullOrEmpty(PrintHead.WLPZBH))
            {
                ckdj += PrintHead.WLPZBH + "/" + PrintHead.WLPZH + "(" + PrintHead.WLPZND + ")";
                if (!string.IsNullOrEmpty(PrintHead.CGBILL))
                {
                    ckdj += "-" + PrintHead.CGBILL + "/" + PrintHead.CGBILLMX;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(PrintHead.CGBILL))
                {
                    ckdj += PrintHead.CGBILL + "/" + PrintHead.CGBILLMX;
                }
            }



            string[] contentArr = { PrintHead.WLH, PrintHead.WLMS, PrintHead.PC, zydh, PrintHead.SCDATE, tgf, sl, ckdj };
            //第一行
            g.DrawRectangle(blackPen, new Rectangle(margin, hrowmargin * defaultrow + subK + defaultHeight, leftWidth, 20));
            g.DrawRectangle(blackPen, new Rectangle(margin + leftWidth, hrowmargin * defaultrow + subK + defaultHeight, rigthWidth, 20));
            g.DrawString(headlineArr[defaultrow - 2], font7, bru, new Rectangle(margin, hrowmargin * defaultrow + subZ + defaultHeight, leftWidth, 20), defalutFormat);
            g.DrawString(contentArr[defaultrow - 2], font7, bru, new Rectangle(margin + leftWidth, hrowmargin * defaultrow + subZ + defaultHeight, rigthWidth, 20), defalutFormat);
            defaultrow++;
            //第二行
            g.DrawRectangle(blackPen, new Rectangle(margin, hrowmargin * defaultrow + subK + defaultHeight, leftWidth, 20));
            g.DrawRectangle(blackPen, new Rectangle(margin + leftWidth, hrowmargin * defaultrow + subK + defaultHeight, rigthWidth, 20));
            g.DrawString(headlineArr[defaultrow - 2], font7, bru, new Rectangle(margin, hrowmargin * defaultrow + subZ + defaultHeight, leftWidth, 20), defalutFormat);

            g.DrawString(contentArr[defaultrow - 2], font8, bru, new Rectangle(margin + leftWidth, hrowmargin * defaultrow + subZ + defaultHeight, rigthWidth, 20), defalutFormat);
            defaultrow++;
            //第三行
            g.DrawRectangle(blackPen, new Rectangle(margin, hrowmargin * defaultrow + subK + defaultHeight, leftWidth, 30));
            g.DrawRectangle(blackPen, new Rectangle(margin + leftWidth, hrowmargin * defaultrow + subK + defaultHeight, rigthWidth, 30));
            g.DrawString(headlineArr[defaultrow - 2], font7, bru, new Rectangle(margin, hrowmargin * defaultrow + subZ + defaultHeight, leftWidth, 30), defalutFormat);
            g.DrawString(contentArr[defaultrow - 2], font22, bru, new Rectangle(margin + leftWidth, hrowmargin * defaultrow + subZ + defaultHeight, rigthWidth, 30), defalutFormat);
            defaultrow++;
            subK += 10;
            subZ += 10;
            //第四行
            g.DrawRectangle(blackPen, new Rectangle(margin, hrowmargin * defaultrow + subK + defaultHeight, leftWidth, 20));
            g.DrawRectangle(blackPen, new Rectangle(margin + leftWidth, hrowmargin * defaultrow + subK + defaultHeight, rigthWidth, 20));
            g.DrawString(headlineArr[defaultrow - 2], font7, bru, new Rectangle(margin, hrowmargin * defaultrow + subZ + defaultHeight, leftWidth, 20), defalutFormat);
            g.DrawString(contentArr[defaultrow - 2], font7, bru, new Rectangle(margin + leftWidth, hrowmargin * defaultrow + subZ + defaultHeight, rigthWidth, 20), defalutFormat);
            defaultrow++;
            //第五行
            g.DrawRectangle(blackPen, new Rectangle(margin, hrowmargin * defaultrow + subK + defaultHeight, leftWidth, 20));
            g.DrawRectangle(blackPen, new Rectangle(margin + leftWidth, hrowmargin * defaultrow + subK + defaultHeight, rigthWidth, 20));
            g.DrawString(headlineArr[defaultrow - 2], font7, bru, new Rectangle(margin, hrowmargin * defaultrow + subZ + defaultHeight, leftWidth, 20), defalutFormat);
            g.DrawString(contentArr[defaultrow - 2], font13, bru, new Rectangle(margin + leftWidth, hrowmargin * defaultrow + subZ + defaultHeight, rigthWidth, 20), defalutFormat);
            defaultrow++;
            //第六行
            g.DrawRectangle(blackPen, new Rectangle(margin, hrowmargin * defaultrow + subK + defaultHeight, leftWidth, 30));
            g.DrawRectangle(blackPen, new Rectangle(margin + leftWidth, hrowmargin * defaultrow + subK + defaultHeight, rigthWidth, 30));
            g.DrawString(headlineArr[defaultrow - 2], font7, bru, new Rectangle(margin, hrowmargin * defaultrow + subZ + defaultHeight, leftWidth, 30), defalutFormat);
            g.DrawString(contentArr[defaultrow - 2], font20, bru, new Rectangle(margin + leftWidth, hrowmargin * defaultrow + subZ + defaultHeight + 2, rigthWidth, 30), defalutFormat);
            defaultrow++;
            subK += 10;
            subZ += 10;
            //第七行
            g.DrawRectangle(blackPen, new Rectangle(margin, hrowmargin * defaultrow + subK + defaultHeight, leftWidth, 20));
            g.DrawRectangle(blackPen, new Rectangle(margin + leftWidth, hrowmargin * defaultrow + subK + defaultHeight, rigthWidth, 20));
            g.DrawRectangle(blackPen, new Rectangle(margin + leftWidth + 100, hrowmargin * defaultrow + subK + defaultHeight, rigthWidth - 100, 20));
            g.DrawString(headlineArr[defaultrow - 2], font7, bru, new Rectangle(margin, hrowmargin * defaultrow + subZ + defaultHeight, leftWidth, 20), defalutFormat);
            if (Xs.Equals("0"))
            {
                Xs = "";
            }
            g.DrawString(q(Msg_Type.printxs) + Xs, font7, bru, new Rectangle(margin + leftWidth + 100, 3 + hrowmargin * defaultrow + subK + defaultHeight, rigthWidth - 100, 20));
            g.DrawString(contentArr[defaultrow - 2], font7, bru, new Rectangle(margin + leftWidth, hrowmargin * defaultrow + subZ + defaultHeight, rigthWidth, 20), defalutFormat);
            defaultrow++;
            //第八行
            g.DrawRectangle(blackPen, new Rectangle(margin, hrowmargin * defaultrow + subK + defaultHeight, leftWidth, 20));
            g.DrawRectangle(blackPen, new Rectangle(margin + leftWidth, hrowmargin * defaultrow + subK + defaultHeight, rigthWidth, 20));
            g.DrawString(headlineArr[defaultrow - 2], font7, bru, new Rectangle(margin, hrowmargin * defaultrow + subZ + defaultHeight, leftWidth, 20), defalutFormat);

            g.DrawString(contentArr[defaultrow - 2], font8, bru, new Rectangle(margin + leftWidth, hrowmargin * defaultrow + subZ + defaultHeight, rigthWidth, 20), defalutFormat);
            defaultrow++;
            //第九行
            g.DrawString(q(Msg_Type.printbz), font7, bru, new Rectangle(margin, hrowmargin * defaultrow + subZ + defaultHeight, leftWidth, 20), defalutFormat);
            List<string> zlArr = new List<string>();
            if (!string.IsNullOrEmpty(PrintHead.SBHMS))
            {
                zlArr.Add(q(Msg_Type.printsbh) + PrintHead.SBHMS);
                //Graphics g1 = e.Graphics;
                //SizeF z = g.MeasureString("设备号:", font5);
                //273
                //SizeF z1 = g.MeasureString(PrintHead.SBHMS, font22);
            }
            if (!string.IsNullOrEmpty(PrintHead.CLCJ))
            {
                zlArr.Add(q(Msg_Type.printclcj) + PrintHead.CLCJ);//"材料厂家:"
            }
            if (!string.IsNullOrEmpty(PrintHead.GYLX))
            {
                zlArr.Add(q(Msg_Type.printgylx) + PrintHead.GYLX);//"工艺路线:"
            }
            if (!string.IsNullOrEmpty(PrintHead.GYSPC))
            {
                zlArr.Add(q(Msg_Type.printgyspc) + PrintHead.GYSPC);//"供应商批次:"
            }
            if (!string.IsNullOrEmpty(PrintHead.REMARK))
            {
                zlArr.Add(q(Msg_Type.printbzxx) + PrintHead.REMARK);//"备注信息:" 
            }
            int dzgd = 0;
            int font22height = 38;
            int font9height = 21;
            int font8height = 14;
            int ksheight = hrowmargin * defaultrow + subZ + defaultHeight + 20;//备注以下开始计算高度
            int originksheight = ksheight;//
            int BZcount = 0;
            for (int i = 0; i < zlArr.Count; i++)
            {
                if (zlArr[i].StartsWith(q(Msg_Type.printsbh)))//"设备号:"
                {
                    SizeF z = g.MeasureString(zlArr[i], font22);
                    int lines = (int)Math.Ceiling(z.Width / (width - margin));

                    //g.DrawString("设备号:", font9, bru, margin, hrowmargin * (defaultrow + i + 1) + 5 + subK + defaultHeight);
                    g.DrawString(zlArr[i], font22, bru, new Rectangle(margin, ksheight, width - margin, font22height * lines));
                    ksheight += font22height * lines;
                    //g.DrawString(zlArr[i].Substring(4, zlArr[i].Length - 4), font22, bru, margin + 70, hrowmargin * (defaultrow + i + 1) + subK + defaultHeight);
                    //subK += 10;

                }
                else
                {

                    SizeF z = g.MeasureString(zlArr[i], font9);
                    int lines = (int)Math.Ceiling(z.Width / (width - margin));
                    g.DrawString(zlArr[i], font9, bru, new Rectangle(margin, ksheight, width - margin, font9height * lines));
                    ksheight += font9height * lines;
                    BZcount += lines;
                }

            }
            for (int i = 0; i < PrintChild.Length; i++)
            {
                Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_LIST data = PrintChild[i];
                g.DrawString(q(Msg_Type.printxctmxx), font8, bru, margin, ksheight); ksheight += font8height;
                string wlxx = q(Msg_Type.printwl) + PrintChild[i].TM + "/" + PrintChild[i].WLMS + "/" + PrintChild[i].PC;
                SizeF z1 = g.MeasureString(wlxx, font8);
                int lines1 = (int)Math.Ceiling(z1.Width / (width - margin));
                g.DrawString(q(Msg_Type.printwl) + PrintChild[i].TM + "/" + PrintChild[i].WLMS + "/" + PrintChild[i].PC, font8, bru, new Rectangle(margin, ksheight, width - margin, font8height * lines1)); ksheight += font8height * lines1;
                //new Rectangle(margin + leftWidth, hrowmargin * defaultrow + 20 + 7, rigthWidth, 20), defalutFormat);
                string xczlxx = q(Msg_Type.printzlxx);// "质量信息:";
                if (!string.IsNullOrEmpty(data.SBHMS))
                {
                    xczlxx += data.SBHMS + "/";
                }
                if (!string.IsNullOrEmpty(data.CLCJ))
                {
                    xczlxx += data.CLCJ + "/";
                }
                if (!string.IsNullOrEmpty(data.GYLX))
                {
                    xczlxx += data.GYLX + "/";
                }
                if (!string.IsNullOrEmpty(data.SBHMS) || !string.IsNullOrEmpty(data.CLCJ) || !string.IsNullOrEmpty(data.GYLX))
                {
                    xczlxx = xczlxx.Substring(0, xczlxx.Length - 1);
                }
                if (string.IsNullOrEmpty(data.SBHMS) && string.IsNullOrEmpty(data.CLCJ) && string.IsNullOrEmpty(data.GYLX))
                {
                    xczlxx = "";
                }

                //if (zlArr[i].Length  > 0)
                //{
                SizeF z = g.MeasureString(xczlxx, font8);
                int lines = (int)Math.Ceiling(z.Width / (width - margin));
                //}

                //g.DrawString(xczlxx, font8, bru, new Rectangle(margin, ksheight, width - margin, font8height * lines)); ksheight += FontHeight * 2 + lines * font8height;
                g.DrawString(xczlxx, font8, bru, new Rectangle(margin, ksheight, width - margin, font8height * lines)); ksheight += (int)z1.Height + (int)z.Height;

            }





            //List<string> zlArr = new List<string>();
            //if (!string.IsNullOrEmpty(PrintHead.SBHMS))
            //{
            //    zlArr.Add("设备号:" + PrintHead.SBHMS);
            //    //Graphics g1 = e.Graphics;
            //    //SizeF z = g.MeasureString("设备号:", font5);
            //    //273
            //    //SizeF z1 = g.MeasureString(PrintHead.SBHMS, font22);
            //}
            //if (!string.IsNullOrEmpty(PrintHead.CLCJ))
            //{
            //    zlArr.Add("材料厂家:" + PrintHead.CLCJ);
            //}
            //if (!string.IsNullOrEmpty(PrintHead.GYLX))
            //{
            //    zlArr.Add("工艺路线:" + PrintHead.GYLX);
            //}
            //if (!string.IsNullOrEmpty(PrintHead.GYSPC))
            //{
            //    zlArr.Add("供应商批次:" + PrintHead.GYSPC);
            //}
            //if (!string.IsNullOrEmpty(PrintHead.REMARK))
            //{
            //    zlArr.Add("备注信息:" + PrintHead.REMARK);
            //}
            //bool isSBH = false;
            //int lines = 0;
            //for (int i = 0; i < zlArr.Count; i++)
            //{
            //    if (zlArr[i].StartsWith("设备号:"))
            //    {
            //        string sbhStr = "设备号: " + zlArr[i].Substring(4, zlArr[i].Length - 4);
            //        SizeF z = g.MeasureString(sbhStr, font22);
            //        //int c = defaultHeight;
            //        lines = (int)Math.Ceiling(z.Width / (width - margin));       
            //        g.DrawString("设备号:", font9, bru, margin, hrowmargin * (defaultrow + i + 1) + 5 + subK + defaultHeight);
            //        g.DrawString(zlArr[i].Substring(4, zlArr[i].Length - 4), font22, bru, margin + 70, hrowmargin * (defaultrow + i + 1) + subK + defaultHeight);
            //        subK += 10;
            //        isSBH = true;
            //    }
            //    else
            //    {
            //        g.DrawString(zlArr[i], font9, bru, margin, hrowmargin * (defaultrow + i + 1) + subK + defaultHeight);
            //    }

            //}



            //int sbhheight = isSBH ? 30 : 0;
            //int blankHeight = zlArr.Count == 0 ? 30 : 0;

            ////int a = hrowmargin * defaultrow + subK + defaultHeight - 10;
            ////int b = 20 + zlArr.Count * hrowmargin + PrintChild.Length * 60 + sbhheight + blankHeight;

            int lastrect = ksheight - originksheight + 20;

            g.DrawRectangle(blackPen, new Rectangle(margin, hrowmargin * defaultrow + 40 + defaultHeight - 10, width, lastrect == 0 ? 20 : lastrect));


        }
        private void Drawbblot(PrintPageEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 1);
            Font font22 = new Font(q(Msg_Type.fonttype), 22, FontStyle.Bold);
            Font font14 = new Font(q(Msg_Type.fonttype), 14, FontStyle.Bold);
            Font font13 = new Font(q(Msg_Type.fonttype), 13, FontStyle.Bold);
            Font font12 = new Font(q(Msg_Type.fonttype), 12, FontStyle.Bold);
            Font font10 = new Font(q(Msg_Type.fonttype), 10, FontStyle.Bold);
            Font font8 = new Font(q(Msg_Type.fonttype), 8, FontStyle.Bold);
            Brush bru = Brushes.Black;
            Graphics g = e.Graphics;//画布
            StringFormat strFormat = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat.Alignment = StringAlignment.Center;//水平居中

            StringFormat strFormat1 = new StringFormat();
            strFormat1.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat1.Alignment = StringAlignment.Near;//水平居中
            StringFormat strFormat2 = new StringFormat();
            strFormat2.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat2.Alignment = StringAlignment.Far;//水平居中
            int width = 272;
            int margin = 8;
            int hrowmargin = 20;
            int rowmargin = 18;
            int grid = width / 3;
            int grid1 = width / 4;

            int subWidth = -55;
            Rectangle recHead = new Rectangle(margin, 0, width, hrowmargin);//矩形
            g.DrawString(PrintHead.GCDYMS, font13, bru, recHead, strFormat);

            g.DrawString(q(Msg_Type.printsbjlotb), font10, bru, margin + 95, 10 + hrowmargin + 10 - 15);
            string LotNo = string.IsNullOrEmpty(PrintHead.LOTNO) ? string.Format(q(Msg_Type.printbhformat), "JS4003A") : q(Msg_Type.printbh) + PrintHead.LOTNO;
            g.DrawString(LotNo, font8, bru, margin, 110);
            //g.DrawString("车号:" + PrintHead.SBHMS, font5, bru, margin + 220,110);
            g.DrawString(q(Msg_Type.printch) + PrintHead.SBHMS, font8, bru, new Rectangle(margin + 170, 110, width - 170 - margin + 5, 15), strFormat2);
            byte[] bytes = ServicModel.BarCode.CreateBarCode(PrintHead.TM, "QRCODE", 70, 70, 1);
            MemoryStream ms = new MemoryStream(bytes);
            Image returnImage = Image.FromStream(ms);
            //二维码
            g.DrawImage(returnImage, 110, 40, 70, 70);
            g.DrawString(PrintHead.TM, font8, bru, 110, 70 + 40);


            string slstr = PrintHead.DCSLBS.ToString() + "X" + PrintHead.DCSLMBSL.ToString();
            int sl = PrintHead.DCSLBS * PrintHead.DCSLMBSL;
            if (PrintHead.DCSLYS != 0)
            {
                if (sl != 0)
                {
                    sl = sl + PrintHead.DCSLYS;
                    slstr += "+" + PrintHead.DCSLYS + "=" + sl.ToString();
                }
                else
                {
                    slstr = PrintHead.DCSLYS.ToString();
                }

            }
            else
            {
                slstr += "=" + sl.ToString();
            }
            string wlss = "";
            if (string.IsNullOrEmpty(PrintHead.NOBILL))
            {
                wlss = PrintHead.PC;
            }
            else
            {
                wlss = PrintHead.NOBILL + "-" + PrintHead.NOBILLMX + "/" + PrintHead.PC;
            }
            string tgf = PrintHead.GZZXBH;
            if (!string.IsNullOrEmpty(PrintHead.GZZXMS))
            {
                tgf += "-" + PrintHead.GZZXMS;
            }
            bool isY = PrintHead.REMARK.Contains(q(Msg_Type.printyps));//"样品数"
            if (isY)
            {
                int ypdIndex = PrintHead.REMARK.IndexOf(q(Msg_Type.printyps));
                string ypdStr = PrintHead.REMARK.Substring(ypdIndex, PrintHead.REMARK.Length - ypdIndex);
                if (ypdStr.Contains("]"))
                {
                    int resIndex = ypdStr.IndexOf("]");
                    if (resIndex > 0)
                    {
                        slstr += "[" + ypdStr.Substring(0, resIndex) + "]";
                    }
                }
            }
            string scdate = PrintHead.SCDATEP;

            string[] contentArr = { q(Msg_Type.printwlbm), PrintHead.WLH, q(Msg_Type.printwlms), PrintHead.WLMS, q(Msg_Type.printwlsx), wlss, q(Msg_Type.printtgf), tgf, q(Msg_Type.printddsl),
                                    PrintHead.GDSL.ToString("0.##"), q(Msg_Type.printscrq), scdate, q(Msg_Type.printbbpm), PrintHead.RQM,
                                   q(Msg_Type.printbzsl), slstr,q(Msg_Type.printhgx), PrintHead.XDGXNAME, q(Msg_Type.printzhuangtai), PrintHead.CPZTNAME, q(Msg_Type.printzh),
                                   PrintHead.TH.ToString(), q(Msg_Type.printczg), CzlList,q(Msg_Type.printwcrq),PrintHead.VDATU};
            //string[] contentArr = { "物料编码", PrintHead.WLH, "物料描述", PrintHead.WLMS, "物料属性", wlss, "提供方", tgf, "订单数量",
            //PrintHead.GDSL.ToString("0.##"), "生产日期", scdate, "包标喷码", PrintHead.RQM,
            //"本幢数量", slstr, "后工序", PrintHead.XDGXNAME, "状态", PrintHead.CPZTNAME, "幢号",
            //PrintHead.TH.ToString(), "操作工", CzlList,"完成日期",PrintHead.VDATU};
            int h1 = 3;
            g.DrawLine(blackPen, margin + grid - 30, rowmargin * 0 + 70 + 13 + h1 - subWidth, margin + width, rowmargin * 0 + 70 + 13 + h1 - subWidth);
            g.DrawString(contentArr[0], font8, bru, new Rectangle(margin, 70 + rowmargin * 0 - subWidth, 210, rowmargin), strFormat1);
            g.DrawString(contentArr[1], font8, bru, new Rectangle(margin + grid - 30, 70 + rowmargin * 0 - subWidth, 210, rowmargin), strFormat1);
            g.DrawLine(blackPen, margin + grid - 30, rowmargin * 2 + 70 + 13 + h1 - subWidth, margin + width, rowmargin * 2 + 70 + 13 + h1 - subWidth);
            g.DrawString(contentArr[2], font8, bru, new Rectangle(margin, 70 + rowmargin * 1 - subWidth, 210, 2 * rowmargin), strFormat1);
            g.DrawString(contentArr[3], font8, bru, new Rectangle(margin + grid - 30, 70 + rowmargin * 1 - subWidth, 210, 2 * rowmargin), strFormat1);
            g.DrawLine(blackPen, margin + grid - 30, rowmargin * 3 + 70 + 13 + h1 - subWidth, margin + width, rowmargin * 3 + 70 + 13 + h1 - subWidth);
            g.DrawString(contentArr[4], font8, bru, new Rectangle(margin, 70 + rowmargin * 3 - subWidth, 210, rowmargin), strFormat1);
            g.DrawString(contentArr[5], font8, bru, new Rectangle(margin + grid - 30, 70 + rowmargin * 3 - subWidth, 210, rowmargin), strFormat1);
            g.DrawString(contentArr[6], font8, bru, new Rectangle(margin, 70 + rowmargin * 4 - subWidth, 210, rowmargin), strFormat1);
            g.DrawString(contentArr[7], font8, bru, new Rectangle(margin + grid - 30, 70 + rowmargin * 4 - subWidth, 210, rowmargin), strFormat1);
            g.DrawLine(blackPen, margin + grid - 30, rowmargin * 4 + 70 + 13 + h1 - subWidth, margin + width, rowmargin * 4 + 70 + 13 + h1 - subWidth);
            //第五行
            int Rowindex = 5;

            g.DrawString(contentArr[8], font8, bru, new Rectangle(margin, 70 + rowmargin * Rowindex - subWidth, 60, rowmargin), strFormat1);
            g.DrawString(contentArr[9], font8, bru, new Rectangle(margin * 2 + grid - 40, 70 + rowmargin * Rowindex - subWidth, width / 2, rowmargin), strFormat1);
            g.DrawLine(blackPen, margin + grid - 30, rowmargin * Rowindex + 70 + 13 + h1 - subWidth, width / 2 - 20, rowmargin * Rowindex + 70 + 13 + h1 - subWidth);
            g.DrawString(contentArr[10], font8, bru, new Rectangle(width / 2 + margin - 20, 70 + rowmargin * Rowindex - subWidth, width / 2 + 60, rowmargin), strFormat1);
            g.DrawLine(blackPen, width / 2 + 60 - 20, rowmargin * Rowindex + 70 + 13 + h1 - subWidth, width + margin, rowmargin * Rowindex + 70 + 13 + h1 - subWidth);
            g.DrawString(contentArr[11], font8, bru, new Rectangle(width / 2 + 60 + margin - 20, 70 + rowmargin * Rowindex - subWidth, width, rowmargin), strFormat1);
            Rowindex++;
            //第六行
            g.DrawString(contentArr[12], font8, bru, new Rectangle(margin, 70 + rowmargin * Rowindex - subWidth, 210, rowmargin), strFormat1);
            g.DrawString(contentArr[13], font8, bru, new Rectangle(margin + grid - 30, 70 + rowmargin * Rowindex - subWidth, 210, rowmargin), strFormat1);
            g.DrawLine(blackPen, margin + grid - 30, rowmargin * Rowindex + 70 + 13 + h1 - subWidth, margin + width, rowmargin * Rowindex + 70 + 13 + h1 - subWidth);
            Rowindex++;
            //第七行
            g.DrawString(contentArr[24], font8, bru, new Rectangle(margin, 70 + rowmargin * Rowindex - subWidth, 210, rowmargin), strFormat1);
            g.DrawString(contentArr[25], font8, bru, new Rectangle(margin + grid - 30, 70 + rowmargin * Rowindex - subWidth, 210, rowmargin), strFormat1);
            g.DrawLine(blackPen, margin + grid - 30, rowmargin * Rowindex + 70 + 13 + h1 - subWidth, margin + width, rowmargin * Rowindex + 70 + 13 + h1 - subWidth);
            Rowindex++;

            //第八行
            g.DrawString(contentArr[16], font8, bru, new Rectangle(margin, 70 + rowmargin * Rowindex - subWidth, 60, rowmargin), strFormat1);
            g.DrawString(contentArr[17], font8, bru, new Rectangle(margin * 2 + grid - 30, 70 + rowmargin * Rowindex - subWidth, width / 2, rowmargin), strFormat1);
            g.DrawLine(blackPen, margin + grid - 30, rowmargin * Rowindex + 70 + 13 + h1 - subWidth, width / 2, rowmargin * Rowindex + 70 + 13 + h1 - subWidth);
            g.DrawString(contentArr[18], font8, bru, new Rectangle(width / 2 + margin, 70 + rowmargin * Rowindex - subWidth, width / 2 + 30, rowmargin), strFormat1);
            g.DrawLine(blackPen, width / 2 + 35, rowmargin * Rowindex + 70 + 13 + h1 - subWidth, width / 2 + margin + 70, rowmargin * Rowindex + 70 + 13 + h1 - subWidth);
            g.DrawString(contentArr[19], font8, bru, new Rectangle(width / 2 + 35 + 2, 70 + rowmargin * Rowindex - subWidth, 40, rowmargin), strFormat1);
            g.DrawString(contentArr[20], font8, bru, new Rectangle(width / 2 + 35 + 2 + 42 + 5, 70 + rowmargin * Rowindex - subWidth, 40, rowmargin), strFormat1);
            g.DrawLine(blackPen, 40 + width / 2 + 35 + 40, rowmargin * Rowindex + 70 + 13 + h1 - subWidth, width + margin, rowmargin * Rowindex + 70 + 13 + h1 - subWidth);
            g.DrawString(contentArr[21], font8, bru, new Rectangle(40 + width / 2 + 35 + 5 + 42, 70 + rowmargin * Rowindex - subWidth, 60, rowmargin), strFormat1);
            Rowindex++;
            //第九行
            g.DrawString(contentArr[14], font8, bru, new Rectangle(margin, 70 + rowmargin * Rowindex - subWidth, 210, rowmargin), strFormat1);
            g.DrawString(contentArr[15], font8, bru, new Rectangle(margin + grid - 30, 70 + rowmargin * Rowindex - subWidth, 210, rowmargin), strFormat1);
            g.DrawLine(blackPen, margin + grid - 30, rowmargin * Rowindex + 70 + 13 + h1 - subWidth, margin + width, rowmargin * Rowindex + 70 + 13 + h1 - subWidth);
            Rowindex++;
            //第十行
            g.DrawString(contentArr[22], font8, bru, new Rectangle(margin, 70 + rowmargin * Rowindex - subWidth, 210, rowmargin), strFormat1);
            g.DrawString(contentArr[23], font8, bru, new Rectangle(margin + grid - 30, 70 + rowmargin * Rowindex - subWidth, 210, rowmargin), strFormat1);
            g.DrawLine(blackPen, margin + grid - 30, rowmargin * Rowindex + 70 + 13 + h1 - subWidth, margin + width, rowmargin * Rowindex + 70 + 13 + h1 - subWidth);


            int beginChild = 11;
            g.DrawString(q(Msg_Type.printbz), font8, bru, margin, 70 + beginChild * rowmargin - subWidth);

            int fozenheight = 20;
            //int addcount = 0;
            int aotuheigth = 0; ;
            for (int i = 0; i < PrintChild.Length; i++)
            {
                string xcmStr = q(Msg_Type.printxcm) + PrintChild[i].TM;
                if (!string.IsNullOrEmpty(PrintChild[i].ZFDCLBNAME))
                {
                    xcmStr += " [" + PrintChild[i].ZFDCLBNAME + "]";
                }
                string wlxx = q(Msg_Type.printwl) + PrintChild[i].WLH + "/" + PrintChild[i].WLMS;

                string zlxx = string.IsNullOrEmpty(PrintChild[i].GZZXBH) ? q(Msg_Type.printwlxx) + PrintChild[i].GYSMS + "/" + PrintChild[i].PC : q(Msg_Type.printzlxx) + PrintChild[i].TH + "/" + PrintChild[i].SBHMS + "/" + PrintChild[i].SCDATEP;              
                g.DrawString(xcmStr, font8, bru, new Rectangle(margin, 10 + (beginChild + 3) * rowmargin + 20 + 60 * i - subWidth + aotuheigth, width, fozenheight), strFormat1);
                bool doubleH = false;
                if (g.MeasureString(wlxx, font8).Width > width)
                {
                    doubleH = true;
                }
                g.DrawString(wlxx, font8, bru, new Rectangle(margin, 10 + (beginChild + 3) * rowmargin + 35 + 60 * i - subWidth + aotuheigth, width, doubleH ? fozenheight * 2 : fozenheight), strFormat1);
                if (doubleH)
                {
                    aotuheigth += fozenheight;
                }
                g.DrawString(zlxx, font8, bru, new Rectangle(margin, 10 + (beginChild + 3) * rowmargin + 50 + 60 * i - subWidth + aotuheigth, width, fozenheight), strFormat1);
                string xcmbzxx = q(Msg_Type.printxcbzxx) + PrintChild[i].REMARK.TrimStart('\n');
                string[] xcmbzxxList = xcmbzxx.Split('\n');
                SizeF sizef = g.MeasureString(xcmbzxx, font8);
                for (int j = 0; j < xcmbzxxList.Length; j++)
                {
                    if (xcmbzxxList[j].Length != 0)
                    {
                        int lines = (int)Math.Ceiling(sizef.Width / (width - margin));

                        g.DrawString(xcmbzxxList[j], font8, bru, new Rectangle(margin, 10 + (beginChild + 3) * rowmargin + 60 + 60 * i - subWidth + aotuheigth, width, fozenheight * lines), strFormat1);
                        //g.DrawString("下层备注信息:" + PrintChild[i].REMARK, font5, bru, margin, 10 + (beginChild + 3) * rowmargin + 65 + 65 * i - subWidth);
                        aotuheigth += fozenheight * (lines - 1);
                    }
                }
                

            }
            int cIndex = PrintChild.Length;
            int cHeigth = 60;
            g.DrawString(q(Msg_Type.printbzxx) + PrintHead.REMARK, font8, bru, new Rectangle(margin, 45 + (beginChild + 2) * rowmargin + cIndex * cHeigth - subWidth + aotuheigth, width, 30));
            //二维码
            //g.DrawImage(returnImage, margin + 5, 75 + 13 * rowmargin + cIndex * 50 - subWidth, 70, 70);
            //g.DrawString(PrintHead.TM, font7, bru, margin, 85 + 70 + 13 * rowmargin + cIndex * 50 - subWidth);
            g.DrawLine(blackPen, margin, 67 - subWidth, margin + width, 67 - subWidth);
            //g.DrawLine(blackPen, 0, 67, width, 67);
            g.DrawLine(blackPen, margin, 67 - subWidth, margin, 40 + (beginChild + 3) * rowmargin + cIndex * cHeigth + 20 - subWidth + aotuheigth);
            g.DrawLine(blackPen, margin + width, 67 - subWidth, margin + width, 40 + (beginChild + 3) * rowmargin + cIndex * cHeigth + 20 - subWidth + aotuheigth);
            g.DrawLine(blackPen, margin, 40 + (beginChild + 3) * rowmargin + cIndex * cHeigth + 20 - subWidth + aotuheigth, margin + width, 40 + (beginChild + 3) * rowmargin + cIndex * cHeigth + 20 - subWidth + aotuheigth);
            //Pen blackPen = new Pen(Color.Black, 1);
            //Font font22 = new Font(q(Msg_Type.fonttype), 22, FontStyle.Bold);
            //Font font14 = new Font(q(Msg_Type.fonttype), 14, FontStyle.Bold);
            //Font font13 = new Font(q(Msg_Type.fonttype), 13, FontStyle.Bold);
            //Font font9 = new Font(q(Msg_Type.fonttype), 12, FontStyle.Bold);
            //Font font7 = new Font(q(Msg_Type.fonttype), 10, FontStyle.Bold);
            //Font font5 = new Font(q(Msg_Type.fonttype), 8,FontStyle.Bold);
            //Brush bru = Brushes.Black;
            //Graphics g = e.Graphics;//画布
            //StringFormat strFormat = new StringFormat();
            //strFormat.LineAlignment = StringAlignment.Center;//垂直居中
            //strFormat.Alignment = StringAlignment.Center;//水平居中

            //StringFormat strFormat1 = new StringFormat();
            //strFormat1.LineAlignment = StringAlignment.Center;//垂直居中
            //strFormat1.Alignment = StringAlignment.Near;//水平居中
            //int width = 272;
            //int margin = 8;
            //int hrowmargin = 20;
            //int rowmargin = 18;
            //int grid = width / 3;
            //int grid1 = width / 4;

            //int subWidth = 15;
            //Rectangle recHead = new Rectangle(margin, 0, width, hrowmargin);//矩形
            //g.DrawString(PrintHead.GCDYMS, font13, bru, recHead, strFormat);

            //g.DrawString("商标机LOT表", font7, bru,margin + 110, hrowmargin + 10 - subWidth);
            //g.DrawString("编号: JS4533B", font5, bru, margin, hrowmargin + 30 - subWidth);
            //g.DrawString("车号:" + PrintHead.SBHMS, font5, bru, margin + 190, hrowmargin + 30 - subWidth);
            //string slstr = PrintHead.DCSLBS.ToString() + " X " + PrintHead.DCSLMBSL.ToString();
            //int sl = PrintHead.DCSLBS * PrintHead.DCSLMBSL;
            //if (PrintHead.DCSLYS != 0)
            //{
            //    if (sl != 0)
            //    {
            //        sl = sl + PrintHead.DCSLYS;
            //        slstr += " + " + PrintHead.DCSLYS + " = " + sl.ToString();
            //    }
            //    else
            //    {
            //        slstr = PrintHead.DCSLYS.ToString();
            //    }

            //}
            //else
            //{
            //    slstr += " = " + sl.ToString();
            //}
            //string wlss = "";
            //if (string.IsNullOrEmpty(PrintHead.NOBILL))
            //{
            //    wlss = PrintHead.PC;
            //}
            //else
            //{
            //    wlss = PrintHead.NOBILL + "-" + PrintHead.NOBILLMX + "/" + PrintHead.PC;
            //}
            //string tgf = PrintHead.GZZXBH;
            //if (!string.IsNullOrEmpty(PrintHead.GZZXMS))
            //{
            //    tgf += "-" + PrintHead.GZZXMS;
            //}

            //string[] contentArr = { "物料编码", PrintHead.WLH, "物料描述", PrintHead.WLMS, "物料属性", wlss, "提供方", tgf, "订单数量", PrintHead.GDSL.ToString("0.##"), "包标喷码", PrintHead.RQM, "生产日期", PrintHead.SCDATE, "包标幢号", PrintHead.TH.ToString(), "本幢数量", slstr, "后工序", PrintHead.XDGXNAME, "状态", PrintHead.CPZTNAME, "操作工", CzlList };


            //int h1 = 3;
            //g.DrawLine(blackPen, margin +grid - 30, rowmargin * 0 + 70 + 13 + h1 - subWidth,margin + width, rowmargin * 0 + 70 + 13 + h1 - subWidth);
            //g.DrawString(contentArr[0], font5, bru, new Rectangle(margin, 70 + rowmargin * 0 - subWidth, 210, rowmargin), strFormat1);
            //g.DrawString(contentArr[1], font5, bru, new Rectangle(margin + grid - 30, 70 + rowmargin * 0 - subWidth, 210, rowmargin), strFormat1);
            //g.DrawLine(blackPen,margin + grid - 30,  rowmargin * 2 + 70 + 13 + h1 - subWidth, margin +width, rowmargin * 2 + 70 + 13 + h1 - subWidth);
            //g.DrawString(contentArr[2], font5, bru, new Rectangle(margin, 70 + rowmargin * 1 - subWidth, 210, 2 * rowmargin), strFormat1);
            //g.DrawString(contentArr[3], font5, bru, new Rectangle(margin + grid - 30, 70 + rowmargin * 1 - subWidth, 210, 2 * rowmargin), strFormat1);
            //g.DrawLine(blackPen,margin + grid - 30, rowmargin * 3 + 70 + 13 + h1 - subWidth,margin + width, rowmargin * 3 + 70 + 13 + h1 - subWidth);
            //g.DrawString(contentArr[4], font5, bru, new Rectangle(margin, 70 + rowmargin * 3 - subWidth, 210, rowmargin), strFormat1);
            //g.DrawString(contentArr[5], font5, bru, new Rectangle(margin + grid - 30, 70 + rowmargin * 3 - subWidth, 210, rowmargin), strFormat1);
            //g.DrawString(contentArr[6], font5, bru, new Rectangle(margin, 70 + rowmargin * 4 - subWidth, 210, rowmargin), strFormat1);
            //g.DrawString(contentArr[7], font5, bru, new Rectangle(margin + grid - 30, 70 + rowmargin * 4 - subWidth, 210, rowmargin), strFormat1);
            //g.DrawLine(blackPen, margin + grid - 30, rowmargin * 4 + 70 + 13 + h1 - subWidth,margin +  width, rowmargin * 4 + 70 + 13 + h1 - subWidth);
            //for (int i = 8; i < 16; i++)
            //{
            //    if ((i - 8) % 4 == 1 || (i - 8) % 4 == 3)
            //    {
            //        int k = (i - 8) % 4 == 1 ? 1 : 3;
            //        int h = (i - 8) / 4;
            //        g.DrawLine(blackPen, margin + grid1 * k - 8, rowmargin * h + 70 + 13 + rowmargin * 5 + h1 - subWidth, margin + grid1 * k + grid1, rowmargin * h + 70 + 13 + rowmargin * 5 + h1 - subWidth);
            //    }
            //    g.DrawString(contentArr[i], font5, bru, new Rectangle(margin + grid1 * ((i - 8) % 4), 70 + rowmargin * 5 + rowmargin * ((i - 8) / 4) - subWidth, width / 4, rowmargin), strFormat1);
            //}
            //g.DrawString(contentArr[16], font5, bru, margin, 70 + 7 * rowmargin - subWidth);
            //g.DrawString(contentArr[17], font5, bru,margin +  60, 70 + 7 * rowmargin - subWidth);
            //g.DrawLine(blackPen, margin + 60, 70 + 7 * rowmargin + 13 + h1 - subWidth, margin + width, 70 + 7 * rowmargin + 13 + h1 - subWidth);
            //for (int i = 18; i < 22; i++)
            //{
            //    if ((i - 18) % 4 == 1 || (i - 18) % 4 == 3)
            //    {
            //        int k = (i - 18) % 4 == 1 ? 1 : 3;
            //        int h = (i - 18) / 4;
            //        g.DrawLine(blackPen,margin +  grid1 * k - 8, rowmargin * h + 70 + 13 + rowmargin * 8 + h1 - subWidth,margin +  grid1 * k + grid1, rowmargin * h + 70 + 13 + rowmargin * 8 + h1 - subWidth);
            //    }
            //    g.DrawString(contentArr[i], font5, bru, new Rectangle(margin + grid1 * ((i - 18) % 4), 70 + rowmargin * 8 + rowmargin * ((i - 18) / 4) - subWidth, width / 4, rowmargin), strFormat1);
            //}
            //g.DrawString(contentArr[22], font5, bru, margin , 70 + 9 * rowmargin - subWidth);
            //g.DrawString(contentArr[23], font5, bru,margin + 60, 70 + 9 * rowmargin - subWidth);
            //g.DrawLine(blackPen,margin + 60, 70 + 9 * rowmargin + 13 + h1 - subWidth,margin + width, 70 + 9 * rowmargin + 13 + h1 - subWidth);
            ////g.DrawString(contentArr[24], font5, bru, 0, 70 + 10 * rowmargin);
            ////g.DrawString(contentArr[25], font5, bru, 60, 70 + 10 * rowmargin);
            ////g.DrawLine(blackPen, 60, 70 + 10 * rowmargin + 13 + h1, width, 70 + 10 * rowmargin + 13 + h1);
            //g.DrawString("备注 ", font5, bru, margin, 70 + 10 * rowmargin - subWidth);


            //for (int i = 0; i < PrintChild.Length; i++)
            //{
            //    g.DrawString("下层码: " + PrintChild[i].TM, font5, bru, margin, 10 + 13 * rowmargin + 20 + 70 * i - subWidth);
            //    g.DrawString("物料: " + PrintChild[i].WLH + "/" + PrintChild[i].WLMS, font5, bru, margin, 10 + 13 * rowmargin + 40 + 70 * i - subWidth);

            //    if (string.IsNullOrEmpty(PrintChild[i].GZZXBH))
            //    {
            //        g.DrawString("质量信息: " + PrintChild[i].GYSMS + "/" + PrintChild[i].PC, font5, bru, margin, 10 + 13 * rowmargin + 60 + 70 * i - subWidth);
            //    }
            //    else
            //    {
            //        g.DrawString("质量信息: " + PrintChild[i].TH + "/" + PrintChild[i].SBHMS + "/" + PrintChild[i].SCDATE, font5, bru, margin, 10 + 13 * rowmargin + 60 + 70 * i - subWidth);
            //    }


            //}
            //int cIndex = PrintChild.Length;
            //g.DrawString("备注信息:" + PrintHead.REMARK, font5, bru, margin, 75 + 12 * rowmargin + cIndex * 50 - subWidth);
            //byte[] bytes = ServicModel.BarCode.CreateBarCode(PrintHead.TM, "QRCODE", 70, 70, 1);
            //MemoryStream ms = new MemoryStream(bytes);
            //Image returnImage = Image.FromStream(ms);
            //g.DrawImage(returnImage, margin + 5, 75 + 13 * rowmargin + cIndex * 50 - subWidth, 70, 70);
            //g.DrawString(PrintHead.TM, font7, bru,margin, 85 + 70 + 13 * rowmargin + cIndex * 50 - subWidth);
            //g.DrawLine(blackPen, margin, 67 - subWidth, margin +width, 67 - subWidth);
            ////g.DrawLine(blackPen, 0, 67, width, 67);
            //g.DrawLine(blackPen, margin, 67 - subWidth, margin, 80 + 70 + 13 * rowmargin + cIndex * 60 + 20 - subWidth);
            //g.DrawLine(blackPen, margin + width, 67 - subWidth, margin + width, 80 + 70 + 13 * rowmargin + cIndex * 60 + 20 - subWidth);
            //g.DrawLine(blackPen, margin, 80 + 70 + 13 * rowmargin + cIndex * 60 + 20 - subWidth,margin + width, 80 + 70 + 13 * rowmargin + cIndex * 60 + 20 - subWidth);






        }

        private void DrawZXLot(PrintPageEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 1);
            Pen pen2 = new Pen(Color.Black, 1);
            //pen2.DashStyle = DashStyle.Custom;
            pen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            pen2.DashPattern = new float[] { 1f, 1f };
            Font font18 = new Font(q(Msg_Type.fonttype), 18);
            Font font32 = new Font(q(Msg_Type.fonttype), 32, FontStyle.Bold);
            Font font28 = new Font(q(Msg_Type.fonttype), 28, FontStyle.Bold);
            Font font14 = new Font(q(Msg_Type.fonttype), 14);
            Font font12 = new Font(q(Msg_Type.fonttype), 12);
            Font font17 = new Font(q(Msg_Type.fonttype), 17, FontStyle.Bold);
            Font font10 = new Font(q(Msg_Type.fonttype), 10);
            Font font5 = new Font(q(Msg_Type.fonttype), 5);
            Brush bru = Brushes.Black;
            Graphics g = e.Graphics;//画布
            StringFormat strFormat = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat.Alignment = StringAlignment.Center;//水平居中
            StringFormat strFormat1 = new StringFormat();
            strFormat1.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat1.Alignment = StringAlignment.Near;//水平居中

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;//抗锯齿        
            int width = 827;
            //int height = 565;
            int m1 = 20;
            int g1 = 20;
            string LotNo = string.IsNullOrEmpty(PrintHead.LOTNO) ? string.Format(q(Msg_Type.printbhformat), "JS4001A") : q(Msg_Type.printbh) + PrintHead.LOTNO;
            g.DrawString(LotNo, font10, bru, 0 + m1, 0 + g1);
            byte[] bytes = ServicModel.BarCode.CreateBarCode(PrintHead.TM, "QRCODE", 70, 70, 1);
            MemoryStream ms = new MemoryStream(bytes);
            Image returnImage = Image.FromStream(ms);
            g.DrawImage(returnImage, 5 + m1, 20 + g1, 70, 70);
            g.DrawString(PrintHead.TM, font10, bru, 0 + m1, 80 + 20 + g1);
            g.DrawString(PrintHead.PC, font10, bru, 0 + m1, 80 + 20 + 20 + g1 + 20);
            string scsj = Convert.ToDateTime(PrintHead.KSTIME).ToString("HHmm") + "0" + Convert.ToDateTime(PrintHead.JSTIME).ToString("HHmm");
            g.DrawString(scsj, font10, bru, 0 + m1, 80 + 20 + 20 + g1);
            g.DrawString(q(Msg_Type.printwlxx) + PrintHead.WLH + "-" + PrintHead.WLMS, font10, bru, 0 + m1, 80 + 20 + 20 + 20 + 20 + g1);
            //g.DrawString(PrintHead.GCDYMS, font18, bru, 200 - 20 - 10, 50 + g1);//PrintHead.ZFDCLBNAME  width - 170 - 140 - 40 - 20
            g.DrawString(PrintHead.GCDYMS, font18, bru, new Rectangle(80, 50, width - (width - 170 - 140 - 40 - 20) + 60, 60), strFormat);
            g.DrawRectangle(blackPen, new Rectangle(width - 170 - 60, 30, 170, 60));
            g.DrawString(PrintHead.CPZTNAME, font32, bru, new Rectangle(width - 170 - 60, 30 + 7, 170, 60), strFormat);
            string zfname = PrintHead.ZFDCLBNAME;
            if (zfname.Length > 0)
            {
                try
                {
                    //暂放素电类型截取部分字段显示
                    string[] contentArr = zfname.Split(q(Msg_Type.printzan).ToCharArray()[0]);//'暂'
                    if (contentArr.Length > 1)
                    {
                        g.DrawString(contentArr[0], font28, bru, new Rectangle(width - 170 - 120, 10 + 90, 170 + 120, 60), strFormat);
                    }

                }
                catch
                {
                }

            }




            g.DrawString(PrintHead.DCDJMS, new Font(q(Msg_Type.fonttype), 50, FontStyle.Bold), bru, new Rectangle(width - 170 - 140 - 40 - 20, 10 + g1, 140, 140));
            if (PrintHead.WLMS.Contains(q(Msg_Type.printshuanglu)))//"双鹿"
            {
                g.DrawString(q(Msg_Type.printshuanglu), new Font(q(Msg_Type.fonttype), 35, FontStyle.Bold), bru, new Rectangle(width - 370, 10 + g1 + 85, 140, 140));
            }

            g.DrawString(q(Msg_Type.printsdlotb), font14, bru, width / 2 - 110 - 20 - 20, 50 + 20 + 20 + g1);
            int margin = 30;
            int h = 220 + 10;
            string sbhms = PrintHead.SBHMS;
            int isWlgroup = 40;
            int scdatepWith = 100;
            if (!string.IsNullOrEmpty(PrintHead.WLGROUP))
            {
                if (PrintHead.WLGROUP.Equals(ZZWLGROUP))
                {
                    sbhms += "(" + PrintHead.PC.Substring(6, 3) + ")";
                    isWlgroup = 0;
                }
            }

            //第一行
            g.DrawString(q(Msg_Type.printscx), font17, bru, 5 + m1, h);//"生产线"
            g.DrawString(sbhms, font17, bru, 100 + m1 + isWlgroup, h - 5);
            g.DrawLine(blackPen, 90 + m1 + 20, h + 20, 230 + m1, h + 20);//line
            g.DrawString(q(Msg_Type.printscrq), font17, bru, 235 + m1, h);//"生产日期"
            g.DrawString(PrintHead.SCDATEP, font17, bru, 340 + m1, h - 5);
            g.DrawLine(blackPen, 320 + m1 + 20, h + 20, 450 + m1 + scdatepWith, h + 20);//line
            g.DrawString(q(Msg_Type.printzh), font17, bru, 465 + m1 + scdatepWith, h);//"幢号"
            g.DrawString(PrintHead.TH.ToString(), font17, bru, 580 + m1 + 20 + scdatepWith * 7 / 10, h - 5);
            g.DrawLine(blackPen, 530 + m1 + 10 + scdatepWith, h + 20, width - 50 - m1, h + 20);//line
            //第二行
            margin += 10;
            g.DrawString(q(Msg_Type.printdcxh), font17, bru, 5 + m1, h + margin);//"电池型号"
            g.DrawString(PrintHead.DCXHMS, font17, bru, 120 + m1 + 20, h + margin - 5);
            g.DrawLine(blackPen, 90 + m1 + 20, h + margin + 20, 230 + m1, h + margin + 20);//line
            g.DrawString(q(Msg_Type.printdcdj), font17, bru, 235 + m1, h + margin);//"电池等级"
            g.DrawString(PrintHead.DCDJMS, font17, bru, 350 + m1 + 20, h + margin - 5);
            g.DrawLine(blackPen, 320 + m1 + 20, h + margin + 20, 450 + m1, h + margin + 20);//line
            g.DrawString(q(Msg_Type.printczg), font17, bru, 465 + m1, h + margin);//"操作工"
            g.DrawString(CzlList, font17, bru, 530 + m1 + 20, h + margin - 5);
            g.DrawLine(blackPen, 530 + m1 + 20, h + margin + 20, width - 50 - m1, h + margin + 20);//line
            //第三行
            g.DrawString(q(Msg_Type.printzcdd), font12, bru, 5 + m1, h + margin + margin);//"正常订单"

            g.DrawLine(blackPen, 130 + m1, h + margin + margin + 20, 310 + m1, h + margin + margin + 20);//line
            g.DrawString(q(Msg_Type.printtsdd), font12, bru, 260 + 60 + m1, h + margin + margin);//"特殊订单"

            g.DrawString(q(Msg_Type.printxcf), font12, bru, 465 + m1, h + margin + margin);//"需存放"
            g.DrawString(q(Msg_Type.printtian), font12, bru, 520 + 220 - m1, h + margin + margin);//"天"
            g.DrawLine(blackPen, 530 + m1, h + margin + margin + 20, width - 50 - m1, h + margin + margin + 20);//line
            //第四行
            g.DrawString(q(Msg_Type.printsdyt), font12, bru, 5 + m1, h + margin + margin + margin);//"素电已挑"


            g.DrawString(q(Msg_Type.printtdrq), font12, bru, 130 + m1, h + margin + margin + margin);//"挑电日期"
            g.DrawLine(blackPen, 210 + m1, h + margin + margin + margin + 20, 350 - m1, h + margin + margin + margin + 20);//line
            g.DrawString(q(Msg_Type.printsl), font12, bru, 465 + m1, h + margin + margin + margin);//"数量"
            string slstr = "";
            if (PrintHead.DCSLBS != 0 && PrintHead.DCSLMBSL != 0)
            {
                slstr = PrintHead.DCSLBS.ToString() + " X " + PrintHead.DCSLMBSL.ToString();
                if (PrintHead.DCSLYS != 0)
                {
                    int sl = PrintHead.DCSLBS * PrintHead.DCSLMBSL;
                    sl = sl + PrintHead.DCSLYS;
                    slstr += " + " + PrintHead.DCSLYS + " = " + sl.ToString("0.##");
                }
                else
                {
                    if (slstr.Length == 0)
                    {
                        slstr = PrintHead.SL.ToString("0.##");
                    }
                    else
                    {
                        slstr += " = " + PrintHead.SL.ToString("0.##");
                    }
                }
            }
            else
            {
                slstr = PrintHead.SL.ToString("0.##");
            }
            if (!slstr.Equals("0"))
            {
                g.DrawString(slstr, font12, bru, 530 + m1, h + margin + margin + margin);
            }
            g.DrawLine(blackPen, 530 + m1, h + margin + margin + margin + 20, width - 50 - m1, h + margin + margin + margin + 20);//line
            //第五行
            string[] bzArr = PrintHead.REMARK.Split(new string[] { ZXVerifyStr }, StringSplitOptions.None);

            if (PrintHead.GC == BranchGC && bzArr.Length == 2)
            {
                string bzcontent = "";
                g.DrawString(q(Msg_Type.printbz), font12, bru, 5 + m1, h + margin + margin + margin + margin);//"备注"
                if (!string.IsNullOrEmpty(PrintHead.ZFDCLBNAME))
                {
                    bzcontent = PrintHead.ZFDCLBNAME + "  " + bzArr[0].Trim().Replace("\n", "");
                }
                else
                {
                    bzcontent = bzArr[0].Trim().Replace("\n", "");
                }
                SizeF bzsizrf1 = g.MeasureString(bzcontent, font12);
                //int c = defaultHeight;
                int lines = (int)Math.Ceiling(bzsizrf1.Width / (width - margin - 80 - m1));
                int bzFont12height = 22;
                //g.DrawString(bzcontent, font12, bru, 80 + m1, h + margin*4);
                g.DrawString(bzcontent, font12, bru, new Rectangle(80 + m1, h + margin * 4, width - margin - 80 - m1, h + margin * 4 + bzFont12height * lines));

                //g.DrawLine(blackPen, 5 + 40 + m1*2, h + margin + margin + margin + margin + 20, width - 50 - m1, h + margin*4 + 20);//line
                lines = lines == 0 ? 1 : lines;
                g.DrawLine(blackPen, 5 + 40 + m1 * 2, h + margin * 4 + bzFont12height * lines + 5, width - 50 - m1, h + margin * 4 + bzFont12height * lines + 5);//line
                string yclStr = bzArr[1].Replace("\n", "");
                SizeF bzsizrf2 = g.MeasureString(yclStr, font12);

                g.DrawString(q(Msg_Type.printycl), font12, bru, 5 + m1, h + margin * 4 + bzFont12height * lines + 5 + 5 + 5);//"原材料"


                int lines1 = (int)Math.Ceiling(bzsizrf2.Width / (width - margin - 80 - m1));
                //g.DrawString(bzArr[1].Replace("\n", ""), font12, bru, 80 + m1, h + margin * 4 + m1 * 2);
                g.DrawString(yclStr, font12, bru, new Rectangle(80 + m1, h + margin * 4 + bzFont12height * lines + 15, width - margin - 80 - m1, h + margin * 4 + bzFont12height * lines + bzFont12height * lines1 + 15));
                //g.DrawLine(blackPen, 5 + 40 + m1 * 2, h + margin * 4 + 20 + m1 * 2, width - 50 - m1, h + margin * 4 + 20 + m1 * 2);//line
                lines1 = lines1 == 0 ? 1 : lines1;
                g.DrawLine(blackPen, 5 + 40 + m1 * 2, h + margin * 4 + bzFont12height * lines + bzFont12height * lines1 + 25, width - 50 - m1, h + margin * 4 + bzFont12height * lines + bzFont12height * lines1 + 25);//line

            }
            else
            {
                g.DrawString(q(Msg_Type.printbz), font12, bru, 5 + m1, h + margin + margin + margin + margin);//"备注"
                string bzcontent = "";
                if (!string.IsNullOrEmpty(PrintHead.ZFDCLBNAME))
                {
                    bzcontent = PrintHead.ZFDCLBNAME + "  " + PrintHead.REMARK;
                }
                else
                {
                    bzcontent = PrintHead.REMARK;
                }
                g.DrawString(bzcontent, font12, bru, 80 + m1, h + margin + margin + margin + margin);
                g.DrawLine(blackPen, 5 + 40 + m1, h + margin + margin + margin + margin + 20, width - 50 - m1, h + margin + margin + margin + margin + 20);//line
            }





            //int square = 7;
            //int loctionX = 80;
            //int loctionY = 117;
            g.DrawRectangle(blackPen, new Rectangle(80 + 20, 30 + 117 + 90 + 30 + 20 + 30, 7, 7));//第三行小方块
            g.DrawRectangle(blackPen, new Rectangle(80 + 20, 30 + 117 + 90 + 30 + 20 + 30 + 40, 7, 7));//第四行小方块

        }
        private void DrawRK(PrintPageEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 1);
            Font font22 = new Font(q(Msg_Type.fonttype), 22);
            Font font14 = new Font(q(Msg_Type.fonttype), 14);
            Font font12 = new Font(q(Msg_Type.fonttype), 12);
            Font font10 = new Font(q(Msg_Type.fonttype), 10);
            Font font5 = new Font(q(Msg_Type.fonttype), 5);
            Brush bru = Brushes.Black;
            Graphics g = e.Graphics;//画布
            StringFormat strFormat = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat.Alignment = StringAlignment.Center;//水平居中
            StringFormat strFormat1 = new StringFormat();
            strFormat1.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat1.Alignment = StringAlignment.Near;//水平居中

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;//抗锯齿           
            //int width = printDialog1.PrinterSettings.DefaultPageSettings.PaperSize.Width;
            int width = 827;
            int height = 565;
            int xmargin = 5;
            int rowmargin = 40;
            Rectangle recHead = new Rectangle(xmargin, 10, width - 10, rowmargin);//矩形
            Rectangle recHead1 = new Rectangle(xmargin, 10 + 25, width - 10, rowmargin);//矩形
            string a = PrintHead.GCDYMS;

            g.DrawString(PrintHead.GCDYMS, font22, bru, recHead, strFormat);
            g.DrawString(q(Msg_Type.printwlrkbszz), font14, bru, recHead1, strFormat);
            for (int i = 0; i < 5; i++)
            {
                g.DrawLine(blackPen, 0, rowmargin + rowmargin * (i + 1), width - 28, rowmargin + rowmargin * (i + 1));
            }
            string gtsl = PrintHead.SL + PrintHead.UNITSNAME + "/" + Xs + q(Msg_Type.printxiang);// "箱";
            if (string.IsNullOrEmpty(Xs))
            {
                gtsl = PrintHead.SL + PrintHead.UNITSNAME + "/" + "   " + q(Msg_Type.printxiang);
            }
            string scrq = "";
            if (!string.IsNullOrEmpty(PrintHead.BCMS))
            {
                scrq = PrintHead.SCDATE + "/" + PrintHead.BCMS;
            }
            else
            {
                scrq = PrintHead.SCDATE;
            }
            string[] contentArr = { q(Msg_Type.printgc), PrintHead.GC, q(Msg_Type.printscrq), scrq, q(Msg_Type.printzhuangtai), q(Msg_Type.printhg),q(Msg_Type.printwlbm), PrintHead.WLH,q(Msg_Type.printwlms), PrintHead.WLMS,q(Msg_Type.printwlsx), PrintHead.PC, q(Msg_Type.printgtsl), gtsl,q(Msg_Type.printckdjno), PrintHead.ERPNO + "/" + PrintHead.GZZXMS + "/" + PrintHead.SBHMS };
            //string[] contentArr = { "工厂", PrintHead.GC, "生产日期", scrq, "状态", "合格", "物料编码", PrintHead.WLH, "物料描述", PrintHead.WLMS, "物料属性", PrintHead.PC, "该托数量/箱数", gtsl, "参考信息", PrintHead.ERPNO + "/" + PrintHead.GZZXMS + "/" + PrintHead.SBHMS };

            int grid = width / 6;
            //int rowmargin1 = 10;
            //int topheight = 80;
            //第一行
            for (int i = 0; i < 6; i++)
            {
                g.DrawString(contentArr[i], font12, bru, new Rectangle(grid * i, 43 + rowmargin, grid, rowmargin), strFormat1);
            }
            //第二行
            for (int i = 0; i < 3; i++)
            {
                g.DrawString(contentArr[6 + i], font12, bru, new Rectangle(grid * i, 3 + rowmargin * 3, grid, rowmargin), strFormat1);
            }
            g.DrawString(contentArr[9], font12, bru, new Rectangle(grid * 3, 3 + rowmargin * 3, grid * 3, rowmargin), strFormat1);
            //第三行
            g.DrawString(contentArr[10], font12, bru, new Rectangle(0, 3 + rowmargin * 4, grid, rowmargin), strFormat1);
            g.DrawString(contentArr[11], font12, bru, new Rectangle(grid, 3 + rowmargin * 4, grid * 3, rowmargin), strFormat1);
            g.DrawString(contentArr[12], font12, bru, new Rectangle(grid * 3, 3 + rowmargin * 4, grid * 4, rowmargin), strFormat1);
            g.DrawString(contentArr[13], font12, bru, new Rectangle(grid * 4, 3 + rowmargin * 4, grid * 6, rowmargin), strFormat1);
            //第四行
            g.DrawString(contentArr[14], font12, bru, new Rectangle(0, 40 + rowmargin * 4, grid, rowmargin), strFormat1);
            g.DrawString(contentArr[15], font12, bru, new Rectangle(grid, 40 + rowmargin * 4, grid * 5, rowmargin), strFormat1);
            g.DrawLine(blackPen, 0, 2 * rowmargin, 0, height);
            g.DrawLine(blackPen, width / 6, 2 * rowmargin, width / 6, rowmargin * 2 + rowmargin * 4);
            g.DrawLine(blackPen, width / 6 * 2, 2 * rowmargin, width / 6 * 2, rowmargin * 2 + rowmargin * 2);
            g.DrawLine(blackPen, width / 6 * 3, 2 * rowmargin, width / 6 * 3, rowmargin * 2 + rowmargin * 3);
            g.DrawLine(blackPen, width / 6 * 4, 2 * rowmargin, width / 6 * 4, 2 * rowmargin + rowmargin);
            g.DrawLine(blackPen, width / 6 * 4, 2 * rowmargin + 2 * rowmargin, width / 6 * 4, 2 * rowmargin + rowmargin * 3);
            g.DrawLine(blackPen, width / 6 * 5, 2 * rowmargin, width / 6 * 5, 2 * rowmargin + rowmargin);
            g.DrawLine(blackPen, width - 28, 2 * rowmargin, width - 28, height);
            g.DrawLine(blackPen, 0, height, width - 28, height);

            byte[] bytes = ServicModel.BarCode.CreateBarCode(PrintHead.TM, "QRCODE", 120, 120, 1);
            MemoryStream ms = new MemoryStream(bytes);
            Image returnImage = Image.FromStream(ms);

            g.DrawImage(returnImage, grid * 4, rowmargin * 6 + 20, 120, 120);
            g.DrawString(PrintHead.TM, font12, bru, grid * 4 + 7, rowmargin * 6 + 20 + 120);
            for (int i = 0; i < PrintChild.Length; i++)
            {
                g.DrawString(q(Msg_Type.printxcm)  + PrintChild[i].TM, font10, bru, 5, 6 * rowmargin + 20 + 90 * i);
                g.DrawString(q(Msg_Type.printwl) + PrintChild[i].WLH + "/" + PrintChild[i].WLMS + "/" + PrintChild[i].PC, font10, bru, 5, 6 * rowmargin + 40 + 90 * i);
                string gysStr = q(Msg_Type.printgys);// "供应商:";
                if (!string.IsNullOrEmpty(PrintChild[i].GYS))
                {
                    gysStr += PrintChild[i].GYS;
                    if (!string.IsNullOrEmpty(PrintChild[i].GYSMS))
                    {
                        gysStr += "-" + PrintChild[i].GYSMS;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(PrintChild[i].GYSMS))
                    {
                        gysStr += PrintChild[i].GYSMS;
                    }
                }
                if (!string.IsNullOrEmpty(PrintChild[i].GYS) || !string.IsNullOrEmpty(PrintChild[i].GYSMS))
                {
                    if (!string.IsNullOrEmpty(PrintChild[i].GYSPC))
                    {
                        gysStr += "/" + PrintChild[i].GYSPC;
                    }
                }
                else
                {
                    gysStr += "/" + PrintChild[i].GYSPC;
                }
                g.DrawString(gysStr, font10, bru, 5, 6 * rowmargin + 60 + 90 * i);

                string zlxxStr = q(Msg_Type.printzlxx);//"质量信息:";
                if (!string.IsNullOrEmpty(PrintChild[i].SBHMS))
                {
                    zlxxStr += PrintChild[i].SBHMS;
                }
                if (!string.IsNullOrEmpty(PrintChild[i].CLCJ))
                {
                    if (!string.IsNullOrEmpty(PrintChild[i].SBHMS))
                    {
                        zlxxStr += "/" + PrintChild[i].CLCJ;
                    }
                    else
                    {
                        zlxxStr += PrintChild[i].CLCJ;
                    }
                }
                if (!string.IsNullOrEmpty(PrintChild[i].GYLX))
                {
                    if (!string.IsNullOrEmpty(PrintChild[i].SBHMS) || !string.IsNullOrEmpty(PrintChild[i].SBHMS))
                    {
                        zlxxStr += "/" + PrintChild[i].GYLX;
                    }
                    else
                    {
                        zlxxStr += PrintChild[i].GYLX;
                    }
                }

                g.DrawString(zlxxStr, font10, bru, 5, 6 * rowmargin + 80 + 90 * i);

            }
            int bzHeight = 6 * rowmargin + 20 + PrintChild.Length * 90;
            g.DrawString(q(Msg_Type.printbz) + PrintHead.REMARK, font10, bru, 5, bzHeight);//"备注:"

        }

        private void DrawZSWLLOT(PrintPageEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 1);
            Font font22 = new Font(q(Msg_Type.fonttype), 22, FontStyle.Bold);
            Font font14 = new Font(q(Msg_Type.fonttype), 14, FontStyle.Bold);
            Font font13 = new Font(q(Msg_Type.fonttype), 13, FontStyle.Bold);
            Font font12 = new Font(q(Msg_Type.fonttype), 12, FontStyle.Bold);
            Font font10 = new Font(q(Msg_Type.fonttype), 10, FontStyle.Bold);
            Font font8 = new Font(q(Msg_Type.fonttype), 8, FontStyle.Bold);
            Brush bru = Brushes.Black;
            Graphics g = e.Graphics;//画布
            StringFormat strFormat = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat.Alignment = StringAlignment.Center;//水平居中

            StringFormat strFormat1 = new StringFormat();
            strFormat1.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat1.Alignment = StringAlignment.Near;//水平居中
            StringFormat strFormat2 = new StringFormat();
            strFormat2.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat2.Alignment = StringAlignment.Far;//水平居中
            int width = 285;
            int margin = 8;
            int hrowmargin = 20;
            int rowmargin = 18;
            int grid = width / 4;
            int grid1 = width / 4;
            int increasingheight = 5;
            g.DrawString(string.Format(q(Msg_Type.printbhformat),"QR-JS-129 A/0"), font10, bru, 0, increasingheight);
            if (PrintHead.CPTYPENAME == "试样")//如果是试样"试样"
            {
                g.DrawRectangle(blackPen, new Rectangle(width - 75, increasingheight, 56, 31));
                g.DrawString(PrintHead.CPTYPENAME, font12, bru, new Rectangle(width - 75, increasingheight, 56, 31), strFormat);
            }

            increasingheight += hrowmargin;
            g.DrawString(q(Msg_Type.printwllotb), font10, bru, margin + 95, increasingheight);//"物料LOT表"
            increasingheight += hrowmargin;
            string[] contentArr = new string[] {q(Msg_Type.printwlbm),PrintHead.WLH,q(Msg_Type.printwlms),PrintHead.WLMS,
            q(Msg_Type.printkssj),Convert.ToDateTime(PrintHead.KSTIME).ToString("yy.MM.dd  HH:mm"),q(Msg_Type.printjssj),Convert.ToDateTime(PrintHead.JSTIME).ToString("yy.MM.dd  HH:mm"),q(Msg_Type.printsbh),PrintHead.SBHMS,q(Msg_Type.printmjh),PrintHead.MOULD,
            q(Msg_Type.printsl),PrintHead.SL.ToString("0.####") + " " + PrintHead.UNITSNAME,"",q(Msg_Type.printjz),PrintHead.JZ.ToString("0.####") + " kg","",q(Msg_Type.printcpzt),PrintHead.CPZTNAME,q(Msg_Type.printczg),CzlList};
            //string[] contentArr = new string[] {"物料编码",PrintHead.WLH,"物料描述",PrintHead.WLMS,
            //"开始时间",Convert.ToDateTime(PrintHead.KSTIME).ToString("yy.MM.dd  HH:mm"),"结束时间",Convert.ToDateTime(PrintHead.JSTIME).ToString("yy.MM.dd  HH:mm"),"设备号",PrintHead.SBHMS,"模具号",PrintHead.MOULD,
            //"数量",PrintHead.SL.ToString("0.####") + " " + PrintHead.UNITSNAME,"","净重",PrintHead.JZ.ToString("0.####") + " kg","","产品状态",PrintHead.CPZTNAME,"操作工",CzlList};
            int contentIndex = 0;
            int intervalmargin = 2;
            for (int i = 0; i < 10; i++)
            {
                g.DrawRectangle(blackPen, new Rectangle(margin, increasingheight, grid, hrowmargin));
                g.DrawString(contentArr[contentIndex++], font8, bru, new Rectangle(margin, increasingheight + intervalmargin, grid, hrowmargin), strFormat1);
                if (i == 6 || i == 7)
                {
                    //g.DrawRectangle(blackPen, new Rectangle(margin + grid, increasingheight, grid, hrowmargin));
                    g.DrawString(contentArr[contentIndex++], font8, bru, new Rectangle(margin + grid, increasingheight + intervalmargin, grid, hrowmargin), strFormat1);
                    //g.DrawRectangle(blackPen, new Rectangle(margin + grid * 2, increasingheight, width - 2 * grid - 2 * margin, hrowmargin));
                    g.DrawRectangle(blackPen, new Rectangle(margin + grid, increasingheight, width - grid - 2 * margin, hrowmargin));
                    g.DrawString(contentArr[contentIndex++], font8, bru, new Rectangle(margin + grid * 2, increasingheight + intervalmargin, width - 2 * grid - 2 * margin, hrowmargin), strFormat1);
                }
                else
                {
                    g.DrawRectangle(blackPen, new Rectangle(margin + grid, increasingheight, width - grid - 2 * margin, hrowmargin));
                    Font difffont;
                    switch (i)
                    {
                        case 1:
                            difffont = font12;
                            break;
                        case 5:
                            difffont = font12;
                            break;
                        default:
                            difffont = font8;
                            break;
                    }
                    g.DrawString(contentArr[contentIndex++], difffont, bru, new Rectangle(margin + grid, increasingheight + intervalmargin, width - grid - 2 * margin, hrowmargin), strFormat1);

                }

                increasingheight += hrowmargin;
            }
            int bzinitalheight = increasingheight;

            g.DrawString(q(Msg_Type.printbz) + ": " + PrintHead.CLPBDM, font10, bru, new Rectangle(margin, increasingheight + 2, width - 2 * grid, hrowmargin), strFormat1);
            byte[] bytes = ServicModel.BarCode.CreateBarCode(PrintHead.TM, "QRCODE", 70, 70, 1);
            MemoryStream ms = new MemoryStream(bytes);
            Image returnImage = Image.FromStream(ms);
            g.DrawImage(returnImage, margin + 2 * grid + width / 6, increasingheight + 10, 70, 70);
            g.DrawString(PrintHead.TM, font8, bru, 2 * grid + 5 + width / 6, increasingheight + 80);
            increasingheight += hrowmargin;
            string bzcontent = "";
            if (PrintHead.WLLBNAME == "密封圈") //无腔号 or 颜色
            {
                if (!string.IsNullOrEmpty(PrintHead.WQH)) bzcontent = q(Msg_Type.printwqh) + PrintHead.WQH;//"无腔号:"
            }
            else if (PrintHead.WLLBNAME == "绝缘圈")
            {
                if (!string.IsNullOrEmpty(PrintHead.MFQCOLORNAME)) bzcontent = q(Msg_Type.printys) + PrintHead.MFQCOLORNAME;//"颜色："
            }
            SizeF sizefbzcontent = g.MeasureString(bzcontent, font8);
            int bzcontentline = (int)Math.Ceiling(sizefbzcontent.Width / (grid * 3 - 20));
            g.DrawString(bzcontent, font8, bru, new Rectangle(margin, increasingheight, 2 * grid - 20, hrowmargin * bzcontentline));
            increasingheight += hrowmargin * bzcontentline;
            string bz = PrintHead.REMARK;
            SizeF sizefbz = g.MeasureString(bz, font8);
            int bzline = (int)Math.Ceiling(sizefbz.Width / (grid * 3 - 50));
            //g.DrawString("备注", font8, bru, new Rectangle(margin, increasingheight, 2 * grid, hrowmargin ));
            g.DrawString(bz, font8, bru, new Rectangle(margin, increasingheight, 3 * grid - 50, hrowmargin * bzline));
            int bzheight = hrowmargin + hrowmargin * bzcontentline + hrowmargin * bzline + 5;
            bzheight = bzheight > 95 ? bzheight : 95;
            g.DrawRectangle(blackPen, new Rectangle(margin, bzinitalheight, width - 2 * margin, bzheight));
            //g.DrawLine(blackPen, margin + grid - 30, rowmargin * 0 + 70 + 13 + h1 - subWidth, margin + width, rowmargin * 0 + 70 + 13 + h1 - subWidth);
        }
        private void DrawZSWLBSK(PrintPageEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 1);
            Pen pen2 = new Pen(Color.Black, 1);
            //pen2.DashStyle = DashStyle.Custom;
            pen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            pen2.DashPattern = new float[] { 1f, 1f };
            Font font18 = new Font(q(Msg_Type.fonttype), 18);
            Font font32 = new Font(q(Msg_Type.fonttype), 32, FontStyle.Bold);
            Font font28 = new Font(q(Msg_Type.fonttype), 28, FontStyle.Bold);
            Font font14 = new Font(q(Msg_Type.fonttype), 14, FontStyle.Bold);
            Font font20 = new Font(q(Msg_Type.fonttype), 20, FontStyle.Bold);
            Font font22 = new Font(q(Msg_Type.fonttype), 22, FontStyle.Bold);
            Font font12 = new Font(q(Msg_Type.fonttype), 12);
            Font font17 = new Font(q(Msg_Type.fonttype), 17, FontStyle.Bold);
            Font font10 = new Font(q(Msg_Type.fonttype), 10);
            Font font8 = new Font(q(Msg_Type.fonttype), 8);
            Font font5 = new Font(q(Msg_Type.fonttype), 5);
            Brush bru = Brushes.Black;
            Graphics g = e.Graphics;//画布
            StringFormat strFormat = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat.Alignment = StringAlignment.Center;//水平居中
            StringFormat strFormat1 = new StringFormat();
            strFormat1.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat1.Alignment = StringAlignment.Near;//水平居中

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;//抗锯齿        
            int width = 827;
            //int height = 565;
            int increasingheight = 5;
            int hrowmargin = 25;
            int margin = 5;
            int width100 = 100;
            int width200 = 200;
            int width300 = 300;
            int width370 = 370;
            int width470 = 470;
            int width600 = 600;
            int width770 = 770;
            int rowheight = 40;
            int intervalmargin = 2;
            g.DrawString(string.Format(q(Msg_Type.printbhformat),"QR-JS-130 A/0"), font10, bru, 0, increasingheight);
            if (PrintHead.CPTYPENAME == "试样")//如果是试样
            {
                g.DrawRectangle(blackPen, new Rectangle(width - 150, increasingheight, 90, 50));
                g.DrawString(PrintHead.CPTYPENAME, font17, bru, new Rectangle(width - 150, increasingheight, 90, 50), strFormat);
            }
            increasingheight += hrowmargin;
            g.DrawString(q(Msg_Type.printwlbsk), font28, bru, new Rectangle(0, increasingheight, width, 50), strFormat);
            increasingheight += 50;
            string scdate = Convert.ToDateTime(PrintHead.KSTIME).ToString("yy.MM.dd HH:mm").ToString() + " - " + Convert.ToDateTime(PrintHead.JSTIME).ToString("yy.MM.dd HH:mm").ToString();
            string[] contentArr = new string[] {q(Msg_Type.printwlbm),PrintHead.WLH,q(Msg_Type.printwlms),PrintHead.WLMS ,q(Msg_Type.printsl),PrintHead.SL.ToString("0.####") + " " + PrintHead.UNITSNAME,
            q(Msg_Type.printxs),PrintHead.GLTMCOUNT.ToString(),q(Msg_Type.printmjh),PrintHead.MOULD,q(Msg_Type.printpc),PrintHead.PC,q(Msg_Type.printscrq),scdate,q(Msg_Type.printcpzt),PrintHead.CPZTNAME};
            //string[] contentArr = new string[] {"物料编码",PrintHead.WLH,"物料描述",PrintHead.WLMS ,"数量",PrintHead.SL + " " + PrintHead.UNITSNAME,
            //"箱数",PrintHead.GLTMCOUNT.ToString(),"模具号",PrintHead.MOULD,"批次",PrintHead.PC,"生产日期",scdate,"产品状态",PrintHead.CPZTNAME};
            int contentIndex = 0;
            for (int i = 0; i < 6; i++)
            {
                if (i == 0 )
                {
                    g.DrawRectangle(blackPen, new Rectangle(margin, increasingheight, width100, rowheight));
                    g.DrawString(contentArr[contentIndex++], font14, bru, new Rectangle(margin, increasingheight + intervalmargin, width100, rowheight), strFormat1);
                    g.DrawRectangle(blackPen, new Rectangle(margin + width100, increasingheight, width200, rowheight));
                    g.DrawString(contentArr[contentIndex++], font14, bru, new Rectangle(margin + width100, increasingheight + intervalmargin, width200, rowheight), strFormat1);
                    g.DrawRectangle(blackPen, new Rectangle(margin + width100 + width200, increasingheight, width100, rowheight));
                    g.DrawString(contentArr[contentIndex++], font14, bru, new Rectangle(margin + width100 + width200, increasingheight + intervalmargin, width100, rowheight), strFormat1);
                    g.DrawRectangle(blackPen, new Rectangle(margin + width100 * 2 + width200, increasingheight, width370, rowheight));
                    g.DrawString(contentArr[contentIndex++], font14, bru, new Rectangle(margin + width100 * 2 + width200, increasingheight + intervalmargin, width370, rowheight), strFormat1);

                }
                else if (i == 1)
                {
                    g.DrawRectangle(blackPen, new Rectangle(margin, increasingheight, width100, rowheight));
                    g.DrawString(contentArr[contentIndex++], font14, bru, new Rectangle(margin, increasingheight + intervalmargin, width100, rowheight), strFormat1);
                    g.DrawRectangle(blackPen, new Rectangle(margin + width100, increasingheight, width200, rowheight));
                    g.DrawString(contentArr[contentIndex++], font20, bru, new Rectangle(margin + width100, increasingheight + intervalmargin, width200, rowheight), strFormat1);
                    g.DrawRectangle(blackPen, new Rectangle(margin + width100 + width200, increasingheight, width100, rowheight));
                    g.DrawString(contentArr[contentIndex++], font14, bru, new Rectangle(margin + width100 + width200, increasingheight + intervalmargin, width100, rowheight), strFormat1);
                    g.DrawRectangle(blackPen, new Rectangle(margin + width100 * 2 + width200, increasingheight, width370, rowheight));
                    g.DrawString(contentArr[contentIndex++], font14, bru, new Rectangle(margin + width100 * 2 + width200, increasingheight + intervalmargin, width370, rowheight), strFormat1);
                }
                else
                {
                    g.DrawRectangle(blackPen, new Rectangle(margin, increasingheight, width300, rowheight));
                    g.DrawString(contentArr[contentIndex++], font14, bru, new Rectangle(margin, increasingheight + intervalmargin, width300, rowheight), strFormat1);
                    g.DrawRectangle(blackPen, new Rectangle(margin + width300, increasingheight, width470, rowheight));
                    if (contentIndex == 9 || contentIndex == 11)
                    {
                        g.DrawString(contentArr[contentIndex++], font22, bru, new Rectangle(margin + width300, increasingheight + intervalmargin, width470, rowheight), strFormat1);
                    }
                    else if (contentIndex == 13)
                    {
                        g.DrawString(contentArr[contentIndex++], font20, bru, new Rectangle(margin + width300, increasingheight + intervalmargin, width470, rowheight), strFormat1);
                    }else
                    {
                        g.DrawString(contentArr[contentIndex++], font14, bru, new Rectangle(margin + width300, increasingheight + intervalmargin, width470, rowheight), strFormat1);
                    }
                   
                }
                increasingheight += rowheight;
            }
            int bzheight = 20;
            g.DrawString(q(Msg_Type.printbz), font10, bru, new Rectangle(margin, increasingheight + intervalmargin + 10, 40, hrowmargin));
            //increasingheight = increasingheight + intervalmargin + 10 + rowheight;
            bzheight += 10;
            if (!string.IsNullOrEmpty(PrintHead.CLPBDM))
            {
                g.DrawString(q(Msg_Type.printclpbdm) + PrintHead.CLPBDM, font12, bru, new Rectangle(margin, increasingheight + bzheight, width470, hrowmargin));
                bzheight += 20;
            }
            if (!string.IsNullOrEmpty(PrintHead.MFQCOLORNAME))
            {
                g.DrawString(q(Msg_Type.printys) + PrintHead.MFQCOLORNAME, font12, bru, new Rectangle(margin, increasingheight + bzheight, width470, hrowmargin));
                bzheight += 20;
            }

            string bzcontent = PrintHead.REMARK;
            SizeF sizef = g.MeasureString(bzcontent, font12);
            int bzcontentline = (int)Math.Ceiling(sizef.Width / width600);
            g.DrawString(bzcontent, font12, bru, new Rectangle(margin, increasingheight + bzheight, width600, hrowmargin * bzcontentline));
            byte[] bytes = ServicModel.BarCode.CreateBarCode(PrintHead.TM, "QRCODE", 70, 70, 1);
            MemoryStream ms = new MemoryStream(bytes);
            Image returnImage = Image.FromStream(ms);
            g.DrawImage(returnImage, margin + width600 + 70, increasingheight + 40, 70, 70);
            g.DrawString(PrintHead.TM, font8, bru, margin + width600 + 70, increasingheight + 110);

            g.DrawRectangle(blackPen, new Rectangle(margin, increasingheight, width770, 200));

        }

        private void lotTempelte(PrintPageEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 1);
            Font font22 = new Font(q(Msg_Type.fonttype), 22);
            Font font14 = new Font(q(Msg_Type.fonttype), 14);
            Font font9 = new Font(q(Msg_Type.fonttype), 12);
            Font font7 = new Font(q(Msg_Type.fonttype), 10);
            Font font5 = new Font(q(Msg_Type.fonttype), 8);
            Brush bru = Brushes.Black;
            Graphics g = e.Graphics;//画布
            StringFormat strFormat = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat.Alignment = StringAlignment.Center;//水平居中

            StringFormat strFormat1 = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;//垂直居中
            strFormat.Alignment = StringAlignment.Center;//水平居中
            int width = 272;
            //int xmargin = 5;
            int hrowmargin = 20;
            int rowmargin = 18;
            int grid = width / 2;
            int bzHeight = 0;
            if (PrintChild != null)
            {
                bzHeight = 11 * rowmargin + 20 + PrintChild.Length * 45;
            }
            else
            {
                bzHeight = 11 * rowmargin + 20;
            }
            Rectangle recHead = new Rectangle(0, 10, width, hrowmargin);//矩形
            g.DrawString(PrintHead.GCDYMS, font14, bru, recHead, strFormat);
            g.DrawString("编号: JS4501A", font5, bru, 0, hrowmargin + 12);
            g.DrawString("LOT表", font7, bru, 110, hrowmargin + 10);
            for (int i = 0; i < 10; i++)
            {
                g.DrawLine(blackPen, 0, rowmargin * (i + 2) + 10, width, rowmargin * (i + 2) + 10);
            }
            for (int i = 0; i < 3; i++)
            {
                if (i != 1)
                {
                    g.DrawLine(blackPen, grid * i, rowmargin * 2 + 10, grid * i, bzHeight + 110);
                }
                else
                {
                    g.DrawLine(blackPen, width / 4, rowmargin * 2 + 10, width / 4, rowmargin * 11 + 10);
                }

            }
            g.DrawLine(blackPen, 0, bzHeight + 110, width, bzHeight + 110);
            string scrq = "";
            string scrq2 = "生产时间";
            if (RigthType == Rigth_Type.zhengjicc)
            {
                scrq = PrintHead.JLTIME;
            }
            else if (RigthType == Rigth_Type.fujicc)
            {
                scrq = Convert.ToDateTime(PrintHead.KSTIME).ToString("MM.dd HH:mm").ToString() + " - " + Convert.ToDateTime(PrintHead.JSTIME).ToString("MM.dd HH:mm").ToString();
            }
            else
            {
                if (string.IsNullOrEmpty(PrintHead.BCMS))
                {
                    scrq = PrintHead.SCDATE;
                }
                else
                {
                    scrq = PrintHead.SCDATE + "/" + PrintHead.BCMS;
                }

            }

            string[] contentArr = { "物料编码", PrintHead.WLH, "物料描述", PrintHead.WLMS, "工厂批次", PrintHead.PC, scrq2, 
                                      scrq, "提供方", PrintHead.GZZXBH + "-" + PrintHead.GZZXMS, "设备号", PrintHead.SBHMS, "数量"  , PrintHead.SL.ToString("0.##")+ " " + PrintHead.UNITSNAME, "产品状态", PrintHead.CPZTNAME, "操作工", CzlList };

            for (int i = 0; i < contentArr.Length; i++)
            {
                int index = i % 2 == 0 ? 0 : 1;
                if (index == 0)
                {
                    g.DrawString(contentArr[i], font7, bru, new Rectangle(width / 4 * index, rowmargin * 2 + 12 + rowmargin * (i / 2), width, rowmargin), strFormat1);
                }
                else
                {

                    g.DrawString(contentArr[i], font7, bru, new Rectangle(width / 4 * index, rowmargin * 2 + 12 + rowmargin * (i / 2), width, rowmargin), strFormat1);

                }

            }

            if (RigthType == Rigth_Type.zhengjicc)
            {
                string[] subArr = { "备注", "桶号:" + PrintHead.TH, "配料单号:" + PrintHead.PLDH, "配方号:" + PrintHead.PFDH, "适用产品规格" + PrintHead.SYCPGG, "适用生产线:" + PrintHead.SYSCX, "备注信息:" + PrintHead.REMARK };
                for (int i = 0; i < subArr.Length; i++)
                {
                    g.DrawString(subArr[i], font5, bru, 5, 11 * rowmargin + 25 + 15 * i);
                }

                byte[] bytes = ServicModel.BarCode.CreateBarCode(PrintHead.TM, "QRCODE", 70, 70, 1);
                MemoryStream ms = new MemoryStream(bytes);
                Image returnImage = Image.FromStream(ms);

                g.DrawImage(returnImage, 180, 11 * rowmargin + 25, 70, 70);
                g.DrawString(PrintHead.TM, font7, bru, 180, 11 * rowmargin + 25 + 80);
            }
            else if (RigthType == Rigth_Type.fujicc)
            {
                string[] subArr = { "备注", "桶号:" + PrintHead.TH, "配料单号:" + PrintHead.PLDH, "配方号:" + PrintHead.PFDH, "适用生产线:" + PrintHead.SYSCX, "视比重:" + PrintHead.SBZ + " g/ml", "备注信息:" + PrintHead.REMARK };
                for (int i = 0; i < subArr.Length; i++)
                {
                    g.DrawString(subArr[i], font5, bru, 5, 11 * rowmargin + 25 + 15 * i);
                }

                byte[] bytes = ServicModel.BarCode.CreateBarCode(PrintHead.TM, "QRCODE", 70, 70, 1);
                MemoryStream ms = new MemoryStream(bytes);
                Image returnImage = Image.FromStream(ms);

                g.DrawImage(returnImage, 180, 11 * rowmargin + 25, 70, 70);
                g.DrawString(PrintHead.TM, font7, bru, 180, 11 * rowmargin + 25 + 80);
            }
            else
            {
                for (int i = 0; i < PrintChild.Length; i++)
                {
                    g.DrawString("下层码: " + PrintChild[i].TM, font5, bru, 5, 11 * rowmargin + 15 + 45 * i);
                    g.DrawString("物料: " + PrintChild[i].WLMS + "/" + PrintChild[i].PC, font5, bru, 5, 11 * rowmargin + 30 + 45 * i);
                    g.DrawString("质量信息:" + PrintChild[i].GYSMS + "/" + PrintChild[i].SBHMS + "/" + PrintChild[i].CLCJ + "/" + PrintChild[i].GYLX, font5, bru, 5, 11 * rowmargin + 45 + 45 * i);


                }
                g.DrawString("备注:" + PrintHead.REMARK, font5, bru, 5, bzHeight);
                byte[] bytes = ServicModel.BarCode.CreateBarCode(PrintHead.TM, "QRCODE", 70, 70, 1);
                MemoryStream ms = new MemoryStream(bytes);
                Image returnImage = Image.FromStream(ms);
                g.DrawImage(returnImage, 10, bzHeight + 15, 70, 70);
                g.DrawString(PrintHead.TM, font7, bru, 10, bzHeight + 15 + 80);
            }
            //this.Close();
        }
        private void baseprintDocument_BeginPrint(object sender, PrintEventArgs e)
        {


        }
        private void DrawLot_N(PrintPageEventArgs e)
        {
            Graphics g = InitPrintSetting(e);
            Rectangle recHead = new Rectangle(0, 0, lotwidth , standardRowHeight);//矩形

            g.DrawString(PrintHead.GCDYMS, sl_font13_Bold, sl_bru, recHead, strFormatCenter_Center);
            sl_currentHeight = standardRowHeight - 2;
            g.DrawString(q(Msg_Type.printwllotb), sl_font10_Bold, sl_bru,new Rectangle(lot_margin, sl_currentHeight, lotwidth - lot_margin * 2,standardRowHeight), strFormatCenter_Center);//"物料LOT表"
            sl_currentHeight += standardRowHeight - 5;
            int imageWidth = 70, imageHeight = 70;
            Image barcodeimage = GetBarCodeImage(PrintHead.TM, imageWidth, imageHeight);
            g.DrawImage(barcodeimage, new Rectangle(lotwidth / 2 - imageWidth/2 , sl_currentHeight, imageWidth, imageHeight));
            sl_currentHeight += imageHeight;
            recHead.Y = sl_currentHeight;
            g.DrawString(PrintHead.TM, sl_font8_Bold, sl_bru, recHead, strFormatNear_Center);
            string LotNo = string.IsNullOrEmpty(PrintHead.LOTNO) ? string.Format(q(Msg_Type.printbhformat), "JS4002A") : q(Msg_Type.printbh) + PrintHead.LOTNO;//"编号: JS4002A" "编号: "
            recHead.X = lot_margin;
            g.DrawString(LotNo, sl_font8_Bold, sl_bru, recHead, strFormatFar_Near);
            if (PrintHead.TH > 0)
            {
                recHead.Y = sl_currentHeight;              
                g.DrawString(q(Msg_Type.printxh) + PrintHead.TH.ToString(), sl_font10_Bold, sl_bru, recHead, strFormatFar_Far);//"序号:"
            }
            string scrq = "";
            string scrq2 = q(Msg_Type.printscsj);// "生产时间";
            if (!string.IsNullOrEmpty(PrintHead.BCMS))
            {
                //scrq = PrintHead.SCDATE + "/" + PrintHead.BCMS;
                scrq = PrintHead.SCDATEP + "/" + PrintHead.BCMS;
            }
            else
            {
                scrq = PrintHead.SCDATEP;
            }
            sl_currentHeight += recHead.Height;

            string pc = q(Msg_Type.printgcpc);// "工厂批次";
            string pccontent = PrintHead.PC;
            if (RigthType == Rigth_Type.dczztl_cc)
            {
                pc = q(Msg_Type.printwlsx);//"物料属性";
                if (!string.IsNullOrEmpty(PrintHead.NOBILL))
                {
                    pccontent = PrintHead.NOBILL + "-" + PrintHead.NOBILLMX + "/" + PrintHead.PC;
                }
            }
            string tgf = PrintHead.GZZXBH;
            if (!string.IsNullOrEmpty(PrintHead.GZZXMS))
            {
                tgf += "-" + PrintHead.GZZXMS;
            }
            string[] contentArr = {q(Msg_Type.printwlbm) , PrintHead.WLH, q(Msg_Type.printwlms), PrintHead.WLMS, pc, pccontent, scrq2,
                                   scrq,q(Msg_Type.printtgf)  , tgf, q(Msg_Type.printsbh), PrintHead.SBHMS, q(Msg_Type.printsl),
                                   PrintHead.SL.ToString("0.##")   + " " + PrintHead.UNITSNAME,q(Msg_Type.printcpzt) , PrintHead.CPZTNAME,
                                   q(Msg_Type.printczg) , CzlList };
            DrawingTableContent(g, contentArr);

            int bigRemarkY = sl_currentHeight;
            for (int i = 0; i < PrintChild.Length; i++)
            {
                List<ChildPrint> nodes = new List<ChildPrint>();
                ChildPrint node1 = new ChildPrint();
                node1.Content = q(Msg_Type.printxcm) + PrintChild[i].TM;//"下层码"
                node1.Font = sl_font8_Bold;
                nodes.Add(node1);
                ChildPrint node2 = new ChildPrint();
                node2.Content = q(Msg_Type.printwl) + PrintChild[i].WLMS;//"物料:"
                node2.Font = sl_font10_Bold;
                nodes.Add(node2);
                if (PrintHead.WLLBNAME.Equals("集电体"))
                {
                    if (!string.IsNullOrEmpty(PrintChild[i].PC))
                    {
                        ChildPrint node3 = new ChildPrint();
                        node3.Content = q(Msg_Type.printpcxx);//"批次信息:";
                        node3.Content += PrintChild[i].PC;
                        node3.Font = sl_font10_Bold;
                        nodes.Add(node3);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(PrintChild[i].PC) || PrintChild[i].TH != 0)
                    {
                        ChildPrint node3 = new ChildPrint();
                        node3.Content = q(Msg_Type.printpcxx);// "批次信息:";
                        if (!string.IsNullOrEmpty(PrintChild[i].PC))
                        {
                            node3.Content += PrintChild[i].PC;
                            if (PrintChild[i].TH != 0)
                            {
                                node3.Content += "/" + PrintChild[i].TH.ToString();
                            }
                        }
                        else
                        {
                            node3.Content += PrintChild[i].TH.ToString();
                        }
                        node3.Font = sl_font10_Bold;
                        nodes.Add(node3);
                    }
                }
                if (PrintHead.WLLBNAME.Equals("集电体"))
                {
                    if (!string.IsNullOrEmpty(PrintChild[i].GYSMS) || !string.IsNullOrEmpty(PrintChild[i].SBHMS))
                    {
                        ChildPrint node4 = new ChildPrint();
                        node4.Font = sl_font10_Bold;
                        if (PrintChild[i].WLLBNAME.Equals("电镀铜钉"))
                        {
                            if (!string.IsNullOrEmpty(PrintChild[i].GYSMS))
                            {
                                node4.Content = q(Msg_Type.printzlxx) + PrintChild[i].GYSMS;//"质量信息:"
                                nodes.Add(node4);
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(PrintChild[i].GYSMS))
                            {
                                node4.Content = q(Msg_Type.printzlxx) + PrintChild[i].GYSMS;//"质量信息:"
                                if (!string.IsNullOrEmpty(PrintChild[i].SBHMS))
                                {
                                    node4.Content += "/" + PrintChild[i].SBHMS;
                                }
                                nodes.Add(node4);
                            }
                            else
                            {
                                node4.Content = q(Msg_Type.printzlxx) + PrintChild[i].SBHMS;//"质量信息:"
                                nodes.Add(node4);
                            }
                        }


                    }
                }
                else
                {

                    if (!string.IsNullOrEmpty(PrintChild[i].GYSMS) || !string.IsNullOrEmpty(PrintChild[i].SBHMS))
                    {
                        ChildPrint node4 = new ChildPrint();
                        node4.Font = sl_font10_Bold;

                        if (!string.IsNullOrEmpty(PrintChild[i].GYSMS))
                        {
                            node4.Content = q(Msg_Type.printzlxx) + PrintChild[i].GYSMS;//"质量信息:"
                            if (!string.IsNullOrEmpty(PrintChild[i].SBHMS))
                            {
                                node4.Content += "/" + PrintChild[i].SBHMS;
                            }

                        }
                        else
                        {
                            node4.Content = q(Msg_Type.printzlxx) + PrintChild[i].SBHMS;//"质量信息:"

                        }

                        nodes.Add(node4);

                    }

                }
                if (!PrintHead.WLLBNAME.Equals("集电体"))
                {
                    if (!string.IsNullOrEmpty(PrintChild[i].CLCJ) || !string.IsNullOrEmpty(PrintChild[i].GYLX))
                    {
                        ChildPrint node5 = new ChildPrint();
                        node5.Font = sl_font10_Bold;
                        if (!string.IsNullOrEmpty(PrintChild[i].CLCJ))
                        {
                            node5.Content = PrintChild[i].CLCJ;
                            if (!string.IsNullOrEmpty(PrintChild[i].GYLX))
                            {
                                node5.Content += "/" + PrintChild[i].GYLX;
                            }
                        }
                        else
                        {
                            node5.Content = PrintChild[i].GYLX;
                        }
                        nodes.Add(node5);
                    }
                }
                if (!string.IsNullOrEmpty(PrintChild[i].REMARK))
                {
                    ChildPrint node6 = new ChildPrint();
                    node6.Font = sl_font10_Bold;
                    node6.Content = q(Msg_Type.printbz) + ":" + PrintChild[i].REMARK;//"备注" 
                    nodes.Add(node6);
                }

                for (int j = 0; j < nodes.Count; j++)
                {
                    //g.DrawString(nodes[j].Content, nodes[j].Font, bru, margin + 5, 11 * rowmargin + addheigth - subWidth);
                    //addheigth += 15;
                    MeasureLineSize res = GetMeasureLineSize(g, nodes[j].Content, nodes[j].Font, lotwidth - 2 * lot_margin);
                    int contentheight = (int)(res.Size.Height * res.Lines);//(int)Math.Ceiling(res.Size.Height);
                    g.DrawString(nodes[j].Content, nodes[j].Font, sl_bru, new Rectangle(lot_margin, sl_currentHeight + 3, lotwidth , contentheight), strFormatCenter_Near);
                    sl_currentHeight += contentheight;
                }


            }
            string[] remarkArr = GetRemarkArray(q(Msg_Type.printbz) + PrintHead.REMARK.TrimStart('\n'));
            for (int i = 0; i < remarkArr.Length; i++)
            {
                MeasureLineSize sizenode = GetMeasureLineSize(g,remarkArr[i],sl_font8_Bold,lotwidth - 2 * lot_margin);
                int height = (int)(sizenode.Size.Height * sizenode.Lines) ;
                g.DrawString(remarkArr[i], sl_font8_Bold, sl_bru, new Rectangle(lot_margin, sl_currentHeight + 3, lotwidth, height), strFormatCenter_Near);
                sl_currentHeight += height;
            }
            
            g.DrawRectangle(sl_Pen, new Rectangle(lot_margin, bigRemarkY, lotwidth , sl_currentHeight - bigRemarkY));

              
                #endregion




            }
        private void DrawFujiLot_N(PrintPageEventArgs e)
        {
            Graphics g = InitPrintSetting(e);
            Rectangle recHead = new Rectangle(0, 0, lotwidth, standardRowHeight);//矩形
            
            g.DrawString(PrintHead.GCDYMS, sl_font13_Bold, sl_bru, recHead, strFormatCenter_Center);
            sl_currentHeight = standardRowHeight - 2;
            g.DrawString(q(Msg_Type.printwllotb), sl_font10_Bold, sl_bru, new Rectangle(lot_margin, sl_currentHeight, lotwidth - lot_margin * 2, standardRowHeight + standardRowHeight - 5), strFormatFar_Center);//"物料LOT表"
            sl_currentHeight += standardRowHeight - 5;         
            recHead.Y = sl_currentHeight;         
            string LotNo = string.IsNullOrEmpty(PrintHead.LOTNO) ? string.Format(q(Msg_Type.printbhformat), "JS4002A") : q(Msg_Type.printbh) + PrintHead.LOTNO;//"编号: JS4002A" "编号: "
            recHead.X = lot_margin;
            g.DrawString(LotNo, sl_font8_Bold, sl_bru, recHead, strFormatFar_Near);
            sl_currentHeight += recHead.Height;
            string scrq = "";
            string scrq2 = q(Msg_Type.printscsj);//"生产时间";

            //scrq = Convert.ToDateTime(PrintHead.JSTIME).ToString("yyyy-MM-dd HH:mm");
            scrq = PrintHead.SCDATEP; //+ " " + scrq.Split(' ')[1];

            string tgf = PrintHead.GZZXBH;
            if (!string.IsNullOrEmpty(PrintHead.GZZXMS))
            {
                tgf += "-" + PrintHead.GZZXMS;
            }
            string[] contentArr = {q(Msg_Type.printwlbm), PrintHead.WLH, q(Msg_Type.printwlms), PrintHead.WLMS, q(Msg_Type.printgcpc), PrintHead.PC, scrq2,
                                      scrq, q(Msg_Type.printtgf), tgf,q(Msg_Type.printsbh), PrintHead.SBHMS, q(Msg_Type.printsl), PrintHead.SIZENAME + " " + PrintHead.UNITSNAME, q(Msg_Type.printcpzt), PrintHead.CPZTNAME, q(Msg_Type.printczg), CzlList };
            int[] indexs = new int[2] { 7, 11 };
            Font[] fonts = new Font[2] { sl_font12_Bold, sl_font16_Bold };
            DrawingTableContent(g, contentArr, indexs, fonts);

            string[] subArr = { q(Msg_Type.printbz), q(Msg_Type.printth) + PrintHead.TH, q(Msg_Type.printpldh) + PrintHead.PLDH  + " "+ Convert.ToDateTime(PrintHead.JSTIME).ToString("HHmm"), q(Msg_Type.printpfh) + PrintHead.PFDH, q(Msg_Type.printsbz) + PrintHead.SBZ + " g/ml"};
            Font[] bzfonts = new Font[] {sl_font8_Bold,sl_font13_Bold,sl_font13_Bold,sl_font13_Bold,sl_font13_Bold };
            int[] bzwidths = new int[] { lotTableWidth_right , lotTableWidth_right , lotTableWidth_right + 40 , lotTableWidth_right + 26 ,lotwidth - lot_margin};
            int bigRemarkY = sl_currentHeight;
            for (int i = 0; i < subArr.Length; i++)
            {
                
                MeasureLineSize node = GetMeasureLineSize(g, subArr[i], bzfonts[i], bzwidths[i]);
                int height = (int)(node.Size.Height * node.Lines) ;
                g.DrawString(subArr[i], bzfonts[i], sl_bru, new Rectangle(lot_margin, sl_currentHeight + 2, bzwidths[i], height),strFormatCenter_Near);
                sl_currentHeight += height;
            }
            string[] remarkArr = GetRemarkArray(q(Msg_Type.printbzxx) + PrintHead.REMARK.TrimStart('\n'));
            for (int i = 0; i < remarkArr.Length; i++)
            {
                MeasureLineSize sizenode = GetMeasureLineSize(g, remarkArr[i], sl_font13_Bold, lotwidth - 2 * lot_margin);
                int height = (int)(sizenode.Size.Height * sizenode.Lines) ;
                g.DrawString(remarkArr[i], sl_font13_Bold, sl_bru, new Rectangle(lot_margin, sl_currentHeight + 3, lotwidth, height), strFormatCenter_Near);
                sl_currentHeight += height;
            }


            int imageWidth = 65, imageHeight = 65;
            Image barcodeimage = GetBarCodeImage(PrintHead.TM, imageWidth, imageHeight);
            g.DrawImage(barcodeimage, new Rectangle(lot_margin + lotTableWidth_right + 32, bigRemarkY + 3, imageWidth, imageHeight));
            g.DrawString(PrintHead.TM, sl_font7_Bold, sl_bru, new Rectangle(lot_margin + lotTableWidth_right + 25, bigRemarkY + imageHeight - 5, lotTableWidth_left, standardRowHeight), strFormatNear_Near);

            g.DrawRectangle(sl_Pen, new Rectangle(lot_margin, bigRemarkY, lotwidth, sl_currentHeight - bigRemarkY));





        }
        private void DrawZJlot_N(PrintPageEventArgs e)
        {
            #region EPSON

            Graphics g = InitPrintSetting(e);
            Rectangle recHead = new Rectangle(0, 0, lotwidth, standardRowHeight);//矩形

            g.DrawString(PrintHead.GCDYMS, sl_font13_Bold, sl_bru, recHead, strFormatCenter_Center);
            sl_currentHeight = standardRowHeight - 2;
            g.DrawString(q(Msg_Type.printwllotb), sl_font10_Bold, sl_bru, new Rectangle(lot_margin, sl_currentHeight, lotwidth - lot_margin * 2, standardRowHeight ), strFormatCenter_Center);//"物料LOT表"
            sl_currentHeight += standardRowHeight - 5;
            int imageWidth = 70, imageHeight = 70;
            Image barcodeimage = GetBarCodeImage(PrintHead.TM, imageWidth, imageHeight);
            g.DrawImage(barcodeimage, new Rectangle(lotwidth / 2 - imageWidth / 2, sl_currentHeight, imageWidth, imageHeight));
            sl_currentHeight += imageHeight;
            recHead.Y = sl_currentHeight;
            g.DrawString(PrintHead.TM, sl_font8_Bold, sl_bru, recHead, strFormatNear_Center);
            string LotNo = string.IsNullOrEmpty(PrintHead.LOTNO) ? string.Format(q(Msg_Type.printbhformat), "JS4002A") : q(Msg_Type.printbh) + PrintHead.LOTNO;//"编号: JS4002A" "编号: "
            recHead.X = lot_margin;
            g.DrawString(LotNo, sl_font8_Bold, sl_bru, recHead, strFormatFar_Near);
            
          
            sl_currentHeight += recHead.Height;
            string scrq = "";
            string scrq2 = q(Msg_Type.printscsj);//"生产时间";
            //scrq = Convert.ToDateTime(PrintHead.JLTIME).ToString("yy-MM-dd HH:mm");
            //scrq = Convert.ToDateTime(PrintHead.SCDATEP).ToString("yy-MM-dd") + " " + scrq.Split(' ')[1];
            scrq = PrintHead.SCDATEP.Substring(2, PrintHead.SCDATEP.Length - 2);// + " " + scrq.Split(' ')[1];

            string tgf = PrintHead.GZZXBH;
            if (!string.IsNullOrEmpty(PrintHead.GZZXMS))
            {
                tgf += "-" + PrintHead.GZZXMS;
            }
            string[] contentArr = {q(Msg_Type.printwlbm), PrintHead.WLH,q(Msg_Type.printwlms), PrintHead.WLMS, q(Msg_Type.printgcpc), PrintHead.PC, scrq2,
                                      scrq,q(Msg_Type.printtgf) , tgf,q(Msg_Type.printsbh), PrintHead.SBHMS, q(Msg_Type.printsl)  , PrintHead.SL.ToString("0.##") + " " + PrintHead.UNITSNAME, q(Msg_Type.printcpzt), PrintHead.CPZTNAME, q(Msg_Type.printczg), CzlList };
            
            int[] indexs = new int[2] { 7, 11 };
            Font[] fonts = new Font[2] { sl_font16_Bold, sl_font22_Bold };
            DrawingTableContent(g, contentArr, indexs, fonts);

            //string[] subArr = { q(Msg_Type.printbz), q(Msg_Type.printth) + PrintHead.TH, q(Msg_Type.printpfh) + PrintHead.PFDH, q(Msg_Type.printpldh) + PrintHead.PLDH, q(Msg_Type.printsycpgg) + PrintHead.SYCPGG, q(Msg_Type.printbzxx) + PrintHead.REMARK };           
            //g.DrawString(subArr[0], font8, bru, margin + 10, 11 * rowmargin + 12 + 15 * 0 - subWidth);
            //g.DrawString(subArr[1], font22, bru, margin + 5, 11 * rowmargin + 12 + 15 * 1 - subWidth);
            //g.DrawString(subArr[2], font22, bru, margin + 5, 11 * rowmargin + 12 + 15 + 30 * 1 - subWidth);
            //g.DrawString(subArr[3], font15, bru, margin + 8, 11 * rowmargin + 12 + 45 + 30 * 1 - subWidth);

            string[] subArr = { q(Msg_Type.printbz), q(Msg_Type.printth) + PrintHead.TH, q(Msg_Type.printpfh) + PrintHead.PFDH, q(Msg_Type.printpldh) + PrintHead.PLDH + " "+ Convert.ToDateTime(PrintHead.JLTIME).ToString("HHmm"), q(Msg_Type.printsycpgg) + PrintHead.SYCPGG };
            Font[] bzfonts = new Font[] { sl_font8_Bold, sl_font22_Bold, sl_font22_Bold, sl_font15_Bold, sl_font8_Bold};
            int[] bzwidths = new int[] { lotwidth - lot_margin  , lotwidth - lot_margin , lotwidth - lot_margin , lotwidth - lot_margin , lotwidth - lot_margin  };
            int bigRemarkY = sl_currentHeight;
            for (int i = 0; i < subArr.Length; i++)
            {
                bool excute = false;
                if (i != 4) excute = true;
                else { if (!string.IsNullOrEmpty(PrintHead.SYCPGG)) excute = true; }
                if (excute)
                {
                    MeasureLineSize node = GetMeasureLineSize(g, subArr[i], bzfonts[i], bzwidths[i]);
                    int height = (int)(node.Size.Height * node.Lines) ;
                    int margin = lot_margin;
                    if (i == 3) margin += 3;
                    else if (i == 4) margin += 5;
                    else if (i == 0) margin += 5;                   
                    g.DrawString(subArr[i], bzfonts[i], sl_bru, new Rectangle(margin, sl_currentHeight , bzwidths[i], height),strFormatNear_Near);
                    sl_currentHeight += height - 2;
                }              
            }
            string[] remarkArr = GetRemarkArray(q(Msg_Type.printbzxx) + PrintHead.REMARK.TrimStart('\n'));
            for (int i = 0; i < remarkArr.Length; i++)
            {
                MeasureLineSize sizenode = GetMeasureLineSize(g, remarkArr[i], sl_font8_Bold, lotwidth - 2 * lot_margin);
                int height = (int)(sizenode.Size.Height * sizenode.Lines) ;
                g.DrawString(remarkArr[i], sl_font8_Bold, sl_bru, new Rectangle(lot_margin + 5, sl_currentHeight + 3, lotwidth, height), strFormatNear_Near);
                sl_currentHeight += height;
            }       
            g.DrawRectangle(sl_Pen, new Rectangle(lot_margin, bigRemarkY, lotwidth, sl_currentHeight - bigRemarkY));









            //int empty = 0;
            //if (!string.IsNullOrEmpty(PrintHead.SYCPGG))
            //{
            //    g.DrawString(subArr[4], font8, bru, margin + 10, 11 * rowmargin + 15 + 80 + 15 * 1 - subWidth);
            //    empty = 15;

            //}
            //g.DrawString(subArr[5], font8, bru, margin + 10, 11 * rowmargin + 15 + 80 + 15 * 1 + empty - subWidth);

            //empty = empty == 0 ? -15 : 0;
            ////底下边框线
            //g.DrawLine(blackPen, margin, bzHeight + 120 - subWidth + empty, 5 + margin + width, bzHeight + 120 - subWidth + empty);

            #endregion



        }
        private void Drawbblot_N(PrintPageEventArgs e)
        {
            Graphics g = InitPrintSetting(e);
            Rectangle recHead = new Rectangle(0, 0, lotwidth, standardRowHeight);//矩形

            g.DrawString(PrintHead.GCDYMS, sl_font13_Bold, sl_bru, recHead, strFormatCenter_Center);
            sl_currentHeight = standardRowHeight - 2;
            g.DrawString(q(Msg_Type.printsbjlotb), sl_font10_Bold, sl_bru, new Rectangle(lot_margin, sl_currentHeight, lotwidth - lot_margin * 2, standardRowHeight), strFormatCenter_Center);//"物料LOT表"
            sl_currentHeight += standardRowHeight - 5;
            int imageWidth = 70, imageHeight = 70;
            Image barcodeimage = GetBarCodeImage(PrintHead.TM, imageWidth, imageHeight);
            g.DrawImage(barcodeimage, new Rectangle(lotwidth / 2 - imageWidth / 2, sl_currentHeight, imageWidth, imageHeight));
            sl_currentHeight += imageHeight;
            recHead.Y = sl_currentHeight;
            g.DrawString(PrintHead.TM, sl_font8_Bold, sl_bru, recHead, strFormatNear_Center);
            string LotNo = string.IsNullOrEmpty(PrintHead.LOTNO) ? string.Format(q(Msg_Type.printbhformat), "JS4003A") : q(Msg_Type.printbh) + PrintHead.LOTNO;//"编号: JS4002A" "编号: "
            recHead.X = lot_margin;          
            recHead.Y = sl_currentHeight;

           
            g.DrawString(LotNo, sl_font8_Bold, sl_bru, recHead, strFormatFar_Near);
            g.DrawString(q(Msg_Type.printch) + PrintHead.SBHMS, sl_font8_Bold, sl_bru, recHead, strFormatFar_Far);//"车号"                     
            sl_currentHeight += recHead.Height;
            int bigRectY = sl_currentHeight;
            string slstr = PrintHead.DCSLBS.ToString() + "X" + PrintHead.DCSLMBSL.ToString();
            int sl = PrintHead.DCSLBS * PrintHead.DCSLMBSL;
            if (PrintHead.DCSLYS != 0)
            {
                if (sl != 0)
                {
                    sl = sl + PrintHead.DCSLYS;
                    slstr += "+" + PrintHead.DCSLYS + "=" + sl.ToString();
                }
                else
                {
                    slstr = PrintHead.DCSLYS.ToString();
                }

            }
            else
            {
                slstr += "=" + sl.ToString();
            }
            string wlss = "";
            if (string.IsNullOrEmpty(PrintHead.NOBILL))
            {
                wlss = PrintHead.PC;
            }
            else
            {
                wlss = PrintHead.NOBILL + "-" + PrintHead.NOBILLMX + "/" + PrintHead.PC;
            }
            string tgf = PrintHead.GZZXBH;
            if (!string.IsNullOrEmpty(PrintHead.GZZXMS))
            {
                tgf += "-" + PrintHead.GZZXMS;
            }
            bool isY = PrintHead.REMARK.Contains(q(Msg_Type.printyps));//"样品数"
            if (isY)
            {
                int ypdIndex = PrintHead.REMARK.IndexOf(q(Msg_Type.printyps));
                string ypdStr = PrintHead.REMARK.Substring(ypdIndex, PrintHead.REMARK.Length - ypdIndex);
                if (ypdStr.Contains("]"))
                {
                    int resIndex = ypdStr.IndexOf("]");
                    if (resIndex > 0)
                    {
                        slstr += "[" + ypdStr.Substring(0, resIndex) + "]";
                    }
                }
            }
            string scdate = PrintHead.SCDATEP;

            string[] contentArr = { q(Msg_Type.printwlbm), PrintHead.WLH, q(Msg_Type.printwlms), PrintHead.WLMS,
                q(Msg_Type.printwlsx), wlss, q(Msg_Type.printtgf), tgf,
                q(Msg_Type.printddsl), PrintHead.GDSL.ToString("0.##"), q(Msg_Type.printscrq), scdate,
                q(Msg_Type.printbbpm), PrintHead.RQM,
                q(Msg_Type.printwcrq),PrintHead.VDATU,
                q(Msg_Type.printhgx), PrintHead.XDGXNAME,q(Msg_Type.printzhuangtai), PrintHead.CPZTNAME, q(Msg_Type.printzh), PrintHead.TH.ToString(),
                q(Msg_Type.printbzsl), slstr,                
                q(Msg_Type.printczg), CzlList};

            //margin + lotTableWidth_left - 30
            int titleWidth = lot_margin + lotTableWidth_left - 30;
            Rectangle tableRect_left = new Rectangle(lot_margin, sl_currentHeight, lotTableWidth_left - 30, standardTableRowHeight);
            Rectangle tableRect_rigth = new Rectangle(titleWidth, sl_currentHeight, lotTableWidth_right + 30, standardTableRowHeight);
            for (int i = 0; i < contentArr.Length; i++)
            {
                if (i  == 8)
                {
                    Rectangle rect1 = new Rectangle(lot_margin, sl_currentHeight, titleWidth, 0);
                    Rectangle rect2 = new Rectangle(titleWidth, sl_currentHeight, lotwidth/2 -  titleWidth, 0);
                    Rectangle rect3 = new Rectangle(lotwidth / 2, sl_currentHeight, titleWidth, 0);
                    Rectangle rect4 = new Rectangle(lotwidth / 2 + titleWidth,sl_currentHeight, lotwidth - lotwidth / 2 - titleWidth, 0);

                    MeasureLineSize m1 = GetMeasureLineSize(g, contentArr[i++], sl_font8_Bold, titleWidth );
                    MeasureLineSize m2 = GetMeasureLineSize(g, contentArr[i++], sl_font8_Bold, lotwidth / 2 -  titleWidth);
                    MeasureLineSize m3 = GetMeasureLineSize(g, contentArr[i++], sl_font8_Bold, titleWidth);
                    MeasureLineSize m4 = GetMeasureLineSize(g, contentArr[i], sl_font8_Bold, lotwidth - lotwidth / 2 + titleWidth);
                    int height = GetMaxLine((int)(m1.Size.Height * m1.Lines) , (int)(m2.Size.Height * m2.Lines) , (int)(m3.Size.Height * m3.Lines) , (int)(m4.Size.Height * m4.Lines) );
                    rect1.Height = height + 2;
                    rect2.Height = height + 2;
                    rect3.Height = height + 2;
                    rect4.Height = height + 2;
                    
                    i -= 3;
                    g.DrawString(contentArr[i++], sl_font8_Bold, sl_bru, rect1, strFormatFar_Near);
                    g.DrawLine(sl_Pen,  titleWidth, sl_currentHeight + height, lotwidth / 2, sl_currentHeight + height);
                    g.DrawString(contentArr[i++], sl_font8_Bold, sl_bru, rect2, strFormatFar_Near);
                    g.DrawString(contentArr[i++], sl_font8_Bold, sl_bru, rect3, strFormatFar_Center);
                    g.DrawLine(sl_Pen, lotwidth / 2  + titleWidth, sl_currentHeight + height,   lotwidth, sl_currentHeight + height);
                    g.DrawString(contentArr[i], sl_font8_Bold, sl_bru, rect4, strFormatFar_Near);
                    sl_currentHeight += height;
                    tableRect_left.Y = sl_currentHeight;
                    tableRect_rigth.Y = sl_currentHeight;
                }
                else if (i ==16)
                {
                    int width = 36; int width1 = 44;
                    Rectangle rect1 = new Rectangle(lot_margin, sl_currentHeight, titleWidth, 0);
                    Rectangle rect2 = new Rectangle(titleWidth, sl_currentHeight, lotwidth / 2 -  titleWidth, 0);
                    Rectangle rect3 = new Rectangle(lotwidth / 2, sl_currentHeight, width, 0);
                    Rectangle rect4 = new Rectangle(lotwidth / 2 + width, sl_currentHeight, width1, 0);
                    Rectangle rect5 = new Rectangle(lotwidth / 2 + width + width1, sl_currentHeight, width, 0);
                    Rectangle rect6 = new Rectangle(lotwidth / 2 + width + width1 + width, sl_currentHeight, width, 0);
                    MeasureLineSize m1 = GetMeasureLineSize(g, contentArr[i++], sl_font8_Bold, titleWidth);
                    MeasureLineSize m2 = GetMeasureLineSize(g, contentArr[i++], sl_font8_Bold, lotwidth / 2 -  titleWidth);
                    MeasureLineSize m3 = GetMeasureLineSize(g, contentArr[i++], sl_font8_Bold, width);
                    MeasureLineSize m4 = GetMeasureLineSize(g, contentArr[i++], sl_font8_Bold, width1);
                    MeasureLineSize m5 = GetMeasureLineSize(g, contentArr[i++], sl_font8_Bold, width);
                    MeasureLineSize m6 = GetMeasureLineSize(g, contentArr[i], sl_font8_Bold, width);
                    int height = GetMaxLine((int)(m1.Size.Height * m1.Lines) , (int)(m2.Size.Height * m2.Lines) , (int)(m3.Size.Height * m3.Lines) , (int)(m4.Size.Height * m4.Lines) , (int)(m5.Size.Height * m5.Lines) , (int)(m6.Size.Height * m6.Lines) );
                    rect1.Height = height + 2;
                    rect2.Height = height + 2;
                    rect3.Height = height + 2;
                    rect4.Height = height + 2;
                    rect5.Height = height + 2;
                    rect6.Height = height + 2;
                    i -= 5;
                    g.DrawString(contentArr[i++], sl_font8_Bold, sl_bru, rect1, strFormatFar_Near);
                    g.DrawLine(sl_Pen, titleWidth, sl_currentHeight + +height, lotwidth / 2, sl_currentHeight + height);
                    g.DrawString(contentArr[i++], sl_font8_Bold, sl_bru, rect2, strFormatFar_Center);
                    g.DrawString(contentArr[i++], sl_font8_Bold, sl_bru, rect3, strFormatFar_Near);
                    g.DrawLine(sl_Pen, lotwidth / 2 + width, sl_currentHeight + height, lotwidth / 2 + width + width1, sl_currentHeight + height);
                    g.DrawString(contentArr[i++], sl_font8_Bold, sl_bru, rect4, strFormatFar_Near);
                    g.DrawString(contentArr[i++], sl_font8_Bold, sl_bru, rect5, strFormatFar_Near);
                    g.DrawString(contentArr[i], sl_font8_Bold, sl_bru, rect6, strFormatFar_Near);
                    g.DrawLine(sl_Pen, lotwidth / 2 + width1 + width + width , sl_currentHeight + height, lotwidth, sl_currentHeight + height);
                    sl_currentHeight += height;
                    tableRect_left.Y = sl_currentHeight;
                    tableRect_rigth.Y = sl_currentHeight;

                }
                else
                {
                    MeasureLineSize left = GetMeasureLineSize(g, contentArr[i++], sl_font8_Bold, lotTableWidth_left);
                    MeasureLineSize right = GetMeasureLineSize(g, contentArr[i], sl_font8_Bold, lotTableWidth_right);
                    int maxLine = GetMaxLine(left.Lines, right.Lines);
                    SizeF size = left.Lines == maxLine ? left.Size : right.Size;
                    tableRect_left.Height = (int)(size.Height * maxLine);
                    tableRect_rigth.Height = (int)(size.Height * maxLine);
                    sl_currentHeight += tableRect_left.Height;
                    tableRect_left.Y += 2;//矩阵-2的目的是显示文字的时候中心位置会偏上，内容输出以后在减去对应的-2；
                    tableRect_rigth.Y += 2;
                    g.DrawString(contentArr[--i], sl_font8_Bold, sl_bru, tableRect_left, strFormatCenter_Near);
                    g.DrawString(contentArr[++i], sl_font8_Bold, sl_bru, tableRect_rigth, strFormatCenter_Near);
                    g.DrawLine(sl_Pen, titleWidth, sl_currentHeight, lotwidth, sl_currentHeight);
                    tableRect_left.Y -= 2;
                    tableRect_rigth.Y -= 2;
                    tableRect_left.Y = sl_currentHeight;
                    tableRect_rigth.Y = sl_currentHeight;
                }
                
            }
            sl_currentHeight += 2;
            MeasureLineSize bznode = GetMeasureLineSize(g, q(Msg_Type.printbz), sl_font8_Bold, lotwidth - lot_margin);
            g.DrawString(q(Msg_Type.printbz), sl_font8_Bold, sl_bru, new Rectangle(lot_margin, sl_currentHeight, lotwidth - lot_margin, (int)Math.Ceiling(bznode.Size.Height)), strFormatCenter_Near);
            sl_currentHeight += (int)(bznode.Size.Height * bznode.Lines);
           
            for (int i = 0; i < PrintChild.Length; i++)
            {
                string xcmStr = q(Msg_Type.printxcm) + PrintChild[i].TM;
                if (!string.IsNullOrEmpty(PrintChild[i].ZFDCLBNAME))
                {
                    xcmStr += " [" + PrintChild[i].ZFDCLBNAME + "]";
                }
                string wlxx = q(Msg_Type.printwl) + PrintChild[i].WLH + "/" + PrintChild[i].WLMS;
                string zlxx = string.IsNullOrEmpty(PrintChild[i].GZZXBH) ? q(Msg_Type.printwlxx) + PrintChild[i].GYSMS + "/" + PrintChild[i].PC : q(Msg_Type.printzlxx) + PrintChild[i].TH + "/" + PrintChild[i].SBHMS + "/" + PrintChild[i].SCDATEP;


                MeasureLineSize node1 = GetMeasureLineSize(g, xcmStr,sl_font8_Bold, lotwidth );
                int height1 = (int)(node1.Size.Height * node1.Lines);               
                g.DrawString(xcmStr, sl_font8_Bold, sl_bru, new Rectangle(lot_margin, sl_currentHeight ,lotwidth  - lot_margin, height1), strFormatFar_Near);
                sl_currentHeight += height1 ;
                MeasureLineSize node2 = GetMeasureLineSize(g, wlxx, sl_font8_Bold, lotwidth );
                int height2 = (int)(node2.Size.Height * node2.Lines) ;
                g.DrawString(wlxx, sl_font8_Bold, sl_bru, new Rectangle(lot_margin, sl_currentHeight, lotwidth - lot_margin, height2), strFormatFar_Near);
                sl_currentHeight += height2;
                MeasureLineSize node3 = GetMeasureLineSize(g, zlxx, sl_font8_Bold, lotwidth );
                int height3 = (int)(node3.Size.Height * node3.Lines) ;
                g.DrawString(zlxx, sl_font8_Bold, sl_bru, new Rectangle(lot_margin, sl_currentHeight, lotwidth - lot_margin, height3), strFormatFar_Near);
                sl_currentHeight += height3;



                string xcmbzxx = q(Msg_Type.printxcbzxx) + PrintChild[i].REMARK.TrimStart('\n');
                string[] xcmbzxxList = GetRemarkArray(xcmbzxx);//xcmbzxx.Split('\n');



                for (int j = 0; j < xcmbzxxList.Length; j++)
                {
                    if (xcmbzxxList[j].Length != 0 && !xcmbzxxList[j].Trim().Equals(q(Msg_Type.printxcbzxx).Trim()))
                    {                      
                        //int lines = (int)Math.Ceiling(sizef.Width / (lotwidth - lot_margin));
                        MeasureLineSize xcbzsize = GetMeasureLineSize(g, xcmbzxxList[j], sl_font8_Bold, lotwidth);
                        int height = (int)(xcbzsize.Size.Height * xcbzsize.Lines);
                        g.DrawString(xcmbzxxList[j], sl_font8_Bold, sl_bru, new Rectangle(lot_margin, sl_currentHeight, lotwidth, height), strFormatNear_Near);
                        //g.DrawString("下层备注信息:" + PrintChild[i].REMARK, font5, bru, margin, 10 + (beginChild + 3) * rowmargin + 65 + 65 * i - subWidth);
                        sl_currentHeight += height;
                    }
                }


            }
            string[] remarkArr = GetRemarkArray(q(Msg_Type.printbzxx) + PrintHead.REMARK.TrimStart('\n'));
            for (int i = 0; i < remarkArr.Length; i++)
            {
                MeasureLineSize sizenode = GetMeasureLineSize(g, remarkArr[i], sl_font8_Bold, lotwidth - 2 * lot_margin);
                int height = (int)(sizenode.Size.Height * sizenode.Lines) ;
                g.DrawString(remarkArr[i], sl_font8_Bold, sl_bru, new Rectangle(lot_margin, sl_currentHeight + 3, lotwidth, height), strFormatCenter_Near);
                sl_currentHeight += height;
            }
            g.DrawRectangle(sl_Pen, new Rectangle(lot_margin, bigRectY, lotwidth, sl_currentHeight - bigRectY));
           

        }
        public void DrawWLRKLOT_N(PrintPageEventArgs e)
        {
            Graphics g = InitPrintSetting(e);
            Rectangle recHead = new Rectangle(0, 0, lotwidth, standardRowHeight);//矩形

            g.DrawString(PrintHead.GCDYMS, sl_font13_Bold, sl_bru, recHead, strFormatCenter_Center);
            sl_currentHeight = standardRowHeight - 2;
            g.DrawString(q(Msg_Type.printtbsspace), sl_font8_Bold, sl_bru, new Rectangle(lot_margin, sl_currentHeight, lotwidth - lot_margin * 2, 16), strFormatCenter_Center);//"物料LOT表"
            sl_currentHeight += 12;
            int imageWidth = 70, imageHeight = 70;
            Image barcodeimage = GetBarCodeImage(PrintHead.TM, imageWidth, imageHeight);
            g.DrawImage(barcodeimage, new Rectangle(lotwidth / 2 - imageWidth / 2, sl_currentHeight, imageWidth, imageHeight));
            sl_currentHeight += imageHeight;
            recHead.Y = sl_currentHeight;
            g.DrawString(PrintHead.TM, sl_font8_Bold, sl_bru, recHead, strFormatNear_Center);
            sl_currentHeight += recHead.Height;
            recHead.X = lot_margin;

          
            g.DrawString(q(Msg_Type.printtuohao) + PrintHead.TH.ToString(), sl_font14_Bold, sl_bru, new Rectangle(lot_margin,sl_currentHeight - 30,lotwidth,30), strFormatFar_Far);//"序号:"                
            

            string[] headlineArr = { q(Msg_Type.printwlbm), q(Msg_Type.printwlms), q(Msg_Type.printgcpc), q(Msg_Type.printzydh), q(Msg_Type.printrkrq), q(Msg_Type.printtgf), q(Msg_Type.printsl), q(Msg_Type.printckdjno) };
            //string[] headlineArr = { "物料编码", "物料描述", "工厂批次", "作业单号", "入库日期", "提供方", "数量", "参考单据" };
            string zydh = "";
            if (!string.IsNullOrEmpty(PrintHead.NOBILL))
            {
                zydh = PrintHead.NOBILL + "-" + PrintHead.NOBILLMX;
            }
            string sl = "";
            if (!string.IsNullOrEmpty(PrintHead.SL.ToString()) && PrintHead.SL != 0)
            {
                sl = PrintHead.SL.ToString("0.##") + " " + PrintHead.UNITSNAME;
            }                    
            string tgf = PrintHead.GYSMS;          
            string ckdj = "";
            if (!string.IsNullOrEmpty(PrintHead.WLPZBH))
            {
                ckdj += PrintHead.WLPZBH + "/" + PrintHead.WLPZH + "(" + PrintHead.WLPZND + ")";
                if (!string.IsNullOrEmpty(PrintHead.CGBILL))
                {
                    ckdj += "-" + PrintHead.CGBILL + "/" + PrintHead.CGBILLMX;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(PrintHead.CGBILL))
                {
                    ckdj += PrintHead.CGBILL + "/" + PrintHead.CGBILLMX;
                }
            }
            if (Xs.Equals("0"))
            {
                Xs = "";
            }
            
            string[] contentArr = { q(Msg_Type.printwlbm), PrintHead.WLH, q(Msg_Type.printwlms), PrintHead.WLMS,
               q(Msg_Type.printgcpc), PrintHead.PC,
               q(Msg_Type.printzydh), zydh,
               q(Msg_Type.printrkrq), PrintHead.SCDATE,
               q(Msg_Type.printtgf), tgf,
               q(Msg_Type.printsl), sl,q(Msg_Type.printxs) + Xs,
               q(Msg_Type.printckdjno),ckdj };
           




            int[] indexs = new int[] { 3,5,9,11,16};
            Font[] fonts = new Font[] {sl_font8_Bold, sl_font22_Bold,sl_font13_Bold,sl_font20_Bold,sl_font8_Bold };


            Rectangle tableRect_left = new Rectangle(lot_margin, sl_currentHeight, lotTableWidth_left - 25, standardTableRowHeight);
            Rectangle tableRect_rigth = new Rectangle(lot_margin + lotTableWidth_left - 25, sl_currentHeight, lotTableWidth_right + 25, standardTableRowHeight);
            for (int i = 0; i < contentArr.Length; i++)
            {
                if (i == 12)
                {
                    Rectangle rect1 = new Rectangle(lot_margin, sl_currentHeight, lotTableWidth_left - 25, 0);
                    Rectangle rect2 = new Rectangle(lot_margin +lotTableWidth_left - 25 , sl_currentHeight, lotwidth - 170 , 0);
                    Rectangle rect3 = new Rectangle(lot_margin + lotTableWidth_left - 25 + (lotwidth - 170), sl_currentHeight, lotwidth - 170 - lot_margin + 3, 0);
                    MeasureLineSize size1 = GetMeasureLineSize(g, contentArr[i++], sl_font10_Bold, lotTableWidth_left - 25);
                    MeasureLineSize size2 = GetMeasureLineSize(g, contentArr[i++], sl_font10_Bold, lotwidth - 170);
                    MeasureLineSize size3 = GetMeasureLineSize(g, contentArr[i], sl_font10_Bold, lotwidth - 170);
                    int height = GetMaxLine((int)(size1.Size.Height * size1.Lines),  (int)(size2.Size.Height * size2.Lines),  (int)(size3.Size.Height * size3.Lines ));                  
                    rect1.Height = height;
                    rect2.Height = height;
                    rect3.Height = height;
                    g.DrawRectangle(sl_Pen, rect1);
                    g.DrawRectangle(sl_Pen, rect2);
                    g.DrawRectangle(sl_Pen, rect3);
                    rect3.Y += 2; rect2.Y += 2; rect1.Y += 2;
                    i -= 2;
                    g.DrawString(contentArr[i++], sl_font10_Bold, sl_bru, rect1, strFormatNear_Near);
                    g.DrawString(contentArr[i++], sl_font10_Bold, sl_bru, rect2, strFormatNear_Near);
                    g.DrawString(contentArr[i], sl_font10_Bold, sl_bru, rect3, strFormatNear_Near);
                   
                    sl_currentHeight += height;
                    tableRect_left.Y = sl_currentHeight;
                    tableRect_rigth.Y = sl_currentHeight;
                }
                else
                {
                    int index = indexs.ToList().IndexOf(i + 1);
                    Font rightfont = index == -1 ? sl_font10_Bold : fonts[index];
                    MeasureLineSize left = GetMeasureLineSize(g, contentArr[i++], sl_font10_Bold, lotTableWidth_left -25);
                    MeasureLineSize right = GetMeasureLineSize(g, contentArr[i], rightfont, lotTableWidth_right + 25);
                    int height_right = (int)(left.Size.Height * left.Lines);
                    int height_left = (int)(right.Size.Height * right.Lines);
                    int maxheight = height_right > height_left ? height_right : height_left;
                    tableRect_left.Height = maxheight;
                    tableRect_rigth.Height = maxheight;
                    g.DrawRectangle(sl_Pen, tableRect_left);
                    g.DrawRectangle(sl_Pen, tableRect_rigth);
                    sl_currentHeight += tableRect_left.Height;
                    tableRect_left.Y += 2;//矩阵-2的目的是显示文字的时候中心位置会偏上，内容输出以后在减去对应的-2；
                    tableRect_rigth.Y += 2;
                    g.DrawString(contentArr[--i], sl_font10_Bold, sl_bru, tableRect_left, strFormatCenter_Near);
                    g.DrawString(contentArr[++i], rightfont, sl_bru, tableRect_rigth, strFormatCenter_Near);
                    tableRect_left.Y -= 2;
                    tableRect_rigth.Y -= 2;
                    tableRect_left.Y = sl_currentHeight;
                    tableRect_rigth.Y = sl_currentHeight;
                }
                
            }
            int bigRemarkY = sl_currentHeight;
            g.DrawString(q(Msg_Type.printbz), sl_font10_Bold, sl_bru, new Rectangle(lot_margin, sl_currentHeight, lotwidth, 18), strFormatFar_Near);
            sl_currentHeight += 18;
            List<string> zlArr = new List<string>();
            if (!string.IsNullOrEmpty(PrintHead.SBHMS))
            {
                zlArr.Add(q(Msg_Type.printsbh) + PrintHead.SBHMS);
               
            }
            if (!string.IsNullOrEmpty(PrintHead.CLCJ))
            {
                zlArr.Add(q(Msg_Type.printclcj) + PrintHead.CLCJ);//"材料厂家:"
            }
            if (!string.IsNullOrEmpty(PrintHead.GYLX))
            {
                zlArr.Add(q(Msg_Type.printgylx) + PrintHead.GYLX);//"工艺路线:"
            }
            if (!string.IsNullOrEmpty(PrintHead.GYSPC))
            {
                zlArr.Add(q(Msg_Type.printgyspc) + PrintHead.GYSPC);//"供应商批次:"
            }
            if (!string.IsNullOrEmpty(PrintHead.REMARK))
            {
                zlArr.Add(q(Msg_Type.printbzxx) + PrintHead.REMARK);//"备注信息:" 
            }
          
            for (int i = 0; i < zlArr.Count; i++)
            {
                if (zlArr[i].StartsWith(q(Msg_Type.printsbh)))//"设备号:"
                {
                    //SizeF z = g.MeasureString(zlArr[i], font22);
                    //int lines = (int)Math.Ceiling(z.Width / (width - margin));                   
                    //g.DrawString(zlArr[i], font22, bru, new Rectangle(margin, ksheight, width - margin, font22height * lines));
                    MeasureLineSize node = GetMeasureLineSize(g, zlArr[i], sl_font22_Bold, lotwidth - lot_margin);
                    int height = (int)(node.Size.Height * node.Lines) ;
                    g.DrawString(zlArr[i], sl_font22_Bold, sl_bru, new Rectangle(lot_margin,sl_currentHeight,lotwidth, height),strFormatCenter_Near);
                    sl_currentHeight += height;

                }
                else
                {
                    MeasureLineSize node = GetMeasureLineSize(g, zlArr[i], sl_font12_Bold, lotwidth - lot_margin);
                    int height = (int)(node.Size.Height * node.Lines) ;
                    g.DrawString(zlArr[i], sl_font12_Bold, sl_bru, new Rectangle(lot_margin, sl_currentHeight, lotwidth, height), strFormatCenter_Near);
                    sl_currentHeight += height;
                              
                }
                

            }
            for (int i = 0; i < PrintChild.Length; i++)
            {
                Sonluk.UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_LIST data = PrintChild[i];
                MeasureLineSize xctmxxsize = GetMeasureLineSize(g, q(Msg_Type.printxctmxx), sl_font8_Bold, lotwidth);
                int xctmxxheight = (int)(xctmxxsize.Size.Height * xctmxxsize.Lines);
                g.DrawString(q(Msg_Type.printxctmxx), sl_font8_Bold, sl_bru, new Rectangle(lot_margin, sl_currentHeight, lotwidth, xctmxxheight));
                sl_currentHeight += xctmxxheight;
                string wlxx = q(Msg_Type.printwl) + PrintChild[i].TM + "/" + PrintChild[i].WLMS + "/" + PrintChild[i].PC;
                //SizeF z1 = g.MeasureString(wlxx, font8);
                //int lines1 = (int)Math.Ceiling(z1.Width / (width - margin));
                //g.DrawString(q(Msg_Type.printwl) + PrintChild[i].TM + "/" + PrintChild[i].WLMS + "/" + PrintChild[i].PC, font8, bru, new Rectangle(margin, ksheight, width - margin, font8height * lines1)); ksheight += font8height * lines1;
                MeasureLineSize wlxxsize = GetMeasureLineSize(g, wlxx, sl_font8_Bold, lotwidth);
                int wlxxheight =  (int)(wlxxsize.Size.Height * wlxxsize.Lines);
                g.DrawString(wlxx, sl_font8_Bold, sl_bru, new Rectangle(lot_margin, sl_currentHeight, lotwidth, wlxxheight));
                sl_currentHeight += wlxxheight;

                string xczlxx = q(Msg_Type.printzlxx);// "质量信息:";
                if (!string.IsNullOrEmpty(data.SBHMS))
                {
                    xczlxx += data.SBHMS + "/";
                }
                if (!string.IsNullOrEmpty(data.CLCJ))
                {
                    xczlxx += data.CLCJ + "/";
                }
                if (!string.IsNullOrEmpty(data.GYLX))
                {
                    xczlxx += data.GYLX + "/";
                }
                if (!string.IsNullOrEmpty(data.SBHMS) || !string.IsNullOrEmpty(data.CLCJ) || !string.IsNullOrEmpty(data.GYLX))
                {
                    xczlxx = xczlxx.Substring(0, xczlxx.Length - 1);
                }
                if (string.IsNullOrEmpty(data.SBHMS) && string.IsNullOrEmpty(data.CLCJ) && string.IsNullOrEmpty(data.GYLX))
                {
                    xczlxx = "";
                }              
                //SizeF z = g.MeasureString(xczlxx, font8);
                //int lines = (int)Math.Ceiling(z.Width / (width - margin));
                
                //g.DrawString(xczlxx, font8, bru, new Rectangle(margin, ksheight, width - margin, font8height * lines)); ksheight += (int)z1.Height + (int)z.Height;

                MeasureLineSize xczlxxsize = GetMeasureLineSize(g, xczlxx, sl_font8_Bold, lotwidth);
                int xczlxxheight =  (int)(xczlxxsize.Size.Height * xczlxxsize.Lines);
                g.DrawString(xczlxx, sl_font8_Bold, sl_bru, new Rectangle(lot_margin, sl_currentHeight, lotwidth, xczlxxheight));
                sl_currentHeight += xczlxxheight;

            }

            g.DrawRectangle(sl_Pen, new Rectangle(lot_margin, bigRemarkY, lotwidth, sl_currentHeight - bigRemarkY));


        }
        public void DrawZSWLLOT_N(PrintPageEventArgs e)
        {
            Graphics g = InitPrintSetting(e);
            g.DrawString(string.Format(q(Msg_Type.printbhformat), "QR-JS-129 A/0"), sl_font10_Bold, sl_bru, new Rectangle(5,5,lotwidth,standardRowHeight),strFormatNear_Near);
            sl_currentHeight += standardRowHeight + 5;
            if (PrintHead.CPTYPENAME == "试样")//如果是试样"试样"
            {
                g.DrawRectangle(sl_Pen, new Rectangle(lotwidth - 65, 5, 56, 31));
                g.DrawString(PrintHead.CPTYPENAME, sl_font12_Bold, sl_bru, new Rectangle(lotwidth - 65, 5 + 2, 56, 31), strFormatCenter_Center);
            }

            
            g.DrawString(q(Msg_Type.printwllotb), sl_font10_Bold, sl_bru,new Rectangle(lot_margin,sl_currentHeight,lotwidth,standardRowHeight),strFormatFar_Center);//"物料LOT表"
            sl_currentHeight += standardRowHeight + 2;
            //increasingheight += hrowmargin;
            string jzTemplete = PrintHead.JZ.ToString("0.0000");
            string jzStr = jzTemplete;//PrintHead.JZ.ToString("0.0000");
            int jzIndex = 0;
            for (int i = jzStr.Length - 1; i > 0; i--)
            {
                char node = jzStr[i];
                if (node != '0')
                {
                    jzIndex = jzStr.Length - 1 - i;
                    break;
                }
            }
            jzStr = jzStr.Substring(0, jzStr.Length - jzIndex);
            StringBuilder jzStrBuilder = new StringBuilder(jzStr);
            for (int i = jzTemplete.Length - jzIndex; i < jzTemplete.Length ; i++)
            {
                jzStrBuilder.Append(' ');
            }
            

            string[] contentArr = new string[] {
            q(Msg_Type.printwlbm),PrintHead.WLH,q(Msg_Type.printwlms),PrintHead.WLMS,
            q(Msg_Type.printkssj),Convert.ToDateTime(PrintHead.KSTIME).ToString("yy.MM.dd  HH:mm"),
            q(Msg_Type.printjssj),Convert.ToDateTime(PrintHead.JSTIME).ToString("yy.MM.dd  HH:mm"),
            q(Msg_Type.printsbh),PrintHead.SBHMS,
            q(Msg_Type.printmjh),PrintHead.MOULD,
            q(Msg_Type.printsl),PrintHead.SL.ToString("0.####") + " " + PrintHead.UNITSNAME,
            q(Msg_Type.printjz),jzStrBuilder.ToString() + " kg",
            q(Msg_Type.printcpzt),PrintHead.CPZTNAME,q(Msg_Type.printczg),CzlList};

            int[] indexs = new int[] { 3, 5, 7, 11 , 13};
            Font[] fonts = new Font[] { sl_font12_Bold, sl_font16_Bold, sl_font16_Bold, sl_font22_Bold , sl_font16_Bold };
            DrawingTableContent(g, contentArr, indexs, fonts);
            int bigRemarkY = sl_currentHeight;
            sl_currentHeight += 2;
            int imageWidth = 70, imageHeight = 70;
            Image barcodeimage = GetBarCodeImage(PrintHead.TM, imageWidth, imageHeight);
            g.DrawImage(barcodeimage, new Rectangle(lotTableWidth_right + 15  + lot_margin , sl_currentHeight, imageWidth, imageHeight));
            
            g.DrawString(PrintHead.TM, sl_font8_Bold, sl_bru, new Rectangle(lotTableWidth_right + 15 - 5 , sl_currentHeight + imageHeight, lotTableWidth_left, 15), strFormatNear_Center);



            string bzcontent = q(Msg_Type.printbz) + ": "  + PrintHead.CLPBDM;
            MeasureLineSize bzcontentsize = GetMeasureLineSize(g, bzcontent, sl_font10_Bold, lotTableWidth_right);
            int bzcontentheight = (int)(bzcontentsize.Lines * bzcontentsize.Size.Height);
            g.DrawString(bzcontent, sl_font10_Bold, sl_bru, new Rectangle(lot_margin, sl_currentHeight, lotTableWidth_right, bzcontentheight), strFormatCenter_Near);
            sl_currentHeight += bzcontentheight;
            string bzcontent1title = "";
            string bzcontent1 = "";
            int bzcontenttitlewidth = 0;
            if (PrintHead.WLLBNAME == "密封圈") //无腔号 or 颜色
            {
                
                if (!string.IsNullOrEmpty(PrintHead.WQH)) {
                    bzcontent1title = q(Msg_Type.printwqh);
                    bzcontent1 = PrintHead.WQH;//"无腔号:"
                }
                bzcontenttitlewidth = 50;
            }
            else if (PrintHead.WLLBNAME == "绝缘圈")
            {
                if (!string.IsNullOrEmpty(PrintHead.MFQCOLORNAME)) {
                    bzcontent1title = q(Msg_Type.printys);
                    bzcontent1 =  PrintHead.MFQCOLORNAME;//"颜色："
                }
                bzcontenttitlewidth = 40;
            }

            MeasureLineSize bzcontentsize1 = GetMeasureLineSize(g, bzcontent1 , sl_font12_Bold, lotTableWidth_right - 40);
            int bzcontentheight1 = (int)(bzcontentsize1.Lines * bzcontentsize1.Size.Height);
            if (!string.IsNullOrEmpty(bzcontent1title))
            {
                g.DrawString(bzcontent1title, sl_font8_Bold, sl_bru, new Rectangle(lot_margin, sl_currentHeight, bzcontenttitlewidth, bzcontentheight1/ bzcontentsize1.Lines), strFormatCenter_Near);
            }
            g.DrawString(bzcontent1, sl_font12_Bold, sl_bru, new Rectangle(lot_margin + bzcontenttitlewidth, sl_currentHeight, lotTableWidth_right - 40, bzcontentheight1), strFormatCenter_Near);
            sl_currentHeight += bzcontentheight1;
            string bz = PrintHead.REMARK.TrimStart('\n');
            string[] remarkArr = GetRemarkArray(bz);
            for (int i = 0; i < remarkArr.Length; i++)
            {
                MeasureLineSize sizenode = GetMeasureLineSize(g, remarkArr[i], sl_font8_Bold, lotTableWidth_right);
                int height = (int)(sizenode.Size.Height * sizenode.Lines);
                g.DrawString(remarkArr[i], sl_font8_Bold, sl_bru, new Rectangle(lot_margin, sl_currentHeight + 3, lotTableWidth_right, height), strFormatCenter_Near);
                sl_currentHeight += height;
            }
            sl_currentHeight = sl_currentHeight < bigRemarkY + imageHeight + 15 ? bigRemarkY + imageHeight + 15 : sl_currentHeight;
            g.DrawRectangle(sl_Pen, new Rectangle(lot_margin, bigRemarkY, lotwidth, sl_currentHeight - bigRemarkY));


            //int bzinitalheight = increasingheight;

            //g.DrawString(q(Msg_Type.printbz) + ": " + PrintHead.CLPBDM, font10, bru, new Rectangle(margin, increasingheight + 2, width - 2 * grid, hrowmargin), strFormat1);
            //byte[] bytes = ServicModel.BarCode.CreateBarCode(PrintHead.TM, "QRCODE", 70, 70, 1);
            //MemoryStream ms = new MemoryStream(bytes);
            //Image returnImage = Image.FromStream(ms);
            //g.DrawImage(returnImage, margin + 2 * grid + width / 6, increasingheight + 10, 70, 70);
            //g.DrawString(PrintHead.TM, font8, bru, 2 * grid + 5 + width / 6, increasingheight + 80);
            //increasingheight += hrowmargin;
            //string bzcontent = "";
            //if (PrintHead.WLLBNAME == "密封圈") //无腔号 or 颜色
            //{
            //    if (!string.IsNullOrEmpty(PrintHead.WQH)) bzcontent = q(Msg_Type.printwqh) + PrintHead.WQH;//"无腔号:"
            //}
            //else if (PrintHead.WLLBNAME == "绝缘圈")
            //{
            //    if (!string.IsNullOrEmpty(PrintHead.MFQCOLORNAME)) bzcontent = q(Msg_Type.printys) + PrintHead.MFQCOLORNAME;//"颜色："
            //}
            //SizeF sizefbzcontent = g.MeasureString(bzcontent, font8);
            //int bzcontentline = (int)Math.Ceiling(sizefbzcontent.Width / (grid * 3 - 20));
            //g.DrawString(bzcontent, font8, bru, new Rectangle(margin, increasingheight, 2 * grid - 20, hrowmargin * bzcontentline));
            //increasingheight += hrowmargin * bzcontentline;
            //string bz = PrintHead.REMARK;
            //SizeF sizefbz = g.MeasureString(bz, font8);
            //int bzline = (int)Math.Ceiling(sizefbz.Width / (grid * 3 - 50));
            ////g.DrawString("备注", font8, bru, new Rectangle(margin, increasingheight, 2 * grid, hrowmargin ));
            //g.DrawString(bz, font8, bru, new Rectangle(margin, increasingheight, 3 * grid - 50, hrowmargin * bzline));
            //int bzheight = hrowmargin + hrowmargin * bzcontentline + hrowmargin * bzline + 5;
            //bzheight = bzheight > 95 ? bzheight : 95;
            //g.DrawRectangle(blackPen, new Rectangle(margin, bzinitalheight, width - 2 * margin, bzheight));
            ////g.DrawLine(blackPen, margin + grid - 30, rowmargin * 0 + 70 + 13 + h1 - subWidth, margin + width, rowmargin * 0 + 70 + 13 + h1 - subWidth);
        }
        /// <summary>
        /// 计算字符的逻辑
        /// </summary>
        /// <param name="e">用来获取当前画布</param>
        /// <param name="content">字符的内容</param>
        /// <param name="font">字符</param>
        /// <param name="width">计算多行的一个参照宽度</param>
        /// <returns></returns>
        public MeasureLineSize GetMeasureLineSize(Graphics g, string content,Font font,int width)
        {
            MeasureLineSize res = new MeasureLineSize();          
            SizeF z = g.MeasureString(content, font);
            int currentwidth = z.Width <= width ? width : width - 5; 
            int lines = (int)Math.Ceiling(z.Width / currentwidth);
            res.Size = z;
            res.Lines = lines;
            return res;
        }
        public int GetMaxLine(params int[] lines)
        {
            return lines.Max();
        }
        /// <summary>
        /// 绘制表格线和内容封装
        /// </summary>
        /// <param name="g"></param>
        /// <param name="contentArr"></param>
        public void DrawingTableContent(Graphics g, string[] contentArr)
        {
            Rectangle tableRect_left = new Rectangle(lot_margin, sl_currentHeight, lotTableWidth_left - 25, standardTableRowHeight);
            Rectangle tableRect_rigth = new Rectangle(lot_margin + lotTableWidth_left - 25, sl_currentHeight, lotTableWidth_right + 25, standardTableRowHeight);
            for (int i = 0; i < contentArr.Length; i++)
            {
                MeasureLineSize left = GetMeasureLineSize(g, contentArr[i++], sl_font10_Bold, lotTableWidth_left - 25);
                MeasureLineSize right = GetMeasureLineSize(g, contentArr[i], sl_font10_Bold, lotTableWidth_right + 25);
                int maxLine = GetMaxLine(left.Lines, right.Lines);
                SizeF size = left.Lines == maxLine ? left.Size : right.Size;
                tableRect_left.Height = (int)(size.Height * maxLine);
                tableRect_rigth.Height = (int)(size.Height * maxLine);
                g.DrawRectangle(sl_Pen, tableRect_left);
                g.DrawRectangle(sl_Pen, tableRect_rigth);
                sl_currentHeight += tableRect_left.Height;
                tableRect_left.Y += 2;//矩阵-2的目的是显示文字的时候中心位置会偏上，内容输出以后在减去对应的-2；
                tableRect_rigth.Y += 2;
                g.DrawString(contentArr[--i], sl_font10_Bold, sl_bru, tableRect_left, strFormatCenter_Near);
                g.DrawString(contentArr[++i], sl_font10_Bold, sl_bru, tableRect_rigth, strFormatCenter_Near);
                tableRect_left.Y -= 2;
                tableRect_rigth.Y -= 2;
                tableRect_left.Y = sl_currentHeight;
                tableRect_rigth.Y = sl_currentHeight;
            }            
        }
        /// <summary>
        /// 负极
        /// </summary>
        /// <param name="g"></param>
        /// <param name="contentArr"></param>
        public void DrawingTableContent(Graphics g, string[] contentArr,int[] indexs,Font[] fonts)
        {
            Rectangle tableRect_left = new Rectangle(lot_margin, sl_currentHeight, lotTableWidth_left - 25, standardTableRowHeight);
            Rectangle tableRect_rigth = new Rectangle(lot_margin + lotTableWidth_left - 25, sl_currentHeight, lotTableWidth_right + 25, standardTableRowHeight);
            for (int i = 0; i < contentArr.Length; i++)
            {
                int index = indexs.ToList().IndexOf(i + 1);
                Font rightfont = index == -1 ? sl_font10_Bold : fonts[index];               
                MeasureLineSize left = GetMeasureLineSize(g, contentArr[i++], sl_font10_Bold, lotTableWidth_left - 25);
                MeasureLineSize right = GetMeasureLineSize(g, contentArr[i], rightfont, lotTableWidth_right + 25);
                int height_right = (int)(left.Size.Height) * left.Lines;
                int height_left = (int)(right.Size.Height) * right.Lines;
                int maxheight = height_right > height_left ? height_right : height_left;
                tableRect_left.Height = maxheight;
                tableRect_rigth.Height = maxheight;
                g.DrawRectangle(sl_Pen, tableRect_left);
                g.DrawRectangle(sl_Pen, tableRect_rigth);
                sl_currentHeight += tableRect_left.Height;
                tableRect_left.Y += 2;//矩阵-2的目的是显示文字的时候中心位置会偏上，内容输出以后在减去对应的-2；
                tableRect_rigth.Y += 2;
                g.DrawString(contentArr[--i], sl_font10_Bold, sl_bru, tableRect_left , strFormatCenter_Near);
                g.DrawString(contentArr[++i], rightfont, sl_bru, tableRect_rigth , strFormatCenter_Near);
                tableRect_left.Y -= 2;
                tableRect_rigth.Y -= 2;
                tableRect_left.Y = sl_currentHeight;
                tableRect_rigth.Y = sl_currentHeight;
            }
        }

        public void ClearCurrentLineParms()
        {
            line_part1 = 0;
            line_part2 = 0;
            line_part3 = 0;
            line_part4 = 0;
            line_part5 = 0;
            line_part6 = 0;
        }
        public Image GetBarCodeImage(string tm,int width,int height,int pure = 1, string codeType = "QRCODE")
        {
            //byte[] bytes = ServicModel.BarCode.CreateBarCode(tm, "QRCODE", 70, 70, 1);
            byte[] bytes = ServicModel.BarCode.CreateBarCode(tm, codeType, width, height, 1);
            MemoryStream ms = new MemoryStream(bytes);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public string[] GetRemarkArray(string content,char split = '\n')
        {
            string[] contentArr = content.Split(split);
            string[] resArr = contentArr.Where(p => !p.Equals("")).ToArray();
            return resArr;
        }
        public Graphics InitPrintSetting(PrintPageEventArgs e)
        {
            sl_Pen = new Pen(Color.Black, 1); 
            sl_currentHeight = 0;
            string fontprefix = "sl_font";
            string line_partprefix = "line_part";
            Graphics g = e.Graphics;//画布            
            strFormatNear_Near.LineAlignment = StringAlignment.Near;//垂直
            strFormatNear_Near.Alignment = StringAlignment.Near;//水平
            strFormatNear_Center.LineAlignment = StringAlignment.Near;//垂直
            strFormatNear_Center.Alignment = StringAlignment.Center;//水平
            strFormatNear_Far.LineAlignment = StringAlignment.Near;//垂直
            strFormatNear_Far.Alignment = StringAlignment.Far;//水平

            strFormatCenter_Near.LineAlignment = StringAlignment.Center;//垂直
            strFormatCenter_Near.Alignment = StringAlignment.Near;//水平
            strFormatCenter_Center.LineAlignment = StringAlignment.Center;//垂直
            strFormatCenter_Center.Alignment = StringAlignment.Center;//水平
            strFormatCenter_Far.LineAlignment = StringAlignment.Center;//垂直
            strFormatCenter_Far.Alignment = StringAlignment.Far;//水平

            strFormatFar_Near.LineAlignment = StringAlignment.Far;//垂直
            strFormatFar_Near.Alignment = StringAlignment.Near;//水平
            strFormatFar_Center.LineAlignment = StringAlignment.Far;//垂直
            strFormatFar_Center.Alignment = StringAlignment.Center;//水平
            strFormatFar_Far.LineAlignment = StringAlignment.Far;//垂直
            strFormatFar_Far.Alignment = StringAlignment.Far;//水平

            lotTableWidth_left = lotwidth / 3 * 1;
            lotTableWidth_right = lotwidth / 3 * 2;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;//抗锯齿   
            for (int i = 0; i < 24; i++)
            {
               GetType().GetField(fontprefix + (i + 7)).SetValue(this, new Font(q(Msg_Type.fonttype), (i + 7)));
               GetType().GetField(fontprefix + (i + 7) + "_Bold").SetValue(this, new Font(q(Msg_Type.fonttype), (i + 7), FontStyle.Bold));
                if (i < 6)
                {
                    GetType().GetField(line_partprefix + (i + 1)).SetValue(this, 0);
                }
            }
            return g;
        }
        #endregion 


    }
    public class MeasureLineSize {
        SizeF _size;
        int _lines;

        public SizeF Size { get => _size; set => _size = value; }
        public int Lines { get => _lines; set => _lines = value; }
    }

    public class ChildPrint
    {
        string _content;

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        Font _font;

        public Font Font
        {
            get { return _font; }
            set { _font = value; }
        }
        int _height;

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
    }
}
