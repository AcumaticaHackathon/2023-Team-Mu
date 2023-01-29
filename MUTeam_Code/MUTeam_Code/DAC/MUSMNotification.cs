using PX.Data;
using PX.Objects.CS;
using System;

namespace MUTeam_Code
{
    [PXProjection(typeof(Select<NotificationSetup,
                        Where<NotificationSetup.module, Equal<MUConstants.MUModuleList.sM>>>), persistent: new Type[] { typeof(NotificationSetup) })]
    [PXCacheName("Customization Notifications")]
    public class SMNotification : NotificationSetup
    {
    }
}