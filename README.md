# 🏫 School Management App (ASP.NET Core)

This is a web application built with **ASP.NET Core** that allows you to manage key school data. It includes functionality for managing **students**, **professors**, **subjects**, **grades**, and **school years** using a connected relational database.

---

## ✨ Features

### 👨‍🎓 Student Management
- Add new students with details like name, email,school year, and assigned grades
- View a full list of enrolled students
- Edit student information (e.g. name, grade, school year)
- Delete students from the system

### 👩‍🏫 Professor Management
- Add new professors with relevant details
- View a list of all professors
- Edit professor information
- Delete professors
- Assign subjects to professors

### 🏫 Academic Structure
- Create and manage school years
- Assign grades to students (per subject)
- Assign subjects to professors

---

## 🗄️ Data Storage

- Uses **Entity Framework Core** with a SQL database (e.g. SQL Server or SQLite)
- All data is stored persistently in the database
- Relationships are managed between students, professors, subjects, and grades

---

## 🛠️ Technologies Used

- **ASP.NET Core (MVC or Razor Pages)**
- **Entity Framework Core**
- **C#**
- **SQL Server** or **SQLite**
- **Bootstrap** (UI styling)
