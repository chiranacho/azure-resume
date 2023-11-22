## Daniel Balezi's Azure Resume
This is my Cloud Resume Challenge built on Azure. It's a static website hosted on Azure Storage, with a visitor counter built on Azure Functions. The website is built with HTML, CSS, and JavaScript. The visitor counter is built with .NET and Azure Functions

![azure-resume](./architecture.png)

## Demo
[View it live here :)](https://cloudresume.balezy.com/)

## Structure
- `frontend/` : Folder contains the website.
    - `main.js` : Folder contains visitor counter code.
- `backend/api/` : Folder contains the dotnet API deployed on Azure Functions.
    - `Counter.cs` : Contains the visitor counter code.
- `.github/workflows/` : Folder contains CI/CD workflow configurations.