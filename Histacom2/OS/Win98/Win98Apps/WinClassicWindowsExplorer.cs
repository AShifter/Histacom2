﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Histacom2.Engine.SaveSystem;
using System.IO;
using Histacom2.Engine;
using Newtonsoft.Json;
using System.Diagnostics;
using Histacom2.Engine.Template;
using Histacom2.OS.Win98.Win98Apps;
using Histacom2.GlobalPrograms;

namespace Histacom2.OS.Win95.Win95Apps
{
    public partial class WinClassicWindowsExplorer : UserControl
    {
        public bool IsFileOpenDialog = false;
        public bool IsFileSaveDialog = false;
        public string onlyViewExtension = "";

        string ToReplaceWith = ProfileDirectory;
        public string CurrentDirectory = ProfileMyComputerDirectory;
        string OldLabelText;
        string CurrentCopyFile;
        int fileType = 6;
        //string attemptedDirectory = "";
        WindowManager wm = new WindowManager();

        public WinClassicWindowsExplorer()
        {
            InitializeComponent();
        }

        void WinClassicWindowsExplorer_Load(object sender, EventArgs e)
        {
            if (SaveSystem.CurrentSave.CurrentOS == "2000")
            {
                pnlInfo.Width = 200;
                txtInfoTitle.Font = new Font(TitleScreen.pfc.Families[0], 16F, FontStyle.Regular, GraphicsUnit.Point, ((0)));
            }

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

            mainView.LargeImageList = new ImageList();
            mainView.LargeImageList.ImageSize = new Size(32, 32);

            mainView.LargeImageList.Images.AddRange(new Bitmap[] { Properties.Resources.Win95Computer, // 0
                                                    Properties.Resources.WinClassicFolder,
                                                    Properties.Resources.WinClassicIE4,
                                                    Properties.Resources.WinClassicInbox,
                                                    Properties.Resources.WinClassicMSN,
                                                    Properties.Resources.WinClassicNetworking, // 5
                                                    Properties.Resources.WinClassicOutlook,
                                                    Properties.Resources.WinClassicRecycle,
                                                    Properties.Resources.Win95File,
                                                    Properties.Resources.WinClassicFolder,
                                                    Properties.Resources.WinClassicApp, // 10
                                                    Properties.Resources.WinClassicSetup,
                                                    Properties.Resources.WinClassicNotepad,
                                                    Properties.Resources.WinClassicCalcBig,
                                                    Properties.Resources.WinClassicNotepadBig,
                                                    Properties.Resources.WinClassicRegedit, // 15
                                                    Properties.Resources.WinClassicWordpad,
                                                    Properties.Resources.WinClassicRtfFile});

            program.BringToFront();


            //diskView.Items.Add("My Computer", 0);
            Application.DoEvents();

            RefreshAll();
            RefreshTreeNode();

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
                if (toRead.IsProtected == true)
                {
                    return "yes";
                }
            }
            else
            {
                return toRead.Label;
            }
            return Val;
        }

        void RefreshAll() {
            //try {
            this.mainView.Items.Clear();

            foreach (string str in Directory.GetDirectories(CurrentDirectory))
            {
                string label = ReadDataFile(str, false);
                ListViewItem itm = this.mainView.Items.Add(label ?? Path.GetFileName(str));
                itm.ImageIndex = 1;
                itm.Tag = str;
            }
            foreach (string str in Directory.GetFiles(CurrentDirectory))
            {
                ListViewItem itm;

                if (IsFileOpenDialog || IsFileSaveDialog)
                {
                    if (!(Path.GetFileName(str) == "_data.info"))
                    {
                        if (new FileInfo(str).Extension == onlyViewExtension)
                        {
                            itm = this.mainView.Items.Add(Path.GetFileName(str));
                            itm.Tag = str;
                        }
                        else break;
                    }
                    else break;
                }
                else
                {
                    if (!(Path.GetFileName(str) == "_data.info"))
                    {
                        itm = this.mainView.Items.Add(Path.GetFileName(str));
                        itm.Tag = str;
                    }
                    else break;
                }
                FileSystemFolderInfo fsfi = JsonConvert.DeserializeObject<FileSystemFolderInfo>(File.ReadAllText(Path.Combine(CurrentDirectory, "_data.info")));
                foreach (var item in fsfi.Files)
                {
                    Debug.Print(item.Name + " " + Path.GetFileName(str));
                    if (item.Name == Path.GetFileName(str)) { itm.ImageIndex = item.FileIcon; break; }
                }
            }
            /*
        } catch (Exception ex) {
            //wm.StartInfobox95("Exploring - C:", "Error with the file explorer \n" + ex.Message, Properties.Resources.Win95Info); add illegal operation dialog here later
            ((Form)this.TopLevelControl).Close();
        }*/
        }

        void RefreshTreeNode()
        {
            // Refresh the TreeView

            diskView.Nodes.Clear();

            int loc = 0;
            TreeNode[] folders = new TreeNode[new DirectoryInfo(ProfileMyComputerDirectory).GetDirectories().Length];
            foreach (DirectoryInfo folder in new DirectoryInfo(ProfileMyComputerDirectory).GetDirectories())
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
        }

        public void OpenFile(string fileDir)
        {
            try
            {
                ReturnType(new FileInfo(fileDir).Extension);
                switch (fileType)
                {
                    case 1:
                        WinClassicNotepad np = new WinClassicNotepad();
                        np.mainText.Text = FileDialogBoxManager.ReadTextFile(fileDir);
                        np.CurrentFilePath = fileDir;
                        WinClassic app = wm.Init(np, "Notepad", Properties.Resources.Win95IconNotepad, true, true);

                        Program.AddTaskbarItem(app, app.Tag.ToString(), "Notepad", Properties.Resources.Win95IconNotepad);
                        break;
                    case 2:
                        WinClassicWordPad wp = new WinClassicWordPad();
                        wp.mainText.LoadFile(fileDir);
                        wp.CurrentFilePath = fileDir;
                        WinClassic app2 = wm.Init(wp, "Wordpad", Properties.Resources.Win95IconWordpad, true, true);

                        Program.AddTaskbarItem(app2, app2.Tag.ToString(), "Wordpad", Properties.Resources.Win95IconWordpad);
                        break;
                    case 12:
                        OpenApplication(FileDialogBoxManager.ReadTextFile(fileDir), fileDir);
                        break;
                }
            }
            catch
            {
            }

        }

        void OpenApplication(string appname, string path)
        {
            switch (appname.ToLower())
            {
                case "explorer":
                    WinClassic app = wm.Init(new Win95WindowsExplorer(), "Windows Explorer", Properties.Resources.WinClassicFileExplorer, true, true);
                    Program.AddTaskbarItem(app, app.Tag.ToString(), "Windows Explorer", Properties.Resources.WinClassicFileExplorer);
                    break;
                case "calc":
                    WinClassic appCalc = wm.Init(new WinClassicCalculator(), "Calculator", Properties.Resources.WinClassicCalc, true, true);
                    Program.AddTaskbarItem(appCalc, appCalc.Tag.ToString(), "Calculator", Properties.Resources.WinClassicCalc);

                    Program.nonimportantapps.Add(appCalc);
                    Program.nonimportantapps[Program.nonimportantapps.Count - 1].BringToFront();
                    Program.nonimportantapps[Program.nonimportantapps.Count - 1].FormClosing += new FormClosingEventHandler(Program.NonImportantApp_Closing);

                    break;
                case "notepad":
                    WinClassic appNP = wm.Init(new WinClassicNotepad(), "Notepad", Properties.Resources.Win95IconNotepad_2, true, true);
                    Program.AddTaskbarItem(appNP, appNP.Tag.ToString(), "Notepad", Properties.Resources.Win95IconNotepad_2);

                    Program.nonimportantapps.Add(appNP);
                    Program.nonimportantapps[Program.nonimportantapps.Count - 1].BringToFront();
                    Program.nonimportantapps[Program.nonimportantapps.Count - 1].FormClosing += new FormClosingEventHandler(Program.NonImportantApp_Closing);

                    break;
                case "wordpad":
                    WinClassic appWP = wm.Init(new WinClassicWordPad(), "Wordpad", Properties.Resources.Win95WordpadIcon2, true, true);
                    Program.AddTaskbarItem(appWP, appWP.Tag.ToString(), "Wordpad", Properties.Resources.Win95WordpadIcon2);

                    Program.nonimportantapps.Add(appWP);
                    Program.nonimportantapps[Program.nonimportantapps.Count - 1].BringToFront();
                    Program.nonimportantapps[Program.nonimportantapps.Count - 1].FormClosing += new FormClosingEventHandler(Program.NonImportantApp_Closing);

                    break;
                case "ie":
                    if (TitleScreen.frm95.ie != null) { wm.StartInfobox95("Error Opening Internet Explorer", "An instance of Internet Explorer 4 is already open.", InfoboxType.Warning, InfoboxButtons.OK); return; }
                    TitleScreen.frm95.ie = wm.Init(new WinClassicIE4(), "Internet Explorer 4", Properties.Resources.Win95IconIE4, true, true);
                    Program.AddTaskbarItem(TitleScreen.frm95.ie, TitleScreen.frm95.ie.Tag.ToString(), "Internet Explorer 4", Properties.Resources.Win95IconIE4);
                    TitleScreen.frm95.ie.BringToFront();
                    TitleScreen.frm95.ie.FormClosing += new FormClosingEventHandler(TitleScreen.frm95.InternetExplorer4_Closing);

                    break;
                case "web chat 99 setup":
                    Win95Installer inst = new Win95Installer("Web Chat 1999");
                    inst.InstallCompleted += (sendr, args) => TitleScreen.frm95.WebChatToolStripMenuItem.Visible = true;
                    WinClassic appInstaller = wm.Init(inst, "Web Chat Setup", null, true, true);
                    Program.AddTaskbarItem(appInstaller, appInstaller.Tag.ToString(), "Web Chat Setup", null);
                    appInstaller.BringToFront();

                    break;
                case "time distorter setup":
                    Win95Installer instTd = new Win95Installer("Time Distorter 0.2");
                    instTd.InstallCompleted += (sendr, args) =>
                    {
                        TitleScreen.frm95.TimeDistorterToolStripMenuItem.Visible = true;
                    };
                    WinClassic appTd = wm.Init(instTd, "Time Distorter Setup", null, true, true);
                    Program.AddTaskbarItem(appTd, appTd.Tag.ToString(), "Time Distorter Setup", null);
                    appTd.BringToFront();

                    break;
                case "iebrokeninstaller":
                    wm.StartInfobox95("Internet Explorer Installer", "Installation Failed: The INF file was not found", InfoboxType.Error, InfoboxButtons.OK);

                    break;
                default:
                    wm.StartInfobox95(path.Replace(ProfileMyComputerDirectory, "C:"), $"{path.Replace(ProfileMyComputerDirectory, "C:")} is not a valid Win32 application.", InfoboxType.Error, InfoboxButtons.OK);
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

        void mainView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(Path.Combine(CurrentDirectory, mainView.FocusedItem.Text)))
                { // If it isn't a file
                    if (mainView.FocusedItem.Text == "C:")
                        GoToDir(Path.Combine(CurrentDirectory, "CDrive"));
                    else
                        GoToDir(Path.Combine(CurrentDirectory, mainView.FocusedItem.Text));
                }
                else
                { // If it is a file
                    if (IsFileOpenDialog == true || IsFileSaveDialog == true)
                    {
                        if (new FileInfo(Path.Combine(CurrentDirectory, txtSave.Text)).Extension == onlyViewExtension)
                        {
                            Program.WindowsExplorerReturnPath = Path.Combine(CurrentDirectory, txtSave.Text);
                        }


                        FileDialogBoxManager.IsInOpenDialog = false;
                        FileDialogBoxManager.IsInSaveDialog = false;

                        ((Form)this.TopLevelControl).Close();
                    }
                    else
                    {
                        OpenFile(mainView.FocusedItem.Tag.ToString());
                    }
                }
            } catch { /* TODO: Illegal operation */ }
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
            CurrentDirectory = dir;
            RefreshAll();
        }

        private void FolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(CurrentDirectory + "\\New Folder")) {
                wm.StartInfobox95("Windows Explorer", "This directory already exists", InfoboxType.Info, InfoboxButtons.OK);
            } else {
                Directory.CreateDirectory(Path.Combine(CurrentDirectory, "New Folder"));
                SaveDirectoryInfo(CurrentDirectory, "New Folder", false, "New Folder", true);
                
                RefreshAll();
            }

            RefreshTreeNode();
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
                        GoToDir(Path.Combine(CurrentDirectory, mainView.FocusedItem.Tag.ToString()));
                    }
                    else OpenFile = true; // If it is a file
                }
                else OpenFile = true;
                if (OpenFile == true)
                {
                    if (txtSave.Text == "")
                    {
                        wm.StartInfobox95("Windows Explorer", "Please enter a filename", InfoboxType.Info, InfoboxButtons.OK);
                    }
                    else
                    {
                        if (new FileInfo(Path.Combine(CurrentDirectory, txtSave.Text)).Extension == onlyViewExtension)
                        {

                            Program.WindowsExplorerReturnPath = Path.Combine(CurrentDirectory, txtSave.Text);

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
                if (!FileOrDirectoryExists(Path.Combine(CurrentDirectory, mainView.FocusedItem.Text)))
                {
                    wm.StartInfobox95("Windows Explorer", "This directory doesn't exist", InfoboxType.Info, InfoboxButtons.OK);
                }
                else
                {
                    if (Directory.Exists(Path.Combine(CurrentDirectory, mainView.FocusedItem.Text)))
                    {
                        Directory.Delete(Path.Combine(CurrentDirectory, mainView.FocusedItem.Text), true);

                        // Remove the directory now from the _data.info

                        SaveSystem.RemoveSubDirFromDirectory(CurrentDirectory, mainView.FocusedItem.Text);
                    }
                    else
                    {
                        File.Delete(Path.Combine(CurrentDirectory, mainView.FocusedItem.Text));

                        // Remove the file now from the _data.info

                        RemoveFileFromDirectory(CurrentDirectory, mainView.FocusedItem.Text);

                    }

                    RefreshAll();
                    RefreshTreeNode();
                }
            }
            catch
            {
                RefreshAll();
            }

            RefreshTreeNode();
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
            wm.StartAboutBox95("Windows 98", "Microsoft Windows 98", Properties.Resources.WinClassicAbout95);
        }

        private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // The AfterLabelEdit event will kick in after this
                OldLabelText = mainView.FocusedItem.Text;
                mainView.LabelEdit = true;
                mainView.FocusedItem.BeginEdit();
            } catch
            {

            }
        }

        private void mainView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            try
            {
                string setText = e.Label;
                if (setText == "") wm.StartInfobox95("Rename", "You must type a filename.", InfoboxType.Error, InfoboxButtons.OK);
                else
                {
                    if (Directory.Exists(setText)) wm.StartInfobox95("Error Renaming File", $"Cannot rename {new DirectoryInfo(setText).Name}: A file with the name you specified already exists. Specify a different filename.", InfoboxType.Error, InfoboxButtons.OK);
                    else
                    {
                        if (File.Exists(setText)) wm.StartInfobox95("Error Renaming File", $"Cannot rename {new FileInfo(setText).Name}: A file with the name you specified already exists. Specify a different filename.", InfoboxType.Error, InfoboxButtons.OK);
                        else
                        {
                            if (Directory.Exists(Path.Combine(CurrentDirectory, OldLabelText)))
                            {
                                // It was a directory

                                Directory.Move(Path.Combine(CurrentDirectory, OldLabelText), Path.Combine(CurrentDirectory, setText));

                                File.Delete(Path.Combine(CurrentDirectory, setText, "_data.info"));
                                SaveDirectoryInfo(CurrentDirectory, setText, false, setText, true, true);

                                // Rename the directory now in the _data.info

                                RenameDirectory(CurrentDirectory, OldLabelText, setText);
                            }
                            else
                            {
                                // It was a file                    

                                File.Copy(Path.Combine(CurrentDirectory, OldLabelText), Path.Combine(CurrentDirectory, setText));
                                File.Delete(Path.Combine(CurrentDirectory, OldLabelText));

                                // Rename the file now in the _data.info

                                RenameFile(CurrentDirectory, OldLabelText, setText);
                            }
                        }
                    }
                }
                RefreshAll();
                RefreshTreeNode();
            }
            catch { }
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

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            btnFolderClose.Image = Properties.Resources.XCross_highlighted;
        }

        private void btnFolderClose_MouseLeave(object sender, EventArgs e)
        {
            btnFolderClose.Image = Properties.Resources.XCross;
        }

        private void btnFolderClose_Click(object sender, EventArgs e)
        {
            FoldersToolStripMenuItem.Checked = false;
            pnlFolders.Hide();
        }

        private void FoldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FoldersToolStripMenuItem.Checked == true)
            {
                FoldersToolStripMenuItem.Checked = false;
                pnlFolders.Hide();
            } else {
                FoldersToolStripMenuItem.Checked = true;
                pnlFolders.Show();
            }
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void mainView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // This will change the web view!

            if (mainView.FocusedItem == null)
            {
                txtInfoTip.Show();
                InfoDesc.Hide();
            } else {
                txtInfoTip.Hide();

                if (File.Exists(Path.Combine(CurrentDirectory, mainView.FocusedItem.Text)))
                {
                    // Check if it is a regonized file - if so then in Windows 2000/ME it gives a fancy description

                    bool recognized = false;
                    string description = "";

                    if (SaveSystem.CurrentSave.CurrentOS == "2000" || SaveSystem.CurrentSave.CurrentOS == "ME")
                    {
                        switch (File.ReadAllText(Path.Combine(CurrentDirectory, mainView.FocusedItem.Text)))
                        {
                            case "explorer":
                                recognized = true;
                                description = "Insert a description here...";
                                break;
                        }
                    }

                    if (recognized == true)
                    {
                        // TODO:
                    } else {
                        InfoDesc.Show();

                        FileInfo fi = new FileInfo(Path.Combine(CurrentDirectory, mainView.FocusedItem.Text));
                        txtInfoDescName.Text = mainView.FocusedItem.Text;
                        txtInfoDescType.Text = ReturnType(fi.Extension).Split('\n')[0];
                        txtInfoDescModified.Text = fi.CreationTime.ToString();

                        txtInfoDescSize.Show();
                        txtInfoDescSize.Text = $"Size: {fi.Length} bytes.";
                    }

                } else if (Directory.Exists(Path.Combine(CurrentDirectory, mainView.FocusedItem.Text))) {
                    txtInfoTip.Hide();
                    InfoDesc.Show();

                    DirectoryInfo fi = new DirectoryInfo(Path.Combine(CurrentDirectory, mainView.FocusedItem.Text));

                    txtInfoDescName.Text = mainView.FocusedItem.Text;
                    txtInfoDescType.Text = "File Folder";
                    txtInfoDescModified.Text = fi.CreationTime.ToString();

                    txtInfoDescSize.Hide();
                }
            }
        }

        private void CutCtrlXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mainView.FocusedItem != null && mainView.FocusedItem.ImageKey != "")
                {

                    // It is a directory
                    string oldLocation;
                    oldLocation = mainView.FocusedItem.ImageKey;

                    CurrentCopyFile = Path.Combine(GameDirectory, "Data", Path.GetFileName(mainView.FocusedItem.ImageKey));

                    if (Directory.Exists(CurrentCopyFile)) Directory.Delete(CurrentCopyFile);
                    if (File.Exists(CurrentCopyFile)) File.Delete(CurrentCopyFile);

                    Directory.Move(mainView.FocusedItem.ImageKey, Path.Combine(GameDirectory, "Data", Path.GetDirectoryName(mainView.FocusedItem.ImageKey)));

                    
                    DirectoryCopy(CurrentCopyFile, oldLocation, true);
                }
                else if (mainView.FocusedItem != null)
                {
                    // It is a file

                    CurrentCopyFile = Path.Combine(GameDirectory, "Data", Path.GetFileName(mainView.FocusedItem.Tag.ToString()));

                    if (Directory.Exists(CurrentCopyFile)) Directory.Delete(CurrentCopyFile);
                    if (File.Exists(CurrentCopyFile)) File.Delete(CurrentCopyFile);

                    File.Move(mainView.FocusedItem.Tag.ToString(), Path.Combine(GameDirectory, "Data", Path.GetFileName(mainView.FocusedItem.Tag.ToString())));

                    
                }
                RefreshAll();
            } catch {
            }           
        }

        private void CopyCtrlCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mainView.FocusedItem != null && mainView.FocusedItem.ImageKey != "")
                {
                    // It is a directory
                    string oldLocation;
                    oldLocation = mainView.FocusedItem.ImageKey;
                    CurrentCopyFile = Path.Combine(GameDirectory, "Data", Path.GetFileName(mainView.FocusedItem.ImageKey));

                    if (Directory.Exists(CurrentCopyFile)) Directory.Delete(CurrentCopyFile);
                    if (File.Exists(CurrentCopyFile)) File.Delete(CurrentCopyFile);

                    DirectoryCopy(CurrentCopyFile, oldLocation, true);
                }
                else if (mainView.FocusedItem != null)
                {
                    // It is a file

                    CurrentCopyFile = Path.Combine(GameDirectory, "Data", Path.GetFileName(mainView.FocusedItem.Tag.ToString()));

                    if (Directory.Exists(CurrentCopyFile)) Directory.Delete(CurrentCopyFile);
                    if (File.Exists(CurrentCopyFile)) File.Delete(CurrentCopyFile);

                    File.Copy(mainView.FocusedItem.Tag.ToString(), Path.Combine(GameDirectory, "Data", Path.GetFileName(mainView.FocusedItem.Tag.ToString())));


                }
                RefreshAll();
            } catch {
            }
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(CurrentCopyFile))
            {
                // It is a directory

                DirectoryCopy(CurrentCopyFile, CurrentDirectory, true);
            } else if (File.Exists(CurrentCopyFile)) {
                // It is a file

                File.Copy(CurrentCopyFile, Path.Combine(CurrentDirectory, Path.GetFileName(CurrentCopyFile)));
            }
            RefreshAll();
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (dir.Exists)
            {
                DirectoryInfo[] dirs = dir.GetDirectories();
                // If the destination directory doesn't exist, create it.
                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                }

                // Get the files in the directory and copy them to the new location.
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string temppath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(temppath, false);
                }

                // If copying subdirectories, copy them and their contents to new location.
                if (copySubDirs)
                {
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        string temppath = Path.Combine(destDirName, subdir.Name);
                        DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                    }
                }
            }            
        }

        private void refresh_Tick(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void SellectAllCtrlAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in mainView.Items)
            {
                item.Selected = true;
            }
        }
    }
}
