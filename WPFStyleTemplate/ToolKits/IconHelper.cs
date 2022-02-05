using System;
using System.IO;
using System.Runtime.InteropServices;

namespace WPFStyleTemplate.ToolKits
{

    [StructLayout(LayoutKind.Sequential)]
    public struct SHFILEINFO
    {
        public const int NAMESIZE = 80;
        public const int MAX_PATH = 1000;
        public IntPtr hIcon;
        public int iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NAMESIZE)]
        public string szTypeName;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct SHGFI
    {
        public const int Icon = 0x0100;

        public const int DisplayName = 0x0200;

        public const int TypeName = 0x0400;

        public const int Attributes = 0x0800;

        public const int IconLocation = 0x1000;

        public const int ExeType = 0x2000;

        public const int SysIconIndex = 0x4000;

        public const int LargeIcon = 0x00000;

        public const int SmallIcon = 0x00001;

        public const int OpenIcon = 0x00002;

        public const int ShellIconSize = 0x00004;

        public const int Selected = 0x10000;

        public const int LinkOverLay = 0x08000;
    }


    public  class IconHelper
    {
        /// <summary>
        /// 获取文件的图标索引号
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>图标索引号</returns>
        public static int GetIconIndex(string fileName)
        {
            SHFILEINFO info = new SHFILEINFO();
           
            IntPtr iconIntPtr = SHGetFileInfo(fileName, 0, ref info, (uint)Marshal.SizeOf(info), (uint)(SHGFI.SysIconIndex | SHGFI.OpenIcon));
            if (iconIntPtr == IntPtr.Zero)
                return -1;
            return info.iIcon;
        }

        /// <summary>
        /// 根据图标索引号获取图标
        /// </summary>
        /// <param name="iIcon">图标索引号</param>
        /// <param name="flag">图标尺寸标识</param>
        /// <returns></returns>
        //public static System.Drawing.Icon GetIcon(int iIcon, IMAGELIST_SIZE_FLAG flag)
        //{

        //    IImageList list = null;
        //    Guid theGuid = new Guid(IID_IImageList);//目前所知用IID_IImageList2也是一样的
        //    SHGetImageList(flag, ref theGuid, ref list);//获取系统图标列表
        //    IntPtr hIcon = IntPtr.Zero;
        //    int r = list.GetIcon(iIcon, ILD_TRANSPARENT | ILD_IMAGE, ref hIcon);//获取指定索引号的图标句柄
        //    return System.Drawing.Icon.FromHandle(hIcon);
        //}

        /// <summary>
        ///  方法3：从文件获取Icon图标
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="flag">图标尺寸标识</param>
        /// <returns></returns>
        //public static System.Drawing.Icon GetIconFromFile(string fileName, IMAGELIST_SIZE_FLAG flag)
        //{
        //    return GetIcon(GetIconIndex(fileName), flag);
        //}

        [DllImport("Shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);
    }
}
