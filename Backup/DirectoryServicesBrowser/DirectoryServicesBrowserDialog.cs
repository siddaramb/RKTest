using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DirectoryServicesBrowser
{
    public partial class DirectoryServicesBrowserDialog : Form
    {
        #region "fields"
        private string connectionPrefix;
        private string objectName;
        private string objectPath;
        private string objectGUID;
        private string userName;
        private string password;
        #endregion

        #region "properties"
        public string ObjectName
        {
            get { return objectName; }
        }
        public string ObjectPath
        {
            get { return objectPath; }
        }
        public string ObjectGUID
        {
            get { return objectGUID; }
        }
        #endregion
       

        public DirectoryServicesBrowserDialog(string userName, 
                                              string password)
        {
            InitializeComponent();
            this.userName = userName;
            this.password = password;
            connectionPrefix = "LDAP://";
        }

        #region "Active Directory Methods - Demonstration"
        private void populateChildren(TreeNode oParent)
        {
            foreach (string child in EnumerateOU(oParent.Text))
            {
                TreeNode oNode = new TreeNode();
                oNode.Text = child;
                oNode.SelectedImageIndex = 1;
                oParent.Nodes.Add(oNode);
            }
        }
        private void populateObjectDetails(string objectLdapPath)
        {
            DirectoryEntry directoryObject = new DirectoryEntry(connectionPrefix +
                                                                objectLdapPath,
                                                                userName,
                                                                password);
            objectName = directoryObject.Name;
            objectPath = directoryObject.Path;
            objectGUID = directoryObject.Guid.ToString();
        }

        private ArrayList EnumerateOU(string OuDn)
        {
            ArrayList alObjects = new ArrayList();
            try
            {
                DirectoryEntry directoryObject = new DirectoryEntry(connectionPrefix + OuDn,
                                                                     userName,
                                                                     password);
                foreach (DirectoryEntry child in directoryObject.Children)
                {
                    string childPath = child.Path.ToString();
                    alObjects.Add(childPath.Remove(0, 7)); //remove the LDAP prefix from the path
                    child.Close();
                    child.Dispose();
                }
                directoryObject.Close();
                directoryObject.Dispose();
            }
            catch (DirectoryServicesCOMException e)
            {
                Console.WriteLine("An Error Occurred: " + e.Message.ToString());
            }
            return alObjects;
        }
        private ArrayList EnumerateDomains()
        {
            ArrayList alDomains = new ArrayList();
            Forest currentForest = Forest.GetCurrentForest();
            DomainCollection myDomains = currentForest.Domains;

            foreach (Domain objDomain in myDomains)
            {
                alDomains.Add(objDomain.Name);
            }
            return alDomains;
        }
        #endregion
      
        #region "events"
        private void DirectoryServicesBrowserDialog_Load(object sender, EventArgs e)
        {
            TreeNode oNode = new TreeNode();
            oNode.SelectedImageIndex = 0;
            foreach (string domain in EnumerateDomains())
            {
                treeView1.Nodes.Add(domain);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            populateChildren(e.Node);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            populateObjectDetails(treeView1.SelectedNode.Text.ToString());
            this.Close();
        }
        #endregion
        

    }
}