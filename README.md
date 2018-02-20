# AnonFileAPI

An unofficial C# API for interacting with https://anonfile.com/


What can this do? 
  - Convert link to direct download link.
  - Upload files.
  - Download files.
  
 
# Code Examples:
___
## Convert to Direct Download Link
```c#
using (AnonFileWrapper afwAnonFileWrapper = new AnonFileWrapper())
{
      Console.WriteLine(afwAnonFileWrapper.GetDirectDownloadLinkFromLink("https://anonfile.com/N411B9d1bf/badstuff.txt"));
}
Console.ReadKey();
```

## Upload Files
```c#
using (AnonFileWrapper afwAnonFileWrapper = new AnonFileWrapper())
{
      AnonFile afAnonFile = afwAnonFileWrapper.UploadFile(@"C:\\something.exe");
      if (afAnonFile.isGoodResponse())
      {
          Console.WriteLine("Full URL: " + afAnonFile.GetFullURL());
          Console.WriteLine("Short URL: " + afAnonFile.GetShortURL());
          Console.WriteLine("Bytes: " + afAnonFile.GetAmountOfBytes());
      }
      else
      {
          Console.WriteLine("Exception Message: " + afAnonFile.GetErrorMessage());
      }
}
Console.ReadKey();
```

## Download Files
```c#
using (AnonFileWrapper afwAnonFileWrapper = new AnonFileWrapper())
{
      afwAnonFileWrapper.DownloadFile("https://anonfile.com/N411B9d1bf/badstuff.txt", @"C:\Users\Username\Downloads\badstuff.txt");
}
```
