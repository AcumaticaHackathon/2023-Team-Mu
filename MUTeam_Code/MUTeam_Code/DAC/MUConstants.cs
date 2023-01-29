using PX.Data;

namespace MUTeam_Code
{
    internal class MUConstants
    {

        public static class MUModuleList
        {
            public class ListAttribute : PXStringListAttribute
            {
                public ListAttribute() : base(
                    new string[] { SM },
                    new string[] { SMDesc })

                { }
            }
            //StringCode
            public const string SM = "SM";
            public class sM
                : PX.Data.BQL.BqlString.Constant<sM>
            { public sM() : base(SM) { } }

            //StringDescription
            public const string SMDesc = "Customization";

        }

    }
}
