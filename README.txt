Car Rental Management System
============================

1. What This Program Does
-------------------------
This is a C# WinForms desktop app that will be used to manage a small car rental business.
It will let you:

- Store basic car info (make, model, year, daily rate, active/inactive)
- Store customer info (name, phone, email, driver’s license)
- Create and track rentals (which customer has which car, for what dates, and cost)

All data is kept in memory only. When you close the program, everything resets.

2. System Requirements
----------------------
- .NET Framework (compatible with the project)
- Visual Studio 2022 with “.NET desktop development” installed

3. How to Run
-------------
1. Extract the ZIP to a folder.
2. Open the `.sln` solution file in Visual Studio.
3. Set the project as Startup Project (if needed).
4. Build and run (press F5).

You can also run the compiled `.exe` from the project’s `bin\Debug` or `bin\Release` folder after building.

4. Main Screens & Features
--------------------------

Main Menu
- Buttons to open: Manage Cars, Manage Customers, Manage Rentals.

Cars
- Enter Make, Model, Year, Daily Rate, and Active status.
- Click 'Add' to create a car.
- Select a row, edit the fields, then click 'Update' to change a car.

Customers
- Enter Name, Phone, Email, and Driver’s License.
- Click 'Add' to create a customer.
- Select a row, edit the fields, then click 'Update' to change a customer.

Rentals
- Select a Customer and Car from drop-down lists.
- Choose Start Date and End Date.
- Click Create Rental to add it; the estimated cost is calculated automatically.
- To return a car, select a rental row and click 'Return' (or equivalent button).
  The system updates the status and recalculates the final cost based on the actual return date.