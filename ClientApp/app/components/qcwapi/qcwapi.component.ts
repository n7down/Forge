import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'qcwapi',
    templateUrl: './qcwapi.component.html'
})
export class QuadcopterWorkbenchAPIComponent {
    public baseUrl: string;
    public data: string = "no data";

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
        this.http.get(this.baseUrl + 'api/fc').subscribe(result => {
            var flightControllers = result.json() as FlightController[];
            this.data = JSON.stringify(flightControllers, null, 2);
        }, error => console.error(error));
    }

    public request() {
        this.http.get(this.baseUrl + 'api/fc').subscribe(result => {
            var flightControllers = result.json() as FlightController[];
            this.data = JSON.stringify(flightControllers, null, 2);
        }, error => console.error(error));
    }
}

interface FlightController {
    id: number;
    name: string;
    mcu: string;
    gyroName:string;
    osd: boolean;
    osdName: string;
    pdb: boolean;
    lipoVoltage: string;
    sdCard: boolean;
    weight: number;
    numberUARTS: number;
    barometer: boolean;
    pwm: boolean;
    sbus: boolean;
    dsmTwo: boolean;
    ledStrip: boolean;
    videoIn: boolean;
    videoOut: boolean;
    buzzer: boolean;
    numberSoftSerial: number;
    size: string;
    mountingHoles: string;
}
