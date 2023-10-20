# UntitledRPG

An API and game engine for an interactive text-based role-playing game where players can create characters, explore worlds, and embark on epic quests.

## Table of Contents

- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [License](#license)

## Features

- Create and customize characters with various attributes.
- Explore different worlds and interact with non-player characters.
- Engage in turn-based combat with monsters and foes.
- Earn experience points, level up, and acquire new skills.
- Manage inventory, collect items, and trade with merchants.

## Getting Started

### Prerequisites

- Windows, you can install on MacOS but these instructions may not help
- [.NET Core SDK 6](https://dotnet.microsoft.com/download)
- [MySQL Server](https://dev.mysql.com/downloads/) (Use MySQL Installer 8.0.34)

### Installation

1. Install MySQL using the following as a [guide](https://www.w3schools.com/mysql/mysql_install_windows.asp)

2. Using your IDE (hopefully Visual Studio), assess your local secrets.json (right click UntitledRPG project and select "Manage User Secrets") and copy and paste the following into the file.

   ```
   {
      "ConnectionStrings": {
         "DATABASE_CONNECTION_STRING": "Server=localhost;Database=untitled_rpg;User={YOUR_USERNAME};Password={YOUR_PASSWORD};"
      }
   }
   ```

3. Replace {YOUR_USERNAME} and {YOUR_PASSWORD} with the password and username created when installing MySQL (This is NOT the root password)

4. Run Migrations by navigating to the project directory and opening the terminal. Run

   ```
   dotnet ef database update
   ```

5. Restore dependecies and build the project

6. Run the application

## License

MIT License

Copyright (c) 2023 Daniel Keith Thompson II

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
