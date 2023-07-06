var Liquidation = /** @class */ (function () {
    /**
     *
     */
    function Liquidation(basicSalaryMontly, monthsWorked, pendingHolyDays, premiumEndYear, premiumMediumYear, layoffs) {
        this.basicSalaryMontly = basicSalaryMontly;
        this.monthsWorked = monthsWorked;
        this.pendingHolyDays = pendingHolyDays;
        this.premiumEndYear = premiumEndYear;
        this.premiumMediumYear = premiumMediumYear;
        this.layoffs = layoffs;
    }
    Liquidation.prototype.Calculate = function () {
        var totalPendingHollyDays = ((this.basicSalaryMontly / 30) * 365) * this.pendingHolyDays;
        var total = (this.basicSalaryMontly * this.monthsWorked) + totalPendingHollyDays + this.premiumEndYear + this.premiumMediumYear + this.layoffs;
        console.log("Vacaciones pendientes: ", totalPendingHollyDays);
        console.log("Liquidación Total ", total);
        // console.log(this.basicSalaryMontly);
        // console.log(this.layoffs);
        // console.log(this.monthsWorked);
        // console.log(this.premiumEndYear);
        // console.log(this.premiumMediumYear);
        // console.log(this.pendingHolyDays);
    };
    return Liquidation;
}());
var LiquidationBuilder = /** @class */ (function () {
    function LiquidationBuilder() {
    }
    LiquidationBuilder.prototype.setBasicSalaryMonth = function (basicSalaryMontly) {
        this.basicSalaryMontly = basicSalaryMontly;
        return this;
    };
    LiquidationBuilder.prototype.setMothsWorked = function (monthsWorked) {
        this.monthsWorked = monthsWorked;
        return this;
    };
    LiquidationBuilder.prototype.setPendingHollyDays = function (pendingHolyDays) {
        this.pendingHolyDays = pendingHolyDays;
        return this;
    };
    LiquidationBuilder.prototype.setPremiumEndYear = function (premiumEndYear) {
        this.premiumEndYear = premiumEndYear;
        return this;
    };
    LiquidationBuilder.prototype.setPremiumMediumYear = function (premiumMediumYear) {
        this.premiumMediumYear = premiumMediumYear;
        return this;
    };
    LiquidationBuilder.prototype.setLayoffs = function (layoffs) {
        this.layoffs = layoffs;
        return this;
    };
    LiquidationBuilder.prototype.build = function () {
        return new Liquidation(this.basicSalaryMontly, this.monthsWorked, this.pendingHolyDays, this.premiumEndYear, this.premiumMediumYear, this.layoffs);
    };
    return LiquidationBuilder;
}());
var total = new LiquidationBuilder()
    .setBasicSalaryMonth(4500)
    .setLayoffs(500)
    .setMothsWorked(15)
    .setPremiumEndYear(1000)
    .setPremiumMediumYear(0)
    .setPendingHollyDays(15)
    .build();
console.log(total);
console.log(total.Calculate());
