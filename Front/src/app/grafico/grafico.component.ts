import { Component, OnInit } from '@angular/core';
import * as Highcharts from 'highcharts';
import { GraficoServiceService } from '../grafico-service.service';
import { Temperatura } from '../Models/temperatura';

declare var require: any;
let Boost = require('highcharts/modules/boost');
let noData = require('highcharts/modules/no-data-to-display');
let More = require('highcharts/highcharts-more');

Boost(Highcharts);
noData(Highcharts);
More(Highcharts);
noData(Highcharts);


@Component({
  selector: 'app-grafico',
  templateUrl: './grafico.component.html',
  styleUrls: ['./grafico.component.css']
})
export class GraficoComponent implements OnInit {

  public capitais = [
    'Selecione',
    'Rio Branco',
    'Maceió',
    'Macapá',
    'Manaus',
    'Salvador',
    'Fortaleza',
    'Brasília',
    'Vitória',
    'Goiânia',
    'São Luís',
    'Cuiabá',
    'Campo Grande',
    'Belo Horizonte',
    'Belém',
    'João Pessoa',
    'Curitiba',
    'Recife',
    'Teresina',
    'Rio de Janeiro',
    'Natal',
    'Porto Alegre',
    'Porto Velho',
    'Boa Vista',
    'Florianópolis',
    'São Paulo',
    'Aracaju',
    'Palmas'
  ];

  public options: any;
  public chart: Highcharts.Chart;

  constructor(private servico: GraficoServiceService) { }

  ngOnInit(): void {
    this.gerarGrafico('').then(() => this.chart = Highcharts.chart('container', this.options));
  }

  onChange(cidade){
    this.gerarGrafico(cidade);
  }

  async gerarGrafico(cidade){
    var listaTempMin = [];
    var listaTempMax = [];
    cidade = ((cidade == '' || cidade == 'Selecione') ? 'Curitiba' : cidade);
   var result = await this.servico.buscar(cidade).toPromise();

   result.forEach(x => {
        listaTempMin.push([new Date(x.dt.toString()).getTime(), parseFloat(x.temp_min.replace(',','.'))]);
        listaTempMax.push([new Date(x.dt.toString()).getTime(), parseFloat(x.temp_max.replace(',','.'))]);
      });

      if(this.options){
        this.options.series[0].data = listaTempMax;
        this.options.series[1].data = listaTempMin;
        this.options.title.text = `Temperatura para ${cidade}`;
        this.chart = Highcharts.chart('container', this.options);
      }else{
    
    this.options = {
      chart: {
        type: 'line',
        width: 800
      },
      title: {
        text: `Temperatura para ${cidade}`
      },
      credits: {
        enabled: false
      },
      tooltip: {
        formatter: function() {
          return 'Data: ' + Highcharts.dateFormat('%e %b %y %H:%M:%S',this.x) + ' Temperatura: ' + this.y.toFixed(2);
        }
      },
      xAxis: {
        type: 'datetime',
        labels: {
          formatter: function() {
            return Highcharts.dateFormat('%e %b %y', this.value);
          }
        }
      },
      series: [
        {
          name: 'Temp. Max.',
          turboThreshold: 500000,
          data: listaTempMax,
          color: '#FF2D00'
        },
        {
          name: 'Temp. Min.',
          turboThreshold: 500000,
          data: listaTempMin,
          color: '#0F00FF'
        }
      ]
    }
  }
  }

}
