using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFImageExplorer.Models
{
    public class ImageObject
    {
        public ImageObject(FileInfo file)
        {
            Name = file.Name;
            Path = file.FullName;
            ModifyDate = file.LastWriteTime;
        }
        public string Name { get; set; }
        public string Path { get; set; }
        public DateTime ModifyDate { get; set; }
    }

    public class ImageCollection : Collection<ImageObject>
    {
        
    }
}
