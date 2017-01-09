# Overview

**KMP Algorithm .NET** is the .NET implementation of Knuth–Morris–Pratt algorithm. The project defines a set of extension methods that apply the algorithm to strings and lists.

Unlike traditional KMP algorithm uses which are focused on string searching, the project provides a generic programming model of using KMP algorithm on [IList(T)](https://docs.microsoft.com/en-us/dotnet/core/api/system.collections.generic.ilist-1) and [IReadOnlyList(T)](https://docs.microsoft.com/en-us/dotnet/core/api/system.collections.generic.ireadonlylist-1), as long as type T is [equatable](https://docs.microsoft.com/en-us/dotnet/core/api/system.iequatable-1). The project also includes a "backward" version of KMP algorithm to search the last occurrence within the instance. Optional parameter [IEqualityComparer(T)](https://docs.microsoft.com/en-us/dotnet/core/api/system.collections.generic.iequalitycomparer-1) is supported to provide different comparison behavior for type T.

# Getting Started

Using extension methods is quite similar to [String.IndexOf](https://docs.microsoft.com/en-us/dotnet/core/api/system.string#System_String_IndexOf_System_String_). The following example searchs an integer array in list.

```cs
    var s = Enumerable.Range(0, 100).ToList();
    var t = new[] { 5, 6, 7, 8, 9 };

    Console.WriteLine(s.IndexOf(t)); // 5
```
Because [List(T)](https://docs.microsoft.com/en-us/dotnet/core/api/system.collections.generic.list-1) and array implemented IReadOnlyList(T) and integer is equatable, the extension method IndexOf is available for search.

Starting at a specified position is also allowed. The following example searchs an integer collection in list, starting at index 6.

```cs
    var s = Enumerable.Range(0, 100).ToList();
    var t = new[] { 10, 11, 12, 13, 14 };

    Console.WriteLine(s.IndexOf(t, 6)); // 10
```
Both methods above return zero-based index of the first occurrence of the specified IList(T) or IReadOnlyList(T) in another list instance, and -1 if it is not found.

Like [String.LastIndexOf](https://docs.microsoft.com/en-us/dotnet/core/api/system.string#System_String_LastIndexOf_System_String_), search starting at last position of the instance is also available. The backward version of KMP algorithm is used in the following example. 

```cs
    var s = Enumerable.Range(0, 100).ToList();
    var t = new[] { 15, 16, 17, 18, 19 };

    Console.WriteLine(s.LastIndexOf(t, 22)); // 15
``` 

# Targeting

This project currently targets .NET Core.

