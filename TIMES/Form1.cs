﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// 跑马灯示例
/// </summary>
namespace TIMES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void liable(object sender, EventArgs e)
        {
            label1.Text = label1.Text.Substring(1) + label1.Text.Substring(0, 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
