# LMS

## Dewey Decimal System Training Application

This web application application is designed to make learning about the Dewey Decimal System fun and engaging for library staff and novice librarians. The application allows users to practice and improve their skills in identifying broad areas, finding call numbers, and correctly replacing books on library shelves.

Live site: [Web App](https://lms2023.azurewebsites.net/)


## Table of Contents

- [Features](#features)
- [Usage](#usage-instructions)
   - [Prerequisites](#prerequisites)
   - [Compilation](#compilation)

     
## Features

1. **Choose a Task:**
   - On startup, the application allows users to choose between three tasks:
     - Replacing books.
     - Identifying areas.
     - Finding call numbers.
   - For now, only the "Replacing books" task is implemented.

2. **Replacing Books:**
   - When the user selects "Replacing books," the application randomly generates 10 different call numbers and displays them to the user.
   - Users can reorder the call numbers in ascending order.
   - The application checks whether the user placed the call numbers in the correct ascending order.
   - Different levels are included to motivate users to continue learning.


## Usage Instructions

To compile and run the Dewey Decimal System Training Application, follow these steps:

### Prerequisites

- Visual Studio 2019
- .NET 6.0

### Compilation

1. Clone this repository to your local machine:

   ```bash
   git clone https://github.com/TrinityJayd/LMS.git
   ```

2. Open your terminal or command prompt and navigate to the project's root directory:

   ```bash
   cd LMS
   ```

3. Compile the application using the .NET CLI:

   ```bash
   dotnet build
   ```

### Running the Application

4. Run the application:

   ```bash
   dotnet run
   ```


[🔝 Back to Top](#lms)
