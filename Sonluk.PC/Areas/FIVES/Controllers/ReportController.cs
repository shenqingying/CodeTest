using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using Sonluk.UI.Model.HR.SY_DEPTService;
using Sonluk.UI.Model.MES.SY_STAFFService;
using Sonluk.UI.Model.MODEL;
using Sonluk.UI.Model.S5.CHECK_INFODETAILService;
using Sonluk.UI.Model.S5.CHECK_INFOService;
using Sonluk.UI.Model.S5.SY_DICTService;
using Sonluk.UI.Model.S5.SY_STAFF_DEPService;
//using Sonluk.UI.Model.S5.SY_CHECKPOINTService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Data.Objects;
using Sonluk.UI.Model.S5.STAFF_DEPService;

namespace Sonluk.PC.Areas.FIVES.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /FIVES/Report/

        FIVESModels fivesmodels = new FIVESModels();
        HRModels hrmodels = new HRModels();
        AppClass appClass = new AppClass();
        CRMModels crmModels = new CRMModels();
        MESModels mesModels = new MESModels();
        WebMSG webmsg = new WebMSG();
        string token = "";
        public ActionResult Index()
        {
            return View();
        }




        public ActionResult BHGDJ()
        {
            Session["location"] = 212;
            token = appClass.CRM_Gettoken();


            FIVES_STAFF_DEP DEPmodel = new FIVES_STAFF_DEP();
            DEPmodel.STAFFID = appClass.CRM_GetStaffid();

            FIVES_STAFF_DEP[] DEPdata = fivesmodels.STAFF_DEP.Read(DEPmodel, token);

            List<FIVES_STAFF_DEP> DEPlist = DEPdata.ToList();
            DEPlist = DEPlist.DistinctBy(p => p.DEPTID).ToList();
            DEPdata = DEPlist.ToArray();
            ViewBag.DeptArr = DEPdata;


            return View();
        }
        public ActionResult DJHZ()
        {
            Session["location"] = 213;
            token = appClass.CRM_Gettoken();
            FIVES_STAFF_DEP DEPmodel = new FIVES_STAFF_DEP();
            DEPmodel.STAFFID = appClass.CRM_GetStaffid();
            FIVES_STAFF_DEP[] DEPdata = fivesmodels.STAFF_DEP.Read(DEPmodel, token);
            //  List<FIVES_STAFF_DEP> DEPlist = DEPdata.ToList();
            DEPdata = DEPdata.DistinctBy(p => p.DEPTID).ToArray();
            ViewBag.DeptArr = DEPdata;

            return View();
        }
        public ActionResult CHECK_INFO()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 209;
            Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT checkpointModel = new Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT();
            Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT[] checkpointRes = fivesmodels.SY_CHECKPOINT.Read(checkpointModel, token);
            ViewBag.CheckPointArr = checkpointRes;
            HR_SY_DEPT deptModel = new HR_SY_DEPT();
            HR_SY_DEPT_SELECT deptRes = hrmodels.SY_DEPT.SELECT(deptModel, token);
            ViewBag.DeptArr = deptRes.HR_SY_DEPT_LIST;
            FIVES_SY_DICT JCLXmodel = new FIVES_SY_DICT();
            JCLXmodel.TYPEID = 2;
            FIVES_SY_DICT[] JCLXRes = fivesmodels.SY_DICT.Read(JCLXmodel, token);
            ViewBag.JCLXArr = JCLXRes;
            string datastring = "{\"DEPID\":\"0\",\"STAFFNAME\":\"\",\"STAFFNO\":\"\"}";
            MES_SY_STAFF model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_STAFF>(datastring);
            MES_SY_STAFF_SELECT rst_MES_SY_STAFF_SELECT = mesModels.SY_STAFF.SELECT(model, token);
            ViewBag.STAFFArr = rst_MES_SY_STAFF_SELECT.MES_SY_STAFF;


            JCLXmodel.TYPEID = 1;

            ViewBag.DFArr = fivesmodels.SY_DICT.Read(JCLXmodel, token);
            return View();
        }
        public ActionResult UPDATE_INFO()
        {
            token = appClass.CRM_Gettoken();
            Session["location"] = 214;
            Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT checkpointModel = new Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT();
            Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT[] checkpointRes = fivesmodels.SY_CHECKPOINT.Read(checkpointModel, token);
            ViewBag.CheckPointArr = checkpointRes;


            FIVES_STAFF_DEP DEPmodel = new FIVES_STAFF_DEP();
            DEPmodel.STAFFID = appClass.CRM_GetStaffid();
            FIVES_STAFF_DEP[] DEPdata = fivesmodels.STAFF_DEP.Read(DEPmodel, token);
            DEPdata = DEPdata.DistinctBy(p => p.DEPTID).ToArray();
            ViewBag.DeptArr = DEPdata;


            string datastring = "{\"DEPID\":\"0\",\"STAFFNAME\":\"\",\"STAFFNO\":\"\"}";
            MES_SY_STAFF model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_SY_STAFF>(datastring);
            MES_SY_STAFF_SELECT rst_MES_SY_STAFF_SELECT = mesModels.SY_STAFF.SELECT(model, token);
            ViewBag.STAFFArr = rst_MES_SY_STAFF_SELECT.MES_SY_STAFF;


            Sonluk.UI.Model.S5.SY_DICTService.FIVES_SY_DICT MODEL = new Sonluk.UI.Model.S5.SY_DICTService.FIVES_SY_DICT();
            MODEL.TYPEID = 9;
            Sonluk.UI.Model.S5.SY_DICTService.FIVES_SY_DICT[] SHOWNAME = fivesmodels.SY_DICT.Read(MODEL, token);
            ViewBag.SHOWNAME = SHOWNAME;

            FIVES_SY_DICT JCLXmodel = new FIVES_SY_DICT();
            JCLXmodel.TYPEID = 1;

            ViewBag.DFArr = fivesmodels.SY_DICT.Read(JCLXmodel, token);
            return View();
        }
        public ActionResult SELECT_COMPARE()
        {
            Session["location"] = 215;
            token = appClass.CRM_Gettoken();
            FIVES_STAFF_DEP DEPmodel = new FIVES_STAFF_DEP();
            DEPmodel.STAFFID = appClass.CRM_GetStaffid();
            FIVES_STAFF_DEP[] DEPdata = fivesmodels.STAFF_DEP.Read(DEPmodel, token);
            DEPdata = DEPdata.DistinctBy(p => p.DEPTID).ToArray();
            ViewBag.DeptArr = DEPdata;
            return View();
        }
        public string SELECT_COMPARE_INFO(string data)
        {
            token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT model = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT>(data);
            try
            {
                Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT[] rst = fivesmodels.SY_CHECKPOINT.Compare(model, token);
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public string CheckInfo_Head(string data)
        {

            token = appClass.CRM_Gettoken();
            FIVES_CHECK_INFOList model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_CHECK_INFOList>(data);
            //FIVES_CHECK_INFOList model = new FIVES_CHECK_INFOList();
            try
            {
                FIVES_CHECK_INFOList[] rst = fivesmodels.CHECK_INFO.Read(model, token);
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        public string CheckInfoHZ_Select(string data)
        {
            token = appClass.CRM_Gettoken();
            FIVES_CHECK_INFOList model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_CHECK_INFOList>(data);
            //FIVES_CHECK_INFOList model = new FIVES_CHECK_INFOList();

            FIVES_CHECK_INFOList[] rst = fivesmodels.CHECK_INFO.Read_HZINFO(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public string CheckInfo_Select(string data, string KSTIME, string JSTIME)
        {
            token = appClass.CRM_Gettoken();
            FIVES_CHECK_INFOList model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_CHECK_INFOList>(data);
            FIVES_CHECK_INFOList[] rst = fivesmodels.CHECK_INFO.Read(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public string CheckInfo_Select_DJHZ(string data, string KSTIME, string JSTIME)
        {
            token = appClass.CRM_Gettoken();
            FIVES_CHECK_INFOList model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_CHECK_INFOList>(data);
            //   model
            //FIVES_CHECK_INFOList model = new FIVES_CHECK_INFOList();

            model.KSTIME = KSTIME;
            model.JSTIME = JSTIME;
            model.HG = 2;//查询全部
            FIVES_CHECK_INFOList[] rst = fivesmodels.CHECK_INFO.Read(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        public string PFMX_Select(int infoid)
        {
            token = appClass.CRM_Gettoken();
            FIVES_CHECK_INFODETAIL model = new FIVES_CHECK_INFODETAIL();
            model.INFOID = infoid;
            FIVES_CHECK_INFODETAILList[] rst = fivesmodels.CHECK_INFODETAIL.Read(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public string EXPORT_CHeck_SELECT(string data, int type, string KSTIME, string JSTIME)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI rst = new MES_RETURN_UI();
            token = appClass.CRM_Gettoken();

           
            try
            {
                if (type == 1)
                {
                    #region checkinfo
                    FIVES_CHECK_INFOList model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_CHECK_INFOList>(data);
                    // model.HG = 1;
                    //FIVES_CHECK_INFOList model = new FIVES_CHECK_INFOList();

                    FIVES_CHECK_INFOList[] checkinfolist = fivesmodels.CHECK_INFO.Read(model, token);
                    FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/FIVES/ExcelTemplate/5S不合格点检报表导出.xlsx", FileMode.Open, FileAccess.Read);
                    IWorkbook workbook = new XSSFWorkbook(file);
                    ISheet sheet = workbook.GetSheetAt(0);
                    int rowcount = 1;
                    for (int i = 0; i < checkinfolist.Length; i++)
                    {
                        int cellIndex = 0;
                        IRow row = sheet.CreateRow(rowcount++);
                        row.CreateCell(cellIndex++).SetCellValue(checkinfolist[i].OPINTMS);
                        row.CreateCell(cellIndex++).SetCellValue(checkinfolist[i].DEPARTMS);
                        row.CreateCell(cellIndex++).SetCellValue(checkinfolist[i].SHOWNAMEMS);
                        if (checkinfolist[i].HG == 0)
                        {
                            row.CreateCell(cellIndex++).SetCellValue("合格");
                        }
                        else if (checkinfolist[i].HG == 1)
                        {
                            row.CreateCell(cellIndex++).SetCellValue("不合格");
                        }
                        row.CreateCell(cellIndex++).SetCellValue(checkinfolist[i].SHOWTIME);
                        row.CreateCell(cellIndex++).SetCellValue(checkinfolist[i].REMARK);
                        row.CreateCell(cellIndex++).SetCellValue(checkinfolist[i].POSITION);
                    }
                    //获取当前列的宽度，然后对比本列的长度，取最大值
                    for (int columnNum = 0; columnNum <= checkinfolist.Length; columnNum++)
                    {
                        int columnWidth = sheet.GetColumnWidth(columnNum) / 256;
                        for (int rowNum = 1; rowNum <= sheet.LastRowNum; rowNum++)
                        {
                            IRow currentRow;
                            //当前行未被使用过
                            if (sheet.GetRow(rowNum) == null)
                            {
                                currentRow = sheet.CreateRow(rowNum);
                            }
                            else
                            {
                                currentRow = sheet.GetRow(rowNum);
                            }

                            if (currentRow.GetCell(columnNum) != null)
                            {
                                ICell currentCell = currentRow.GetCell(columnNum);
                                int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;
                                if (columnWidth < length)
                                {
                                    columnWidth = length;
                                }
                            }
                        }
                        sheet.SetColumnWidth(columnNum, columnWidth * 256);
                    }

                    string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                    FileStream file1 = new FileStream(string.Format(@"{0}/Areas/FIVES/ExcelTemplate/{1}.xlsx", Server.MapPath("~"), now + STAFFID + "13"), FileMode.Create);
                    workbook.Write(file1);
                    file1.Close();
                    rst.TYPE = "S";
                    rst.MESSAGE = now + STAFFID + "13";
                    #endregion
                }
                else if (type == 2)
                {
                    #region checkinfomx
                    FIVES_CHECK_INFOList model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_CHECK_INFOList>(data);
                    // model.HG = 1;
                    //FIVES_CHECK_INFOList model = new FIVES_CHECK_INFOList();

                    FIVES_CHECK_INFOList[] checkinfolist = fivesmodels.CHECK_INFO.Read(model, token);
                    List<FIVES_CHECK_INFODETAILList> checkinfomxlist = new List<FIVES_CHECK_INFODETAILList>();
                    for (int i = 0; i < checkinfolist.Length; i++)
                    {
                        FIVES_CHECK_INFODETAIL mxmodel = new FIVES_CHECK_INFODETAIL();
                        mxmodel.INFOID = checkinfolist[i].INFOID;
                        checkinfomxlist.AddRange(fivesmodels.CHECK_INFODETAIL.Read(mxmodel, token));

                    }

                    FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/FIVES/ExcelTemplate/5S不合格点检报表明细导出.xlsx", FileMode.Open, FileAccess.Read);
                    IWorkbook workbook = new XSSFWorkbook(file);
                    ISheet sheet = workbook.GetSheetAt(0);
                    int rowcount = 1;
                    for (int i = 0; i < checkinfomxlist.Count; i++)
                    {
                        int cellIndex = 0;
                        IRow row = sheet.CreateRow(rowcount++);
                        FIVES_CHECK_INFOList checkinfo = checkinfolist.Where(p => p.INFOID == checkinfomxlist[i].INFOID).ToList()[0];
                        row.CreateCell(cellIndex++).SetCellValue(checkinfo.OPINTMS);
                        row.CreateCell(cellIndex++).SetCellValue(checkinfo.DEPARTMS);
                        row.CreateCell(cellIndex++).SetCellValue(checkinfo.SHOWNAMEMS);
                        row.CreateCell(cellIndex++).SetCellValue(checkinfo.SHOWTIME);
                        row.CreateCell(cellIndex++).SetCellValue(checkinfo.REMARK);
                        row.CreateCell(cellIndex++).SetCellValue(checkinfomxlist[i].TYPEMS);
                        row.CreateCell(cellIndex++).SetCellValue(checkinfomxlist[i].REMARK);
                    }
                    //获取当前列的宽度，然后对比本列的长度，取最大值
                    for (int columnNum = 0; columnNum <= checkinfolist.Length; columnNum++)
                    {
                        int columnWidth = sheet.GetColumnWidth(columnNum) / 256;
                        for (int rowNum = 1; rowNum <= sheet.LastRowNum; rowNum++)
                        {
                            IRow currentRow;
                            //当前行未被使用过
                            if (sheet.GetRow(rowNum) == null)
                            {
                                currentRow = sheet.CreateRow(rowNum);
                            }
                            else
                            {
                                currentRow = sheet.GetRow(rowNum);
                            }

                            if (currentRow.GetCell(columnNum) != null)
                            {
                                ICell currentCell = currentRow.GetCell(columnNum);
                                int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;
                                if (columnWidth < length)
                                {
                                    columnWidth = length;
                                }
                            }
                        }
                        sheet.SetColumnWidth(columnNum, columnWidth * 256);
                    }

                    string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                    FileStream file1 = new FileStream(string.Format(@"{0}/Areas/FIVES/ExcelTemplate/{1}.xlsx", Server.MapPath("~"), now + STAFFID + "13"), FileMode.Create);
                    workbook.Write(file1);
                    file1.Close();
                    rst.TYPE = "S";
                    rst.MESSAGE = now + STAFFID + "13";
                    #endregion
                }
                else if (type == 3)
                {
                    FIVES_CHECK_INFOList model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_CHECK_INFOList>(data);
                    //FIVES_CHECK_INFOList model = new FIVES_CHECK_INFOList();

                    FIVES_CHECK_INFOList[] hzarr = fivesmodels.CHECK_INFO.Read_HZINFO(model, token);
                    FileStream file = new FileStream(Server.MapPath("~") + @"/Areas/FIVES/ExcelTemplate/点检汇总导出.xlsx", FileMode.Open, FileAccess.Read);
                    IWorkbook workbook = new XSSFWorkbook(file);
                    ISheet sheet = workbook.GetSheetAt(0);
                    ISheet sheet1 = workbook.GetSheetAt(1);
                    ISheet sheet2 = workbook.GetSheetAt(2);
                    int rowcount = 1;
                    int rowsecond = 1;
                    int rowsthird = 1;
                    //  FIVES_CHECK_INFOList[] TTdata = new FIVES_CHECK_INFOList[];

                    for (int i = 0; i < hzarr.Length; i++)
                    {
                        int Index = 0;
                        IRow row = sheet.CreateRow(rowcount++);
                        row.CreateCell(Index++).SetCellValue(hzarr[i].OPINTMS);
                        row.CreateCell(Index++).SetCellValue(hzarr[i].DEPARTMS);
                        row.CreateCell(Index++).SetCellValue(hzarr[i].FREQUENCYNAME);
                        row.CreateCell(Index++).SetCellValue(hzarr[i].CHECKCOUNT);
                        row.CreateCell(Index++).SetCellValue(hzarr[i].BHGCOUNT);
                        decimal d = hzarr[i].BHGCOUNT == 0 ? 100.0M : Math.Round(100 - (decimal)(hzarr[i].BHGCOUNT * 100) / hzarr[i].CHECKCOUNT, 1);
                        row.CreateCell(Index++).SetCellValue(d.ToString("##.0") + "%");

                        FIVES_CHECK_INFOList TTmodel = new FIVES_CHECK_INFOList();
                        TTmodel.OPINTID = hzarr[i].OPINTID;
                        TTmodel.KSTIME = KSTIME;
                        TTmodel.JSTIME = JSTIME;
                        TTmodel.HG = 2;
                        TTmodel.ISDELETE = true;
                        
                        FIVES_CHECK_INFOList[] TTdata = fivesmodels.CHECK_INFO.Read(TTmodel, token);
                        for (int x = 0; x < TTdata.Length; x++)
                        {
                            string str = "";
                            int cellIndex = 0;
                            IRow second = sheet1.CreateRow(rowsecond++);
                            second.CreateCell(cellIndex++).SetCellValue(TTdata[x].OPINTMS);
                            second.CreateCell(cellIndex++).SetCellValue(TTdata[x].DEPARTMS);
                            if (TTdata[x].HG == 1)
                            {
                                str = "不合格";
                            }
                            else
                            {
                                str = "合格";
                            }
                            second.CreateCell(cellIndex++).SetCellValue(str);
                            second.CreateCell(cellIndex++).SetCellValue(TTdata[x].SHOWNAMEMS);
                            second.CreateCell(cellIndex++).SetCellValue(TTdata[x].SHOWTIME);
                            second.CreateCell(cellIndex++).SetCellValue(TTdata[x].REMARK);

                            FIVES_CHECK_INFODETAIL MXmodel = new FIVES_CHECK_INFODETAIL();
                            MXmodel.INFOID = TTdata[x].INFOID;
                            FIVES_CHECK_INFODETAILList[] MXdata = fivesmodels.CHECK_INFODETAIL.Read(MXmodel, token);
                            for (int j = 0; j < MXdata.Length; j++)
                            {
                                int cellIthird = 0;
                                IRow third = sheet2.CreateRow(rowsthird++);
                                third.CreateCell(cellIthird++).SetCellValue(TTdata[x].OPINTMS);
                                third.CreateCell(cellIthird++).SetCellValue(TTdata[x].DEPARTMS);
                                third.CreateCell(cellIthird++).SetCellValue(TTdata[x].SHOWNAMEMS);
                                third.CreateCell(cellIthird++).SetCellValue(TTdata[x].SHOWTIME);
                                third.CreateCell(cellIthird++).SetCellValue(MXdata[j].TYPEMS);
                                third.CreateCell(cellIthird++).SetCellValue(MXdata[j].REMARK);
                            }
                        }
                        for (int columnNum = 0; columnNum <= TTdata.Length; columnNum++)
                        {
                            int columnWidth = sheet1.GetColumnWidth(columnNum) / 256;
                            for (int rowNum = 1; rowNum <= sheet.LastRowNum; rowNum++)
                            {
                                IRow currentRow;
                                //当前行未被使用过
                                if (sheet1.GetRow(rowNum) == null)
                                {
                                    currentRow = sheet1.CreateRow(rowNum);
                                }
                                else
                                {
                                    currentRow = sheet1.GetRow(rowNum);
                                }

                                if (currentRow.GetCell(columnNum) != null)
                                {
                                    ICell currentCell = currentRow.GetCell(columnNum);
                                    int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;
                                    if (columnWidth < length)
                                    {
                                        columnWidth = length;
                                    }
                                }
                            }
                            sheet.SetColumnWidth(columnNum, columnWidth * 256);
                        }
                    }
                    //获取当前列的宽度，然后对比本列的长度，取最大值
                    for (int columnNum = 0; columnNum <= hzarr.Length; columnNum++)
                    {
                        int columnWidth = sheet.GetColumnWidth(columnNum) / 256;
                        for (int rowNum = 1; rowNum <= sheet.LastRowNum; rowNum++)
                        {
                            IRow currentRow;
                            //当前行未被使用过
                            if (sheet.GetRow(rowNum) == null)
                            {
                                currentRow = sheet.CreateRow(rowNum);
                            }
                            else
                            {
                                currentRow = sheet.GetRow(rowNum);
                            }

                            if (currentRow.GetCell(columnNum) != null)
                            {
                                ICell currentCell = currentRow.GetCell(columnNum);
                                int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;
                                if (columnWidth < length)
                                {
                                    columnWidth = length;
                                }
                            }
                        }
                        sheet.SetColumnWidth(columnNum, columnWidth * 256);
                    }


                    sheet.ForceFormulaRecalculation = true;
                    sheet1.ForceFormulaRecalculation = true;
                    sheet2.ForceFormulaRecalculation = true;
                    string now = DateTime.Now.ToString("yyyyMMddHHmmss.fff");
                    FileStream file1 = new FileStream(string.Format(@"{0}/Areas/FIVES/ExcelTemplate/{1}.xlsx", Server.MapPath("~"), now + STAFFID + "13"), FileMode.Create);
                    workbook.Write(file1);
                    file1.Close();
                    rst.TYPE = "S";
                    rst.MESSAGE = now + STAFFID + "13";
                }


            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }
        public ActionResult EXPORT_CheckInfo(string filename, string downloadname)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/FIVES/ExcelTemplate/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", downloadname);
        }
        public string UPDATE_SHOWTIME(string TIME, string data)
        {
            token = appClass.CRM_Gettoken();
            FIVES_CHECK_INFO[] model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_CHECK_INFO[]>(data);
            for (int i = 0; i < model.Length; i++)
            {
                FIVES_CHECK_INFOList CXmodel = new FIVES_CHECK_INFOList();
                CXmodel.OPINTID = model[i].OPINTID;
                CXmodel.DEPARTID = model[i].DEPARTID;
                CXmodel.TYPEID = model[i].TYPEID;
                FIVES_CHECK_INFOList[] CXdata = fivesmodels.CHECK_INFO.Read(CXmodel, token);

                string temp = TIME.Substring(0, 10);

                //   var query = (from c in CXdata where c.SHOWTIME.Substring(0, 10) == temp select c).ToList();
                List<FIVES_CHECK_INFOList> query = new List<FIVES_CHECK_INFOList>(from c in CXdata where c.SHOWTIME.Substring(0, 10) == temp select c);
                if (query.Count > 0)
                {
                    //MES_RETURN_UI CXRES = new MES_RETURN_UI();
                    //CXRES.TYPE = "E";
                    //CXRES.MESSAGE = query[0].OPINTMS + TIME.Substring(0, 10) + "已经有点检记录，不允许修改";
                    //return Newtonsoft.Json.JsonConvert.SerializeObject(CXRES);
                    webmsg.KEY = 0;
                    webmsg.MSG = query[0].OPINTMS + TIME.Substring(0, 10) + "已经有点检记录，不允许修改"; ;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            int Temp_Minutes = 0, Temp_Seconds = 0;
            for (int i = 0; i < model.Length; i++)
            {
                if (i == 0)
                {
                    model[i].SHOWTIME = TIME;
                }
                else
                {
                    Temp_Minutes = Temp_Minutes + new Random().Next(3, 6);
                    Temp_Seconds = new Random().Next(0, 59);
                    model[i].SHOWTIME = Convert.ToDateTime(TIME).AddMinutes(Temp_Minutes).AddSeconds(Temp_Seconds).ToString();//随机时间

                }
                //    model[i].SHOWTIME = TIME;
                MES_RETURN_UI RES = fivesmodels.CHECK_INFO.Update(model[i], token);
                if (RES.TYPE != "S")
                {
                    webmsg.KEY = 0;
                    webmsg.MSG = "修改失败！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
                }
            }
            webmsg.KEY = 1;
            webmsg.MSG = "修改成功！";
            return Newtonsoft.Json.JsonConvert.SerializeObject(webmsg);
        }
        public string UPDATE_SHOWTIME_part(string TIME, string data)
        {
            token = appClass.CRM_Gettoken();
            FIVES_CHECK_INFO model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_CHECK_INFO>(data);

            FIVES_CHECK_INFOList CXmodel = new FIVES_CHECK_INFOList();
            CXmodel.OPINTID = model.OPINTID;
            CXmodel.DEPARTID = model.DEPARTID;
            CXmodel.TYPEID = model.TYPEID;
            FIVES_CHECK_INFOList[] CXdata = fivesmodels.CHECK_INFO.Read(CXmodel, token);


            string temp = TIME.Substring(0, 10);

            var query = (from c in CXdata where c.SHOWTIME.Substring(0, 10) == temp select c).ToList();
            if (query.Count > 0)
            {
                MES_RETURN_UI CXRES = new MES_RETURN_UI();
                CXRES.TYPE = "E";
                CXRES.MESSAGE = TIME.Substring(0, 10) + "已经有点检记录，不允许修改";
                return Newtonsoft.Json.JsonConvert.SerializeObject(CXRES);
            }
            model.SHOWTIME = TIME;
            MES_RETURN_UI RES = fivesmodels.CHECK_INFO.Update(model, token);
            if (RES.TYPE == "S")
            {
                RES.MESSAGE = "修改成功";
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(RES);
        }
        [HttpPost]
        public string getOPINTMS(string data)
        {
            string token = appClass.CRM_Gettoken();
            Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT model = Newtonsoft.Json.JsonConvert.DeserializeObject<Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINT>(data);
            Sonluk.UI.Model.S5.SY_CHECKPOINTService.FIVES_SY_CHECKPOINTList[] res = fivesmodels.SY_CHECKPOINT.ReadaddDepName(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }
        //[HttpPost]
        //public string getDJLX(int Depid)
        //{
        //    string token = appClass.CRM_Gettoken();
        //    FIVES_STAFF_DEP DEPmodel = new FIVES_STAFF_DEP();
        //    DEPmodel.STAFFID = appClass.CRM_GetStaffid();
        //    DEPmodel.DEPTID = Depid;
        //    FIVES_STAFF_DEP[] DEPdata = fivesmodels.STAFF_DEP.Read(DEPmodel, token);

        //    List<FIVES_SY_DICT> DICTdata = new List<FIVES_SY_DICT>();
        //    int i = 0;
        //    foreach (var item in DEPdata)
        //    {
        //        if (item.XJSTATUS != 0)
        //        {
        //            FIVES_SY_DICT temp_model = new FIVES_SY_DICT();
        //            temp_model.DICID = item.XID;
        //            temp_model.DICNAME = item.XNAME;
        //            DICTdata.Add(temp_model);

        //        }
        //        if (item.CJSTATUS != 0)
        //        {
        //            FIVES_SY_DICT temp_model = new FIVES_SY_DICT();
        //            temp_model.DICID = item.CID;
        //            temp_model.DICNAME = item.CNAME;
        //            DICTdata.Add(temp_model);
        //        }
        //        if (item.XFDJSTATUS != 0)
        //        {
        //            FIVES_SY_DICT temp_model = new FIVES_SY_DICT();
        //            temp_model.DICID = item.XFDJID;
        //            temp_model.DICNAME = item.XFDJNAME;
        //            DICTdata.Add(temp_model);
        //        }
        //        if (item.STDJSTATUS != 0)
        //        {
        //            FIVES_SY_DICT temp_model = new FIVES_SY_DICT();
        //            temp_model.DICID = item.STDJID;
        //            temp_model.DICNAME = item.STDJNAME;
        //            DICTdata.Add(temp_model);
        //        }
        //        if (item.JFDJSTATUS != 0)
        //        {
        //            FIVES_SY_DICT temp_model = new FIVES_SY_DICT();
        //            temp_model.DICID = item.JFDJID;
        //            temp_model.DICNAME = item.JFDJNAME;
        //            DICTdata.Add(temp_model);
        //        }
        //    }

        //    FIVES_SY_DICT[] RESdata = DICTdata.ToArray();
        //    return Newtonsoft.Json.JsonConvert.SerializeObject(RESdata);
        //}
        [HttpPost]
        public string GetType(string data)
        {
            string token = appClass.CRM_Gettoken();
            FIVES_STAFF_DEP model = Newtonsoft.Json.JsonConvert.DeserializeObject<FIVES_STAFF_DEP>(data);
            model.STAFFID = appClass.CRM_GetStaffid();
            FIVES_STAFF_DEP[] res = fivesmodels.STAFF_DEP.Read(model, token);
            res = (from c in res where c.TYPENAME != "通知" select c).ToArray();
            return Newtonsoft.Json.JsonConvert.SerializeObject(res);
        }

    }
}
