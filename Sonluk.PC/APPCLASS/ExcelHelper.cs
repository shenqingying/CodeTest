using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using Sonluk.UI.Model.MODEL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Sonluk.PC.APPCLASS
{
    public class ExcelHelper
    {
        /// <summary>
        /// 将数据输入到Excel并存于指定路径
        /// </summary>
        /// <param name="path">保存路径</param>
        /// <param name="data">数据</param>
        /// <param name="title">标题</param>
        /// <param name="sheetTitle">表名</param>
        /// <param name="addition">添加额外方法</param>
        /// <param name="dataTransform">额外修改填写数据</param>
        /// <param name="sep">分隔标题字符</param>
        /// <param name="sepChild">分隔标题数据字符</param>
        /// <returns></returns>
        public static MES_RETURN_UI xlsOut<Tin>(string path, List<Tin> data, List<string> dataName, Dictionary<int, string> title, string sheetTitle = "sheet1", Func<IWorkbook, IWorkbook> addition = null, Func<string, int, int, string, string> dataTransform = null, char sep = '|', char sepChild = ',')
        {
            MES_RETURN_UI rst = new MES_RETURN_UI();
            try
            {
                //获取基本信息
                int rowNumTitle = title.Count; //标题行
                int rowNumData = data.Count;   //数据行
                int colNumMax = 0;             //最大列数
                foreach (var item in title)
                {
                    int num = item.Value.Split(sep).Length;
                    if (colNumMax < num) colNumMax = num;
                }

                //表初始化
                IWorkbook mworkbook = new HSSFWorkbook();
                ISheet msheet = mworkbook.CreateSheet(sheetTitle);

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
                for (int i = 0; i < rowNumTitle; i++)
                {
                    IRow row = msheet.CreateRow(i);
                    row.HeightInPoints = 30;
                    for (int j = 0; j < colNumMax; j++) row.CreateCell(j).CellStyle = style;
                }
                for (int i = rowNumTitle; i < rowNumData + rowNumTitle; i++)
                {
                    IRow row = msheet.CreateRow(i);
                    for (int j = 0; j < colNumMax; j++) row.CreateCell(j).CellStyle = styleA;
                }

                //设置列宽
                //msheet.SetColumnWidth(12, 15 * 256);

                //写入标题
                foreach (var item in title)
                {
                    string[] titleChild = item.Value.Split(sep);
                    int startCol = 0;
                    for (int titleCol = 0; titleCol < titleChild.Length; titleCol++)
                    {
                        string[] titleChildInfo = titleChild[titleCol].Split(sepChild);
                        if (titleChildInfo.Length == 1 || titleChildInfo.Length == 2 || titleChildInfo.Length == 3)
                        {
                            int colspan = titleChildInfo.Length > 1 ? Convert.ToInt32(titleChildInfo[1]) : 1;
                            int rowspan = titleChildInfo.Length == 3 ? Convert.ToInt32(titleChildInfo[2]) : 1;
                            msheet.GetRow(item.Key).GetCell(startCol).SetCellValue(titleChildInfo[0]);
                            msheet.AddMergedRegion(new CellRangeAddress(item.Key, item.Key + rowspan - 1, startCol, startCol + colspan - 1));
                            startCol = startCol + colspan;
                        }
                        else
                        {
                            rst.TYPE = "E";
                            rst.MESSAGE = "标题格式错误！";
                            return rst;
                        }
                    }
                }

                //写入数据
                for (int i = rowNumTitle; i < rowNumData + rowNumTitle; i++)
                {
                    Type myData = data[i - rowNumTitle].GetType();
                    for (int j = 0; j < dataName.Count; j++)
                    {
                        foreach (PropertyInfo pi in myData.GetProperties())
                        {
                            if (pi.Name == dataName[j])
                            {
                                string dataIn = dataTransform(pi.GetValue(data[i - rowNumTitle], null).ToString(), i, j, pi.Name);
                                msheet.GetRow(i).GetCell(j).SetCellValue(dataIn);
                                break;
                            }
                        }
                    }
                }

                //外部操作
                addition(mworkbook);

                //保存Excel
                using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    mworkbook.Write(file);
                }
                rst.TYPE = "S";
                rst.MESSAGE = path;
            }
            catch (Exception e)
            {
                rst.TYPE = "E";
                rst.MESSAGE = "临时文件保存失败：" + e.Message;
            }
            return rst;
        }
    }
}