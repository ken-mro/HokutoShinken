﻿using System;
using System.Windows.Forms;

namespace HokutoShinken
{
    public partial class Form1 : Form
    {
        private NotifyIcon notifyIcon;
        KeyboardHook keyboardHook = new KeyboardHook();
        private Shout shout = new Shout();
        private bool _canUse = false;
        private ToolStripMenuItem _canUseMenu;

        public Form1()
        {
            this.ShowInTaskbar = false;
            this.setComponents();
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

            _canUseMenu = new ToolStripMenuItem();
            _canUseMenu.Text = "Start";
            _canUseMenu.Click += CanUse_Click;
            contextMenuStrip.Items.Add(_canUseMenu);

            notifyIcon.ContextMenuStrip = contextMenuStrip;

            keyboardHook.KeyDownEvent += KeyboardHook_KeyDownEvent;
            keyboardHook.Hock();

            notifyIcon.BalloonTipTitle = "Now you are the legitimate successor of Hokuto Shinken!";
            notifyIcon.BalloonTipText = "Decline the inheritance? Right click on the icon in the Task Tray.";
            notifyIcon.ShowBalloonTip(5000);
        }

        private void CanUse_Click(object sender, EventArgs e)
        {
            _canUse = !_canUse;
            _canUseMenu.Text = _canUse ? "Stop" : "Start";
        }
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            keyboardHook.UnHook();
            Application.Exit();
        }

        private void KeyboardHook_KeyDownEvent(object sender, KeyEventArgs e)
        {
            if (!_canUse) return;
                var key = e.KeyCode;
            shout.Shouting(key);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
