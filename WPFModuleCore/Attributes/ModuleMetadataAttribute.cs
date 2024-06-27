using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFModuleCore.Entities;

namespace WPFModuleCore.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ModuleMetadataAttribute : Attribute
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

        public ModuleLevel Level { get; set; }
    }
}
