using Sonluk.MES.MES.Base;
using Sonluk.UI.Model.MES.PMM_MOULDService;
using Sonluk.UI.Model.MES.SY_MATERIALService;
using Sonluk.UI.Model.MES.SY_TYPEMXService;
using Sonluk.UI.Model.MES.TM_CZRService;
using Sonluk.UI.Model.MES.TM_TMINFOService;
using Sonluk.UI.Model.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sonluk.MES.MES.main
{
    public partial class frmZSLotprint : baseview
    {
        private MES_PMM_MOULD _MES_PMM_MOULD = new MES_PMM_MOULD();
        int wllbtype = 0;
        string Gh = "";
        public frmZSLotprint()
        {
            InitializeComponent();
           
        }

        private void SMtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ScanTM();

            }
        }
        public void ScanTM()
        {
            TM_Type type = TMtype(SMtextBox.Text.Trim());
            switch (type)
            {
                case TM_Type.none:
                    MessageBox.Show("你扫描的是无效的条码！！", "消息框");
                    break;
                case TM_Type.staffno:
                    getCzrInfo();
                    break;
                case TM_Type.wllot:
                    getwllot();
                    break;
                default:
                    MessageBox.Show("你扫描的是无效的条码！！", "消息框");
                    break;
            }
            SMtextBox.Clear();
        }
        public void getCzrInfo()
        {
            if (!string.IsNullOrEmpty(_MES_PMM_MOULD.MID))
            {

                MES_RETURN_UI res = ServicModel.PUBLIC_FUNC.GET_YGNAME(SMtextBox.Text.Trim().ToUpper(), getToken());
                if (res.TYPE.Equals("S"))
                {


                    MES_TM_CZR model = new MES_TM_CZR();
                    //model.GC = _MES_PMM_MOULD.GC;
                    model.CZLB = 3;
                    model.CZRGH = SMtextBox.Text.Trim().ToUpper();
                    model.CZRNAME = res.MESSAGE;
                    model.SBBH = _MES_PMM_MOULD.SBBH;
                    model.ISREPLACE = 1;

                    MES_RETURN_UI addres = AddCzr(model);
                    if (addres.TYPE == "S")
                    {
                        czrtextBox1.Text = res.MESSAGE;
                        Gh = SMtextBox.Text.Trim().ToUpper();
                    }
                    else
                    {
                        ShowMeg(addres.MESSAGE);
                    }



                }
                else
                {
                    ShowMeg(res.MESSAGE);
                }
            }
            else
            {
                ShowMeg("扫描操作人员前先扫描模具号");
            }

            //if (res.TYPE.Equals("S"))
            //{
            //    _czrList = SelectCZR(model);

            //    czrytextBox.Text = _czrList.CZR;
            //}
            //else
            //{
            //    MessageBox.Show(res.MESSAGE, "消息框");
            //}


        }
        public void getwllot()
        {
            //_MES_PMM_MOULD = new MES_PMM_MOULD();
            //Gh = "";
            ClearUI();
            //GetDictionaryMX()  字典
            MES_PMM_MOULD model = new MES_PMM_MOULD();
            model.MID = SMtextBox.Text.Trim();
            MES_PMM_MOULD_SELECT res = ServicModel.PMM_MOULD.SELECT_ALL(model, getToken());
            if (res.MES_RETURN.TYPE == "S")
            {
                if (res.MES_PMM_MOULD.Length == 0)
                {
                    ShowMeg(string.Format("没有查询到{0}对应的模具信息", model.MID));
                }
                else if (res.MES_PMM_MOULD.Length == 1)
                {
                    _MES_PMM_MOULD = res.MES_PMM_MOULD[0];
                    ConfigUI(_MES_PMM_MOULD);

                }
                else
                {
                    ShowMeg("获取到模具信息异常" + res.MES_PMM_MOULD.Length + "");
                }
            }
            else
            {
                ShowMeg(res.MES_RETURN.MESSAGE);
            }
        }
        private void ConfigUI(MES_PMM_MOULD model)
        {
            if (model.STATUS != "正常") ShowMeg(string.Format("模具{0}状态为{1}", model.MOULD, model.STATUS));
            wllbtype = 0;
            if (model.WLLBNAME == "密封圈")
            {
                wllbtype = 1;
                wqhyslabel.Text = "无腔号:";
            }
            else if (model.WLLBNAME == "绝缘圈")
            {
                wllbtype = 2;
                wqhyslabel.Text = "颜色:";
                List<MES_SY_TYPEMXLIST> yslist = GetDictionaryMX(33).ToList();
                int index = yslist.FindIndex(p => model.WLMS.Contains(p.MXNAME));
                if (index != -1)
                {
                    wxhystextBox2.Text = yslist[index].MXNAME;
                }
               
            }
            else
            {
                ShowMeg("模具物料类别不属于绝缘圈或密封圈为" + model.WLLBNAME);
            }


            gctextBox.Text = model.GC + "-" + model.GCMS;
            gzzxtextBox4.Text = model.GZZXBH + "-" + model.GZZXMS;
            sbhtextBox2.Text = model.SBMS;
            mjhtextBox5.Text = model.MOULD;
            wlxxtextBox.Text = model.WLH + "/" + model.WLMS;
            sltextBox1.Text = model.CASENUM.ToString();
            jztextBox1.Text = model.CASEWET.ToString();

            clpbdmtextBox6.Text = model.MATCHCODENAME;
            //List<MES_SY_TYPEMXLIST> dwlist = GetDictionaryMX(2,model.GC).ToList();
            MES_SY_TYPEMXLIST choicllist = new MES_SY_TYPEMXLIST();
            choicllist.ID = 0;
            choicllist.MXNAME = "==请选择==";
            //dwlist.Insert(0, choicllist);
            //dwcomboBox1.DataSource = dwlist;
            //dwcomboBox1.DisplayMember = "MXNAME";
            //dwcomboBox1.ValueMember = "ID";
            MES_SY_MATERIAL materialmodel = new MES_SY_MATERIAL();
            materialmodel.WLH = model.WLH;
            materialmodel.GC = model.GC;
            MES_SY_MATERIAL_SELECT mRes = ServicModel.SY_MATERIAL.SELECT(materialmodel, getToken());
            if (mRes.MES_RETURN.TYPE.Equals("S"))
            {
                if (mRes.MES_SY_MATERIAL != null && mRes.MES_SY_MATERIAL.Length > 0)
                {
                    dwlabel.Text = mRes.MES_SY_MATERIAL[0].UNITSNAME;
                }

            }
            List<MES_SY_TYPEMXLIST> cpztlist = GetDictionaryMX(9, model.GC).ToList();
            cpztlist.Insert(0, choicllist);
            cpztcomboBox1.DataSource = cpztlist;
            cpztcomboBox1.DisplayMember = "MXNAME";
            cpztcomboBox1.ValueMember = "ID";
            int hgindex = cpztlist.FindIndex(p => p.MXNAME == "合格");
            if (hgindex != -1)
            {
                cpztcomboBox1.SelectedValue = cpztlist[hgindex].ID;
            }
            List<MES_SY_TYPEMXLIST> lxlist = GetDictionaryMX(32, model.GC).ToList();
            lxlist.Insert(0, choicllist);
            lxcomboBox2.DataSource = lxlist;
            lxcomboBox2.DisplayMember = "MXNAME";
            lxcomboBox2.ValueMember = "ID";
            int zcindex = lxlist.FindIndex(p => p.MXNAME == "正常");
            if (zcindex != -1)
            {
                lxcomboBox2.SelectedValue = lxlist[zcindex].ID;
            }
            MES_TM_TMINFO kstimemodel = new MES_TM_TMINFO();
            kstimemodel.LB = 1;
            kstimemodel.MID = model.MID;
            MES_RETURN_UI kstimeres = ServicModel.TM_TMINFO.SELECT_TM_LASTTIME(kstimemodel, getToken());
            string currentTime = Convert.ToDateTime(ServicModel.PUBLIC_FUNC.GET_TIME(getToken())).ToString("yyyy-MM-dd HH:mm:ss");
            if (kstimeres.TYPE == "S")
            {
                if (!string.IsNullOrEmpty(kstimeres.MESSAGE))
                {
                    ksdateTimePicker1.Text = kstimeres.MESSAGE;//.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    ksdateTimePicker1.Text = currentTime;//DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
            //ksdateTimePicker1.Text =
            jsdateTimePicker2.Text = currentTime;// DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            MES_TM_CZR czrmodel = new MES_TM_CZR();
            czrmodel.SBBH = model.SBBH;
            czrmodel.CZLB = 3;
            MES_TM_CZR_SELECT_CZR_NOW czrres = SelectCZR(czrmodel);
            if (czrres.MES_RETURN.TYPE == "S" && czrres.MES_TM_CZR.Length == 1)
            {
                Gh = czrres.MES_TM_CZR[0].CZRGH;
                czrtextBox1.Text = czrres.MES_TM_CZR[0].CZRNAME;
            }
            else
            {

            }



        }
        private void qrdybutton1_Click(object sender, EventArgs e)
        {
            if (!judge.IsNo_3(sltextBox1.Text.Trim()))
            {
                ShowMeg("数量信息不能为空,最多三位小数");
                return;
            }
            //if (Convert.ToInt32(dwcomboBox1.SelectedValue) == 0)
            //{
            //    ShowMeg("必须选择数量单位");
            //    return;
            //}
            if (!judge.IsNo_3(jztextBox1.Text.Trim()))
            {
                ShowMeg("净重信息不能为空,最多三位小数");
                return;
            }
            if (Convert.ToInt32(cpztcomboBox1.SelectedValue) == 0)
            {
                ShowMeg("产品状态不能为空");
                return;
            }
            if (Convert.ToInt32(lxcomboBox2.SelectedValue) == 0)
            {
                ShowMeg("类型不能为空");
                return;
            }
            if (string.IsNullOrEmpty(czrtextBox1.Text.Trim()))
            {
                ShowMeg("必须扫描操作工条件");
                return;
            }

            if (string.IsNullOrEmpty(ksdateTimePicker1.Text.Trim()))
            {
                ShowMeg("开始时间不能为空");
                return;
            }
            if (judge.IsDate(ksdateTimePicker1.Text.Trim()) == false)
            {
                ShowMeg("开始时间不能正确的时间格式");
                return;
            }
            if (string.IsNullOrEmpty(jsdateTimePicker2.Text.Trim()))
            {
                ShowMeg("结束时间不能为空");
                return;
            }
            if (judge.IsDate(jsdateTimePicker2.Text.Trim()) == false)
            {
                ShowMeg("结束时间不能正确的时间格式");
                return;
            }
            TimeSpan midtine = DateTime.Parse(jsdateTimePicker2.Text.Trim()) - DateTime.Parse(ksdateTimePicker1.Text.Trim());
            if (midtine.TotalSeconds < 0)
            {
                ShowMeg("开始时间不能大于结束时间");
                return;
            }
            else if (midtine.TotalSeconds == 0)
            {
                ShowMeg("开始时间不能等于结束时间");
                return;
            }
            if (wllbtype == 2 && string.IsNullOrEmpty(wxhystextBox2.Text.Trim()))
            {
                ShowMeg("物料类别是绝缘圈的模具号必须选择颜色");
                return;
            }
            else if (wllbtype == 1 && string.IsNullOrEmpty(wxhystextBox2.Text.Trim()))
            {
                //ShowMeg("物料类别是密封圈的模具号必须选择无腔号");
                //return;
            }
            //MES_TM_TMINFO_INSERT_GL model = new UI.Model.MES.TM_TMINFOService.MES_TM_TMINFO_INSERT_GL();
            MES_TM_TMINFO info = new MES_TM_TMINFO();
            info.GC = _MES_PMM_MOULD.GC;
            info.TMLB = 1;
            info.TMSX = Convert.ToInt32(Print_Type.zswllot);
            info.JSTIME = jsdateTimePicker2.Text.Trim();


            string _workdayAM = "07:30";
            string _workdayPM = "19:30";
            TimeSpan dspWorkingDayAM = DateTime.Parse(_workdayAM).TimeOfDay;
            TimeSpan dspWorkingDayPM = DateTime.Parse(_workdayPM).TimeOfDay;
            //string time1 = "2017-2-17 8:10:00";

            List<MES_SY_TYPEMXLIST> bclist = GetDictionaryMX(5, _MES_PMM_MOULD.GC).ToList();
            DateTime t1 = Convert.ToDateTime(info.JSTIME);
            TimeSpan dspNow = t1.TimeOfDay;
            int bcindex = 0;
            bool isSubday = false;
            if (dspNow >= dspWorkingDayAM && dspNow <= dspWorkingDayPM)
            {
                bcindex = bclist.FindIndex(p => p.MXNAME == "日班");

            }
            else
            {
                if (dspNow < dspWorkingDayAM)
                {
                    isSubday = true;
                }
                bcindex = bclist.FindIndex(p => p.MXNAME == "夜班");

            }
            if (bcindex == -1)
            {
                ShowMeg("获取班次信息异常请联系管理员");
                return;
            }
            info.BC = bclist[bcindex].ID;
            if (isSubday)
            {
                t1 = t1.AddDays(-1);
            }
            info.SCDATE = t1.ToString("yyyy-MM-dd");
            //info.SCDATE
            //info.BC
            //info.PC
            info.JLR = Convert.ToInt32(getUserInfo("staffid"));
            info.CPZT = Convert.ToInt32(cpztcomboBox1.SelectedValue);
            info.SL = Convert.ToDecimal(sltextBox1.Text.Trim());
            info.KSTIME = ksdateTimePicker1.Text.Trim();
            info.REMARK = bzrichTextBox1.Text.Trim();
            info.MAC = DeviceInfo.GetNetCardMAC().Substring(0, 17);
            info.MID = _MES_PMM_MOULD.MID;
            info.JZ = Convert.ToDecimal(jztextBox1.Text.Trim());
            info.CPTYPE = Convert.ToInt32(lxcomboBox2.SelectedValue);

            //info.UNITSID = Convert.ToInt32(dwcomboBox1.SelectedValue);


            //info.UNITSNAME = Convert.ToString(dwcomboBox1.SelectedText);            

            if (wllbtype == 1)
            {
                info.WQH = wxhystextBox2.Text.Trim();
            }
            else if (wllbtype == 2)
            {
                //info.MFQCOLOR = wqhyslabel.Text.Trim();
                List<MES_SY_TYPEMXLIST> yslist = GetDictionaryMX(33, _MES_PMM_MOULD.GC).ToList();
                int ysindex = yslist.FindIndex(p => p.MXNAME == wxhystextBox2.Text.Trim());
                info.MFQCOLOR = yslist[ysindex].ID;
            }
            try
            {
                MES_RETURN_UI res = ServicModel.TM_TMINFO.INSERT_ONLY(info, getToken());
                if (res.TYPE == "S")
                {
                    PrintInfoByTM(res.TM, res.GC, 1, Rigth_Type.zswllotdy, Print_Type.zswllot);
                    ClearUI();
                    
                }
                else
                {
                    ShowMeg(res.MESSAGE);
                }
            }
            catch (Exception ex)
            {
                ShowMeg(ex.Message);
                throw;
            }
            SMtextBox.Select();
            //MES_TM_TMINFO_INSERT_RETURN res = ServicModel.TM_TMINFO.INSERT(model,0, getToken());
            //if (res.MES_RETURN.TYPE == "S")
            //{

            //}
            //else
            //{
            //    ShowMeg(res.MES_RETURN.MESSAGE);
            //}
        }
        private void ClearUI()
        {
            _MES_PMM_MOULD = new MES_PMM_MOULD();
            wllbtype = 0;
            Gh = "";
            gctextBox.Clear();
            gzzxtextBox4.Clear();
            sbhtextBox2.Clear();
            mjhtextBox5.Clear();
            wlxxtextBox.Clear();
            clpbdmtextBox6.Clear();
            sltextBox1.Clear();
            //dwcomboBox1.DataSource = new List<MES_SY_TYPEMXLIST>();
            //dwtextBox.Clear();
            dwlabel.Text = "单位";
            jztextBox1.Clear();
            cpztcomboBox1.DataSource = new List<MES_SY_TYPEMXLIST>();
            lxcomboBox2.DataSource = new List<MES_SY_TYPEMXLIST>();
            ksdateTimePicker1.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            jsdateTimePicker2.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            czrtextBox1.Clear();
            wxhystextBox2.Clear();
            bzrichTextBox1.Clear();
        }


        private void wxhystextBox2_Click(object sender, EventArgs e)
        {
            //Random r = new Random();
            //int type = r.Next(1, 3);

            //frmZSLotSub form = new frmZSLotSub(wllbtype, wxhystextBox2.Text.Trim());
            if (wllbtype != 0)
            {
                frmZSLotSub form = new frmZSLotSub(wllbtype, wxhystextBox2.Text.Trim(), _MES_PMM_MOULD.CAVE);
                form.block = SubBackContent;
                show(form);
            }
           
        }
        public void SubBackContent(string content)
        {
            wxhystextBox2.Text = content;
        }
        private void wxhystextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmZSLotprint_Shown(object sender, EventArgs e)
        {
            string currentTime = Convert.ToDateTime(ServicModel.PUBLIC_FUNC.GET_TIME(getToken())).ToString("yyyy-MM-dd HH:mm:ss");
            ksdateTimePicker1.Text = currentTime;//DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            jsdateTimePicker2.Text = currentTime;// DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //dd
        }
    }
}
