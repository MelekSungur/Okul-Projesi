﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Okul_Projesi
{
    public partial class FRMOGRETMEN : Form
    {
        public FRMOGRETMEN()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FRMKLUPLER frm = new FRMKLUPLER();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRMDERSLER frm = new FRMDERSLER();
            frm.Show();


                }

        private void FRMOGRETMEN_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FRMOGRENCI fr=new FRMOGRENCI();
            fr.Show();
        }
    }
}
