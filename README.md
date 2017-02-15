# Postcode Validation Task #


Unit Tests
----------
 
Unit tests were written against the test cases.  Nine of the tests passed and six failed (as shown in below image):

![alt tag](https://github.com/evan-ritchie/PostcodeValidator/tree/master/PostcodeValidator/img/UnitTestResults.png)



Running the Solution
--------------------

To run the solution:

* Create a new directory, "c:\code\imports"
* Copy the .exe file from your email to your desktop (or any local directory)
* Double click the .exe to run the program.  This will:
  - Untar the import_data.csv.gz (downloaded from GoogleDrive)
  - Process all the records creating the following 2 files in c:code\imports:
   - succeeded_validation.csv
   - failed_validation.csv
  - The files will be sorted by RowId (Ascending)

to c:\Code\ConsoleApps\PostcodeValidator