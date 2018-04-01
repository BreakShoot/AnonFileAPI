# AnonFileAPI

An unofficial C# API for interacting with https://anonfile.com/


## Abilities 
  - Convert link to direct download link.
  - Upload files.
  - Download files.
  - 100% standalone.
  - Contains Exception Types
  
 
# Code Examples:
___
## Convert to Direct Download Link
```c#
using (AnonFileWrapper afwAnonFileWrapper = new AnonFileWrapper())
      Console.WriteLine(afwAnonFileWrapper.GetDirectDownloadLinkFromLink("https://anonfile.com/N411B9d1bf/badstuff.txt"));

```

## Upload Files
```c#
using (AnonFileWrapper anonFileWrapper = new AnonFileWrapper())
{
    AnonFile anonFile = anonFileWrapper.UploadFile($"C:\\Users\\username\\OneDrive\\Documents\\test\\example.txt");
    Console.WriteLine("Error Code: {0}", anonFile.ErrorCode);
    Console.WriteLine("Error Message: {0}", anonFile.ErrorMessage);
    Console.WriteLine("Error Type: {0}", anonFile.ErrorType);
    Console.WriteLine("Full URL: {0}", anonFile.FullUrl);
    Console.WriteLine("Status: {0}", anonFile.Status);
    Console.WriteLine("Download URL: {0}", anonFileWrapper.GetDirectDownloadLinkFromLink(anonFile.FullUrl));
}
```

## Download Files
```c#
using (AnonFileWrapper afwAnonFileWrapper = new AnonFileWrapper())
{
      afwAnonFileWrapper.DownloadFile("https://anonfile.com/N411B9d1bf/badstuff.txt", @"C:\Users\Username\Downloads\badstuff.txt");
}
```
## Tell Types of Exceptions
```c#
using (AnonFileWrapper anonFileWrapper = new AnonFileWrapper())
{
      AnonFile anonFile = anonFileWrapper.UploadFile("C:\\Users\\username\\OneDrive\\Documents\\test\\example.txt");
      if (anonFile.ErrorCode == AnonFile.AnonExceptions.ERROR_FILE_BANNED)
          return;
}
```

