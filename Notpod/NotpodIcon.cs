﻿/*
 * Created by SharpDevelop.
 * User: Jaran
 * Date: 25.12.2011
 * Time: 10:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Notpod
{
    public sealed class NotpodIcon
    {
        private NotifyIcon notifyIcon;
        private ContextMenu notificationMenu;
        
        #region Initialize icon and menu
        public NotpodIcon()
        {
            notifyIcon = new NotifyIcon();
            notificationMenu = new ContextMenu(InitializeMenu());
            
            notifyIcon.DoubleClick += IconDoubleClick;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotpodIcon));
            
            notifyIcon.Icon = (Icon)resources.GetObject("notpod-icon");
            notifyIcon.ContextMenu = notificationMenu;
        }
        
        private MenuItem[] InitializeMenu()
        {
            MenuItem[] menu = new MenuItem[] {
                new MenuItem("About", menuAboutClick),
                new MenuItem("Exit", menuExitClick)
            };
            return menu;
        }
        #endregion
        
        #region Main - Program entry point
        /// <summary>Program entry point.</summary>
        /// <param name="args">Command Line Arguments</param>
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            bool isFirstInstance;
            // Please use a unique name for the mutex to prevent conflicts with other programs
            using (Mutex mtx = new Mutex(true, "Notpod", out isFirstInstance)) {
                if (isFirstInstance) {
                    NotpodIcon applicationInstance = new NotpodIcon();
                    applicationInstance.notifyIcon.Visible = true;
                    Application.Run();
                    applicationInstance.notifyIcon.Dispose();
                } else {
                    // The application is already running
                    MessageBox.Show("Notpod is already running in your system tray. Look for it's icon there and right-click it to get started.","Notpod",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } // releases the Mutex
        }
        #endregion
        
        #region Event Handlers
        private void menuAboutClick(object sender, EventArgs e)
        {
            MessageBox.Show("About This Application");
        }
        
        private void menuExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void IconDoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("The icon was double clicked");
        }
        #endregion
    }
}
