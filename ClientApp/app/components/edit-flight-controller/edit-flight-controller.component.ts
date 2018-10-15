import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Http, RequestOptions, Headers } from '@angular/http';

@Component({
    selector: 'edit-flight-controller',
    templateUrl: './edit-flight-controller.component.html',
    styleUrls: ['./edit-flight-controller.component.css']
})
export class EditFlightControllerComponent {
    private sub: any;
    private baseUrl: string;
    public flightController: FlightController;
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

    update() {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        let options = new RequestOptions({ headers: headers });
        let body = JSON.stringify(this.flightController);
        this.http.put(this.baseUrl + 'api/v1/fc/' + this.id, body, options).subscribe(result => {
            this.flightController = result.json() as FlightController;
            this.router.navigate(['/flight-controller/' + this.id]);
        }, error => console.error(error));
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
    osd: string;
    osdName: string;
    pdb: string;
    lipoVoltage: string;
    sdCard: string;
    weight: string;
    numberUarts: number;
    barometer: boolean;
    pwm: boolean;
    sbus: boolean;
    dsmTwo: boolean;
    ledStrip: boolean;
    videoIn: boolean;
    videoOut: boolean;
    buzzer: boolean;
    numberSoftSerials: number;
}
