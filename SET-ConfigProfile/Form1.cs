﻿using System;
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
        //public List<SourcePathList> sourcePathList { get; set; }
        //public List<ConfigFilePathList> configFilePathList { get; set; }

        public class FilePathList
        {
            public int RowIndex { get; set; }
            public string FileFullPathProfile { get; set; }
            public string FileDirectoryPath { get; set; }
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
        List<string> exceptExtList = new List<string>() { ".pfx" };
        List<string> configExtList = new List<string>() { ".csproj", ".cs", ".config" };

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

        public class SelectedItem
        {
            public string Text { get; set; }
            public string Value { get; set; }
        }
        public class ConstCheckIsDirectoryOrFile
        {
            public const string Directory = "D";
            public const string File = "F";
            public const string NotFound = "N";
        }

        public class ConstCheckIsConfigOrProfile
        {
            public const string Config = "C";
            public const string Profile = "P";
            public const string NotFound = "N";
        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            ddlProfile.Enabled = false;
            CopyDataGridView.Rows.Clear();
            CopyDataGridView.AllowUserToAddRows = false;
            CopyDataGridView.Refresh();
        }

        #region Source

        private void btnBrowseSourceFolder_Click(object sender, EventArgs e)
        {
            var applicationPath = Application.StartupPath;

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = applicationPath;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                var folderPath = dialog.FileName;
                txtSourcePath.Text = folderPath;
            }

        }

        #endregion

        #region Config
        private void btnBrowseConfigFolder_Click(object sender, EventArgs e)
        {
            var applicationPath = Application.StartupPath;

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = applicationPath;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                var folderPath = dialog.FileName;
                txtConfigPath.Text = folderPath;

                var ddlProfileList = GetProfileList(folderPath);
                ddlProfile.DataSource = ddlProfileList;
                ddlProfile.DisplayMember = "Text";
                ddlProfile.ValueMember = "Value";
                ddlProfile.Enabled = true;

                BindCopyGrid();
            }

        }

        #endregion

        #region GridView
        public void RefreshGridview()
        {
            var sourcePathList = GetSourcePathList(txtSourcePath.Text);
            var configFilePathList = GetConfigFilePathList(txtConfigPath.Text);




            //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
            //SqlCommand cmd = new SqlCommand("select * from tbl_data", con);
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //sda.Fill(ds);
            //GridView1.DataSource = ds;
            //GridView1.DataBind();
        }

        private void BindCopyGrid()
        {
            CopyDataGridView.Rows.Clear();
            DataTable dt = new DataTable();

            string selProfile = ddlProfile.SelectedValue.ToString();

            //var CopyFileList = GetConfigFilePathList(txtConfigPath.Text).Where(x => x.FileProfile == selProfile).ToList();
            var CopyFileList = GetCopyList();
            if (CopyFileList.Count > 0)
            {
                var i = 0;

                var indexStatus = CopyDataGridView.Columns["Status"].Index;
                var indexDirectoryPath = CopyDataGridView.Columns["DirectoryPath"].Index;
                var indexFileName = CopyDataGridView.Columns["FileName"].Index;
                var indexProfile = CopyDataGridView.Columns["Profile"].Index;

                foreach (var item in CopyFileList)
                {
                    CopyDataGridView.Rows.Add();
                    CopyDataGridView.AllowUserToAddRows = false;

         
                    CopyDataGridView.Rows[i].Cells[indexDirectoryPath].Value = item.DirectoryPath;
                    CopyDataGridView.Rows[i].Cells[indexFileName].Value = item.Filename;

                    DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();
                    var profileList = GetProfileList(item.DirectoryPath, item.Filename);// Bind combobox with datasource.  
                    l_objGridDropbox.DataSource = profileList; 
                    l_objGridDropbox.DisplayMember = "Text";
                    l_objGridDropbox.ValueMember = "Value";

    

                    bool isHasProfile = profileList.Where(x => x.Value == selProfile).ToList().Count > 0;

                    if(isHasProfile){
                        CopyDataGridView.Rows[i].Cells[0].Value = true;
                        CopyDataGridView.Rows[i].Cells[indexStatus].Value = "Prompt";
                        l_objGridDropbox.Value = selProfile;
                    }
                    else
                    {
                        CopyDataGridView.Rows[i].Cells[0].Value = false;
                        CopyDataGridView.Rows[i].Cells[indexStatus].Value = "Profile not Same";
                        if (profileList.Count > 0)
                        {
                            l_objGridDropbox.Value = profileList.Select(x => x.Value).FirstOrDefault();
                        }
                    }

                    CopyDataGridView[indexProfile, i] = l_objGridDropbox;
             
                    i++;
                }
            }
        }




        #endregion

        #region Function

        private string CheckIsDirectoryOrFile(string path)
        {
            string toReturn = "";

            try
            {
                FileAttributes attr = File.GetAttributes(path);

                if (attr.HasFlag(FileAttributes.Directory))
                    toReturn = ConstCheckIsDirectoryOrFile.Directory;
                else
                    toReturn = ConstCheckIsDirectoryOrFile.File;
            }
            catch (Exception)
            {
                toReturn = ConstCheckIsDirectoryOrFile.NotFound;
            }

            return toReturn;
        }

        private string CheckFileConfigOrProfile(string filePath)
        {
            string toReturn = "";

            try
            {
                FileInfo fileInfo = new FileInfo(filePath);
                var extensionFile = fileInfo.Extension;
                foreach (var item in configExtList)
                {
                    if (item == extensionFile)
                    {
                        toReturn = ConstCheckIsConfigOrProfile.Config;
                        break;
                    }
                    else
                    {
                        toReturn = ConstCheckIsConfigOrProfile.Profile;
                    }
                }
            }
            catch (Exception)
            {
                toReturn = ConstCheckIsConfigOrProfile.NotFound;
            }

            return toReturn;
        }

        private List<SourcePathList> GetSourcePathList(string folderPath)
        {
            var toReturn = new List<SourcePathList>();

            var allFolderList = GetAllDirectory(folderPath);
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
                toReturn.Add(item);
            }

            return toReturn;
        }
        private List<ConfigFilePathList> GetConfigFilePathList(string folderPath)
        {
            var toReturn = new List<ConfigFilePathList>();

            var removeList = new List<string>();

            var allfilesList = GetAllFileInDirectory(folderPath);
            var allfilesListWithoutExcept = allfilesList;

            foreach (var item in exceptList)
            {
                var exceptPath = Path.Combine(folderPath, item);
                allfilesListWithoutExcept = allfilesListWithoutExcept.Where(stringToCheck => !stringToCheck.Contains(exceptPath)).ToList();
            }

            foreach (var itemExt in exceptExtList)
            {
                foreach (var file in allfilesListWithoutExcept)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    var extensionFile = fileInfo.Extension;

                    if (itemExt == extensionFile)
                    {
                        removeList.Add(file);
                    }
                }
            }

            foreach (var item in removeList)
            {
                allfilesListWithoutExcept.Remove(item);
            }

            foreach (var file in allfilesListWithoutExcept)
            {
                var chechIsDirectoryOrFile = CheckIsDirectoryOrFile(file);

                if (ConstCheckIsDirectoryOrFile.File == chechIsDirectoryOrFile)
                {

                    FileInfo fileInfo = new FileInfo(file);
                    var extensionFile = fileInfo.Extension;
                    var checkConfigOrProfile = CheckFileConfigOrProfile(file);

                    var item = new ConfigFilePathList();
                    item.FileFullPath = fileInfo.FullName;
                    item.FileDirectoryPath = fileInfo.FullName.Replace(folderPath, "").Replace(fileInfo.Name, "");
                    item.FileExtension = extensionFile;
                    item.FileProfile = extensionFile;

                    if (ConstCheckIsConfigOrProfile.Config == checkConfigOrProfile)
                    {
                        item.Filename = fileInfo.Name;
                    }
                    else
                    {
                        item.Filename = fileInfo.Name.Replace(extensionFile, "");
                    }

                    toReturn.Add(item);
                }
            }

            return toReturn;
        }
        private List<SelectedItem> GetProfileList(string folderPath)
        {
            var toReturn = new List<SelectedItem>();

            var configFilePathList = GetConfigFilePathList(folderPath);
            try
            {
                toReturn = configFilePathList.Select(x => new { Text = x.FileExtension.Replace(".", ""), Value = x.FileExtension }).GroupBy(x => new { x.Text, x.Value }).Select(n => new SelectedItem { Text = n.Key.Text, Value = n.Key.Value }).ToList();
            }
            catch
            {


            }

            return toReturn;
        }


        private List<SelectedItem> GetProfileList(string folderPath, string filename)
        {
            var toReturn = new List<SelectedItem>();

            var configPath = txtConfigPath.Text;

            var configFilePathList = GetConfigFilePathList(configPath);
            configFilePathList = configFilePathList.Where(x => x.FileDirectoryPath == folderPath).Where(x => x.Filename == filename).ToList();

            try
            {
                toReturn = configFilePathList.Select(x => new { Text = x.FileExtension.Replace(".", ""), Value = x.FileExtension }).GroupBy(x => new { x.Text, x.Value }).Select(n => new SelectedItem { Text = n.Key.Text, Value = n.Key.Value }).ToList();
            }
            catch
            {


            }

            return toReturn;
        }

        private List<CopyList> GetCopyList()
        {
            var toReturn = new List<CopyList>();

            var configFilePathList = GetConfigFilePathList(txtConfigPath.Text);

            foreach (var item in configFilePathList)
            {
                var addItem = new CopyList();

                addItem.DirectoryPath = item.FileDirectoryPath;
                addItem.Filename = item.Filename;

                toReturn.Add(addItem);
            }

            toReturn = toReturn.GroupBy(g => new { g.DirectoryPath, g.Filename }).Select(x => new CopyList { DirectoryPath = x.Key.DirectoryPath, Filename = x.Key.Filename }).ToList();

            return toReturn;
        }

        private List<string> GetAllDirectory(string folderPath)
        {
            var toReturn = new List<string>();

            try
            {
                toReturn = Directory.GetDirectories(folderPath, "*", System.IO.SearchOption.AllDirectories).ToList();
            }
            catch
            {

            }

            return toReturn;
        }
        private List<string> GetAllFileInDirectory(string folderPath)
        {
            var toReturn = new List<string>();

            try
            {
                toReturn = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories).ToList();
            }
            catch
            {

            }

            return toReturn;
        }
        #endregion

        private void CopyDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1)
            {
                // Bind grid cell with combobox and than bind combobox with datasource.  
                //DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();
                //DataGridViewRow row = CopyDataGridView.Rows[e.RowIndex];

                //var indexDirectoryPath = CopyDataGridView.Columns["DirectoryPath"].Index;
                //var indexFileName = CopyDataGridView.Columns["FileName"].Index;

                //if (CopyDataGridView.Columns[e.ColumnIndex].Name.Contains("Profile"))
                //{
                //    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                //    CopyDataGridView[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;

                //    var directoryPath = row.Cells[indexDirectoryPath].Value.ToString();
                //    var fileName = row.Cells[indexFileName].Value.ToString();
                //    l_objGridDropbox.DataSource = GetProfileList(directoryPath, fileName); // Bind combobox with datasource.  
                //    l_objGridDropbox.ValueMember = "Text";
                //    l_objGridDropbox.DisplayMember = "Value";

                //}


            }
        }

        //private void CopyDataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        //{
        //    string selProfile = ddlProfile.SelectedValue.ToString();
        //    var indexProfile = CopyDataGridView.Columns["Profile"].Index;

        //    e.Row.Cells[indexProfile].Value = selProfile;
        //}





        private void CopyDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        //if (e.RowIndex > 0)
        //{
        //    string selProfile = ddlProfile.SelectedValue.ToString();

        //    DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();
        //    DataGridViewRow row = CopyDataGridView.Rows[e.RowIndex];

        //    var indexDirectoryPath = CopyDataGridView.Columns["DirectoryPath"].Index;
        //    var indexFileName = CopyDataGridView.Columns["FileName"].Index;
        //    var indexProfile = CopyDataGridView.Columns["Profile"].Index;

        //    CopyDataGridView[indexProfile, e.RowIndex] = l_objGridDropbox;

        //    var directoryPath = row.Cells[indexDirectoryPath].Value.ToString();
        //    var fileName = row.Cells[indexFileName].Value.ToString();
        //    l_objGridDropbox.DataSource = GetProfileList(directoryPath, fileName); // Bind combobox with datasource.  
        //    l_objGridDropbox.ValueMember = "Text";
        //    l_objGridDropbox.DisplayMember = "Value";

        //    l_objGridDropbox.Value = selProfile;

        //}


    }
}
