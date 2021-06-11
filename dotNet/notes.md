# C# Details
C# is object oriented and **component-oriented**, and has similar programming patterns to JavaScript, Java and C++. Shouldn't be to bad to learn as I have a fair amount of experience in these languages.  
#### Features
- Garbage Collection
- Nullable Types
- Exception Handling
- Lambda Expressions
- Language Integrated Query (LINQ)

## .NET Architecture
Language interoperability is a key feature of .NET. Code generated from C# can interact with code that was generated from any of myore than 20 other CTS-compliant languages. 

### Specifics
**Namespaces**
- Provide a hierarchical means of organizing C# programs and libraries. They contain types and other namespaces. A using directive that references a given namespace enables unqualified use of the types that are members of that namespace. 
**Types and Variables**
- There are two kinds of types in C#: __value types__ and __reference types__. Variables of value types directly contain their data. Variables of reference types store references to their data (objects).
	- Class: Supports single inheritance and polymorphism
	- Struct: Similar to class, but are value types and don't typically require heap allocation. 
	- Delegate: represents references to methods with a particular parameter list and return type. Delegates make it possible to treat methods as entities that can be assigned to variables and passed as parameters.

C# Programs can be stored in several source files. When a C# program is compiled, all of the source files are processed together, and the source files can freely reference each other. Conceptually, it's as if all the source files were concatenated into one large file before being processed.

## Types and Members
A class declaration may specify a base clase. Follow the class name and type parameters with a colon and the name of the base class. Omitting a base class specification is the same as deriving from type `object`  
```
public class Point3D : Point{
	public int Z { get; set; }
	public Point3D(intx, int y, int z) : base(x, y){ // Super equivalent
		Z = z;
	}
}
```
Class inherits the member of its base class. Inheritance means that a class implicitly contains almost all members of its base class. A class doesn't inherit the instance and static constructors, and the finalizer.  

Enums make a return in this language, come with the ability to add combination values.   
```
public enum Seasons{
	None = 0,
	Summer = 1,
	Autum = 2,
	Winter = 4,
	Spring = 8,
	All = Summer | Autumn | Winter | Spring 
}
var spring = Seasons.Spring;
```

C# also supports tuples, not as easy to use as in Python but still looks pretty good.  
```
(double Sum, int Count) t2 = (4.5, 3); // Without declaring names they get set to item1, item2...  
```  



