using Sonluk.PC.APPCLASS;
using Sonluk.PC.Models;
using Sonluk.UI.Model.MES.BAT_SPECSService;
using Sonluk.UI.Model.MES.BAT_SPECS_SAMPService;
using Sonluk.UI.Model.MES.BAT_SPECS_PERFORService;
using Sonluk.UI.Model.MES.BAT_PACKAGEService;
using Sonluk.UI.Model.MES.BAT_REPORTService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Data;
using NPOI.SS.Converter;
using Sonluk.UI.Model.MODEL;
using Sonluk.UI.Model.MES.SY_GCService;
using Sonluk.UI.Model.MES.BAT_QLTYService;
using NPOI.SS.Util;

namespace Sonluk.PC.Areas.MES.Controllers
{
    public class YCLSYController : Controller
    {
        MESModels mesModels = new MESModels();
        const string BAT_REPORT_Template_View = "交收检验报告展示";
        const string BAT_REPORT_Template_ZH = "交收检验报告模板";
        const string BAT_REPORT_Template_EN = "交收检验报告模板EN";

        // GET: /MES/YCLSY/
        public ActionResult Index()
        {
            AppClass.SetSession("location", 0);
            return View();
        }
        public ActionResult BAT_SPECS()
        {
            AppClass.SetSession("location", 10024);
            return View();
        }
        public ActionResult BAT_SPECS_SAMP()
        {
            AppClass.SetSession("location", 10025);
            return View();
        }
        public ActionResult BAT_SPECS_PERFOR()
        {
            AppClass.SetSession("location", 10026);
            return View();
        }
        public ActionResult BAT_PACKAGE()
        {
            AppClass.SetSession("location", 10027);
            return View();
        }
        public ActionResult BAT_REPORT()
        {
            AppClass.SetSession("location", 10028);
            return View();
        }
        public ActionResult BAT_QLTY()
        {
            AppClass.SetSession("location", 10030);
            return View();
        }
        public ActionResult BAT_QLTY_TMARK()
        {
            AppClass.SetSession("location", 10032);
            return View();
        }
        public ActionResult BAT_QLTY_REPORT()
        {
            AppClass.SetSession("location", 10031);
            return View();
        }
        public ActionResult BAT_QLTY_TMARK_REPORT()
        {
            AppClass.SetSession("location", 10046);
            return View();
        }

        #region 通用 Get 和 Post

        public ActionResult Export_Download(string filename, string filenameout)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", filenameout + ".xls");
        }

        public ActionResult Template_Download(string filename, string filenameout)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            return File(arrFile, "application/vnd.ms-excel", filenameout + ".xls");
        }

        public ActionResult Export_Downloadx(string filename, string filenameout)
        {
            byte[] arrFile = null;
            string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xlsx", Server.MapPath("~"), filename);
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrFile = new byte[fs.Length];
                fs.Read(arrFile, 0, arrFile.Length);
            }
            System.IO.File.Delete(path);
            return File(arrFile, "application/vnd.ms-excel", filenameout + ".xlsx");
        }

        [HttpPost]
        public string BAT_MT_Search(int mt)//1（生产线），9（电池型号），14（素电类型），10（喷墨位置），11（绝缘圈）
        {
            string token = AppClass.GetSession("token").ToString();
            MES_DCBZ model = new MES_DCBZ();
            model.RI = mt;
            MES_DCBZ_SELECT rst = mesModels.BAT_SPECS.SELECT_LIST(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst.MES_DCBZ);
        }

        [HttpPost]
        public string BAT_GC_List(int mt)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_SY_GC model_MES_SY_GC = new MES_SY_GC();
            model_MES_SY_GC.STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_SY_GC[] MES_SY_GC_list = mesModels.SY_GC.SELECT_BY_ROLE(model_MES_SY_GC, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(MES_SY_GC_list);
        }

        #endregion

        #region BAT_SPECS

        [HttpPost]
        public string BAT_SPECS_Search_List(string DCXH)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_DCBZ_SELECT rst = mesModels.BAT_SPECS.SELECT_LIST_LEFT(DCXH, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst.MES_DCBZ);
        }

        [HttpPost]
        public string BAT_SPECS_Search(string datastring)
        {
            MES_DCBZ model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_DCBZ>(datastring);
            string token = AppClass.GetSession("token").ToString();
            MES_DCBZ_SELECT rst = mesModels.BAT_SPECS.SELECT_SPECS_FULL(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst.MES_DCBZ);
        }

        [HttpPost]
        public string BAT_SPECS_Create(string datastring)
        {
            MES_DCBZ model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_DCBZ>(datastring);
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = mesModels.BAT_SPECS.INSERT_FULL(model, token);
            if (rst.TYPE == "S")
            {
                return "新增成功！";
            }
            else if (rst.TYPE == "E")
            {
                return "新增失败！";
            }
            else
            {
                return "服务器异常！";
            }
        }

        [HttpPost]
        public string BAT_SPECS_Update(string datastring)
        {
            MES_DCBZ model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_DCBZ>(datastring);
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = mesModels.BAT_SPECS.UPDATE(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        [HttpPost]
        public string BAT_SPECS_Delete(string DCXH)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = mesModels.BAT_SPECS.DELETE(DCXH, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        #endregion

        #region BAT_SPECS_SAMP

        [HttpPost]
        public string BAT_SPECS_SAMP_Search(string datastring)
        {
            MES_DCCCCYSJ model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_DCCCCYSJ>(datastring);
            string token = AppClass.GetSession("token").ToString();
            MES_DCCCCYSJ_SELECT rst = mesModels.BAT_SPECS_SAMP.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst.MES_DCCCCYSJ);
        }

        [HttpPost]
        public string BAT_SPECS_SAMP_Create(string datastring)
        {
            MES_DCCCCYSJ model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_DCCCCYSJ>(datastring);
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = mesModels.BAT_SPECS_SAMP.INSERT(model, token);
            return rst.MESSAGE;
        }

        [HttpPost]
        public string BAT_SPECS_SAMP_Update(string datastring)
        {
            MES_DCCCCYSJ model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_DCCCCYSJ>(datastring);
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = mesModels.BAT_SPECS_SAMP.UPDATE(model, token);
            return rst.MESSAGE;

        }

        [HttpPost]
        public string BAT_SPECS_SAMP_Delete(int RI)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = mesModels.BAT_SPECS_SAMP.DELETE(RI, token);
            if (rst.TYPE == "S")
            {
                return "删除成功！";
            }
            else if (rst.TYPE == "E")
            {
                return "删除失败！";
            }
            else
            {
                return "服务器异常！";
            }
        }

        [HttpPost]
        public string BAT_SPECS_SAMP_Export(string datastring)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_DCCCCYSJ model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_DCCCCYSJ>(datastring);
            MES_DCCCCYSJ_SELECT rstdata = mesModels.BAT_SPECS_SAMP.SELECT(model, token);
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                IWorkbook mworkbook = new HSSFWorkbook(); ;
                ISheet msheet = mworkbook.CreateSheet(model.DCXH + " " + model.DCBZ);

                //标题栏样式
                ICellStyle style = mworkbook.CreateCellStyle();
                style.Alignment = HorizontalAlignment.Center;
                style.VerticalAlignment = VerticalAlignment.Center;
                style.BorderBottom = BorderStyle.Thin;
                style.BorderLeft = BorderStyle.Thin;
                style.BorderRight = BorderStyle.Thin;
                style.BorderTop = BorderStyle.Thin;

                //数据栏样式
                ICellStyle styleA = mworkbook.CreateCellStyle();
                styleA.Alignment = HorizontalAlignment.Center;
                styleA.VerticalAlignment = VerticalAlignment.Center;
                styleA.BorderBottom = BorderStyle.Thin;
                styleA.BorderLeft = BorderStyle.Thin;
                styleA.BorderRight = BorderStyle.Thin;
                styleA.BorderTop = BorderStyle.Thin;

                for (int i = 0; i < 1; i++)
                {
                    IRow row = msheet.CreateRow(i);
                    for (int j = 0; j < 4; j++) row.CreateCell(j).CellStyle = style;
                }
                for (int i = 1; i < rstdata.MES_DCCCCYSJ.Length + 1; i++)
                {
                    IRow row = msheet.CreateRow(i);
                    for (int j = 0; j < 4; j++) row.CreateCell(j).CellStyle = styleA;
                }

                msheet.GetRow(0).GetCell(0).SetCellValue("序号");
                msheet.GetRow(0).GetCell(1).SetCellValue("电池型号");
                msheet.GetRow(0).GetCell(2).SetCellValue("数值类型");
                msheet.GetRow(0).GetCell(3).SetCellValue("数值");

                for (int i = 0; i < rstdata.MES_DCCCCYSJ.Length; i++)
                {
                    int j = 0;
                    IRow row = msheet.GetRow(i + 1);
                    row.GetCell(j++).SetCellValue(i + 1);
                    row.GetCell(j++).SetCellValue(rstdata.MES_DCCCCYSJ[i].DCXH);
                    row.GetCell(j++).SetCellValue(rstdata.MES_DCCCCYSJ[i].DCBZ);
                    row.GetCell(j++).SetCellValue(rstdata.MES_DCCCCYSJ[i].SZ);
                }

                string filename = DateTime.Now.ToString("yyyyMMddHHmmss.fff") + "电池抽样数据";
                string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), filename);
                //open
                FileStream file_o = new FileStream(path, FileMode.Create, FileAccess.Write);
                mworkbook.Write(file_o);
                //close
                file_o.Close();
                rst.TYPE = "S";
                rst.MESSAGE = filename;
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "导出失败：" + e.Message;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        #endregion

        #region BAT_SPECS_PERFOR

        [HttpPost]
        public string BAT_SPECS_PERFOR_Search(string datastring)
        {
            MES_DCDXNSZ_SEARCH model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_DCDXNSZ_SEARCH>(datastring);
            string token = AppClass.GetSession("token").ToString();
            MES_DCDXNSZ_SELECT rst = mesModels.BAT_SPECS_PERFOR.SELECT(model, token);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst.MES_DCDXNSZ);
        }

        [HttpPost]
        public string BAT_SPECS_PERFOR_Cover(string datastring)
        {
            MES_DCDXNSZ model = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_DCDXNSZ>(datastring);
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = mesModels.BAT_SPECS_PERFOR.COVER(model, token);
            return rst.MESSAGE;
        }

        [HttpPost]
        public string BAT_SPECS_PERFOR_Delete(int RI)
        {
            string token = AppClass.GetSession("token").ToString();
            MES_RETURN_UI rst = mesModels.BAT_SPECS_PERFOR.DELETE(RI, token);
            if (rst.TYPE == "S")
            {
                return "删除成功！";
            }
            else if (rst.TYPE == "E")
            {
                return "删除失败！";
            }
            else
            {
                return "服务器异常！";
            }
        }

        [HttpPost]
        public string BAT_SPECS_PERFOR_Export(string datastring)
        {
            List<MES_DCDXNSZ> rstdata = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MES_DCDXNSZ>>(datastring);
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                IWorkbook mworkbook = new HSSFWorkbook();
                ISheet msheet = mworkbook.CreateSheet();

                //标题栏样式
                ICellStyle style = mworkbook.CreateCellStyle();
                style.Alignment = HorizontalAlignment.Center;
                style.VerticalAlignment = VerticalAlignment.Center;
                style.BorderBottom = BorderStyle.Thin;
                style.BorderLeft = BorderStyle.Thin;
                style.BorderRight = BorderStyle.Thin;
                style.BorderTop = BorderStyle.Thin;

                //数据栏样式
                ICellStyle styleA = mworkbook.CreateCellStyle();
                styleA.Alignment = HorizontalAlignment.Center;
                styleA.VerticalAlignment = VerticalAlignment.Center;
                styleA.BorderBottom = BorderStyle.Thin;
                styleA.BorderLeft = BorderStyle.Thin;
                styleA.BorderRight = BorderStyle.Thin;
                styleA.BorderTop = BorderStyle.Thin;

                for (int i = 0; i < 1; i++)
                {
                    IRow row = msheet.CreateRow(i);
                    for (int j = 0; j < 6; j++) row.CreateCell(j).CellStyle = style;
                }
                for (int i = 1; i < rstdata.Count + 1; i++)
                {
                    IRow row = msheet.CreateRow(i);
                    for (int j = 0; j < 6; j++) row.CreateCell(j).CellStyle = styleA;
                }

                msheet.GetRow(0).GetCell(0).SetCellValue("序号");
                msheet.GetRow(0).GetCell(1).SetCellValue("电池型号");
                msheet.GetRow(0).GetCell(2).SetCellValue("生产线");
                msheet.GetRow(0).GetCell(3).SetCellValue("素电类型");
                msheet.GetRow(0).GetCell(4).SetCellValue("日期");
                msheet.GetRow(0).GetCell(5).SetCellValue("数值");

                for (int i = 0; i < rstdata.Count; i++)
                {
                    int j = 0;
                    IRow row = msheet.GetRow(i + 1);
                    row.GetCell(j++).SetCellValue(i + 1);
                    row.GetCell(j++).SetCellValue(rstdata[i].DCXH);
                    row.GetCell(j++).SetCellValue(rstdata[i].SCX);
                    row.GetCell(j++).SetCellValue(rstdata[i].SDDJ);
                    row.GetCell(j++).SetCellValue(rstdata[i].RQ);
                    row.GetCell(j++).SetCellValue(rstdata[i].SZ);
                }

                string filename = DateTime.Now.ToString("yyyyMMddHHmmss.fff") + "电性能数据";
                string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), filename);
                //open
                FileStream file_o = new FileStream(path, FileMode.Create, FileAccess.Write);
                mworkbook.Write(file_o);
                //close
                file_o.Close();
                rst.TYPE = "S";
                rst.MESSAGE = filename;
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "导出失败：" + e.Message;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        [HttpPost]
        public string BAT_SPECS_PERFOR_Import(string DATEM)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            HttpPostedFileBase file = Request.Files[0];
            IWorkbook mworkbook;
            if (DATEM == "")
            {
                rst.TYPE = "E-Ctrl";
                rst.MESSAGE = "请选择年月。";
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
            }
            try
            {
                if (file.FileName.IndexOf(".xlsx") > 0) mworkbook = new XSSFWorkbook(file.InputStream);
                else if (file.FileName.IndexOf(".xls") > 0) mworkbook = new HSSFWorkbook(file.InputStream);
                else
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "请使用Excel文件！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                }

                ISheet msheet = mworkbook.GetSheetAt(0);

                if (msheet != null)
                {
                    IRow firstRow = msheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数
                    int startRow = 6;
                    int endRow = 36;
                    bool verify = true;
                    //验证表格
                    for (int i = startRow; i <= endRow; i++)
                    {
                        if (msheet.GetRow(i).GetCell(0) == null)
                        {
                            if (i < 33) verify = false;
                            else endRow = i - 1;
                            break;
                        }
                        if (i - 5 != msheet.GetRow(i).GetCell(0).NumericCellValue)
                        {
                            if (i < 33) verify = false; //填写正确的日期至少到28号
                            else endRow = i - 1;
                            break;
                        }
                    }
                    if (verify)
                    {
                        string msg = "";
                        string token = AppClass.GetSession("token").ToString();
                        List<MES_DCDXNSZ> modelList = new List<MES_DCDXNSZ>();
                        for (int j = 1; j < cellCount; j++)
                        {
                            int datacol = j;
                            if (msheet.GetRow(1).GetCell(j) == null)
                            {
                                msg = msg + "[?]第" + datacol + "列无电池型号数据，该列不进行导入。";
                                continue;
                            }
                            else
                            {
                                msheet.GetRow(1).GetCell(j).SetCellType(CellType.String);
                                if (msheet.GetRow(1).GetCell(j).StringCellValue == "")
                                {
                                    msg = msg + "[?]第" + datacol + "列无电池型号数据，该列不进行导入。";
                                    continue;
                                }
                            }
                            if (msheet.GetRow(3).GetCell(j) == null)
                            {
                                msg = msg + "[?]第" + datacol + "列无生产线数据，该列不进行导入。";
                                continue;
                            }
                            else
                            {
                                msheet.GetRow(3).GetCell(j).SetCellType(CellType.String);
                                if (msheet.GetRow(3).GetCell(j).StringCellValue == "")
                                {
                                    msg = msg + "[?]第" + datacol + "列无生产线数据，该列不进行导入。";
                                    continue;
                                }
                            }
                            if (msheet.GetRow(4).GetCell(j) == null)
                            {
                                msg = msg + "[?]第" + datacol + "列无素电类型数据，该列不进行导入。";
                                continue;
                            }
                            else
                            {
                                msheet.GetRow(4).GetCell(j).SetCellType(CellType.String);
                                if (msheet.GetRow(4).GetCell(j).StringCellValue == "")
                                {
                                    msg = msg + "[?]第" + datacol + "列无素电类型数据，该列不进行导入。";
                                    continue;
                                }
                            }
                            for (int i = startRow; i <= endRow; i++)
                            {
                                if (msheet.GetRow(i).GetCell(j) != null)
                                {
                                    msheet.GetRow(i).GetCell(j).SetCellType(CellType.String);
                                    string cell = msheet.GetRow(i).GetCell(j).StringCellValue;
                                    if (cell != "/" && cell != "")
                                    {
                                        MES_DCDXNSZ model = new MES_DCDXNSZ();
                                        model.SZ = msheet.GetRow(i).GetCell(j).StringCellValue;
                                        model.DCXH = msheet.GetRow(1).GetCell(j).StringCellValue;
                                        model.SCX = msheet.GetRow(3).GetCell(j).StringCellValue;
                                        model.SDDJ = msheet.GetRow(4).GetCell(j).StringCellValue;
                                        if (msheet.GetRow(i).GetCell(0).NumericCellValue < 10) model.RQ = DATEM + "-0" + msheet.GetRow(i).GetCell(0).NumericCellValue;
                                        else model.RQ = DATEM + "-" + msheet.GetRow(i).GetCell(0).NumericCellValue;
                                        modelList.Add(model);
                                    }
                                }
                            }
                        }
                        MES_DCDXNSZ_SELECT postList = new MES_DCDXNSZ_SELECT();
                        postList.MES_DCDXNSZ = new MES_DCDXNSZ[modelList.Count];
                        postList.MES_DCDXNSZ = modelList.ToArray();
                        MES_RETURN_UI rst_son = mesModels.BAT_SPECS_PERFOR.MCOVER_LIST(postList, token);
                        if (rst_son.TYPE == "S")
                        {
                            rst.TYPE = "S";
                            if (msg == "") rst.MESSAGE = "导入成功：[?]" + rst_son.MESSAGE;
                            else rst.MESSAGE = "部分导入成功：[?]" + rst_son.MESSAGE + msg;
                        }
                        else
                        {
                            rst.TYPE = "E";
                            if (msg == "") rst.MESSAGE = "导入失败：[?]" + rst_son.MESSAGE;
                            else rst.MESSAGE = "导入失败：[?]" + rst_son.MESSAGE + msg;
                        }
                    }
                    else
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "导入失败：[?]请使用最新数据表模板。";
                    }
                }
                else
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "导入失败：[?]无数据。";
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "导入失败：[?]" + e.Message;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        [HttpPost]
        public string BAT_SPECS_PERFOR_Import_Single(string DATEM)
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            HttpPostedFileBase file = Request.Files[0];
            IWorkbook mworkbook = new HSSFWorkbook();
            if (DATEM == "")
            {
                rst.TYPE = "E";
                rst.MESSAGE = "请选择年月。";
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
            }
            try
            {
                if (file.FileName.IndexOf(".xlsx") > 0) mworkbook = new XSSFWorkbook(file.InputStream);
                else if (file.FileName.IndexOf(".xls") > 0) mworkbook = new HSSFWorkbook(file.InputStream);

                ISheet msheet = mworkbook.GetSheetAt(0);

                if (msheet != null)
                {
                    IRow firstRow = msheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数
                    int startRow = 6;
                    bool verify = true;
                    //验证表格
                    for (int i = 0; i <= 29; i++)
                    {
                        if (i + 1 != msheet.GetRow(startRow + i).GetCell(0).NumericCellValue)
                        {
                            verify = false;
                            break;
                        }
                    }
                    if (verify)
                    {
                        string msg = "";
                        string token = AppClass.GetSession("token").ToString();
                        for (int j = 1; j < cellCount; j++)
                        {
                            int datacol = j - 1;
                            if (msheet.GetRow(1).GetCell(j) == null)
                            {
                                msg = msg + " 第" + datacol + "列无电池型号数据，该列未导入。";
                                continue;
                            }
                            else
                            {
                                msheet.GetRow(1).GetCell(j).SetCellType(CellType.String);
                                if (msheet.GetRow(1).GetCell(j).StringCellValue == "")
                                {
                                    msg = msg + " 第" + datacol + "列无电池型号数据，该列未导入。";
                                    continue;
                                }
                            }
                            if (msheet.GetRow(3).GetCell(j) == null)
                            {
                                msg = msg + " 第" + datacol + "列无生产线数据，该列未导入。";
                                continue;
                            }
                            else
                            {
                                msheet.GetRow(3).GetCell(j).SetCellType(CellType.String);
                                if (msheet.GetRow(3).GetCell(j).StringCellValue == "")
                                {
                                    msg = msg + " 第" + datacol + "列无生产线数据，该列未导入。";
                                    continue;
                                }
                            }
                            if (msheet.GetRow(4).GetCell(j) == null)
                            {
                                msg = msg + " 第" + datacol + "列无素电类型数据，该列未导入。";
                                continue;
                            }
                            else
                            {
                                msheet.GetRow(4).GetCell(j).SetCellType(CellType.String);
                                if (msheet.GetRow(4).GetCell(j).StringCellValue == "")
                                {
                                    msg = msg + " 第" + datacol + "列无素电类型数据，该列未导入。";
                                    continue;
                                }
                            }
                            for (int i = startRow; i <= startRow + 29; i++)
                            {
                                if (msheet.GetRow(i).GetCell(j) != null)
                                {
                                    msheet.GetRow(i).GetCell(j).SetCellType(CellType.String);
                                    string cell = msheet.GetRow(i).GetCell(j).StringCellValue;
                                    if (cell != "/" && cell != "")
                                    {
                                        MES_DCDXNSZ model = new MES_DCDXNSZ();
                                        model.SZ = msheet.GetRow(i).GetCell(j).StringCellValue;
                                        model.DCXH = msheet.GetRow(1).GetCell(j).StringCellValue;
                                        model.SCX = msheet.GetRow(3).GetCell(j).StringCellValue;
                                        model.SDDJ = msheet.GetRow(4).GetCell(j).StringCellValue;
                                        if (msheet.GetRow(i).GetCell(0).NumericCellValue < 10) model.RQ = DATEM + "-0" + msheet.GetRow(i).GetCell(0).NumericCellValue;
                                        else model.RQ = DATEM + "-" + msheet.GetRow(i).GetCell(0).NumericCellValue;
                                        MES_RETURN_UI rst_son = mesModels.BAT_SPECS_PERFOR.COVER(model, token);
                                        if (rst_son.TYPE == "E")
                                        {
                                            int ecol = j - 1;
                                            int erow = i - startRow + 1;
                                            rst.TYPE = "E";
                                            if (msg == "") rst.MESSAGE = "导入失败，第" + ecol + "列，" + erow + "号的数据有问题，请检查，之前的数据均已导入。错误信息：" + rst_son.MESSAGE;
                                            else rst.MESSAGE = "导入失败，第" + erow + "列，" + ecol + "号的数据有问题，请检查，之前的数据（除" + msg + " 之外）均已导入。错误信息：" + rst_son.MESSAGE;
                                            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                                        }
                                    }
                                }
                            }
                        }
                        rst.TYPE = "S";
                        if (msg == "") rst.MESSAGE = "导入成功！";
                        else rst.MESSAGE = "部分导入成功，其中：" + msg;
                    }
                    else
                    {
                        rst.TYPE = "E";
                        rst.MESSAGE = "请使用最新数据表模板。";
                    }
                }
                else
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "无数据。";
                }
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = e.Message;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        #endregion

        #region BAT_PACKAGE

        [HttpPost]
        public string BAT_PACKAGE_Search(string datastring)
        {
            MES_PD_GD_PACKINFO_SEARCH postData = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_GD_PACKINFO_SEARCH>(datastring);
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_PD_GD_PACKINFO_SELECT rst = mesModels.BAT_PACKAGE.SELECT_LIST(postData, token, STAFFID);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        [HttpPost]
        public string BAT_PACKAGE_Cover(string datastring)
        {
            MES_PD_GD_PACKINFO postData = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_PD_GD_PACKINFO>(datastring);
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI rst = mesModels.BAT_PACKAGE.COVER(postData, token, STAFFID);
            return rst.MESSAGE;
        }

        [HttpPost]
        public string BAT_PACKAGE_Delete(string GDDH)
        {
            string token = AppClass.GetSession("token").ToString();
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            MES_RETURN_UI rst = mesModels.BAT_PACKAGE.DELETE(GDDH, token, STAFFID);
            return rst.MESSAGE;
        }

        [HttpPost]
        public string BAT_PACKAGE_Import()
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            HttpPostedFileBase file = Request.Files[0];
            DataTable dt = ExcelToDataTable(file, true);
            if (dt != null)
            {
                if (dt.TableName == "Error")
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "导入失败，错误信息：" + dt.Rows[0]["MESSAGE"].ToString();
                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                }

                if (dt.Columns.Contains("工厂") == false ||
                    dt.Columns.Contains("生产订单号") == false ||
                    dt.Columns.Contains("订单数量（箱）") == false ||
                    dt.Columns.Contains("电池喷码") == false ||
                    dt.Columns.Contains("检验标准") == false ||
                    dt.Columns.Contains("喷码位置") == false ||
                    dt.Columns.Contains("检验水平（抽箱数）") == false ||
                    dt.Columns.Contains("检验水平（外观）") == false ||
                    dt.Columns.Contains("卡片日期唛") == false ||
                    dt.Columns.Contains("绝缘圈") == false)
                {
                    rst.TYPE = "E";
                    rst.MESSAGE = "请使用外观与包装模版！";
                    return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                }

                int insertNum = 0;
                int updateNum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MES_PD_GD_PACKINFO coverData = new MES_PD_GD_PACKINFO();
                    coverData.GC = dt.Rows[i]["工厂"].ToString();
                    coverData.ERPNO = dt.Rows[i]["生产订单号"].ToString();
                    coverData.COUNTX = dt.Rows[i]["订单数量（箱）"].ToString();
                    coverData.CODOWORD = dt.Rows[i]["电池喷码"].ToString();
                    coverData.SNINFO = dt.Rows[i]["检验标准"].ToString();
                    coverData.WORDSPACE = dt.Rows[i]["喷码位置"].ToString();
                    coverData.CXS = dt.Rows[i]["检验水平（抽箱数）"].ToString();
                    coverData.WG = dt.Rows[i]["检验水平（外观）"].ToString();
                    coverData.KPRQM = dt.Rows[i]["卡片日期唛"].ToString();
                    coverData.INSULATION = dt.Rows[i]["绝缘圈"].ToString();
                    string token = AppClass.GetSession("token").ToString();
                    int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
                    rst = mesModels.BAT_PACKAGE.COVER(coverData, token, STAFFID);
                    if (rst.TYPE == "S")
                    {
                        if (rst.MESSAGE == "已新增") insertNum++;
                        else if (rst.MESSAGE == "已更新") updateNum++;
                    }
                    else if (rst.TYPE == "E")
                    {
                        rst.MESSAGE = "已导入 " + i + " / " + dt.Rows.Count + " 条数据，但是第" + (i + 1) + "条数据导入失败（该条及之后的数据均已中止导入），错误信息：" + rst.MESSAGE;
                        return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
                    }
                }
                rst.MESSAGE = "已导入 " + (insertNum + updateNum) + " / " + dt.Rows.Count + " 条数据，其中新增" + insertNum + "条，更新" + updateNum + "条。";
            }
            else
            {
                rst.TYPE = "E";
                rst.MESSAGE = "Excel转DataTable失败！";
                return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        [HttpPost]
        public string BAT_PACKAGE_Export(string datastring)
        {
            List<MES_PD_GD_PACKINFO> rstdata = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MES_PD_GD_PACKINFO>>(datastring);
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                IWorkbook mworkbook = new HSSFWorkbook();
                ISheet msheet = mworkbook.CreateSheet();

                //标题栏样式
                ICellStyle style = mworkbook.CreateCellStyle();
                style.Alignment = HorizontalAlignment.Center;
                style.VerticalAlignment = VerticalAlignment.Center;
                style.BorderBottom = BorderStyle.Thin;
                style.BorderLeft = BorderStyle.Thin;
                style.BorderRight = BorderStyle.Thin;
                style.BorderTop = BorderStyle.Thin;

                //数据栏样式
                ICellStyle styleA = mworkbook.CreateCellStyle();
                styleA.Alignment = HorizontalAlignment.Center;
                styleA.VerticalAlignment = VerticalAlignment.Center;
                styleA.BorderBottom = BorderStyle.Thin;
                styleA.BorderLeft = BorderStyle.Thin;
                styleA.BorderRight = BorderStyle.Thin;
                styleA.BorderTop = BorderStyle.Thin;

                for (int i = 0; i < 1; i++)
                {
                    IRow row = msheet.CreateRow(i);
                    for (int j = 0; j < 14; j++) row.CreateCell(j).CellStyle = style;
                }
                for (int i = 1; i < rstdata.Count + 1; i++)
                {
                    IRow row = msheet.CreateRow(i);
                    for (int j = 0; j < 14; j++) row.CreateCell(j).CellStyle = styleA;
                }
                msheet.SetColumnWidth(2, 11 * 256);
                msheet.SetColumnWidth(3, 16 * 256);
                msheet.SetColumnWidth(4, 12 * 256);
                msheet.SetColumnWidth(5, 52 * 256);
                msheet.SetColumnWidth(6, 15 * 256);
                msheet.SetColumnWidth(10, 19 * 256);
                msheet.SetColumnWidth(11, 17 * 256);
                msheet.SetColumnWidth(12, 11 * 256);

                int cellNum = 0;
                msheet.GetRow(0).GetCell(cellNum++).SetCellValue("序号");
                msheet.GetRow(0).GetCell(cellNum++).SetCellValue("工厂");
                msheet.GetRow(0).GetCell(cellNum++).SetCellValue("生产订单号");
                msheet.GetRow(0).GetCell(cellNum++).SetCellValue("销售订单号");
                msheet.GetRow(0).GetCell(cellNum++).SetCellValue("物料号");
                msheet.GetRow(0).GetCell(cellNum++).SetCellValue("物料描述");
                msheet.GetRow(0).GetCell(cellNum++).SetCellValue("订单数量（箱）");
                msheet.GetRow(0).GetCell(cellNum++).SetCellValue("电池喷码");
                msheet.GetRow(0).GetCell(cellNum++).SetCellValue("检验标准");
                msheet.GetRow(0).GetCell(cellNum++).SetCellValue("喷码位置");
                msheet.GetRow(0).GetCell(cellNum++).SetCellValue("检验水平（抽箱数）");
                msheet.GetRow(0).GetCell(cellNum++).SetCellValue("检验水平（外观）");
                msheet.GetRow(0).GetCell(cellNum++).SetCellValue("卡片日期唛");
                msheet.GetRow(0).GetCell(cellNum++).SetCellValue("绝缘圈");

                for (int i = 0; i < rstdata.Count; i++)
                {
                    int j = 0;
                    IRow row = msheet.GetRow(i + 1);
                    row.GetCell(j++).SetCellValue(i + 1);
                    row.GetCell(j++).SetCellValue(rstdata[i].GC);
                    row.GetCell(j++).SetCellValue(rstdata[i].ERPNO);
                    row.GetCell(j++).SetCellValue(rstdata[i].XSNOBILL + "-" + rstdata[i].XSNOBILLMX);
                    row.GetCell(j++).SetCellValue(rstdata[i].WLH);
                    row.GetCell(j++).SetCellValue(rstdata[i].WLMS);
                    row.GetCell(j++).SetCellValue(rstdata[i].COUNTX);
                    row.GetCell(j++).SetCellValue(rstdata[i].CODOWORD);
                    row.GetCell(j++).SetCellValue(rstdata[i].SNINFO);
                    row.GetCell(j++).SetCellValue(rstdata[i].WORDSPACE);
                    row.GetCell(j++).SetCellValue(rstdata[i].CXS);
                    row.GetCell(j++).SetCellValue(rstdata[i].WG);
                    row.GetCell(j++).SetCellValue(rstdata[i].KPRQM);
                    row.GetCell(j++).SetCellValue(rstdata[i].INSULATION);
                }

                string filename = DateTime.Now.ToString("yyyyMMddHHmmss.fff") + "外观与包装";
                string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), filename);
                //open
                FileStream file_o = new FileStream(path, FileMode.Create, FileAccess.Write);
                mworkbook.Write(file_o);
                //close
                file_o.Close();
                rst.TYPE = "S";
                rst.MESSAGE = filename;
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "导出失败：" + e.Message;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        #endregion

        #region BAT_REPORT

        [HttpPost]
        public string BAT_REPORT_Search(string datastring)
        {
            MES_BAT_REPORT_SEARCH postData = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_BAT_REPORT_SEARCH>(datastring);
            MES_BAT_REPORT rst = new MES_BAT_REPORT();
            rst.MES_RETURN = new UI.Model.MES.BAT_REPORTService.MES_RETURN();
            if (postData.ERPNO == "" && postData.XSNOBILL == "" && postData.XSNOBILLMX == "")
            {
                string templatePath = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), BAT_REPORT_Template_View);
                try
                {
                    using (FileStream fs = new FileStream(templatePath, FileMode.Open, FileAccess.Read))
                    {
                        rst.File = ExcelToHtmlStr(fs);
                        rst.MES_RETURN.TYPE = "S";
                        rst.MES_RETURN.MESSAGE = "预览表生成成功！";
                    }
                }
                catch (Exception e)
                {
                    rst.MES_RETURN.TYPE = "E";
                    rst.MES_RETURN.MESSAGE = "预览表生成失败：" + e.Message;
                }
            }
            else
            {
                string token = AppClass.GetSession("token").ToString();
                int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
                rst = mesModels.BAT_REPORT.SEARCH(postData, token, STAFFID);
                if (rst.MES_RETURN.TYPE == "S" || rst.MES_RETURN.TYPE == "W")
                {
                    rst = BAT_REPORT_ModelToExcel(rst, "查询", BAT_REPORT_Template_View);
                    string tempPath = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), rst.File);
                    try
                    {
                        FileStream stream = System.IO.File.OpenRead(tempPath);
                        rst.File = ExcelToHtmlStr(stream);
                        System.IO.File.Delete(tempPath);
                        stream.Close();
                    }
                    catch (Exception e)
                    {
                        rst.MES_RETURN.TYPE = "E";
                        rst.MES_RETURN.MESSAGE = "预览表生成失败：" + e.Message;
                    }
                }
                else
                {
                    string templatePath = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), BAT_REPORT_Template_View);
                    try
                    {
                        using (FileStream fs = new FileStream(templatePath, FileMode.Open, FileAccess.Read))
                        {
                            rst.File = ExcelToHtmlStr(fs);
                        }
                    }
                    catch (Exception e)
                    {
                        rst.MES_RETURN.TYPE = "E";
                        rst.MES_RETURN.MESSAGE = "预览表生成失败：" + e.Message;
                    }
                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        [HttpPost]
        public string BAT_REPORT_Export(string datastring)
        {
            MES_BAT_REPORT exportData = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_BAT_REPORT>(datastring);
            MES_BAT_REPORT rst = BAT_REPORT_ModelToExcel(exportData, "导出", BAT_REPORT_Template_ZH);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        [HttpPost]
        public string BAT_REPORT_Export_En(string datastring)
        {
            MES_BAT_REPORT exportData = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_BAT_REPORT>(datastring);
            MES_BAT_REPORT rst = BAT_REPORT_ModelToExcel(exportData, "导出", BAT_REPORT_Template_EN, 1);
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        //填充Excel并保存
        private MES_BAT_REPORT BAT_REPORT_ModelToExcel(MES_BAT_REPORT model, string name, string templateName, int DISP_H = 0)
        {
            if (model.MES_RETURN.TYPE == "S" || model.MES_RETURN.TYPE == "W")
            {
                try
                {
                    IWorkbook mworkbook = new HSSFWorkbook();
                    string templatePath = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), templateName);
                    try
                    {
                        FileStream stream = System.IO.File.OpenRead(templatePath);//open
                        mworkbook = new HSSFWorkbook(stream);
                        stream.Close();                                            //close
                    }
                    catch (Exception e)
                    {
                        model.MES_RETURN.TYPE = "E";
                        model.MES_RETURN.MESSAGE = name + "失败：" + e.Message;
                        return model;
                    }
                    ISheet msheet = mworkbook.GetSheetAt(0);
                    if (msheet != null)
                    {
                        if (model.ERPNO != "")
                        {
                            msheet.GetRow(3).GetCell(6 + DISP_H).SetCellValue(model.WLMS);     //品种规格
                            msheet.GetRow(3).GetCell(24 + DISP_H).SetCellValue(model.XSNOBILL + "-" + model.XSNOBILLMX); //作业单号码
                            msheet.GetRow(4).GetCell(6 + DISP_H).SetCellValue(model.COUNTX);   //数量（箱）
                            msheet.GetRow(4).GetCell(9 + DISP_H).SetCellValue(model.COUNTZ);   //数量（只）
                            msheet.GetRow(4).GetCell(17 + DISP_H).SetCellValue(model.SCX);     //素电生产线
                            msheet.GetRow(4).GetCell(24 + DISP_H).SetCellValue(model.DATE);    //素电日期

                            msheet.GetRow(8).GetCell(13 + DISP_H).SetCellValue(model.DCMINA);  //电池尺寸A最小值
                            msheet.GetRow(8).GetCell(17 + DISP_H).SetCellValue(model.DCMAXA);  //电池尺寸A最大值
                            msheet.GetRow(8).GetCell(21 + DISP_H).SetCellValue(model.SZA);     //实测结果范围A
                            msheet.GetRow(9).GetCell(13 + DISP_H).SetCellValue(model.DCMINB);  //电池尺寸B最小值
                            msheet.GetRow(9).GetCell(17 + DISP_H).SetCellValue(model.DCMAXB);  //电池尺寸B最大值
                            msheet.GetRow(9).GetCell(21 + DISP_H).SetCellValue(model.SZB);     //实测结果范围B
                            msheet.GetRow(10).GetCell(13 + DISP_H).SetCellValue(model.DCMINC); //电池尺寸C最小值
                            msheet.GetRow(10).GetCell(17 + DISP_H).SetCellValue(model.DCMAXC); //电池尺寸C最大值
                            msheet.GetRow(10).GetCell(21 + DISP_H).SetCellValue(model.SZC);    //实测结果范围C
                            msheet.GetRow(11).GetCell(13 + DISP_H).SetCellValue(model.DCMINK); //电池开路电压最小值
                            msheet.GetRow(11).GetCell(17 + DISP_H).SetCellValue(model.DCMAXK); //电池开路电压最大值
                            msheet.GetRow(11).GetCell(21 + DISP_H).SetCellValue(model.SZK);    //实测结果范围开路电压
                            msheet.GetRow(12).GetCell(13 + DISP_H).SetCellValue(model.DCFDFS); //电池放电方式
                            if (model.DCMAD != "") msheet.GetRow(12).GetCell(19 + DISP_H).SetCellValue("≥" + model.DCMAD);  //电池放电性能
                            msheet.GetRow(12).GetCell(21 + DISP_H).SetCellValue(model.SZDXN);  //实测结果范围

                            msheet.GetRow(13).GetCell(10 + DISP_H).SetCellValue(model.SAMP1);  //抽样数1
                            msheet.GetRow(14).GetCell(10 + DISP_H).SetCellValue(model.SAMP2);  //抽样数2
                            msheet.GetRow(15).GetCell(10 + DISP_H).SetCellValue(model.SAMP3);  //抽样数3
                            msheet.GetRow(16).GetCell(10 + DISP_H).SetCellValue(model.SAMP4);  //抽样数4
                            msheet.GetRow(5).GetCell(6 + DISP_H).SetCellValue(model.PACKOPEN); //抽箱数

                            msheet.GetRow(15).GetCell(13 + DISP_H).SetCellValue(model.CODOWORD);   //日期唛
                            msheet.GetRow(15).GetCell(21 + DISP_H).SetCellValue(model.CODOWORD);   //日期唛

                            msheet.GetRow(22).GetCell(5 + DISP_H).SetCellValue("林凯丽");      //检验员
                            msheet.GetRow(23).GetCell(5 + DISP_H).SetCellValue(model.JSDATE);  //检验日期
                            msheet.GetRow(22).GetCell(20 + DISP_H).SetCellValue("高红欣");     //审核
                            msheet.GetRow(23).GetCell(20 + DISP_H).SetCellValue(model.JSDATE); //审核日期
                        }
                        model.File = DateTime.Now.ToString("yyyyMMddHHmmss.fff") + "交收检验报告";
                        string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), model.File);
                        FileStream file_o = new FileStream(path, FileMode.Create, FileAccess.Write);//open
                        mworkbook.Write(file_o);
                        file_o.Close();                                                             //close
                        return model;
                    }
                    else
                    {
                        model.MES_RETURN.TYPE = "E";
                        model.MES_RETURN.MESSAGE = "模板不存在！";
                        return model;
                    }
                }
                catch (Exception e)
                {
                    model.MES_RETURN.TYPE = "E";
                    model.MES_RETURN.MESSAGE = name + "失败：" + e.Message;
                    return model;
                }
            }
            else return model;
        }

        #endregion

        #region BAT_QLTY

        [HttpPost]
        public string BAT_QLTY_Search(string datastring)
        {
            return AppClass.EasyCall<MES_ZLRBB_SEARCH, MES_ZLRBB_SELECT>(datastring, mesModels.BAT_QLTY.SELECT);
        }

        [HttpPost]
        public string BAT_QLTY_Update(string datastring)
        {
            return AppClass.EasyCall<MES_ZLRBB, MES_RETURN_UI>(datastring, mesModels.BAT_QLTY.COVER);
        }

        [HttpPost]
        public string BAT_QLTY_Update_TMark(string datastring)
        {
            return AppClass.EasyCall<MES_ZLRBB, MES_RETURN_UI>(datastring, mesModels.BAT_QLTY.COVER_TMARK);
        }

        [HttpPost]
        public string BAT_QLTY_Action(int RI)
        {
            return mesModels.BAT_QLTY.ACTION(RI, AppClass.GetSession("token").ToString()).MESSAGE;
        }

        [HttpPost]
        public string BAT_QLTY_Delete(int RI)
        {
            int STAFFID = Convert.ToInt32(AppClass.GetSession("STAFFID"));
            return mesModels.BAT_QLTY.DELETE(RI, STAFFID, AppClass.GetSession("token").ToString()).MESSAGE;
        }

        [HttpPost]
        public string BAT_QLTY_Delete_TMark(int RI)
        {
            return mesModels.BAT_QLTY.DELETE_TMARK(RI, AppClass.GetSession("token").ToString()).MESSAGE;
        }

        [HttpPost]
        public string BAT_QLTY_STAFF_Search(string datastring)
        {
            return AppClass.EasyCall<MES_ZLRBB_STAFF, MES_SELECTOfMES_ZLRBB_STAFF>(datastring, mesModels.BAT_QLTY.STAFF_SELECT);
        }

        #endregion

        #region BAT_QLTY_REPORT

        [HttpPost]
        public string BAT_QLTY_REPORT_Search(string datastring)
        {
            return AppClass.EasyCall<MES_ZLRBB_SEARCH, MES_ZLRBB_SELECT>(datastring, mesModels.BAT_QLTY.SELECT_SUM);
        }

        [HttpPost]
        public string BAT_QLTY_TMARK_REPORT_Search(string datastring)
        {
            return AppClass.EasyCall<MES_ZLRBB_SEARCH, MES_ZLRBB_SELECT>(datastring, mesModels.BAT_QLTY.TMARK_SELECT_SUM);
        }

        [HttpPost]
        public string BAT_QLTY_REPORT_Export(string datastring)
        {
            MES_ZLRBB_SELECT abcres = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZLRBB_SELECT>(datastring);
            MES_RETURN_UI abcr = new MES_RETURN_UI();
            try
            {
                MES_ZLRBB[] zlrbb = abcres.MES_ZLRBB;
                IWorkbook mworkbook = new HSSFWorkbook();
                ISheet msheet = mworkbook.CreateSheet("质量日报表");

                //标题栏样式
                ICellStyle style = mworkbook.CreateCellStyle();
                style.Alignment = HorizontalAlignment.Center;
                style.VerticalAlignment = VerticalAlignment.Center;
                style.BorderBottom = BorderStyle.Thin;
                style.BorderLeft = BorderStyle.Thin;
                style.BorderRight = BorderStyle.Thin;
                style.BorderTop = BorderStyle.Thin;
                style.WrapText = true;

                //数据栏样式
                ICellStyle styleA = mworkbook.CreateCellStyle();
                styleA.Alignment = HorizontalAlignment.Center;
                styleA.VerticalAlignment = VerticalAlignment.Center;
                styleA.BorderBottom = BorderStyle.Thin;
                styleA.BorderLeft = BorderStyle.Thin;
                styleA.BorderRight = BorderStyle.Thin;
                styleA.BorderTop = BorderStyle.Thin;

                for (int i = 0; i < 4; i++)
                {
                    IRow row = msheet.CreateRow(i);
                    row.HeightInPoints = 30;
                    for (int j = 0; j < 10; j++) row.CreateCell(j).CellStyle = style;
                }
                for (int i = 4; i < abcres.MES_ZLRBB.Length + 4; i++)
                {
                    IRow row = msheet.CreateRow(i);
                    for (int j = 0; j < 10; j++) row.CreateCell(j).CellStyle = styleA;
                }
                msheet.SetColumnWidth(12, 15 * 256);

                msheet.GetRow(0).GetCell(0).SetCellValue("质量日报表");
                msheet.GetRow(1).GetCell(0).SetCellValue("生产线");
                msheet.GetRow(1).GetCell(1).SetCellValue("不合格数量（只）");
                //msheet.GetRow(2).GetCell(10).SetCellValue("商标机");
                //msheet.GetRow(3).GetCell(10).SetCellValue("1.0V以下");
                //msheet.GetRow(3).GetCell(11).SetCellValue("1.0~1.595(1.60)V");
                //msheet.GetRow(3).GetCell(12).SetCellValue("1.595(1.60)V以上");
                //msheet.GetRow(3).GetCell(13).SetCellValue("设定值以下吹出电");
                //msheet.GetRow(3).GetCell(14).SetCellValue("外观不良");
                string[] list0 = { "正极环嵌入", "刻线", "封口剂涂布", "隔膜纸插入", "电解液注入", "锌膏注入", "封口成型", "导电膜涂布", "素电产量（万只）" };
                for (int i = 1; i < 10; i++)
                {
                    msheet.GetRow(2).GetCell(i).SetCellValue(list0[i - 1]);
                    msheet.AddMergedRegion(new CellRangeAddress(2, 3, i, i));
                }
                msheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 9));
                msheet.AddMergedRegion(new CellRangeAddress(1, 1, 1, 9));
                msheet.AddMergedRegion(new CellRangeAddress(1, 3, 0, 0));
                //msheet.AddMergedRegion(new CellRangeAddress(2, 2, 10, 9));

                for (int i = 0; i < abcres.MES_ZLRBB.Length; i++)
                {
                    int j = 0;
                    IRow row = msheet.GetRow(i + 4);
                    row.GetCell(j++).SetCellValue(zlrbb[i].SDLINE);
                    row.GetCell(j++).SetCellValue(zlrbb[i].ZJHQR);
                    row.GetCell(j++).SetCellValue(zlrbb[i].KX);
                    row.GetCell(j++).SetCellValue(zlrbb[i].FKJTB);
                    row.GetCell(j++).SetCellValue(zlrbb[i].GMZCR);
                    row.GetCell(j++).SetCellValue(zlrbb[i].DJYZR);
                    row.GetCell(j++).SetCellValue(zlrbb[i].XGZR);
                    row.GetCell(j++).SetCellValue(zlrbb[i].FKCX);
                    row.GetCell(j++).SetCellValue(zlrbb[i].DDMTB);
                    row.GetCell(j++).SetCellValue(zlrbb[i].SDCL);
                    //row.GetCell(j++).SetCellValue(zlrbb[i].VYX);
                    //row.GetCell(j++).SetCellValue(zlrbb[i].VZ);
                    //row.GetCell(j++).SetCellValue(zlrbb[i].VYS);
                    //row.GetCell(j++).SetCellValue(zlrbb[i].SDZYXCCD);
                    //row.GetCell(j++).SetCellValue(zlrbb[i].WGBL);
                }

                string now = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string filename = now + "质量日报表";
                string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), filename);
                //open
                FileStream file_o = new FileStream(path, FileMode.Create, FileAccess.Write);
                mworkbook.Write(file_o);
                //close
                file_o.Close();
                abcr.TYPE = "S";
                abcr.MESSAGE = filename;
            }
            catch (Exception e)
            {
                abcr.TYPE = "E";
                abcr.MESSAGE = "导出失败：" + e;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(abcr);
        }

        [HttpPost]
        public string BAT_QLTY_REPORT_Export_S(string datastring)
        {
            MES_ZLRBB_SELECT reabcres = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZLRBB_SELECT>(datastring);
            try
            {
                IWorkbook mworkbook = new HSSFWorkbook(); ;
                ISheet msheet = mworkbook.CreateSheet("质量日报表");

                //标题栏样式
                ICellStyle style = mworkbook.CreateCellStyle();
                style.Alignment = HorizontalAlignment.Center;
                style.VerticalAlignment = VerticalAlignment.Center;
                style.BorderBottom = BorderStyle.Thin;
                style.BorderLeft = BorderStyle.Thin;
                style.BorderRight = BorderStyle.Thin;
                style.BorderTop = BorderStyle.Thin;
                style.WrapText = true;

                //数据栏样式
                ICellStyle styleA = mworkbook.CreateCellStyle();
                styleA.Alignment = HorizontalAlignment.Center;
                styleA.VerticalAlignment = VerticalAlignment.Center;
                styleA.BorderBottom = BorderStyle.Thin;
                styleA.BorderLeft = BorderStyle.Thin;
                styleA.BorderRight = BorderStyle.Thin;
                styleA.BorderTop = BorderStyle.Thin;

                //创建单元格
                for (int i = 0; i < 4; i++)
                {
                    IRow row = msheet.CreateRow(i);
                    row.HeightInPoints = 30;
                    for (int j = 0; j < 13; j++) row.CreateCell(j).CellStyle = style;
                }
                for (int i = 4; i < 98; i++)
                {
                    IRow row = msheet.CreateRow(i);
                    row.CreateCell(0).CellStyle = style;
                    row.CreateCell(1).CellStyle = style;
                    for (int j = 2; j < 13; j++) row.CreateCell(j).CellStyle = styleA;
                }
                msheet.SetColumnWidth(0, 6 * 256);
                msheet.SetColumnWidth(1, 6 * 256);
                msheet.SetColumnWidth(15, 15 * 256);

                //填充数据，合并单元格
                msheet.GetRow(0).GetCell(0).SetCellValue("质量日报表");
                msheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 12));
                msheet.GetRow(1).GetCell(0).SetCellValue("日期");
                msheet.AddMergedRegion(new CellRangeAddress(1, 3, 0, 0));
                msheet.GetRow(1).GetCell(1).SetCellValue("班次");
                msheet.AddMergedRegion(new CellRangeAddress(1, 3, 1, 1));
                msheet.GetRow(1).GetCell(2).SetCellValue("填写人");
                msheet.AddMergedRegion(new CellRangeAddress(1, 3, 2, 2));
                msheet.GetRow(1).GetCell(3).SetCellValue("不合格数量（只）");
                msheet.AddMergedRegion(new CellRangeAddress(1, 1, 3, 12));
                //msheet.GetRow(2).GetCell(13).SetCellValue("商标机");
                //msheet.AddMergedRegion(new CellRangeAddress(2, 2, 13, 12));
                //msheet.GetRow(3).GetCell(13).SetCellValue("1.0V以下");
                //msheet.GetRow(3).GetCell(14).SetCellValue("1.0~1.595(1.60)V");
                //msheet.GetRow(3).GetCell(15).SetCellValue("1.595(1.60)V以上");
                //msheet.GetRow(3).GetCell(16).SetCellValue("设定值以下吹出电");
                //msheet.GetRow(3).GetCell(17).SetCellValue("外观不良");
                string[] listA = { "正极环嵌入", "刻线", "封口剂涂布", "隔膜纸插入", "电解液注入", "锌膏注入", "封口成型", "导电膜涂布", "素电产量（万只）", "备注" };
                for (int i = 3; i < 13; i++)
                {
                    msheet.GetRow(2).GetCell(i).SetCellValue(listA[i - 3]);
                    msheet.AddMergedRegion(new CellRangeAddress(2, 3, i, i));
                }

                for (int i = 0; i < 91; i = i + 3)
                {
                    IRow row = msheet.GetRow(i + 4);
                    IRow row2 = msheet.GetRow(i + 5);
                    IRow row3 = msheet.GetRow(i + 6);
                    row.GetCell(0).SetCellValue(i / 3 + 1);
                    msheet.AddMergedRegion(new CellRangeAddress(i + 4, i + 6, 0, 0));
                    row.GetCell(1).SetCellValue("日");
                    if (reabcres.MES_ZLRBB[i].SDLINE != null)
                    {
                        row.GetCell(2).SetCellValue(reabcres.MES_ZLRBB[i].JLTXR);
                        if (reabcres.MES_ZLRBB[i].ZJHQR != 0) row.GetCell(3).SetCellValue(reabcres.MES_ZLRBB[i].ZJHQR);
                        if (reabcres.MES_ZLRBB[i].KX != 0) row.GetCell(4).SetCellValue(reabcres.MES_ZLRBB[i].KX);
                        if (reabcres.MES_ZLRBB[i].FKJTB != 0) row.GetCell(5).SetCellValue(reabcres.MES_ZLRBB[i].FKJTB);
                        if (reabcres.MES_ZLRBB[i].GMZCR != 0) row.GetCell(6).SetCellValue(reabcres.MES_ZLRBB[i].GMZCR);
                        if (reabcres.MES_ZLRBB[i].DJYZR != 0) row.GetCell(7).SetCellValue(reabcres.MES_ZLRBB[i].DJYZR);
                        if (reabcres.MES_ZLRBB[i].XGZR != 0) row.GetCell(8).SetCellValue(reabcres.MES_ZLRBB[i].XGZR);
                        if (reabcres.MES_ZLRBB[i].FKCX != 0) row.GetCell(9).SetCellValue(reabcres.MES_ZLRBB[i].FKCX);
                        if (reabcres.MES_ZLRBB[i].DDMTB != 0) row.GetCell(10).SetCellValue(reabcres.MES_ZLRBB[i].DDMTB);
                        if (reabcres.MES_ZLRBB[i].SDCL != 0) row.GetCell(11).SetCellValue(reabcres.MES_ZLRBB[i].SDCL);
                        row.GetCell(12).SetCellValue(reabcres.MES_ZLRBB[i].BZ);
                    }
                    row2.GetCell(1).SetCellValue("中");
                    if (reabcres.MES_ZLRBB[i + 1].SDLINE != null)
                    {
                        row2.GetCell(2).SetCellValue(reabcres.MES_ZLRBB[i + 1].JLTXR);
                        if (reabcres.MES_ZLRBB[i + 1].ZJHQR != 0) row2.GetCell(3).SetCellValue(reabcres.MES_ZLRBB[i + 1].ZJHQR);
                        if (reabcres.MES_ZLRBB[i + 1].KX != 0) row2.GetCell(4).SetCellValue(reabcres.MES_ZLRBB[i + 1].KX);
                        if (reabcres.MES_ZLRBB[i + 1].FKJTB != 0) row2.GetCell(5).SetCellValue(reabcres.MES_ZLRBB[i + 1].FKJTB);
                        if (reabcres.MES_ZLRBB[i + 1].GMZCR != 0) row2.GetCell(6).SetCellValue(reabcres.MES_ZLRBB[i + 1].GMZCR);
                        if (reabcres.MES_ZLRBB[i + 1].DJYZR != 0) row2.GetCell(7).SetCellValue(reabcres.MES_ZLRBB[i + 1].DJYZR);
                        if (reabcres.MES_ZLRBB[i + 1].XGZR != 0) row2.GetCell(8).SetCellValue(reabcres.MES_ZLRBB[i + 1].XGZR);
                        if (reabcres.MES_ZLRBB[i + 1].FKCX != 0) row2.GetCell(9).SetCellValue(reabcres.MES_ZLRBB[i + 1].FKCX);
                        if (reabcres.MES_ZLRBB[i + 1].DDMTB != 0) row2.GetCell(10).SetCellValue(reabcres.MES_ZLRBB[i + 1].DDMTB);
                        if (reabcres.MES_ZLRBB[i + 1].SDCL != 0) row2.GetCell(11).SetCellValue(reabcres.MES_ZLRBB[i + 1].SDCL);
                        row2.GetCell(12).SetCellValue(reabcres.MES_ZLRBB[i + 1].BZ);
                    }
                    row3.GetCell(1).SetCellValue("夜");
                    if (reabcres.MES_ZLRBB[i + 2].SDLINE != null)
                    {
                        row3.GetCell(2).SetCellValue(reabcres.MES_ZLRBB[i + 2].JLTXR);
                        if (reabcres.MES_ZLRBB[i + 2].ZJHQR != 0) row3.GetCell(3).SetCellValue(reabcres.MES_ZLRBB[i + 2].ZJHQR);
                        if (reabcres.MES_ZLRBB[i + 2].KX != 0) row3.GetCell(4).SetCellValue(reabcres.MES_ZLRBB[i + 2].KX);
                        if (reabcres.MES_ZLRBB[i + 2].FKJTB != 0) row3.GetCell(5).SetCellValue(reabcres.MES_ZLRBB[i + 2].FKJTB);
                        if (reabcres.MES_ZLRBB[i + 2].GMZCR != 0) row3.GetCell(6).SetCellValue(reabcres.MES_ZLRBB[i + 2].GMZCR);
                        if (reabcres.MES_ZLRBB[i + 2].DJYZR != 0) row3.GetCell(7).SetCellValue(reabcres.MES_ZLRBB[i + 2].DJYZR);
                        if (reabcres.MES_ZLRBB[i + 2].XGZR != 0) row3.GetCell(8).SetCellValue(reabcres.MES_ZLRBB[i + 2].XGZR);
                        if (reabcres.MES_ZLRBB[i + 2].FKCX != 0) row3.GetCell(9).SetCellValue(reabcres.MES_ZLRBB[i + 2].FKCX);
                        if (reabcres.MES_ZLRBB[i + 2].DDMTB != 0) row3.GetCell(10).SetCellValue(reabcres.MES_ZLRBB[i + 2].DDMTB);
                        if (reabcres.MES_ZLRBB[i + 2].SDCL != 0) row3.GetCell(11).SetCellValue(reabcres.MES_ZLRBB[i + 2].SDCL);
                        row3.GetCell(12).SetCellValue(reabcres.MES_ZLRBB[i + 2].BZ);
                    }
                    //for (int k = 13; k < 18; k++) msheet.AddMergedRegion(new CellRangeAddress(i + 4, i + 5, k, k));
                    //if (reabcres.MES_ZLRBB[i].SDLINE != null)
                    //{
                    //    if (reabcres.MES_ZLRBB[i].VYX != 0) row.GetCell(13).SetCellValue(reabcres.MES_ZLRBB[i].VYX);
                    //    if (reabcres.MES_ZLRBB[i].VZ != 0) row.GetCell(14).SetCellValue(reabcres.MES_ZLRBB[i].VZ);
                    //    if (reabcres.MES_ZLRBB[i].VYS != 0) row.GetCell(15).SetCellValue(reabcres.MES_ZLRBB[i].VYS);
                    //    if (reabcres.MES_ZLRBB[i].SDZYXCCD != 0) row.GetCell(16).SetCellValue(reabcres.MES_ZLRBB[i].SDZYXCCD);
                    //    if (reabcres.MES_ZLRBB[i].WGBL != 0) row.GetCell(17).SetCellValue(reabcres.MES_ZLRBB[i].WGBL);
                    //}
                }
                int lastRow = 97;
                //msheet.GetRow(lastRow).GetCell(0).SetCellValue("无日期记录");
                //msheet.GetRow(lastRow).GetCell(0).CellStyle = styleA;
                //msheet.AddMergedRegion(new CellRangeAddress(lastRow, lastRow, 0, 1));
                //msheet.AddMergedRegion(new CellRangeAddress(lastRow, lastRow, 2, 12));
                //msheet.GetRow(lastRow).GetCell(13).SetCellValue(reabcres.MES_ZLRBB[63].VYX);
                //msheet.GetRow(lastRow).GetCell(14).SetCellValue(reabcres.MES_ZLRBB[63].VZ);
                //msheet.GetRow(lastRow).GetCell(15).SetCellValue(reabcres.MES_ZLRBB[63].VYS);
                //msheet.GetRow(lastRow).GetCell(16).SetCellValue(reabcres.MES_ZLRBB[63].SDZYXCCD);
                //msheet.GetRow(lastRow).GetCell(17).SetCellValue(reabcres.MES_ZLRBB[63].WGBL);
                msheet.GetRow(lastRow).GetCell(0).SetCellValue("合计");
                msheet.GetRow(lastRow).GetCell(0).CellStyle = styleA;
                msheet.AddMergedRegion(new CellRangeAddress(67, 67, 0, 2));
                int lastcell = 3;
                msheet.GetRow(lastRow).GetCell(lastcell++).SetCellValue(reabcres.MES_ZLRBB[62].ZJHQR);
                msheet.GetRow(lastRow).GetCell(lastcell++).SetCellValue(reabcres.MES_ZLRBB[62].KX);
                msheet.GetRow(lastRow).GetCell(lastcell++).SetCellValue(reabcres.MES_ZLRBB[62].FKJTB);
                msheet.GetRow(lastRow).GetCell(lastcell++).SetCellValue(reabcres.MES_ZLRBB[62].GMZCR);
                msheet.GetRow(lastRow).GetCell(lastcell++).SetCellValue(reabcres.MES_ZLRBB[62].DJYZR);
                msheet.GetRow(lastRow).GetCell(lastcell++).SetCellValue(reabcres.MES_ZLRBB[62].XGZR);
                msheet.GetRow(lastRow).GetCell(lastcell++).SetCellValue(reabcres.MES_ZLRBB[62].FKCX);
                msheet.GetRow(lastRow).GetCell(lastcell++).SetCellValue(reabcres.MES_ZLRBB[62].DDMTB);
                msheet.GetRow(lastRow).GetCell(lastcell++).SetCellValue(reabcres.MES_ZLRBB[62].SDCL);
                //lastcell++;
                //msheet.GetRow(lastRow).GetCell(lastcell++).SetCellValue(reabcres.MES_ZLRBB[62].VYX);
                //msheet.GetRow(lastRow).GetCell(lastcell++).SetCellValue(reabcres.MES_ZLRBB[62].VZ);
                //msheet.GetRow(lastRow).GetCell(lastcell++).SetCellValue(reabcres.MES_ZLRBB[62].VYS);
                //msheet.GetRow(lastRow).GetCell(lastcell++).SetCellValue(reabcres.MES_ZLRBB[62].SDZYXCCD);
                //msheet.GetRow(lastRow).GetCell(lastcell++).SetCellValue(reabcres.MES_ZLRBB[62].WGBL);

                string now = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string filename = now + "质量日报表";
                string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), filename);
                //open
                FileStream file_o = new FileStream(path, FileMode.Create, FileAccess.Write);
                mworkbook.Write(file_o);
                //close
                file_o.Close();
                reabcres.MES_RETURN.TYPE = "S";
                reabcres.MES_RETURN.MESSAGE = filename;
            }
            catch (Exception e)
            {
                reabcres.MES_RETURN.TYPE = "E";
                reabcres.MES_RETURN.MESSAGE = "导出失败：" + e;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(reabcres.MES_RETURN);
        }

        [HttpPost]
        public string BAT_QLTY_TMARK_REPORT_Export(string datastring)
        {
            MES_ZLRBB_SELECT abcres = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZLRBB_SELECT>(datastring);
            MES_RETURN_UI abcr = new MES_RETURN_UI();
            try
            {
                MES_ZLRBB[] zlrbb = abcres.MES_ZLRBB;
                IWorkbook mworkbook = new HSSFWorkbook();
                ISheet msheet = mworkbook.CreateSheet("1.0V以下不良电统计");

                //标题栏样式
                ICellStyle style = mworkbook.CreateCellStyle();
                style.Alignment = HorizontalAlignment.Center;
                style.VerticalAlignment = VerticalAlignment.Center;
                style.BorderBottom = BorderStyle.Thin;
                style.BorderLeft = BorderStyle.Thin;
                style.BorderRight = BorderStyle.Thin;
                style.BorderTop = BorderStyle.Thin;
                style.WrapText = true;

                //数据栏样式
                ICellStyle styleA = mworkbook.CreateCellStyle();
                styleA.Alignment = HorizontalAlignment.Center;
                styleA.VerticalAlignment = VerticalAlignment.Center;
                styleA.BorderBottom = BorderStyle.Thin;
                styleA.BorderLeft = BorderStyle.Thin;
                styleA.BorderRight = BorderStyle.Thin;
                styleA.BorderTop = BorderStyle.Thin;

                //单元格初始化
                int colNum = 20; //总列数
                for (int i = 0; i < 3; i++)
                {
                    IRow row = msheet.CreateRow(i);
                    row.HeightInPoints = 30;
                    for (int j = 0; j < colNum; j++) row.CreateCell(j).CellStyle = style;
                }
                for (int i = 3; i < abcres.MES_ZLRBB.Length + 3; i++)
                {
                    IRow row = msheet.CreateRow(i);
                    for (int j = 0; j < colNum; j++) row.CreateCell(j).CellStyle = styleA;
                }
                //msheet.SetColumnWidth(12, 15 * 256);

                //写入表头
                msheet.GetRow(0).GetCell(0).SetCellValue("1.0V以下不良电统计");
                msheet.GetRow(1).GetCell(0).SetCellValue("项目");
                msheet.GetRow(1).GetCell(1).SetCellValue("隔膜纸");
                msheet.GetRow(1).GetCell(7).SetCellValue("锌膏");
                msheet.GetRow(1).GetCell(10).SetCellValue("成型");
                msheet.GetRow(1).GetCell(14).SetCellValue("其它");
                string[] list0 = { "生产线", "黑点", "烫头不良", "裂口穿孔", "烫头破", "插破", "成型不良", "黑头", "无（缺）锌膏", "溢出", "铜钉斜插", "脱皮拉丝", "刻线不良", "底盖斜", "铜钉脱焊", "热胶注入不良", "外部短路", "原因不明", "其它", "合计" };
                for (int i = 0; i < list0.Length; i++)
                {
                    msheet.GetRow(2).GetCell(i).SetCellValue(list0[i]);
                }
                msheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 19));
                msheet.AddMergedRegion(new CellRangeAddress(1, 1, 1, 6));
                msheet.AddMergedRegion(new CellRangeAddress(1, 1, 7, 9));
                msheet.AddMergedRegion(new CellRangeAddress(1, 1, 10, 13));
                msheet.AddMergedRegion(new CellRangeAddress(1, 1, 14, 17));

                //写入数据
                for (int i = 0; i < abcres.MES_ZLRBB.Length; i++)
                {
                    int j = 0;
                    IRow row = msheet.GetRow(i + 3);
                    row.GetCell(j++).SetCellValue(zlrbb[i].SDLINE);
                    row.GetCell(j++).SetCellValue(zlrbb[i].HD);
                    row.GetCell(j++).SetCellValue(zlrbb[i].TTBL);
                    row.GetCell(j++).SetCellValue(zlrbb[i].LKCK);
                    row.GetCell(j++).SetCellValue(zlrbb[i].TTP);
                    row.GetCell(j++).SetCellValue(zlrbb[i].CP);
                    row.GetCell(j++).SetCellValue(zlrbb[i].CXBL);
                    row.GetCell(j++).SetCellValue(zlrbb[i].HT);
                    row.GetCell(j++).SetCellValue(zlrbb[i].WXG);
                    row.GetCell(j++).SetCellValue(zlrbb[i].YC);
                    row.GetCell(j++).SetCellValue(zlrbb[i].TDXC);
                    row.GetCell(j++).SetCellValue(zlrbb[i].TPLS);
                    row.GetCell(j++).SetCellValue(zlrbb[i].KXBL);
                    row.GetCell(j++).SetCellValue(zlrbb[i].DGX);
                    row.GetCell(j++).SetCellValue(zlrbb[i].TDTH);
                    row.GetCell(j++).SetCellValue(zlrbb[i].RJZRBL);
                    row.GetCell(j++).SetCellValue(zlrbb[i].WBDL);
                    row.GetCell(j++).SetCellValue(zlrbb[i].YYBM);
                    row.GetCell(j++).SetCellValue(zlrbb[i].QT);
                    row.GetCell(j++).SetCellValue(zlrbb[i].HD + zlrbb[i].TTBL + zlrbb[i].LKCK + zlrbb[i].TTP + zlrbb[i].CP + zlrbb[i].CXBL + zlrbb[i].HT + zlrbb[i].WXG + zlrbb[i].YC + zlrbb[i].TDXC + zlrbb[i].TPLS + zlrbb[i].KXBL + zlrbb[i].DGX + zlrbb[i].TDTH + zlrbb[i].RJZRBL + zlrbb[i].WBDL + zlrbb[i].YYBM + zlrbb[i].QT);
                }

                string now = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string filename = now + "不良电统计";
                string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), filename);
                using (FileStream file_o = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    mworkbook.Write(file_o);
                }
                abcr.TYPE = "S";
                abcr.MESSAGE = filename;
            }
            catch (Exception e)
            {
                abcr.TYPE = "E";
                abcr.MESSAGE = "导出失败：" + e;
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(abcr);
        }

        [HttpPost]
        public string BAT_QLTY_TMARK_REPORT_Export_S(string datastring)
        {
            MES_ZLRBB_SELECT rst_MES_ZLRBB_SELECT = Newtonsoft.Json.JsonConvert.DeserializeObject<MES_ZLRBB_SELECT>(datastring);
            MES_RETURN_UI rst = new MES_RETURN_UI();

            //标题
            Dictionary<int, string> title = new Dictionary<int, string>();
            title.Add(0, "1.0V以下不良电统计,20");
            title.Add(1, "日期,1,2|隔膜纸,6|锌膏,3|成型,4|其它,4");
            title.Add(2, "|黑点|烫头不良|裂口穿孔|烫头破|插破|成型不良|黑头|无（缺）锌膏|溢出|铜钉斜插|脱皮拉丝|刻线不良|底盖斜|铜钉脱焊|热胶注入不良|外部短路|原因不明|其它|合计");

            //数据
            string[] dataName = { "", "HD", "TTBL", "LKCK", "TTP", "CP", "CXBL", "HT", "WXG", "YC", "TDXC", "TPLS", "KXBL", "DGX", "TDTH", "RJZRBL", "WBDL", "YYBM", "QT" };
            List<MES_ZLRBB> dataReorder = rst_MES_ZLRBB_SELECT.MES_ZLRBB.ToList();
            dataReorder.Remove(dataReorder[0]);
            dataReorder.Add(rst_MES_ZLRBB_SELECT.MES_ZLRBB[0]);

            //转Excel
            string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "不良电统计";
            string path = string.Format(@"{0}/Areas/MES/ExportFile/{1}.xls", Server.MapPath("~"), filename);
            rst = ExcelHelper.xlsOut<MES_ZLRBB>(path, dataReorder, dataName.ToList(), title, "1.0V以下不良电统计", (workbookIn) =>
            {
                IWorkbook workbookOut = workbookIn;
                ISheet msheet = workbookOut.GetSheetAt(0);
                //写入额外数据
                for (int i = 0; i < dataReorder.Count; i++)
                {
                    IRow row = msheet.GetRow(i + 3);
                    row.GetCell(0).SetCellValue(i + 1);
                    int total = dataReorder[i].HD + dataReorder[i].TTBL + dataReorder[i].LKCK + dataReorder[i].TTP + dataReorder[i].CP + dataReorder[i].CXBL + dataReorder[i].HT + dataReorder[i].WXG + dataReorder[i].YC + dataReorder[i].TDXC + dataReorder[i].TPLS + dataReorder[i].KXBL + dataReorder[i].DGX + dataReorder[i].TDTH + dataReorder[i].RJZRBL + dataReorder[i].WBDL + dataReorder[i].YYBM + dataReorder[i].QT;
                    row.GetCell(19).SetCellValue(total == 0 ? "" : total.ToString());
                }
                msheet.GetRow(34).GetCell(0).SetCellValue("合计");
                return workbookOut;
            }, (dataIn, dataInRow, dataInCol, dataInName) =>
            {
                if (dataIn == "0") dataIn = "";
                return dataIn;
            });
            if (rst.TYPE == "S") rst.MESSAGE = filename;
            return Newtonsoft.Json.JsonConvert.SerializeObject(rst);
        }

        #endregion

        #region 工具

        /// <summary>
        /// Excel转DataTable
        /// </summary>
        /// <param name="file">上传文件</param>
        /// <param name="isFirstRowColumn">是否有列名行</param>
        /// <returns></returns>
        private DataTable ExcelToDataTable(HttpPostedFileBase file, Boolean isFirstRowColumn)
        {
            IWorkbook mworkbook;
            DataTable rstdata = new DataTable();
            int startRow = 0;
            try
            {
                if (file.FileName.IndexOf(".xlsx") > 0) // 2007版本
                    mworkbook = new XSSFWorkbook(file.InputStream);
                else if (file.FileName.IndexOf(".xls") > 0) // 2003版本
                    mworkbook = new HSSFWorkbook(file.InputStream);
                else return null;

                ISheet msheet = mworkbook.GetSheetAt(0);

                if (msheet != null)
                {
                    IRow firstRow = msheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; i++)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    rstdata.Columns.Add(column);
                                }
                            }
                        }
                        startRow = msheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = msheet.FirstRowNum;
                    }

                    //最后一列的标号
                    int rowCount = msheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; i++)
                    {
                        IRow row = msheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是""　　　　　　

                        DataRow dataRow = rstdata.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是""
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        rstdata.Rows.Add(dataRow);
                    }
                }
                rstdata.TableName = file.FileName;
            }
            catch (Exception e)
            {
                rstdata.TableName = "Error";
                rstdata.Columns.Add(new DataColumn("MESSAGE"));
                DataRow dataRow = rstdata.NewRow();
                dataRow[0] = e.Message;
                rstdata.Rows.Add(dataRow);
            }
            return rstdata;
        }

        /// <summary>
        /// Excel转HTML
        /// </summary>
        /// <param name="file">上传文件</param>
        /// <returns></returns>
        private System.Xml.XmlDocument ExcelToHtml(HttpPostedFileBase file)
        {
            IWorkbook workbook;
            string fileExt = Path.GetExtension(file.FileName).ToLower(); //获取后缀名称
            if (fileExt == ".xlsx") workbook = new XSSFWorkbook(file.InputStream);
            else if (fileExt == ".xls") workbook = new HSSFWorkbook(file.InputStream);
            else workbook = null;

            ExcelToHtmlConverter eth = new ExcelToHtmlConverter();

            // 设置输出参数
            eth.OutputColumnHeaders = false;
            eth.OutputHiddenColumns = false;
            eth.OutputHiddenRows = false;
            eth.OutputLeadingSpacesAsNonBreaking = false;
            eth.OutputRowNumbers = false;
            eth.UseDivsToSpan = false;

            eth.ProcessWorkbook(workbook);
            eth.Document.ChildNodes[0].ChildNodes[1].RemoveChild(eth.Document.ChildNodes[0].ChildNodes[1].ChildNodes[0]);
            return eth.Document;
        }

        /// <summary>
        /// Excel转HTML
        /// </summary>
        /// <param name="file">文件流</param>
        /// <returns></returns>
        private System.Xml.XmlDocument ExcelToHtml(FileStream file)
        {
            IWorkbook workbook;
            string fileExt = Path.GetExtension(file.Name).ToLower();
            if (fileExt == ".xlsx") workbook = new XSSFWorkbook(file);
            else if (fileExt == ".xls") workbook = new HSSFWorkbook(file);
            else workbook = null;

            ExcelToHtmlConverter eth = new ExcelToHtmlConverter();

            // 设置输出参数
            eth.OutputColumnHeaders = false;
            eth.OutputRowNumbers = false;
            eth.OutputHiddenColumns = false;
            eth.OutputHiddenRows = false;
            eth.OutputLeadingSpacesAsNonBreaking = false;
            eth.UseDivsToSpan = false;

            eth.ProcessWorkbook(workbook);
            eth.Document.ChildNodes[0].ChildNodes[1].RemoveChild(eth.Document.ChildNodes[0].ChildNodes[1].ChildNodes[0]);
            return eth.Document;
        }

        /// <summary>
        /// Excel转HTML字符串
        /// </summary>
        /// <param name="file">文件流</param>
        /// <returns></returns>
        private string ExcelToHtmlStr(FileStream file)
        {
            IWorkbook workbook;
            string fileExt = Path.GetExtension(file.Name).ToLower();
            if (fileExt == ".xlsx") workbook = new XSSFWorkbook(file);
            else if (fileExt == ".xls") workbook = new HSSFWorkbook(file);
            else workbook = null;

            ExcelToHtmlConverter eth = new ExcelToHtmlConverter();

            // 设置输出参数
            eth.OutputColumnHeaders = false;
            eth.OutputRowNumbers = false;
            eth.OutputHiddenColumns = false;
            eth.OutputHiddenRows = false;
            eth.OutputLeadingSpacesAsNonBreaking = false;
            eth.UseDivsToSpan = false;

            eth.ProcessWorkbook(workbook);
            eth.Document.ChildNodes[0].ChildNodes[1].RemoveChild(eth.Document.ChildNodes[0].ChildNodes[1].ChildNodes[0]);

            //XML转字符串
            MemoryStream ms = new MemoryStream();
            eth.Document.Save(ms);
            ms.Position = 0;
            StreamReader msReader = new StreamReader(ms);
            string rst = msReader.ReadToEnd();
            ms.Close();

            return rst;
        }

        #endregion

    }
}
