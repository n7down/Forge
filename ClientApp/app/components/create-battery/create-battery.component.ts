import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Http, RequestOptions, Headers } from '@angular/http';

@Component({
    selector: 'create-battery',
    templateUrl: './create-battery.component.html',
    styleUrls: ['./create-battery.component.css']
})
export class CreateBatteryComponent {
    private sub: any;
    private baseUrl: string;
    private battery: Battery | undefined;
    private id: string | undefined;
    
    constructor(private route: ActivatedRoute, private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
    }
    
    ngOnInit() {
    }

    submit() {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        let options = new RequestOptions({ headers: headers });
        let body = JSON.stringify(this.battery);
        this.http.post(this.baseUrl + 'api/v1/battery/', body, options).subscribe(result => {
            console.log(result.json());
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
    mah: number;
    cRating: string;
    plugType: string;
    weight: string;
    dimension: string;
    link: string;
}
