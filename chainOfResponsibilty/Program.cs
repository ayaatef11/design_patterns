using System.Security.Cryptography.X509Certificates;

namespace chainOfResponsibilty
{/* team leader can approve developer requests up
  to 3 days otherwise it goes to the technical manager
    technical manager can approve developer requests with more than 3 days and team leader requests as well
    cto can approve technical manager requests 
    ceo can approve cto requests*/
    internal class Program
    {
        static void Main(string[] args)
        {

            var teamLeaderHandler = new TeamLeaderApprovalHandler();
            var trchnicalManagerHandler = new technicalManagerApprovalHandler();
            var ctoHandler=new ctoApprovalHandler();
            var employee = new Employee()
            {
                id = 1,
                name = "ibrahim nada",
                dateOfBirth = new DateOnly(1995, 1, 1),
                hireDate = new DateOnly(2022,1, 1),
                jopTitle=JopTitle.developer
            };
            var request = new vacationRequest
            {
                employee = employee,
                startDate=DateTime.Today.AddDays(59),
                endDate=DateTime.Today.AddDays(15)
            
            };

            var ceoHandler=new ceoApprovalHandler();


            teamLeaderHandler.setNextHandler(trchnicalManagerHandler);
            

        }
    }
    public enum JopTitle
    {
        developer, teamLeader, technicalManager, CTO
    }
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateOnly dateOfBirth { get; set; }
        public DateOnly hireDate { get; set; }
        public JopTitle jopTitle { get; set; }
        public bool isTerminated { get; set; }
    }
    public class vacationRequest
    {
        public Employee employee { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public double totalDays => endDate.Subtract(startDate).TotalDays;
    }
    public interface IApprovalHandler
    {
        void setNextHandler(IApprovalHandler next)
       ;
        //as if i couldn't to the process the other handler can do it
        void process(vacationRequest request);
    }
    public abstract class ApprovalHandler : IApprovalHandler
    {//this is the skelton of chain of responsibility
        public IApprovalHandler next;
        public abstract void process(vacationRequest request);
        public void setNextHandler(IApprovalHandler next)
        {
            this.next = next;

        }
        protected void callNext(vacationRequest request)
        {
            if (this.next != null) next.process(request);
        }
    }
    public class TeamLeaderApprovalHandler : ApprovalHandler
    {
        //team leader can approve developer requests up
        //  to 3 days otherwise it goes to the technical manager
        public override void process(vacationRequest request)
        {
            if (request.employee.jopTitle == JopTitle.developer && request.totalDays <= 3)
            {
                Console.WriteLine("request has been approved by the team leader");
            }
            else callNext(request);
        }
    } 

public class technicalManagerApprovalHandler : ApprovalHandler
    {

        //technical manager can approve developer requests with more than 3 days and team leader requests as well
        public override void process(vacationRequest request)
        {
            if (request.employee.jopTitle == JopTitle.teamLeader || (request.employee.jopTitle == JopTitle.developer && request.totalDays > 3))
            {
                Console.WriteLine("request has beena approved by technical manager");
            }else callNext(request);
        }
    }
    public class ctoApprovalHandler:ApprovalHandler
    {
        public override void  process (vacationRequest request)
        {
            if (request.employee.jopTitle == JopTitle.technicalManager)
            {
                Console.WriteLine("request has been approved by cto");

            }
            else
            {
                callNext(request);
            }
        }
    }
    public class ceoApprovalHandler : ApprovalHandler
    {
        public override void process(vacationRequest request)
        {
            if (request.employee.jopTitle != JopTitle.technicalManager)
            {
                Console.WriteLine("request has been approved by the ceo");
            }
            else callNext(request);
        }
    }
    public class RequestDaysValidationHandler : ApprovalHandler
    {
        public override void process(vacationRequest request)
        {
            if (request.totalDays < 1)
            {
                Console.WriteLine("Request has been rejected because of invalid days");
            }
            else
            {
                callNext(request);
            }
        }
    }
}