using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WalletComponents
{

    public class TransactionPanel : Panel
    {
        private Panel panel32;
        private Button button19;
        private Label label25;
        private SPanel sPanel11;
        private Label label26;

        public TransactionPanel()
        {
            this.panel32 = new System.Windows.Forms.Panel();
            this.button19 = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.sPanel11 = new WalletComponents.SPanel();
            this.label26 = new System.Windows.Forms.Label();
            SuspendLayout();
            this.panel32.SuspendLayout();
            this.sPanel11.SuspendLayout();
            this.SuspendLayout();

            // 
            // panel32
            // 
            this.panel32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel32.Controls.Add(this.button19);
            this.panel32.Location = new System.Drawing.Point(540, 0);
            this.panel32.Name = "panel32";
            this.panel32.Padding = new System.Windows.Forms.Padding(0, 8, 0, 15);
            this.panel32.Size = new System.Drawing.Size(207, 61);
            this.panel32.TabIndex = 4;
            // 
            // button19
            // 
            this.button19.FlatAppearance.BorderSize = 0;
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button19.ForeColor = System.Drawing.Color.Yellow;
            this.button19.Location = new System.Drawing.Point(0, 8);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(200, 38);
            this.button19.TabIndex = 4;
            this.button19.Text = "View On BlockChain";
            this.button19.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(204, 22);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(75, 13);
            this.label25.TabIndex = 3;
            this.label25.Text = "20th Jan 2018";
            // 
            // sPanel11
            // 
            this.sPanel11.Controls.Add(this.label26);
            this.sPanel11.Location = new System.Drawing.Point(0, 0);
            this.sPanel11.Name = "sPanel11";
            this.sPanel11.Size = new System.Drawing.Size(206, 64);
            this.sPanel11.TabIndex = 2;
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(57, 21);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(87, 13);
            this.label26.TabIndex = 0;
            this.label26.Text = "Test Transaction";
           
            this.panel32.ResumeLayout(false);
            this.sPanel11.ResumeLayout(false);
            this.sPanel11.PerformLayout();
            // 
            // panel31
            // 
            Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            AutoSize = true;
            Controls.Add(this.panel32);
            Controls.Add(this.label25);
            Controls.Add(this.sPanel11);
            Location = new System.Drawing.Point(3, 168);
            MinimumSize = new System.Drawing.Size(400, 3);
            Name = "panel31";
            Size = new System.Drawing.Size(747, 49);
            TabIndex = 4;

            ResumeLayout(false);
            PerformLayout();
        }

        private void InitializeComponent()
        {
           
        }
    }
}
