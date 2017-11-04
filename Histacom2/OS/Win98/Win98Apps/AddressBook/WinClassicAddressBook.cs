﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Histacom2.Engine;
using Histacom2.Engine.Template;

namespace Histacom2.OS.Win95.Win95Apps
{
    public partial class WinClassicAddressBook : UserControl
    {
        WindowManager wm = new WindowManager();

        public List<AddressBookContactList> AddressBookObjects;
        public WinClassicAddressBook()
        {
            InitializeComponent();
            foreach (ToolStripMenuItem item in topmenu.Items)
            {
                item.Font = new Font(TitleScreen.pfc.Families[0], 16F, FontStyle.Regular, GraphicsUnit.Point, ((0)));
                item.BackColor = Color.Silver;
                item.BackgroundImage = Properties.Resources.sliversilver;
                item.BackgroundImageLayout = ImageLayout.Center;
                item.DisplayStyle = ToolStripItemDisplayStyle.Text;
            }

            //Time to prepare to load all the fonts up for the combo boxes

            //foreach (FontFamily font in System.Drawing.FontFamily.Families)
            //{
            // Added to the ComboBox here

            //comboFont.Items.Add(font.Name);
            //}

            AddressBookObjects = new List<AddressBookContactList>
            {
                new AddressBookContactList()
                {
                    AttachedNode = treeView1.Nodes[0].Text
                }
            };
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateContactListFromNodeName(treeView1.SelectedNode.Text);
        }

        //AddressBookContactList GetAddressBookContactListFromNode(string NodeText)
        //{
        //    AddressBookContactList toReturn = new AddressBookContactList();
        //    foreach (AddressBookContactList lstitem in AddressBookObjects)
        //    {
        //        if (lstitem.AttachedNode == NodeText)
        //        {
        //            toReturn = lstitem;
        //        }
        //    }
        //    if (toReturn == null)
        //    {
        //        // Something has gone wrong!
        //        MessageBox.Show("Unable to find list of items");
        //    }
        //    MessageBox.Show("Gone through process!");
        //    return toReturn;
        //}

        public void UpdateContactListFromNodeName(string NodeName)
        {
            contactsView.Items.Clear();
            try
            {
                foreach (AddressBookContactList ContactList in AddressBookObjects)
                {
                    if (ContactList.AttachedNode == NodeName)
                    {
                        foreach (AddressBookContact contact in ContactList.Contacts)
                        {
                            if (contact.FirstName != null)
                                contactsView.Items.Add(contact.FirstName + " " + contact.MiddleName + " " + contact.LastName);
                        }
                    }
                }
            } catch
            {

            }             
        }

        public void AddFolderToNode(TreeNode OldTreeNode, string NewNodeName)
        {
            if (OldTreeNode != null)
            {
                OldTreeNode.Nodes.Add(NewNodeName);

                AddressBookObjects.Add(new AddressBookContactList
                {
                    AttachedNode = NewNodeName,
                });
            }
        }

        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFolder();      
        }

        void NewFolder()
        {
            FRMWinClassicAddressBookNewFolder abnf = new FRMWinClassicAddressBookNewFolder();
            WinClassic app = wm.Init(abnf, "Address Book - New Folder", Properties.Resources.Win95IconWordpad, true, true, true);

            if (treeView1.SelectedNode != null)
            {
                if (Program.AddressBookSelectedFolderName != null)
                {
                    AddFolderToNode(treeView1.SelectedNode, Program.AddressBookSelectedFolderName);
                }
                else
                {
                    wm.StartInfobox95("Address Book - New Folder", "You must enter a folder name!", InfoboxType.Error, InfoboxButtons.OK);
                }
            }
        }

        private void newContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewContact();
        }

        void NewContact()
        {
            FRMWinClassicAddressBookNewContact abnc = new FRMWinClassicAddressBookNewContact();
            WinClassic app = wm.Init(abnc, "Address Book - New Contact", Properties.Resources.Win95IconWordpad, true, true, true);

            if (treeView1.SelectedNode != null)
            {
                if (Program.AddressBookSelectedContact != null)
                {
                    foreach (AddressBookContactList ContactList in AddressBookObjects)
                    {
                        if (ContactList.AttachedNode == treeView1.SelectedNode.Text)
                        {
                            ContactList.Contacts.Add(Program.AddressBookSelectedContact);
                            contactsView.Items.Add(Program.AddressBookSelectedContact.FirstName + " " + Program.AddressBookSelectedContact.MiddleName + " " + Program.AddressBookSelectedContact.LastName);
                        }
                    }
                }
            }
        }

        private void toolProp_Click(object sender, EventArgs e)
        {
            OpenProperties();
        }

        void OpenProperties()
        {
            FRMWinClassicAddressBookNewContact abnc = new FRMWinClassicAddressBookNewContact();

            // Finds the selected contact
            if (treeView1.SelectedNode != null)
            {
                foreach (AddressBookContactList ContactList in AddressBookObjects)
                {
                    if (ContactList.AttachedNode == treeView1.SelectedNode.Text)
                    {
                        foreach (AddressBookContact Contact in ContactList.Contacts)
                        {
                            if (contactsView.FocusedItem == null)
                            { // Most likely they are trying to view a whole folder!
                                wm.StartInfobox95("Properties of a folder", "You cannot view the properties of a contact folder.", InfoboxType.Warning, InfoboxButtons.OK);
                            }
                            else
                            {
                                if ((Contact.FirstName + " " + Contact.MiddleName + " " + Contact.LastName) == contactsView.FocusedItem.Text)
                                {
                                    abnc.toSet = Contact;
                                }
                            }
                        }
                    }
                }
                WinClassic app = wm.Init(abnc, "Address Book - Contact Properties", Properties.Resources.Win95IconWordpad, true, true, true);

                if (treeView1.SelectedNode != null)
                {
                    if (Program.AddressBookSelectedContact != null)
                    {
                        foreach (AddressBookContactList ContactList in AddressBookObjects)
                        {
                            if (ContactList.AttachedNode == treeView1.SelectedNode.Text)
                            {
                                foreach (AddressBookContact Contact in ContactList.Contacts)
                                {
                                    if ((Contact.FirstName + " " + Contact.MiddleName + " " + Contact.LastName) == contactsView.FocusedItem.Text)
                                    {
                                        ContactList.Contacts.Remove(Contact);
                                        ContactList.Contacts.Add(Program.AddressBookSelectedContact);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenProperties();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteContact();
        }

        void DeleteContact()
        {
            try
            {
                if (treeView1.SelectedNode != null)
                {
                    foreach (AddressBookContactList ContactList in AddressBookObjects)
                    {
                        if (ContactList.AttachedNode == treeView1.SelectedNode.Text)
                        {
                            foreach (AddressBookContact Contact in ContactList.Contacts)
                            {
                                if (contactsView.FocusedItem == null)
                                { // Most likely they are trying to delete a whole folder!
                                    if (treeView1.SelectedNode.Text != "Shared Contacts")
                                        if (treeView1.SelectedNode != null)
                                        {
                                            AddressBookObjects.Remove(ContactList);
                                            treeView1.Nodes.Remove(treeView1.SelectedNode);
                                            UpdateContactListFromNodeName("Shared Contacts");
                                        }
                                }
                                else
                                {
                                    if ((Contact.FirstName + " " + Contact.MiddleName + " " + Contact.LastName) == contactsView.FocusedItem.Text)
                                    {
                                        ContactList.Contacts.Remove(Contact);
                                    }
                                }
                            }
                        }
                    }
                }
            } catch { }
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            DeleteContact();
        }

        private void newContactToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NewContact();
        }

        private void newFolderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NewFolder();
        }

        private void toolbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolbar.Visible = toolbarToolStripMenuItem.Checked;
        }

        private void foldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Visible = foldersToolStripMenuItem.Checked;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Close();
        }

        private void toolNew_Click(object sender, EventArgs e)
        {
            newContext.Show(MousePosition);
        }

        private void aboutAddressBookToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void WinClassicAddressBook_Load(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).FormClosed += (sender2, e2) =>
            {
                SaveData();
            };
        }

        public void SaveData()
        {

        }

        public void SaveDataAs()
        {

        }

    }

    public class AddressBookContact
    {
        public string FirstName;
        public string MiddleName;
        public string LastName;
        public List<string> Emails = new List<string>();
    }

    public class AddressBookContactList
    {
        public string AttachedNode;
        public List<AddressBookContact> Contacts = new List<AddressBookContact>();
    }
}
