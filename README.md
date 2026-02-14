Service Application Read Me
This application is designed for users to report issues, attach files (such as images or documents), and submit them for review. Users can provide a location, category, and description of the issue, and optionally attach files for better clarification. The application validates user input and stores submitted issues in memory for future retrieval.
1.	Main Menu
Upon starting the application, you will be presented with the Main Menu with four options:
•	Report Issues (currently implemented): Clicking this button takes the user to the Report Issues form.
•	Local Events and Announcements (not implemented)
•	Service Request Status: (not implemented)
•	Exit: (currently implemented): I have implemented an exit confirmation dialog to prevent users from accidentally closing the application, when the Exit button is clicked.
## Features
2.	Reporting an Issue
•	Click on the Report Issues button to open the reporting form.
•	View Submitted Issues button: Click the button to view previously reported issues after or before the submission of your reported issues.
•	Once the form is opened use the Location Input: Enter the location (e.g., Akasia) of the issue in the provided textbox.
•	Category Selection: Choose the category of the issue from the dropdown or list (e.g., sanitation, roads, utilities).
•	Description Box: Provide a detailed description of the issue in the RichTextBox control.
•	File Attachments/ Media Attachment: When submitting an issue, users can select multiple files (e.g., images or documents) to attach to the issue. These files are stored in memory along with the issue.
•	Submit Button: Click the "Submit" button to finalize the report.
•	Confirmation: A confirmation message will appear indicating the successful submission of the issue.
•	Reset Form: The form will be cleared, allowing for new issue submissions.
•	Back Button: Click the "Back " button to return to the main menu or navigate to other sections.
•	Form Validation**: Real-time validation is provided to ensure all required fields are filled out before submission. 
•	Progress Indicators: The application shows a progress bar during file attachments and form submissions to provide feedback to users.

Contact
For any issues or inquiries, please contact [st10102168@rcconnect.edu.za].

Read Me file 
1.	Steps to Compile:
o	Open the solution file (ServicesApplication.sln) in Visual Studio.
o	Build the solution by selecting Build > Build Solution from the main menu or pressing Ctrl+Shift+B.
o	Address any errors indicated in the Error List pane, if present. None are present.
Running the Application
1.	Once compiled, run the application by pressing F5 or selecting Debug > Start Debugging.
2.	The application will open with a main menu containing the following options:
o	Report Issues: To report new and existing issues.
o	Local Events and Announcements: To view municipal or community and even add new events.
o	Service Request Status: To keep track of previously submitted service requests and status.
o	Exit: Used to exit the application by clicking on it. 
3.	Navigating the Application:
o	Use the provided navigation buttons to return to the main menu or to move to other sections by just clicking.
o	When submitting forms, use the “Submit” button to finalize entries
o	When returning to main menu use the back button on each form.
Using the application.
1.	Report Issues:
o	Enter the issue details, including location, category, and description.
o	Attach any supporting media (images or documents).
o	Submit the form; a message will confirm successful submission.
o	View submissions, by clicking view submitted issues button, this will take you to a new form where you will see your submitted issues. 
2.	Viewing Local Events:
o	Use the search and filtering features to find events by category or event name.
o	View all events and announcements. 
o	Add event or announcements. 
o	Event date format is 11/02/2026 
3.	 Service Request Status:
o	Enter your request ID to view status updates and track request progress.
o	Search by category by “filter by status” if one has forgotten their requestID. 
o	Refresh page to refresh data. 

