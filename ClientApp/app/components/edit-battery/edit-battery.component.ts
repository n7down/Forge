import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Http, RequestOptions, Headers } from '@angular/http';

@Component({
    selector: 'edit-battery',
    templateUrl: './edit-battery.component.html',
    styleUrls: ['./edit-battery.component.css']
})
export class EditBatteryComponent {
    private sub: any;
    private baseUrl: string;
    public battery: Battery;
    public id: string | undefined;
    
    constructor(private route: ActivatedRoute, private http: Http, @Inject('BASE_URL') baseUrl: string, private router: Router) {
        this.baseUrl = baseUrl;
    }
    
    ngOnInit() {
		this.sub = this.route.params.subscribe(params => {
			this.id = params['id'];
			this.http.get(this.baseUrl + 'api/v1/battery/' + this.id).subscribe(result => {
		     	this.battery = result.json() as Battery
			}, error => console.error(error));
		});
    }

    update() {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        let options = new RequestOptions({ headers: headers });
        let body = JSON.stringify(this.battery);
        this.http.put(this.baseUrl + 'api/v1/battery/' + this.id, body, options).subscribe(result => {
            this.battery = result.json() as Battery;
            this.router.navigate(['/battery/' + this.id]);
        }, error => console.error(error));
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }
}

interface Battery {
    id: string;
    name: string;
    lipoVoltage: string;
    mAh: string;
    cRating: string;
    plugType: string;
    weight: string;
    dimension: string;
    link: string;
}
