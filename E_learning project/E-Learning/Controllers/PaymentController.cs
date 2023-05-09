using E_Learning.Interface;
using E_Learning.ViewModels;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Security.Claims;



namespace E_Learning.Controllers
{
    public class PaymentController : Controller
    {
        IStudentRepository studentRepository;
        ICourseStudentRepository courseStudentRepository;
        public PaymentController(IStudentRepository studentRepo, ICourseStudentRepository courseStudentRepo)
        {
            studentRepository = studentRepo;
            courseStudentRepository = courseStudentRepo;
        }


        public ActionResult Charge(string stripeEmail, string stripeToken, long balance)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken,
                Balance = balance
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 5000,
                Description = "Test Payment",
                Currency = "usd",
                Customer = customer.Id
            });
            Claim claim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            int stdId = studentRepository.GetByUserId(claim.Value).Id;
            courseStudentRepository.UpdateIsPaid(stdId);
            return RedirectToAction("Profile", "Student");
        }
    }
}

