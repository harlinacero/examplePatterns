interface Character {
    toAttack();
    behavior();
    makeMission();
}

class Hero implements Character {
    
    toAttack() {
        console.log("I'm a hero, I attack with sword")
    }
    behavior() {
        console.log("I'm a hero, I'm good");
    }
    makeMission() {
        console.log("Save the princess");
    }
}


class Villain implements Character {
    
    toAttack() {
        console.log("I'm a villaing, I attack with weapons")
    }
    behavior() {
        console.log("I'm a villaing, I'm bad");
    }
    makeMission() {
        console.log("Kidnap the princess");
    }
}

class Princess implements Character {
    
    toAttack() {
        console.log("I'm a princess, I not attack")
    }
    behavior() {
        console.log("I'm doing nothing");
    }
    makeMission() {
        console.log("be rescued");
    }
}


interface FactoryCharacter {
    createCharacter(): Character;
}

class FactoryHero implements FactoryCharacter{
    createCharacter(): Character {
        return new Hero();
    }
}

class FactoryVillaing implements FactoryCharacter{
    createCharacter(): Character {
        return new Villain();
    }
}

class FactoryPrincess implements FactoryCharacter{
    createCharacter(): Character {
        return new Princess();
    }
}

function executeFactory(factory: FactoryCharacter) {
    const character = factory.createCharacter();
    character.toAttack();
    character.behavior();
    character.makeMission();
}



type FactoryType = "hero"| "villain"|"princess";
function creatreCharacter(type: FactoryType) {
    const factories = {
        hero: FactoryHero,
        villain: FactoryVillaing,
        princess: FactoryPrincess
    }

    const factory = factories[ type ];
    return new factory();
}

executeFactory(creatreCharacter('hero'));
executeFactory(creatreCharacter('villain'));
executeFactory(creatreCharacter('princess'));