using PX.Data;
using PX.Objects.AR;
using PX.Objects.CA;
using PX.Objects.CR;
using PX.Objects.CS;
using System;

namespace MUTeam_Code
{
    [PXProjection(typeof(Select<NotificationSetupRecipient>), persistent: new Type[] { typeof(NotificationSetupRecipient) })]
    [PXCacheName("Customization Notifications")]
    public class MUNotificationSetupRecipient : IBqlTable
    {

        #region RecipientID
        public abstract class recipientID : PX.Data.BQL.BqlGuid.Field<recipientID> { }
        protected Guid? _RecipientID;
        [PXDBGuid(true, IsKey = true, BqlField = typeof(NotificationSetupRecipient.recipientID))]
        public virtual Guid? RecipientID
        {
            get
            {
                return this._RecipientID;
            }
            set
            {
                this._RecipientID = value;
            }
        }
        #endregion
        #region SetupID
        public abstract class setupID : PX.Data.BQL.BqlGuid.Field<setupID> { }
        protected Guid? _SetupID;
        [PXDBGuid(BqlField = typeof(NotificationSetupRecipient.setupID))]
        [PXDefault(typeof(NotificationSetup.setupID))]
        [PXParent(typeof(Select<NotificationSetup,
            Where<NotificationSetup.setupID, Equal<Current<MUNotificationSetupRecipient.setupID>>>>))]
        public virtual Guid? SetupID
        {
            get
            {
                return this._SetupID;
            }
            set
            {
                this._SetupID = value;
            }
        }
        #endregion
        #region ContactType
        public abstract class contactType : PX.Data.BQL.BqlString.Field<contactType> { }
        protected string _ContactType;
        [PXDBString(1, IsFixed = true, BqlField = typeof(NotificationSetupRecipient.contactType))]
        [PXUIField(DisplayName = "Contact Type")]
        [CRMContactType.List]
        public virtual string ContactType
        {
            get
            {
                return this._ContactType;
            }
            set
            {
                this._ContactType = value;
            }
        }
        #endregion
        #region ContactID
        public abstract class contactID : PX.Data.BQL.BqlInt.Field<contactID> { }
        protected Int32? _ContactID;
        //[PXDBInt(BqlField = typeof(NotificationSetupRecipient.contactID))]
        //[PXSelector(typeof(Search<Contact.contactID,
        //    Where<Contact.isActive, Equal<True>,
        //    And<Contact.contactType, Equal<Current<MUNotificationSetupRecipient.contactType>>>>>),
        //    SubstituteKey = typeof(Contact.fullName))]
        [ContactRaw(BqlField = typeof(NotificationSetupRecipient.contactID))]
        public virtual Int32? ContactID
        {
            get
            {
                return this._ContactID;
            }
            set
            {
                this._ContactID = value;
            }
        }
        #endregion
        #region OriginalContactID
        public abstract class originalContactID : PX.Data.BQL.BqlInt.Field<originalContactID> { }
        [PXInt]
        [PXUIField(Visible = false)]
        public Int32? OriginalContactID
        {
            get
            {
                return this.ContactID;
            }
        }
        #endregion
        #region Format
        public abstract class format : PX.Data.BQL.BqlString.Field<format> { }
        protected string _Format;
        [PXDefault(typeof(Search<NotificationSetup.format,
            Where<NotificationSetup.setupID, Equal<Current<NotificationSetupRecipient.setupID>>>>))]
        [PXDBString(255, BqlField = typeof(NotificationSetupRecipient.format))]
        [PXUIField(DisplayName = "Format")]
        [NotificationFormat.List]
        [PXNotificationFormat(
            typeof(NotificationSetup.reportID),
            typeof(NotificationSetup.notificationID),
            typeof(Where<NotificationSetupRecipient.setupID, Equal<Current<NotificationSetup.setupID>>>))]
        public virtual string Format
        {
            get
            {
                return this._Format;
            }
            set
            {
                this._Format = value;
            }
        }
        #endregion
        #region Active
        public abstract class active : PX.Data.BQL.BqlBool.Field<active> { }
        protected bool? _Active;
        [PXDBBool(BqlField = typeof(NotificationSetupRecipient.active))]
        [PXDefault(typeof(Search<NotificationSetup.active,
            Where<NotificationSetup.setupID, Equal<Current<NotificationSetupRecipient.setupID>>>>))]
        [PXUIField(DisplayName = "Active")]
        public virtual bool? Active
        {
            get
            {
                return this._Active;
            }
            set
            {
                this._Active = value;
            }
        }
        #endregion
        #region AddTo
        public abstract class addTo : PX.Data.BQL.BqlString.Field<addTo> { }

        [PXDBString(1, IsFixed = true, BqlField = typeof(NotificationSetupRecipient.addTo))]
        [RecipientAddTo]
        [PXDefault(RecipientAddToAttribute.To)]
        [PXUIField(DisplayName = "Add To")]
        public virtual string AddTo { get; set; }
        #endregion

        #region tstamp
        public abstract class Tstamp : PX.Data.BQL.BqlByteArray.Field<Tstamp> { }
        protected Byte[] _tstamp;
        [PXDBTimestamp(BqlField = typeof(NotificationSetupRecipient.Tstamp))]
        public virtual Byte[] tstamp
        {
            get
            {
                return this._tstamp;
            }
            set
            {
                this._tstamp = value;
            }
        }
        #endregion
        #region CreatedByID
        public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
        protected Guid? _CreatedByID;
        [PXDBCreatedByID(BqlField = typeof(NotificationSetupRecipient.createdByID))]
        public virtual Guid? CreatedByID
        {
            get
            {
                return this._CreatedByID;
            }
            set
            {
                this._CreatedByID = value;
            }
        }
        #endregion
        #region CreatedByScreenID
        public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
        protected String _CreatedByScreenID;
        [PXDBCreatedByScreenID(BqlField = typeof(NotificationSetupRecipient.createdByScreenID))]
        public virtual String CreatedByScreenID
        {
            get
            {
                return this._CreatedByScreenID;
            }
            set
            {
                this._CreatedByScreenID = value;
            }
        }
        #endregion
        #region CreatedDateTime
        public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
        protected DateTime? _CreatedDateTime;
        [PXDBCreatedDateTime(BqlField = typeof(NotificationSetupRecipient.createdDateTime))]
        public virtual DateTime? CreatedDateTime
        {
            get
            {
                return this._CreatedDateTime;
            }
            set
            {
                this._CreatedDateTime = value;
            }
        }
        #endregion
        #region LastModifiedByID
        public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
        protected Guid? _LastModifiedByID;
        [PXDBLastModifiedByID(BqlField = typeof(NotificationSetupRecipient.lastModifiedByID))]
        public virtual Guid? LastModifiedByID
        {
            get
            {
                return this._LastModifiedByID;
            }
            set
            {
                this._LastModifiedByID = value;
            }
        }
        #endregion
        #region LastModifiedByScreenID
        public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
        protected String _LastModifiedByScreenID;
        [PXDBLastModifiedByScreenID(BqlField = typeof(NotificationSetupRecipient.lastModifiedByScreenID))]
        public virtual String LastModifiedByScreenID
        {
            get
            {
                return this._LastModifiedByScreenID;
            }
            set
            {
                this._LastModifiedByScreenID = value;
            }
        }
        #endregion
        #region LastModifiedDateTime
        public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
        protected DateTime? _LastModifiedDateTime;
        [PXDBLastModifiedDateTime(BqlField = typeof(NotificationSetupRecipient.lastModifiedDateTime))]
        public virtual DateTime? LastModifiedDateTime
        {
            get
            {
                return this._LastModifiedDateTime;
            }
            set
            {
                this._LastModifiedDateTime = value;
            }
        }
        #endregion
    }
}