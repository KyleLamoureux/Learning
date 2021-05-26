"use strict";
/*
Typescript is basically a tool to help the developer find bugs before the code is ran, it's a static type-checker.
Static types systems decribe the shape and behaviours of what our values will be when we run our programs.
*/

// Generally not needed to include the return type, as it will be infered
function getTheNumber(): number{
    return 2;
}

// Greeter Function
function greet(person: string, date: Date){
    console.log(`Hello ${person}, today is ${date.toDateString()}!`);
}
// let myName: string = "Kyle" // Not necessary, as the type is infered
let myName = "Kyle"

greet(myName, new Date());

const names = ["Alice", "Bob", "Eve"]
names.forEach((s) => {
    console.log(s.toUpperCase());
})

/*
Two biggest strictness checks:
- noImplicitAny
    - Using any often defeats the purpose of using Typescript, as that is the Javascript experience.
      Turning this flag on will alert you of any variables whose type is implicitly inferred as any.
- strictNullChecks
    - Makes the handling of null and undefined cases explicit
*/

// Paramter's type annotation is an object type
function printCoord(pt: Point){
    console.log(`The coordinate's (x, y) is (${pt.x}, ${pt.y})`);
}
printCoord({x:3, y:7});

// Optional properties
function printName(obj: {first: string, last?: string}){
    // Typescript will warn you if you access obj.last without checking that it is not undefined
}

/* Union Type:
- Type formed from tow or more other types, representing values that may be any one of those types.
- Will only allow operations that are valid for both types. Ex., can't use toUpperCase as doens't exist for number
*/
function printId(id: ID){
    if (typeof id == "string"){
        console.log(`Your ID is : ${id.toUpperCase()}`);
    } else {
        console.log(id)
    }
}
printId(101); printId("202");

// Type Aliases and Interfaces
interface Point {
    x: number,
    y: number
};
type ID = number | string;
/*
Difference between interface and type is that a type cannot be re-opened to add new properties
vs an interface which is always extendable
Interfaces may only be used to declare the shape of object, not re-name primitives.
Should primarily use interfaces, unless you need the features from type
*/

// Literal Types
function printText(s: string, alignment: "left" | "right" | "centre"){
    // Alignment will only accept those three inputs
}

function compare(a: string, b: string): -1 | 0 | 1 {
    return a === b ? 0 : a > b ? 1 : -1;
}

interface Options {
    width: number;
}
function configure(x: Options | "auto"){
}
configure({width: 100});
configure("auto")

// Null and Undefined
function doSomething(x: string | null){
    if (x === null){
        // do nothing
    } else {
        console.log(`Hello, ${x.toUpperCase()}`);
    }
}

// Non-null Asserstion operator
// Writing `!` after any expression is effectively a type assertion that the value isn't null or undefined
function liveDangerously(x?: number | null){
    // No Error
    console.log(x!.toFixed())
}
liveDangerously(12.01)
