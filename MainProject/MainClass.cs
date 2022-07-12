using ReferencedProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    public class MainClass : ReferencedClass
    {
        public MainClass()
        {
            var helper = new MainHelperClass();
            var referencedhelper = new ReferenceHelperClass();
        }
    }

    public class MainHelperClass
    {

    }
}
