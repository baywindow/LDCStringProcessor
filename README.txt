To whom it may concern.

You can ignore the LDCStringProcessor project, it's a Main project but it really doesn't do much

StringLib is the project with the meat in it. It's a class library that implements the string reformatting as given in the test. It uses
the strategy pattern to implmement different classes for string formatting. ReformatStrategyLDC implements the test and I threw in
another one (ReformatStrategyOther) to show how another class might be implemented.
StringProcessor is effectively the entry point to the library and it uses the constructor to set up ReformatStrategyLDC.

LDCStringProcessorTests are the unit tests for the class library. I think I've written enough to provide a reasonable coverage and I even
wrote them before I did the library! :-)

Also knocking about GitHub (should be at the same level as this project) there's a file LDC_FootFall_SQLQuery.sql that's the SQL for the
other half of this test. Hopefully it will work on your copy of the database although it did occur to me that our creations of the tables
might be different and could potentially impact it.

If you need the script for the way I've created the tables please let me know (andy.napierhemy@gmail.com)

Thanks
Andy
