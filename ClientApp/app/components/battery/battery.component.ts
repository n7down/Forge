import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Http, RequestOptions, Headers } from '@angular/http';

@Component({
    selector: 'battery',
    templateUrl: './battery.component.html',
    styleUrls: ['./battery.component.css']
})
export class BatteryComponent implements OnInit, OnDestroy {
    private sub: any;
    private baseUrl: string;
    public battery: Battery | undefined;
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

    remove() {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        let options = new RequestOptions({ headers: headers });
        this.http.delete(this.baseUrl + 'api/v1/battery/' + this.id, options).subscribe(result => {
            this.router.navigate(['/batteries']);
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
    mah: string;
    cRating: string;
    plugType: string;
    weight: string;
    dimension: string;
    link: string;
}
