using PX.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUTeam_Code

{
    [Serializable]
    [PXCacheName("CustProject")]
    public class CustProject : IBqlTable
    {
        #region Projid
        [PXDBGuid(IsKey = true)]
        [PXUIField(DisplayName = "Projid")]
        public virtual Guid? Projid { get; set; }
        public abstract class projid : PX.Data.BQL.BqlGuid.Field<projid> { }
        #endregion

        #region Name
        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Name")]
        public virtual string Name { get; set; }
        public abstract class name : PX.Data.BQL.BqlString.Field<name> { }
        #endregion

        #region IsWorking
        [PXDBBool()]
        [PXUIField(DisplayName = "Is Working")]
        public virtual bool? IsWorking { get; set; }
        public abstract class isWorking : PX.Data.BQL.BqlBool.Field<isWorking> { }
        #endregion

        #region Description
        [PXDBString(512, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Description")]
        public virtual string Description { get; set; }
        public abstract class description : PX.Data.BQL.BqlString.Field<description> { }
        #endregion

        #region CreatedByID
        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID { get; set; }
        public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
        #endregion

        #region CreatedDateTime
        [PXDBCreatedDateTime()]
        public virtual DateTime? CreatedDateTime { get; set; }
        public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
        #endregion

        #region LastModifiedByID
        [PXDBLastModifiedByID()]
        public virtual Guid? LastModifiedByID { get; set; }
        public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
        #endregion

        #region LastModifiedDateTime
        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
        #endregion

        #region ParentID
        [PXDBGuid()]
        [PXUIField(DisplayName = "Parent ID")]
        public virtual Guid? ParentID { get; set; }
        public abstract class parentID : PX.Data.BQL.BqlGuid.Field<parentID> { }
        #endregion

        #region Tstamp
        [PXDBTimestamp()]
        [PXUIField(DisplayName = "Tstamp")]
        public virtual byte[] Tstamp { get; set; }
        public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
        #endregion

        #region Level
        [PXDBInt()]
        [PXUIField(DisplayName = "Level")]
        public virtual int? Level { get; set; }
        public abstract class level : PX.Data.BQL.BqlInt.Field<level> { }
        #endregion

        #region SnapshotID
        [PXDBGuid()]
        [PXUIField(DisplayName = "Snapshot ID")]
        public virtual Guid? SnapshotID { get; set; }
        public abstract class snapshotID : PX.Data.BQL.BqlGuid.Field<snapshotID> { }
        #endregion
    }

}


