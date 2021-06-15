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
```c#
public class Point3D : Point{
	public int Z { get; set; }
	public Point3D(intx, int y, int z) : base(x, y){ // Super equivalent
		Z = z;
	}
}
```
Class inherits the member of its base class. Inheritance means that a class implicitly contains almost all members of its base class. A class doesn't inherit the instance and static constructors, and the finalizer.  

Enums make a return in this language, come with the ability to add combination values.   
```c#
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
```c#
(double Sum, int Count) t2 = (4.5, 3); // Without declaring names they get set to item1, item2...  
```  

## Program Building Blocks
A _method_ is a member that implements a computation or action that can be performed by an object or class.
- _static methods_ are accessed through the class.
- _instance methods_ are accessed through instances of the class.  
When the method body is a single expression, the method can be defined using a compact expression format:
```c#
public override string ToString() => "This is an object";
```  
  
  
__Value parameters__ can be optional, by specifiying a default value so that corresponding arguments can be omitted.  
__Reference parameters__ is used for passing arguments by reference. A reference parameter is declared with the `ref` modifier.
```c#
static void Swap(ref int x, ref int y){
	int temp = x;
	x = y;
	y = temp;
}
public static void SwapExample(){
	int i = 1, j = 2;
	Swap(ref i, ref j);
	Console.WriteLine($"{i} {j}"); // "2 1"
}
```

__Output Parameter__ is used for passing arguments by reference. Similar to a reference parameter, except that it doesn't require that you explicitly assign a value to the called-provided argument.
```c#
static void Divide(int x, int y, out int result, out int remainder)
{
    result = x / y;
    remainder = x % y;
}

public static void OutUsage()
{
    Divide(10, 3, out int res, out int rem);
    Console.WriteLine($"{res} {rem}");	// "3 1"
}
```

C# supports both instance and static constructors.   
- An _instance constructor_ is a member that implements the actions required to initialize an instance of a class. 
- A _static constructor_ is a member that implements the actions required to initialize a class itself when its first loaded.

**Properties:** A natural extensions of fields. Both are named members with associate types, and the syntax for accessing fields and properties is the same. However, unlike fields properties don't denote storage locations. Instead, properties have _accessors_ that specify the statements executed when their values are read or written.  

**Indexers:** A member that enables objects to be indexed in the same way as an array.  

**Events:** A event is a member that enables a class or object to provide notifications. An event is delcared like a field except that the delcaration includes an `event` keyword and the type must be a delegate type.  

**Operators:** A operator is a member that defines the meaning of applying a particular expression operator to instances of a class.  
- All must be declared as `public` and `static`

## Major Language Areas
A **delegate type** represents references to methods with a particular parameter list and return type. They make it possible to treat methods as entites that can be assigned to variables and passed as parameters.  
```c#
delegate double Function(double x);
static double[] Apply(double[] a, Function f){
	var result = new double[a.Length];
	for (int i = 0; i < a.Length; i++) result[i] = f(a[i]);
	return result;
}
double[] a = { 0.0, 0.5, 1.0 };
double[] doubles = Apply(a, (double x) => x * 2.0);
```


C# supports asynchronous programs with two keywords: `async` and `await`. 
- You add the `async` modifer to a method declaration to declare the method is asynchronus
- The `await` operator tells the compiler to asynchronously await for a result to finish.
```c#
public async Task<int> RetrieveDocsHomePage()
{
    var client = new HttpClient();
    byte[] content = await client.GetByteArrayAsync("https://docs.microsoft.com/");

    Console.WriteLine($"{nameof(RetrieveDocsHomePage)}: Finished downloading.");
    return content.Length;
}
```

## Fundamentals
A **class or record** is a reference type. When an object of the type is created, the variable to which the object is assigned holds only a reference to that memory. When the object reference is assigned to a new variable, the new variable refers to the original object.   

A **struct** is a value type. When a struct is created, the variable to which the struct is assigned holds the struct's actual data. When the struct is assigned to a new variable, it's copied. Changes made to one copy don't affect the other copy. 

In general:
- **Classes** are used to model more complex behaviour, or data that is intended to be modified after a class object is created.
- **Structs** are best suited for small data structures that contain primiarly data that isn't intended to be modified after the struct is created.
- **Record** types are for large data structures that contain primiarly data that isn't intended to be modifed after the object is created.

### Implicit types, anonymous types, and nullable value types
You can implicitly type a local variable (but not class members) by using the `var` keyword.  

It can be inconvenient to create a named tpye for simple sets of related values that you don't intend to store pass outside method boundaries. You can create *anonymous types* for this purpose.

Ordinary value types can't have a value of **null**. However, you can create *nullable value* types by appending a `?` after the type. 
- Especially useful when you're passing data to and from databases in which numeric values might be `null`.


