interface IPrototype {
    instance: number;
    Clone();
}


class User implements IPrototype {
    private firstName: string;
    private lastName: string;
    private birthDay: Date;
    instance: number = 0;

    constructor(firstName: string, lastName: string, birthDay: Date) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.birthDay = birthDay;
    }

    setFirstName(name: string) {
        this.firstName = name;
    }

    Clone() {
        this.instance++;
        return new User(this.firstName + " (clone)", this.lastName + "(clone)", this.birthDay);
    }
}

const user1 = new User('Harlin', 'Acero', new Date(1991, 0, 31));
const user2 = user1.Clone();
const user3 = user1.Clone();
user2.setFirstName('Dario');

console.log(user2);
console.log(user3);
console.log(user1);