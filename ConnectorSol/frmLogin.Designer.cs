
namespace ConnectorSol
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnJsonToSql = new System.Windows.Forms.Button();
            this.txtJsonFilePath = new System.Windows.Forms.TextBox();
            this.btnConvertJsonToSQL = new System.Windows.Forms.Button();
            this.btnConvertXmlToSql = new System.Windows.Forms.Button();
            this.txtXmlFilePath = new System.Windows.Forms.TextBox();
            this.btnXmlToSql = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseJsonOrXmlFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBaseUrl = new System.Windows.Forms.TextBox();
            this.txtAPIKey = new System.Windows.Forms.TextBox();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.txtSecretKey = new System.Windows.Forms.TextBox();
            this.btnViewQuery = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnJsonToSql
            // 
            this.btnJsonToSql.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJsonToSql.Location = new System.Drawing.Point(445, 446);
            this.btnJsonToSql.Name = "btnJsonToSql";
            this.btnJsonToSql.Size = new System.Drawing.Size(237, 26);
            this.btnJsonToSql.TabIndex = 8;
            this.btnJsonToSql.Text = "Browse Json Credential\'s File";
            this.btnJsonToSql.UseVisualStyleBackColor = true;
            this.btnJsonToSql.Click += new System.EventHandler(this.btnJsonToSql_Click);
            // 
            // txtJsonFilePath
            // 
            this.txtJsonFilePath.Location = new System.Drawing.Point(109, 446);
            this.txtJsonFilePath.Name = "txtJsonFilePath";
            this.txtJsonFilePath.Size = new System.Drawing.Size(330, 22);
            this.txtJsonFilePath.TabIndex = 9;
            // 
            // btnConvertJsonToSQL
            // 
            this.btnConvertJsonToSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvertJsonToSQL.Location = new System.Drawing.Point(684, 446);
            this.btnConvertJsonToSQL.Margin = new System.Windows.Forms.Padding(4);
            this.btnConvertJsonToSQL.Name = "btnConvertJsonToSQL";
            this.btnConvertJsonToSQL.Size = new System.Drawing.Size(153, 28);
            this.btnConvertJsonToSQL.TabIndex = 10;
            this.btnConvertJsonToSQL.Text = "Json To SQL";
            this.btnConvertJsonToSQL.UseVisualStyleBackColor = true;
            this.btnConvertJsonToSQL.Click += new System.EventHandler(this.btnConvertToSQL_Click);
            // 
            // btnConvertXmlToSql
            // 
            this.btnConvertXmlToSql.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvertXmlToSql.Location = new System.Drawing.Point(684, 475);
            this.btnConvertXmlToSql.Margin = new System.Windows.Forms.Padding(4);
            this.btnConvertXmlToSql.Name = "btnConvertXmlToSql";
            this.btnConvertXmlToSql.Size = new System.Drawing.Size(153, 28);
            this.btnConvertXmlToSql.TabIndex = 14;
            this.btnConvertXmlToSql.Text = "Xml To SQL";
            this.btnConvertXmlToSql.UseVisualStyleBackColor = true;
            this.btnConvertXmlToSql.Click += new System.EventHandler(this.btnConvertXmlToSql_Click);
            // 
            // txtXmlFilePath
            // 
            this.txtXmlFilePath.Location = new System.Drawing.Point(109, 479);
            this.txtXmlFilePath.Name = "txtXmlFilePath";
            this.txtXmlFilePath.Size = new System.Drawing.Size(330, 22);
            this.txtXmlFilePath.TabIndex = 13;
            // 
            // btnXmlToSql
            // 
            this.btnXmlToSql.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXmlToSql.Location = new System.Drawing.Point(445, 477);
            this.btnXmlToSql.Name = "btnXmlToSql";
            this.btnXmlToSql.Size = new System.Drawing.Size(237, 26);
            this.btnXmlToSql.TabIndex = 12;
            this.btnXmlToSql.Text = "Browse Xml Credential\'s File";
            this.btnXmlToSql.UseVisualStyleBackColor = true;
            this.btnXmlToSql.Click += new System.EventHandler(this.btnXmlToSql_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 27);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(830, 307);
            this.textBox1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 562);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 16;
            // 
            // btnBrowseJsonOrXmlFile
            // 
            this.btnBrowseJsonOrXmlFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseJsonOrXmlFile.Location = new System.Drawing.Point(109, 392);
            this.btnBrowseJsonOrXmlFile.Name = "btnBrowseJsonOrXmlFile";
            this.btnBrowseJsonOrXmlFile.Size = new System.Drawing.Size(238, 37);
            this.btnBrowseJsonOrXmlFile.TabIndex = 17;
            this.btnBrowseJsonOrXmlFile.Text = "Browse Json/Xml Data File";
            this.btnBrowseJsonOrXmlFile.UseVisualStyleBackColor = true;
            this.btnBrowseJsonOrXmlFile.Click += new System.EventHandler(this.btnBrowseJsonOrXmlFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(887, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Base Url:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(896, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "APIKey:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(876, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "SecretKey:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(902, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "Query:";
            // 
            // txtBaseUrl
            // 
            this.txtBaseUrl.Location = new System.Drawing.Point(959, 27);
            this.txtBaseUrl.Name = "txtBaseUrl";
            this.txtBaseUrl.Size = new System.Drawing.Size(713, 22);
            this.txtBaseUrl.TabIndex = 23;
            // 
            // txtAPIKey
            // 
            this.txtAPIKey.Location = new System.Drawing.Point(959, 64);
            this.txtAPIKey.Name = "txtAPIKey";
            this.txtAPIKey.Size = new System.Drawing.Size(713, 22);
            this.txtAPIKey.TabIndex = 24;
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(959, 167);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(713, 102);
            this.txtQuery.TabIndex = 25;
            // 
            // txtSecretKey
            // 
            this.txtSecretKey.Location = new System.Drawing.Point(959, 96);
            this.txtSecretKey.Name = "txtSecretKey";
            this.txtSecretKey.Size = new System.Drawing.Size(713, 22);
            this.txtSecretKey.TabIndex = 27;
            // 
            // btnViewQuery
            // 
            this.btnViewQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewQuery.Location = new System.Drawing.Point(959, 299);
            this.btnViewQuery.Name = "btnViewQuery";
            this.btnViewQuery.Size = new System.Drawing.Size(213, 35);
            this.btnViewQuery.TabIndex = 28;
            this.btnViewQuery.Text = "View Query Response";
            this.btnViewQuery.UseVisualStyleBackColor = true;
            this.btnViewQuery.Click += new System.EventHandler(this.btnViewQuery_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(959, 379);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(721, 261);
            this.dataGridView1.TabIndex = 29;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1777, 669);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnViewQuery);
            this.Controls.Add(this.txtSecretKey);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.txtAPIKey);
            this.Controls.Add(this.txtBaseUrl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowseJsonOrXmlFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnConvertXmlToSql);
            this.Controls.Add(this.txtXmlFilePath);
            this.Controls.Add(this.btnXmlToSql);
            this.Controls.Add(this.btnConvertJsonToSQL);
            this.Controls.Add(this.txtJsonFilePath);
            this.Controls.Add(this.btnJsonToSql);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Json/Xml To SQL";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnJsonToSql;
        private System.Windows.Forms.TextBox txtJsonFilePath;
        private System.Windows.Forms.Button btnConvertJsonToSQL;
        private System.Windows.Forms.Button btnConvertXmlToSql;
        private System.Windows.Forms.TextBox txtXmlFilePath;
        private System.Windows.Forms.Button btnXmlToSql;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseJsonOrXmlFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBaseUrl;
        private System.Windows.Forms.TextBox txtAPIKey;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.TextBox txtSecretKey;
        private System.Windows.Forms.Button btnViewQuery;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

