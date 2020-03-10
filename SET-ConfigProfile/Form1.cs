using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace SET_ConfigProfile
{
    public partial class Form1 : Form
    {
        #region Constructor
        public List<SourcePathList> sourcePathList { get; set; }
        public List<ConfigFilePathList> configFilePathList { get; set; }

        public class FilePathList
        {
            public int RowIndex { get; set; }
            public string FileFullPathProfile { get; set; }
            public string FileFullPath { get; set; }
            public string FilePath { get; set; }
            public string Filename { get; set; }
            public string FileExtension { get; set; }
            public string FileProfile { get; set; }
            public string Status { get; set; }
        }

        public class ConfigFilePathList
        {
            public string FileFullPath { get; set; }
            public string FileDirectoryPath { get; set; }

            public string FilePath { get; set; }
            public string Filename { get; set; }
            public string FileExtension { get; set; }
            public string FileProfile { get; set; }
        }


        public class SourcePathList
        {
            public string FullPath { get; set; }
            public string DirectoryPath { get; set; }

        }

        public class ProfileList
        {
            public string Ext { get; set; }
            public string DotExt { get; set; }

        }

        List<string> exceptList = new List<string>() { ".git", "packages", "bin", "obj" };
        List<string> exceptExtList = new List<string>() { ".pfx"};

        public class CopyList
        {
            public int RowIndex { get; set; }
            public bool isCheckCopy { get; set; }
            public string DirectoryPath { get; set; }
            public string Filename { get; set; }
            //public string FileFullPath { get; set; }
            //public string FilePath { get; set; }
            //public string FileExtension { get; set; }
            //public string FileProfile { get; set; }
        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            ddlProfile.Enabled = false;
        }

        private void btnBrowseSourceFolder_Click(object sender, EventArgs e)
        {
            sourcePathList = new List<SourcePathList>();
            var applicationPath = Application.StartupPath;

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = applicationPath;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                var folderPath = dialog.FileName;
                txtSourcePath.Text = folderPath;

                var allFolderList = System.IO.Directory.GetDirectories(folderPath, "*", System.IO.SearchOption.AllDirectories).ToList();
                var allFolderListWithoutExcept = allFolderList.Distinct().ToList();
                foreach (var item in exceptList)
                {
                    var exceptPath = Path.Combine(folderPath, item);
                    allFolderListWithoutExcept = allFolderListWithoutExcept.Where(stringToCheck => !stringToCheck.Contains(exceptPath)).ToList();
                }

                foreach (var path in allFolderListWithoutExcept)
                {
                    var item = new SourcePathList();

                    item.FullPath = path;
                    item.DirectoryPath = path.Replace(folderPath, "");
                    sourcePathList.Add(item);

                }

            }

        }

        private void btnBrowseConfigFolder_Click(object sender, EventArgs e)
        {
            configFilePathList = new List<ConfigFilePathList>();

            var applicationPath = Application.StartupPath;

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = applicationPath;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                var folderPath = dialog.FileName;
                txtConfigPath.Text = folderPath;

                //TODO Get List FilePath List
                var allfilesList = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories).ToList();
                var allfilesListWithoutExcept = allfilesList;

                foreach (var item in exceptList)
                {
                    var exceptPath = Path.Combine(folderPath, item);
                    allfilesListWithoutExcept = allfilesListWithoutExcept.Where(stringToCheck => !stringToCheck.Contains(exceptPath)).ToList();
                }

                foreach (var file in allfilesListWithoutExcept)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    var extensionFile = fileInfo.Extension;

                    var checkIsFile = fileInfo.FullName.Replace(extensionFile, "");
                    FileInfo checkIsFileInfo = new FileInfo(checkIsFile);
                    var checkIsFileInfoExt = checkIsFileInfo.Extension;

                    bool isCheckIsFileInfoExtNotInExceptList = exceptExtList.Where(x => x == checkIsFileInfoExt).ToList().Count() == 0;
                    if (isCheckIsFileInfoExtNotInExceptList)
                    {
                        var item = new ConfigFilePathList();
                        item.FileFullPath = fileInfo.FullName;
                        item.FileDirectoryPath = fileInfo.FullName.Replace(folderPath, "").Replace(extensionFile, "");
                        item.Filename = "";
                        item.FileExtension = extensionFile;
                        configFilePathList.Add(item);
                    }

                }

                var ddlProfileList = configFilePathList.Select(x => new ProfileList { Ext = x.FileExtension.Replace(".", ""), DotExt = x.FileExtension }).GroupBy(x => new { x.Ext, x.DotExt }).Select(n => new { n.Key.Ext, n.Key.DotExt }).ToList();
                ddlProfile.DataSource = ddlProfileList;
                ddlProfile.DisplayMember="Ext";
                ddlProfile.ValueMember="DotExt";
                ddlProfile.Enabled = true;



            }

        }
    }
}
