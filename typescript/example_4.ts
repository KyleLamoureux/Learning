/* Object Types
In JavaScript, the fundament way that data is passed is through objects.
*/

interface Person {
    name: string,
    age: number
}
function greet(person: Person) {
    return "Hello " + person.name
}

/* Index Signatures */
interface StringArray {
    [index: number]: string | number;
    length: number; // Ok, length is a number
    name: string; // Ok, name is a string
}

/* Extending Types: Possible to multi extend could also potentially use Intersections in some cases*/
interface BasicAddress {
    name?: string;
    street: string;
    city: string;
    country: string;
    postalCode: string;
}

interface AddressWithUnit extends BasicAddress {
    unit: string;
}

/* Generics */
interface Box<Type> {
    contents: Type;
}
let box: Box<string> = { contents: "hello" };
box.contents;

function setContents<Type>(box: Box<Type>, newContents: Type){
    box.contents = newContents;
}

const roArray: ReadonlyArray<string> = ["red", "green", "blue"];

/* Tuples */
interface StringNumberPair {
    // specialized properties
    length: 2;
    0: string;
    1: number;

    // Other 'Array<string | number>' members...
    slice(start?: number, end?: number): Array<string | number>;
}

// Rest elements in tuples:
function readButtonInput(...args: [string, number, ...boolean[]]){
    const [name, version, ...input] = args;
}

