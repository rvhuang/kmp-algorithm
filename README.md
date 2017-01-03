# Knuth–Morris–Pratt Algorithm .NET

This project consists of a set of extension methods using Knuth–Morris–Pratt (KMP) algorithm. Unlike traditional KMP algorithm uses, which are focused on string searching, this project provides a generic programming model of using KMP algorithm on IList(T) and IReadOnlyList(T). Caller can get a zero-based index of the first occurrence of the specified IList(T) or IReadOnlyList(T) in another list instance. Caller is also allowed to specify an IEqualityComparer(T) instance to provide different comparison behavior.

This project supports .NET Framework 4.5 and .NET Core.

