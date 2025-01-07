# README
---
## 1. Environment Setup
- The development of this application was conducted on a Windows system. To ensure proper functionality, it is recommended to run the program on Windows. Testing on Mac systems has not been conducted.

- The `.env.example` file contains environment variables for database configuration. These should be modified to fit your local environment, including file paths and connection strings.

- For the OpenAI API, you will need to configure your API key as an environment variable on your computer. We use the Windows environment variable system to read the API key. The variable name is `OPENAI_API_KEY`.

  <img src="https://github.com/user-attachments/assets/d12b4285-bf7b-4efc-92c1-ea71cd471b1c" alt="Environment Variable Setup" width="600">

Please ensure the environment is properly set up before proceeding with the following steps!

---
## 2. User Guide
- **Login Interface**: Upon running the program, you will be presented with the user login interface. New users must register first before logging in. Usernames must be unique.

  <img src="https://github.com/user-attachments/assets/0c7b74a0-b072-4f11-8709-da3adbaeaaea" alt="User Login Interface" width="600">

- **Homepage**: After logging in, the homepage allows you to browse recommended restaurants. The homepage also lets you edit restaurants you wish to save and export them to notes. The top-right corner provides a button to switch to the saved notes page.

  <img src="https://github.com/user-attachments/assets/c0f51142-ec10-40c1-9df1-e7e3619d2439" alt="Homepage" width="600">

- **Notes Page**: On the notes page, you can view your saved restaurants and click hyperlinks for more details. If you want to delete a restaurant, select the checkbox for that restaurant and click `Delete` to remove it.

  <img src="https://github.com/user-attachments/assets/d099b21a-3033-4fbb-b43f-298ee4ea0482" alt="Notes Page" width="600">

---
New features are under development...
