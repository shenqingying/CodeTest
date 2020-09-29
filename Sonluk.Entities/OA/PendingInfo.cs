using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.OA
{
    public class PendingInfo
    {
        private string _Subject;
        private string _ApplicationCategory;
        private string _Creator;
        private string _Distinct;
        private string _BodyType;
        private string _ID;
        private string _ObjectID;
        private string _HasAttachments;
        private string _CreateDate;
        private string _SubObjectID;
        private string _ImportantLevel;
        private string _Link;


        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }
        public string ApplicationCategory
        {
            get { return _ApplicationCategory; }
            set { _ApplicationCategory = value; }
        }
        public string Creator
        {
            get { return _Creator; }
            set { _Creator = value; }
        }
        public string Distinct
        {
            get { return _Distinct; }
            set { _Distinct = value; }
        }
        public string BodyType
        {
            get { return _BodyType; }
            set { _BodyType = value; }
        }
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string ObjectID
        {
            get { return _ObjectID; }
            set { _ObjectID = value; }
        }
        public string HasAttachments
        {
            get { return _HasAttachments; }
            set { _HasAttachments = value; }
        }
        public string CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        public string SubObjectID
        {
            get { return _SubObjectID; }
            set { _SubObjectID = value; }
        }
        public string ImportantLevel
        {
            get { return _ImportantLevel; }
            set { _ImportantLevel = value; }
        }
        public string Link
        {
            get { return _Link; }
            set { _Link = value; }
        }
    }
}
