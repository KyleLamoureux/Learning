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

/* Guidelines for writing good generic functions 
- Push type parameters down
- Use fewer type parameters
- Type parameters should appear twice
*/

/* Optional Parameters */
function f(x?: number){}
function f2(x = 10){} // Default

/* Callbacks */
function myForEach(arr: any[], callback: (arg: any, index: number) => void){
    for(let i = 0; i < arr.length; i++){
        callback(arr[i], i)
    }
}
myForEach([1,2,3], (a, i) => {
    console.log(i.toFixed());
})

/* Declaring This in a function */
const user = {
    id: 123,
    admin: false,
    becomeAdmin: function() {
        this.admin = true;
    },
};
/*
interface DB {
    filterUsers(filter: (this: User) => boolean): User[];
}
const db = getDb();
const admins = db.filterUsers(function (this: User) {
    return this.admin;
})
*/

/* Rest Arguments: This is really cool */
const arr1 = [1,2,3];
const arr2 = [4,5,6];
arr1.push(...arr2);
console.log(arr1);

/* Parameter Destruction */
type ABC = {a: number; b: number; c:number};
function sum({a, b, c}: ABC){
    console.log(a + b + c);
}

