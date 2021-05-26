/* Simplest way to describe a function is with a function type expression */
// fn: (a: string) => void ... means a function with one paramter, named a, of type string
// that doesn't have a return value
type GreetFunction = (a: string) => void; // Could also be done like this
function greeter(fn: (a: string) => void) {
    fn("Hello, World");
}
function printToConsole(s: string){
    console.log(s);
}

greeter(printToConsole)

/* Generic Functions */
function firstElement<Type>(arr: Type[]): Type{
    return arr[0];
}
const s = firstElement(["a", "b"]);
const n = firstElement([1, 2])

/* Inference */
function map<Input, Output>(arr: Input[], func: (arg: Input) => Output): Output[]{
    return arr.map(func);
}
// Of type 'number[]'
const parsed = map(["1", "2", "3"], (n) => parseInt(n));

/* Constraints */
function longest<Type extends {length: number}>(a: Type, b: Type){
    if(a.length >= b.length){
        return a;
    } else {
        return b;
    }
}
const longerArray = longest([1,2], [1,2,3])
const longerString = longest("alice", "bob")
// const notOk = longest(10, 100);
