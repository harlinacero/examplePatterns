// Clase Pizza
class Pizza {
    private dough: string;
    private sauce: string;
    private cheese: string;
    private toppings: string[];

    constructor(
        dough: string,
        sauce: string,
        cheese: string,
        toppings: string[]
    ) {
        this.dough = dough;
        this.sauce = sauce;
        this.cheese = cheese;
        this.toppings = toppings;
    }

    public getDough(): string {
        return this.dough;
    }

    public getSauce(): string {
        return this.sauce;
    }

    public getCheese(): string {
        return this.cheese;
    }

    public getToppings(): string[] {
        return this.toppings;
    }
}

// Builder
class PizzaBuilder {
    private dough: string;
    private sauce: string;
    private cheese: string;
    private toppings: string[];

    constructor() {
        this.toppings = [];
    }

    public setDough(dough: string): PizzaBuilder {
        this.dough = dough;
        return this;
    }

    public setSauce(sauce: string): PizzaBuilder {
        this.sauce = sauce;
        return this;
    }

    public setCheese(cheese: string): PizzaBuilder {
        this.cheese = cheese;
        return this;
    }

    public addTopping(topping: string): PizzaBuilder {
        this.toppings.push(topping);
        return this;
    }

    public build(): Pizza {
        return new Pizza(this.dough, this.sauce, this.cheese, this.toppings);
    }
}

// Uso
const pizza = new PizzaBuilder()
    .setDough('thin')
    .setSauce('tomato')
    .setCheese('mozzarella')
    .addTopping('mushrooms')
    .addTopping('olives')
    .addTopping('onions')
    .build();

console.log(pizza);