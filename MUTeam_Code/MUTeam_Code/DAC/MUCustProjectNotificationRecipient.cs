using System;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.SM;

namespace MUTeam_Code
{
    [Serializable]
    [PXCacheName("MUCustProjectNotificationRecipient")]
    public class MUCustProjectNotificationRecipient : IBqlTable
    {
        #region ProjectID
        [PXDBGuid(IsKey = true)]
        [PXDBDefault(typeof(MUCustProject.projid))]
        [PXParent(typeof(SelectFrom<MUCustProject>.
             Where<MUCustProject.projid.
             IsEqual<MUCustProjectNotificationRecipient.projectID.FromCurrent>>))]
        public virtual Guid? ProjectID { get; set; }
        public abstract class projectID : PX.Data.BQL.BqlGuid.Field<projectID> { }
        #endregion

        #region EMail
        [PXDBWeblink]
        [PXUIField(DisplayName = "Email")]
        public virtual string EMail { get; set; }
        public abstract class eMail : PX.Data.BQL.BqlString.Field<eMail> { }
        #endregion

        #region NotifyOnSuccess
        [PXDBBool()]
        [PXDefault(true, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Notify On Success")]
        public virtual bool? NotifyOnSuccess { get; set; }
        public abstract class notifyOnSuccess : PX.Data.BQL.BqlBool.Field<notifyOnSuccess> { }
        #endregion

        #region NotifyOnFail
        [PXDBBool()]
        [PXDefault(true, PersistingCheck = PXPersistingCheck.Nothing)]
        [PXUIField(DisplayName = "Notify On Fail")]
        public virtual bool? NotifyOnFail { get; set; }
        public abstract class notifyOnFail : PX.Data.BQL.BqlBool.Field<notifyOnFail> { }
        #endregion

        #region CreatedByID
        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID { get; set; }
        public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
        #endregion

        #region CreatedByScreenID
        [PXDBCreatedByScreenID()]
        public virtual string CreatedByScreenID { get; set; }
        public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
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

        #region LastModifiedByScreenID
        [PXDBLastModifiedByScreenID()]
        public virtual string LastModifiedByScreenID { get; set; }
        public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
        #endregion

        #region LastModifiedDateTime
        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
        #endregion

        #region Tstamp
        [PXDBTimestamp()]
        [PXUIField(DisplayName = "Tstamp")]
        public virtual byte[] Tstamp { get; set; }
        public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
        #endregion

        #region Noteid
        [PXNote()]
        public virtual Guid? Noteid { get; set; }
        public abstract class noteid : PX.Data.BQL.BqlGuid.Field<noteid> { }
        #endregion
    }
}