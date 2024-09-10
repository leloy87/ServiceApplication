using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D; // Required for gradient brushes
using System.Windows.Forms;

namespace ServiceApplication
{
    public partial class ReportIssues : Form
    {
        // List to store the file paths of the selected files
        private List<string> selectedFiles = new List<string>();

        public ReportIssues()
        {
            InitializeComponent(); // Initialize form components first
            ApplyStyling();        // Apply custom styling afterwards
            CreateHeader();        // Create the header
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
            btnAttachMedia.BackColor = Color.FromArgb(255, 182, 193); // Light pink
            btnAttachMedia.ForeColor = Color.White;
            btnAttachMedia.FlatStyle = FlatStyle.Flat;
            btnAttachMedia.FlatAppearance.BorderSize = 2; // Add border size
            btnAttachMedia.FlatAppearance.BorderColor = Color.FromArgb(255, 105, 180); // Border color
            btnAttachMedia.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 192, 203); // Darker pink on click
            btnAttachMedia.Font = new Font("Comic Sans MS", 12, FontStyle.Bold); // Larger font
            btnAttachMedia.Size = new Size(150, 50); // Larger size

            btnSubmit.BackColor = Color.FromArgb(255, 192, 203); // Slightly darker pink
            btnSubmit.ForeColor = Color.White;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.FlatAppearance.BorderSize = 2; // Add border size
            btnSubmit.FlatAppearance.BorderColor = Color.FromArgb(255, 105, 180); // Border color
            btnSubmit.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 182, 193); // Light pink on click
            btnSubmit.Font = new Font("Comic Sans MS", 12, FontStyle.Bold); // Larger font
            btnSubmit.Size = new Size(150, 50); // Larger size

            btnBack.BackColor = Color.FromArgb(255, 182, 193); // Light pink
            btnBack.ForeColor = Color.White;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 2; // Add border size
            btnBack.FlatAppearance.BorderColor = Color.FromArgb(255, 105, 180); // Border color
            btnBack.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 192, 203); // Slightly darker pink on click
            btnBack.Font = new Font("Comic Sans MS", 12, FontStyle.Bold); // Larger font
            btnBack.Size = new Size(150, 50); // Larger size

            // Style the labels
            lblAttachment.ForeColor = Color.FromArgb(255, 105, 180); // Light pink
            lblAttachment.Font = new Font("Comic Sans MS", 12, FontStyle.Regular);

            // Style the text boxes and combo box
            txtLocation.BackColor = Color.FromArgb(255, 240, 245); // Light pastel
            txtLocation.ForeColor = Color.FromArgb(0, 0, 0); // Black text
            txtLocation.Font = new Font("Comic Sans MS", 10, FontStyle.Regular);

            cmbCategory.BackColor = Color.FromArgb(255, 240, 245); // Light pastel
            cmbCategory.ForeColor = Color.FromArgb(0, 0, 0); // Black text
            cmbCategory.Font = new Font("Comic Sans MS", 10, FontStyle.Regular);

            rtxtDescription.BackColor = Color.FromArgb(255, 240, 245); // Light pastel
            rtxtDescription.ForeColor = Color.FromArgb(0, 0, 0); // Black text
            rtxtDescription.Font = new Font("Comic Sans MS", 10, FontStyle.Regular);

            // Style the progress bar
            progressBarAttachFiles.ForeColor = Color.FromArgb(255, 105, 180); // Light pink
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
                Text = "Report Issues Here",
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

        // Event handler for when the attachment label is clicked
        private void lblAttachment_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Attachment label clicked. You can now change the attached file if needed.");
        }

        // Logic to attach multiple media files
        private void btnAttachMedia_Click(object sender, EventArgs e)
        {
            progressBarAttachFiles.Visible = true;
            progressBarAttachFiles.Style = ProgressBarStyle.Marquee;

            // Open file dialog for the user to select media files
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png|Document Files|*.pdf;*.docx",
                Multiselect = true  // Allow multiple files to be selected
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Clear previously selected files
                selectedFiles.Clear();

                // Add selected file paths to the list
                selectedFiles.AddRange(openFileDialog.FileNames);

                // Display the selected file names in the label (without the full path)
                lblAttachment.Text = string.Join(", ", openFileDialog.SafeFileNames);
            }
            progressBarAttachFiles.Visible = false;
        }

        // Logic to submit an issue
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Call the SubmitIssue method to handle submission
            SubmitIssue();
        }

        // Method to submit an issue
        private void SubmitIssue()
        {
            // Validate user input
            string location = txtLocation.Text.Trim();
            string category = cmbCategory.SelectedItem?.ToString();
            string description = rtxtDescription.Text.Trim();

            // Ensure required fields are filled out
            if (string.IsNullOrEmpty(location) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Please fill out all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create a new issue with the user's input
            var issue = new Issue
            {
                Location = location,
                Category = category,
                Description = description,
                Attachments = new List<string>(selectedFiles) // Add selected files if any
            };

            // Add the issue to the in-memory storage
            IssueStorage.Issues.Add(issue);

            // Show a success message
            MessageBox.Show("Issue submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear the form fields for new input
            txtLocation.Clear();
            cmbCategory.SelectedIndex = -1;
            rtxtDescription.Clear();
            lblAttachment.Text = "No files selected";
            selectedFiles.Clear();  // Clear the selected files list for next submission
        }

        // Logic to navigate back to the main menu
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Create a new instance of the MainMenu form and show it
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();

            // Hide the current ReportIssues form
            this.Hide();
        }

        // Optional: Handle other events if needed
        private void Location_Click(object sender, EventArgs e)
        {
            // Optional: Handle Location label click
        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            // Optional: Handle location text change
        }

        private void Category_Click(object sender, EventArgs e)
        {
            // Optional: Handle Category label click
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Optional: Handle category selection change
        }

        private void Description_Click(object sender, EventArgs e)
        {
            // Optional: Handle Description label click
        }

        private void rtxtDescription_TextChanged(object sender, EventArgs e)
        {
            // Optional: Handle description text change
        }

        private void btnViewIssues_Click(object sender, EventArgs e)
        {
            // Create a new instance of the ViewIssues form
            ViewIssues viewIssuesForm = new ViewIssues();

            // Display the ViewIssues form
            viewIssuesForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Optional: Handle label click
        }

        private void ReportIssues_Load(object sender, EventArgs e)
        {
            // Optional: Handle form load
        }

        private void progressBarAttachFiles_Click(object sender, EventArgs e)
        {
            // Optional: Handle progress bar click
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            // Optional: Handle tooltip popup
        }

        // Add shadow effect to controls
        private void AddShadowEffect(Control control)
        {
            control.Paint += (sender, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, control.ClientRectangle,
                    Color.DarkGray, 5, ButtonBorderStyle.None, // Left
                    Color.DarkGray, 5, ButtonBorderStyle.None, // Top
                    Color.DarkGray, 5, ButtonBorderStyle.Solid, // Right
                    Color.DarkGray, 5, ButtonBorderStyle.Solid); // Bottom
            };
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
        }
}

}



