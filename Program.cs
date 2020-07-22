using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

using LegisTests;

namespace POMExample
{
  class Program
  {
    static void Main(string[] args)
    {
      String osv = System.Environment.OSVersion.VersionString;
      String divider = osv.Contains("Windows") ? "\\" : "/";
      string path = "C:\\Users\\username\\Workspace\\path1\\path2\\legis\\LegisTests\\bin\\Debug\\netcoreapp3.0";

      string[] splited = path.Split(divider);
      string concat = "";
      for (int i = 0; i < splited.Length - 3; i++)
      {
        concat += splited[i] + divider;
      }
      Console.WriteLine(concat);
    }
  }
}