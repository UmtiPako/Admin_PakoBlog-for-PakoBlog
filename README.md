# **Admin Panel for PakoBlog**

This project is the administration system for the **PakoBlog** application. It provides a web-based interface for managing blog content, users, and other administrative tasks.

## **✨ Features**

* **Blog Post Management**: Create, edit, and delete blog posts.  
* **Dashboard**: A central dashboard to get an overview of blog activity.  
* **Responsive Design**: Accessible on both desktop and mobile devices.

## **🛠️ Technologies**

* **Backend**: C\# with ASP.NET Core MVC  
* **Frontend**: HTML, CSS, JavaScript  
* **Database**: Entity Framework Core for data management  
* **Framework**: .NET

## **🚀 Getting Started**

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### **Prerequisites**

* [.NET SDK](https://dotnet.microsoft.com/download) (Version 6.0 or higher is recommended)  
* A code editor like [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio](https://visualstudio.microsoft.com/)

### **Installation**

1. **Clone the repository**:  
   git clone https://github.com/UmtiPako/Admin\_PakoBlog-for-PakoBlog.git  
   cd Admin\_PakoBlog-for-PakoBlog

2. Restore dependencies:  
   Open the terminal in the project directory and run:  
   dotnet restore

3. Update the database:  
   This project uses Entity Framework Core for the database. To apply the latest migrations and create the database, run the following commands:  
   dotnet ef database update

4. Configure appsettings.json:  
   Update your database connection string in the appsettings.json file.  
   "ConnectionStrings": {  
     "DefaultConnection": "Server=(localdb)\\\\mssqllocaldb;Database=PakoBlogDb;Trusted\_Connection=True;MultipleActiveResultSets=true"  
   }

### **Running the Application**

1. **Run the project from the terminal**:  
   dotnet run

2. Access the application:  
   Open your web browser and navigate to the URL provided in the terminal (e.g., https://localhost:7001).

## **🤝 Contributing**

Contributions, issues, and feature requests are welcome\! Feel free to check the [issues page](https://www.google.com/search?q=https://github.com/UmtiPako/Admin_PakoBlog-for-PakoBlog/issues).

## **📄 License**

This project is licensed under the MIT License. See the LICENSE file for details.
