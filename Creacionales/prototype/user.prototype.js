var User = /** @class */ (function () {
    function User(firstName, lastName, birthDay) {
        this.instance = 0;
        this.firstName = firstName;
        this.lastName = lastName;
        this.birthDay = birthDay;
    }
    User.prototype.setFirstName = function (name) {
        this.firstName = name;
    };
    User.prototype.Clone = function () {
        this.instance++;
        return new User(this.firstName + " (clone)", this.lastName + "(clone)", this.birthDay);
    };
    return User;
}());
var user1 = new User('Harlin', 'Acero', new Date(1991, 0, 31));
var user2 = user1.Clone();
var user3 = user1.Clone();
user2.setFirstName('Dario');
console.log(user2);
console.log(user3);
console.log(user1);
