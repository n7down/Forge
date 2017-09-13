import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'qcwapi',
    templateUrl: './qcwapi.component.html'
})
export class QuadcopterWorkbenchAPIComponent {
    public forecasts: WeatherForecast[];
    public baseUrl: string;
    public data: string = "no data";

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
    }

    public request() {
        this.http.get(this.baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {

            // TODO: setup for flight controller interface
            this.forecasts = result.json() as WeatherForecast[];
            this.data = JSON.stringify(this.forecasts, null, 2);
        }, error => console.error(error));
        // this.http.get(this.baseUrl + 'api/fc').subscribe(result => {
        //     this.data = JSON.parse(result.json());
        // }, error => console.error(error));
    }
}

interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

// interface FlightController {
//     public long Id { get; set; }
//     public string Name { get; set; }
//     public string MCU { get; set; }
//     public string GyroName { get; set; }
//     public bool OSD { get; set; }
//     public string OSDName { get; set; }
//     public bool PDB { get; set; }
//     public string LipoVoltage { get; set; }
//     public bool SDCard { get; set; }

//     // weight in grams
//     public float Weight { get; set; }
//     public int NumberUARTS { get; set; }
//     public bool Barometer { get; set; }
//     public bool PWM { get; set; }
//     public bool SBUS { get; set; }
//     public bool DSMTwo { get; set; }
//     public bool LedStrip { get; set; }
//     public bool VideoIn { get; set; }
//     public bool VideoOut { get; set; }
//     public bool Buzzer { get; set; }
//     public int NumberSoftSerial { get; set; }
//     public string Size { get; set; }
//     public string MountingHoles { get; set; }
// }
