using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.CR;
using System;
using PX.Data.BQL;
using PX.Objects.CS;

namespace MUTeam_Code
{
    public class MUCustomizationSetup : PXGraph<MUCustomizationSetup>
  {

    #region Views

    public SelectFrom<MUSMSetup>.View SMSetup;

    public PXSelectReadonly<MUCustProject> ProjectList;
    public PXSelect<MUCustProjectNotificationRecipient,
        Where<MUCustProjectNotificationRecipient.projectID, Equal<Current<MUCustProject.projid>>>> RecipientList;

    #endregion

    #region Actions

    public PXSave<MUSMSetup> Save;
    public PXCancel<MUSMSetup> Cancel;

        #endregion

        #region Event Handlers
/*
        protected void SMNotification_Module_FieldDefaulting(PXCache cache, PXFieldDefaultingEventArgs e)
        {
            if (e.Row == null) return;
            var row = (SMNotification)e.Row;

            e.NewValue = MUConstants.MUModuleList.SM;
        }

        protected void SMNotification_SourceCD_FieldDefaulting(PXCache cache, PXFieldDefaultingEventArgs e)
        {
            if (e.Row == null) return;
            var row = (SMNotification)e.Row;

            e.NewValue = MUConstants.MUModuleList.SMDesc;
        }
*/

        #endregion

    }
}