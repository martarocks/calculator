import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';

import { CalcService } from '../services/calc.service';
import { Calculation } from '../models/calculation.model';
@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css'],
})
export class CalculatorComponent implements OnInit {
  calculationModel: Calculation;
  constructor(private readonly calcService: CalcService) {}
  ngOnInit(): void {}
  expressionString = '';
  expression = '';
  expressionResults = '';

  numbers: Array<number> = [];
  operands: Array<string> = [];
  possibleKeys: Array<string> = ['/', '+', '-', '*'];

  activeKey(key: string) {
    const lastKeyPressed = this.expression[this.expression.length - 1];
    debugger;
    /// is it a valid operand
    if (this.possibleKeys.find((k) => k == key) != undefined) {
      // Entered operand before number?
      if (this.numbers.length > 0) {
        /// check foe sequence of operands
        var sequence = this.possibleKeys.find((k) => k == lastKeyPressed);
        if (sequence == undefined || lastKeyPressed == undefined) {
            this.operands.push(key);
            this.expression = this.expression + key;
            
        }
      }
    } else {
      this.numbers.push(parseInt(key));
      this.expression = this.expression + key;
    }
  }

  reset() {
    this.expression = '';
    this.expressionResults = '';

    localStorage.removeItem('result');
  }

  store() {
    localStorage.setItem('result', this.expression);
  } 
  
  recall() {
    this.expression = localStorage.getItem('result');
  }

  back() {
    debugger;
    this.expression = this.expression.substring(0,this.expression.length-1);
  }

  calculate() {
    debugger;
    this.calculationModel = new Calculation();
    this.calculationModel.numbers = [];
    this.calculationModel.operands = [];
    this.calculationModel.numbers = this.numbers;
    this.calculationModel.operands = this.operands;
    this.calcService.calculate(this.calculationModel).subscribe((data) => {
      this.expressionResults = data;
      this.expression = data;
    });
  }
}
