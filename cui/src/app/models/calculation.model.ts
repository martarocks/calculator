

export class Calculation {
    numbers: Array<number>;
    operands: Array<string>;
    constructor(calculation?: Partial<Calculation>) {
      Object.assign(this, calculation);
    }
  }
  