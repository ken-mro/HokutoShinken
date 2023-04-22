using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HokutoShinken
{
    public partial class Form1 : Form
    {
        private NotifyIcon notifyIcon;
        KeyboardHook keyboardHook = new KeyboardHook();
        private Shout shout = new Shout();

        public Form1()
        {
            this.ShowInTaskbar = false;
            this.setComponents();
            shout.InitialShout(); 
        }

        private void setComponents()
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Properties.Resources.Hokuto;
            notifyIcon.Visible = true;
            notifyIcon.Text = "HokutoShinken";

            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem closeMenu = new ToolStripMenuItem();
            closeMenu.Text = "&Decline the inheritance";
            closeMenu.Click += ToolStripMenuItem_Click;
            contextMenuStrip.Items.Add(closeMenu);

            ToolStripMenuItem shoutCatchPhrase = new ToolStripMenuItem();
            shoutCatchPhrase.Text = "Listen to the catch phrase!";
            shoutCatchPhrase.Click += InitialShout_Click;
            contextMenuStrip.Items.Add(shoutCatchPhrase);

            notifyIcon.ContextMenuStrip = contextMenuStrip;

            keyboardHook.KeyDownEvent += KeyboardHook_KeyDownEvent;
            //keyboardHook.KeyUpEvent += KeyboardHook_KeyUpEvent;
            keyboardHook.Hock();

            notifyIcon.BalloonTipTitle = "Now you are the legitimate successor of Hokuto Shinken!";
            notifyIcon.BalloonTipText = "Decline the inheritance? Right click on the icon in the Task Tray.";
            notifyIcon.ShowBalloonTip(5000);
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            keyboardHook.UnHook();
            Application.Exit();
        }

        private void InitialShout_Click(object sender, EventArgs e)
        {
            shout.InitialShout();
        }

        private void KeyboardHook_KeyDownEvent(object sender, KeyEventArgs e)
        {
            var key = e.KeyCode;
            shout.Shouting(key);
        }

        //private void KeyboardHook_KeyUpEvent(object sender, KeyEventArgs e)
        //{

        //}

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
