using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;


namespace DXSample {
    public partial class Main: XtraForm {
        public Main() {
            InitializeComponent();
        }
        public void InitData() {
            for(int i = 0;i < 5;i++) {
                dataSet11.Tables[0].Rows.Add(new object[] { i, string.Format("FirstName {0}", i), i});
            }
        }
        ColumnHeaderExtender extender;
        private void OnFormLoad(object sender, EventArgs e) {
            InitData();
            extender = new ColumnHeaderExtender(gridView1);
            extender.AddCustomButton();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e) {
            extender.RemoveCustomButton();
        }

    }
}
