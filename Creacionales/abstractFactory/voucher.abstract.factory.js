/**
 * How to implement Abstract Factory?
 *
 * 1. Declare base products classes/interfaces for each product
 *  in the catalog.
 *
 * Base products:
 *  - Product
 *  - Service
 */
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var Product = /** @class */ (function () {
    /**
     *
     */
    function Product(unitValue, quantity, tax) {
        this.quantity = quantity;
        this.unitValue = unitValue;
        this.tax = tax;
    }
    return Product;
}());
var Service = /** @class */ (function () {
    /**
     *
     */
    function Service(value, disccount) {
        this.disccount = disccount;
        this.value = value;
    }
    return Service;
}());
/**
 * 2. Implement concrete products classes that inherits/implements
 *  base products classes/interfaces, the number of concrete prodcuts
 *  will depend on the number of families.
 *
 * Concrete products:
 *  - ProductBasic
 *  - ProductAdvanced
 *  - ServiceBasic
 *  - ServiceAdvance
 */
var ProductBasic = /** @class */ (function (_super) {
    __extends(ProductBasic, _super);
    function ProductBasic() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    ProductBasic.prototype.getPrice = function () {
        return this.calculateGross() + this.calculateTax();
    };
    ProductBasic.prototype.getInvoice = function () {
        console.log("--------Facture -------");
        console.log("--------Product Basic -------");
        console.log("Total Gross: " + this.calculateGross());
        console.log("Total Tax: " + this.calculateTax());
        console.log("Total Price: " + this.getPrice());
    };
    ProductBasic.prototype.calculateTax = function () {
        var total = (this.calculateGross() * this.tax) / 100;
        return total;
    };
    ProductBasic.prototype.calculateGross = function () {
        var total = this.unitValue * this.quantity;
        return total;
    };
    return ProductBasic;
}(Product));
var ProductAdvanced = /** @class */ (function (_super) {
    __extends(ProductAdvanced, _super);
    /**
     *
     */
    function ProductAdvanced(unitValue, quantity, tax, taxadd2, discount) {
        var _this = _super.call(this, unitValue, quantity, tax) || this;
        _this.taxAdd2 = taxadd2;
        _this.discount = discount;
        return _this;
    }
    ProductAdvanced.prototype.getPrice = function () {
        return this.calculateGross() + this.calculateTax() - this.discount;
    };
    ProductAdvanced.prototype.getInvoice = function () {
        console.log("--------Facture -------");
        console.log("--------Product Advance -------");
        console.log("Total Gross: " + this.calculateGross());
        console.log("Total Disccount: " + this.discount);
        console.log("Total Tax: " + this.calculateTax());
        console.log("Total Price: " + this.getPrice());
    };
    ProductAdvanced.prototype.calculateTax = function () {
        return (this.calculateGross() * this.tax / 100) + (this.calculateGross() * this.taxAdd2 / 100);
    };
    ProductAdvanced.prototype.calculateGross = function () {
        return this.unitValue * this.quantity;
    };
    return ProductAdvanced;
}(Product));
var ServiceBasic = /** @class */ (function (_super) {
    __extends(ServiceBasic, _super);
    function ServiceBasic() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    ServiceBasic.prototype.getPrice = function () {
        return this.value - this.disccount;
    };
    ServiceBasic.prototype.getInvoice = function () {
        console.log("--------Facture -------");
        console.log("--------Service Basic -------");
        console.log("Total Gross: " + this.value);
        console.log("Total Disccount: " + this.disccount);
        console.log("Total Price: " + this.getPrice());
    };
    return ServiceBasic;
}(Service));
var ServiceAdvance = /** @class */ (function (_super) {
    __extends(ServiceAdvance, _super);
    function ServiceAdvance(value, disccount, tax) {
        var _this = _super.call(this, value, disccount) || this;
        _this.tax = tax;
        return _this;
    }
    ServiceAdvance.prototype.getPrice = function () {
        return this.calculatePrice() - this.disccount;
    };
    ServiceAdvance.prototype.calculatePrice = function () {
        return this.value + this.calculateTax();
    };
    ServiceAdvance.prototype.calculateTax = function () {
        return (this.value * this.tax) / 100;
    };
    ServiceAdvance.prototype.getInvoice = function () {
        console.log("--------Facture -------");
        console.log("--------Service Advance -------");
        console.log("Total Gross: " + this.calculatePrice());
        console.log("Total Tax: " + this.calculateTax());
        console.log("Total Disccount: " + this.disccount);
        console.log("Total Price: " + this.getPrice());
    };
    return ServiceAdvance;
}(Service));
/**
* 4. Create concrete factories that implements/inherits from the
*  abstract factory behaviour and implements all the products creation
*  methods. The number of concrete factories will depend of the number
*  of product families.
*
* Concrete Factories:
*  - BasicStoreFactory
*  - AdvanceStoreFactory
*
*/
var BasicStoreFactory = /** @class */ (function () {
    /**
     *
     */
    function BasicStoreFactory(unitValue, quantity, tax, disccount) {
        this.unitvalue = unitValue;
        this.quantity = quantity;
        this.tax = tax;
        this.disccount = disccount;
    }
    BasicStoreFactory.prototype.createProduct = function () {
        return new ProductBasic(this.unitvalue, this.quantity, this.tax);
    };
    BasicStoreFactory.prototype.createService = function () {
        return new ServiceBasic(this.unitvalue, this.disccount);
    };
    return BasicStoreFactory;
}());
var AdvanceStoreFactory = /** @class */ (function () {
    function AdvanceStoreFactory(unitValue, quantity, tax, taxAdd2, disccount) {
        this.unitvalue = unitValue;
        this.quantity = quantity;
        this.tax = tax;
        this.taxAdd2 = taxAdd2;
        this.disccount = disccount;
    }
    AdvanceStoreFactory.prototype.createProduct = function () {
        return new ProductAdvanced(this.unitvalue, this.quantity, this.tax, this.taxAdd2, this.disccount);
    };
    AdvanceStoreFactory.prototype.createService = function () {
        return new ServiceAdvance(this.unitvalue, this.disccount, this.taxAdd2);
    };
    return AdvanceStoreFactory;
}());
// Main
function appStoreFactory(factory) {
    var product = factory.createProduct();
    var service = factory.createService();
    //
    product.getInvoice();
    var productPrice = product.getPrice();
    console.log("price ".concat(productPrice));
    service.getInvoice();
    var servicePrice = service.getPrice();
    console.log("price ".concat(servicePrice));
}
var Store = /** @class */ (function () {
    function Store() {
    }
    return Store;
}());
function createFactory(type, store) {
    var factories = {
        basic: BasicStoreFactory,
        advance: AdvanceStoreFactory
    };
    var Factory = factories[type];
    return new Factory(store.unitValue, store.quantity, store.tax, store.taxAdd2, store.disccount);
}
var store1 = {
    unitValue: 10000,
    quantity: 2,
    tax: 19,
    taxAdd2: 5,
    disccount: 2000
};
appStoreFactory(createFactory('basic', store1));
appStoreFactory(createFactory('advance', store1));
