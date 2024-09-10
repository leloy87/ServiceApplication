using System;
using System.Drawing;
using System.Drawing.Drawing2D; // For gradient background
using System.Windows.Forms;

namespace ServiceApplication
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent(); // Initialize form components first
            ApplyStyling();
        }

        // Override OnPaint method to apply gradient background
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Create a gradient brush for the background
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                Color.FromArgb(255, 239, 243), Color.FromArgb(255, 182, 193), 90F)) // Pink gradient
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle); // Fill the background with gradient
            }
        }

        private void ApplyStyling()
        {
            // Set the same font and size for all buttons
            Font simpleFont = new Font("Segoe UI", 12, FontStyle.Regular); // Simple, modern font
            Size buttonSize = new Size(200, 60); // Larger buttons for better visibility

            // Define a base color for hover and click effects
            Color hoverColor = Color.FromArgb(173, 216, 230); // Light Blue
            Color clickColor = Color.FromArgb(100, 149, 237); // Cornflower Blue

            // Welcome label
            Label lblWelcome = new Label();
            lblWelcome.Text = "Welcome to Municipalities of South Africa Service App";
            lblWelcome.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblWelcome.ForeColor = Color.Black;
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(50, 20); // Adjust position
            this.Controls.Add(lblWelcome);

            // Footer label
            Label lblFooter = new Label();
            lblFooter.Text = "Service Application v1.0 | Developed by Your Name";
            lblFooter.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            lblFooter.ForeColor = Color.Gray;
            lblFooter.AutoSize = true;
            lblFooter.Location = new Point(50, 400); // Adjust position to the bottom
            this.Controls.Add(lblFooter);

            // Style buttons
            StyleButton(btnReportIssues, Color.FromArgb(135, 206, 250), simpleFont, buttonSize, new Point(50, 100), hoverColor, clickColor);
            StyleButton(btnLocalEvents, Color.FromArgb(144, 238, 144), simpleFont, buttonSize, new Point(50, 180), hoverColor, clickColor);
            StyleButton(btnServiceStatus, Color.FromArgb(255, 165, 0), simpleFont, buttonSize, new Point(50, 260), hoverColor, clickColor);

            // Add Exit button
            Button btnExit = new Button();
            btnExit.Text = "Exit";
            btnExit.BackColor = Color.FromArgb(255, 99, 71); // Tomato Red
            btnExit.ForeColor = Color.White;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.Font = simpleFont;
            btnExit.Size = buttonSize;
            btnExit.Location = new Point(50, 340); // Adjust position
            btnExit.Click += BtnExit_Click;
            btnExit.MouseEnter += (s, e) => btnExit.BackColor = hoverColor;
            btnExit.MouseLeave += (s, e) => btnExit.BackColor = Color.FromArgb(255, 99, 71);
            btnExit.MouseDown += (s, e) => btnExit.BackColor = clickColor;
            btnExit.MouseUp += (s, e) => btnExit.BackColor = Color.FromArgb(255, 99, 71);
            this.Controls.Add(btnExit);
        }

        private void StyleButton(Button button, Color baseColor, Font font, Size size, Point location, Color hoverColor, Color clickColor)
        {
            button.BackColor = baseColor;
            button.ForeColor = Color.Black;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = font;
            button.Size = size;
            button.Location = location;

            button.MouseEnter += (s, e) => button.BackColor = hoverColor;
            button.MouseLeave += (s, e) => button.BackColor = baseColor;
            button.MouseDown += (s, e) => button.BackColor = clickColor;
            button.MouseUp += (s, e) => button.BackColor = baseColor;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            // Ask for confirmation before exiting
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Exit the application
            }
        }

        // Event handler for the Report Issues button
        private void ReportIssues(object sender, EventArgs e)
        {
            // Create an instance of the ReportIssues form
            ReportIssues reportIssuesForm = new ReportIssues();

            // Show the ReportIssues form
            reportIssuesForm.Show();

            // Optionally hide the Main Menu if you don't want both forms visible
            this.Hide();
        }

        private void LocalEvents(object sender, EventArgs e)
        {
            // Handle Local Events button click (if needed)
        }

        private void Service_Status(object sender, EventArgs e)
        {
            // Handle Service Status button click (if needed)
        }
    }
}




