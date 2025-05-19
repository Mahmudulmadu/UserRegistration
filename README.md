User Registration ASP.NET Core MVC Project

This is a simple ASP.NET Core MVC web application that allows users to register with their name, email, password, and confirm password. 
After successful registration, an automated confirmation email is sent to the user.

Features:

User registration form
Email validation and duplicate check
Confirm password validation
Email confirmation using Gmail SMTP
Data storage with Entity Framework Core and SQL Server
Bootstrap UI for better user experience

Technologies Used:

ASP.NET Core MVC
Entity Framework Core
SQL Server
C#
Bootstrap
Gmail SMTP

How to Run:

Clone the repository.
Open the project in Visual Studio.
Configure your SMTP email and app password in appsettings.json.

Apply the database migration using the Package Manager Console:

Update-Database
Run the project.

SMTP Configuration (example in appsettings.json):

"SmtpSettings": {
  "FromEmail": "yourgmail@gmail.com",
  "AppPassword": "yourapppassword"
}


Next Improvements:

Add login/logout features
Email verification link
