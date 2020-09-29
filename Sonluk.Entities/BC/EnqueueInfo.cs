using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class EnqueueInfo
    {
        private string _Name;          //GNAME Elementary Lock of Lock Entry (Table Name) 锁定表项中的加锁组名(=表名)
        private string _Argument;      //GARG Argument String (=Key Fields) of Lock Entry 锁定表项的参数串 (=关键字段)
        private string _Mode;          //GMODE Lock Mode (Shared/Exclusive) of a Lock Entry 锁定表目的锁定方式(共享/排他)
        private string _Owner;         //GUSR Lock Owner, ID of Logical Unit of Work (LUW) 锁拥有者,工作逻辑单元标识符(LUW)
        private string _OwnerVB;       //GUSRVB Lock Owner, ID of Logical Unit of Work (LUW) /Update Task 锁拥有者,工作逻辑单元标识符(LUW)
        private int _CumulativeCounter;    //GUSE Cumulative Counter for Lock Entry /Dialog 锁定项的累积计数器
        private int _CumulativeCounterVB;  //GUSEVB Cumulative Counter for Lock Entry / Update Task   锁定项的累积计数器
        private string _Object;        //GOBJ Name of Lock Object in the Lock Entry 锁住的目标名在锁住的条目里
        private string _Client;        //GCLIENT Client in the lock entry 锁定表项中的集团
        private string _User;          //GUNAME User name in lock entry 使用者名子在锁定目录中
        private string _TableArgument; //GTARG Argument String of Lock Entry (Table Key Fields) 锁定表项的参数串 (=关键字段)
        private string _TCode;         //GTCODE Transaction Code in the Lock Entry 在锁住条目的事务代码
        private string _BackupType;    //GBCKTYPE Backup flag for lock entry 锁定条目的备份标记
        private string _Host;          //GTHOST Host Name in the Lock Owner ID 锁定属主ID的主机名 
        private int _WorkProcess;      //GTWP Work Process Number in Lock Owner ID 在锁定所有者标识中的工作进程号
        private int _System;           //GTSYSNR SAP System Number in Lock Owner ID SAP系统数在锁定拥有者ID里
        private string _Date;          //GTDATE Date within lock owner ID 锁定占有者ID期内日期
        private string _Time;          //GTTIME Time in Lock Owner ID 在锁上所有者标识期间内的时间
        private int _Microseconds;     //GTUSEC Time/Microseconds Share in Lock Owner ID 时间/微秒被所有者标识的加锁占用
        private string _Mark;          //GTMARK Selection Indicator of Lock Entry 为锁定输入选择指示器
        private int _CumulativeCounterTxt;    //GUSETXT Cumulative Counter for Lock Entry /Dialog 锁定项的累积计数器
        private int _CumulativeCounterVBTxt;  //GUSEVBT Cumulative Counter for Lock Entry / Update Task 锁定项的累积计数器
        


        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string Argument
        {
            get { return _Argument; }
            set { _Argument = value; }
        }
        public string Mode
        {
            get { return _Mode; }
            set { _Mode = value; }
        }
        public string Owner
        {
            get { return _Owner; }
            set { _Owner = value; }
        }
        public string OwnerVB
        {
            get { return _OwnerVB; }
            set { _OwnerVB = value; }
        }
        public int CumulativeCounter
        {
            get { return _CumulativeCounter; }
            set { _CumulativeCounter = value; }
        }
        public int CumulativeCounterVB
        {
            get { return _CumulativeCounterVB; }
            set { _CumulativeCounterVB = value; }
        }
        public string Object
        {
            get { return _Object; }
            set { _Object = value; }
        }
        public string Client
        {
            get { return _Client; }
            set { _Client = value; }
        }
        public string User
        {
            get { return _User; }
            set { _User = value; }
        }
        public string TableArgument
        {
            get { return _TableArgument; }
            set { _TableArgument = value; }
        }
        public string TCode
        {
            get { return _TCode; }
            set { _TCode = value; }
        }
        public string BackupType
        {
            get { return _BackupType; }
            set { _BackupType = value; }
        }
        public string Host
        {
            get { return _Host; }
            set { _Host = value; }
        }
        public int WorkProcess
        {
            get { return _WorkProcess; }
            set { _WorkProcess = value; }
        }
        public int System
        {
            get { return _System; }
            set { _System = value; }
        }
        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        public string Time
        {
            get { return _Time; }
            set { _Time = value; }
        }
        public int Microseconds
        {
            get { return _Microseconds; }
            set { _Microseconds = value; }
        }
        public string Mark
        {
            get { return _Mark; }
            set { _Mark = value; }
        }
        public int CumulativeCounterTxt
        {
            get { return _CumulativeCounterTxt; }
            set { _CumulativeCounterTxt = value; }
        }
        public int CumulativeCounterVBTxt
        {
            get { return _CumulativeCounterVBTxt; }
            set { _CumulativeCounterVBTxt = value; }
        }
    }
}
