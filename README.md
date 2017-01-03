# Overview

**KMP Algorithm .NET** is a project defining a set of extension methods that apply Knuth–Morris–Pratt (KMP) algorithm to lists.

Unlike traditional KMP algorithm uses, which are focused on string searching, the project provides a generic programming model of using KMP algorithm on [IList(T)](https://msdn.microsoft.com/zh-tw/library/5y536ey6.aspx) and [IReadOnlyList(T)](https://msdn.microsoft.com/zh-tw/library/hh192385.aspx). Caller can get a zero-based index of the first occurrence of the specified IList(T) or IReadOnlyList(T) in another list instance. Optional parameter IEqualityComparer(T) instance is also supported to provide different comparison behavior.

This project targets .NET Framework 4.5 (or above) and .NET Core.

