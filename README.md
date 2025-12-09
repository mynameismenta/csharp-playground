# csharp-playground

Repository containing a collection of **C#** projects organized for experimentation, learning, and concept demonstration. The goal is to centralize practical examples, good practices, and small reusable components, enabling continuous exploration and evolution.

## 🧩 Repository Structure

The structure is modular, where each folder represents an independent project.  
Each project:
- Has its own build and test cycle.  
- Maintains autonomy, avoiding unwanted dependencies between modules.

## 🚀 Repository Goals

- Explore different paradigms and features of the C# language.  
- Enable quick testing of ideas without needing separate repositories.  
- Provide an organized and extensible environment for learning.

## 🛠️ Technologies Used

- Latest .NET SDK  
- C#  
- Auxiliary tools: Git, dotnet CLI, Visual Studio  

## 📦 How to Run

Clone the repository:

```bash
git clone https://github.com/usuario/csharp-playground.git
cd csharp-playground
```
List all projects:
```bash
dotnet sln list
```

Run any project:
```bash
dotnet run --project ProjectName/src/ProjectName.csproj
```

Run the tests:
```bash
dotnet test
```
### 📁 Adding New Projects
```bash
dotnet new console -o MyNewProject
dotnet sln add MyNewProject/MyNewProject.csproj
```
## 🧪 Possible Project Examples
Simple games (Hangman, Tic-Tac-Toe, etc.);
Small ASP.NET APIs;
Data structures;
Studies on LINQ, tasks, parallelism, and async/await
