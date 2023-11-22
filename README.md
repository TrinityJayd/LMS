# LMS

## Dewey Decimal System Training Application

This web application application is designed to make learning about the Dewey Decimal System fun and engaging for library staff and novice librarians. The application allows users to practice and improve their skills in identifying broad areas, finding call numbers, and correctly replacing books on library shelves.

Live site: [Web App](https://lms2023.azurewebsites.net/)


## Table of Contents

- [Features](#features)
  - [Updates Part 2](#updates-part-2)
  - [Updates Part 3](#updates-part-3)
- [Usage](#usage-instructions)
   - [Prerequisites](#prerequisites)
   - [Compilation](#compilation)
- [Screenshots](#screenshots)

     
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

### Updates Part 2
----
1. **Enabling the Identifying Areas Task**
   - In this update, the "Identifying Areas" task is enabled.

   
2. **User-Friendly Interface for Matching Columns**
   - Upon selecting the "Identifying Areas" task, users will encounter an intuitive user interface. The interface allows users to engage in a column-matching challenge involving call numbers (top level only) and descriptions.


3. **User-Driven Questions**
   - Users now have the freedom to answer as many questions as they desire.

  
4. **Alternating Question Types**
   - They alternate between matching descriptions to call numbers and call numbers to descriptions.


5. **Randomized Item Selection**
   - Each question is a unique challenge with four randomly selected items in the first column.
   - The second column presents seven potential answers, including three incorrect ones, offering a dynamic and engaging experience.

  
   **Note: In this context, a "question" encompasses the entire column-matching set, including both columns.**


6. **Gamification for User Motivation**
   - The timer and levels have been reused for gamification

  
7. **Efficient Data Storage**
   - Call numbers and their corresponding descriptions are efficiently stored in a dictionary, ensuring optimal data management and retrieval.

### Updates Part 3
----
1. **Incorporation of Finding Call Numbers Task**
    - Enabled the "Finding Call Numbers" task, allowing users to delve into the hierarchical Dewey Decimal classification system.

2. **Dynamic Quiz Structure**
    - Created a quiz mechanism where users encounter third-level entries, select from top-level options, and progress based on correct answers.

3. **Memory Loading of Dewey Decimal Data**
    - Implemented loading of Dewey Decimal classification data into application memory from a JSON file, ensuring efficient data access.

4. **Tree-Based Data Storage**
    - Utilized a tree structure to efficiently store and manage Dewey Decimal classification data within the application.


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

## Screenshots


**Landing Page**


<img src="Demo Images/landing.png" alt="Game 1" width="1000" height="600" />


**Options**


<img src="Demo Images/options.png" alt="Game 1" width="1000" height="600" />


**Sort Call Numbers Page**


<img src="Demo Images/sorting.png" alt="Game 1" width="1000" height="600" />


**Identifying Areas Page**


<img src="Demo Images/identifying.png" alt="Game 1" width="1000" height="600" />


**Finding Call Numbers Page**


<img src="Demo Images/finding.png" alt="Game 1" width="1000" height="600" />

[🔝 Back to Top](#lms)
