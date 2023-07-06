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

abstract class Product {
    protected unitValue: number;
    protected quantity: number;
    protected tax: number;
    /**
     *
     */
    constructor(unitValue: number, quantity: number, tax: number) {
        this.quantity = quantity;
        this.unitValue = unitValue;
        this.tax = tax;
    }

    abstract getPrice(): number;
    abstract getInvoice(): void;
}

abstract class Service {
    protected value: number;
    protected disccount: number;

    /**
     *
     */
    constructor(value: number, disccount: number) {
        this.disccount = disccount;
        this.value = value;
    }

    abstract getPrice(): number;
    abstract getInvoice(): void;
}

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
class ProductBasic extends Product {

    getPrice(): number {
        return this.calculateGross() + this.calculateTax();
    }
    getInvoice(): void {
        console.log("--------Facture -------");
        console.log("--------Product Basic -------");
        console.log("Total Gross: " + this.calculateGross());
        console.log("Total Tax: " + this.calculateTax());
        console.log("Total Price: " + this.getPrice());

    }

    private calculateTax(): number {
        const total = (this.calculateGross() * this.tax) / 100;
        return total;
    }

    private calculateGross(): number {
        const total = this.unitValue * this.quantity;
        return total;
    }
}

class ProductAdvanced extends Product {
    private taxAdd2: number;
    private discount: number;

    /**
     *
     */
    constructor(unitValue: number, quantity: number, tax: number, taxadd2: number, discount: number) {
        super(unitValue, quantity, tax);
        this.taxAdd2 = taxadd2;
        this.discount = discount;
    }

    getPrice(): number {
        return this.calculateGross() + this.calculateTax() - this.discount;
    }

    getInvoice(): void {
        console.log("--------Facture -------");
        console.log("--------Product Advance -------");
        console.log("Total Gross: " + this.calculateGross());
        console.log("Total Disccount: " + this.discount);
        console.log("Total Tax: " + this.calculateTax());
        console.log("Total Price: " + this.getPrice());

    }

    private calculateTax(): number {
        return (this.calculateGross() * this.tax / 100) + (this.calculateGross() * this.taxAdd2 / 100);
    }

    private calculateGross(): number {
        return this.unitValue * this.quantity;
    }
}

class ServiceBasic extends Service {


    getPrice(): number {
        return this.value - this.disccount;
    }

    getInvoice(): void {
        console.log("--------Facture -------");
        console.log("--------Service Basic -------");
        console.log("Total Gross: " + this.value);
        console.log("Total Disccount: " + this.disccount);
        console.log("Total Price: " + this.getPrice());
    }

}

class ServiceAdvance extends Service {
    private tax: number;

    constructor(value: number, disccount: number, tax: number) {
        super(value, disccount);
        this.tax = tax;
    }

    getPrice(): number {
        return this.calculatePrice() - this.disccount;
    }


    private calculatePrice() {
        return this.value + this.calculateTax();
    }

    private calculateTax() {
        return (this.value * this.tax) / 100;
    }

    getInvoice(): void {
        console.log("--------Facture -------");
        console.log("--------Service Advance -------");
        console.log("Total Gross: " + this.calculatePrice());
        console.log("Total Tax: " + this.calculateTax());
        console.log("Total Disccount: " + this.disccount);
        console.log("Total Price: " + this.getPrice());
    }

}


/** 3. Declare abstract factory class/interface that declare creation
*  methods for each base product. The return value could be the base
*  products types or concrete products types.
*
* Abstract Factory:
*   - StoreAbastractFactory
*     createProduct(): Product;
*     createService(): Service;
*/


interface StoreAbastractFactory {
    createProduct(): Product;
    createService(): Service;
}



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
class BasicStoreFactory implements StoreAbastractFactory {
    private readonly unitvalue: number;
    private readonly quantity: number;
    private readonly tax: number;
    private readonly disccount: number;

    /**
     *
     */
    constructor(unitValue: number, quantity: number, tax: number, disccount: number) {
        this.unitvalue = unitValue;
        this.quantity = quantity;
        this.tax = tax;
        this.disccount = disccount;
    }

    createProduct(): Product {
        return new ProductBasic(this.unitvalue, this.quantity, this.tax);
    }

    createService(): Service {
        return new ServiceBasic(this.unitvalue, this.disccount);
    }

}

class AdvanceStoreFactory implements StoreAbastractFactory {
    private readonly unitvalue: number;
    private readonly quantity: number;
    private readonly tax: number;
    private readonly taxAdd2: number;
    private readonly disccount: number;

    constructor(unitValue: number, quantity: number, tax: number, taxAdd2: number, disccount: number) {
        this.unitvalue = unitValue;
        this.quantity = quantity;
        this.tax = tax;
        this.taxAdd2 = taxAdd2;
        this.disccount = disccount;
    }

    createProduct(): Product {
        return new ProductAdvanced(this.unitvalue, this.quantity, this.tax, this.taxAdd2, this.disccount)
    }
    createService(): Service {
        return new ServiceAdvance(this.unitvalue, this.disccount, this.taxAdd2);
    }

}

// Main
function appStoreFactory(factory: StoreAbastractFactory) {
    const product = factory.createProduct();
    const service = factory.createService();
    //

    product.getInvoice();
    const productPrice = product.getPrice();

    console.log(`price ${productPrice}`);

    service.getInvoice();
    const servicePrice = service.getPrice();

    console.log(`price ${servicePrice}`);
}

type factoryType = 'basic' | 'advance'

class Store {
    unitValue: number;
    quantity: number;
    tax: number;
    taxAdd2: number;
    disccount: number;
}

function createFactory(type: factoryType, store: Store) {
    const factories = {
        basic: BasicStoreFactory,
        advance: AdvanceStoreFactory
    };

    const Factory = factories[ type ];
    return new Factory(store.unitValue, store.quantity, store.tax, store.taxAdd2, store.disccount);
}

const store1: Store = {
    unitValue: 10000,
    quantity: 2,
    tax: 19,
    taxAdd2: 5,
    disccount: 2000
}

appStoreFactory(createFactory('basic', store1));
appStoreFactory(createFactory('advance', store1));