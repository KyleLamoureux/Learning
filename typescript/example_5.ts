/* Classes */
class Point {
    x=0;
    y=0;
}
const pt = new Point();
pt.x = 0; 
pt.y = 0;

console.log(pt)

class GoodGreeter {
    name: string;
    test!: string; // not inialized, but no error

    constructor() {
        this.name = "hello"
    }
}
const gg = new GoodGreeter();
console.log(gg)

/* Index Signatures */
class MyClass {
    [s: string]: boolean | ((s: string) => boolean);
    
    check(s: string) {
        return this[s] as boolean;
    }
}

/* Generic Classes */
class Box<Type> {
    contents: Type;
    constructor(value: Type){
        this.contents = value;
    }
}
const b = new Box("hello!");

/* Prevent losing class context */
class MyClass2 {
    name = "MyClass2";
    getName = () => { // Arrow function is the trick
        return this.name;
    };
}
const c = new MyClass2();
const g = c.getName;
console.log(g());

/* This */
class Box2 {
    content: string = "";
    sameAs(other: this) {
        return other.content === this.content;
    }
}
class DerivedBox extends Box2 {
    otherContent: string = "?";
}

const base = new Box2();
const derived = new DerivedBox();
// derived.sameAs(base); // Error

/* Parameter Properties */
class Params {
    constructor(
        public readonly x: number,
        protected y: number,
        private z: number,
    ){}
}
const a = new Params(1, 2, 3);
console.log(a.x);
// console.log(a.z); // Error as it's private

/*
Big take away:
- Familar with the vast majority of concepts discussed given I've taken OO
- If I'm ever in need of writing OO TypeScript, I'll be sure to reference this for best practices.
  Other than that it was a big refresher in OO principles in the flavour of TypeScript.
*/