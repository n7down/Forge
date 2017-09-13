import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'qcwapi',
    templateUrl: './qcwapi.component.html'
})
export class QuadcopterWorkbenchAPIComponent {
    public forecasts: WeatherForecast[];
    public baseUrl: string;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        // http.get(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
        //     this.forecasts = result.json() as WeatherForecast[];
        // }, error => console.error(error));
        console.log(baseUrl);
        baseUrl = baseUrl;
    }

    public request() {
        // this.http.get(this.baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
        //     this.forecasts = result.json() as WeatherForecast[];
        // }, error => console.error(error));
        this.http.get(this.baseUrl + 'api/fc').subscribe(result => {
            console.log(result.json());
        }, error => console.error(error));
    }
}

interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}
