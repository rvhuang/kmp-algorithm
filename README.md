# Overview

[![Build Status](https://travis-ci.org/rvhuang/kmp-algorithm.svg?branch=master)](https://travis-ci.org/rvhuang/kmp-algorithm) [![algorithm-force MyGet Build Status](https://www.myget.org/BuildSource/Badge/algorithm-force?identifier=dae1708a-833c-4128-aaa9-0811c1fe33c6)](https://www.myget.org/feed/algorithm-force/package/nuget/AlgorithmForce.Searching)

**KMP Algorithm .NET** is the .NET implementation of Knuth–Morris–Pratt algorithm. The project defines a set of extension methods that apply the algorithm to strings and lists.

Unlike traditional KMP algorithm uses which are focused on string instances, the project provides a set of generic APIs that apply KMP algorithm to [IEnumerable(T)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1), [IList(T)](https://docs.microsoft.com/en-us/dotnet/core/api/system.collections.generic.ilist-1) and [IReadOnlyList(T)](https://docs.microsoft.com/en-us/dotnet/core/api/system.collections.generic.ireadonlylist-1), as long as type ``T`` is [equatable](https://docs.microsoft.com/en-us/dotnet/core/api/system.iequatable-1). This expands the applicability of the algorithm, making searching an array of bytes in a longer array, or a collection of floats in an array of floats with same algorithm possible. In some cases, you may specify optional parameter [IEqualityComparer(T)](https://docs.microsoft.com/en-us/dotnet/core/api/system.collections.generic.iequalitycomparer-1) instance to provide different comparison behavior for type `T`.

The project also includes a "backward" version of KMP algorithm that searches the last occurrence of the target within the instance. 

## Getting Started

### Installation

    PM> Install-Package AlgorithmForce.Searching -Source https://www.myget.org/F/algorithm-force/api/v3/index.json

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

The project provides iterator pattern for forward and backward index enumeration. The following example enumerates each of indexes by calling ```IndexesOf``` and ```LastIndexesOf``` extension method.

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

In this example, caller can start enumerating each index before all indexes are found.

### Searching in Deferred Execution

The project provides a set of `IndexOf` APIs optimized for [IEnumerable(T)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1) instance that is produced in **deferred execution**. That is, the search can start before whole collection is ready. The APIs are defined in `AlgorithmForce.Searching.Deferred` namespace.

The following example shows how to search an array of numbers in `Enumerable.Range()`.

```cs
    // using AlgorithmForce.Searching.Deferred

    var s = Enumerable.Range(0, 100); // deferred execution 
    var t = new[] { 95, 96, 97, 98, 99 };

    Console.WriteLine(s.IndexOf(t)); // 95
```

A set of APIs that wrap [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader) and [BinaryReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.binaryreader) as `IEnumerable(T)` instances can be used together in order to search the collection in streamed content. The following code snippet shows how to search an array in `StringReader` by applying `AsCharEnumerable()` API.

```cs
    var s = "Vrogros, the Underlord, is a melee strength hero.";
    var t = new[] { 'U', 'n', 'd', 'e', 'r', 'l', 'o', 'r', 'd' };

    using (var reader = new StringReader(s))
    {
        Console.WriteLine(reader.AsCharEnumerable().IndexOf(t)); 
        // 13
    }
```

## Table of Features

| Search In\Search With | IEnumerable(T) | IReadOnlyList(T) | string |
|-----------------------|----------------|------------------|--------|
| IEnumerable(T)        | Not Supported  | IndexOf()        | IndexOf() |
| IReadOnlyList(T)      | Not Supported  | IndexOf(), LastIndexOf(), IndexesOf(), LastIndexesOf() | IndexOf(), LastIndexOf(), IndexesOf(), LastIndexesOf() |
| string                | Not Supported  | IndexOf(). LastIndexOf(), IndexesOf(), LastIndexesOf() | Native APIs, IndexesOf(), LastIndexesOf() |

## Future Works

* `IndexOfAny()` and `IndexesOfAll()` implementation
* Vertical Search in a collecton of collections

## Platform

This project targets [.NET Standard 1.6](https://github.com/dotnet/standard/blob/master/docs/versions/netstandard1.6.md) currently.

## License

The project is licesed under the [MIT license](LICENSE). Feel free to use and modify the code in your algorithm homeworks. 

