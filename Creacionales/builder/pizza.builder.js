// Clase Pizza
var Pizza = /** @class */ (function () {
    function Pizza(dough, sauce, cheese, toppings) {
        this.dough = dough;
        this.sauce = sauce;
        this.cheese = cheese;
        this.toppings = toppings;
    }
    Pizza.prototype.getDough = function () {
        return this.dough;
    };
    Pizza.prototype.getSauce = function () {
        return this.sauce;
    };
    Pizza.prototype.getCheese = function () {
        return this.cheese;
    };
    Pizza.prototype.getToppings = function () {
        return this.toppings;
    };
    return Pizza;
}());
// Builder
var PizzaBuilder = /** @class */ (function () {
    function PizzaBuilder() {
        this.toppings = [];
    }
    PizzaBuilder.prototype.setDough = function (dough) {
        this.dough = dough;
        return this;
    };
    PizzaBuilder.prototype.setSauce = function (sauce) {
        this.sauce = sauce;
        return this;
    };
    PizzaBuilder.prototype.setCheese = function (cheese) {
        this.cheese = cheese;
        return this;
    };
    PizzaBuilder.prototype.addTopping = function (topping) {
        this.toppings.push(topping);
        return this;
    };
    PizzaBuilder.prototype.build = function () {
        return new Pizza(this.dough, this.sauce, this.cheese, this.toppings);
    };
    return PizzaBuilder;
}());
// Uso
var pizza = new PizzaBuilder()
    .setDough('thin')
    .setSauce('tomato')
    .setCheese('mozzarella')
    .addTopping('mushrooms')
    .addTopping('olives')
    .addTopping('onions')
    .build();
console.log(pizza);
