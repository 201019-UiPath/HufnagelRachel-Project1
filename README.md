# HufnagelRachel-Project1
**Author:**
**Rachel Hufnagel**
  
## Project Description
This application is designed with functionality that would make virtual shopping much simpler! Customers can sign up for an account, place orders, view their order history, and specific location inventory. Managers can view and replenish location inventory, add new products, and view the order history of specific locations. This application used Entity Framework Core to connect to a PostgreSQL database, ASP.NET Core API to create a RESTful API, and front end will be created/implemented with HTML, CSS, BootstrapJS, and Javascript.

## Technologies Used
C# Programming
ADO.NET Entity Framework Core
Testing Process / SDLC
Defect Logging
PostgreSQL
XML
Features
Users can sign up for accounts or log in to existing accounts
Users can view products and inventory per location
User can place orders for multiple products at a time and view order history
Manager users can view location order history
Manager users can replenish inventory at locations
Manager users can add new products to inventories
To-do list:

Complete the front end of the website
Order histiories should be able to be sorted by Date and Price, either ascending or descending
## Getting Started
To Clone: git clone https://github.com/201019-UiPath/HufnagelRachel-Project1.git

Once cloned, you will need to create an appsettings.json file to direct the application to your database
Database tables can be created using EF Core Code-First approach using these commands:
dotnet ef migrations add initial -c LacrosseContext --startup-project ../LacrosseUI/LacrosseUI.csproj
dotnet ef database update --startup-project ../LacrosseUI/LacrosseUI.csproj
You will also need to populate your database with seed data of your choice
## Usage
After installation is complete and database migrated:

The current app is still under developement for the interface. If you would like to test this and web service like Postman would be reccomended.

## License
This project uses the following license: MIT License.