using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCCalculator.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCalculator.Controllers
{
    public class HomeController : Controller
    {
        string Input;
        public IActionResult Index()
        {
            TempData["result"] = string.Empty;
            TempData["total"] = string.Empty;
            TempData["firstNumber"] = string.Empty;
            TempData["secondNumber"] = string.Empty;
            TempData["sign"] = string.Empty;

            return View();
        }

        [HttpPost]
        public IActionResult Index(string click, IFormCollection input)
        {
            Input = (input["result"]).ToString();

            SelectClick(click);
            return View();
        }

        private string SelectClick(string click)
        {
            int total = 0;
            int firstNumber = 0;
            int secondNumber = 0;

            string result = Input;

            switch (click.ToLower())
            {
                case "c":
                    result = "0";
                    total = 0;
                    TempData["total"] = total;
                    TempData["result"] = "";
                    break;

                case "+":
                    TempData["sign"] = "+";
                    TempData["result"] = "";
                    firstNumber = int.Parse(Input.ToString());
                    TempData["firstNumber"] = firstNumber;
                    break;

                case "-":
                    TempData["sign"] = "-";
                    TempData["result"] = "";
                    firstNumber = int.Parse(Input.ToString());
                    TempData["firstNumber"] = firstNumber;
                    break;

                case "*":
                    TempData["sign"] = "*";
                    TempData["result"] = "";
                    firstNumber = int.Parse(Input.ToString());
                    TempData["firstNumber"] = firstNumber;
                    break;
                case "/":
                    TempData["sign"] = "/";
                    TempData["result"] = "";
                    firstNumber = int.Parse(Input.ToString());
                    TempData["firstNumber"] = firstNumber;
                    break;
                case "=":


                    if ((string)TempData["sign"] == "+")
                    {
                        if (TempData["firstNumber"] != null)
                        {
                            firstNumber = int.Parse(TempData.Peek("firstNumber").ToString());
                            secondNumber = int.Parse(Input.ToString());
                            result = (firstNumber + secondNumber).ToString();
                            TempData["result"] = result;
                        }
                    }
                    if ((string)TempData["sign"] == "-")
                    {
                        if (TempData["firstNumber"] != null)
                        {
                            firstNumber = int.Parse(TempData.Peek("firstNumber").ToString());
                            secondNumber = int.Parse(Input.ToString());
                            result = (firstNumber - secondNumber).ToString();
                            TempData["result"] = result;
                        }
                    }
                    if ((string)TempData["sign"] == "*")
                    {
                        if (TempData["firstNumber"] != null)
                        {
                            firstNumber = int.Parse(TempData.Peek("firstNumber").ToString());
                            secondNumber = int.Parse(Input.ToString());
                            result = (firstNumber * secondNumber).ToString();
                            TempData["result"] = result;
                        }
                    }
                    if ((string)TempData["sign"] == "/")
                    {
                        if (TempData["firstNumber"] != null)
                        {
                            firstNumber = int.Parse(TempData.Peek("firstNumber").ToString());
                            secondNumber = int.Parse(Input.ToString());
                            result = (firstNumber / secondNumber).ToString();
                            TempData["result"] = result;
                        }
                    }

                    TempData["total"] = total;

                    break;


                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    TempData["result"] += click;
                    break;
                default:
                    break;
            }

            return click;
        }


    }
}
