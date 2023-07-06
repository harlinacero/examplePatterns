// STEP 1
interface CPU {
    getSeries(): string
}

interface Memory {
    getCapacityInGB(): void;
}

interface Display {
    getResolution(): void;
}

// STEP 2

class CPUPhone implements CPU {
    series: string;
    constructor(series: string) {
        this.series = series;
    }
    getSeries(): string {
        return this.series
    }
}

class CPULaptop implements CPU {
    series: string;
    constructor(series: string) {
        this.series = series;
    }
    getSeries(): string {
        return this.series
    }
}

class CPUTablet implements CPU {
    series: string;
    constructor(series: string) {
        this.series = series;
    }
    getSeries(): string {
        return this.series
    }
}

class MemoryPhone implements Memory {
    memory: number;
    constructor(memory: number) {
        this.memory = memory;
    }
    getCapacityInGB(): number {
        return this.memory
    }
}

class MemoryLaptop implements Memory {
    memory: number;
    constructor(memory: number) {
        this.memory = memory;
    }
    getCapacityInGB(): number {
        return this.memory
    }
}

class MemoryTablet implements Memory {
    memory: number;
    constructor(memory: number) {
        this.memory = memory;
    }
    getCapacityInGB(): number {
        return this.memory
    }
}

class DisplayPhone implements Display {
    resolution: number;
    constructor(resolution: number) {
        this.resolution = resolution;
    }
    getResolution(): number {
        return this.resolution;
    }
}

class DisplayLaptop implements Display {
    resolution: number;
    constructor(resolution: number) {
        this.resolution = resolution;
    }
    getResolution(): number {
        return this.resolution;
    }
}

class DisplayTablet implements Display {
    resolution: number;
    constructor(resolution: number) {
        this.resolution = resolution;
    }
    getResolution(): number {
        return this.resolution;
    }
}

//Step 3

interface abstractFactory {
    cpu: string,
    memory: number,
    display: number,
    createCPU(): CPU,
    createMemory(): Memory,
    createDisplay(): Display
}

class Phone implements abstractFactory {
    cpu: string;
    memory: number;
    display: number;
    constructor(cpu: string, memory: number, display: number) {
        this.cpu = cpu;
        this.memory = memory;
        this.display = display;
    }

    createCPU(): CPU {
        return new CPUPhone(this.cpu)
    }
    createMemory(): Memory {
        return new MemoryPhone(this.memory);
    }
    createDisplay(): Display {
        return new DisplayPhone(this.display);
    }
}

class Tablet implements abstractFactory {
    cpu: string;
    memory: number;
    display: number;
    constructor(cpu: string, memory: number, display: number) {
        this.cpu = cpu;
        this.memory = memory;
        this.display = display;
    }

    createCPU(): CPU {
        return new CPUPhone(this.cpu)
    }
    createMemory(): Memory {
        return new MemoryPhone(this.memory);
    }
    createDisplay(): Display {
        return new DisplayPhone(this.display);
    }
}

function app(factory: abstractFactory) {
    const cpu = factory.createCPU()
    console.log("Cpu ", cpu.getSeries())

    const memory = factory.createMemory()
    console.log("Memory ", memory.getCapacityInGB())

    const display = factory.createDisplay()
    console.log("Display ", display.getResolution())
}

app(new Phone("m1", 128, 1200))
app(new Tablet("m2", 512, 2200))