var Hero = /** @class */ (function () {
    function Hero() {
    }
    Hero.prototype.toAttack = function () {
        console.log("I'm a hero, I attack with sword");
    };
    Hero.prototype.behavior = function () {
        console.log("I'm a hero, I'm good");
    };
    Hero.prototype.makeMission = function () {
        console.log("Save the princess");
    };
    return Hero;
}());
var Villain = /** @class */ (function () {
    function Villain() {
    }
    Villain.prototype.toAttack = function () {
        console.log("I'm a villaing, I attack with weapons");
    };
    Villain.prototype.behavior = function () {
        console.log("I'm a villaing, I'm bad");
    };
    Villain.prototype.makeMission = function () {
        console.log("Kidnap the princess");
    };
    return Villain;
}());
var Princess = /** @class */ (function () {
    function Princess() {
    }
    Princess.prototype.toAttack = function () {
        console.log("I'm a princess, I not attack");
    };
    Princess.prototype.behavior = function () {
        console.log("I'm doing nothing");
    };
    Princess.prototype.makeMission = function () {
        console.log("be rescued");
    };
    return Princess;
}());
var FactoryHero = /** @class */ (function () {
    function FactoryHero() {
    }
    FactoryHero.prototype.createCharacter = function () {
        return new Hero();
    };
    return FactoryHero;
}());
var FactoryVillaing = /** @class */ (function () {
    function FactoryVillaing() {
    }
    FactoryVillaing.prototype.createCharacter = function () {
        return new Villain();
    };
    return FactoryVillaing;
}());
var FactoryPrincess = /** @class */ (function () {
    function FactoryPrincess() {
    }
    FactoryPrincess.prototype.createCharacter = function () {
        return new Princess();
    };
    return FactoryPrincess;
}());
function executeFactory(factory) {
    var character = factory.createCharacter();
    character.toAttack();
    character.behavior();
    character.makeMission();
}
function creatreCharacter(type) {
    var factories = {
        hero: FactoryHero,
        villain: FactoryVillaing,
        princess: FactoryPrincess
    };
    var factory = factories[type];
    return new factory();
}
executeFactory(creatreCharacter('hero'));
executeFactory(creatreCharacter('villain'));
executeFactory(creatreCharacter('princess'));
