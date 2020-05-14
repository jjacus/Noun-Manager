using System;
using System.Collections.Generic;
using System.Text;
using CDManager;

namespace CDManager.BLL
{
    class Program
    {
        static void Main(string[] args)
        {
            CDController start = new CDController();
            start.Run();
        }
    }
}
