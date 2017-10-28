# Overview

[![Build Status](https://travis-ci.org/rvhuang/kmp-algorithm.svg?branch=master)](https://travis-ci.org/rvhuang/kmp-algorithm)

**KMP Algorithm .NET** is the .NET implementation of Knuth–Morris–Pratt algorithm. The project defines a set of extension methods that apply the algorithm to strings and lists.

Unlike traditional KMP algorithm uses which are focused on string searching, the project provides a generic programming model of using KMP algorithm on [IList(T)](https://docs.microsoft.com/en-us/dotnet/core/api/system.collections.generic.ilist-1) and [IReadOnlyList(T)](https://docs.microsoft.com/en-us/dotnet/core/api/system.collections.generic.ireadonlylist-1), as long as type T is [equatable](https://docs.microsoft.com/en-us/dotnet/core/api/system.iequatable-1). This expands the applicability of the algorithm, making searching an array of bytes in a longer array, or a collection of floats in an array of floats with same algorithm possible. In some cases, you may specify optional parameter [IEqualityComparer(T)](https://docs.microsoft.com/en-us/dotnet/core/api/system.collections.generic.iequalitycomparer-1) instance to provide different comparison behavior for type T.

The project also includes a "backward" version of KMP algorithm that searches the last occurrence of the target within the instance. 

## Getting Started

### First and Last Index Search

Using the extension method is similar to [String.IndexOf](https://docs.microsoft.com/en-us/dotnet/core/api/system.string#System_String_IndexOf_System_String_), as following example shows.

```cs
    var s = Enumerable.Range(0, 100).ToList();
    var t = new[] { 5, 6, 7, 8, 9 };

    Console.WriteLine(s.IndexOf(t)); // 5
```

Because [List(T)](https://docs.microsoft.com/en-us/dotnet/core/api/system.collections.generic.list-1) and array implements IReadOnlyList(T) interface, and [Int32](https://docs.microsoft.com/en-us/dotnet/core/api/system.int32) is equatable, the extension method ```IndexOf``` is available for search.

Starting at a specified position is also supported. The following example searches an array of integer in collection, starting at index 6.

```cs
    var s = Enumerable.Range(0, 100).ToArray();
    var t = new List<int> { 10, 11, 12, 13, 14 };

    Console.WriteLine(s.IndexOf(t, 6)); // 10
```

Similar to [String.LastIndexOf](https://docs.microsoft.com/en-us/dotnet/core/api/system.string#System_String_LastIndexOf_System_String_), you can also search the last occurrence of target array in the collection. 
The backward version of KMP algorithm is used in the following example.

```cs
    var s = Enumerable.Range(0, 100).ToList();
    var t = new List<int> { 15, 16, 17, 18, 19 };

    Console.WriteLine(s.LastIndexOf(t)); // 15
``` 

### Index Enumeration

The project provides iterator pattern for forward and backward index enumeration. The following example enumerates each of indexes by calling ```IndexesOf``` and ```LastIndexesOf``` method.

```cs
    var s = "1231abcdabcd123231abcdabcdabcdtrefabc";
    var t = new List<char> { 'a', 'b', 'c', 'd', 'a', 'b', 'c', 'd'};

    foreach (var index in s.IndexesOf(t))
    {
        Console.WriteLine(index); // 4, 18, 22
    }

    foreach (var index in s.LastIndexesOf(t))
    {
        Console.WriteLine(index); // 22, 18, 4
    }
```

In this example, caller can start enumerating the collection of indexes before all indexes are found.

## Future Works

* Full documentation comments and Nuget package.
* `IndexOfAny` implementation.

## Platform

This project currently targets .NET Core only.

