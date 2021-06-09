/* Modules 
JavaScript specification declares that any JavaScript files without an export or top-level await should be considered a script and not
a module. 
If you have a file that doesn't currently have any imports and exports, but you want to be treated as a module, add the line:
- export {};

3 Main things to consider when writing module-based code in TypeScript:
- Syntax: what syntax do I want to use to import and export things?
- Module Resolution: What is the relationship between module names (or paths) and files on disk?
- Module Output Target: What should my emitted JavaScript module look like?
*/

// Main export declared via 
export default function helloWorld(){
    console.log("Hello world!");
}
// But can have as many as you like by omited defalt
export var pi = 3.14
export function absolute(num: number){
    return (num < 0 ? num * -1 : num);
}

/* Puttin all the imported objects into the same namespace */
// import * as math from ".math.js";
// console.log(math.pi);
// const positivePhi = math.absolute(math.phi)

// CommonJS vs ES2020. Web developement man. Looks like I only dipped my toes into dependency management. 