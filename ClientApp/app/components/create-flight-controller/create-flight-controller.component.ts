import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Http, RequestOptions, Headers } from '@angular/http';

@Component({
    selector: 'create-flight-controller',
    templateUrl: './create-flight-controller.component.html',
    styleUrls: ['./create-flight-controller.component.css']
})
export class CreateFlightControllerComponent {
    public baseUrl: string;
    public name: string;
    public mcu: string;
    public gyroName: number;
    public osd: boolean;
    public osdName: string;
    public pdb: string;
    public lipoVoltage: string;
    public sdCard: string;
    public weight: string;
    public numberUarts: number;
    public barometer: boolean;
    public pwm: boolean;
    public sbus: boolean;
    public dsmTwo: boolean;
    public ledStrip: boolean;
    public videoIn: boolean;
    public videoOut: boolean;
    public buzzer: boolean;
    public numberSoftSerials: number;
    
    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string, private router: Router) {
        this.baseUrl = baseUrl;
    }

    create() {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        let options = new RequestOptions({ headers: headers });
        let body = JSON.stringify({ name: this.name, mcu: this.mcu, gyroName: this.gyroName, osd: this.osd, 
            osdName: this.osdName, pdb: this.pdb, lipoVoltage: this.lipoVoltage, sdCard: this.sdCard, weight: this.weight, 
            numberUarts: this.numberUarts, barometer: this.barometer, pwm: this.pwm, sbus: this.sbus, dsmTwo: this.dsmTwo,
            ledStrip: this.ledStrip, videoIn: this.videoIn, videoOut: this.videoOut, buzzer: this.buzzer, numberSoftSerials: this.numberSoftSerials });
        this.http.post(this.baseUrl + 'api/v1/fc/', body, options).subscribe(result => {
            this.router.navigate(['/flight-controllers']);
        }, error => console.error(error));
    }
}
