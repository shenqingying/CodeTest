using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.SD
{
    public class SOKeywordInfo
    {
        private string _Number;          //VBELN Sales Document
        private int _Item;         //POSNR Sales Document Item
        private string _Material;
        private string _ProcessingRecordsStatus;  //POTAG 采购标志
        private string _Creator;           //ERNAM Name of Person who Created the Object 创建对象的人员名称
        private string _Plant;             //WERKS Plant (Own or External) 工厂(自有或外部)
        private string _StartDate;
        private string _Date;              //ERDAT Date on Which Record Was Created 记录的创建日期
        private string _StartChangedDate;
        private string _ChangedDate;       //AEDAT Changed On 更改日期
        private string _StartCurrentDate;
        private string _CurrentDate;       //SYDATUM Current Date of Application Server 日期和时间,当前(应用服务器)日期
        private string _ReleaseGroup;

        public string Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
        public int Item
        {
            get { return _Item; }
            set { _Item = value; }
        }
        public string Material
        {
            get { return _Material; }
            set { _Material = value; }
        }
        public string ProcessingRecordsStatus
        {
            get { return _ProcessingRecordsStatus; }
            set { _ProcessingRecordsStatus = value; }
        }
        public string Creator
        {
            get { return _Creator; }
            set { _Creator = value; }
        }
        public string Plant
        {
            get { return _Plant; }
            set { _Plant = value; }
        }
        public string StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }
        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        public string StartChangedDate
        {
            get { return _StartChangedDate; }
            set { _StartChangedDate = value; }
        }
        public string ChangedDate
        {
            get { return _ChangedDate; }
            set { _ChangedDate = value; }
        }
        public string StartCurrentDate
        {
            get { return _StartCurrentDate; }
            set { _StartCurrentDate = value; }
        }
        public string CurrentDate
        {
            get { return _CurrentDate; }
            set { _CurrentDate = value; }
        }
        public string ReleaseGroup
        {
            get { return _ReleaseGroup; }
            set { _ReleaseGroup = value; }
        }
        
    }
}
