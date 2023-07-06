class Liquidation {
    private basicSalaryMontly: number;
    private monthsWorked: number;
    private pendingHolyDays: number;
    private premiumEndYear: number;
    private premiumMediumYear: number;
    private layoffs: number;

    /**
     *
     */
    constructor(
        basicSalaryMontly: number,
        monthsWorked: number,
        pendingHolyDays: number,
        premiumEndYear: number,
        premiumMediumYear: number,
        layoffs: number) {

        this.basicSalaryMontly = basicSalaryMontly;
        this.monthsWorked = monthsWorked;
        this.pendingHolyDays = pendingHolyDays;
        this.premiumEndYear = premiumEndYear;
        this.premiumMediumYear = premiumMediumYear;
        this.layoffs = layoffs;
    }

    Calculate() {
        const totalPendingHollyDays = ((this.basicSalaryMontly / 30) * 365) * this.pendingHolyDays;
        const total = (this.basicSalaryMontly * this.monthsWorked) + totalPendingHollyDays + this.premiumEndYear + this.premiumMediumYear + this.layoffs;
        console.log("Vacaciones pendientes: ", totalPendingHollyDays);
        console.log("Liquidación Total ", total);
    }
}

class LiquidationBuilder {
    private basicSalaryMontly: number;
    private monthsWorked: number;
    private pendingHolyDays: number;
    private premiumEndYear: number;
    private premiumMediumYear: number;
    private layoffs: number;


    setBasicSalaryMonth(basicSalaryMontly: number): LiquidationBuilder {
        this.basicSalaryMontly = basicSalaryMontly;
        return this;
    }

    setMothsWorked(monthsWorked: number): LiquidationBuilder {
        this.monthsWorked = monthsWorked;
        return this;
    }

    setPendingHollyDays(pendingHolyDays: number): LiquidationBuilder {
        this.pendingHolyDays = pendingHolyDays;
        return this;
    }

    setPremiumEndYear(premiumEndYear: number): LiquidationBuilder {
        this.premiumEndYear = premiumEndYear;
        return this;
    }

    setPremiumMediumYear(premiumMediumYear: number): LiquidationBuilder {
        this.premiumMediumYear = premiumMediumYear;
        return this;
    }

    setLayoffs(layoffs: number): LiquidationBuilder {
        this.layoffs = layoffs;
        return this;
    }

    build(): Liquidation {
        return new Liquidation(this.basicSalaryMontly, this.monthsWorked, this.pendingHolyDays,
            this.premiumEndYear, this.premiumMediumYear, this.layoffs);
    }
}

const total = new LiquidationBuilder()
    .setBasicSalaryMonth(4500)
    .setLayoffs(500)
    .setMothsWorked(15)
    .setPremiumEndYear(1000)
    .setPremiumMediumYear(0)
    .setPendingHollyDays(15)
    .build();

console.log(total);
console.log(total.Calculate());