# Overview

**KMP Algorithm .NET** is the .NET implementation of Knuth–Morris–Pratt algorithm. The project defines a set of extension methods that apply the algorithm to strings and lists.

Unlike traditional KMP algorithm uses which are focused on string searching, the project provides a generic programming model of using KMP algorithm on [IList(T)](https://msdn.microsoft.com/zh-tw/library/5y536ey6.aspx) and [IReadOnlyList(T)](https://msdn.microsoft.com/zh-tw/library/hh192385.aspx), as long as type T is [equatable](https://msdn.microsoft.com/en-us/library/ms131187.aspx). The project also includes a "backward" version of KMP algorithm to search the last occurrence within the instance. Optional parameter [IEqualityComparer(T)](https://msdn.microsoft.com/en-us/library/ms132151.aspx) is supported to provide different comparison behavior for type T.

# Examples

Using extension methods is quite similar to [String.IndexOf](https://msdn.microsoft.com/en-us/library/k8b1470s.aspx). The following example searchs an integer array in list.

```cs
    var s = Enumerable.Range(0, 100).ToList();
    var t = new[] { 5, 6, 7, 8, 9 };

    Console.WriteLine(s.IndexOf(t)); // 5
```

Starting at a specified position is also allowed. The following example searchs an integer collection in list, starting at index 6.

```cs
    var s = Enumerable.Range(0, 100).ToList();
    var t = new[] { 10, 11, 12, 13, 14 };

    Console.WriteLine(s.IndexOf(t, 6)); // 10
```

Like [String.LastIndexOf](https://msdn.microsoft.com/en-us/library/1wdsy8fy.aspx), search starting at last position of the instance is also available. The backward version of KMP algorithm is used in the following example. 

```cs
    var s = Enumerable.Range(0, 100).ToList();
    var t = new[] { 15, 16, 17, 18, 19 };

    Console.WriteLine(s.LastIndexOf(t, 22)); // 15
```

All methods return zero-based index of the first occurrence of the specified IList(T) or IReadOnlyList(T) in another list instance, and -1 if it is not found.

# Targeting

This project currently targets .NET Core.

