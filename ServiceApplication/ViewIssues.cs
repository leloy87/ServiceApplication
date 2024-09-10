using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace ServiceApplication
{
    public partial class ViewIssues : Form
    {
        private List<Issue> issues; // Declare class-level variable

        public ViewIssues()
        {
            InitializeComponent();
            ApplyStyling(); // Apply custom styling
            CreateHeader(); // Create the header
        }

        private void ViewIssues_Load(object sender, EventArgs e)
        {
            LoadIssues();
        }

        private void LoadIssues()
        {
            // Initialize the issues list from the IssueStorage class
            issues = IssueStorage.Issues;
            UpdateDataGridView(issues);
        }

        private void UpdateDataGridView(List<Issue> issuesToDisplay)
        {
            dataGridViewIssues.DataSource = null; // Clear existing data
            dataGridViewIssues.DataSource = issuesToDisplay; // Bind new data
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = textBoxSearch.Text.ToLower();
            var filteredIssues = issues.Where(issue =>
                issue.Description.ToLower().Contains(searchTerm) ||
                issue.Id.ToString().Contains(searchTerm)).ToList();
            UpdateDataGridView(filteredIssues);
        }

        private void dataGridViewIssues_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Your logic here to handle cell clicks
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            // Optionally handle text changes for real-time filtering
        }

        // Override OnPaint method to apply gradient background
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Create a gradient brush
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                Color.FromArgb(255, 239, 243), Color.FromArgb(255, 182, 193), 90F)) // Pink gradient
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle); // Fill the background with gradient
            }
        }

        private void ApplyStyling()
        {
            // Style the buttons
            buttonSearch.BackColor = Color.FromArgb(255, 182, 193); // Light pink
            buttonSearch.ForeColor = Color.White;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.FlatAppearance.BorderSize = 2; // Add border size
            buttonSearch.FlatAppearance.BorderColor = Color.FromArgb(255, 105, 180); // Border color
            buttonSearch.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 192, 203); // Darker pink on click
            buttonSearch.Font = new Font("Comic Sans MS", 12, FontStyle.Bold); // Larger font
            buttonSearch.Size = new Size(150, 50); // Larger size

            // Style the text boxes
            textBoxSearch.BackColor = Color.FromArgb(255, 240, 245); // Light pastel
            textBoxSearch.ForeColor = Color.FromArgb(0, 0, 0); // Black text
            textBoxSearch.Font = new Font("Comic Sans MS", 10, FontStyle.Regular);

            // Style the DataGridView
            dataGridViewIssues.BackgroundColor = Color.FromArgb(255, 240, 245); // Light pastel background
            dataGridViewIssues.DefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0); // Black text
            dataGridViewIssues.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255); // White cells
            dataGridViewIssues.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 105, 180); // Header background color
            dataGridViewIssues.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Header text color
            dataGridViewIssues.Font = new Font("Comic Sans MS", 10, FontStyle.Regular);

            // Style the form
            this.BackColor = Color.FromArgb(255, 239, 243); // Gradient light pink
        }

        // Method to create the header
        private void CreateHeader()
        {
            // Create a panel for the header
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(255, 105, 180), // Light pink
                BorderStyle = BorderStyle.FixedSingle // Border around the panel
            };

            // Create a label for the header text
            Label headerLabel = new Label
            {
                Text = "View Reported Issues",
                ForeColor = Color.White,
                Font = new Font("Comic Sans MS", 16, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Add the label to the panel
            headerPanel.Controls.Add(headerLabel);

            // Add the panel to the form
            this.Controls.Add(headerPanel);
            headerPanel.BringToFront(); // Bring the panel to the front
        }
    }

    // Define the Issue class
    public class Issue
    {
        public int Id { get; set; } // Added Id property
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public List<string> Attachments { get; set; } = new List<string>();
    }

    // In the MainMenu or ReportIssues form, store submitted issues in a list
    public static class IssueStorage
    {
        public static List<Issue> Issues = new List<Issue>();
    }
}
