using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;
namespace MUTeam_Code
{
    [PXCacheName("Project Log")]
    public class MUCustProjectLog: IBqlTable
    {
        #region ExecutionKey
        [PXDBIdentity]
        public virtual int? ExecutionKey { get; set; }
        public abstract class executionKey : PX.Data.BQL.BqlInt.Field<executionKey> { }
        #endregion
        #region DatePublished
        [PXDBCreatedDateTime()]
        public virtual DateTime? DatePublished { get; set; }
        public abstract class datePublished : PX.Data.BQL.BqlDateTime.Field<datePublished> { }
        #endregion
        #region ProjectList
        [PXDBString(500,IsUnicode =true)]
        public virtual string ProjectList { get; set; }
        public abstract class projectList :
        PX.Data.BQL.BqlString.Field<projectList>
        { }
        #endregion
        #region NotificationID
        [PXDBInt()]
        public virtual int? NotificationID { get; set; }
        public abstract class notificationID : PX.Data.BQL.BqlInt.Field<notificationID> { }
        #endregion
        #region ErrorMessage
        [PXDBString()]
        public virtual string ErrorMessage { get; set; }
        public abstract class errorMessage :
       PX.Data.BQL.BqlString.Field<errorMessage>
        { }
        
            #endregion
    }
}
