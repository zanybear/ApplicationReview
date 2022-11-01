(*Note - find more info at ARProgrameDoc file)
# Objective:
Business Line objective is to create a program where they can verify or review online deposit applications. Also looking to have separate functionality for users with different roles.

# Business Requirements:
•	Functionality to identify users
•	Option access per the user role
•	Allowing Bankers to process assigned apps
•	Ability to add comments to manager on the application basis
•	Option to view all apps by queues to Manager
•	Any user can be able to view app details by id
# Development needs:
•	Authenticate user login to identify their roles
•	Creating different menu options for the users 
•	Use the current app data and user data for the business logic  
# Application Test Data:
Manager role:
mgr1
mgr2

Banker role:
bnkr1
bnkr2

App id’s:
2022110201 to 2022110221
2022110101 to 2022110121

Queue names:
Assigned
Declined
Approved
Withdraw
# Test Criteria
-Login application using manager or banker preferred id.
-Choose any option you like to view or operate.
-	You can view /add banker comments with the options Banker Note/Add Notes
-You can search any app id with App search
-	Manager role can view app count by queue
-	Bankers can get their list of assigned apps and process app (that gets the first assigned app from data layer)
-	User can logout using exit option.
# Development work
-	Structured as a three tier to identify business logic, data and screen work.
-	Used oops concept to connect classes from all different namespaces.
-	Created an Interface to verify user ids.
-	Created model classes to manage business data.
-	Executing generic collection class query using LINQ functionality.
-	Created Enum for Queue types.
# Software:
Developed this console application using latest VS 2022,.net6 Framework and C# language.
