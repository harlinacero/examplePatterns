class Car {
    run() {
        throw "Must be implemented";
    }
}

class Mazda extends Car {
    run() {
        console.log("Mazda is running");
    }
}

class Chevrolet extends Car {
    run() {
        console.log("Chevrolet is Running")
    }
}


class FactoryCar {
    create() {
        throw 'Must implement';
    }
}

class FactoryMazda extends FactoryCar {
    create() {
        return new Mazda();
    }
}

class FactoryChevrolet extends FactoryCar {
    create() {
        return new Chevrolet();
    }
}


function execute(factory) {
    const car = factory.create()
    car.run()
}


// execute(new FactoryMazda())

function creatreFactory(type) {
    const factories = {
        mazda: FactoryMazda,
        chevrolet: FactoryChevrolet
    }

    const factory = factories[ type ];
    return new factory();
}

execute(creatreFactory("mazda"));
execute(creatreFactory("chevrolet"));

