using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFModuleCore.Entities;

namespace WPFModuleCore
{
    /// <summary>
    /// 模块元数据
    /// </summary>
    public class ModuleMeta
    {
        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName { get; set; }
        /// <summary>
        /// 模块显示名称
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 模块描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 模块加载顺序
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// 模块依赖
        /// </summary>
        public List<string> DependsOn { get; set; }
        /// <summary>
        /// 是否按需加载
        /// </summary>
        public bool OnDemand { get; set; }
        /// <summary>
        /// 模块状态
        /// </summary>
        public ModuleState State { get; set; }
        /// <summary>
        /// 模块级别
        /// </summary>
        public ModuleLevel Level { get; set; }
    }
}
