// declaramos class por cada producto en concreto
var PhoneCpu = /** @class */ (function () {
    function PhoneCpu() {
    }
    PhoneCpu.prototype.setSeries = function (series) {
        console.log("Phone ".concat(series));
    };
    return PhoneCpu;
}());
var LaptopCpu = /** @class */ (function () {
    function LaptopCpu() {
    }
    LaptopCpu.prototype.setSeries = function (series) {
        console.log("Laptop ".concat(series));
    };
    return LaptopCpu;
}());
var TabletCpu = /** @class */ (function () {
    function TabletCpu() {
    }
    TabletCpu.prototype.setSeries = function (series) {
        console.log("Tablet ".concat(series));
    };
    return TabletCpu;
}());
var PhoneMemory = /** @class */ (function () {
    function PhoneMemory() {
    }
    PhoneMemory.prototype.setCapacityInGb = function (gb) {
        console.log("Phone ".concat(gb, "gb"));
    };
    return PhoneMemory;
}());
var LaptopMemory = /** @class */ (function () {
    function LaptopMemory() {
    }
    LaptopMemory.prototype.setCapacityInGb = function (gb) {
        console.log("Laptop ".concat(gb, "gb"));
    };
    return LaptopMemory;
}());
var TabletMemory = /** @class */ (function () {
    function TabletMemory() {
    }
    TabletMemory.prototype.setCapacityInGb = function (gb) {
        console.log("Tablet ".concat(gb, "gb"));
    };
    return TabletMemory;
}());
var PhoneDisplay = /** @class */ (function () {
    function PhoneDisplay() {
    }
    PhoneDisplay.prototype.setResolution = function () {
        console.log("Phone resolution...");
    };
    return PhoneDisplay;
}());
var LaptopDisplay = /** @class */ (function () {
    function LaptopDisplay() {
    }
    LaptopDisplay.prototype.setResolution = function () {
        console.log("Laptop resolution...");
    };
    return LaptopDisplay;
}());
var TabletDisplay = /** @class */ (function () {
    function TabletDisplay() {
    }
    TabletDisplay.prototype.setResolution = function () {
        console.log("Tablet resolution...");
    };
    return TabletDisplay;
}());
// declaramos class para fabricas concretas de productos
var PhoneFactory = /** @class */ (function () {
    function PhoneFactory() {
    }
    PhoneFactory.prototype.createCpu = function () {
        return new PhoneCpu();
    };
    PhoneFactory.prototype.createMemory = function () {
        return new PhoneMemory();
    };
    PhoneFactory.prototype.createDisplay = function () {
        return new PhoneDisplay();
    };
    return PhoneFactory;
}());
var LaptopFactory = /** @class */ (function () {
    function LaptopFactory() {
    }
    LaptopFactory.prototype.createCpu = function () {
        return new LaptopCpu();
    };
    LaptopFactory.prototype.createMemory = function () {
        return new LaptopMemory();
    };
    LaptopFactory.prototype.createDisplay = function () {
        return new LaptopDisplay();
    };
    return LaptopFactory;
}());
var TabletFactory = /** @class */ (function () {
    function TabletFactory() {
    }
    TabletFactory.prototype.createCpu = function () {
        return new TabletCpu();
    };
    TabletFactory.prototype.createMemory = function () {
        return new TabletMemory();
    };
    TabletFactory.prototype.createDisplay = function () {
        return new TabletDisplay();
    };
    return TabletFactory;
}());
// funciones de implementacion
var appFactoryNew = function (factory, serie, capacity) {
    var cpu = factory.createCpu();
    var memory = factory.createMemory();
    var display = factory.createDisplay();
    cpu.setSeries(serie);
    memory.setCapacityInGb(capacity);
    display.setResolution();
};
var createFactoryNew = function (type) {
    var factories = { phone: PhoneFactory, laptop: LaptopFactory, tablet: TabletFactory };
    var Factory = factories[type];
    return new Factory();
};
appFactoryNew(createFactoryNew("phone"), 'i3', 216);
appFactoryNew(createFactoryNew("laptop"), 'i7', 1024);
appFactoryNew(createFactoryNew("tablet"), 'i5', 216);
