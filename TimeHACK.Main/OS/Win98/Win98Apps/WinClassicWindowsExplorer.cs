﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TimeHACK.Engine.SaveSystem;
using System.IO;
using TimeHACK.Engine;
using Newtonsoft.Json;
using TimeHACK.Engine.Template;

namespace TimeHACK.OS.Win95.Win95Apps
{
    public partial class WinClassicWindowsExplorer : UserControl
    {
        public bool IsFileOpenDialog = false;
        public bool IsFileSaveDialog = false;
        public string onlyViewExtension = "";

        string ToReplaceWith = ProfileDirectory;
        string currentDirectory = Path.Combine(ProfileDirectory, "folders", "Computer");
        string oldLabelText;
        int fileType = 6;
        //string attemptedDirectory = "";
        WindowManager wm = new WindowManager();

        public WinClassicWindowsExplorer()
        {
            InitializeComponent();
        }

        //'Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs)
        //'    mainView.Items.Clear()
        //'    Dim childamount As TreeNodeCollection
        //'    childamount = TreeView1.SelectedNode.Nodes
        //'    lblamountofobjects.Text = (childamount.Count & " objects(s)")
        //'    For Each TreeNode In TreeView1.SelectedNode.Nodes
        //'        If TreeNode.tag = "file" Then
        //'            TreeNode.forecolor = TreeView1.BackColor
        //'        End If
        //'        mainView.Items.Add(TreeNode.text)
        //'    Next
        //'End Sub

        string ReadDataFile(string reqDirectory, bool returnYesIfProtected = false) {
            string Val = "";
            string directoryFileInfo;
            directoryFileInfo = File.ReadAllText(Path.Combine(reqDirectory, "_data.info"));
            FileSystemFolderInfo toRead = new FileSystemFolderInfo();
            toRead = JsonConvert.DeserializeObject<FileSystemFolderInfo>(directoryFileInfo);

            if (returnYesIfProtected == true)
            {
                if (toRead.Isprotected == true)
                {
                    return "yes";
                }
            }
            else
            {
                return toRead.label;
            }
            return Val;
        }

        void RefreshAll() {
            try {
                // Refresh the right listview
                this.mainView.Items.Clear();
                // For Each drive As string In My.Computer.FileSystem.GetDirectories(GameMain.MyDocuments & "\HistacomVB\" & GameMain.SaveProfile & "\HistacomVB\Folders")
                //    If GetPropetiesForDir(drive)(4) = "isMyDocuments" Then
                //        diskView.Items.Add("", 0)
                //    End If
                //Next
                foreach (string str in Directory.GetDirectories(currentDirectory))
                {
                    string label = ReadDataFile(str, false);
                    if (label == "")
                    {
                        ListViewItem itm = this.mainView.Items.Add(Path.GetFileName(str));
                        itm.ImageKey = str;
                    } else {
                        ListViewItem itm = this.mainView.Items.Add(label);
                        itm.ImageKey = str;
                    }
                }
                foreach (string str in Directory.GetFiles(currentDirectory))
                {
                    // Get the app Icon

                    //int AppIcon = 2;

                    //switch (new FileInfo(str).Extension)
                    //{
                    //    case ".exe":
                    //        string contents;

                    //        contents = File.ReadAllText(str);

                    //        switch (contents.ToLower())
                    //        {
                    //            case "calc":
                    //                AppIcon = 3;
                    //                break;
                    //            case "explorer":
                    //                AppIcon = 4;
                    //                break;
                    //        }
                    //        break;
                    //}



                    if (IsFileOpenDialog == true || IsFileSaveDialog == true)
                    {
                        if (!(Path.GetFileName(str) == "_data.info"))
                        {
                            if (new FileInfo(str).Extension == onlyViewExtension)
                            {
                                ListViewItem itm = this.mainView.Items.Add(Path.GetFileName(str));
                                itm.Tag = str;
                            }
                        }
                    } else {
                        if (!(Path.GetFileName(str) == "_data.info")) {
                            ListViewItem itm = this.mainView.Items.Add(Path.GetFileName(str));
                            itm.Tag = str;
                        }
                    }
                }
            } catch (Exception ex) {
                wm.StartInfobox95("Exploring - C:", "Error with the file explorer \n" + ex.Message, Properties.Resources.Win95Info);
                ((Form)this.TopLevelControl).Close();
            }
        }

        void OpenFile(string fileDir)
        {
            try
            {
                ReturnType(new FileInfo(fileDir).Extension);
                switch (fileType)
                {
                    case 1:
                        WinClassicNotepad np = new WinClassicNotepad();
                        np.mainText.Text = FileDialogBoxManager.ReadTextFile(fileDir);
                        WinClassic app = wm.StartWin95(np, "Notepad", Properties.Resources.Win95IconNotepad, true, true);

                        Program.AddTaskbarItem(app, app.Tag.ToString(), "Notepad", Properties.Resources.Win95IconNotepad);

                        break;
                    case 12:
                        OpenApplication(FileDialogBoxManager.ReadTextFile(fileDir));
                        break;
                }
            } catch {
            }
            
        }

        void OpenApplication(string appname)
        {
            switch (appname.ToLower())
            {               
                case "explorer":
                    Engine.Template.WinClassic app = wm.StartWin95(new Win95WindowsExplorer(), "Windows Explorer", Properties.Resources.WinClassicFileExplorer, true, true);
                    Program.AddTaskbarItem(app, app.Tag.ToString(), "Windows Explorer", Properties.Resources.WinClassicFileExplorer);
                    break;
                case "calc":
                    Engine.Template.WinClassic appCalc = wm.StartWin95(new WinClassicCalculator(), "Calculator", Properties.Resources.WinClassicCalc, true, true);
                    Program.AddTaskbarItem(appCalc, appCalc.Tag.ToString(), "Calculator", Properties.Resources.WinClassicCalc);

                    Program.nonimportantapps.Add(appCalc);
                    Program.nonimportantapps[Program.nonimportantapps.Count - 1].BringToFront();
                    Program.nonimportantapps[Program.nonimportantapps.Count - 1].FormClosing += new FormClosingEventHandler(Program.NonImportantApp_Closing);

                    break;
                case "wordpad":
                    Engine.Template.WinClassic appWP = wm.StartWin95(new WinClassicWordPad(), "Wordpad", Properties.Resources.WinClassicWordpad, true, true);
                    Program.AddTaskbarItem(appWP, appWP.Tag.ToString(), "Wordpad", Properties.Resources.WinClassicWordpad);

                    Program.nonimportantapps.Add(appWP);
                    Program.nonimportantapps[Program.nonimportantapps.Count - 1].BringToFront();
                    Program.nonimportantapps[Program.nonimportantapps.Count - 1].FormClosing += new FormClosingEventHandler(Program.NonImportantApp_Closing);

                    break;
                case "addressbook":
                    WinClassic appAdBk = wm.StartWin95(new WinClassicAddressBook(), "Address Book", Properties.Resources.WinClassicAddressBook, true, true);
                    Program.AddTaskbarItem(appAdBk, appAdBk.Tag.ToString(), "Address Book", Properties.Resources.WinClassicAddressBook);

                    Program.nonimportantapps.Add(appAdBk);
                    Program.nonimportantapps[Program.nonimportantapps.Count - 1].BringToFront();
                    Program.nonimportantapps[Program.nonimportantapps.Count - 1].FormClosing += new FormClosingEventHandler(Program.NonImportantApp_Closing);

                    break;
            }
            }

        string ReturnType(string extension) {
            string returnVal = "";
            fileType = 1;
            switch (extension) {
                case ".txt":
                    fileType = 1;
                    returnVal = "Text Document \n createtext";
                    break;
                case ".dat":
                    fileType = 1;
                    returnVal = "Text Document \n createtext";
                    break;
                case ".rtf":
                    fileType = 2;
                    returnVal = "Rich Text Document \n createtext";
                    break;
                case ".cfg":
                    fileType = 1;
                    returnVal = "Config file \n createtext";
                    break;
                case ".log":
                    fileType = 1;
                    returnVal = "log text file \n createtext";
                    break;
                case ".properties":
                    fileType = 1;
                    returnVal = "Config file \n createtext";
                    break;
                case ".json":
                    fileType = 1;
                    returnVal = "Config file \n createtext";
                    break;
                case ".doc":
                    fileType = 3;
                    returnVal = "Word Document (Old) \n word";
                    break;
                case ".docx":
                    fileType = 3;
                    returnVal = "Word Document \n word";
                    break;
                case ".docm":
                    fileType = 3;
                    returnVal = "Macro-Enabled Word Document \n word";
                    break;
                case ".xls":
                    fileType = 4;
                    returnVal = "Excel Spreadsheets (Old) \n excel";
                    break;
                case ".xlsx":
                    fileType = 4;
                    returnVal = "Excel Spreadsheets \n excel";
                    break;
                case ".ppt":
                    fileType = 5;
                    returnVal = "Powerpoint Presentation (Old) \n powerpoint";
                    break;
                case ".pptx":
                    fileType = 5;
                    returnVal = "Powerpoint Presentation \n powerpoint";
                    break;
                case ".pub":
                    fileType = 7;
                    returnVal = "Publisher Document \n powerpoint";
                    break;
                case ".xps":
                    fileType = 8;
                    returnVal = "XPS Document \n xpsview";
                    break;
                case ".htm":
                    fileType = 9;
                    returnVal = "HTML web page \n html";
                    break;
                case ".html":
                    fileType = 9;
                    returnVal = "HTML web page \n html";
                    break;
                case ".wps":
                    fileType = 10;
                    returnVal = "Works document \n works";
                    break;
                case ".wmf":
                    fileType = 11;
                    returnVal = "Windows Metafile (A picture) \n createart";
                    break;
                case ".emf":
                    fileType = 11;
                    returnVal = "Enhanced Metafile (A picture) \n createart";
                    break;
                case ".png":
                    fileType = 11;
                    returnVal = "Picture file (Portable Network Graphics) \n createart";
                    break;
                case ".jpg":
                    fileType = 11;
                    returnVal = "Picture file \n createart";
                    break;
                case ".jpeg":
                    fileType = 11;
                    returnVal = "Picture file \n createart";
                    break;
                case ".gif":
                    fileType = 12;
                    returnVal = "Picture file \n gifman";
                    break;
                case ".tif":
                    fileType = 11;
                    returnVal = "Picture file \n createart";
                    break;
                case ".bmp":
                    fileType = 11;
                    returnVal = "Picture file \n createart";
                    break;
                case ".zip":
                    fileType = 11;
                    returnVal = "Compressed ZIP file \n winrar";
                    break;
                case ".rar":
                    fileType = 11;
                    returnVal = "WINRAR Compressed file \n winrar";
                    break;
                case ".gz":
                    fileType = 11;
                    returnVal = "WINRAR file \n winrar";
                    break;
                case ".7z":
                    fileType = 11;
                    returnVal = "7ZIP file \n 7z";
                    break;
                case ".ace":
                    fileType = 11;
                    returnVal = "WINRAR file \n winrar";
                    break;
                case ".arj":
                    fileType = 11;
                    returnVal = "WINRAR file \n winrar";
                    break;
                case ".bz2":
                    fileType = 11;
                    returnVal = "WINRAR file \n winrar";
                    break;
                case ".gzip":
                    fileType = 11;
                    returnVal = "WINRAR file \n winrar";
                    break;
                case ".lzh":
                    fileType = 11;
                    returnVal = "WINRAR file \n winrar";
                    break;
                case ".tar":
                    fileType = 11;
                    returnVal = "WINRAR file \n winrar";
                    break;
                case ".uue":
                    fileType = 11;
                    returnVal = "WINRAR file \n winrar";
                    break;
                case ".xz":
                    fileType = 11;
                    returnVal = "WINRAR file \n winrar";
                    break;
                case ".z":
                    fileType = 11;
                    returnVal = "WINRAR file \n winrar";
                    break;
                case ".001":
                    fileType = 11;
                    returnVal = "WINRAR file \n winrar";
                    break;
                case ".exe":
                    fileType = 12;
                    returnVal = "Program \n exe";
                    break;
                case ".jar":
                    fileType = 13;
                    returnVal = "Java file \n java";
                    break;
                case ".iso":
                    fileType = 14;
                    returnVal = "CD Image file \n iso";
                    break;
                case ".avi":
                    fileType = 15;
                    returnVal = "Video \n video";
                    break;
                case ".m4v":
                    fileType = 15;
                    returnVal = "Video (MPEG-4) \n video";
                    break;
                case ".mp4":
                    fileType = 15;
                    returnVal = "Video (MPEG-4) \n video";
                    break;
                case ".wmv":
                    fileType = 15;
                    returnVal = "Video \n video";
                    break;
                case ".m2v":
                    fileType = 15;
                    returnVal = "Video \n video";
                    break;
                case ".m3u":
                    fileType = 15;
                    returnVal = "Video \n video";
                    break;
                case ".mts":
                    fileType = 15;
                    returnVal = "Video \n video";
                    break;
                case ".dv":
                    fileType = 15;
                    returnVal = "Video (Digital Video) \n video";
                    break;
                case ".flv":
                    fileType = 15;
                    returnVal = "Video \n video";
                    break;
                case ".m1v":
                    fileType = 15;
                    returnVal = "Video \n video";
                    break;
                case ".m2ts":
                    fileType = 15;
                    returnVal = "Video \n video";
                    break;
                case ".mkv":
                    fileType = 15;
                    returnVal = "Video \n video";
                    break;
                case ".mov":
                    fileType = 15;
                    returnVal = "Video \n video";
                    break;
                case ".mpeg4":
                    fileType = 15;
                    returnVal = "Video \n video";
                    break;
                case ".mpeg":
                    fileType = 15;
                    returnVal = "Video \n video";
                    break;
                case ".mpg":
                    fileType = 15;
                    returnVal = "Video \n video";
                    break;
                case ".3gp":
                    fileType = 15;
                    returnVal = "Video \n video";
                    break;
                case ".m4p":
                    fileType = 15;
                    returnVal = "Video \n video";
                    break;
                case ".mp2":
                    fileType = 21;
                    returnVal = "Audio \n video";
                    break;
                case ".mp3":
                    fileType = 21;
                    returnVal = "Audio \n video";
                    break;
                case ".wav":
                    fileType = 21;
                    returnVal = "Audio \n video";
                    break;
                case ".nls":
                    fileType = 16;
                    returnVal = "Font file \n font";
                    break;
                case ".dll":
                    fileType = 17;
                    returnVal = "System File \n sys";
                    break;
                case ".bat":
                    fileType = 18;
                    returnVal = "MS-DOS Batch file \n winterm";
                    break;
                case ".url":
                    fileType = 19;
                    returnVal = "Shortcut \n short";
                    break;
                case ".sh":
                    fileType = 20;
                    returnVal = "BASH file \n winterm";
                    break;
                case ".win":
                    fileType = 17;
                    returnVal = "System file \n sys";
                    break;
            }
            return returnVal;
        }

    //Private Sub windows_explorer_Closed(sender As Object, e As EventArgs) Handles Me.Closed
    //    IsFileDialog = False
    //End Sub
        void WinClassicWindowsExplorer_Load(object sender, EventArgs e) {
            diskView.ImageList = new ImageList();

            diskView.ImageList.Images.Add(Properties.Resources.Win95DesktopIcon);
            diskView.ImageList.Images.Add(Properties.Resources.Win95HardDiskIcon);
            diskView.ImageList.Images.Add(Properties.Resources.WinClassicFolderSmall);
            diskView.ImageList.Images.Add(Properties.Resources.WinClassicOpenFolderSmall);
            diskView.ImageList.Images.Add(Properties.Resources.Win95ControlPanelIcon);
            diskView.ImageList.Images.Add(Properties.Resources.Win95PrintersFolder);
            diskView.ImageList.Images.Add(Properties.Resources.Win95ComputerIcon);
            diskView.ImageList.Images.Add(Properties.Resources.Win95NetworkIcon);
            diskView.ImageList.Images.Add(Properties.Resources.Win95RecycleIcon);

            program.BringToFront();

            int loc = 0;
            TreeNode[] folders = new TreeNode[new DirectoryInfo(currentDirectory).GetDirectories().Length];
            foreach (DirectoryInfo folder in new DirectoryInfo(currentDirectory).GetDirectories())
            {
                if (folder.GetDirectories().Length > 0)
                {
                    string label = ReadDataFile(folder.FullName, false);
                    TreeNode[] tn = createSubDirNodes(folder);
                    folders[loc] = new TreeNode(label ?? folder.Name, 2, 3, tn);
                    folders[loc].Tag = folder.FullName;
                }
                else
                {
                    string label = ReadDataFile(folder.FullName, false);
                    folders[loc] = new TreeNode(label ?? folder.Name, 2, 3);
                    folders[loc].Tag = folder.FullName;
                }
                loc++;
            }
            TreeNode[] mypcarray = new TreeNode[3];
            mypcarray[0] = new TreeNode("(C:)", 1, 1, folders);
            mypcarray[1] = new TreeNode("Control Panel", 4, 4);
            mypcarray[2] = new TreeNode("Printers", 5, 5);
            TreeNode[] desktoparray = new TreeNode[3];
            desktoparray[0] = new TreeNode("My Computer", 6, 6, mypcarray);
            desktoparray[1] = new TreeNode("Network Neighborhood", 7, 7);
            desktoparray[2] = new TreeNode("Recycle Bin", 8, 8);
            diskView.Nodes.Add(new TreeNode("Desktop", 0, 0, desktoparray));
            

            //diskView.Items.Add("My Computer", 0);
            Application.DoEvents();

            RefreshAll();

            if (FileDialogBoxManager.IsInOpenDialog)
            {
                IsFileOpenDialog = true;
            }
            else if (FileDialogBoxManager.IsInSaveDialog)
            {
                IsFileSaveDialog = true;
            }

            if (IsFileOpenDialog == true)
            {
                pnlSave.Show();
                Button1.Text = "Open";
            }
            else
            {
                if (IsFileSaveDialog == true)
                {
                    pnlSave.Show();
                    Button1.Text = "Save";
                }
            }

            onlyViewExtension = FileDialogBoxManager.OnlyViewExtension;
        }

        void mainView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (mainView.FocusedItem.Tag == null)
                { // If it isn't a file
                    GoToDir(Path.Combine(currentDirectory, mainView.FocusedItem.ImageKey.ToString()));
                }
                else
                { // If it is a file
                        if (IsFileOpenDialog == true || IsFileSaveDialog == true)
                        {
                            if (new FileInfo(Path.Combine(currentDirectory, txtSave.Text)).Extension == onlyViewExtension)
                            {
                                Program.WindowsExplorerReturnPath = Path.Combine(currentDirectory, txtSave.Text);
                            }


                            FileDialogBoxManager.IsInOpenDialog = false;
                            FileDialogBoxManager.IsInSaveDialog = false;

                            ((Form)this.TopLevelControl).Close();
                        }
                        else
                        {
                            OpenFile((string)mainView.FocusedItem.Tag);
                        }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        void diskView_AfterSelect(object sender, EventArgs e)
        {
            try
            {
                if (diskView.SelectedNode != null)
                {
                    if (diskView.SelectedNode.Text == "My Computer")
                    {
                        GoToDir(ProfileFileSystemDirectory);
                    }
                    else if (diskView.SelectedNode.Text == "(C:)")
                    {
                        GoToDir(ProfileMyComputerDirectory);
                    }
                    else
                    {
                        if (diskView.SelectedNode.Tag != null)
                        {
                            // It is a directory:

                            try
                            {
                                GoToDir(diskView.SelectedNode.Tag.ToString());
                            }
                            catch { }
                        }
                    }
                }
            } catch {
            }
        }

        void GoToDir(string dir)
        {
            mainView.Show();
            mainView.BringToFront();
            currentDirectory = dir;
            RefreshAll();
        }

        private void FolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(currentDirectory + "\\New Folder")) {
                wm.StartInfobox95("Windows Explorer", "This directory already exists", Properties.Resources.Win95Info);
            } else {
                Directory.CreateDirectory(currentDirectory + "\\New Folder");
                SaveDirectoryInfo(currentDirectory + "\\New Folder", false, "New Folder", true);
                
                RefreshAll();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool OpenFile = false;
                if (mainView.FocusedItem != null)
                {
                    if ((string)mainView.FocusedItem.Tag == "")
                    { // If it isn't a file
                        GoToDir(Path.Combine(currentDirectory, mainView.FocusedItem.Tag.ToString()));
                    }
                    else OpenFile = true; // If it is a file
                }
                else OpenFile = true;
                if (OpenFile == true)
                {
                    if (txtSave.Text == "")
                    {
                        wm.StartInfobox95("Windows Explorer", "Please enter a filename", Properties.Resources.Win95Info);
                    }
                    else
                    {
                        if (new FileInfo(Path.Combine(currentDirectory, txtSave.Text)).Extension == onlyViewExtension)
                        {

                            Program.WindowsExplorerReturnPath = Path.Combine(currentDirectory, txtSave.Text);

                        }


                        FileDialogBoxManager.IsInOpenDialog = false;
                        FileDialogBoxManager.IsInSaveDialog = false;

                        ((Form)this.TopLevelControl).Close();
                    }
                }
            } catch {

            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FileOrDirectoryExists(Path.Combine(currentDirectory, mainView.FocusedItem.Text)))
                {
                    wm.StartInfobox95("Windows Explorer", "This directory doesn't exist", Properties.Resources.Win95Info);
                }
                else
                {
                    if (Directory.Exists(Path.Combine(currentDirectory, mainView.FocusedItem.Text))) Directory.Delete(Path.Combine(currentDirectory, mainView.FocusedItem.Text), true);
                        else File.Delete(Path.Combine(currentDirectory, mainView.FocusedItem.Text));

                    RefreshAll();
                }
            } catch
            {
                RefreshAll();
            }
            
        }

        internal static bool FileOrDirectoryExists(string path)
        {
             return (Directory.Exists(path) || File.Exists(path));
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Close();
        }
        private void AboutWindows95ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager wm = new WindowManager();
            wm.StartAboutBox95("Windows 95", "Microsoft Windows 95 Rev B", Properties.Resources.WinClassicAbout95);
        }

        private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // The AfterLabelEdit event will kick in after this
                oldLabelText = mainView.FocusedItem.Text;
                mainView.LabelEdit = true;
                mainView.FocusedItem.BeginEdit();
            } catch
            {

            }
        }

        private void mainView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {

            string setText;
            setText = mainView.FocusedItem.Text;
            if (setText == "")
            {
                wm.StartInfobox95("Windows Explorer", "Please enter a new directory name", Properties.Resources.Win95Info);
            }
            else
            {
                if (Directory.Exists(setText))
                {
                    wm.StartInfobox95("Windows Explorer", "That directory already exists.", Properties.Resources.Win95Info);
                }
                else
                {
                    Directory.Delete(Path.Combine(currentDirectory, oldLabelText), true);
                    Directory.CreateDirectory(Path.Combine(currentDirectory, setText));
                }
            }
            RefreshAll();
        }

        private TreeNode[] createSubDirNodes(DirectoryInfo folder)
        {
            TreeNode[] toReturn = new TreeNode[folder.GetDirectories().Length];
            int loc = 0;
            foreach (DirectoryInfo fold in folder.GetDirectories())
            {
                if (fold.GetDirectories().Length > 0)
                {
                    string label = ReadDataFile(fold.FullName, false);
                    TreeNode[] tn = createSubDirNodes(fold);
                    toReturn[loc] = new TreeNode(label ?? fold.Name, 2, 3, tn);
                    toReturn[loc].Tag = fold.FullName;
                }
                else
                {
                    string label = ReadDataFile(fold.FullName, false);
                    toReturn[loc] = new TreeNode(label ?? fold.Name, 2, 3);
                    toReturn[loc].Tag = fold.FullName;
                }
                loc++;
            }
            return toReturn;
        }
    }
}
