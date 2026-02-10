//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace FirstRest_Project.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class MyFairstAPIController : ControllerBase
//    {
//        [HttpGet("MyName", Name = "MyName")]
//        public string GetMyName() 
//        {
//            return "My Name is Ahmad";
//        }
//        [HttpGet ("YourName",Name = "YourName")]
//        public string GetYourName()
//        {
//            return "Your Name is Ali";
//        }
//        [HttpGet("Sum/{Num1}/{Num2}")]
//        public int SumTowNumbers(int Num1 , int Num2) 
//        {

//            return Num1 + Num2;
//        }
//        [HttpGet("Multi/{Num3}/{Num4}")]
//        public int MultiTowNumbers(int Num3, int Num4)
//        {

//            return Num3 * Num4;
//        }
//    }

//}
