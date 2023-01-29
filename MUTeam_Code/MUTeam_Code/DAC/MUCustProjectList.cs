using PX.Data;

namespace MUTeam_Code
{
    [PXProjection(typeof(Select<CustProject>))]
    [PXCacheName("Customization List")]
    public class MUCustProject : CustProject
    {
    }
}
