import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Http, RequestOptions, Headers } from '@angular/http';

@Component({
    selector: 'flight-controller',
    templateUrl: './flight-controller.component.html',
    styleUrls: ['./flight-controller.component.css']
})
export class FlightControllerComponent implements OnInit, OnDestroy {
    private sub: any;
    private baseUrl: string;
    public flightController: FlightController | undefined;
    public id: string | undefined;
    
    constructor(private route: ActivatedRoute, private http: Http, @Inject('BASE_URL') baseUrl: string, private router: Router) {
        this.baseUrl = baseUrl;
    }
    
    ngOnInit() {
		this.sub = this.route.params.subscribe(params => {
			this.id = params['id'];
			this.http.get(this.baseUrl + 'api/v1/fc/' + this.id).subscribe(result => {
		     	this.flightController = result.json() as FlightController
			}, error => console.error(error));
		});
    }

    remove() {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        let options = new RequestOptions({ headers: headers });
        this.http.delete(this.baseUrl + 'api/v1/fc/' + this.id, options).subscribe(result => {
        }, error => console.error(error));
        this.router.navigate(['/flight-controllers']);
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
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
