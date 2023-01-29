using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.CR;
using System;
using PX.Data.BQL;
using PX.Objects.CS;
using PX.Objects;

namespace MUTeam_Code
{
    public class MUCustomizationSetup : PXGraph<MUCustomizationSetup>
  {

    #region Views

    public SelectFrom<MUSMSetup>.View SMSetup;

    public CRNotificationSetupList<MUSMNotification> Notifications;
    public PXSelect<MUNotificationSetupRecipient,
        Where<MUNotificationSetupRecipient.setupID, Equal<Current<MUSMNotification.setupID>>>> Recipients;

    #endregion

    #region Actions

    public PXSave<MUSMSetup> Save;
    public PXCancel<MUSMSetup> Cancel;

        #endregion

        #region Event Handlers

        protected void SMNotification_Module_FieldDefaulting(PXCache cache, PXFieldDefaultingEventArgs e)
        {
            if (e.Row == null) return;
            var row = (MUSMNotification)e.Row;

            e.NewValue = MUConstants.MUModuleList.SM;
        }

        protected void SMNotification_SourceCD_FieldDefaulting(PXCache cache, PXFieldDefaultingEventArgs e)
        {
            if (e.Row == null) return;
            var row = (MUSMNotification)e.Row;

            e.NewValue = MUConstants.MUModuleList.SMDesc;
        }


        #endregion

    }
}