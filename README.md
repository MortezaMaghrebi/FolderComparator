# FolderComparator
This application compares two C/C++ or C# projects file by file.

### for example:
If one project has a file named "file1.c", the application searches for a file named "file1.c" in the second project and then compares the contents of both files.

### Notepad++ Integration:
You can use the Notepad++ Compare plugin to visualize the differences between the compared files.

The application can optionally beautify the code (improve formatting) and remove comments before comparing the files.

## How to use
### 1. Browse the First Project Folder:
Click the top "Open" button to select the folder containing the first project.

### 2. Browse the Second Project Folder:
Click the bottom "Open" button to select the folder containing the second project.

## Comparison Options:
### Remove Comments:
This option removes comments from the code before comparison.
### Beautify Code:
This option improves the formatting of the code before comparison.

The selected options are applied when you click the "Compare" button.

## Compare Results:

Clicking the "Compare" button displays a list of all files with differences in the right-hand list box.

Double-clicking an item in the list box opens both files (original and modified) in Notepad++ for further analysis.

## How to Use Notepad++ Compare Tool
### 1. Install Notepad++ Compare Plugin:

The Compare plugin is not included in the default Notepad++ installation. You need to install it separately.

### 2. Change Compare Shortcut (Optional):

The default shortcut for comparing files in Notepad++ is Alt+Ctrl+C. You can change this shortcut to Ctrl+Shift+C to integrate with the application.

### Here's how to change the compare shortcut in Notepad++:
Open Notepad++.
Go to the Settings menu.
Select Shortcut Mapper.
Click on the Plugin Commands tab.
Find the "Compare" command and change the shortcut to Ctrl+Shift+C.
Click Save to apply the changes.


