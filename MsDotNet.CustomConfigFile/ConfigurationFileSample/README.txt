
[Semi Custom Section]
If you want to see  built in Sections, then go to http://msdn.microsoft.com/en-us/library/system.configuration.appsettingssection.aspx. 
At the end of the page there is a list of subclasses of Section, technically they're available.


[Totally Custom Section]
Writing a custom section requires you to write code. There is a tool for quick edition at https://csd.codeplex.com/
It really improves edition and additionally features:
- Supports from VS2008 tto VS2012
- XSD generation (which let validate configuration file, mark sections as required, and support documentation)
- Integration with VS (can be under source control, XSD is interpreted by tools when editing configurtion files)
- It takes advantage of built-in .NET types, type converters etc.

