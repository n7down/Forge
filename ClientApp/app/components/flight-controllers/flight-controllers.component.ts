import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'flight-controllers',
    templateUrl: './flight-controllers.component.html',
    styleUrls: ['./flight-controllers.component.css']
})
export class FlightControllersComponent {
    public flightControllers: FlightController[] = [];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
		http.get(baseUrl + 'api/v1/fc').subscribe(result => {
            this.flightControllers = result.json() as FlightController[];
        }, error => console.error(error));
    }
}

interface FlightController {
    id: string;
    name: string;
    mcu: string;
    gyroName: string;
    osd: boolean;
    osdName: string;
    pdb: boolean;
    lipoVoltage: string;
    sdCard: boolean;
    weight: string;
    numberUarts: number;
    barometer: boolean;
    pwm: boolean;
    sbus: boolean;
    dsmTwo: boolean;
    ledStrip: boolean
    videoIn: boolean;
    videoOut: boolean;
    buzzer: boolean;
    numberSoftSerial: number;
}
