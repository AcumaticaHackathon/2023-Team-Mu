using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MUTeam_Code.MUConstants;
using static PX.Data.PXGenericInqGrph;
using static PX.Objects.IN.InventoryItem;

namespace MUTeam_Code
{
    public class MUCustomizationProcess : PXGraph<MUCustomizationProcess>
    {
        #region Views
        public PXFilter<MUCustFilter> Filter;
        public PXCancel<MUMetaRow> Cancel;
        public PXSelect<CustProject, Where<CustProject.projid, IsNotNull>> Customizations;
        public PXSelect<MUCustProjectLog> LogBook;
        public PXFilteredProcessing<MUMetaRow, MUCustFilter> JobList;
        //public PXProcessing<
        //    MUMetaRow>

        //    JobList;
        #endregion

        #region Constructor
        public MUCustomizationProcess() 
        {
            JobList.SetProcessAllEnabled(true);
            JobList.SetProcessVisible(false);
            JobList.SetProcessAllCaption("Publish!");
        }
        #endregion

        #region Delegate
        protected virtual IEnumerable jobList()
        {
            MUMetaRow newRow = new MUMetaRow();
            var items = SelectFrom<CustProject>.Where<CustProject.projid.IsNotNull>.View.Select(this).RowCast<CustProject>().ToList();
            items = items.Where(x => x.IsWorking == true).ToList();
            string metadata = string.Empty;
            foreach (var item in items)
            {
                metadata += item.Name + " - " + item.Description + " - " + item.Level +  " | ";
                //gather project data into string
            }
            newRow.Data = metadata;
            //List<MUMetaRow> newList = new List<MUMetaRow>();
            //newList.Add(newRow);
            yield return newRow;
        }
        #endregion
        #region Events
        protected virtual void MUMetaRow_RowSelected(PXCache sender, PXRowSelectedEventArgs e)
        {

            MUCustFilter filter = e.Row as MUCustFilter;
            //if (filter == null)
            //{
                JobList.SetProcessDelegate(
                delegate (List<MUMetaRow> list)
                {

                    var graph = PXGraph.CreateInstance<MUCustomizationProcess>();
                    graph.PerformAction(list,filter);

                }
            );

            //}
            


        }
        #endregion

        #region Process
        public virtual void PerformAction(List<MUMetaRow> list,MUCustFilter filter)
        {
            //TODO Create Log Entry
            MUCustProjectLog LogEntry = new MUCustProjectLog();
            LogEntry.DatePublished = DateTime.Now;
            LogEntry.ProjectName = list.FirstOrDefault().Data;
            LogEntry.NotificationID = filter.NotificationID;
            LogEntry = LogBook.Insert(LogEntry);
            
            //TODO Run Publish and get results
            PublishAPICall WebCall = new PublishAPICall();
            var task = WebCall.PublishPackage("https://hackathon.acumatica.com/Mu/", "admin", "123", new[] { "eSignature" });
            List<PublishResults> Results = task.Result;
            string condensedMessage = "";
            foreach (var item in Results)
            {
                condensedMessage += item.PackageName +" - ";
                foreach (var log in item.Log) 
                {
                    condensedMessage += log.message;
                }
            }
            //TODO Update Log Entry
            LogEntry.ErrorMessage = condensedMessage;
            LogBook.Update(LogEntry);


            //TODO  Send Notifications
        }
        #endregion

        #region fILTER Objects
        [Serializable]
        [PXCacheName("Filter")]
        public partial class MUCustFilter : IBqlTable
        {
            #region NotificationID

            public abstract class notificationID : PX.Data.IBqlField
            {
            }
            protected Int32? _NotificationID;
            [PXUIField(DisplayName ="Mailing ID")]
            
            [PXSelector(typeof(Search<MUSMNotification.notificationID,Where<MUSMNotification.module.IsEqual<MUModuleList.sM>>>), DescriptionField = typeof(MUSMNotification.notificationCD), CacheGlobal = true)]
            public virtual Int32? NotificationID
            {
                get
                {
                    return this._NotificationID;
                }
                set
                {
                    this._NotificationID = value;
                }
            }
            #endregion

        }
        [Serializable]
        [PXCacheName("MetaObject")]
        public partial class MUMetaRow : IBqlTable
        {
            #region Data
            public abstract class bqlField : BqlString.Field<bqlField> { }

            [PXString(500, IsUnicode = true)]
            [PXUIField(DisplayName = "Customizations that will Publish")]
            public virtual string Data
            {
                get;
                set;
            }
            #endregion

        }

        #endregion
    }
}