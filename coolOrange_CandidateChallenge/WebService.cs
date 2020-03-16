using powerGateServer.SDK;

namespace coolOrange_CandidateChallenge
{
    [WebServiceData("CandidateChallenge", "Employee_Service")]
    public class TestService : WebService
    {
        public TestService()
        {
            AddMethod(new Employees());
        }
    }
}