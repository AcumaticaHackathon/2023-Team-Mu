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

    public PXSelectReadonly<MUCustProject> ProjectList;
    public PXSelect<MUCustProjectNotificationRecipient,
        Where<MUCustProjectNotificationRecipient.projectID, Equal<Current<MUCustProject.projid>>>> RecipientList;

    #endregion

    #region Actions

    public PXSave<MUSMSetup> Save;
    public PXCancel<MUSMSetup> Cancel;

        #endregion


    }
}