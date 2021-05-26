"use strict";

/* Narrowing */
function padLeft(padding: number | string, input: string): string {
    if (typeof padding === "number"){
        return new Array(padding+1).join(" ") + input; // Hover padding
    }
    return padding + input; // Hover padding
}
console.log(padLeft(5, "test1"))
console.log(padLeft("   ", "test2"))

/* Truthiness narrowing 
- 0, NaN, "", null, undefined -> all get coerced to false
*/
function getUsersOnlineMessage(numUsersOnline: number){
    if (numUsersOnline){
        return `There are ${numUsersOnline} online now`;
    }
    return "Nobody's here :(";
}
// Both of these result in `true`
Boolean("hello");
!!"world"

// Gaurding against null or undefined
function printAll(strs: string | string[] | null){
    if (strs && typeof strs === "object"){ 
        for(const s of strs){
            console.log(s);
        }
    } else if (typeof strs === "string"){
        console.log(strs)
    }
}
printAll(["hello", "world"])
printAll("hello")
printAll(null)

// Equality Narrowing
function example(x: string | number, y: string | boolean) {
    if (x === y) {
        // We can now call any 'string' method on 'x' or 'y'.
        x.toUpperCase();
        y.toLowerCase();
    } else {
        console.log(x);
        console.log(y);
    }
}

// Discriminated Unions
/*When every type in a union contains a property with literal types, Typescript considers 
  that to be a discriminated union, and can narrow out the members of the unions

  Good for representing any sort of messaging scheme in Javascript
*/
interface Circle {
    kind: "circle",
    radius: number,
}
interface Square {
    kind: "square",
    sideLength: number,
}
type Shape = Circle | Square

function getArea(shape: Shape){
    switch (shape.kind){
        case "circle":
            return Math.PI * shape.radius ** 2;
        case "square":
            return shape.sideLength ** 2;
        default:
            const _exhaustiveCheck: never = shape; // Adding a new shape will cause a problem, letting you know to update this
            return _exhaustiveCheck;
    }
}

