using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Sonluk.Utility;
using Sonluk.UI.Model.MM.PurchaseOrderService;

namespace Sonluk.UI.Model.MM
{
    public class PurchaseOrder
    {
        private PurchaseOrderSoapClient client = new PurchaseOrderSoapClient("PurchaseOrderSoap", AppConfig.Settings("RemoteAddress") + "MM/PurchaseOrder.asmx");

        public IList<POItemInfo> Read(POKeywordInfo keyword)
        {
            return client.Read(keyword);
        }

        public IList<POItemInfo> Read(SOKeywordInfo keyword)
        {
            return client.ReadBySO(keyword);
        }

        public IList<POItemInfo> Read(Stream file)
        {
            MemoryStream memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);
            return client.ReadBySOFile(memoryStream.ToArray());
        }

        public IList<POItemHistoryInfo> History(string number, int itemNumber)
        {
            return client.History(number, itemNumber);
        }

        public IList<MessageInfo> UpdateDeliveryDate(IList<POItemInfo> nodes)
        {
            return client.UpdateDeliveryDate(nodes.ToArray());
        }

        public MemoryStream Export(string type, IList<POItemInfo> itemNodes)
        {

            byte[] fileByte = client.ExportSet(type, itemNodes.ToArray());
            MemoryStream memoryStream = new MemoryStream(fileByte);
            return memoryStream;
        }

        public IList<FileStreamInfo> Export(IList<POItemInfo> itemNodes, int type)
        {
            IList<FileStreamInfo> files = client.Export(itemNodes.ToArray(), type);
            int filesLength = files.Count();

            for (int i = 0; i < filesLength; i++)
            {
                MemoryStream memoryStream = new MemoryStream(files[i].Bytes);
                string fileName = files[i].Name + "_" + files[i].TattedCode + "." + files[i].Extension;
                string path = AppDomain.CurrentDomain.BaseDirectory + "/Temp/PO/" + fileName;
                try
                {
                    FileStream file = new FileStream(path, FileMode.Create);
                    file.Write(memoryStream.ToArray(), 0, (memoryStream.ToArray()).GetLength(0));
                    file.Close();
                }
                catch (Exception e)
                {
                    Logger.Write("UI.Model.MM.PurchaseOrder.Export", e.ToString());
                }
                files[i].Bytes = null;
            }
            return files;
        }

        public List<PageInfoOfPOInfo> AnalysePrintData(string type, int status, string pageSize, IList<POItemInfo> itemNodes, string ptoken = "")
        {
            return client.AnalysePrintData(type, status, pageSize, itemNodes.ToArray(), ptoken).ToList();
        }

        public IList<FileStreamInfo> GetStorageIdentificationPDF(string CGXM, string TPM, string GYS, int TS, int XS, int SL, string MODE, string LTBS)
        {
            IList<FileStreamInfo> files = client.GetStorageIdentificationPDF(CGXM, TPM, GYS, TS, XS, SL, MODE, LTBS);
            int filesLength = files.Count();

            for (int i = 0; i < filesLength; i++)
            {
                MemoryStream memoryStream = new MemoryStream(files[i].Bytes);
                string fileName = files[i].Name + "_" + files[i].TattedCode + "." + files[i].Extension;
                string path = AppDomain.CurrentDomain.BaseDirectory + "/Temp/PO/" + fileName;
                try
                {
                    FileStream file = new FileStream(path, FileMode.Create);
                    file.Write(memoryStream.ToArray(), 0, (memoryStream.ToArray()).GetLength(0));
                    file.Close();
                }
                catch (Exception e)
                {
                    Logger.Write("UI.Model.MM.PurchaseOrder.GetStorageIdentificationPDF", e.ToString());
                }
                files[i].Bytes = null;
            }
            return files;
        }

        public IList<ZSL_BCS104> GetStorageIdentificationList(string CGXM, string TPM, string GYS, int TS, int XS, int SL, string MODE, string LTBS)
        {
            return client.GetStorageIdentificationList(CGXM, TPM, GYS, TS, XS, SL, MODE, LTBS);
        }

        public string GenerateStorageIdentification(string CGXM, string TPM, string GYS, int TS, int XS, int SL, string MODE, string LTBS)
        {
            return client.GenerateStorageIdentification(CGXM, TPM, GYS, TS, XS, SL, MODE, LTBS);
        }


        public IList<FileStreamInfo> GetStorageIdentificationZHPDF(int GLTS, string DYFS, string USER, string MODE, int FS, IList<ZSL_BCS104> itemNodes)
        {
            IList<FileStreamInfo> files = client.GetStorageIdentificationZHPDF(GLTS, DYFS, USER, MODE, FS, itemNodes.ToArray());
            int filesLength = files.Count();

            for (int i = 0; i < filesLength; i++)
            {
                MemoryStream memoryStream = new MemoryStream(files[i].Bytes);
                string fileName = files[i].Name + "_" + files[i].TattedCode + "." + files[i].Extension;
                string path = AppDomain.CurrentDomain.BaseDirectory + "/Temp/PO/" + fileName;
                try
                {
                    FileStream file = new FileStream(path, FileMode.Create);
                    file.Write(memoryStream.ToArray(), 0, (memoryStream.ToArray()).GetLength(0));
                    file.Close();
                }
                catch (Exception e)
                {
                    Logger.Write("UI.Model.MM.PurchaseOrder.GetStorageIdentificationZHPDF", e.ToString());
                }
                files[i].Bytes = null;
            }
            return files;
        }

        public IList<ZSL_BCS104> GetStorageIdentificationZHList(int GLTS, string DYFS, string USER, string MODE, int FS, IList<ZSL_BCS104> itemNodes)
        {
            return client.GetStorageIdentificationZHList(GLTS, DYFS, USER, MODE, FS, itemNodes.ToArray());
        }

        public string GenerateStorageIdentificationZH(int GLTS, string DYFS, string USER, string MODE, int FS, IList<ZSL_BCS104> itemNodes)
        {
            return client.GenerateStorageIdentificationZH(GLTS, DYFS, USER, MODE, FS, itemNodes.ToArray());
        }

        public string ZBCFUN_RKBS_CHANGE(string IV_TPM, string IV_MODE, string IV_USER)
        {
            return client.ZBCFUN_RKBS_CHANGE(IV_TPM, IV_MODE, IV_USER);
        }
        public string ZMMFUN_GCDZ_READ(string werks)
        {
            return client.ZMMFUN_GCDZ_READ(werks);
        }
        public ZMMFUN_PURBS_READ ZMMFUN_PURBS_READ(List<ZSL_BCS303_CT> IT_PURCT)
        {
            return client.ZMMFUN_PURBS_READ(IT_PURCT.ToArray());
        }

    }
}
