# Admin PakoBlog — Admin Panel

The **Admin PakoBlog** project is an ASP.NET Core–based admin panel for managing posts, categories, tags, users, and media content for PakoBlog.

> This README provides quick setup instructions, development environment guidelines, and contribution notes. Update it as your repository evolves.

---

## 🚀 Features

- **Post Management:** Create/edit/delete posts, manage draft & published states, schedule publishing.
- **Categories & Tags:** Hierarchical categories and multiple tags.
- **Media Library:** Upload, rename, and associate images/files.
- **User & Role Management:** Admin/Editor/Author roles (extensible); password reset.
- **Comment Moderation:** Approve, hide, delete; mark as spam (optional).
- **Search & Filtering:** Filter by title, status, date, and author.

---

## 📦 Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/UmtiPako/Admin_PakoBlog-for-PakoBlog.git
   ```
2. Navigate into the project directory:
   ```bash
   cd Admin_PakoBlog-for-PakoBlog
   ```
3. Restore dependencies:
   ```bash
   dotnet restore
   ```
4. Update the `appsettings.json` with your database connection string.
5. Run migrations:
   ```bash
   dotnet ef database update
   ```
6. Start the application:
   ```bash
   dotnet run
   ```

---

## 🛠 Technologies

- **ASP.NET Core MVC**
- **Entity Framework Core**
- **Bootstrap** for UI styling
- **SQL Server** (configurable)

---

---

## 📄 License

This project is licensed under the MIT License — see the [LICENSE](LICENSE) file for details.

