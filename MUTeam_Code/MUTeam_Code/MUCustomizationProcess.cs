using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MUTeam_Code
{
    public class MUCustomizationProcess : PXGraph<MUCustomizationProcess>
    {
        #region Views
        //public PXFilter<MUCustFilter> Filter;
        public PXCancel<MUMetaRow> Cancel;
        public PXSelect<CustProject, Where<CustProject.projid, IsNotNull>> Customizations;
        //[PXFilterable]
        public PXProcessing<
            MUMetaRow>

            JobList;
        #endregion

        #region Constructor
        public MUCustomizationProcess() { }
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
            List<MUMetaRow> newList = new List<MUMetaRow>();
            newList.Add(newRow);
            return newList;
        }
        #endregion
        #region Events
        protected virtual void MUMetaRow_RowSelected(PXCache sender, PXRowSelectedEventArgs e)
        {


            JobList.SetProcessDelegate(
                delegate (List<MUMetaRow> list)
                {

                    var graph = PXGraph.CreateInstance<MUCustomizationProcess>();
                    graph.PerformAction(list);

                }
            );


        }
        #endregion

        #region Process
        public virtual void PerformAction(List<MUMetaRow> list)
        {
            //TODO Create Log Entry
            //TODO Run Publish

            //TODO Get Results of publication

            //TODO Update Log Entry

            //TODO  Send Notifications
        }
        #endregion

        #region fILTER Objects
        [Serializable]
        [PXCacheName("Filter")]
        public partial class MUCustFilter : IBqlTable
        {


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