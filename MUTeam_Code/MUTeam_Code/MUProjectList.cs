using System;
using PX.SM;
using PX.Data;
using System.Collections;

namespace MUTeam_Code
{

    // Acuminator disable once PX1016 ExtensionDoesNotDeclareIsActiveMethod extension should be constantly active
    public class ProjectListExt : PXGraphExtension<ProjectList>
    {
        #region Views

        public PXSelect<MUCustProjectNotificationRecipient,
            Where<MUCustProjectNotificationRecipient.projectID,
                Equal<Current<CustProject.projid>>>> ProjectNotifyRecipients;

        #endregion


        #region Actions

        public PXAction<CustProject> openDialogBox;
        [PXUIField(DisplayName = "Open Dialog Box",
            //MapEnableRights = PXCacheRights.Update,
            //MapViewRights = PXCacheRights.Update,
            Visible = true)]
        [PXButton(Category = "Publish", DisplayOnMainToolbar = true)]
        public virtual IEnumerable OpenDialogBox(PXAdapter adapter)
        {
            if(ProjectNotifyRecipients.AskExt() == WebDialogResult.OK)
            {
            }
            return adapter.Get();
        }

        #endregion

    }
}