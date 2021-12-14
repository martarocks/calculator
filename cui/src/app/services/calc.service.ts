import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CalcService {
  private apiPath: string = 'https://localhost:4001/calculator/';
  constructor(private readonly http: HttpClient) {}

  public calculate(data: any): Observable<any> {
      return this.http.post<any>(`${this.apiPath}`, data);
   }
  
  public get(): Observable<any> {
    return this.http.get('https://localhost:4001/weatherforecast');
 }
}