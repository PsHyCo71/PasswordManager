# Password Manager

## Description
A simple **passwor manager** to store your data safely in a **sqlite database**.

## Requirements
- Windows 10 or later
- .NET SDK 10.0 or later (If you just need to run the `.exe` you don't need it)

### .NET SDK Installation Guide for Windows
- From the website
    - Open your browser and go to this [page](https://dotnet.microsoft.com/en-us/download/dotnet)
    - Install latest version
    - Execute the downloaded file
    - Check if dotnet is installed by typing this in the Command Prompt or Powershell
    ```bash
    dotnet --version
    ```
- With packet manager
    - Open the Command Prompt or Powershell as administrator
    
    - Choose one of the following package managers for Windows:
    ```bash
    winget install Microsoft.DotNet.SDK.10
    ```
    ```bash
    scoop install dotnet-sdk      #(Only on powershell)
    ```
    ```bash
    choco install dotnet-sdk -y   #(Only on powershell)
    ```
    - and check:
    ```bash
    dotnet --version
    ```

## How it works
The program creates the ``.db`` files and the relative tables automatically the first time you launch the program, on the first boot it will ask you to create a **master password** that is afterwards mixed with a salt and hashed, the salt and the hash will be saved in a ``.db`` file called ``MasterKey.db``.
Once created a password the main database, called ``Password.db``, will be initialized and you can now access it.

## Functionalitys
1. **Add a new password** – store a username/email, URL, and password.

2. **Update a password** – select by ID and update username/email, URL, or password.

3. **Delete a password** – remove a single entry by ID.

4. **Delete all passwords** – clear the database entirely.

5. **Search password** – search by keyword and display matching entries.

6. **Show all passwords** – list all stored entries.

7. **Exit** – close the program safely.

## How to use
- Clone the repository:
    ```bash
    git clone https://github.com/PsHyCo71/PasswordManager.git
    ```
- Open a terminal and navigate to the project directory

- Start the program with:
    ```bash
    dotnet run
    ```

## Security features

- The program uses SQLCipher to encrypt Passwords.db.

- Passwords are only decrypted temporarily during read/write operations.

- Master password is hashed with a salt and never stored in plain text.

⚠️ Note: This software has not been fully security-audited. Use it for testing or learning purposes only.

## DISCLAIMER
Even though the database is encrypted, I do not recommend storing real passwords here.
New hacking tools and techniques are constantly emerging, and I do not have formal cybersecurity training. I cannot guarantee the security of your data.
There may be vulnerabilities or bugs that could expose sensitive information.

If you are interested in improving the project’s security and overall functionality, see the [``CONTRIBUTING.md``](https://github.com/PsHyCo71/PasswordManager/blob/main/CONTRIBUTING.md) file.

## License
This project is licensed under the [GNU GPL v3.0](https://www.gnu.org/licenses/gpl-3.0.html)