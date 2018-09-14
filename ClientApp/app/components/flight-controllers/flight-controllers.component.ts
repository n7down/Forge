import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'flight-controllers',
    templateUrl: './flight-controllers.component.html'
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
    gyroname: string;
    osd: boolean;
    osdname: string;
    pdb: boolean;
    lipovoltage: string;
    sdcard: boolean;
    weight: string;
    numberuarts: number;
    barometer: boolean;
    pwm: boolean;
    sbus: boolean;
    dsmtwo: boolean;
    ledstrip: boolean
    videoin: boolean;
    videoout: boolean;
    buzzer: boolean;
    numbersoftserial: number;
}
