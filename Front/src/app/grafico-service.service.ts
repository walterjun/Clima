import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Temperatura } from './Models/temperatura';

@Injectable({
  providedIn: 'root'
})
export class GraficoServiceService {

  APIUrl:string = "http://localhost:39063/api"; 

  constructor(private http: HttpClient) { }

  buscar(cidade:string){
    let chamada = `/Pesquisa?cidade=${cidade}`;
    return this.http
            .get<Temperatura[]>(this.APIUrl + chamada);
  }
}
