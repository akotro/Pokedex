namespace Pokedex
{
    partial class Pokedex
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
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.listBoxPokemon = new System.Windows.Forms.ListBox();
            this.pictureBoxSprite = new System.Windows.Forms.PictureBox();
            this.labelTypeName = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSprite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelName.Location = new System.Drawing.Point(200, 161);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(106, 30);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Pokemon";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxSearch.Location = new System.Drawing.Point(200, 568);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(334, 33);
            this.textBoxSearch.TabIndex = 1;
            this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyDown);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSearch.Location = new System.Drawing.Point(200, 607);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(334, 36);
            this.buttonSearch.TabIndex = 0;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // listBoxPokemon
            // 
            this.listBoxPokemon.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxPokemon.FormattingEnabled = true;
            this.listBoxPokemon.ItemHeight = 25;
            this.listBoxPokemon.Location = new System.Drawing.Point(12, 159);
            this.listBoxPokemon.Name = "listBoxPokemon";
            this.listBoxPokemon.Size = new System.Drawing.Size(165, 479);
            this.listBoxPokemon.TabIndex = 3;
            this.listBoxPokemon.SelectedIndexChanged += new System.EventHandler(this.listBoxPokemon_SelectedIndexChanged);
            // 
            // pictureBoxSprite
            // 
            this.pictureBoxSprite.Location = new System.Drawing.Point(200, 235);
            this.pictureBoxSprite.Name = "pictureBoxSprite";
            this.pictureBoxSprite.Size = new System.Drawing.Size(334, 300);
            this.pictureBoxSprite.TabIndex = 4;
            this.pictureBoxSprite.TabStop = false;
            // 
            // labelTypeName
            // 
            this.labelTypeName.AutoSize = true;
            this.labelTypeName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTypeName.Location = new System.Drawing.Point(255, 191);
            this.labelTypeName.Name = "labelTypeName";
            this.labelTypeName.Size = new System.Drawing.Size(0, 25);
            this.labelTypeName.TabIndex = 5;
            // 
            // labelType
            // 
            this.labelType.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelType.Location = new System.Drawing.Point(200, 191);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(55, 25);
            this.labelType.TabIndex = 0;
            this.labelType.Text = "Type:";
            // 
            // pictureBoxTitle
            // 
            this.pictureBoxTitle.ImageLocation = "C:\\Users\\akotr\\programming\\ConnectLine\\PokeAPI\\Pokedex\\Resources\\Pokedex.png";
            this.pictureBoxTitle.Location = new System.Drawing.Point(74, 12);
            this.pictureBoxTitle.Name = "pictureBoxTitle";
            this.pictureBoxTitle.Size = new System.Drawing.Size(390, 144);
            this.pictureBoxTitle.TabIndex = 0;
            this.pictureBoxTitle.TabStop = false;
            // 
            // Pokedex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 661);
            this.Controls.Add(this.pictureBoxTitle);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.labelTypeName);
            this.Controls.Add(this.pictureBoxSprite);
            this.Controls.Add(this.listBoxPokemon);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.labelName);
            this.Name = "Pokedex";
            this.Text = "PokeDex";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSprite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelName;
        private TextBox textBoxSearch;
        private Button buttonSearch;
        private ListBox listBoxPokemon;
        private PictureBox pictureBoxSprite;
        private Label labelTypeName;
        private Label labelType;
        private PictureBox pictureBoxTitle;
    }
}